using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        //Member Variables
        int thirst;
        //Satisfaction will be added to or subtracted from depending on whether taste of lemonade is greater than, less than, or equal to tasteConstant.
        int satisfaction;
        int tasteConstant;
        Random random;
        //If likelinessToBuy is greater than variable (based on weather, popularity of stand, recipe, and price), customer will buy lemonade
        int likelinessToBuy;
        //Constructor
        public Customer(Random random)
        {
            this.random = random;
            tasteConstant = random.Next(1, 10);
            thirst = random.Next(1, 3);
            satisfaction = 1;
            likelinessToBuy = thirst * satisfaction;
        }
        //Member Methods

    }
}
