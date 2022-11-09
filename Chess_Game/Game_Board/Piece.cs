﻿namespace Game_Board
{
    internal class Piece
    {

        public Position Position { get; set; }
        public Color Color { get; protected set; }  // protected => acessado somente pelas subclasses e por ela própria
        public int QteMovimento { get; protected set; }
        public GameBoard Gmbd { get; protected set; }

        public Piece(GameBoard gmbd, Color color)
        {
            this.Position = null;
            this.Gmbd = gmbd;
            this.Color = color;
            this.QteMovimento = 0;
        }
    }
}
