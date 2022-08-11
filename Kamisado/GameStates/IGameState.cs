using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kamisado.GameStates
{
    public interface IGameState
    {
        void OnPaint(PaintEventArgs e, Graphics g);
        void ExitState();
        bool OnMouseDown(MouseEventArgs me);
        bool OnMouseUp(MouseEventArgs me);
        bool OnMouseMove(MouseEventArgs me);
    }
}
