using Game_Board;

namespace Chess
{
    internal class Pawn : Piece
    {
        private ChessGame Game;

        public Pawn(GameBoard gmbd, Color color, ChessGame game) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
            this.Game = game;
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
                Position p2 = new Position(Position.LinePosition - 1, Position.ColumnPosition);
                if (Gmbd.ValidPositon(p2) && Free(p2) && Gmbd.ValidPositon(pos) && Free(pos) && QtyMove == 0)
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

                // # jogada especial - En Passant
                if (Position.LinePosition == 3)
                {
                    Position esquerda = new Position(Position.LinePosition, Position.ColumnPosition - 1);
                    if (Gmbd.ValidPositon(esquerda) && ExistEnemy(esquerda) && Gmbd.Piece(esquerda) == Game.VulnerableEnPassant)
                    {
                        mat[esquerda.LinePosition - 1, esquerda.ColumnPosition] = true;  // possivel para peão se mover
                    }
                    Position direita = new Position(Position.LinePosition, Position.ColumnPosition + 1);
                    if (Gmbd.ValidPositon(direita) && ExistEnemy(direita) && Gmbd.Piece(direita) == Game.VulnerableEnPassant)
                    {
                        mat[direita.LinePosition - 1, direita.ColumnPosition] = true;  // possivel para peão se mover - evento possivel
                    }
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
                Position p2 = new Position(Position.LinePosition + 1, Position.ColumnPosition);
                if (Gmbd.ValidPositon(p2) && Free(p2) && Gmbd.ValidPositon(pos) && Free(pos) && QtyMove == 0)
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

                // # jogada especial - En Passant
                if (Position.LinePosition == 4)
                {
                    Position esquerda = new Position(Position.LinePosition, Position.ColumnPosition - 1);
                    if (Gmbd.ValidPositon(esquerda) && ExistEnemy(esquerda) && Gmbd.Piece(esquerda) == Game.VulnerableEnPassant)
                    {
                        mat[esquerda.LinePosition + 1, esquerda.ColumnPosition] = true;  // possivel para peão se mover
                    }
                    Position direita = new Position(Position.LinePosition, Position.ColumnPosition + 1);
                    if (Gmbd.ValidPositon(direita) && ExistEnemy(direita) && Gmbd.Piece(direita) == Game.VulnerableEnPassant)
                    {
                        mat[direita.LinePosition + 1, direita.ColumnPosition] = true;  // possivel para peão se mover - evento possivel
                    }
                }
            }
            return mat;
        }
    }
}
