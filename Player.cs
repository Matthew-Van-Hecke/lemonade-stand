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
        public Pitcher MakePitcher(bool firstPitcher)
        {
            int taste = 0;
            int sizeOfBatch;
            int lemons;
            int sugar;
            int ice;
            if (firstPitcher)
            {
                myRecipe.PrintCurrentRecipe();
                if (myRecipe.WouldYouLikeToAdjustRecipe())
                {
                    myRecipe.AdjustRecipe(inventory);
                    myRecipe.PrintCurrentRecipe();
                }
            }
            //This portion is functional but could use some cleaning up later.
                sizeOfBatch = myRecipe.NumberOfCups;
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
            if (sizeOfBatch > 0)
            {
                taste = (lemons * sugar + ice) / sizeOfBatch;
            }
            RemoveItemsFromInventory(lemons, sugar, ice, sizeOfBatch);
            return new Pitcher(sizeOfBatch, taste);
        }
        public void RemoveItemsFromInventory(int lemons, int sugar, int ice, int cups)
        {
            inventory.Lemons.RemoveRange(0, lemons);
            inventory.SugarCubes.RemoveRange(0, sugar);
            inventory.IceCubes.RemoveRange(0, ice);
        }
    }
}
