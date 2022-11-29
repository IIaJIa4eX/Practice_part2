using System.ComponentModel.DataAnnotations.Schema;

namespace final_project.DAL.Entities
{
    [Table("Users")]
    public class User : NamedEntity
    {
            
            public string? LastName { get; set; }

            public string? Patronymic { get; set; }

            public string? Email { get; set; }
    }
}
