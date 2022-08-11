using System.Collections.Generic;

namespace Kamisado.Engine
{
    public class Player
    {
        public enum PlayerType
        {
            Player,
            Computer
        };

        public enum PlayerColor
        {
            Gold,
            Black
        }

        PlayerType type;
        PlayerColor color;
        Dictionary<Board.Color, Tower> towers;
        int playDirection;

        public Player(PlayerType playerType, PlayerColor playerColor)
        {
            this.type = playerType;
            this.color = playerColor;
            playDirection = type == PlayerType.Computer ? 1 : -1;
            towers = new Dictionary<Board.Color, Tower>();
        }

        public PlayerType Type
        {
            get { return type; }
        }

        public PlayerColor Color
        {
            get { return color; }
        }

        public Dictionary<Board.Color, Tower> Towers
        {
            get { return towers; }
        }

        public int PlayDirection
        {
            get { return playDirection; }
        }
    }
}
