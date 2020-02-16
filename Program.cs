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
            Recipe recipe = new Recipe();
            Player player = new Player();
            Pitcher pitcher;
            pitcher = player.MakePitcher();
            Console.WriteLine("Pitcher contains " + pitcher.numberOfCupsRemaining + " cups.");
            Console.ReadLine();
        }
    }
}
