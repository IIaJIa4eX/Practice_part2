using System;

namespace lesson_3_patterns_part1
{
    //for_review
    public abstract class Employee
    {
        protected internal int _Rate { get; set; }

        protected internal string _EmployeeName { get; set; }

        protected internal string _SecondName { get; set; }
        protected internal abstract void CalculateIncome();
    }

    public class FixedSalaryEmploee : Employee
    {


        public FixedSalaryEmploee()
        {
          
        }


        protected internal override void CalculateIncome()
        {

            Console.WriteLine($"Monthly average: {_Rate}") ;
        }



    }
    public class HourlyPaymentEmployee : Employee
    {


        public HourlyPaymentEmployee()
        {
            
        }

        protected internal override void CalculateIncome()
        {

            Console.WriteLine($"Monthly average : { 20.8 * 8 * _Rate}");
        }
    }

    public class EmployeeFactory
    {
        public TEmployee CreateEmployee<TEmployee>(int rate, string name, string secondName = "") where TEmployee: Employee, new()
        {
            //TEmployee emp = new TEmployee();
            //emp._EmployeeName = name;
            //emp._Rate = rate;
            TEmployee emp = new EmployeeBuilder<TEmployee>()
                .SetName(name)
                .SetSecondName(secondName)
                .SetRate(rate)
                .Build();
            return emp;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();

            var e1 = employeeFactory.CreateEmployee<HourlyPaymentEmployee>(20, "Derek");
            e1.CalculateIncome();
            Employee[] employees = new Employee[]
            {
                employeeFactory.CreateEmployee<HourlyPaymentEmployee>(20, "Rahim","Hooladakri"),
                employeeFactory.CreateEmployee<FixedSalaryEmploee>(60, "John"),
                employeeFactory.CreateEmployee<HourlyPaymentEmployee>(34, "Babel"),
                employeeFactory.CreateEmployee<FixedSalaryEmploee>(45, "高橋"),
                employeeFactory.CreateEmployee<HourlyPaymentEmployee>(77, "Ivan"),

            };

            for(int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Name: {employees[i]._EmployeeName}. Secondname:{employees[i]._SecondName}. Rate: {employees[i]._Rate}");
                employees[i].CalculateIncome();
            }
            Console.WriteLine("end");
        }


        
    }

    public class EmployeeBuilder<T> where T : Employee, new()
    {
        private readonly T TEmployee = new T();

        public EmployeeBuilder<T> SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                TEmployee._EmployeeName = name;
                return this;
            }
            TEmployee._EmployeeName = "Undefined";
            return this;
        }

        public EmployeeBuilder<T> SetSecondName(string secondName)
        {
            if (!string.IsNullOrEmpty(secondName))
            {
                TEmployee._SecondName = secondName;
                return this;
            }
            TEmployee._SecondName = "Undefined";
            return this;
        }

        public EmployeeBuilder<T> SetRate(int rate)
        {
            TEmployee._Rate = rate;
            return this;
        }

        public T Build()
        {
            return TEmployee;
        }

    }
}
