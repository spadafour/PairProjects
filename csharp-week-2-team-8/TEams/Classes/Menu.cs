using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Text;

namespace TEams.Classes
{
    class Menu
    {
        //Lists and Dictionaries
        public List<Department> departments = new List<Department>();
        private List<Employee> employees = new List<Employee>();
        private Dictionary<string, Project> projects = new Dictionary<string, Project>();

        public void CreateDepartments()
        {
            Department marketing = new Department(001, "Marketing");
            Department sales = new Department(002, "Sales");
            Department engineering = new Department(003, "Engineering");

            departments.Add(marketing);
            departments.Add(sales);
            departments.Add(engineering);
        }

        public void PrintDepartments()
        {
            Console.WriteLine("------------- DEPARTMENTS ------------------------------");
            foreach (Department department in departments)
            {
                Console.WriteLine(department.Name);
            }
        }

        private Department FindDepartmentByName(string deptName)
        {
            foreach (Department department in departments)
            {
                if (department.Name == deptName)
                {
                    return department;
                }
            }
            return null;
            
        }

        public void CreateEmployees()
        {
            Employee dJohnson = new Employee()
            {
                EmployeeId = 001,
                FirstName = "Don",
                LastName = "Johnson",
                Email = "djohnson@teams.com",
                Department = FindDepartmentByName("Engineering"),
                HireDate = new DateTime(2020, 08, 21),
            };
            Employee aSmith = new Employee(002, "Angie", "aSmith", "asmith@teams.com", FindDepartmentByName("Engineering"), new DateTime(2020, 08, 21));
            Employee mThompson = new Employee(003, "Margaret", "Thompson", "mthompson@teams.com", FindDepartmentByName("Marketing"), new DateTime (2020, 08, 21));

            employees.Add(dJohnson);
            employees.Add(aSmith);
            employees.Add(mThompson);
        }

        public void GiveRaiseToAngie(double percent)
        {
            employees[1].RaiseSalary(percent);
        }

        public void PrintEmployees()
        {
            Console.WriteLine("\n------------- EMPLOYEES ------------------------------");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.LastName}, {employee.FirstName} ({employee.Salary.ToString("C2")}) {employee.Department.Name}");
            }
        }

        public void CreateTeamsProject()
        {
            Project tEams = new Project("TEams", "Project Management Software", DateTime.Today, DateTime.Today.AddDays(30));
            foreach (Employee engineer in employees)
            {
                if (engineer.Department == FindDepartmentByName("Engineering"))
                {
                    tEams.TeamMembers.Add(engineer);
                }
            }

            projects[tEams.Name] = tEams;
        }

        public void CreateLandingPageProject()
        {
            Project marketingLandingPage = new Project("Marketing Landing Page", "Lead Capture Landing Page for Marketing", DateTime.Today.AddDays(31), DateTime.Today.AddDays(38));
            foreach (Employee marketer in employees)
            {
                if (marketer.Department == FindDepartmentByName("Marketing"))
                {
                    marketingLandingPage.TeamMembers.Add(marketer);
                }
            }

            projects[marketingLandingPage.Name] = marketingLandingPage;
        }

        public void PrintProjectsReport()
        {
            Console.WriteLine("\n------------- PROJECTS ------------------------------");
            foreach (KeyValuePair<string, Project> project in projects)
            {
                Console.WriteLine($"{project.Key}: {project.Value.TeamMembers.Count}");
            }

        }

    }
}
