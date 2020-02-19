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
        public Recipe MyRecipe
        {
            get { return myRecipe; }
        }

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            myRecipe = new Recipe();
        }

        // member methods (CAN DO)

    }
}
