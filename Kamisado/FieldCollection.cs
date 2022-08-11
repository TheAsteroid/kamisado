using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kamisado
{
    public class FieldCollection : DrawableCollection
    {
        public Field GetField(Point mouseCoordinates)
        {
            Point coordinates = new Point(
                (mouseCoordinates.X - Board.BoardMargin) / (Field.Size.Width + Field.Margin),
                (mouseCoordinates.Y - Board.BoardMargin) / (Field.Size.Height + Field.Margin));

            if (Contains(coordinates))
            {
                return (Field)this[coordinates];
            }

            return null;
        }
    }
}
