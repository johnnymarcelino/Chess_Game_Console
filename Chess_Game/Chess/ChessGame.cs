using Game_Board;
using Microsoft.Win32.SafeHandles;
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
        public Piece VulnerableEnPassant { get; private set; }

        public ChessGame()
        {
            Gmbd = new GameBoard(8, 8);
            Shift = 1;
            CurrentPlaryer = Color.White;
            Finished = false;
            Check = false;
            VulnerableEnPassant = null;
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

            // # Roque Pequeno
            if (p is Rey && destination.ColumnPosition == origin.ColumnPosition + 2)
            {
                Position originT = new Position(origin.LinePosition, origin.ColumnPosition + 3);
                Position destinationT = new Position(origin.LinePosition, origin.ColumnPosition + 1);
                Piece t = Gmbd.WithdrawPiece(originT);
                t.IncludeQtyMove();  // Agora tem quantidade de movimentos
                Gmbd.PutPiece(t, destinationT);
            }

            // # Roque Grande
            if (p is Rey && destination.ColumnPosition == origin.ColumnPosition - 2)
            {
                Position originT = new Position(origin.LinePosition, origin.ColumnPosition - 4);
                Position destinationT = new Position(origin.LinePosition, origin.ColumnPosition - 1);
                Piece t = Gmbd.WithdrawPiece(originT);
                t.IncludeQtyMove();  // Agora tem quantidade de movimentos
                Gmbd.PutPiece(t, destinationT);
            }

            // # jogada especial - En Passant
            if (p is Pawn)
            {
                if (origin.ColumnPosition != destination.ColumnPosition && capturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destination.LinePosition + 1, destination.ColumnPosition);
                    }
                    else
                    {
                        posP = new Position(destination.LinePosition - 1, destination.ColumnPosition);
                    }
                    capturedPiece = Gmbd.WithdrawPiece(posP);
                    captured.Add(capturedPiece);
                }
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

            // # Roque Pequeno
            if (piece is Rey && destination.ColumnPosition == origin.ColumnPosition + 2)  // se andou duas casas para esquerda
            {
                Position originT = new Position(origin.LinePosition, destination.ColumnPosition + 3);
                Position destinationT = new Position(origin.LinePosition, destination.ColumnPosition + 1);
                Piece t = Gmbd.WithdrawPiece(destinationT);  // retira o rei do <destinoT>
                t.IncludeQtyMove();  // Agora tem quantidade de movimentos
                Gmbd.PutPiece(t, originT);
            }

            // # Roque Grande
            if (piece is Rey && destination.ColumnPosition == origin.ColumnPosition - 2)  // se andou duas casas para esquerda
            {
                Position originT = new Position(origin.LinePosition, destination.ColumnPosition - 4);
                Position destinationT = new Position(origin.LinePosition, destination.ColumnPosition - 1);
                Piece t = Gmbd.WithdrawPiece(destinationT);  // retira o rei do <destinoT>
                t.IncludeQtyMove();  // Agora tem quantidade de movimentos
                Gmbd.PutPiece(t, originT);
            }

            // # jogada especial - En Passant
            if (piece is Pawn)
            {
                if (origin.ColumnPosition != destination.ColumnPosition && capturedPiece == VulnerableEnPassant)
                {
                    Piece pawn = Gmbd.WithdrawPiece(destination);
                    Position posP;
                    if (piece.Color == Color.White)
                    {
                        posP = new Position(3, destination.ColumnPosition);
                    }
                    else
                    {
                        posP = new Position(4, destination.ColumnPosition);
                    }
                    Gmbd.PutPiece(pawn, posP);
                }
            }

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

            if (TestCheckmate(Opponent(CurrentPlaryer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }

            Piece p = Gmbd.Piece(destination);

            // # jogada especial - En Passant
            if (p is Pawn && (destination.LinePosition == origin.LinePosition - 2 || destination.LinePosition == origin.LinePosition + 2))
            {
                VulnerableEnPassant = p;
            }
            else
            {
                VulnerableEnPassant = null;
            }


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
            if (!Gmbd.Piece(origin).PossibleMove(destination))
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
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is Rey)
                {
                    return x;
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

        public bool TestCheckmate(Color color)  // rei de uma determinada cor está em checkmate
        {
            if(!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < Gmbd.Lines; i++)
                {
                    for(int j = 0; j < Gmbd.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origen = x.Position;
                            Position destiation = new Position(i, j);
                            Piece capturedPiece = MoveOut(origen, destiation);
                            bool testCheck = IsInCheck(color);
                            UndoMove(origen, destiation, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Gmbd.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('a', 1, new Tower(Gmbd, Color.White));
            PutNewPiece('b', 1, new Horse(Gmbd, Color.White));
            PutNewPiece('c', 1, new Bishop(Gmbd, Color.White));
            PutNewPiece('d', 1, new Queen(Gmbd, Color.White));
            PutNewPiece('e', 1, new Rey(Gmbd, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Gmbd, Color.White));
            PutNewPiece('g', 1, new Horse(Gmbd, Color.White));
            PutNewPiece('h', 1, new Tower(Gmbd, Color.White));
            PutNewPiece('a', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Gmbd, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Gmbd, Color.White, this));

            PutNewPiece('a', 8, new Tower(Gmbd, Color.Black));
            PutNewPiece('b', 8, new Horse(Gmbd, Color.Black));
            PutNewPiece('c', 8, new Bishop(Gmbd, Color.Black));
            PutNewPiece('d', 8, new Queen(Gmbd, Color.Black));
            PutNewPiece('e', 8, new Rey(Gmbd, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Gmbd, Color.Black));
            PutNewPiece('g', 8, new Horse(Gmbd, Color.Black));
            PutNewPiece('h', 8, new Tower(Gmbd, Color.Black));
            PutNewPiece('a', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Gmbd, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Gmbd, Color.Black, this));
        }
    }
}
