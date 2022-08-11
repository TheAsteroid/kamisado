using Kamisado.Engine;
using System.Drawing;

namespace Kamisado.GUI
{
    public abstract class DrawableObject
    {
        protected BoardControl boardControl;
        protected GameController gameController;

        protected Rectangle rect;

        protected System.Drawing.Point
            topLeft,
            topRight,
            bottomLeft,
            bottomRight;

        protected Engine.Point
            position;

        private readonly Size
            size,
            fieldRadius,
            itemRadius;

        private readonly int margin;

        public DrawableObject(BoardControl boardControl, Size size, int margin)
        {
            this.boardControl = boardControl;
            gameController = boardControl.GameController;

            this.size = size;
            fieldRadius = new Size((DrawableField.WIDTH + DrawableField.MARGIN) / 2, (DrawableField.HEIGHT + DrawableField.MARGIN) / 2);
            itemRadius = new Size(size.Width / 2, size.Height / 2);

            this.margin = margin;
        }

        public void SetPosition(Engine.Point position)
        {
            this.position = position;

            System.Drawing.Point center = new System.Drawing.Point(
                position.X * (fieldRadius.Width * 2 + margin) + BoardControl.MARGIN + fieldRadius.Width,
                position.Y * (fieldRadius.Height * 2 + margin) + BoardControl.MARGIN + fieldRadius.Height);
            topLeft = new System.Drawing.Point(
                center.X - itemRadius.Width,
                center.Y - itemRadius.Height);
            topRight = new System.Drawing.Point(
                center.X + itemRadius.Width,
                center.Y - itemRadius.Height);
            bottomLeft = new System.Drawing.Point(
                center.X - itemRadius.Width,
                center.Y + itemRadius.Height);
            bottomRight = new System.Drawing.Point(
                center.X + itemRadius.Width,
                center.Y + itemRadius.Height);

            rect = new Rectangle(this.topLeft, size);
        }

        public abstract void Draw(Graphics g);
    }
}
