namespace Minesweeper
{
    partial class MainForm
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
            this.RestartButton = new System.Windows.Forms.Button();
            this.TimeRemainingLabel = new System.Windows.Forms.Label();
            this.ClicksLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RestartButton
            // 
            this.RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RestartButton.Location = new System.Drawing.Point(350, 12);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(147, 62);
            this.RestartButton.TabIndex = 0;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // TimeRemainingLabel
            // 
            this.TimeRemainingLabel.AutoSize = true;
            this.TimeRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TimeRemainingLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.TimeRemainingLabel.Location = new System.Drawing.Point(42, 9);
            this.TimeRemainingLabel.Name = "TimeRemainingLabel";
            this.TimeRemainingLabel.Size = new System.Drawing.Size(63, 69);
            this.TimeRemainingLabel.TabIndex = 1;
            this.TimeRemainingLabel.Text = "0";
            // 
            // ClicksLabel
            // 
            this.ClicksLabel.AutoSize = true;
            this.ClicksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClicksLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ClicksLabel.Location = new System.Drawing.Point(752, 9);
            this.ClicksLabel.Name = "ClicksLabel";
            this.ClicksLabel.Size = new System.Drawing.Size(63, 69);
            this.ClicksLabel.TabIndex = 2;
            this.ClicksLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(868, 648);
            this.Controls.Add(this.ClicksLabel);
            this.Controls.Add(this.TimeRemainingLabel);
            this.Controls.Add(this.RestartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Label TimeRemainingLabel;
        private System.Windows.Forms.Label ClicksLabel;
    }
}

