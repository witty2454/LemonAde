using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Recipe
    {
        public int lemon;
        public int sugar;
        public int ice;
        public int cup;
        public double lemonadePrice;

        public Recipe()
        {
        }
        public void RecipeStart(Player player)
        {
            Console.WriteLine("RECIPE MAKER\n");
            Console.WriteLine("Time to make your recipe for the day! A basic lemonade recipe calls for 1 lemon, 2 sugars, and 2 ice, in one cup. You will be deciding how much of each ingredient to put in each individual cup and then you will decide how many cups to sell that day. Remember, the weather and the price will affect how many customers buy your lemonade. First, make your recipe, then make sure to set your price.\n\n");
            Console.WriteLine("What would you like to do: 'make' recipe, 'check' inventory, 'set' lemonade price, 'display' recipe, 'leave'?");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "make":
                    player.inventory.DisplayInventory();
                    lemon = PickLemons();
                    CheckLemonInventory(player, lemon);
                    sugar = PickSugar();
                    CheckSugarInventory(player, sugar);
                    ice = PickIce();
                    CheckIceInventory(player, ice);
                    cup = PickCup();
                    CheckCupInventory(player, cup);
                    int totalLemon = CalculateLemonUse(lemon, cup);
                    CheckLemonInventory(player, totalLemon);
                    int totalSugar = CalculateSugarUse(sugar, cup);
                    CheckSugarInventory(player, totalLemon);
                    int totalIce = CalculateIceUse(ice, cup);
                    CheckIceInventory(player, totalIce);
                    RemoveLemons(player, totalLemon);
                    RemoveSugar(player, totalSugar);
                    RemoveIce(player, totalIce);
                    RemoveCup(player, cup);
                    MakeLemonade(player, cup);
                    player.inventory.DisplayInventory();
                    Console.Clear();
                    RecipeStart(player);
                    break;

                case "check":
                    player.inventory.DisplayInventory();
                    Console.Clear();
                    RecipeStart(player);
                    break;
                case "set":
                    if (player.inventory.supplies[4].Count > 0)
                    {
                        DisplayRecipe(lemon, sugar, ice, cup);
                        PickLemonadePrice();
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("You haven't made any lemonade yet, what are you ging to sell?");
                        Console.ReadKey();
                        Console.Clear();
                        RecipeStart(player);
                    }
                    break;
                case "display":
                    DisplayRecipe(lemon, sugar, ice, cup);
                    Console.Clear();
                    RecipeStart(player);
                    break;
                case "leave":
                    if (lemonadePrice > 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Your didn't enter a price for your lemonade! You must enter a price for your lemonade.");
                        Console.ReadKey();
                        Console.Clear();
                        RecipeStart(player);
                    }
                    break;

                default:
                    Console.WriteLine("User error, please select one of the options.");
                    Console.ReadKey();
                    Console.Clear();
                    RecipeStart(player);
                    break;
            }
        }
        public int PickLemons()
        {
            Console.WriteLine("How many lemons would you like to put in your each cup?");
            lemon = int.Parse(Console.ReadLine());
            return lemon;
        }
        public bool CheckLemonInventory(Player player, int lemon)// TODO
        {//program will catch the user the first time and no matter what number is entered the second time, will throw error. 
            if (player.inventory.supplies[0].Count < lemon)
            {
                Console.WriteLine("You do not have that many lemons!");
                PickLemons();
            }
            return true;
        }
        public int PickSugar()
        {
            Console.WriteLine("\nHow much sugar would you like to put in each cup?");
            sugar = int.Parse(Console.ReadLine());
            return sugar;
        }
        public bool CheckSugarInventory(Player player, int sugarCount)
        {//program will catch the user the first time and no matter what number is entered the second time, will throw error.
            if (player.inventory.supplies[1].Count < sugar)
            {
                Console.WriteLine("You do not have that much sugar!");
                PickSugar();
            }
            return true;
        }
        public int PickIce()
        {
            Console.WriteLine("\nHow much ice would you like to put in each cup?");
            ice = int.Parse(Console.ReadLine());
            return ice;
        }
        public bool CheckIceInventory(Player player, int iceCount)
        {//program will catch the user the first time and no matter what number is entered the second time, will throw error.
            if (player.inventory.supplies[2].Count < iceCount)
            {
                Console.WriteLine("You do not have that much ice!");
                PickIce();
            }
            return true;
        }
        public int PickCup()
        {
            Console.WriteLine("\nHow many cups of lemonade would you like to make?");
            cup = int.Parse(Console.ReadLine());
            return cup;
        }
        public bool CheckCupInventory(Player player, int cupCount)
        {//program will catch the user the first time and no matter what number is entered the second time, will throw error.
            if (player.inventory.supplies[2].Count < cupCount)
            {
                Console.WriteLine("You do not have that many cups!");
                PickCup();
            }
            return true;
        }
        public int CalculateLemonUse(int lemon, int cup)
        {
            int totalLemons = lemon * cup;
            return totalLemons;
        }
        public int CalculateSugarUse(int sugar, int cup)
        {
            int totalSugar = sugar * cup;
            return totalSugar;
        }
        public int CalculateIceUse(int ice, int cup)
        {
            int totalIce = ice * cup;
            return totalIce;
        }
        public void RemoveLemons(Player player, int lemon)
        {
            for (int i = 0; i < lemon; i++)
            {
                player.inventory.supplies[0].RemoveAt(0);
            }
        }
        public void RemoveSugar(Player player, int sugar)
        {
            for (int i = 0; i < sugar; i++)
            {
                player.inventory.supplies[1].RemoveAt(0);
            }
        }
        public void RemoveIce(Player player, int ice)
        {
            for (int i = 0; i < ice; i++)
            {
                player.inventory.supplies[2].RemoveAt(0);
            }
        }
        public void RemoveCup(Player player, int cup)
        {
            for (int i = 0; i < cup; i++)
            {
                player.inventory.supplies[3].RemoveAt(0);
            }
        }
        public void MakeLemonade(Player player, int cup)
        {
            for (int i = 0; i < cup; i++)
            {
                player.inventory.AddLemonade(new Lemonade());
            }
        }
        public double PickLemonadePrice()
        {
            Console.WriteLine("How much would you like to sell each cup of your lemonade for?");
            lemonadePrice = double.Parse(Console.ReadLine());
            return lemonadePrice;
        }
        public void DisplayRecipe(int lemon, int sugar, int ice, int cup)
        {
            Console.WriteLine($"Your current recipe includes *(each number represents the amount of the item in each cup): \n Lemons: {lemon}  \n Sugar: {sugar} \nIce: {ice}\n Cups of Lemonade: {cup}\n");
            Console.ReadKey();
        }
    }
}
