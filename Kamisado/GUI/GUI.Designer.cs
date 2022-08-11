namespace Kamisado.GUI
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewGameBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewGameGold = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDifficulty = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImpossible = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowMoveValues = new System.Windows.Forms.ToolStripMenuItem();
            this.boardContainer = new System.Windows.Forms.Panel();
            this.boardControl = new Kamisado.GUI.BoardControl();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.boardContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 525);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGame,
            this.menuOptions});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuGame
            // 
            this.menuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewGameBlack,
            this.menuNewGameGold,
            this.menuExit});
            this.menuGame.Name = "menuGame";
            this.menuGame.Size = new System.Drawing.Size(50, 20);
            this.menuGame.Text = "Game";
            // 
            // menuNewGameBlack
            // 
            this.menuNewGameBlack.Name = "menuNewGameBlack";
            this.menuNewGameBlack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.menuNewGameBlack.Size = new System.Drawing.Size(215, 22);
            this.menuNewGameBlack.Text = "New game (Black)";
            this.menuNewGameBlack.Click += new System.EventHandler(this.menuNewGameBlack_Click);
            this.menuNewGameBlack.MouseLeave += new System.EventHandler(this.statusLabel_Clear);
            this.menuNewGameBlack.MouseHover += new System.EventHandler(this.menuNewGameBlack_Hover);
            // 
            // menuNewGameGold
            // 
            this.menuNewGameGold.Name = "menuNewGameGold";
            this.menuNewGameGold.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNewGameGold.Size = new System.Drawing.Size(215, 22);
            this.menuNewGameGold.Text = "New game (Gold)";
            this.menuNewGameGold.Click += new System.EventHandler(this.menuNewGameGold_Click);
            this.menuNewGameGold.MouseLeave += new System.EventHandler(this.statusLabel_Clear);
            this.menuNewGameGold.MouseHover += new System.EventHandler(this.menuNewGameGold_Hover);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menuExit.Size = new System.Drawing.Size(215, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDifficulty,
            this.menuShowMoveValues});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(61, 20);
            this.menuOptions.Text = "Options";
            // 
            // menuDifficulty
            // 
            this.menuDifficulty.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEasy,
            this.menuMedium,
            this.menuHard,
            this.menuImpossible});
            this.menuDifficulty.Name = "menuDifficulty";
            this.menuDifficulty.Size = new System.Drawing.Size(172, 22);
            this.menuDifficulty.Text = "Difficulty";
            // 
            // menuEasy
            // 
            this.menuEasy.Name = "menuEasy";
            this.menuEasy.Size = new System.Drawing.Size(131, 22);
            this.menuEasy.Text = "Easy";
            this.menuEasy.Click += new System.EventHandler(this.menuEasy_Click);
            // 
            // menuMedium
            // 
            this.menuMedium.Name = "menuMedium";
            this.menuMedium.Size = new System.Drawing.Size(131, 22);
            this.menuMedium.Text = "Medium";
            this.menuMedium.Click += new System.EventHandler(this.menuMedium_Click);
            // 
            // menuHard
            // 
            this.menuHard.Name = "menuHard";
            this.menuHard.Size = new System.Drawing.Size(131, 22);
            this.menuHard.Text = "Hard";
            this.menuHard.Click += new System.EventHandler(this.menuHard_Click);
            // 
            // menuImpossible
            // 
            this.menuImpossible.Name = "menuImpossible";
            this.menuImpossible.Size = new System.Drawing.Size(131, 22);
            this.menuImpossible.Text = "Impossible";
            this.menuImpossible.Click += new System.EventHandler(this.menuImpossible_Click);
            // 
            // menuShowMoveValues
            // 
            this.menuShowMoveValues.Checked = true;
            this.menuShowMoveValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowMoveValues.Name = "menuShowMoveValues";
            this.menuShowMoveValues.Size = new System.Drawing.Size(172, 22);
            this.menuShowMoveValues.Text = "Show Move values";
            this.menuShowMoveValues.Click += new System.EventHandler(this.menuShowMoveValues_Click);
            // 
            // boardContainer
            // 
            this.boardContainer.Controls.Add(this.boardControl);
            this.boardContainer.Location = new System.Drawing.Point(13, 27);
            this.boardContainer.Name = "boardContainer";
            this.boardContainer.Size = new System.Drawing.Size(767, 495);
            this.boardContainer.TabIndex = 2;
            // 
            // boardControl
            // 
            this.boardControl.GameController = null;
            this.boardControl.Location = new System.Drawing.Point(0, 0);
            this.boardControl.Margin = new System.Windows.Forms.Padding(0);
            this.boardControl.Name = "boardControl";
            this.boardControl.Size = new System.Drawing.Size(767, 494);
            this.boardControl.TabIndex = 0;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 547);
            this.Controls.Add(this.boardContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "GUI";
            this.Text = "Kamisado 1.0";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.boardContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuGame;
        private System.Windows.Forms.ToolStripMenuItem menuNewGameGold;
        private System.Windows.Forms.ToolStripMenuItem menuNewGameBlack;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuDifficulty;
        private System.Windows.Forms.Panel boardContainer;
        private BoardControl boardControl;
        private System.Windows.Forms.ToolStripMenuItem menuEasy;
        private System.Windows.Forms.ToolStripMenuItem menuMedium;
        private System.Windows.Forms.ToolStripMenuItem menuHard;
        private System.Windows.Forms.ToolStripMenuItem menuImpossible;
        private System.Windows.Forms.ToolStripMenuItem menuShowMoveValues;

    }
}

