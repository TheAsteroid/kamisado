using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kamisado.Engine
{
    public class MessageQueue
    {
        const int LABEL_HEIGHT = 15;
        Panel messageBox;
        Panel moveValuesBox;
        bool showMoveValues;

        public MessageQueue(Panel messageBox, Panel moveValuesBox)
        {
            this.messageBox = messageBox;
            this.moveValuesBox = moveValuesBox;
        }

        public void Queue(string format, params object[] args)
        {
            // Move all messages down, remove if out of range
            foreach (Control c in messageBox.Controls.OfType<Control>().ToList())
            {
                c.Top += LABEL_HEIGHT;
                c.ForeColor = Color.FromArgb(c.ForeColor.A,
                    Math.Min(c.ForeColor.R + 25, messageBox.BackColor.R),
                    Math.Min(c.ForeColor.G + 25, messageBox.BackColor.G),
                    Math.Min(c.ForeColor.B + 25, messageBox.BackColor.B));
                if (c.Top > messageBox.Height - LABEL_HEIGHT)
                {
                    messageBox.Controls.Remove(c);
                }
            }
            // Create new message on top
            Label l = new Label()
            {
                Width = messageBox.Width,
                Text = string.Format(format, args)
            };
            messageBox.Controls.Add(l);
            // Refresh the board
            messageBox.Parent.Refresh();
        }

        public void Clear()
        {
            // Remove all messages
            foreach (Control c in messageBox.Controls.OfType<Control>().ToList())
            {
                messageBox.Controls.Remove(c);
            }
            moveValuesBox.Controls.Clear();
        }

        public void SetMoveValues(string values)
        {
            moveValuesBox.Controls.Clear();
            moveValuesBox.Controls.Add(new Label()
            {
                Width = moveValuesBox.Width,
                Height = moveValuesBox.Height,
                Text = values
            });
        }
    }
}
