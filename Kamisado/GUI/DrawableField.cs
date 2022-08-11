using Kamisado.Engine;
using System.Drawing;

namespace Kamisado.GUI
{
    public class DrawableField : DrawableObject
    {
        public const int
            WIDTH = 56,
            HEIGHT = 56,
            MARGIN = 2;

        public DrawableField(BoardControl boardControl, Field field)
            : base(boardControl, new Size(WIDTH, HEIGHT), MARGIN)
        {
            Field = field;
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(boardControl.CommonBrushes[Field.Color], rect);
            g.DrawLines(boardControl.BorderLightPens[Field.Color], new System.Drawing.Point[] { topLeft, topRight, bottomRight });
            g.DrawLines(boardControl.BorderDarkPens[Field.Color], new System.Drawing.Point[] { topLeft, bottomLeft, bottomRight });
        }

        public Field Field { get; }
    }
}
