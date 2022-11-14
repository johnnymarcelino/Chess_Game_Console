using Game_Board;

namespace Chess
{
    internal class Horse : Piece
    {
        public Horse(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
        }

        public override string ToString()
        {
            return "H";
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

            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition - 2);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            pos.DefineValues(Position.LinePosition - 2, Position.ColumnPosition - 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            pos.DefineValues(Position.LinePosition - 2, Position.ColumnPosition + 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition + 2);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            pos.DefineValues(Position.LinePosition + 2, Position.ColumnPosition + 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            pos.DefineValues(Position.LinePosition + 2, Position.ColumnPosition - 1);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }

            pos.DefineValues(Position.LinePosition + 1, Position.ColumnPosition - 2);
            if (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
            }
            return mat;
        }
    }
}
