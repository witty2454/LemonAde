using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class game
    public class Game
    {
        public Player player;
        public UserInterface UI;
        public Day runDay;
        public Store store;
        public Recipe recipe;
        public Random rnd;
        public Weather weather;

        public Game()
        {
            player = new Player();
            UI = new UserInterface();
            runDay = new Day();
            store = new Store();
            recipe = new Recipe();
            rnd = new Random();
            weather = new Weather();
        }
        public void RunGame()
        {
            UI.WelcomePlayer();
            Console.Clear();
            runDay.DisplayDay();
            player.inventory.DisplayInventory();
            store.StoreStart(player);
            Console.Clear();
            runDay.GetWeather(rnd);
            runDay.GetForecast(rnd);
            recipe.RecipeStart(player);
            Console.Clear();
            player.inventory.DisplayInventory();
            runDay.GetTotalCustomers(rnd, recipe);
            player.SellLemonade(runDay.customer);
            player.inventory.DisplayInventory();
            double dayEarning = runDay.CalculateDaysEarnings(player, recipe);
            double dayProfit = runDay.CalculateDayProfit(store);
            double runningProfit = CalculateDayOneProfit(dayProfit);
            //double totalProfit = CalculateTotalProfit(dayProfit,runningProfit)
            runDay.DisplayDayProfit();
            DisplayTotalProfit(runningProfit);
            AddProfit(runningProfit);
            player.CheckSpoilInventory();
            Console.Clear();
            EndOfDay();
            NewDay();
        }
        public double CalculateDayOneProfit(double dayProfit)
        {
            double dayOneProfit = dayProfit + 0;

            return dayOneProfit;
        }
        public double CalculateTotalProfit(double dayProfit, double runningProfit)
        {
            double totalProfit = dayProfit + runningProfit;

            return totalProfit;
        }
        public void DisplayTotalProfit(double totalProfit)
        {
            Console.WriteLine($"Your total profit is: ${totalProfit}!");
            Console.ReadKey();
        }
        public void AddProfit(double totalProfit)
        {
            player.inventory.money = totalProfit + player.inventory.money;
        }
        public void EndOfDay()
        {
            if (player.inventory.money <= 0)
            {
                Console.WriteLine("You have no more money!");
                Console.WriteLine("GAME OVER");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                runDay.day++;
            }
        }
        public void NewDay()
        {
            for (int i = 0; i < 8; i++)
            {
                if (runDay.day <= 7)
                {
                    runDay.DisplayDay();
                    store.StoreStart(player);
                    Console.Clear();
                    runDay.GetWeather(rnd);
                    runDay.GetForecast(rnd);
                    recipe.RecipeStart(player);
                    Console.Clear();
                    player.inventory.DisplayInventory();
                    runDay.GetTotalCustomers(rnd, recipe);
                    player.SellLemonade(runDay.customer);
                    player.inventory.DisplayInventory();
                    double dayEarning = runDay.CalculateDaysEarnings(player, recipe);
                    double dayProfit = runDay.CalculateDayProfit(store);
                    double runningProfit = CalculateDayOneProfit(dayProfit);
                    double totalProfit = CalculateTotalProfit(dayProfit, runningProfit);
                    runDay.DisplayDayProfit();
                    DisplayTotalProfit(runningProfit);
                    AddProfit(runningProfit);
                    player.CheckSpoilInventory();
                    Console.Clear();
                    EndOfDay();
                    NewDay();
                }
                else
                {
                    Console.WriteLine("Congrats on making it through a whole week with your lemonade stand!\n\n Game Over :D");
                    Console.ReadKey();
                    player.inventory.DisplayInventory();
                    return;
                }
            }
        }
    }
}
