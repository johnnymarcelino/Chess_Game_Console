using Game_Board;

namespace Chess
{
    internal class Pawn : Piece
    {
        public Pawn(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position pos)
        {
            Piece p = Gmbd.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Gmbd.Piece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Gmbd.Lines, Gmbd.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition);
                if (Gmbd.ValidPositon(pos) && Free(pos))
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }

                pos.DefineValues(Position.LinePosition - 2, Position.ColumnPosition);
                if (Gmbd.ValidPositon(pos) && Free(pos) && QtyMove == 0)
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }

                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition - 1);
                if (Gmbd.ValidPositon(pos) && ExistEnemy(pos))
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }

                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition + 1);
                if (Gmbd.ValidPositon(pos) && ExistEnemy(pos))
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition);
                if (Gmbd.ValidPositon(pos) && Free(pos))
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }

                pos.DefineValues(Position.LinePosition + 2, Position.ColumnPosition);
                if (Gmbd.ValidPositon(pos) && Free(pos) && QtyMove == 0)
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }

                pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition - 1);
                if (Gmbd.ValidPositon(pos) && ExistEnemy(pos))
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }

                pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition + 1);
                if (Gmbd.ValidPositon(pos) && ExistEnemy(pos))
                {
                    mat[pos.LinePosition, pos.ColumnPosition] = true;
                }
            }
            return mat;
        }
    }
}
