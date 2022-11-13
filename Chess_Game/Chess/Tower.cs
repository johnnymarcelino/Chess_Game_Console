using Game_Board;
using System.IO;

namespace Chess
{
    internal class Tower : Piece
    {
        public Tower(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe da peças - pieces
        {
        }
        public override string ToString()
        {
            return "T";
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
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.LinePosition = pos.LinePosition - 1;  // pos.LinePosition--
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
                pos.LinePosition = pos.LinePosition + 1;  // pos.LinePosition++
            }

            // dereita
            pos.DefineValues(Position.LinePosition, Position.ColumnPosition + 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.ColumnPosition = pos.ColumnPosition + 1;  // pos.LinePosition++
            }

            // esquerda
            pos.DefineValues(Position.LinePosition, Position.ColumnPosition - 1);
            while (Gmbd.ValidPositon(pos) && CanMove(pos))
            {
                mat[pos.LinePosition, pos.ColumnPosition] = true;
                if (Gmbd.Piece(pos) != null && Gmbd.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.ColumnPosition = pos.ColumnPosition - 1;  // pos.LinePosition--
            }

            return mat;
        }
    }
}
