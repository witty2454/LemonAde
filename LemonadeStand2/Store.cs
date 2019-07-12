using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Store
    {
        public double totalExpense;
        public Store()
        {
        }
        public void StoreStart(Player player)
        {
            Console.WriteLine("STORE");
            Console.WriteLine("Welcome to the store! While you are here you can buy the necessary items to make your lemonade. What would you like to do:'buy' ingredients, 'check' inventory, 'leave' store?");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "buy":
                    Console.WriteLine("Decide how much of each supply you would like to buy. If you do not want to buy an item, type 0.\n\n PRICES:\n\nLemons: $.15\nSugar: $.05\nIce: $.05\nCups: $.10\n\n");
                    player.inventory.DisplayInventory();
                    int lemon = PlayerBuyLemon(player);
                    AddLemonToInventory(player, lemon);
                    int sugar = PlayerBuySugar(player);
                    AddSugarToInventory(player, sugar);
                    int ice = PlayerBuyIce(player);
                    AddIceToInventory(player, ice);
                    int cup = PlayerBuyCup(player);
                    AddCupToInventory(player, cup);
                    player.inventory.DisplayInventory();
                    GetPlayerTotalExpense(lemon * new Lemon().price, sugar * new Sugar().price, ice * new Ice().price, cup * new Cup().price);
                    Console.Clear();
                    StoreStart(player);
                    break;

                case "check":
                    player.inventory.DisplayInventory();
                    Console.Clear();
                    StoreStart(player);
                    break;

                case "leave":
                    if ((player.inventory.supplies[0].Count <= 0) || (player.inventory.supplies[1].Count) <= 0 || (player.inventory.supplies[2].Count <= 0) || (player.inventory.supplies[3].Count <= 0))
                    {
                        Console.WriteLine("It looks like you don't have enough supplies to make lemonade. Please check your inventory and buy the necessary items to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        StoreStart(player);
                    }
                    else
                    {
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("User error, please select one of the options.");
                    Console.ReadKey();
                    Console.Clear();
                    StoreStart(player);
                    break;
            }
        }
        public int PlayerBuyLemon(Player player)
        {
            Console.WriteLine("How many lemons would you like to buy?");
            int lemon = int.Parse(Console.ReadLine());
            if (!WithdrawLemonMoney(player, GetLemonExpense(lemon)))
            {
                return PlayerBuyLemon(player);
            }
            return lemon;
        }
        public double GetLemonExpense(int lemon)
        {
            double expense;
            expense = lemon * new Lemon().price;
            return expense;
        }
        public bool WithdrawLemonMoney(Player player, double expense)
        {
            if (player.inventory.money >= expense)
            {
                player.inventory.money -= expense;
                return true;
            }
            else
            {
                Console.WriteLine("You do not have enough money to buy that amount of lemons.\n\n");
                return false;
            }
        }
        public void AddLemonToInventory(Player player, int lemon)
        {
            for (int i = 0; i < lemon; i++)
            {
                player.inventory.AddLemon(new Lemon());
            }
        }
        public int PlayerBuySugar(Player player)
        {
            Console.WriteLine("How much sugar would you like to buy?");
            int sugar = int.Parse(Console.ReadLine());
            if (!WithdrawSugarMoney(player, GetSugarExpense(sugar)))
            {
                return PlayerBuySugar(player);
            }
            return sugar;
        }
        public double GetSugarExpense(int sugar)
        {
            double expense;
            expense = sugar * new Sugar().price;
            return expense;
        }
        public bool WithdrawSugarMoney(Player player, double expense)
        {
            if (player.inventory.money >= expense)
            {
                player.inventory.money -= expense;
                return true;
            }
            else
            {
                Console.WriteLine("You do not have enough money to buy that amount of sugar.\n\n");
                return false;
            }
        }
        public void AddSugarToInventory(Player player, int sugar)
        {
            for (int i = 0; i < sugar; i++)
            {
                player.inventory.AddSugar(new Sugar());
            }
        }
        public int PlayerBuyIce(Player player)
        {
            Console.WriteLine("How much ice would you like to buy?");
            int ice = int.Parse(Console.ReadLine());
            if (!WithdrawIceMoney(player, GetIceExpense(ice)))
            {
                return PlayerBuyIce(player);
            }
            return ice;
        }
        public double GetIceExpense(int ice)
        {
            double expense;
            expense = ice * new Ice().price;
            return expense;
        }
        public bool WithdrawIceMoney(Player player, double expense) //TODO
        {
            if (player.inventory.money >= expense)
            {
                player.inventory.money -= expense;
                return true;
            }
            else
            {
                Console.WriteLine("You do not have enough money to buy that amount of ice.\n\n");
                return false;
            }
        }
        public void AddIceToInventory(Player player, int ice)
        {
            for (int i = 0; i < ice; i++)
            {
                player.inventory.AddIce(new Ice());
            }
        }
        public int PlayerBuyCup(Player player)
        {
            Console.WriteLine("How many cups would you like to buy?");
            int cup = int.Parse(Console.ReadLine());
            if (!WithdrawCupMoney(player, GetCupExpense(cup)))
            {
                return PlayerBuyCup(player);
            }
            return cup;
        }
        public double GetCupExpense(int cup)
        {
            double expense;
            expense = cup * new Cup().price;
            return expense;
        }
        public bool WithdrawCupMoney(Player player, double expense)
        {
            if (player.inventory.money >= expense)
            {
                player.inventory.money -= expense;
                return true;
            }
            else
            {
                Console.WriteLine("You do not have enough money to buy that amount of cups.\n\n");
                return false;
            }
        }
        public void AddCupToInventory(Player player, int cup)
        {
            for (int i = 0; i < cup; i++)
            {
                player.inventory.AddCup(new Cup());
            }
        }
        public double GetPlayerTotalExpense(double lemonExpense, double sugarExpense, double iceExpense, double cupExpense)
        {
            double totalExpense;
            totalExpense = lemonExpense + sugarExpense + iceExpense + cupExpense;
            return totalExpense;
        }
    }
}
