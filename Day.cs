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
        public int weatherValue;
        public List<Customer> customers;

        public Day(Random random)
        {
            weather = new Weather(random);
            customers = new List<Customer>() { new Customer(random), new Customer(random), new Customer(random), new Customer(random) };
            weatherValue = (weather.temperature * (weather.conditions.IndexOf(weather.currentCondition) + 1))/25;
        }
        //Member Methods

    }
}
