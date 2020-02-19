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
        private int numberOfCupsRemaining;
        public int NumberOfCupsRemaining
        {
            get { return numberOfCupsRemaining; }
            set { numberOfCupsRemaining = value; }
        }
        private int taste;
        public int Taste
        {
            get { return taste; }
        }
        private double pricePerCup;
        public double PricePerCup
        {
            get { return pricePerCup; }
        }
        //Constructor
        public Pitcher()
        {
            numberOfCupsRemaining = 0;
            this.taste = 0;
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
            Console.WriteLine("How much would you like to charge per cup of lemonade? Current price: $" + pricePerCup);
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
        public void MakeInitialBatchOfLemonade(Recipe recipe, Inventory inventory)
        {
            int taste = 0;
            int sizeOfBatch;
            int lemons;
            int sugar;
            int ice;

            recipe.PrintCurrentRecipe();
            if (recipe.WouldYouLikeToAdjustRecipe())
            {
                recipe.AdjustRecipe(inventory);
                recipe.PrintCurrentRecipe();
            }

            //This portion is functional but could use some cleaning up later.
            FillPitcher(recipe, inventory);
        }
        public void FillPitcher(Recipe recipe, Inventory inventory)
        {
            int lemons;
            int sugar;
            int ice;
            numberOfCupsRemaining = recipe.NumberOfCups;
            if (recipe.NumberOfLemons > inventory.Lemons.Count)
            {
                lemons = inventory.Lemons.Count;
            }
            else
            {
                lemons = recipe.NumberOfLemons;
            }
            if (recipe.NumberOfSugarCubes > inventory.SugarCubes.Count)
            {
                sugar = inventory.SugarCubes.Count;
            }
            else
            {
                sugar = recipe.NumberOfSugarCubes;
            }
            if (recipe.NumberOfIceCubes > inventory.IceCubes.Count)
            {
                ice = inventory.IceCubes.Count;
            }
            else
            {
                ice = recipe.NumberOfIceCubes;
            }
            if (numberOfCupsRemaining > 0)
            {
                taste = (lemons * sugar + ice) / numberOfCupsRemaining;
            }
            inventory.RemoveItemsFromInventoryToFillPitcher(lemons, sugar, ice);
        }
    }
}
