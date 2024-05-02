using System;


namespace Roulette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User(0);
            Bank bank = new Bank(1000);
            StartScreen startScreen = new StartScreen(user, bank);
            startScreen.ConvertToCredits();
            startScreen.SelectGame();

            
            if (startScreen.Roulette)
            {
               
                Roulette roulette = new Roulette(user, bank);
                roulette.PlayRoulette();
            }
            else if (startScreen.Blackjack) 
            {
                Blackjack blackjack = new Blackjack();
                blackjack.PlayBlackjack(user, bank);


            }
            

            Console.ReadLine();
        }
    }
}