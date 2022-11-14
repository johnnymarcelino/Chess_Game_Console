namespace Game_Board
{
    internal class Position
    {
        public int LinePosition { get; set; }
        public int ColumnPosition { get; set; }

        public Position(int line, int column)
        {
            this.LinePosition = line;
            this.ColumnPosition = column ;
        }

        public void DefineValues(int lines, int column)
        {
            this.LinePosition = lines;
            this.ColumnPosition = column;
        }

        public override string ToString()
        {
            return LinePosition + ", " + ColumnPosition;
        }
    }
}
