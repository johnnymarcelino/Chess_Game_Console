using Game_Board;

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
    }
}
