using System;
using System.Collections.Generic;
using System.Text;

namespace TEams.Classes
{
    class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public Department(int departmentId, string name)
        {
            DepartmentId = departmentId;
            Name = name;
        }
    }
}
