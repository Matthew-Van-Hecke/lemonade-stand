using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //Member Variables
        public int temperature;
        public List<string> conditions;
        Random random;
        public string currentCondition;
        //Constructor
        public Weather(Random random)
        {
            this.random = random;
            temperature = random.Next(50, 100);
            conditions = new List<string> { "Raining", "Overcast", "Sunny" };
            currentCondition = conditions[random.Next(conditions.Count)];
        }
        //Member Methods

    }
}
