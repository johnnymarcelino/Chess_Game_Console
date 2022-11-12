using Chess;
using Game_Board;
using System;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameBoard gmbd = new GameBoard(8, 8);  // tipo matriz inicia-se com valor nulo.

                gmbd.PutPiece(new Tower(gmbd, Color.Preta), new Position(0, 0));
                gmbd.PutPiece(new Tower(gmbd, Color.Preta), new Position(8, 3));
                gmbd.PutPiece(new Rey(gmbd, Color.Preta), new Position(1, 3));
                Screen.GameBoardPrint(gmbd);
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
