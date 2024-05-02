using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    internal class RouletteGame
    {
        private readonly User _user;
        private readonly Bank _bank;

        public RouletteGame(User user, Bank bank)
        {
            _user = user;
            _bank = bank;
        }

        public void Play()
        {
            Console.WriteLine("Willkommen beim Roulette!");

            while (true)
            {
                Console.WriteLine("Ihr aktuelles Guthaben: " + _user.UserCredits);

                
                Console.WriteLine("Platzieren Sie Ihren Einsatz:");
                int betAmount = GetBetAmount();

               
                List<string> betFields = GetBetFields();

                
                string winningField = SimulateRouletteSpin();

                
                int winnings = CalculateWinnings(betFields, winningField, betAmount);

                
                _user.UserCredits += winnings;

                Console.WriteLine($"Gewonnen: {winnings} | Neues Guthaben: {_user.UserCredits}");

                Console.WriteLine("Möchten Sie noch eine Runde spielen? [ja/nein]");
                string continueResponse = Console.ReadLine();
                if (continueResponse.ToLower() != "ja")
                    break;
            }
        }

        private int GetBetAmount()
        {
            int betAmount;
            while (true)
            {
                Console.Write("Geben Sie den Betrag Ihres Einsatzes ein: ");
                if (int.TryParse(Console.ReadLine(), out betAmount) && betAmount > 0 && betAmount <= _user.UserCredits)
                    return betAmount;
                Console.WriteLine("Ungültiger Betrag oder nicht genügend Guthaben.");
            }
        }

        private List<string> GetBetFields()
        {
            Console.WriteLine("Platzieren Sie Ihre Wetten (z.B. Rot, Schwarz, Zahl): ");
            string[] availableFields = { "Rot", "Schwarz", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36" };
            List<string> betFields = new List<string>();

            while (true)
            {
                string bet = Console.ReadLine();
                if (availableFields.Contains(bet))
                {
                    betFields.Add(bet);
                    Console.WriteLine("Weitere Wette platzieren oder 'fertig' eingeben, um fortzufahren.");
                }
                else if (bet.ToLower() == "fertig")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ungültige Wette. Bitte erneut eingeben.");
                }
            }

            return betFields;
        }

        private string SimulateRouletteSpin()
        {
            
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                return "Rot";
            }
            else
            {
                return "Schwarz";
            }
        }

        private int CalculateWinnings(List<string> betFields, string winningField, int betAmount)
        {
            if (betFields.Contains(winningField))
            {
                if (winningField == "Rot" || winningField == "Schwarz")
                {
                    return betAmount * 2; 
                }
                else if (int.TryParse(winningField, out int winningNumber))
                {
                   
                    if (betFields.Contains(winningField))
                    {
                        return betAmount * 36; 
                    }
                    else
                    {
                        return 0; 
                    }
                }
            }
            return -betAmount; 
        }
    }
}
