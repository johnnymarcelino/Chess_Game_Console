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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(game);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origen = Screen.ReadChessPosition().ToPosition();
                        game.ValidateOriginPosition(origen);

                        bool[,] possiblePositions = game.Gmbd.Piece(origen).PossibleMoves();

                        Console.Clear();
                        Screen.GameBoardPrint(game.Gmbd, possiblePositions);

                        Console.WriteLine();
                        Console.WriteLine("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        game.ValidateDestinationPosition(origen, destination);

                        game.MakePlay(origen, destination);
                    }
                    catch (GameBoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(game);
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
