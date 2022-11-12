using Game_Board;
using System;
using System.Runtime.CompilerServices;

namespace Chess
{
    internal class ChessGame
    {

        public GameBoard Gmbd { get; private set; }
        private int Shift;
        private Color CurrentPlaryer;
        public bool Finished { get; private set; }


        public ChessGame()
        {
            Gmbd = new GameBoard(8, 8);
            Shift = 1;
            CurrentPlaryer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void MoveOut(Position origin, Position destination)
        {
            Piece p = Gmbd.WithdrawPiece(origin);
            p.IncludeQtyMove();
            Piece capturedPiece = Gmbd.WithdrawPiece(destination);
            Gmbd.PutPiece(p, destination);
        }

        private void PutPieces()
        {
            Gmbd.PutPiece(new Tower(Gmbd, Color.White), new ChessPosition('c', 1).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.White), new ChessPosition('c', 2).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.White), new ChessPosition('d', 2).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.White), new ChessPosition('e', 2).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.White), new ChessPosition('e', 1).ToPosition());
            Gmbd.PutPiece(new Rey(Gmbd, Color.White), new ChessPosition('d', 1).ToPosition());

            Gmbd.PutPiece(new Tower(Gmbd, Color.Black), new ChessPosition('c', 7).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.Black), new ChessPosition('c', 8).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.Black), new ChessPosition('d', 7).ToPosition());
            Gmbd.PutPiece(new Tower(Gmbd, Color.Black), new ChessPosition('e', 7).ToPosition());
            Gmbd.PutPiece(new Rey(Gmbd, Color.Black), new ChessPosition('e', 8).ToPosition());
            Gmbd.PutPiece(new Rey(Gmbd, Color.Black), new ChessPosition('d', 8).ToPosition());
        }

    }
}
