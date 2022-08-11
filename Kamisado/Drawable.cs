using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kamisado
{
    public class Drawable
    {
        protected Color
            color,
            borderColorLight,
            borderColorDark;

        protected Rectangle rect;

        protected Point
            position,
            topLeft,
            topRight,
            bottomLeft,
            bottomRight;

        private Size 
            size,
            fieldRadius,
            itemRadius;

        private int margin;

        public Drawable(Color color, Point position, Size size, int margin)
        {
            this.color = color;

            this.borderColorLight = Color.FromArgb(
                Math.Min(color.R + 40, 255),
                Math.Min(color.G + 40, 255),
                Math.Min(color.B + 40, 255));
            this.borderColorDark = Color.FromArgb(
                Math.Max(color.R - 40, 0),
                Math.Max(color.G - 40, 0),
                Math.Max(color.B - 40, 0));

            this.size = size;
            fieldRadius = new Size((Field.Size.Width + Field.Margin) / 2, (Field.Size.Height + Field.Margin) / 2);
            itemRadius = new Size(size.Width / 2, size.Height / 2);

            this.margin = margin;

            SetPosition(position);
        }

        protected void SetPosition(Point position)
        {
            this.position = position;
            
            Point center = new Point(
                position.X * (Field.Size.Width + margin) + Board.BoardMargin + fieldRadius.Width,
                position.Y * (Field.Size.Height + margin) + Board.BoardMargin + fieldRadius.Height);
            this.topLeft = new Point(
                center.X - itemRadius.Width,
                center.Y - itemRadius.Height);
            this.topRight = new Point(
                center.X + itemRadius.Width,
                center.Y - itemRadius.Height);
            this.bottomLeft = new Point(
                center.X - itemRadius.Width,
                center.Y + itemRadius.Height);
            this.bottomRight = new Point(
                center.X + itemRadius.Width,
                center.Y + itemRadius.Height);

            this.rect = new Rectangle(this.topLeft, size);
        }

        public Color Color
        {
            get { return color; }
        }
        public Color BorderColorLight
        {
            get { return borderColorLight; }
        }
        public Color BorderColorDark
        {
            get { return borderColorDark; }
        }

        public Rectangle Rect
        {
            get { return rect; }
        }

        public Point Position
        {
            get { return position; }
        }
        public Point TopLeft
        {
            get { return topLeft; }
        }
        public Point TopRight
        {
            get { return topRight; }
        }
        public Point BottomLeft
        {
            get { return bottomLeft; }
        }
        public Point BottomRight
        {
            get { return bottomRight; }
        }

        public int Margin
        {
            get { return margin; }
        }
        public Size Size
        {
            get { return size; }
        }
    }
}
