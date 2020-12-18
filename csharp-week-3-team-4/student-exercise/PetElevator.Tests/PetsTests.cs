using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetElevator.CRM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetElevator.Tests
{
    [TestClass]
    public class PetsTests
    {
        //First Constructor Test
        [TestMethod]
        [DataRow("", "")]
        [DataRow("Ron", null)]
        [DataRow(null, "Dog")]
        [DataRow("Bugsy", "Dog")]
        [DataRow("Cleopatra", "CAT")]
        [DataRow("Ron", "Alligator")]
        public void PetElevatorFirstConstructorTest(string name, string species)
        {
            Pet pet = new Pet(name, species);
            Assert.AreEqual(pet.PetName, name);
            Assert.AreEqual(pet.Species, species);
        }
        

        //Second Constructor Test
        [TestMethod]
        public void PetElevatorSecondConstructorTest()
        {
            //Standard Entry
            Pet Bugsy = new Pet("Bugsy", "Dog", new List<string> { "Polio", "Bordatella", "Rabies" });
            string bugsyName = "Bugsy";
            string bugsySpecies = "Dog";
            List<string> bugsyVaccines = new List<string> { "Polio", "Bordatella", "Rabies" };
            Assert.AreEqual(bugsyName, Bugsy.PetName);
            Assert.AreEqual(bugsySpecies, Bugsy.Species);
            CollectionAssert.AreEqual(bugsyVaccines, Bugsy.Vaccinations);

            //Another Standard Entry
            Pet Ron = new Pet("Ron", "Alligator", new List<string> { "Polio", "Bordatella", "Rabies" });
            string ronName = "Ron";
            string ronSpecies = "Alligator";
            List<string> ronVaccinations = new List<string> { "Polio", "Bordatella", "Rabies" };
            Assert.AreEqual(ronName, Ron.PetName);
            Assert.AreEqual(ronSpecies, Ron.Species);
            CollectionAssert.AreEqual(ronVaccinations, Ron.Vaccinations);

            //Empty Strings
            Pet emptyPet = new Pet("", "", new List<string> { "" });
            string emptyName = "";
            string emptySpecies = "";
            List<string> emptyVaccines = new List<string> { "" };
            Assert.AreEqual(emptyName, emptyPet.PetName);
            Assert.AreEqual(emptySpecies, emptyPet.Species);
            CollectionAssert.AreEqual(emptyVaccines, emptyPet.Vaccinations);

            //Null Strings and List
            Pet nullPet = new Pet(null, null, new List<string> { null });
            string nullName = null;
            string nullSpecies = null;
            List<string> nullVaccinations = new List<string> { null };
            Assert.AreEqual(nullName, nullPet.PetName);
            Assert.AreEqual(nullSpecies, nullPet.Species);
            CollectionAssert.AreEqual(nullVaccinations, nullPet.Vaccinations);
        }


        //Testing AddVaccinationsToList() Method
        [TestMethod]
        public void AddVaccinationToListTest()
        {
            List<string> expected = new List<string> { "Polio" };

            // Test one for null addition
            Pet steve = new Pet("Steve", "Llama", new List<string> { "Polio" });
            steve.AddVaccinationToList(null);
            CollectionAssert.AreEqual(expected, steve.Vaccinations);

            //Test two for creation of list 
            Pet pam = new Pet("Pam", "Frog ");
            pam.AddVaccinationToList("Polio");
            CollectionAssert.AreEqual(expected, pam.Vaccinations);

            //Test three for addition to existing list 
            Pet jim = new Pet("Jim", "House Elf", new List<string> { "Polio" });
            List<string> jimExpected = new List<string> { "Polio", "Bordatella" };
            jim.AddVaccinationToList("Bordatella");
            CollectionAssert.AreEqual(jimExpected, jim.Vaccinations);

            // Test four addition of existing vaccine
            Pet johnathan = new Pet("Johnathan", "Emu", new List<string> { "Polio" });
            johnathan.AddVaccinationToList("Polio");
            CollectionAssert.AreEqual(expected, johnathan.Vaccinations);
        }
    }
}
