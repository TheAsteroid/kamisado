using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kamisado
{
    public class Board
    {
        private FieldCollection fields;
        private BrushCollection brushes;
        private PenCollection pens;

        public Board()
        {
            InitializeBoard();
        }

        public FieldCollection Fields
        {
            get { return fields; }
        }
        public BrushCollection Brushes
        {
            get { return brushes; }
        }
        public PenCollection Pens
        {
            get { return pens; }
        }

        private void InitializeBoard()
        {
            InitializeFields();
            InitializeBrushesAndPens();
            InitializePieces();
        }

        private void InitializeFields()
        {
            fields = new FieldCollection();
            for (int i = 0; i < 8; i++)
            {
                fields.Add(new Field(Color.FromArgb(215, 116, 33), new Point(i, i)));                   // Orange
                fields.Add(new Field(Color.FromArgb(0, 107, 173), new Point((i * 3 + 1) % 8, i)));      // Blue
                fields.Add(new Field(Color.FromArgb(109, 54, 136), new Point((5 * i + 2) % 8, i)));     // Purple
                fields.Add(new Field(Color.FromArgb(212, 113, 159), new Point((11 - i) % 8, i)));       // Pink
                fields.Add(new Field(Color.FromArgb(227, 195, 4), new Point((i + 4) % 8, i)));          // Yellow
                fields.Add(new Field(Color.FromArgb(209, 49, 58), new Point(((i * 3 + 5) % 8), i)));    // Red
                fields.Add(new Field(Color.FromArgb(0, 145, 87), new Point((i * 5 + 6) % 8, i)));       // Green
                fields.Add(new Field(Color.FromArgb(87, 38, 0), new Point(7 - i, i)));                  // Brown
            }
        }

        private void InitializeBrushesAndPens()
        {
            brushes = new BrushCollection();
            pens = new PenCollection();
            foreach (IGrouping<Color, Drawable> grouped in fields.GroupBy(field => field.Color))
            {
                Field f = (Field)grouped.First();
                brushes.Add(new SolidBrush(f.Color));
                brushes.Add(new SolidBrush(f.BorderColorLight));
                brushes.Add(new SolidBrush(f.BorderColorDark));
                pens.Add(new Pen(f.Color, Field.BorderWidth));
                pens.Add(new Pen(f.BorderColorDark, Field.BorderWidth));
                pens.Add(new Pen(f.BorderColorLight, Field.BorderWidth));
            }
            brushes.Add(new SolidBrush(Color.Gold));
            brushes.Add(new SolidBrush(Color.Black));
            pens.Add(new Pen(Color.Gold, Field.BorderWidth));
            pens.Add(new Pen(Color.Black, Field.BorderWidth));
        }

        private void InitializePieces()
        {
            for (int i = 0; i < 8; i++)
            {
                Point computerLocation = new Point(i, 0);
                ((Field)fields[computerLocation]).TryPushPiece(
                    new Piece(fields[computerLocation].Color, computerLocation, Piece.PlayerEnum.Computer));
                
                Point playerLocation = new Point(i, 7);
                ((Field)fields[playerLocation]).TryPushPiece(
                    new Piece(fields[playerLocation].Color, playerLocation, Piece.PlayerEnum.Player));
            }
        }

        public void Dispose()
        {
            foreach (SolidBrush b in brushes)
            {
                b.Dispose();  
            }
            foreach (Pen p in pens)
            {
                p.Dispose();
            }
            brushes = null;
            fields = null;
        }

        public static int BoardMargin { get { return 10; } }
    }
}
