using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.CRM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetElevator.Tests
{
    [TestClass]
    public class CustomerTests
    {
        //First Constructor Test
        [DataTestMethod]
        [DataRow("Jim", "McCrorey")]
        [DataRow("Pam", "Iovino")]
        [DataRow("Joe", "Howell")]
        [DataRow("Rob", "Spadafore")]
        [DataRow("Tom", "Anderson")]
        [DataRow("", "")]
        [DataRow(null, "Anderson")]
        [DataRow("Tom", null)]
        public void FirstConstructorTest(string firstName, string lastName)
        {
            Customer customer = new Customer(firstName, lastName);
            string expectedFirstName = firstName;
            string expectedLastName = lastName;
            Assert.AreEqual(expectedFirstName, customer.FirstName);
            Assert.AreEqual(expectedLastName, customer.LastName);
        }


        //Second Constructor Test
        [DataTestMethod]
        [DataRow("Jim", "McCrorey", "84653894651")]
        [DataRow("Pam", "Iovino", "879645123")]
        [DataRow("Joe", "Howell", "98754948")]
        [DataRow("Rob", "Spadafore", "021365489")]
        [DataRow("Tom", "Anderson", "13564841")]
        [DataRow("", "", "")]
        [DataRow(null, "Anderson", "456564465")]
        [DataRow("Tom", null, "465123312")]
        [DataRow("Tom", "Anderson", null)]
        public void SecondContructorTest(string firstName, string lastName, string phoneNumber)
        {
            Customer customer = new Customer(firstName, lastName, phoneNumber);
            string expectedFirstName = firstName;
            string expectedLastName = lastName;
            string expectedPhoneNumber = phoneNumber;
            Assert.AreEqual(expectedFirstName, customer.FirstName);
            Assert.AreEqual(expectedLastName, customer.LastName);
            Assert.AreEqual(expectedPhoneNumber, customer.PhoneNumber);

        }


        //Testing GetBalanceDue() Method
        [TestMethod]
        public void GetBalanceDueTests()
        {
            Customer tom = new Customer("Tom", "Anderson");

            //Test for Happy Path 
            Dictionary<string, double> standardTest = new Dictionary<string, double> { {"walking", 10 }, {"grooming", 10.96 }, {"sitting", 15} };
            double expected = 35.96;
            double result = tom.GetBalanceDue(standardTest);
            Assert.AreEqual(expected, result);

            //Test for empty dictionary
            Dictionary<string, double> zeroTest = new Dictionary<string, double> { };
            expected = 0;
            result = tom.GetBalanceDue(zeroTest);
            Assert.AreEqual(expected, result);

            //Test for negative numbers as prices
            Dictionary<string, double> negativeTest = new Dictionary<string, double> { { "walking", -10 }, { "sitting", -20 } };
            expected = -30;
            result = tom.GetBalanceDue(negativeTest);
            Assert.AreEqual(expected, result);
        }
    }
}

