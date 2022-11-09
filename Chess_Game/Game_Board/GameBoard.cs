namespace Game_Board
{
    internal class GameBoard
    {

        public int lines { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces;  // privativa, somente tabuleiro controla


        public GameBoard(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }


    }
}
