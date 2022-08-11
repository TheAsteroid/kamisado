using Kamisado.Engine;
using Kamisado.Engine.GameStates;
using System;
using System.Windows.Forms;

namespace Kamisado.GUI
{
    public partial class GUI : Form
    {
        private GameController gameController;

        public GUI()
        {
            InitializeComponent();
            gameController = new GameController();
            gameController.CreateMessageQueue(boardControl.MessageBox, boardControl.MoveValuesBox);
            SetDifficulty(GameController.Difficulty.Medium, menuMedium);
            boardControl.GameController = gameController;
            boardControl.InitializeBoard();
        }

        private void menuNewGameGold_Hover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Start a new game where you use golden towers";
        }

        private void menuNewGameBlack_Hover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Start a new game where you use black towers";
        }

        private void menuNewGameGold_Click(object sender, EventArgs e)
        {
            StartGame(true);
        }

        private void menuNewGameBlack_Click(object sender, EventArgs e)
        {
            StartGame(false);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit this game?", "Exit", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuEasy_Click(object sender, EventArgs e)
        {
            SetDifficulty(GameController.Difficulty.Easy, (ToolStripMenuItem)sender);
        }

        private void menuMedium_Click(object sender, EventArgs e)
        {
            SetDifficulty(GameController.Difficulty.Medium, (ToolStripMenuItem)sender);
        }

        private void menuHard_Click(object sender, EventArgs e)
        {
            SetDifficulty(GameController.Difficulty.Hard, (ToolStripMenuItem)sender);
        }

        private void menuImpossible_Click(object sender, EventArgs e)
        {
            SetDifficulty(GameController.Difficulty.Impossible, (ToolStripMenuItem)sender);
        }

        private void menuShowMoveValues_Click(object sender, EventArgs e)
        {
            menuShowMoveValues.Checked = !menuShowMoveValues.Checked;
            boardControl.MoveValuesBox.Visible = menuShowMoveValues.Checked;
        }

        private void statusLabel_Clear(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
        }

        private void StartGame(bool isComputerBlack)
        {
            if (!gameController.IsFirstMoveDone ||
                MessageBox.Show("Are you sure you want to start a new game?", "New game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StatusLabel.Text = "Starting new game";
                // First go to NewGameState
                gameController.StateMachine.HandleEvent(
                    isComputerBlack ? StateTable.Event.NewGameGold : StateTable.Event.NewGameBlack);
                // Allow board to initialize
                boardControl.InitializeBoard();
                // Then go to player or computer state
                gameController.StateMachine.HandleEvent(
                    isComputerBlack ? StateTable.Event.NewGameGold : StateTable.Event.NewGameBlack);
                StatusLabel.Text = string.Empty;
                Refresh();
            }
        }

        private void SetDifficulty(GameController.Difficulty difficulty, ToolStripMenuItem sender)
        {
            gameController.SetDifficulty(difficulty);
            foreach (ToolStripMenuItem ts in menuDifficulty.DropDownItems)
            {
                if (ts == sender)
                {
                    ts.Checked = true;
                }
                else
                {
                    ts.Checked = false;
                }
            }
            gameController.MessageQueue.Queue("Difficulty set to {0}", sender.Text);
        }
    }
}
