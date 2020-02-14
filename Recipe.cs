using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        //Member Variables
        int numberOfCups;
        int numberOfLemons;
        int numberOfSugarCubes;
        int numberOfIceCubes;
        int taste;
        //Constructor
        public Recipe()
        {
            numberOfCups = 32;
            numberOfLemons = 4;
            numberOfSugarCubes = 4;
            numberOfIceCubes = 128;
        }
        //Member Methods

        //Will probably eventually want to move this method to the player class.
        public Pitcher MakePitcher()
        {
            taste = (numberOfLemons + numberOfSugarCubes + numberOfIceCubes) / numberOfCups;
            PrintCurrentRecipe();
            if (WouldYouLikeToAdjustRecipe())
            {
                AdjustRecipe();
                PrintCurrentRecipe();
            }
            return new Pitcher(numberOfCups, taste);
        }
        public void AdjustRecipe()
        {
            Console.WriteLine("Current size of recipe: " + numberOfCups + " cups");
            Console.WriteLine("How big would you like to make it?");
            numberOfCups = GetValidIntFromUserInput();
            Console.WriteLine("Current number of lemons in recipe: " + numberOfLemons);
            Console.WriteLine("How many would you like to include?");
            numberOfLemons = GetValidIntFromUserInput();
            Console.WriteLine("Current quantity of sugar in recipe: " + numberOfSugarCubes + " cubes");
            Console.WriteLine("How many would you like to include?");
            numberOfSugarCubes = GetValidIntFromUserInput();
            Console.WriteLine("Current number of ice cubes in recipe: " + numberOfIceCubes);
            Console.WriteLine("How many would you like to include?");
            numberOfIceCubes = GetValidIntFromUserInput();
        }
        public int GetValidIntFromUserInput()
        {
            bool validResponse = true;
            int chosenNumber = 0;
            Console.WriteLine("Please enter a non-negative integer.");
            do
            {
                if (!validResponse || chosenNumber < 0)
                {
                    Console.WriteLine("Invalid response. Please type a non-negative integer");
                }
                validResponse = int.TryParse(Console.ReadLine(), out chosenNumber);
            } while (!validResponse || chosenNumber < 0);
            return chosenNumber;
        }
        public void PrintCurrentRecipe()
        {
            Console.WriteLine("Makes " + numberOfCups + " cups.\n" + numberOfLemons + " lemons.\n" + numberOfSugarCubes + " sugar cubes\n" + numberOfIceCubes + " ice cubes");
        }
        public bool WouldYouLikeToAdjustRecipe()
        {
            Console.WriteLine("Would you like to adjust the recipe? (\"yes\" or \"no\")");
            string response = "";
            do
            {
                response = Console.ReadLine();
                if (response.ToLower() != "yes" && response.ToLower() != "no")
                {
                    Console.WriteLine("Invalid response. Please type either \"yes\" or \"no\".");
                }
            } while (response.ToLower() != "yes" && response.ToLower() != "no");
            if (response.ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
