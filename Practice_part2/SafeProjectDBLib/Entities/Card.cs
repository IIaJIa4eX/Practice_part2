using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeProjectDBLib.Entities
{
    [Table("Cards")]
    public class Card
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; } = -1;

        [Column]
        [StringLength(255)]
        public string? OwnerName { get; set; } = string.Empty;
        [Column]
        [StringLength(50)]
        public string? CVV2 { get; set; } = string.Empty;

        [Column]
        [StringLength(255)]
        public string? CardNumber { get; set; } = string.Empty;

        [Column]
        public DateTime ExpDate { get; set; } = DateTime.UtcNow;

        public virtual Client Client { get; set; } = null;

       
    }
}
