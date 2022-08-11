namespace Kamisado.GUI
{
    partial class BoardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelInformation = new System.Windows.Forms.Label();
            this.MessageBox = new System.Windows.Forms.Panel();
            this.MoveValuesBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(495, 17);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(0, 13);
            this.labelInformation.TabIndex = 0;
            // 
            // MessageBox
            // 
            this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MessageBox.Location = new System.Drawing.Point(496, 8);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(263, 225);
            this.MessageBox.TabIndex = 1;
            // 
            // MoveValuesBox
            // 
            this.MoveValuesBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MoveValuesBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveValuesBox.Location = new System.Drawing.Point(496, 240);
            this.MoveValuesBox.Name = "MoveValuesBox";
            this.MoveValuesBox.Size = new System.Drawing.Size(263, 225);
            this.MoveValuesBox.TabIndex = 2;
            // 
            // BoardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MoveValuesBox);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.labelInformation);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BoardControl";
            this.Size = new System.Drawing.Size(767, 473);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInformation;
        public System.Windows.Forms.Panel MessageBox;
        public System.Windows.Forms.Panel MoveValuesBox;
    }
}
