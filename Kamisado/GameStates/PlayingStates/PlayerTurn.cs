using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kamisado.GameStates.PlayingStates
{
    public class PlayerTurn : IPlaying
    {
        private Field currentField;
        private Field hoverField;
        private Board board;

        public PlayerTurn(Board board)
        {
            currentField = null;
            hoverField = null;
            this.board = board;
        }

        public void OnPaint(PaintEventArgs e, Graphics g)
        {
            throw new NotImplementedException();
        }

        public void ExitState()
        {
            throw new NotImplementedException();
        }

        public bool OnMouseDown(System.Windows.Forms.MouseEventArgs me)
        {
            currentField = board.Fields.GetField(new Point(me.X, me.Y));
            if (!currentField.HasPlayerPiece(Piece.PlayerEnum.Player))
            {
                currentField = null;
            }
            hoverField = currentField;
            return false;
        }

        public bool OnMouseUp(System.Windows.Forms.MouseEventArgs me)
        {
            if (currentField != null && currentField.HasPlayerPiece(Piece.PlayerEnum.Player))
            {
                Field newField = board.Fields.GetField(new Point(me.X, me.Y));
                if (!newField.HasPiece)
                {
                    newField.TryPushPiece(currentField.PopPiece());
                }
            }
            if (hoverField != null)
            {
                hoverField.ResetColor();
                hoverField = null;
            }
            currentField = null;
            return true;
        }

        public bool OnMouseMove(System.Windows.Forms.MouseEventArgs me)
        {
            if (currentField != null)
            {
                Field currentHoverField = board.Fields.GetField(new Point(me.X, me.Y));
                if (currentHoverField != hoverField)
                {
                    if (hoverField != null)
                    {
                        hoverField.ResetColor();
                    }
                    if (currentHoverField != null)
                    {
                        currentHoverField.SetColor(currentHoverField.BorderColorLight);
                    }
                    hoverField = currentHoverField;
                    return true;
                }
            }
            return false;
        }

        private bool MayPlacePiece(Field hoverField)
        {
            if (currentField != null &&
                    (hoverField.Position.X == currentField.Position.X ||
                    hoverField.Position.Y == currentField.Position.Y))
            {
                return true;
            }
            return false;
        }
    }
}
