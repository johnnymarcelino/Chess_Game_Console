using Game_Board;
using System.Collections.Generic;
using System.Reflection;

namespace Chess
{
    internal class ChessGame
    {

        public GameBoard Gmbd { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlaryer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;  // = new HashSet<Piece>();
        private HashSet<Piece> captured;  // = new HashSet<Piece>();
        public bool Check { get; private set; }

        public ChessGame()
        {
            Gmbd = new GameBoard(8, 8);
            Shift = 1;
            CurrentPlaryer = Color.White;
            Finished = false;
            Check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece MoveOut(Position origin, Position destination)
        {
            Piece p = Gmbd.WithdrawPiece(origin);
            p.IncludeQtyMove();
            Piece capturedPiece = Gmbd.WithdrawPiece(destination);
            Gmbd.PutPiece(p, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Gmbd.WithdrawPiece(destination);
            piece.DecreaseQtyMove();
            if (capturedPiece != null)
            {
                Gmbd.PutPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            Gmbd.PutPiece(piece, origin);
        }

        public void MakePlay(Position origin, Position destination)
        {
            Piece capturedPiece = MoveOut(origin, destination);
            if (IsInCheck(CurrentPlaryer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new GameBoardException("You can't put yourself in check!");
            }

            if (IsInCheck(Opponent(CurrentPlaryer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece eachPiece in captured)
            {
                if (eachPiece.Color == color)
                {
                    aux.Add(eachPiece);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece eachPiece in pieces)
            {
                if (eachPiece.Color == color)
                {
                    aux.Add(eachPiece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));  // ExceptWith -> retorna todas as peças, exceto a peça capturada
            return aux;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece Rey(Color color)
        {
            foreach (Piece pieceX in PiecesInGame(color))
            {
                if (pieceX is Rey)
                {
                    return pieceX;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece r = Rey(color);
            if (r == null)
            {
                throw new GameBoardException("There is not a Rey in the color " + color + " on the gameboard");
            }

            foreach (Piece piece in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if (mat[r.Position.LinePosition, r.Position.ColumnPosition])
                {
                    return true;
                }
            }
            return false;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Gmbd.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Gmbd, Color.White));
            PutNewPiece('c', 2, new Tower(Gmbd, Color.White));
            PutNewPiece('d', 2, new Tower(Gmbd, Color.White));
            PutNewPiece('e', 2, new Tower(Gmbd, Color.White));
            PutNewPiece('e', 1, new Tower(Gmbd, Color.White));
            PutNewPiece('d', 1, new Rey(Gmbd, Color.White));

            PutNewPiece('c', 7, new Tower(Gmbd, Color.Black));
            PutNewPiece('c', 8, new Tower(Gmbd, Color.Black));
            PutNewPiece('d', 7, new Tower(Gmbd, Color.Black));
            PutNewPiece('e', 7, new Tower(Gmbd, Color.Black));
            PutNewPiece('e', 8, new Rey(Gmbd, Color.Black));
            PutNewPiece('d', 8, new Rey(Gmbd, Color.Black));
        }
    }
}
