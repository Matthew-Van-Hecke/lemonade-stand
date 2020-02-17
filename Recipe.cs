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
        private int numberOfCups;
        public int NumberOfCups
        {
            get { return numberOfCups; }
        }
        private int numberOfLemons;
        public int NumberOfLemons
        {
            get { return numberOfLemons; }
        }
        private int numberOfSugarCubes;
        public int NumberOfSugarCubes
        {
            get { return numberOfSugarCubes; }
        }
        private int numberOfIceCubes;
        public int NumberOfIceCubes
        {
            get { return numberOfIceCubes; }
        }
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
        
        public void AdjustRecipe(Inventory inventory)
        {
            Console.WriteLine("Note: if the selected quantity of an item is greater than the amount you have left in your inventory, the rest of that item from your inventory will go into the batch.\n");
            Console.WriteLine("Current size of recipe: " + numberOfCups + " cups.\nYou currently have " + inventory.Cups.Count + " cups available to use.");
            Console.WriteLine("How big would you like to make it?");
            numberOfCups = GetValidIntFromUserInput();
            Console.WriteLine("Current number of lemons in recipe: " + numberOfLemons + "\nYou currently have " + inventory.Lemons.Count + " lemons available to use.");
            Console.WriteLine("How many would you like to include in your recipe?");
            numberOfLemons = GetValidIntFromUserInput();
            Console.WriteLine("Current quantity of sugar in recipe: " + numberOfSugarCubes + " cubes.\nYou currently have " + inventory.SugarCubes.Count + " sugar cubes available to use.");
            Console.WriteLine("How many would you like to include?");
            numberOfSugarCubes = GetValidIntFromUserInput();
            Console.WriteLine("Current number of ice cubes in recipe: " + numberOfIceCubes + "\nYou currently have " + inventory.IceCubes.Count + " available to use.");
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
