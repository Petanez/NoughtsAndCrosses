using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    public enum Player {None = 0, Noughts, Crosses}
    public struct Square
    {
        public Player Owner { get; }
        public Square(Player owner)
        {
            this.Owner = owner;
        }
        public override string ToString()
        {
            switch(Owner)
            {
                case Player.None:
                    return ".";
                case Player.Crosses:
                    return "X";
                case Player.Noughts:
                    return "O";
                default:
                    throw new Exception("invalid state");
            }
        }
        
    }
}