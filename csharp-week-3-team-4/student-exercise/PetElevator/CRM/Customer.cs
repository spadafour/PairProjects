using PetElevator.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetElevator.CRM
{
    public class Customer : Person, IBillable
    {
        public string PhoneNumber { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public Customer(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public Customer(string firstName, string lastName, string phoneNumber): base(firstName, lastName)
        {
            PhoneNumber = phoneNumber;
        }
                
        public double GetBalanceDue(Dictionary<string, double> servicesRendered)
        {
            double balance = 0;
            foreach (string service in servicesRendered.Keys)
            {
                balance += servicesRendered[service];
            }
            return balance;
        }
    }
}
