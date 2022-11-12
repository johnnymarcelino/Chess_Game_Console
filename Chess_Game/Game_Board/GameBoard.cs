namespace Game_Board
{
    internal class GameBoard
    {

        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;  // privativa, somente tabuleiro controla


        public GameBoard(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position pos)
        {
            return Pieces[pos.LinePosition, pos.ColumnPosition];
        }

        public bool ExitPiece(Position pos)
        {
            PositionValidation(pos);
            return Piece(pos) != null;
        }


        public void PutPiece(Piece p, Position pos)
        {
            if (ExitPiece(pos))
            {
                throw new GameBoardException("There is already a piece in this position!");
            }
            Pieces[pos.LinePosition, pos.ColumnPosition] = p;
            p.Position = pos;
        }

        public Piece WithdrawPiece(Position pos)
        {
            if (Piece(pos) == null)
            {
                return null;
            }
            Piece aux = Piece(pos);
            aux.Position = null;
            Pieces[pos.LinePosition, pos.ColumnPosition] = null;
            return aux;
        }

        public bool ValidPositon(Position pos)
        {
            if(pos.LinePosition < 0 || pos.LinePosition >= Lines || pos.ColumnPosition < 0 || pos.ColumnPosition >= Columns)
            {
                return false;
            }
            return true;
        }

        public void PositionValidation(Position pos)
        {
            if (!ValidPositon(pos))
            {
                throw new GameBoardException("Invalid Position");
            }
        }

    }
}
