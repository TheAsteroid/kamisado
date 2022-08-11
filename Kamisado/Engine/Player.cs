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

        private readonly PlayerType type;
        private readonly PlayerColor color;
        private readonly Dictionary<Board.Color, Tower> towers;
        private readonly int playDirection;

        public Player(PlayerType playerType, PlayerColor playerColor)
        {
            type = playerType;
            color = playerColor;
            playDirection = type == PlayerType.Computer ? 1 : -1;
            towers = new Dictionary<Board.Color, Tower>();
        }

        public PlayerType Type => type;

        public PlayerColor Color => color;

        public Dictionary<Board.Color, Tower> Towers => towers;

        public int PlayDirection => playDirection;
    }
}
