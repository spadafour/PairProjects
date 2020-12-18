using System;
using System.Collections.Generic;
using System.Text;

namespace TEams.Classes
{
    class Employee
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double Salary { get; private set; } = 60000;
        public Department Department { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName { get { return $"{LastName}, {FirstName}"; } }
        
        public Employee() { }
        public Employee(long employeeId, string firstName, string lastName, string email, Department department, DateTime hireDate)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Department = department;
            HireDate = hireDate;
        }

        public void RaiseSalary(double percent)
        {
            double raise = Salary * percent / 100;
            Salary += raise;
        }
    }
}
