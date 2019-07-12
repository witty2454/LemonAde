using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonadestand
{
    public class Inventory
    {
        public double money = 30.00;
        public List<List<Supply>> supplies;
        public double profit;
        List<Supply> lemon;
        List<Supply> sugar;
        List<Supply> ice;
        List<Supply> cup;
        List<Supply> lemonade;

        public Inventory()
        {
            supplies = new List<List<Supply>>();
            lemon = new List<Supply>();
            sugar = new List<Supply>();
            ice = new List<Supply>();
            cup = new List<Supply>();
            lemonade = new List<Supply>();
            supplies.Add(lemon);
            supplies.Add(sugar);
            supplies.Add(ice);
            supplies.Add(cup);
            supplies.Add(lemonade);
            //this adds the supplies to the list so they can be placeholders. 
        }

        public void AddLemon(Lemon lemon)
        {
            supplies[0].Add(lemon);
        }
        public void AddSugar(Sugar sugar)
        {
            supplies[1].Add(sugar);
        }
        public void AddIce(Ice ice)
        {
            supplies[2].Add(ice);
        }
        public void AddCup(Cup cup)
        {
            supplies[3].Add(cup);
        }
        public void AddLemonade(Lemonade lemonade)
        {
            supplies[4].Add(lemonade);
        }
        public void DisplayInventory()
        {
            Console.WriteLine($"Your current inventory:\n\n Money: ${money}\n Lemons: {supplies[0].Count}\n Sugar: {supplies[1].Count}\n Ice: {supplies[2].Count}\n Empty Cups: {supplies[3].Count}\n Cups of Lemonade: {supplies[4].Count}\n");
            Console.ReadKey();
        }
    }
}