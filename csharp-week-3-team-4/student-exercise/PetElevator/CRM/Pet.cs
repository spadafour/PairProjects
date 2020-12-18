using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetElevator.CRM
{
    public class Pet
    {
        public string PetName { get; set; }
        public string Species { get; set; }
        public List<string> Vaccinations { get; set; } 

        public Pet(string name, string species)
        {
            PetName = name;
            Species = species;
            Vaccinations  = new List<string>();
        }

        public Pet( string name, string species, List<string> vaccinations)
        {
            PetName = name;
            Species = species;
            Vaccinations = vaccinations; 
        }

        public string ListVaccinations()
        {
            return string.Join(", ", Vaccinations);
        }

        public bool AddVaccinationToList(string vaccine)
        {
            if (!(vaccine == null) && !Vaccinations.Contains(vaccine))
            {
                Vaccinations.Add(vaccine);
                return true;
            }
            else { return false; }
        }




    }
}
