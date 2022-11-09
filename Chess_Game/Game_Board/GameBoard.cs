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
    }
}
