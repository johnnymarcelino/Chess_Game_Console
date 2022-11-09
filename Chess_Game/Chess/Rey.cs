using Game_Board;

namespace Chess
{
    internal class Rey : Piece
    {
        public Rey(GameBoard gmbd, Color color) : base(gmbd, color)  // repassa os valores a classe peças - pieces
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
