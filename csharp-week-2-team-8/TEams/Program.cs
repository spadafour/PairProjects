using System;
using System.Collections.Generic;
using TEams.Classes;

namespace TEams
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu();
            

            // create some departments
            mainMenu.CreateDepartments();

            // print each department by name
            mainMenu.PrintDepartments();

            // create employees
            mainMenu.CreateEmployees();

            // give Angie a 10% raise, she is doing a great job!
            mainMenu.GiveRaiseToAngie(10);

            // print all employees
            mainMenu.PrintEmployees();

            // create the TEams project
            mainMenu.CreateTeamsProject();

            // create the Marketing Landing Page Project
            mainMenu.CreateLandingPageProject();

            // print each project name and the total number of employees on the project
            mainMenu.PrintProjectsReport();
        }
    }
}
