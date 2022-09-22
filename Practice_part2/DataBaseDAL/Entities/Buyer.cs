using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDAL.Entities
{
        [Table("Buyers")]
        public class Buyer : NamedEntity
        {
            public string? LastName { get; set; }

            public string? Patronymic { get; set; }

            public DateTime Birthday { get; set; }
        }
    
}

