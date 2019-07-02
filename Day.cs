using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Day
    {
        public Weather weather;
        public int day;
        public List<Customer> customer;
        public double dayEarning;
        public double dayProfit;

        public Day()
        {
            day = 1;
            weather = new Weather();
            customer = new List<Customer>();
        }
        public void GetWeather(Random rnd)
        {
            weather.GetTemp(rnd);
            weather.GetOvercast(rnd);
            weather.DisplayCurrentWeather();
        }
        public void GetForecast(Random rnd)
        {
            weather.GetTemp(rnd);
            weather.GetOvercast(rnd);
            weather.DisplayForecast();
        }
        public void DisplayDay()
        {
            Console.WriteLine($"Today is Day {day}\n\n");
        }
        public void GetTotalCustomers(Random rnd, Recipe recipe)//customers that come out based on weather conditions
        {
            Demand demand = new Demand(recipe, weather);
            if (weather.temperature == "Hot" && weather.condition == "and sunny")
            {
                int customerNumber = rnd.Next(35, 40);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Hot" && weather.condition == "and cloudy")
            {
                int customerNumber = rnd.Next(30, 34);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Hot" && weather.condition == "with thunderstorms")
            {
                int customerNumber = rnd.Next(20, 29);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Warm" && weather.condition == "and sunny")
            {
                int customerNumber = rnd.Next(25, 31);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Warm" && weather.condition == "and cloudy")
            {
                int customerNumber = rnd.Next(20, 24);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Warm" && weather.condition == "with thunderstorms")
            {
                int customerNumber = rnd.Next(15, 19);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Cold" && weather.condition == "and sunny")
            {
                int customerNumber = rnd.Next(5, 11);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Cold" && weather.condition == "and cloudy")
            {
                int customerNumber = rnd.Next(0, 10);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
            else if (weather.temperature == "Cold" && weather.condition == "with thunderstorms")
            {
                int customerNumber = rnd.Next(0, 4);
                for (int i = 0; i < customerNumber; i++)
                {
                    customer.Add(new Customer(demand));
                }
            }
        }

        public double CalculateDaysEarnings(Player player, Recipe recipe)
        {
            dayEarning = recipe.lemonadePrice * player.soldInventory;
            return dayEarning;
        }
        public double CalculateDayProfit(Store store)
        {
            dayProfit = dayEarning - store.totalExpense;
            return dayProfit;
        }
        public void DisplayDayProfit()
        {
            if (dayProfit <= 0)
            {
                Console.WriteLine($"You lost money today! You lost ${dayProfit}.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"You made ${dayProfit} today!");
                Console.ReadKey();
            }
        }
    }
}
