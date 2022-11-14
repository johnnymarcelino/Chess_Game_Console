using Game_Board;

namespace Chess
{
    internal class Queen : Piece
    {
        public Queen(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Gmbd.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Gmbd.Lines, Gmbd.Columns];
            Position pos = new Position(0, 0);

            // esquerda
            pos.DefineValues(Position.LinePosition, Position.ColumnPosition - 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition, Position.ColumnPosition - 1);
            }

            // direita
            pos.DefineValues(Position.LinePosition, Position.ColumnPosition + 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition, Position.ColumnPosition + 1);
            }

            // acima
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition);
            }

            // abaixo
            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition);
            }

            // acima
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.LinePosition = pos.LinePosition - 1;  // pos.LinePosition--
            }

            // NO
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition - 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition - 1);
            }

            // NE
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition + 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition + 1);
            }

            // SE
            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition + 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition + 1);
            }

            // SO
            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition - 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition - 1);
            }
            return mat;
        }
    }
}
