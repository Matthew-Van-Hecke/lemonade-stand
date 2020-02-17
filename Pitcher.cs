using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        //Member Variables
        public int numberOfCupsRemaining;
        public int taste;
        public double pricePerCup;
        //Constructor
        public Pitcher(int numberOfCups, int taste)
        {
            this.numberOfCupsRemaining = numberOfCups;
            this.taste = taste;
            pricePerCup = 0.25;
        }
        //Member Methods
        public void PourCup()
        {
            numberOfCupsRemaining--;
        }
        public void SetPricePerCup()
        {
            bool isNumber = true;
            double doubleUserInput = 0;
            Console.WriteLine("How much would you like to charge per cup of lemonade");
            do
            {
                if (!isNumber || doubleUserInput < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                }
                isNumber = double.TryParse(Console.ReadLine(), out doubleUserInput);
            } while (!isNumber || doubleUserInput < 0);
            pricePerCup = doubleUserInput;
        }
    }
}
