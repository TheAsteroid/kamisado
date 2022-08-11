namespace Kamisado.Engine
{
    public class Board
    {
        public const int
            WIDTH = 8,
            HEIGHT = 8;

        public enum Color
        {
            Orange = 0,
            Blue = 1,
            Purple = 2,
            Pink = 3,
            Yellow = 4,
            Red = 5,
            Green = 6,
            Brown = 7
        };

        private readonly Field[,] fields;

        public Board(Player player = null, Player computer = null)
        {
            fields = new Field[WIDTH, HEIGHT];
            // Create all fields for the board
            for (int y = 0; y < 8; y++)
            {
                int x = y;
                fields[x, y] = new Field(Color.Orange, x, y);
                x = (y * 3 + 1) % 8;
                fields[x, y] = new Field(Color.Blue, x, y);
                x = (5 * y + 2) % 8;
                fields[x, y] = new Field(Color.Purple, x, y);
                x = (11 - y) % 8; ;
                fields[x, y] = new Field(Color.Pink, x, y);
                x = (y + 4) % 8;
                fields[x, y] = new Field(Color.Yellow, x, y);
                x = ((y * 3 + 5) % 8);
                fields[x, y] = new Field(Color.Red, x, y);
                x = (y * 5 + 6) % 8;
                fields[x, y] = new Field(Color.Green, x, y);
                x = 7 - y;
                fields[x, y] = new Field(Color.Brown, x, y);
            }

            if (computer != null && player != null)
            {
                // Set the initial towers for player (row 7) and computer (row 0)
                for (int x = 0; x < 8; x++)
                {
                    new Tower(fields[x, 0].Color, computer, this).MoveTo(new Point(x, 0));
                    new Tower(fields[x, 7].Color, player, this).MoveTo(new Point(x, 7));
                }
            }
        }

        public Field this[Point position]
        {
            get { return fields[position.X, position.Y]; }
            set { fields[position.X, position.Y] = value; }
        }
    }
}
