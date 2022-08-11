using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kamisado
{
    public class Field : Drawable
    {
        private Piece piece;
        private Color originalColor;

        public Field(Color color, Point position) : 
            base(color, position, Size, Margin)
        {
            piece = null;
            originalColor = color;
        }

        public Color OriginalColor
        {
            get { return originalColor; }
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void ResetColor()
        {
            this.color = originalColor;
        }

        public bool HasPiece
        {
            get { return piece != null; }
        }

        public bool HasPlayerPiece(Piece.PlayerEnum player)
        {
            return piece != null && piece.Player == player;
        }

        public Piece PeekPiece()
        {
            return piece;
        }

        public Piece PopPiece()
        {
            Piece popped = this.piece;
            this.piece = null;
            return popped;
        }

        public bool TryPushPiece(Piece piece)
        {
            if (this.piece == null)
            {
                this.piece = piece;
                this.piece.Move(this.position);
                return true;
            }
            return false;
        }

        public static int BorderWidth
        {
            get { return 5; }
        }
        public static Size Size
        {
            get { return new Size(70, 70); }
        }
        public static int Margin
        {
            get { return 5; }
        }
    }
}
