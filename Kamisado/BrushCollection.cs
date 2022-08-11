using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kamisado
{
    public class BrushCollection : KeyedCollection<Color, SolidBrush>
    {
        protected override Color GetKeyForItem(SolidBrush brush)
        {
            return brush.Color;
        }
    }
}
