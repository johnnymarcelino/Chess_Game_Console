namespace Game_Board
{
    abstract class Piece
    {

        public Position Position { get; set; }
        public Color Color { get; protected set; }  // protected => acessado somente pelas subclasses e por ela própria
        public int QtyMove { get; protected set; }
        public GameBoard Gmbd { get; protected set; }

        public Piece(GameBoard gmbd, Color color)
        {
            this.Position = null;
            this.Gmbd = gmbd;
            this.Color = color;
            this.QtyMove = 0;
        }

        public abstract bool[,] PossibleMoves();

        public bool ExistPossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Gmbd.Lines; i++)
            {
                for (int j = 0; j < Gmbd.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.LinePosition, pos.ColumnPosition];
        }


        public void IncludeQtyMove()
        {
            QtyMove++;
        }
    }
}
