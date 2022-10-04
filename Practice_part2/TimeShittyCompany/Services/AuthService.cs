using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Authorization;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;

namespace TimeShittyCompany.Services
{
    //for review
    public class AuthService : IAuthService
    {
        IUsersRepository _usersRepository;

        public const string secretWord = "!@#^#&&^(%^$_ADFSGJ_vbcn<>?";

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public string Authenticate(string email, string password)
        {
            User tmpUser = _usersRepository.CheckData(email, password);

            if (tmpUser != null && tmpUser.Id != -1)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(secretWord);
                SecurityTokenDescriptor tokenDescriptor = new
                SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, tmpUser.Id.ToString())
                }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new
                SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token =
                tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return string.Empty;
        }

        public JwtTokenResponse Authenticate_TokenResp(string email, string password)
        {

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            User tmpUser = _usersRepository.CheckData(email, password);
            
            if (tmpUser != null)
            {
                JwtTokenResponse tokenResponse = new JwtTokenResponse();

                tokenResponse.Token = GenerateJwtToken(tmpUser.Id, 15);
                RefreshToken refreshToken = GenerateRefreshToken(tmpUser.Id);

                tmpUser.Expires = refreshToken.Expires;
                tmpUser.Token = refreshToken.Token;
                _usersRepository.UpdateById(tmpUser);

                tokenResponse.RefreshToken = refreshToken.Token;
                return tokenResponse;
            }  

            return null;
        }

        public string RefreshToken(string token)
        {


                User tmpUser = _usersRepository.FindToken(token);

                if(tmpUser.Id != -1 && tmpUser != null && DateTime.Now < tmpUser.Expires) { 

                    RefreshToken tmpRefToken = GenerateRefreshToken(tmpUser.Id);
                    tmpUser.Expires = tmpRefToken.Expires;
                    tmpUser.Token = tmpRefToken.Token;

                    _usersRepository.UpdateById(tmpUser);

                    return tmpRefToken.Token;
                }
            
            return string.Empty;
        }


        private string GenerateJwtToken(int id, int minutes)
        {
            JwtSecurityTokenHandler tokenHandler = new
            JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretWord);
            SecurityTokenDescriptor tokenDescriptor = new
            SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, id.ToString()) }),
                Expires = DateTime.Now.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new
                SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(int id)
        {
            RefreshToken refreshToken = new RefreshToken();
            refreshToken.Expires = DateTime.Now.AddMinutes(30);
            refreshToken.Token = GenerateJwtToken(id, 30);
            return refreshToken;
        }


    }
}