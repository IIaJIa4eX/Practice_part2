using Microsoft.IdentityModel.Tokens;
using NLog.Fluent;
using SafeProject.Models.Authorization;
using SafeProject.Services.Interfaces;
using SafeProjectDBLib;
using SafeProjectDBLib.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SafeProject.Services
{
    public class AuthService : IAuthService
    {

        private readonly Dictionary<string,SessionInfo> _sessions = new Dictionary<string, SessionInfo>();
        private readonly IServiceScopeFactory _IServiceScopeFactory;

        public const string secretWord = "!@#^#&&^(%^$_ADFSGJ_vbcn<>?";

        public AuthService(IServiceScopeFactory serviceScopeFactory)
        {
            _IServiceScopeFactory = serviceScopeFactory;
        }

        public SessionInfo GetSessionInfo(string sessionToken)
        {
            SessionInfo sessionInfo;
            lock (_sessions)
            {
                _sessions.TryGetValue(sessionToken, out sessionInfo);
            }

            if(sessionInfo == null)
            {
                using IServiceScope scope = _IServiceScopeFactory.CreateScope();
                CardStorageDbConnection context = scope.ServiceProvider.GetRequiredService<CardStorageDbConnection>();

                AccountSession accSession = context.AccountSessions
                .Where(acc => acc.SessionToken == sessionToken)
                .FirstOrDefault();
                if(accSession == null)
                {
                    return null;
                }

                Account account = context.Accounts
                .Where(acc => acc.AccountId == accSession.AccountId)
                .FirstOrDefault();

                sessionInfo = GetSession(account, accSession);

                if(sessionInfo != null)
                {
                    lock (_sessions)
                    {
                        _sessions[sessionToken] = sessionInfo;
                    }
                }

            }

            return sessionInfo;
        }

        public AuthResponse Login(AuthRequest authRequest)
        {
            using IServiceScope scope = _IServiceScopeFactory.CreateScope();
            CardStorageDbConnection context = scope.ServiceProvider.GetRequiredService<CardStorageDbConnection>();

            if (!string.IsNullOrWhiteSpace(authRequest.login))
             {
                Account account = FindByLoginPass(context, authRequest.login, authRequest.password);

                if (account == null)
                {
                    return new AuthResponse()
                    {
                        AuthStatus = AuthStatus.NotFound
                    };
                }

                AccountSession accSession = new AccountSession()
                {
                    AccountId = account.AccountId,
                    SessionToken = CreateSessionToken(account),
                    TimeCreated = DateTime.Now,
                    TimeLastRequest = DateTime.Now,
                    IsClosed = false,
                };

                context.AccountSessions.Add(accSession);
                context.SaveChanges();

                SessionInfo sessionInfo = GetSession(account, accSession);

                lock (_sessions) {
                    if (!_sessions.ContainsKey(sessionInfo.SessionToken))
                    {
                        _sessions.Add(sessionInfo.SessionToken, sessionInfo);
                    }
                    else
                    {
                        _sessions[sessionInfo.SessionToken] = sessionInfo;
                    }
                }

                return new AuthResponse() { AuthStatus = AuthStatus.Sucess, SessionInfo = sessionInfo };

             }

            return null;

        }

        private SessionInfo GetSession(Account account, AccountSession accountSession)
        {
            return new SessionInfo()
            {
                SessionId = accountSession.AccountId,
                SessionToken = accountSession.SessionToken,
                Account = new AccountDTO()
                {
                    AccountId = account.AccountId,
                    Email = account.Emal

                }
            };
        }


        private string CreateSessionToken(Account account)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretWord);
            SecurityTokenDescriptor tokenDescriptor = new
            SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new
            SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token =
            tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public string RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        private Account FindByLoginPass(CardStorageDbConnection context, string login, string password)
        {
            return context.Accounts
                .Where(acc => acc.Emal == login && acc.Password == password)
                .FirstOrDefault();
        }
    }
}
