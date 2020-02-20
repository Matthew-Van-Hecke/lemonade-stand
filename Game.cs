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
        int lengthOfGame;
        
        Random masterRandom;
        //Constructor
        public Game()
        {
            masterRandom = new Random();
            player = new Player();
            store = new Store();
            days = new List<Day>() { new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom) };
            currentDay = 0;
            lengthOfGame = 7;
        }
        //Member Methods
        public void PlayGame()
        {
            do
            {
                PrintGameInstructions();
                while (currentDay < lengthOfGame)
                {
                    PlayDay();
                }
                PrintGameResults();
                currentDay = 0;
            } while (PlayAgain());
            Console.WriteLine("Good game! Thanks for playing!");
        }
        private void PlayDay()
        {
            DisplayStatsAtStartOfDay();
            GoShopping();
            SetUpCurrentPitcher();
            PlayBusinessHours();
            DisplayStatsAtEndOfDay();
            MeltIce();
            player.Inventory.PrintInventory();
            player.Wallet.TotalIncome += incomeToday;
            cupsSoldToday = 0;
            incomeToday = 0;
            currentDay++;
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
                customer = days[currentDay].Customers[i];
                RefillPitcherIfNeeded();
                CheckIfCustomerWillBuy(customer);
                if (!CupsRemaining())
                {
                    break;
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
            Console.WriteLine("Game over.\nTotal expenses: $" + player.Wallet.TotalExpenses + "\nTotal income: $" + player.Wallet.TotalIncome + "\nYou made a profit of $" + (player.Wallet.TotalIncome - player.Wallet.TotalExpenses) + ".\n\nGood game!");
        }
        public void SetUpCurrentPitcher()
        {
            currentPitcher = new Pitcher();
            currentPitcher.MakeInitialBatchOfLemonade(player.MyRecipe, player.Inventory);
            currentPitcher.SetPricePerCup();
        }
        public void RefillPitcherIfNeeded()
        {
            if (currentPitcher.NumberOfCupsRemaining <= 0)
            {
                currentPitcher.FillPitcher(player.MyRecipe, player.Inventory);
            }
        }
        public void CheckIfCustomerWillBuy(Customer customer)
        {
            if (customer.WillBuy(currentPitcher.Taste, days[currentDay].WeatherValue, currentPitcher.PricePerCup))
            {
                SellCupOfLemonade();
            }
        }
        public bool CupsRemaining()
        {
            if (player.Inventory.Cups.Count <= 0)
            {
                Console.WriteLine("You ran out of cups.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void PrintGameInstructions()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to The Lemonade Stand Game!\nThe goal of the game is to make as much profit as possible on your lemonade stand.\nEach day, you will be given the opportunity to buy ingredients, set the propoortions for the day's lemonade, and set the price.\nRemeber, the weather will have an impact on the price customers are willing to pay for a cup.\nThe game will last for " + lengthOfGame + " days.\nGood luck!");
            Console.WriteLine("--------------------------------");
        }
        public bool PlayAgain()
        {
            Console.WriteLine("Would you like to play again?");
            if (GetUserInputForAskIfPlayAgain() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetUserInputForAskIfPlayAgain()
        {
            string userInput = "no";
            do
            {
                if (userInput.ToLower() != "yes" && userInput.ToLower() != "no")
                {
                    Console.WriteLine("Invalid response. Please type \"yes\" or \"no\".");
                }
                userInput = Console.ReadLine();
            } while (userInput.ToLower() != "yes" && userInput.ToLower() != "no");
            return userInput.ToLower();
        }
    }
}
