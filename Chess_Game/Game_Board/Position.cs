
namespace Game_Board
{
    internal class Position
    {
        public int Line;
        public int Column;

        public Position(int line, int column)
        {
            this.Line = line;
            this.Column = column ;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }

    }
}
