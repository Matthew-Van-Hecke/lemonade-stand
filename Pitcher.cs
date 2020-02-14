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
        public int numberOfCupsRemaining;
        public int taste;
        //Constructor
        public Pitcher(int numberOfCups, int taste)
        {
            this.numberOfCupsRemaining = numberOfCups;
            this.taste = taste;
        }
        //Member Methods
        public void PourCup()
        {
            numberOfCupsRemaining--;
        }
    }
}
