using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC_Test_DataBase_Clinic
{
    //for_review
    [Table("Pets")]
    public class Pet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [Column]
        [StringLength(255)]
        public string? Name { get; set; }

        [Column]
        public DateTime Birthday { get; set; }

        public Client Client { get; set; }

        [InverseProperty(nameof(Consultation.Pet))]
        public ICollection<Consultation> Consultations { get; set; } = new HashSet<Consultation>();
    }
}
