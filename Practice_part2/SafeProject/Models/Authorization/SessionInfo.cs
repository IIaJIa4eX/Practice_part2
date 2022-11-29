using SafeProjectDBLib.Entities;

namespace SafeProject.Models.Authorization
{
    public class SessionInfo
    {
        public int SessionId { get; set; }
        public string SessionToken { get; set; }

        public AccountDTO Account { get; set; } 
    }
}
