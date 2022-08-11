using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kamisado.GameStates
{
    public class Initializing : IGameState
    {
        public void OnPaint(PaintEventArgs e, Graphics g)
        {
            
        }

        public void ExitState()
        {
            
        }

        public bool OnMouseDown(System.Windows.Forms.MouseEventArgs me)
        {
            return false;
        }

        public bool OnMouseUp(System.Windows.Forms.MouseEventArgs me)
        {
            GameController.Instance.StateMachine.ChangeGameState(typeof(Playing));
            return true;
        }

        public bool OnMouseMove(System.Windows.Forms.MouseEventArgs me)
        {
            return false;
        }
    }
}
