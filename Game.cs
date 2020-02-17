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
        List<Day> days;
        Pitcher currentPitcher;
        int currentDay;
        
        Random masterRandom;
        //Constructor
        public Game()
        {
            masterRandom = new Random();
            player = new Player();
            days = new List<Day>() { new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom), new Day(masterRandom) };
            currentDay = 0;
        }
        //Member Methods
        public void PlayGame()
        {
            //Loop through for each day.
                //Display day, weather, current inventory, and amount of money in wallet.
                //Give player the opportunity to purchase items from the store.
                //Give player the opportunity to choose the recipe for their lemonade, and how much of it they would like to make.
                //Begin work day.
                    //Have customers walk by one at a time and, if the math works out, have the customer buy.
                    //Use the CustomerSatisfied method to adjust popularity of the lemonade stand.
                //At the end of the day, print how many cups were sold out of how many possible.
                //Print remaining inventory.
                //Maybe give some sort of popularity indicator.
                //At the end of the day, all remaining ice cubes in the inventory melt.
            //Repeat for next day.
            //At the end of the game, print overall stats (at least profit/loss, but maybe also total amount spent on ingredients)
        }
        public bool WillBuy(Customer customer)
        {
            double differenceOfTaste;
            if (currentPitcher.taste >= customer.tasteConstant)
            {
                differenceOfTaste = currentPitcher.taste - customer.tasteConstant;
            }
            else
            {
                differenceOfTaste = customer.tasteConstant - currentPitcher.taste;
            }
            double abilityToSell = days[currentDay].weatherValue * customer.thirst - currentPitcher.pricePerCup - differenceOfTaste;
            if (abilityToSell > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
