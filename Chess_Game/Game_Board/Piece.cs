namespace Game_Board
{
    internal class Piece
    {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qteMovimento { get; protected set; }
        public GameBoard gmbd { get; protected set; }

        public Piece(Position position, GameBoard gmbd, Color color)
        {
            this.position = position;
            this.gmbd = gmbd;
            this.color = color;
            this.qteMovimento = 0;
        }
    }
}
