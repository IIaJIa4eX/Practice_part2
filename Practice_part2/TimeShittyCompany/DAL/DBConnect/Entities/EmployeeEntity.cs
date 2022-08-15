using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.DAL.DBContext.Entities
{

    [Table("Employees", Schema = "Test")]
    public sealed class EmployeeEntity
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
        public int Age { get; set; }


    }
}
