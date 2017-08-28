namespace SchaakSpelStijn
{
    partial class ScoreBord
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
            this.lblBlack = new System.Windows.Forms.Label();
            this.lblWhite = new System.Windows.Forms.Label();
            this.txtBlackLost = new System.Windows.Forms.TextBox();
            this.txtWhiteLost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBlack
            // 
            this.lblBlack.AutoSize = true;
            this.lblBlack.Location = new System.Drawing.Point(24, 16);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(105, 13);
            this.lblBlack.TabIndex = 0;
            this.lblBlack.Text = "Zwart heeft verloren:";
            // 
            // lblWhite
            // 
            this.lblWhite.AutoSize = true;
            this.lblWhite.Location = new System.Drawing.Point(27, 434);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(94, 13);
            this.lblWhite.TabIndex = 1;
            this.lblWhite.Text = "Wit heeft verloren:";
            // 
            // txtBlackLost
            // 
            this.txtBlackLost.Location = new System.Drawing.Point(27, 32);
            this.txtBlackLost.Multiline = true;
            this.txtBlackLost.Name = "txtBlackLost";
            this.txtBlackLost.Size = new System.Drawing.Size(83, 106);
            this.txtBlackLost.TabIndex = 2;
            // 
            // txtWhiteLost
            // 
            this.txtWhiteLost.Location = new System.Drawing.Point(27, 450);
            this.txtWhiteLost.Multiline = true;
            this.txtWhiteLost.Name = "txtWhiteLost";
            this.txtWhiteLost.Size = new System.Drawing.Size(83, 106);
            this.txtWhiteLost.TabIndex = 3;
            // 
            // ScoreBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtWhiteLost);
            this.Controls.Add(this.txtBlackLost);
            this.Controls.Add(this.lblWhite);
            this.Controls.Add(this.lblBlack);
            this.Name = "ScoreBord";
            this.Size = new System.Drawing.Size(137, 559);
            this.Load += new System.EventHandler(this.ScoreBord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBlack;
        private System.Windows.Forms.Label lblWhite;
        private System.Windows.Forms.TextBox txtBlackLost;
        private System.Windows.Forms.TextBox txtWhiteLost;
    }
}
