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
        private Random random;

        public Day(Random random)
        {
            this.random = random;
            weather = new Weather(random);
            customers = new List<Customer>();
            PopulateCustomerList();
            SetWeatherValue();
            numberOfCupsSoldToday = 0;
        }
        //Member Methods
        private void SetWeatherValue()
        {
            weatherValue = (weather.Temperature * (weather.Conditions.IndexOf(weather.CurrentCondition) + 1) / 10);
        }
        private void PopulateCustomerList()
        {
            int numberOfCustomers = random.Next(90, 110);
            for (int i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(new Customer(random));
            }
        }
    }
}
