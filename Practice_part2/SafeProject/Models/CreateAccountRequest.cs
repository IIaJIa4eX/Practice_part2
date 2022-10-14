using SafeProjectDBLib.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SafeProject.Models
{
    //for_review
    public class CreateAccountRequest
    {

        [StringLength(255)]
        public string? Emal { get; set; }


        [StringLength(255)]
        public string? Password { get; set; }


        [StringLength(255)]
        public string? FirstName { get; set; }

        [StringLength(255)]
        public string? LastName { get; set; }

        [StringLength(255)]
        public string? SecondName { get; set; }

    }
}
