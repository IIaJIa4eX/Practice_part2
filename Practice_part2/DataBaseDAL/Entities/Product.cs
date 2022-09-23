using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDAL.Entities
{
    //for_review

    [Table("Products")]
    public class Product : NamedEntity
    {
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string? Category { get; set; }
    }
}
