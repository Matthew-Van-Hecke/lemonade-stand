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

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
        }

        internal Pitcher Pitcher
        {
            get => default;
            set
            {
            }
        }

        internal Wallet Wallet
        {
            get => default;
            set
            {
            }
        }

        internal Recipe Recipe
        {
            get => default;
            set
            {
            }
        }

        internal Inventory Inventory
        {
            get => default;
            set
            {
            }
        }

        // member methods (CAN DO)
    }
}
