using System;

namespace Kamisado.Engine
{
    public class Tower
    {
        private readonly Board board;

        public Tower(Board.Color color, Player player, Board board)
        {
            Color = color;
            Player = player;
            this.board = board;
            Position = new Point(-1, -1);
            player.Towers.Add(color, this);
        }

        public Point Position
        {
            get;
            private set;
        }

        public Player Player { get; }

        public Board.Color Color { get; }

        /// <summary>
        /// The number of Sumo's on this piece. Use AddSumo to increase this number.
        /// </summary>
        public int SumoCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Add a Sumo to this tower
        /// </summary>
        public void AddSumo()
        {
            if (SumoCount == 3)
            {
                throw new Exception("Max SumoCount reached");
            }
            SumoCount++;
        }

        public void MoveTo(Point newPosition)
        {
            // Move to field
            board[newPosition].Tower = this;
            if (Position.X >= 0 && Position.Y >= 0)
            {
                // Set current field to null
                board[Position].Tower = null;
            }
            // Set correct coordinates
            Position = newPosition;
        }
    }
}
