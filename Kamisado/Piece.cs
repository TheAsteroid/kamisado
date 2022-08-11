using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kamisado
{
    public class Piece : Drawable
    {
        public enum PlayerEnum
        {
            Computer,
            Player
        };

        private PlayerEnum player;
        private Color playerColor;

        public Piece(Color color, Point position, PlayerEnum player)
            : base(color, position, Size, Margin)
        {
            this.player = player;
            switch (player)
            {
                case PlayerEnum.Player:
                    playerColor = Color.Black;
                    break;
                case PlayerEnum.Computer:
                    playerColor = Color.Gold;
                    break;
            }
        }

        public PlayerEnum Player
        {
            get { return player; }
        }

        public Color PlayerColor
        {
            get { return playerColor; }
        }

        public void Move(Point toPosition)
        {
            SetPosition(toPosition);
        }

        public static Size Size
        {
            get { return new Size(50, 50); }
        }
        public static int Margin
        {
            get { return 5; }
        }
    }
}
