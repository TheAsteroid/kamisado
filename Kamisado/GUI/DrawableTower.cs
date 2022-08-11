using Kamisado.Engine;
using System.Drawing;

namespace Kamisado.GUI
{
    public class DrawableTower : DrawableObject
    {
        public const int
            WIDTH = 40,
            HEIGHT = 40,
            MARGIN = 2;

        Tower tower;

        public DrawableTower(BoardControl boardControl, Tower tower)
            : base(boardControl, new Size(WIDTH, HEIGHT), MARGIN)
        {
            this.boardControl = boardControl;
            this.tower = tower;
        }

        public override void Draw(Graphics g)
        {
            // Always update the position from the Tower object because it can change
            SetPosition(tower.Position);
            if (tower == gameController.CurrentTower)
            {
                g.FillEllipse(boardControl.BorderLightBrushes[tower.Color], rect);
            }
            else
            {
                g.FillEllipse(boardControl.BorderDarkBrushes[tower.Color], rect);
            }
            g.DrawArc(boardControl.PlayerPens[tower.Player.Color], rect, 0, 360);
        }

        public Tower Tower
        {
            get { return tower; }
        }
    }
}
