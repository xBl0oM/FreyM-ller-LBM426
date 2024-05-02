using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace Roulette
{

    internal class StartScreen
    {
        private User _user;
        private Bank _bank;
        public bool Blackjack;
        public bool Roulette;
        private int _selectedCredits;

        public StartScreen(User user, Bank bank)
        {
            _user = user;
            _bank = bank;
        }

        public void ConvertToCredits()
        {
            Console.WriteLine("Möchten Sie ihre wertvollen Batzen in noch wertvollere Credits umwandeln? [ja/nein] ");
            string userResponse = Console.ReadLine();

            if (userResponse == "ja")
            {
                Console.WriteLine("Geben Sie den Betrag ein, den Sie in Credits umwandeln möchten:");
                int? amount = null;
                bool isNumberValid = false;
                while (!isNumberValid)
                {
                    try
                    {
                        amount = Convert.ToInt32(Console.ReadLine());
                        isNumberValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Na Hoppla, das habe ich nicht verstanden.");
                    }
                }

                if (amount.HasValue)
                {
                    _selectedCredits = amount.Value;
                    _user.UserCredits += _selectedCredits;
                    Console.WriteLine($"Sie haben erfolgreich {_selectedCredits} Credits erhalten.");
                }
                else
                {
                    Console.WriteLine("Keine gültige Eingabe. Credits wurden nicht hinzugefügt.");
                }
            }
            else
            {
                Console.WriteLine("Schade, in dem Fall werden Sie heute kein Gewinner des Lebens und im Casino.");
            }
        }

        public void SelectGame()
        {
            Console.WriteLine("Auf was haben Sie mehr Lust? Blackjack oder Roulette");
            bool isSelecting = false;
            string selectResponse = "";
            while (!isSelecting)
            {
                try
                {
                    selectResponse = Console.ReadLine();
                    isSelecting = true;
                }
                catch
                {
                    Console.WriteLine("Na Hoppla, das habe ich nicht verstanden.");
                }
            }

            switch (selectResponse.ToLower()) // Kleinschreibung für den Vergleich
            {
                case "roulette":
                    Console.WriteLine("Sie haben Roulette gewählt.");
                    RouletteGame rouletteGame = new RouletteGame(_user, _bank);
                    rouletteGame.Play();
                    break;
                case "blackjack":
                    Console.WriteLine("Sie haben Blackjack gewählt.");
                    // Hier können Sie den Aufruf für das Blackjack-Spiel einfügen, wenn Sie es implementieren.
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }
        }
    }

}
