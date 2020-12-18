using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Collect decimal values
            Console.Write("Please enter a series of decimal vaules (separated by spaces): ");
            string[] tenArr = Console.ReadLine().Split(' ');

            //for each decimal value in the array
            for (int i = 0; i < tenArr.Length; i++)
            {
                //tenVal is number variable for where we are in the loop
                int tenVal = int.Parse(tenArr[i]);

                //Begin writing to Console
                Console.Write($"{tenVal} in binary is ");

                //set holder variable to manipulate and set string variable to hold output
                int holder = tenVal;
                string binary = "";

                //writing digits
                while (holder>1)
                {
                    binary = ($"{holder%2}" + binary);
                    holder = holder / 2;
                }

                //write binary output
                if (tenVal<1)
                {
                    Console.WriteLine($"{tenVal}");
                }
                else
                {
                    binary = "1" + binary;
                    Console.WriteLine($"{binary}");
                }
            }
        }
    }
}
