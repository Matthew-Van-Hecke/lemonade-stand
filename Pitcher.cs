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
            Console.WriteLine("How much would you like to charge per cup of lemonade? Current price: $" + pricePerCup);
            pricePerCup = GetDoubleFromUserInput();
        }
        public double GetDoubleFromUserInput()
        {
            bool isNumber = true;
            double doubleUserInput = 0;
            do
            {
                if (!isNumber || doubleUserInput < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                }
                isNumber = double.TryParse(Console.ReadLine(), out doubleUserInput);
            } while (!isNumber || doubleUserInput < 0);
            return doubleUserInput;
        }
        public void MakeInitialBatchOfLemonade(Recipe recipe, Inventory inventory)
        {
            int taste = 0;
            int sizeOfBatch;
            int lemons;
            int sugar;
            int ice;
            LetUserMakeLemonadePlan(recipe, inventory);
            FillPitcher(recipe, inventory);
        }
        public void LetUserMakeLemonadePlan(Recipe recipe, Inventory inventory)
        {
            recipe.PrintCurrentRecipe();
            if (recipe.WouldYouLikeToAdjustRecipe())
            {
                recipe.AdjustRecipe(inventory);
                recipe.PrintCurrentRecipe();
            }
        }
        public void FillPitcher(Recipe recipe, Inventory inventory)
        {
            numberOfCupsRemaining = recipe.NumberOfCups;
            int lemons = AdjustNumberOfLemonsIfNeeded(recipe, inventory);
            int sugar = AdjustQuantityOfSugarIfNeeded(recipe, inventory);
            int ice = AdjustQuantityOfIceIfNeeded(recipe, inventory);
            SetTasteOfPitcher(lemons, sugar, ice, numberOfCupsRemaining);
            inventory.RemoveItemsFromInventoryToFillPitcher(lemons, sugar, ice);
        }
        public int AdjustNumberOfLemonsIfNeeded(Recipe recipe, Inventory inventory)
        {
            if (recipe.NumberOfLemons > inventory.Lemons.Count)
            {
                return inventory.Lemons.Count;
            }
            else
            {
                return recipe.NumberOfLemons;
            }
        }
        public int AdjustQuantityOfSugarIfNeeded(Recipe recipe, Inventory inventory)
        {
            if (recipe.NumberOfSugarCubes > inventory.SugarCubes.Count)
            {
                return inventory.SugarCubes.Count;
            }
            else
            {
                return recipe.NumberOfSugarCubes;
            }
        }
        public int AdjustQuantityOfIceIfNeeded(Recipe recipe, Inventory inventory)
        {
            if (recipe.NumberOfIceCubes > inventory.IceCubes.Count)
            {
                return inventory.IceCubes.Count;
            }
            else
            {
                return recipe.NumberOfIceCubes;
            }
        }
        public void SetTasteOfPitcher(int lemons, int sugar, int ice, int numberOfCupsRemaining)
        {
            if (numberOfCupsRemaining > 0)
            {
                taste = (lemons * sugar + ice) / numberOfCupsRemaining;
            }
        }
    }
}
