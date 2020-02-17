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
        private int temperature;
        public int Temperature
        {
            get { return temperature; }
        }
        private List<string> conditions;
        public List<string> Conditions
        {
            get { return conditions; }
        }
        private string currentCondition;
        public string CurrentCondition
        {
            get { return currentCondition; }
        }
        Random random;
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
