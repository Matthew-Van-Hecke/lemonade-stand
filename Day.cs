using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        private Weather weather;
        public Weather Weather
        {
            get { return weather; }
        }
        private int weatherValue;
        public int WeatherValue
        {
            get { return weatherValue; }
        }
        private List<Customer> customers;
        public List<Customer> Customers
        {
            get { return customers; }
        }
        private int numberOfCupsSoldToday;

        public Day(Random random)
        {
            weather = new Weather(random);
            customers = new List<Customer>() { new Customer(random), new Customer(random), new Customer(random), new Customer(random) };
            weatherValue = (weather.Temperature * (weather.Conditions.IndexOf(weather.CurrentCondition) + 1)/10);
            numberOfCupsSoldToday = 0;
        }
        public Day()
        {

        }
        public void SetWeatherValue()
        {
            weatherValue = (weather.Temperature * (weather.Conditions.IndexOf(weather.CurrentCondition) + 1) / 10);
        }
       
        //Member Methods

    }
}
