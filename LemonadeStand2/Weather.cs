using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Weather
    {
        public string temperature;
        public string condition;
        public Weather()
        {

        }
        public int GetTemp(Random rnd)
        {
            int temperature = rnd.Next(1, 4);

            switch (temperature)
            {
                case 1:
                    this.temperature = "Hot";
                    break;
                case 2:
                    this.temperature = "Warm";
                    break;
                case 3:
                    this.temperature = "Cold";
                    break;
                default:
                    Console.WriteLine("There was an error getting the report");
                    break;
            }
            return temperature;
        }
        public int GetOvercast(Random rnd)
        {
            int condition = rnd.Next(1, 4);

            switch (condition)
            {
                case 1:
                    this.condition = "and sunny";
                    break;
                case 2:
                    this.condition = "and cloudy";
                    break;
                case 3:
                    this.condition = "with thunderstorms";
                    break;
                default:
                    Console.WriteLine("There was an error getting the report");
                    break;
            }
            return condition;
        }
        public void DisplayCurrentWeather()
        {
            Console.WriteLine($"Today's forcast is: {temperature} {condition}\n");
        }
        public void DisplayForecast()
        {
            Console.WriteLine($"The weather for tomorrow is: {temperature} {condition}\n");
        }
    }
}
