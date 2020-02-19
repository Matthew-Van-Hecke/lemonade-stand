using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        //Member Variables
        Player player;
        Store store;
        List<Day> days;
        Pitcher currentPitcher;
        int currentDay;
        int cupsSoldToday;
        double incomeToday;
        
        Random masterRandom;
        //Constructor
        public Game()
        {
            masterRandom = new Random();
            player = new Player();
            store = new Store();
            days = new List<Day>() { new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom) };
            currentDay = 0;
        }
        //Member Methods
        public void PlayGame()
        {
            //Loop through for each day.
            while (currentDay < 7)
            {
                PlayDay();
            }
            //Repeat for next day.
            //At the end of the game, print overall stats (at least profit/loss, but maybe also total amount spent on ingredients)
            PrintGameResults();
        }
        private void PlayDay()
        {
            DisplayStatsAtStartOfDay();
            GoShopping();
            currentPitcher = player.MakePitcher();
            currentPitcher.SetPricePerCup();
            PlayBusinessHours();
            ////Use the CustomerSatisfied method to adjust popularity of the lemonade stand.
            DisplayStatsAtEndOfDay();
            MeltIce();
            player.Inventory.PrintInventory();
            currentDay++;
            player.Wallet.TotalIncome += incomeToday;
            cupsSoldToday = 0;
            incomeToday = 0;
        }
        private void DisplayStatsAtStartOfDay()
        {
            Console.WriteLine("\nDay: " + (currentDay + 1));
            Console.WriteLine(days[currentDay].Weather.Temperature + " degrees, and " + days[currentDay].Weather.CurrentCondition + ".");
            player.Inventory.PrintInventory();
            Console.WriteLine("You have $" + player.Wallet.Money + " in your wallet.");
        }
        
        private void GoShopping()
        {
            Console.WriteLine("\nYou have " + player.Inventory.Cups.Count + " cups in your inventory. Cups cost $" + store.PricePerCup + " each.");
            store.SellCups(player);
            Console.WriteLine("\nYou have " + player.Inventory.Lemons.Count + " lemons in your inventory. Lemons cost $" + store.PricePerLemon + " each.");
            store.SellLemons(player);
            Console.WriteLine("\nYou have " + player.Inventory.SugarCubes.Count + " sugar cubes in your inventory. Sugar cubes cost $" + store.PricePerSugarCube + " each.");
            store.SellSugarCubes(player);
            Console.WriteLine("\nYou have " + player.Inventory.IceCubes.Count + " ice cubes in your inventory. Ice cubes cost $" + store.PricePerIceCube + " each.");
            store.SellIceCubes(player);
            Console.WriteLine("You have $" + player.Wallet.Money + " remaining in your wallet.");
        }
        private void PlayBusinessHours()
        {
            Customer customer;
            for (int i = 0; i < days[currentDay].Customers.Count; i++)
            {
                if (currentPitcher.NumberOfCupsRemaining <= 0)
                {
                    currentPitcher.RefillPitcher(player.MyRecipe, player.Inventory);
                }
                customer = days[currentDay].Customers[i];
                if (customer.WillBuy(currentPitcher.Taste, days[currentDay].WeatherValue, currentPitcher.PricePerCup))
                {
                    if (player.Inventory.Cups.Count <= 0)
                    {
                        Console.WriteLine("You ran out of cups.");
                        break;
                    }
                    SellCupOfLemonade();
                }
            }
        }
        private void SellCupOfLemonade()
        {
            currentPitcher.PourCup();
            player.Wallet.Money += currentPitcher.PricePerCup;
            player.Inventory.Cups.Remove(player.Inventory.Cups[0]);
            cupsSoldToday++;
            incomeToday += currentPitcher.PricePerCup;
        }
        private void DisplayStatsAtEndOfDay()
        {
            Console.WriteLine("Today, you sold " + cupsSoldToday + " cups of lemonade to a potential " + days[currentDay].Customers.Count + " customers, making $" + incomeToday + ".");
        }
        private void MeltIce()
        {
            Console.WriteLine("All of your remaining ice cubes melted");
            player.Inventory.IceCubes.Clear();
        }
        public void PrintGameResults()
        {
            Console.WriteLine("Game over.\nTotal expenses: $" + player.Wallet.TotalExpenses + "\nTotal income: $" + player.Wallet.TotalIncome + "\nYou made a profit of $" + (player.Wallet.TotalIncome - player.Wallet.TotalExpenses) + ".");
        }
    }
}
