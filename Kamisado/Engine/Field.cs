namespace Kamisado.Engine
{
    public class Field
    {
        public Field(Board.Color color, int x, int y)
        {
            Color = color;
            Tower = null;
            X = x;
            Y = y;
        }

        public Tower Tower { get; set; }

        public int X { get; }

        public int Y { get; }

        public Board.Color Color { get; }
    }
}
