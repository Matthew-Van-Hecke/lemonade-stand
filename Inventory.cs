using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Inventory
    {
        // member variables (HAS A)
        private List<Lemon> lemons;
        public List<Lemon> Lemons
        {
            get { return lemons; }
        }
        private List<SugarCube> sugarCubes;
        public List<SugarCube> SugarCubes
        {
            get { return sugarCubes; }
        }
        private List<IceCube> iceCubes;
        public List<IceCube> IceCubes
        {
            get { return iceCubes; }
        }
        private List<Cup> cups;
        public List<Cup> Cups
        {
            get { return cups; }
        }

        // constructor (SPAWNER)
        public Inventory()
        {
            lemons = new List<Lemon>();
            sugarCubes = new List<SugarCube>();
            iceCubes = new List<IceCube>();
            cups = new List<Cup>();
        }

        // member methods (CAN DO)
        public void AddLemonsToInventory(int numberOfLemons)
        {
            for(int i = 0; i < numberOfLemons; i++)
            {
                Lemon lemon = new Lemon();
                lemons.Add(lemon);
            }
        }

        public void AddSugarCubesToInventory(int numberOfSugarCubes)
        {
            for(int i = 0; i < numberOfSugarCubes; i++)
            {
                SugarCube sugarCube = new SugarCube();
                sugarCubes.Add(sugarCube);
            }
        }

        public void AddIceCubesToInventory(int numberOfIceCubes)
        {
            for(int i = 0; i < numberOfIceCubes; i++)
            {
                IceCube iceCube = new IceCube();
                iceCubes.Add(iceCube);
            }
        }

        public void AddCupsToInventory(int numberOfCups)
        {
            for(int i = 0; i < numberOfCups; i++)
            {
                Cup cup = new Cup();
                cups.Add(cup);
            }
        }
        public void PrintInventory()
        {
            Console.WriteLine($"You currently have {cups.Count} cups, {lemons.Count} lemons, {sugarCubes.Count} sugar cubes, and {iceCubes.Count} ice cubes in your inventory");
        }
    }
}
