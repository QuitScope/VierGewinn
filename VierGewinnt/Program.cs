using System;

namespace VierGewinnt
{
    class Program

    {
        struct Board
        {
            public int[,] Field;
            public int Player;
            public bool GameOver;
        }

        static Board NewGame()
        {
            Board board = new();
            board.Field = new int[6, 7];
            board.GameOver = false;

            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    board.Field[i, j] = 0;
                }
            }

            board.Player = 1;
            return board;
        }
        static Board SetToken(Board board, int col)
        {
            //nunit für C# laden
            for (int i = 0; i < 6; i++)
            {
                if (i == 5 || board.Field[i + 1, col] != 0)
                {
                    board.Field[i, col] = board.Player;

                    if (board.Player == 1)
                        board.Player = 2;
                    else
                        board.Player = 1;
                }
            }
            return board;
        }

        static void Ausgabe(Board board)
        {
            char EckeLinksOben = (char)(0x250C);
            char EckeRechtsOben = (char)(0x2510);
            char EckeLinksUnten = (char)(0x2514);
            char EckeRechtsUnten = (char)(0x2518);
            char Waagerechte = (char)(0x2500);
            char Senkrechte = (char)(0x2502);
            char TrennerOben = (char)(0x252C);
            char TrennerLinks = (char)(0x251C);
            char TrennerRechts = (char)(0x2524);
            char TrennerUnten = (char)(0x2534);
            char Kreuz = (char)(0x253C);

            Console.Clear();
            if(board.Player == 1)
            {
                Console.WriteLine("Spieler 1 ist dran!\n");
            }
            else
            {
                Console.WriteLine("Spieler 2 ist dran!\n");
            }

            Console.Write("{0}{1}{1}{1}", EckeLinksOben, Waagerechte);
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0}{1}{1}{1}", TrennerOben, Waagerechte);
            }
            Console.WriteLine("{0}", EckeRechtsOben);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("{0} {1} ", Senkrechte, board.Field[i, j]);
                }
                Console.WriteLine("{0}", Senkrechte);
                if (i < 5)
                {
                    Console.Write("{0}{1}{1}{1}", TrennerLinks, Waagerechte);
                    for (int k = 0; k < 6; k++)
                    {
                        Console.Write("{0}{1}{1}{1}", Kreuz, Waagerechte);
                    }
                    Console.WriteLine("{0}", TrennerRechts);
                }
            }

            Console.Write("{0}{1}{1}{1}", EckeLinksUnten, Waagerechte);
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0}{1}{1}{1}", TrennerUnten, Waagerechte);
            }
            Console.WriteLine("{0}", EckeRechtsUnten);

            Console.WriteLine("\n\nWähle eine Spalte durch eingeben der Nummer(1-7) aus.");

            Console.SetCursorPosition(0, 8);
        }
        static Board Turn(Board board)
        {
            Ausgabe(board);

            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey();

                // Falls Eingabe Zahl ist
                if (char.IsDigit(k.KeyChar) && Convert.ToInt32(k.KeyChar) - 49 < 7 &&
                    board.Field[0, Convert.ToInt32(k.KeyChar) - 49] == 0)
                {

                    board = SetToken(board, Convert.ToInt32(k.KeyChar) - 49);
                    //board = GewinnBerechnung(Spielfeld, Convert.ToInt32(k.KeyChar) - 49);

                    Ausgabe(board);
                    break;
                }
                else
                {
                    Ausgabe(board);
                }  // else End                                         

            } // while End

            return board;


        }
        static void Main(string[] args)
        {
            Board board = NewGame();

            // Ausgabe
            Console.WriteLine("Willkommen bei 4 Gewinnt!\n\n" +
                "Um ein neues Spiel zu starten drücke eine beliebige Taste...");
            while (!Console.KeyAvailable) { }

            while (true)
            {
                board = NewGame();

                while (!board.GameOver)
                {
                    // 1 Zug setzen
                    board= Turn(board);

                } // while End
                Console.Clear();

                if (board.Player == 1)
                    Console.Write("Spieler 2 hat gewonnen!");
                else
                    Console.Write("Spieler 1 hat gewonnen!");

                board.GameOver = false;
                Console.Write("\n\n\nDrücke eine beliebige Taste um ein neues Spiel zu starten!");
                while (!Console.KeyAvailable) { }
            } // while End
        }
    }
}
