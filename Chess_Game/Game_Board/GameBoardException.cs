using System;

namespace Game_Board
{
    internal class GameBoardException : Exception
    {

        // Construtor da classe, repassando o valor como base
        public GameBoardException(string msg) : base(msg)
        {
        }

    }
}
