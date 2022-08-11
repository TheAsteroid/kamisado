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

        Size
            size,
            fieldRadius,
            itemRadius;

        int margin;

        public DrawableObject(BoardControl boardControl, Size size, int margin)
        {
            this.boardControl = boardControl;
            this.gameController = boardControl.GameController;

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
            this.topLeft = new System.Drawing.Point(
                center.X - itemRadius.Width,
                center.Y - itemRadius.Height);
            this.topRight = new System.Drawing.Point(
                center.X + itemRadius.Width,
                center.Y - itemRadius.Height);
            this.bottomLeft = new System.Drawing.Point(
                center.X - itemRadius.Width,
                center.Y + itemRadius.Height);
            this.bottomRight = new System.Drawing.Point(
                center.X + itemRadius.Width,
                center.Y + itemRadius.Height);

            this.rect = new Rectangle(this.topLeft, size);
        }

        public abstract void Draw(Graphics g);
    }
}
