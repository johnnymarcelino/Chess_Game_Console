using Game_Board;
using System;

namespace Chess
{
    internal class ChessPosition
    {
        public char BoardColumn { get; set; }
        public int BoardLine { get; set; }

        public ChessPosition(char boardColumn, int boardLine)
        {
            BoardColumn = boardColumn;
            BoardLine = boardLine;
        }

        public Position ToPosition()
        {
            return new Position(8 - BoardLine, BoardColumn - 'a');
        }

        public override string ToString()
        {
            return "" + BoardColumn + BoardLine;
        }
    }
}
