using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kamisado
{
    public class DrawableCollection : KeyedCollection<Point, Drawable>
    {
        protected override Point GetKeyForItem(Drawable d)
        {
            return d.Position;
        }
    }
}
