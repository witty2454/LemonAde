using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Demand
    {
        public int priceDemand;
        public int weatherDemand;

        public Demand(Recipe recipe, Weather weather)
        {
            GetPriceDemand(recipe);
            GetWeatherDemand(weather);
        }
        public int GetPriceDemand(Recipe recipe)
        {
            if (recipe.lemonadePrice <= .50)
            {
                priceDemand = 1;
            }
            else if (recipe.lemonadePrice >= .51 && recipe.lemonadePrice <= .75)
            {
                priceDemand = 2;
            }
            else if (recipe.lemonadePrice >= .76 && recipe.lemonadePrice <= 1.00)
            {
                priceDemand = 3;
            }
            else if (recipe.lemonadePrice >= 1.01)
            {
                priceDemand = 4;
            }
            return priceDemand;
        }
        public int GetWeatherDemand(Weather weather)
        {
            if (weather.temperature == "Hot" && weather.condition == "and sunny")
            {
                weatherDemand = 1;
            }
            else if (weather.temperature == "Hot" && weather.condition == "and cloudy")
            {
                weatherDemand = 2;
            }
            else if (weather.temperature == "Hot" && weather.condition == "with thunderstorms")
            {
                weatherDemand = 3;
            }
            else if (weather.temperature == "Warm" && weather.condition == "and sunny")
            {
                weatherDemand = 2;
            }
            else if (weather.temperature == "Warm" && weather.condition == "and cloudy")
            {
                weatherDemand = 3;
            }
            else if (weather.temperature == "Warm" && weather.condition == "with thunderstorms")
            {
                weatherDemand = 4;
            }
            else if (weather.temperature == "Cold" && weather.condition == "and sunny")
            {
                weatherDemand = 3;
            }
            else if (weather.temperature == "Cold" && weather.condition == "and cloudy")
            {
                weatherDemand = 4;
            }
            else if (weather.temperature == "Cold" && weather.condition == "with thunderstorms")
            {
                weatherDemand = 5;
            }
            return weatherDemand;
        }
    }
}
