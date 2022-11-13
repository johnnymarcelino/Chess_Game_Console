using System;
using Game_Board;
using Chess;

namespace Chess_Game
{
    internal class Screen
    {
        public static void GameBoardPrint(GameBoard gmbd)  // static => membro não necessita da instaciação da classe, .:. livre
        {
            for (int i = 0; i < gmbd.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gmbd.Columns; j++)
                {
                    PrintPiece(gmbd.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void GameBoardPrint(GameBoard gmbd, bool[,] possiblePositions)  // static => membro não necessita da instaciação da classe, .:. livre
        {

            ConsoleColor originalBackGround = Console.BackgroundColor;
            ConsoleColor modifieldBackGround = ConsoleColor.DarkGray;

            for (int i = 0; i < gmbd.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gmbd.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = modifieldBackGround;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackGround;
                    }
                    PrintPiece(gmbd.Piece(i, j));
                    Console.BackgroundColor = originalBackGround;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackGround;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
