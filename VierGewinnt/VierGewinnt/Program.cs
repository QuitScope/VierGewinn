using System;

namespace VierGewinnt
{
    class Program

    {
        public class Board
        {
            public int[,] Field;
            public int Player;
            public Boolean GameOver = false;
        }

        static Board NewGame()
        {
            Board board = new();
            board.Field = new int[6, 7];

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

        //static Board Turn(Board board)
        //{
        //    Console.Clear();
        //    if (board.Player == 1)
        //        Console.WriteLine("Spieler 1 ist dran!");
        //    else
        //        Console.WriteLine("Spieler 2 ist dran!");


        //} 
        static void Main(string[] args)
        {
            Board board = NewGame();
        }
    }
}
