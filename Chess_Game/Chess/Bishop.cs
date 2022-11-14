using Game_Board;
using System.IO;

namespace Chess
{
    internal class Bishop : Piece
    {
        public Bishop(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
        }

        public override string ToString()
        {
            return "B";
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

            // NO
            pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition -1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(Position.LinePosition - 1, Position.ColumnPosition -1);
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
