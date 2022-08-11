using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kamisado
{
    public partial class GUI : Form
    {
        private Graphics g;

        public GUI()
        {
            InitializeComponent();

            g = this.CreateGraphics();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GameController.Instance.StateMachine.GameState.OnPaint(e, g);
            base.OnPaint(e);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            g.Dispose();
            //GameController.Instance.Board.Dispose();

            base.Dispose(disposing);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (GameController.Instance.StateMachine.GameState.OnMouseDown(e))
            {
                InvokePaint(this, null);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (GameController.Instance.StateMachine.GameState.OnMouseUp(e))
            {
                InvokePaint(this, null);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (GameController.Instance.StateMachine.GameState.OnMouseMove(e))
            {
                InvokePaint(this, null);
            }
            base.OnMouseMove(e);
        }
    }
}
