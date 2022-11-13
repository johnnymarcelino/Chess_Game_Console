using Game_Board;
using System;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace Chess
{
    internal class ChessGame
    {

        public GameBoard Gmbd { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlaryer { get; private set; }
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

        public void MakePlay(Position origin, Position destination)
        {
            MoveOut(origin, destination);
            Shift++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Gmbd.Piece(pos) == null)
            {
                throw new GameBoardException("There is not any piece in the origin position chose");
            }
            if (CurrentPlaryer != Gmbd.Piece(pos).Color)
            {
                throw new GameBoardException("Origin piece chose ins't yours!");
            }
            if (!Gmbd.Piece(pos).ExistPossibleMoves())
            {
                throw new GameBoardException("There is not possible moves to the choice of origin piece");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Gmbd.Piece(origin).CanMoveTo(destination))
            {
                throw new GameBoardException("Invalid destination position");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlaryer == Color.White)
            {
                CurrentPlaryer = Color.Black;
            }
            else
            {
                CurrentPlaryer = Color.White;
            }
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
