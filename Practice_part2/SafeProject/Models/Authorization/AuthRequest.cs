using System.ComponentModel.DataAnnotations;

namespace SafeProject.Models.Authorization
{
    public class AuthRequest
    {
        [Required]
        public string? login { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
