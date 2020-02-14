using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Day today = new Day(new Random());
            Console.WriteLine(today.weatherValue);
            Console.ReadLine();
        }
    }
}
