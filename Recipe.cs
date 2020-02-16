﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        //Member Variables
        public int numberOfCups;
        public int numberOfLemons;
        public int numberOfSugarCubes;
        public int numberOfIceCubes;
        public int taste;
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
            Console.WriteLine("Current size of recipe: " + numberOfCups + " cups.\nYou currently have " + inventory.cups.Count + " cups available to use.");
            Console.WriteLine("How big would you like to make it?");
            numberOfCups = GetValidIntFromUserInput();
            if (numberOfCups > inventory.cups.Count)
            {
                numberOfCups = inventory.cups.Count;
            }
            Console.WriteLine("Current number of lemons in recipe: " + numberOfLemons + "\nYou currently have " + inventory.lemons.Count + " lemons available to use.");
            Console.WriteLine("How many would you like to include in your recipe?");
            numberOfLemons = GetValidIntFromUserInput();
            if (numberOfLemons > inventory.lemons.Count)
            {
                numberOfLemons = inventory.lemons.Count;
            }
            Console.WriteLine("Current quantity of sugar in recipe: " + numberOfSugarCubes + " cubes.\nYou currently have " + inventory.sugarCubes.Count + " sugar cubes available to use.");
            Console.WriteLine("How many would you like to include?");
            numberOfSugarCubes = GetValidIntFromUserInput();
            if (numberOfSugarCubes > inventory.sugarCubes.Count)
            {
                numberOfSugarCubes = inventory.sugarCubes.Count;
            }
            Console.WriteLine("Current number of ice cubes in recipe: " + numberOfIceCubes + "\nYou currently have " + inventory.iceCubes.Count + " available to use.");
            Console.WriteLine("How many would you like to include?");
            numberOfIceCubes = GetValidIntFromUserInput();
            if (numberOfIceCubes > inventory.iceCubes.Count)
            {
                numberOfIceCubes = inventory.iceCubes.Count;
            }
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
