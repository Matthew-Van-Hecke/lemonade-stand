using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public int weatherAntiValue;
        public List<Customer> customers;

        public Day(Random random)
        {
            weather = new Weather(random);
            customers = new List<Customer>() { new Customer(random), new Customer(random), new Customer(random), new Customer(random) };
            weatherAntiValue = 300/(weather.temperature * (weather.conditions.IndexOf(weather.currentCondition) + 1));
        }
        //Member Methods

    }
}
