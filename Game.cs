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
                //At the end of the day, print how many cups were sold out of how many possible.
                //Print remaining inventory.
                //Maybe give some sort of popularity indicator.
                //At the end of the day, all remaining ice cubes in the inventory melt.
            //Repeat for next day.
            //At the end of the game, print overall stats (at least profit/loss, but maybe also total amount spent on ingredients)
        }
    }
}
