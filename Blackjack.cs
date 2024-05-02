using System;

namespace Roulette
{
    internal class Blackjack
    {
        public void PlayBlackjack(User user, Bank bank)
        {


            int spielerPunkte;
            int hausPunkte;
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Blackjack ist ein Kartenspiel, bei dem das Ziel ist, eine Hand mit einem Wert von 21 oder so nah wie möglich daran zu erreichen, ohne darüber hinauszugehen. Jeder Spieler und der Dealer erhalten zu Beginn zwei Karten. Die Karten 2 bis 10 haben ihren Nennwert, Bildkarten zählen als 10 und Asse können entweder als 1 oder 11 gezählt werden. Der Spieler kann entweder eine weitere Karte nehmen (hit) oder stehen bleiben (stand), um ihren Wert zu halten. Wenn der Wert der Hand des Spielers über 21 liegt, verliert er automatisch (bust). Der Dealer muss nach festgelegten Regeln spielen, normalerweise muss er bei 17 oder höher stehen bleiben. Der Spieler gewinnt, wenn seine Hand einen höheren Wert hat als die des Dealers, aber nicht über 21 liegt, oder wenn der Dealer über 21 geht.");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Wie ist dein Name?");
            string spielername = Console.ReadLine();

            bool wantsToPlay = true;
            while (wantsToPlay)
            {

                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Wie viele Chips möchtest du setzen?");
                int einsatz = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Sie haben erfolgreich " + einsatz + " Chips eingesetzt.");
                Console.WriteLine("------------------------------------------------------------------------");
                string[] karten = new string[13];
                karten[0] = "Ass";
                karten[1] = "Zwei";
                karten[2] = "Drei";
                karten[3] = "Vier";
                karten[4] = "Fünf";
                karten[5] = "Sechs";
                karten[6] = "Sieben";
                karten[7] = "Acht";
                karten[8] = "Neun";
                karten[9] = "Zehn";
                karten[10] = "Bube";
                karten[11] = "Dame";
                karten[12] = "König";

                int[] werte = new int[13];

                werte[0] = 11;
                werte[1] = 2;
                werte[2] = 3;
                werte[3] = 4;
                werte[4] = 5;
                werte[5] = 6;
                werte[6] = 7;
                werte[7] = 8;
                werte[8] = 9;
                werte[9] = 10;
                werte[10] = 10;
                werte[11] = 10;
                werte[12] = 10;

                int agrobotwert = 0;
                int passivbotwert = 0;
                int spielerwert = 0;
                int bankwert = 0;
                int austeilen = 0;
                string verdecktekarte = "";
                int agroAss = 0;
                int passivAss = 0;
                int bankAss = 0;
                int spielerAss = 0;

                Random zufall = new Random();

                while (austeilen < 2)
                {
                    int index = zufall.Next(0, karten.Length);
                    string spieler = karten[index];
                    spielerwert += werte[index];
                    if (spieler == "Ass")
                    {
                        spielerAss += 1;
                    }

                    if (spielerwert > 21 && spielerAss > 0)
                    {
                        spielerwert -= 10;
                        spielerAss -= 1;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Sie haben ein(e) [ " + spieler + " ] bekommen und haben nun:" + spielerwert + " Punkte.");


                    int index2 = zufall.Next(0, karten.Length);
                    string agrobot = karten[index2];
                    agrobotwert += werte[index2];
                    if (agrobot == "Ass")
                    {
                        agroAss += 1;
                    }

                    if (agrobotwert > 21 && agroAss > 0)
                    {
                        agrobotwert -= 10;
                        agroAss -= 1;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Der AgroBot hat ein(e) [ " + agrobot + " ] bekommen und hat nun:" + agrobotwert + " Punkte.");


                    int index3 = zufall.Next(0, karten.Length);
                    string passivbot = karten[index3];
                    passivbotwert += werte[index3];
                    if (passivbot == "Ass")
                    {
                        passivAss += 1;
                    }

                    if (passivbotwert > 21 && passivAss > 0)
                    {
                        passivbotwert -= 10;
                        passivAss -= 1;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Der PassivBot hat ein(e) [ " + passivbot + " ] bekommen und hat nun:" + passivbotwert + " Punkte.");


                    Random zufallhaus = new Random();
                    int index1 = zufallhaus.Next(0, karten.Length);
                    string bankKarten = karten[index1];
                    bankwert += werte[index1];
                    if (bankKarten == "Ass")
                    {
                        bankAss += 1;
                    }
                    if (bankwert > 21 && bankAss > 0)
                    {
                        bankwert -= 10;
                        bankAss -= 1;
                    }
                    austeilen++;
                    if (austeilen == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(" Die Bank hat eine [ Verdeckte Karte ] und ein(e) [ " + bank + " ] gezogen.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (austeilen == 1)
                    {
                        verdecktekarte = karten[index1];
                    }
                }

                while (spielerwert <= 21)
                {
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine("Sie haben nun " + spielerwert + " möchten Sie noch eine Karte ziehen");
                    Console.WriteLine("Antworten Sie mit [ja] oder [nein]");
                    string mehrkarten = Console.ReadLine().ToLower();
                    Console.WriteLine("------------------------------------------------------------------------");

                    if (mehrkarten == "ja")
                    {
                        int index = zufall.Next(0, karten.Length);
                        string spieler = karten[index];
                        spielerwert += werte[index];
                        if (spieler == "Ass")
                        {
                            spielerAss += 1;
                        }
                        if (spielerwert > 21 && spielerAss > 0)
                        {
                            spielerwert -= 10;
                            spielerAss -= 1;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" Sie haben ein(e) [ " + spieler + " ] bekommen und haben nun:" + spielerwert + " Punkte.");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (mehrkarten == "nein")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" Sie haben jetzt:" + spielerwert + " Punkte.");
                        Console.ForegroundColor = ConsoleColor.White;
                        while (agrobotwert < 17 || passivbotwert < 10)
                        {
                            if (agrobotwert < 17)
                            {
                                int index2 = zufall.Next(0, karten.Length);
                                string agrobot = karten[index2];
                                agrobotwert += werte[index2];
                                if (agrobot == "Ass")
                                {
                                    agroAss += 1;
                                }

                                if (agrobotwert > 21 && agroAss > 0)
                                {
                                    agrobotwert -= 10;
                                    agroAss -= 1;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Der AgroBot hat ein(e) [ " + agrobot + " ] bekommen und hat nun:" + agrobotwert + " Punkte.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (agrobotwert >= 17)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Der AgroBot hat keine Karte gezogen und hat weiterhin:" + agrobotwert + " Punkte.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (passivbotwert < 10)
                            {
                                int index3 = zufall.Next(0, karten.Length);
                                string passivbot = karten[index3];
                                passivbotwert += werte[index3];
                                if (passivbot == "Ass")
                                {
                                    passivAss += 1;
                                }

                                if (passivbotwert > 21 && passivAss > 0)
                                {
                                    passivbotwert -= 10;
                                    passivAss -= 1;
                                }
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" Der PassivBot hat ein(e) [ " + passivbot + " ] bekommen und hat nun:" + passivbotwert + " Punkte.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (passivbotwert >= 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" Der PassivBot hat keine Karte gezogen und hat weiterhin:" + passivbotwert + " Punkte.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        break;
                    }
                    while (agrobotwert < 17 || passivbotwert < 10)
                    {
                        if (agrobotwert < 17)
                        {
                            int index2 = zufall.Next(0, karten.Length);
                            string agrobot = karten[index2];
                            agrobotwert += werte[index2];
                            if (agrobot == "Ass")
                            {
                                agroAss += 1;
                            }

                            if (agrobotwert > 21 && agroAss > 0)
                            {
                                agrobotwert -= 10;
                                agroAss -= 1;
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Der AgroBot hat ein(e) [ " + agrobot + " ] bekommen und hat nun:" + agrobotwert + " Punkte.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (agrobotwert >= 17)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Der AgroBot hat keine Karte gezogen und hat weiterhin:" + agrobotwert + " Punkte.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (passivbotwert < 10)
                        {
                            int index3 = zufall.Next(0, karten.Length);
                            string passivbot = karten[index3];
                            passivbotwert += werte[index3];
                            if (passivbot == "Ass")
                            {
                                passivAss += 1;
                            }

                            if (passivbotwert > 21 && passivAss > 0)
                            {
                                passivbotwert -= 10;
                                passivAss -= 1;
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Der PassivBot hat ein(e) [ " + passivbot + " ] bekommen und hat nun:" + passivbotwert + " Punkte.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (passivbotwert >= 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Der PassivBot hat keine Karte gezogen und hat weiterhin:" + passivbotwert + " Punkte.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Die Verdeckte Karte der Bank war ein(e) [ " + verdecktekarte + " ] und die Bank hat nun " + bankwert + " Punkte.");
                while (bankwert <= 16 && spielerwert <= 21)
                {
                    int index1 = zufall.Next(0, karten.Length);
                    string bankKarten = karten[index1];
                    bankwert += werte[index1];
                    if (bankKarten == "Ass")
                    {
                        bankAss += 1;
                    }
                    if (bankwert > 21 && bankAss > 0)
                    {
                        bankwert -= 10;
                        bankAss -= 1;
                    }
                    Console.WriteLine("Die Bank hat ein(e) [ " + bank + " ] gezogen und hat nun " + bankwert + " Punkte.");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Sie haben:" + spielerwert + " Punkte.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Der AgroBot hat :" + agrobotwert + " Punkte.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Der PassivBot hat:" + passivbotwert + " Punkte.");
                Console.ForegroundColor = ConsoleColor.White;

                int spielernummer = 0;

                while (spielernummer < 3)
                {
                    int[] spielerrunde = { spielerwert, agrobotwert, passivbotwert };
                    string[] spielernamen = { spielername, "AgroBot", "PassivBot" };
                    int auswertung = spielerrunde[spielernummer];
                    string name = spielernamen[spielernummer];
                    if (auswertung == bankwert)
                    {
                        Console.WriteLine("Unentschieden! " + name + " behält all seine Chips");
                    }
                    else if (auswertung == 21)
                    {
                        Console.WriteLine("Glückwunsch! " + name + " hat ein Blackjack und somit gewonnen");
                        Console.WriteLine("Der Gewinn von " + name + $" beträgt {einsatz * 2}  Chips");
                        user.UserCredits -= einsatz;
                        bank.BankCredits += einsatz;
                    }
                    else if (auswertung > 21)
                    {
                        Console.WriteLine("Niederlage! " + name + " hat 21 überschritten und alles verloren.");
                        Console.WriteLine("Der Verlust von " + name + $" beträgt -{einsatz * 2}  Chips");
                        user.UserCredits -= einsatz;
                        bank.BankCredits += einsatz;
                    }
                    else if (auswertung > bankwert)
                    {
                        Console.WriteLine("Glückwunsch! " + name + " hat mehr Punkte als die Bank und somit gewonnen.");
                        Console.WriteLine("Der Gewinn von " + name + $" beträgt {einsatz * 2} Chips");
                        user.UserCredits -= einsatz;
                        bank.BankCredits += einsatz;
                    }
                    else if (auswertung < bankwert)
                    {
                        Console.WriteLine("Niederlage! " + name + " hat weniger Punkte als die Bank und somit veloren.");
                        Console.WriteLine("Der Verlust von " + name + $" beträgt -{einsatz * 2} Chips");
                        user.UserCredits -= einsatz;
                        bank.BankCredits += einsatz;
                    }
                    spielernummer++;
                }
                Console.WriteLine("Wollen Sie erneut spielen? [ja/nein]");
                string playsAgain = Console.ReadLine().ToLower();
                if (playsAgain == "ja")
                {
                    wantsToPlay = true;
                }
                else if (playsAgain == "nein")
                {
                    wantsToPlay = false;
                }
                else
                {
                    Console.WriteLine("Das habe ich nicht verstanden!");
                }
            }

            Console.WriteLine("Möchten Sie eine Runde Roulette spielen? [ja/nein]");
            string wantsRoulette = Console.ReadLine().ToLower();
            if (wantsRoulette == "ja")
            {
                Console.Clear();
                Console.WriteLine("Wechsel zum Roulette-Spiel...");
                Roulette roulette = new Roulette(user, bank);
                roulette.PlayRoulette();
            }
            else
            {
                Console.WriteLine("Vielen Dank fürs Spielen!");
            }
        }

    }
}

