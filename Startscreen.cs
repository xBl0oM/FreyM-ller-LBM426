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

        public StartScreen(User user, Bank bank)
        {
            _user = user;
            _bank = bank;

        }

        public void ConvertToCredits()
        {
            Console.WriteLine("Möchten Sie ihre wertvollen Batzen in noch wertvollere Credits umwandeln? [ja/nein] ");
            string userResponse = "";
            bool tryCatch = false;

            while (!tryCatch)
            {
                try
                {
                    userResponse = Console.ReadLine();
                    tryCatch = true;
                }
                catch
                {
                    Console.WriteLine("Na Hoppla, das habe ich nicht verstanden.");
                }
            }
            if (userResponse == "ja")
            {
                Console.WriteLine("Geben Sie den Betrag ein, den Sie in Credits umwandeln möchten:");
                int amount = Convert.ToInt32(Console.ReadLine());
                _user.UserCredits += amount;
                Console.WriteLine($"Sie haben erfolgreich {amount} Credits erhalten.");
            }
            else
            {
                Console.WriteLine("Schade, in dem Fall werden Sie heute kein Gewinner des Lebens und im Casino werden.");
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

            switch (selectResponse)
            {
                case "roulette":
                    Console.WriteLine("Sie haben Roulette gewählt.");
                    Roulette = true;
                    break;
                case "Roulette":
                    Console.WriteLine("Sie haben Roulette gewählt.");
                    Roulette = true;
                    break;
                case "blackjack":
                    Console.WriteLine("Sie haben Blackjack gewählt.");
                    Blackjack = true;
                    break;
                case "Blackjack":
                    Console.WriteLine("Sie haben Blackjack gewählt.");
                    Blackjack = true;
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }
        }
    }
}
