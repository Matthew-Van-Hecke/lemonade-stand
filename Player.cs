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
        private Inventory inventory;
        public Inventory Inventory
        {
            get { return inventory; }
        }
        private Wallet wallet;
        public Wallet Wallet
        {
            get { return wallet; }
        }
        Recipe myRecipe;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            myRecipe = new Recipe();
        }

        // member methods (CAN DO)
        public Pitcher MakePitcher()
        {
            int taste = 0;
            int cups;
            int lemons;
            int sugar;
            int ice;
            myRecipe.PrintCurrentRecipe();
            if (myRecipe.WouldYouLikeToAdjustRecipe())
            {
                myRecipe.AdjustRecipe(inventory);
                myRecipe.PrintCurrentRecipe();
            }
            //This portion is functional but could use some cleaning up later.
            if (myRecipe.NumberOfCups > inventory.Cups.Count)
            {
                cups = inventory.Cups.Count;
            }
            else
            {
                cups = myRecipe.NumberOfCups;
            }
            if (myRecipe.NumberOfLemons > inventory.Lemons.Count)
            {
                lemons = inventory.Lemons.Count;
            }
            else
            {
                lemons = myRecipe.NumberOfLemons;
            }
            if (myRecipe.NumberOfSugarCubes > inventory.SugarCubes.Count)
            {
                sugar = inventory.SugarCubes.Count;
            }
            else
            {
                sugar = myRecipe.NumberOfSugarCubes;
            }
            if (myRecipe.NumberOfIceCubes > inventory.IceCubes.Count)
            {
                ice = inventory.IceCubes.Count;
            }
            else
            {
                ice = myRecipe.NumberOfIceCubes;
            }
            if (cups > 0)
            {
                taste = (lemons * sugar + ice) / cups;
            }
            RemoveItemsFromInventory(lemons, sugar, ice, cups);
            return new Pitcher(cups, taste);
        }
        public void RemoveItemsFromInventory(int lemons, int sugar, int ice, int cups)
        {
            inventory.Lemons.RemoveRange(0, lemons);
            inventory.SugarCubes.RemoveRange(0, sugar);
            inventory.IceCubes.RemoveRange(0, ice);
            inventory.Cups.RemoveRange(0, cups);
        }
    }
}
