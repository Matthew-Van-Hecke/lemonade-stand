using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        Weather weather;
        List<Customer> customers;
        public Day(Random random)
        {
            weather = new Weather(random);
            customers = new List<Customer>() { new Customer(), new Customer(), new Customer(), new Customer() };
        }
    }
}
