using Game_Board;
using System;

namespace Chess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gmbd = new GameBoard(8, 8);  // tipo matriz inicia-se com valor nulo.


            Screen.GameBoardPrint(gmbd);
            Console.ReadLine();
        }
    }
}
