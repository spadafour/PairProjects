using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PetElevator.HR;

namespace PetElevator.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void FullNameReturnsCorrectFormat()
        {
            Employee employee = new Employee("Test", "Testerson");

            string fullName = employee.FullName;

            Assert.AreEqual("Testerson, Test", fullName);
        }

        [TestMethod]
        public void RaiseSalaryTest_Positive()
        {
            Employee employee = new Employee("Test", "Testerson");
            employee.Salary = 100;

            employee.RaiseSalary(5); //raise 5%

            Assert.IsTrue(employee.Salary == 100 * 1.05);
        }

        [TestMethod]
        public void RaiseSalaryTest_Negative()
        {
            Employee employee = new Employee("Test", "Testerson");
            employee.Salary = 100;

            employee.RaiseSalary(-10); //"raise" by negative 10%

            Assert.AreEqual(100, employee.Salary); //salary should remain same
        }


        //Adding new test to given EmployeeTests to check GetBalanceDue() method
        [TestMethod]
        public void GetBalanceDueTest()
        {
            Employee john = new Employee("John", "Smith");

            //Test for Standard Balance, no discount
            Dictionary<string, double> standardTest = new Dictionary<string, double> { { "food", 10 }, { "grooming", 10.96 }, { "sitting", 15 } };
            double expected = 35.96;
            double result = john.GetBalanceDue(standardTest);
            Assert.AreEqual(expected, result);

            //Test for correct discount, case insensitive
            Dictionary<string, double> discountTest = new Dictionary<string, double> { { "WALKING", 10 }, { "grooming", 10.96 }, { "sitting", 15 } };
            expected = 30.96;
            result = john.GetBalanceDue(discountTest);
            Assert.AreEqual(expected, result);

            //Test for empty dictionary 
            Dictionary<string, double> zeroTest = new Dictionary<string, double> { };
            expected = 0;
            result = john.GetBalanceDue(zeroTest);
            Assert.AreEqual(expected, result);

            //Test for negative numbers as prices
            Dictionary<string, double> negativeTest = new Dictionary<string, double> { { "food", -10 }, { "sitting", -20 } };
            expected = -30;
            result = john.GetBalanceDue(negativeTest);
            Assert.AreEqual(expected, result);
        }
    }
}
