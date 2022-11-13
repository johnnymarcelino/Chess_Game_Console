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
                ChessGame game = new ChessGame();

                while (!game.Finished)
                {
                    Console.Clear();
                    Screen.GameBoardPrint(game.Gmbd);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origen = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = game.Gmbd.Piece(origen).PossibleMoves();

                    Console.Clear();
                    Screen.GameBoardPrint(game.Gmbd, possiblePositions);

                    Console.WriteLine();
                    Console.WriteLine("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    game.MoveOut(origen, destination);
                }
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
