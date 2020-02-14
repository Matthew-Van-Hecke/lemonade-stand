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
        ////Eventually, move tasteOfRecipe to pitcher class.
        //int tasteOfRecipe;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            sellabilityOfLemonade = 15;
        }

        // member methods (CAN DO)
        //private void CalculateSellability()
        //{
        //    sellabilityOfLemonade = tasteOfRecipe * popularity;
        //}
    }
}
