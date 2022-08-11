using Kamisado.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kamisado.GUI
{
    public partial class BoardControl : UserControl
    {
        public const int
            BORDER_WIDTH = 5,
            MARGIN = 5;

        Bitmap backBuffer;
        GameController gameController;
        DrawableField[,] fields;
        List<DrawableTower> towers;
        Board board;

        Dictionary<Board.Color, Pen>
            commonPens,
            borderLightPens,
            borderDarkPens;

        Dictionary<Board.Color, Brush>
            commonBrushes,
            borderLightBrushes,
            borderDarkBrushes;

        Dictionary<Player.PlayerColor, Pen>
            playerPens;

        public BoardControl()
        {
            InitializeComponent();

            this.SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);
        }

        public DrawableField this[Engine.Point position]
        {
            get { return fields[position.X, position.Y]; }
            private set { fields[position.X, position.Y] = value; }
        }

        public GameController GameController
        {
            get { return gameController; }
            set { gameController = value; }
        }

        #region Style properties
        public Dictionary<Board.Color, Pen> CommonPens
        {
            get { return commonPens; }
        }

        public Dictionary<Board.Color, Pen> BorderLightPens
        {
            get { return borderLightPens; }
        }

        public Dictionary<Board.Color, Pen> BorderDarkPens
        {
            get { return borderDarkPens; }
        }

        public Dictionary<Board.Color, Brush> CommonBrushes
        {
            get { return commonBrushes; }
        }

        public Dictionary<Board.Color, Brush> BorderLightBrushes
        {
            get { return borderLightBrushes; }
        }

        public Dictionary<Board.Color, Brush> BorderDarkBrushes
        {
            get { return borderDarkBrushes; }
        }

        public Dictionary<Player.PlayerColor, Pen> PlayerPens
        {
            get { return playerPens; }
        }
        #endregion

        public void InitializeBoard()
        {
            backBuffer = null;

            InitializePens();

            fields = new DrawableField[Board.WIDTH, Board.HEIGHT];
            towers = new List<DrawableTower>();
            board = gameController.Board;
            for (int x = 0; x < Board.WIDTH; x++)
            {
                for (int y = 0; y < Board.HEIGHT; y++)
                {
                    Engine.Point p = new Engine.Point(x, y);
                    this[p] = new DrawableField(this, board[p]);
                    this[p].SetPosition(p);
                    if (board[p].Tower != null)
                    {
                        towers.Add(new DrawableTower(this, board[p].Tower));
                        towers[towers.Count - 1].SetPosition(p);
                    }
                }
            }
            Refresh();
        }

        private void InitializePens()
        {
            commonPens = new Dictionary<Board.Color, Pen>()
            {
                { Board.Color.Orange,   new Pen(Color.FromArgb(215, 116, 33),    BORDER_WIDTH) },
                { Board.Color.Blue,     new Pen(Color.FromArgb(0, 107, 173),     BORDER_WIDTH) },
                { Board.Color.Purple,   new Pen(Color.FromArgb(109, 54, 136),    BORDER_WIDTH) },
                { Board.Color.Pink,     new Pen(Color.FromArgb(212, 113, 159),   BORDER_WIDTH) },
                { Board.Color.Yellow,   new Pen(Color.FromArgb(227, 195, 4),     BORDER_WIDTH) },
                { Board.Color. Red,     new Pen(Color.FromArgb(209, 49, 58),     BORDER_WIDTH) },
                { Board.Color.Green,    new Pen(Color.FromArgb(0, 145, 87),      BORDER_WIDTH) },
                { Board.Color.Brown,    new Pen(Color.FromArgb(87, 38, 0),       BORDER_WIDTH) }
            };

            borderLightPens = new Dictionary<Board.Color, Pen>();
            borderDarkPens = new Dictionary<Board.Color, Pen>();
            commonBrushes = new Dictionary<Board.Color, Brush>();
            borderLightBrushes = new Dictionary<Board.Color, Brush>();
            borderDarkBrushes = new Dictionary<Board.Color, Brush>();

            foreach (KeyValuePair<Board.Color, Pen> pair in commonPens)
            {
                Color colorLight = Color.FromArgb(
                    Math.Min(pair.Value.Color.R + 40, 255),
                    Math.Min(pair.Value.Color.G + 40, 255),
                    Math.Min(pair.Value.Color.B + 40, 255));
                Color colorDark = Color.FromArgb(
                    Math.Max(pair.Value.Color.R - 40, 0),
                    Math.Max(pair.Value.Color.G - 40, 0),
                    Math.Max(pair.Value.Color.B - 40, 0));

                borderLightPens.Add(pair.Key, new Pen(colorLight, BORDER_WIDTH));
                borderDarkPens.Add(pair.Key, new Pen(colorDark, BORDER_WIDTH));
                commonBrushes.Add(pair.Key, new SolidBrush(pair.Value.Color));
                borderLightBrushes.Add(pair.Key, new SolidBrush(colorLight));
                borderDarkBrushes.Add(pair.Key, new SolidBrush(colorDark));
            }

            playerPens = new Dictionary<Player.PlayerColor, Pen>()
            {
                { Player.PlayerColor.Black, new Pen(Color.Black, BORDER_WIDTH) },
                { Player.PlayerColor.Gold,  new Pen(Color.Gold, BORDER_WIDTH) }
            };
        }

        #region Event handlers
        protected override void OnPaint(PaintEventArgs e)
        {
            if (backBuffer == null)
            {
                backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }

            Graphics g = Graphics.FromImage(backBuffer);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(this.BackColor);

            if (fields != null)
            {
                // Paint all fields
                for (int x = 0; x < Board.WIDTH; x++)
                {
                    for (int y = 0; y < Board.HEIGHT; y++)
                    {
                        fields[x, y].Draw(g);
                    }
                }
            }
            if (towers != null)
            {
                // Paint all towers
                for (int i = 0; i < towers.Count; i++)
                {
                    towers[i].Draw(g);
                }
            }

            g.Dispose();

            //Copy the back buffer to the screen
            e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Don't allow the background to paint
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool oldUseWaitCursor = UseWaitCursor;
            UseWaitCursor = true;
            gameController.StateMachine.HandleMouseDown(GetFieldPosition(new System.Drawing.Point(e.X, e.Y)));
            UseWaitCursor = oldUseWaitCursor;

            Refresh();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool oldUseWaitCursor = UseWaitCursor;
            UseWaitCursor = true;
            Refresh();
            gameController.StateMachine.HandleMouseUp(GetFieldPosition(new System.Drawing.Point(e.X, e.Y)));
            UseWaitCursor = oldUseWaitCursor;

            Refresh();

            base.OnMouseUp(e);
        }
        #endregion

        private Engine.Point GetFieldPosition(System.Drawing.Point cursorPosition)
        {
            int x = (cursorPosition.X - MARGIN) / (DrawableField.WIDTH + DrawableField.MARGIN * 2);
            int y = (cursorPosition.Y - MARGIN) / (DrawableField.HEIGHT + DrawableField.MARGIN * 2);
            if (x >= Board.WIDTH && y >= Board.HEIGHT)
            {
                x = -1;
                y = -1;
            }

            return new Engine.Point(x, y);
        }
    }
}
