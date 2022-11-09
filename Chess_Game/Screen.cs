using System;
using Game_Board;

namespace Chess_Game
{
    internal class Screen
    {
        public static void GameBoardPrint(GameBoard gmbd)
        {
            for (int i = 0; i < gmbd.Lines; i++)
            {
                for (int j = 0; j < gmbd.Columns; j++)
                {
                    if (gmbd.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(gmbd.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
