using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    public class Game
    {
/*         private Square[][] _board = 
        {
            new Square[3],
            new Square[3],
            new Square[3]
        }; */
        
        private List<List<Square>> _board = new List<List<Square>>()
        {
            new List<Square>{ new Square(), new Square(), new Square()},
            new List<Square>{ new Square(), new Square(), new Square()},
            new List<Square>{ new Square(), new Square(), new Square()}
        };
        public void PlayGame()
        {
            Player player = Player.Crosses;

            DisplayBoard();
            bool @continue = true;
            while (@continue)
            {
                @continue = PlayMove(player);
                DisplayBoard();
                if (!@continue)
                    return;
                else if (WinCondition(_board, player))
                    return;
                player = 3 - player;
            }
        }
        public void DisplayBoard()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                    Console.Write(" " + _board[i][j]);
                Console.WriteLine();
            }
        }

        public bool WinCondition(List<List<Square>> board, Player player)
        {
            //  first check for vertical wins
            if ((board[0][0].Owner == Player.Crosses && board[1][0].Owner == Player.Crosses && board[2][0].Owner == Player.Crosses
            || board[0][0].Owner == Player.Noughts && board[1][0].Owner == Player.Noughts && board[2][0].Owner == Player.Noughts)
            || (board[0][1].Owner == Player.Crosses && board[1][1].Owner == Player.Crosses && board[2][1].Owner == Player.Crosses
            || board[0][1].Owner == Player.Noughts && board[1][1].Owner == Player.Noughts && board[2][1].Owner == Player.Noughts)
            || (board[0][2].Owner == Player.Crosses && board[1][2].Owner == Player.Crosses && board[2][2].Owner == Player.Crosses
            || board[0][2].Owner == Player.Noughts && board[1][2].Owner == Player.Noughts && board[2][2].Owner == Player.Noughts)
            //  then horizontal
            || (board[0][0].Owner == Player.Crosses && board[0][1].Owner == Player.Crosses && board[0][2].Owner == Player.Crosses
            || board[0][0].Owner == Player.Noughts && board[0][1].Owner == Player.Noughts && board[0][2].Owner == Player.Noughts)
            || (board[1][0].Owner == Player.Crosses && board[1][1].Owner == Player.Crosses && board[1][2].Owner == Player.Crosses
            || board[1][0].Owner == Player.Noughts && board[1][1].Owner == Player.Noughts && board[1][2].Owner == Player.Noughts)
            || (board[2][0].Owner == Player.Crosses && board[2][1].Owner == Player.Crosses && board[2][2].Owner == Player.Crosses
            || board[2][0].Owner == Player.Noughts && board[2][1].Owner == Player.Noughts && board[2][2].Owner == Player.Noughts)
            //  then diagonal
            || (board[0][0].Owner == Player.Crosses && board[1][1].Owner == Player.Crosses && board[2][2].Owner == Player.Crosses
            || board[0][0].Owner == Player.Noughts && board[1][1].Owner == Player.Noughts && board[2][2].Owner == Player.Noughts)
            || (board[2][0].Owner == Player.Crosses && board[1][1].Owner == Player.Crosses && board[0][2].Owner == Player.Crosses
            || board[2][0].Owner == Player.Noughts && board[1][1].Owner == Player.Noughts && board[0][2].Owner == Player.Noughts))
            {
                Console.WriteLine($"{player} has won!");
                return true;
            }
            return false;
        }

        public bool PlayMove(Player player)
        {
            Console.WriteLine("Invalid input quits the game");
            Console.Write($"{player}: Insert Coordinates e.g. 3,3 > ");

        TryAgain:
            string userInput = Console.ReadLine();
            string[] parts;
            parts = userInput.Split(",");
            if (parts.Length != 2)
                return false;

            int.TryParse(parts[0], out int row);
            int.TryParse(parts[1], out int column);

            if (row < 1 || column < 1 || row > 3 || column > 3)
            {
                System.Console.WriteLine("The square is out of range");
                goto TryAgain;
            }

            if (_board[row - 1][column - 1].Owner != Player.None)
            {
                Console.WriteLine("The square was already occupied");
                goto TryAgain;
            } 

            _board[row - 1][column - 1] = new Square(player);
            return true;
        }
    }
}