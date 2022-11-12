using Chess;
using Game_Board;
using System;
using System.IO;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameBoard gmbd = new GameBoard(8, 8);  // tipo matriz inicia-se com valor nulo.

                gmbd.PutPiece(new Tower(gmbd, Color.Black), new Position(1, 5));
                gmbd.PutPiece(new Tower(gmbd, Color.Black), new Position(4, 3));
                gmbd.PutPiece(new Rey(gmbd, Color.Black), new Position(1, 3));
                Screen.GameBoardPrint(gmbd);

                gmbd.PutPiece(new Tower(gmbd, Color.White), new Position(3, 5));
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
