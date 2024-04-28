namespace Minesweeper
{
    partial class DifficultySelectForm
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
            this.BeginnerButton = new System.Windows.Forms.Button();
            this.IntermediateButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BeginnerButton
            // 
            this.BeginnerButton.BackColor = System.Drawing.Color.Green;
            this.BeginnerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BeginnerButton.ForeColor = System.Drawing.Color.White;
            this.BeginnerButton.Location = new System.Drawing.Point(12, 67);
            this.BeginnerButton.Name = "BeginnerButton";
            this.BeginnerButton.Size = new System.Drawing.Size(268, 116);
            this.BeginnerButton.TabIndex = 0;
            this.BeginnerButton.Text = "Beginner";
            this.BeginnerButton.UseVisualStyleBackColor = false;
            this.BeginnerButton.Click += new System.EventHandler(this.BeginnerButton_Click);
            // 
            // IntermediateButton
            // 
            this.IntermediateButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.IntermediateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IntermediateButton.ForeColor = System.Drawing.Color.White;
            this.IntermediateButton.Location = new System.Drawing.Point(12, 259);
            this.IntermediateButton.Name = "IntermediateButton";
            this.IntermediateButton.Size = new System.Drawing.Size(268, 116);
            this.IntermediateButton.TabIndex = 1;
            this.IntermediateButton.Text = "Intermediate";
            this.IntermediateButton.UseVisualStyleBackColor = false;
            this.IntermediateButton.Click += new System.EventHandler(this.IntermediateButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(12, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 116);
            this.button2.TabIndex = 2;
            this.button2.Text = "Expert";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(286, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "9x9 board, 10 mines";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(278, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "16x16 board, 40 mines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(278, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "30x16 board, 99 mines";
            // 
            // DifficultySelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(587, 658);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.IntermediateButton);
            this.Controls.Add(this.BeginnerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DifficultySelectForm";
            this.Text = "Select a difficulty!";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BeginnerButton;
        private System.Windows.Forms.Button IntermediateButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}