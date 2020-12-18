﻿using System;

namespace MartianWeight
{
    /*
    In case you've ever pondered how much you weight on Mars, here's the calculation:
    Wm = We* 0.378
    where 'Wm' is the weight on Mars, and 'We' is the weight on Earth

    Write a command line program which accepts a series of Earth weights from the user  
    and displays each Earth weight as itself, and its Martian equivalent.


    C:\Users> MartianWeight  
    Enter a series of Earth weights (space-separated): 98 235 185

    98 lbs.on Earth, is 37 lbs.on Mars.
    235 lbs.on Earth, is 88 lbs.on Mars.
    185 lbs.on Earth, is 69 lbs.on Mars. 
    */
    class Program
    {
        static void Main(string[] args)
        {
            //Collect weight values
            Console.Write("Enter a series of Earth weights (space separated): ");
            string[] weightEarthArr = Console.ReadLine().Split(' ');

            //Output conversion vaules
            for (int i=0; i<weightEarthArr.Length; i++)
            {
                double weightEarth = double.Parse(weightEarthArr[i]);
                double weightMars = weightEarth * 0.378;
                Console.WriteLine($"{weightEarth} lbs. on Earth is {weightMars} lbs. on Mars.");
            }
        }
    }
}
