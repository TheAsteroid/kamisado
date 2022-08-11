using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kamisado.GameStates.PlayingStates;

namespace Kamisado.GameStates
{
    public class Playing : IGameState
    {
        private IPlaying playingState;
        private Board board;

        public Playing(Type stateType)
        {
            board = new Board();
            ChangePlayingState(stateType);
        }

        public IPlaying PlayingState
        {
            get { return playingState; }
        }

        public Board Board
        {
            get { return board; }
        }

        public void ChangePlayingState(Type stateType)
        {
            if (playingState == null || playingState.GetType() != stateType)
            {
                if (playingState != null)
                {
                    playingState.ExitState();
                }
                switch (stateType.Name)
                {
                    case "ComputerTurn":
                        playingState = new ComputerTurn();
                        break;
                    case "PlayerTurn":
                        playingState = new PlayerTurn(board);
                        break;
                    default:
                        throw new NotSupportedException("PlayingState " + stateType.Name + " does not exist");
                }
            }
        }

        public void OnPaint(PaintEventArgs e, Graphics g)
        {
            foreach (Field f in board.Fields)
            {
                g.FillRectangle(board.Brushes[f.Color], f.Rect);
                g.DrawLines(board.Pens[f.BorderColorLight], new Point[] { f.TopLeft, f.TopRight, f.BottomRight });
                g.DrawLines(board.Pens[f.BorderColorDark], new Point[] { f.TopLeft, f.BottomLeft, f.BottomRight });

                if (f.HasPiece)
                {
                    Piece p = f.PeekPiece();
                    g.FillEllipse(board.Brushes[p.BorderColorDark], p.Rect);
                    g.DrawArc(board.Pens[p.PlayerColor], p.Rect, 0, 360);
                }
            }
        }

        public void ExitState()
        {
            playingState.ExitState();
        }

        public bool OnMouseDown(System.Windows.Forms.MouseEventArgs me)
        {
            return playingState.OnMouseDown(me);
        }

        public bool OnMouseUp(System.Windows.Forms.MouseEventArgs me)
        {
            return playingState.OnMouseUp(me);
        }

        public bool OnMouseMove(System.Windows.Forms.MouseEventArgs me)
        {
            return playingState.OnMouseMove(me);
        }
    }
}
