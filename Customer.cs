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
        private string name;
        private List<string> names;
        private int thirst;
        public int Thirst
        {
            get { return thirst; }
        }
        private int tasteConstant;
        public int TasteConstant
        {
            get { return tasteConstant; }
        }
        private Random random;
        //Constructor
        public Customer(Random random)
        {
            this.random = random;
            names = new List<string>() { "George", "John", "Thomas", "James", "Andrew", "Millard", "Franklin" };
            name = names[RandomNumberGenerator(0, names.Count)];
            tasteConstant = RandomNumberGenerator(4, 7);
            thirst = RandomNumberGenerator(1, 3);
        }
        //Member Methods
        private int RandomNumberGenerator(int min, int max)
        {
            return random.Next(min, max);
        }
        //This method is not currently used anywhere, but will be called when I add functionality for changing popularity of the lemonade stand.
        public bool CustomerSatisfied(Pitcher pitcher)
        {
            if (pitcher.Taste <= tasteConstant + 2 && pitcher.Taste >= tasteConstant - 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
