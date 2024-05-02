using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User(100); 
            Bank bank = new Bank(1000);
            StartScreen startScreen = new StartScreen(user, bank);
            startScreen.ConvertToCredits();
            startScreen.SelectGame();

            Console.ReadLine(); 
        }

    }


}
