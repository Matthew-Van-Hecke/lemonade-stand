using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        //Hash this out, and 
        int sellabilityOfLemonade;
        Recipe myRecipe;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            sellabilityOfLemonade = 15;
            myRecipe = new Recipe();
        }

        // member methods (CAN DO)
        public Pitcher MakePitcher()
        {
            int taste = (myRecipe.numberOfLemons + myRecipe.numberOfSugarCubes + myRecipe.numberOfIceCubes) / myRecipe.numberOfCups;
            myRecipe.PrintCurrentRecipe();
            if (myRecipe.WouldYouLikeToAdjustRecipe())
            {
                myRecipe.AdjustRecipe(inventory);
                myRecipe.PrintCurrentRecipe();
            }
            RemoveItemsFromInventory();
            return new Pitcher(myRecipe.numberOfCups, taste);
        }
        public void RemoveItemsFromInventory()
        {
            inventory.lemons.RemoveRange(0, myRecipe.numberOfLemons);
            inventory.sugarCubes.RemoveRange(0, myRecipe.numberOfSugarCubes);
            inventory.iceCubes.RemoveRange(0, myRecipe.numberOfIceCubes);
            inventory.cups.RemoveRange(0, myRecipe.numberOfCups);
        }
        //private void CalculateSellability()
        //{
        //    sellabilityOfLemonade = tasteOfRecipe * popularity;
        //}
    }
}
