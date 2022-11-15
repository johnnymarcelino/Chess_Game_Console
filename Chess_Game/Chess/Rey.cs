using Game_Board;

namespace Chess
{
    internal class Rey : Piece
    {
        private ChessGame Game;

                                                                // construtor base da classe Piece
        public Rey(GameBoard gmbd, Color color, ChessGame game) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
            this.Game = game;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Gmbd.Piece(pos);
            return p == null || p.Color != Color;
        }

        private bool TestTowerToRock(Position pos)
        {
            Piece piece = Gmbd.Piece(pos);
            return piece != null && piece is Tower && piece.Color == Color && piece.QtyMove == 0;  // se peça nesta posição é uma torre para roque
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Gmbd.Lines, Gmbd.Columns];
            Position pos = new Position(0, 0);

            // acima
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // ne
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition + 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // direita
            pos.DefineValues(Position.LinePosition, Position.ColumnPosition + 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // se
            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition + 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // abaixo
            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // so
            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition - 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // esquerda
            pos.DefineValues(Position.LinePosition, Position.ColumnPosition - 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // no
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition - 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            // # Jogada especial - Roque Pequeno
            if (QtyMove == 0 && !Game.Check) 
            {
                // # roque pequeno
                Position posT1 = new Position(Position.LinePosition, Position.ColumnPosition + 3);
                if (TestTowerToRock(posT1))
                {
                    Position p1 = new Position(Position.LinePosition, Position.ColumnPosition + 1);
                    Position p2 = new Position(Position.LinePosition, Position.ColumnPosition + 2);
                    if (Gmbd.Piece(p1) == null && Gmbd.Piece(p2) == null)
                    {
                        mat[Position.LinePosition, Position.ColumnPosition + 2] = true;
                    }
                }

                // # roque grande
                Position posT2 = new Position(Position.LinePosition, Position.ColumnPosition - 4);
                if (TestTowerToRock(posT2))
                {
                    Position p1 = new Position(Position.LinePosition, Position.ColumnPosition - 1);
                    Position p2 = new Position(Position.LinePosition, Position.ColumnPosition - 2);
                    Position p3 = new Position(Position.LinePosition, Position.ColumnPosition - 3);
                    if (Gmbd.Piece(p1) == null && Gmbd.Piece(p2) == null && Gmbd.Piece(p3) == null)
                    {
                        mat[Position.LinePosition, Position.ColumnPosition - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
