using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace command_line_input_exercises_pairs
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            //Get Bill Amount
            Console.Write("Please enter the amount of the bill: ");
            decimal billAmt = decimal.Parse(Console.ReadLine());

            //Get Amount Tendered
            Console.Write("Please enter the amount tendered: ");
            decimal tenderAmt = decimal.Parse(Console.ReadLine());

            //Calculate Change
            decimal change = tenderAmt - billAmt;
            Console.WriteLine($"The change required is {change:C2}");
        }
    }
}
