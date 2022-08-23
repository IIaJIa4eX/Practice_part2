using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Models
{
    // [Table("Employees", Schema = "vma")]
    public class Employee
    {
        private long _id;
        private string _name;

        public long id
        {
            get => _id;
            set => _id = value;
        }
        public string name
        {
            get => _name;
            set => _name = value;
        }

        internal Employee(long id, string name)
        {
            _id = id;
            _name = name;
        }

        internal Employee() { }
    }

    public class EmployeeFactory
    {
        public Employee Create(long id, string name) => new Employee(id, name);
    }
}