using System;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game rungame = new Game();
            rungame.RunGame();
            Console.ReadKey();
        }
    }
}