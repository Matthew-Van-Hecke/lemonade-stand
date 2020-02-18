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
        }
        private void PlayDay()
        {
            DisplayStatsAtStartOfDay();
            GoShopping();
            currentPitcher = player.MakePitcher();
            PlayBusinessHours();
            ////Use the CustomerSatisfied method to adjust popularity of the lemonade stand.
            DisplayStatsAtEndOfDay();
            MeltIce();
            player.Inventory.PrintInventory();
            currentDay++;
        }
        private void DisplayStatsAtStartOfDay()
        {
            Console.WriteLine("Day: " + (currentDay + 1));
            Console.WriteLine(days[currentDay].Weather.Temperature + " degrees, and " + days[currentDay].Weather.CurrentCondition + ".");
            player.Inventory.PrintInventory();
            Console.WriteLine("You have $" + player.Wallet.Money + " in your wallet.");
        }
        private bool WillBuy(Customer customer)
        {
            double differenceOfTaste;
            if (currentPitcher.Taste >= customer.TasteConstant)
            {
                differenceOfTaste = currentPitcher.Taste - customer.TasteConstant;
            }
            else
            {
                differenceOfTaste = customer.TasteConstant - currentPitcher.Taste;
            }
            double abilityToSell = days[currentDay].WeatherValue * customer.Thirst - currentPitcher.PricePerCup - differenceOfTaste;
            if (abilityToSell > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GoShopping()
        {
            Console.WriteLine("You have " + player.Inventory.Cups.Count + " cups.");
            store.SellCups(player);
            Console.WriteLine("You have " + player.Inventory.Lemons.Count + " lemons.");
            store.SellLemons(player);
            Console.WriteLine("You have " + player.Inventory.SugarCubes.Count + " sugar cubes.");
            store.SellSugarCubes(player);
            Console.WriteLine("You have " + player.Inventory.IceCubes.Count + " ice cubes.");
            store.SellIceCubes(player);
        }
        private void PlayBusinessHours()
        {
            Customer customer;
            for (int i = 0; i < days[currentDay].Customers.Count; i++)
            {
                if (currentPitcher.NumberOfCupsRemaining <= 0)
                {
                    currentPitcher = player.MakePitcher();
                }
                customer = days[currentDay].Customers[i];
                if (WillBuy(customer))
                {
                    SellCupOfLemonade();
                }
            }
        }
        private void SellCupOfLemonade()
        {
            currentPitcher.PourCup();
            player.Wallet.Money += currentPitcher.PricePerCup;
            currentPitcher.NumberOfCupsRemaining--;
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
    }
}
