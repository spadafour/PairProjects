using System;
using System.Collections.Generic;
using System.Text;

namespace TEams.Classes
{
    class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime DueDate { get; set; }
        public List<Employee> TeamMembers { get; set; } = new List<Employee>();

        public Project(string name, string description, DateTime startDate, DateTime dueDate)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            DueDate = dueDate;
        }
    }
}
