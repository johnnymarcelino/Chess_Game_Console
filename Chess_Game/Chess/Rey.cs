using Game_Board;

namespace Chess
{
    internal class Rey : Piece
    {
        public Rey(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
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
            return mat;
        }
    }
}
