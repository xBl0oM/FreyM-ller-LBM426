using System;
using System.Collections.Generic;

namespace Roulette
{
    internal class Roulette
    {
        private readonly User _user;
        private readonly Bank _bank;

        public Roulette(User user, Bank bank)
        {
            _user = user;
            _bank = bank;
        }

        public void PlayRoulette()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" _______                       __              __      __               \r\n/       \\                     /  |            /  |    /  |              \r\n$$$$$$$  |  ______   __    __ $$ |  ______   _$$ |_  _$$ |_     ______  \r\n$$ |__$$ | /      \\ /  |  /  |$$ | /      \\ / $$   |/ $$   |   /      \\ \r\n$$    $$< /$$$$$$  |$$ |  $$ |$$ |/$$$$$$  |$$$$$$/ $$$$$$/   /$$$$$$  |\r\n$$$$$$$  |$$ |  $$ |$$ |  $$ |$$ |$$    $$ |  $$ | __ $$ | __ $$    $$ |\r\n$$ |  $$ |$$ \\__$$ |$$ \\__$$ |$$ |$$$$$$$$/   $$ |/  |$$ |/  |$$$$$$$$/ \r\n$$ |  $$ |$$    $$/ $$    $$/ $$ |$$       |  $$  $$/ $$  $$/ $$       |\r\n$$/   $$/  $$$$$$/   $$$$$$/  $$/  $$$$$$$/    $$$$/   $$$$/   $$$$$$$/ \r\n                                                                        \r\n                                                                        \r\n                                                                        ");
            Console.ResetColor(); 

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Aktuelle Credits: {_user.UserCredits}");
                Console.ResetColor();

                Console.WriteLine("Möchten Sie eine Wette platzieren? [ja/nein]");
                string response = Console.ReadLine();

                if (response.ToLower() == "nein")
                {
                    Console.WriteLine("Auf Wiedersehen!");
                    break;
                }
                else if (response.ToLower() == "ja")
                {
                    PlaceBet();
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie 'ja' oder 'nein' ein.");
                }
            }
        }

        private void PlaceBet()
        {
            Console.WriteLine("Geben Sie den Betrag ein, den Sie setzen möchten:");
            int betAmount;
            while (!int.TryParse(Console.ReadLine(), out betAmount) || betAmount <= 0 || betAmount > _user.UserCredits)
            {
                Console.WriteLine("Ungültiger Betrag. Bitte geben Sie eine positive Zahl ein, die kleiner oder gleich Ihren aktuellen Credits ist:");
            }

            Console.WriteLine("Geben Sie die Art der Wette ein [Rot/Schwarz oder eine Zahl 1-36]:");
            string betType = Console.ReadLine();

           
            List<string> validColors = new List<string> { "rot", "schwarz" };

            if (validColors.Contains(betType.ToLower()))
            {
                
                ProcessColorBet(betType, betAmount);
            }
            else
            {
               
                int number;
                while (!int.TryParse(betType, out number) || number < 0 || number > 36)
                {
                    Console.WriteLine("Ungültige Zahl. Bitte geben Sie eine Zahl zwischen 0 und 36 ein:");
                    betType = Console.ReadLine();
                }

                ProcessNumberBet(number, betAmount);
            }
        }

        private void ProcessColorBet(string color, int betAmount)
        {
            Random random = new Random();
            string[] rouletteColors = { "rot", "schwarz" };
            string winningColor = rouletteColors[random.Next(rouletteColors.Length)];

            Console.WriteLine($"Die Kugel landete auf {winningColor}.");

            if (winningColor.ToLower() == color.ToLower())
            {
                int winnings = betAmount * 2;
                Console.WriteLine($"Glückwunsch! Sie haben die richtige Farbe gewählt und gewinnen {winnings} Credits.");
                _user.UserCredits += winnings;
                _bank.BankCredits -= winnings;
            }
            else
            {
                Console.WriteLine("Leider haben Sie die falsche Farbe gewählt. Sie verlieren Ihren Einsatz.");
                _user.UserCredits -= betAmount;
                _bank.BankCredits += betAmount;
            }
        }

        private void ProcessNumberBet(int number, int betAmount)
        {
            Random random = new Random();
            int winningNumber = random.Next(0, 37); 

            Console.WriteLine($"Die Kugel landete auf {winningNumber}.");

            if (winningNumber == number)
            {
                int winnings = betAmount * 36;
                Console.WriteLine($"Glückwunsch! Sie haben die richtige Zahl gewählt und gewinnen {winnings} Credits.");
                _user.UserCredits += winnings;
                _bank.BankCredits -= winnings;
            }
            else
            {
                Console.WriteLine("Leider haben Sie die falsche Zahl gewählt. Sie verlieren Ihren Einsatz.");
                _user.UserCredits -= betAmount;
                _bank.BankCredits += betAmount;
            }
        }
    }
}