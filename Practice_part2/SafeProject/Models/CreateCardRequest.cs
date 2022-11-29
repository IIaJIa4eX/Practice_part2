using System.ComponentModel.DataAnnotations;

namespace SafeProject.Models
{
    public class CreateCardRequest
    {
        [Required]
        public int CardId { get; set; }

        public int ClientId { get; set; }

        [Required]
        [StringLength(50)]
        public string? OwnerName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? CVV2 { get; set; } = string.Empty;

        [StringLength(255)]
        public string? CardNumber { get; set; } = string.Empty;
        public DateTime ExpDate { get; set; }
    }
}
