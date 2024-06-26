﻿namespace Minesweeper
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
            this.components = new System.ComponentModel.Container();
            this.RestartButton = new System.Windows.Forms.Button();
            this.BombsRemainingLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabel = new System.Windows.Forms.Label();
            this.DiffSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.Color.Yellow;
            this.RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RestartButton.ForeColor = System.Drawing.Color.Black;
            this.RestartButton.Location = new System.Drawing.Point(340, 9);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(167, 69);
            this.RestartButton.TabIndex = 0;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // BombsRemainingLabel
            // 
            this.BombsRemainingLabel.AutoSize = true;
            this.BombsRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BombsRemainingLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.BombsRemainingLabel.Location = new System.Drawing.Point(984, 9);
            this.BombsRemainingLabel.Name = "BombsRemainingLabel";
            this.BombsRemainingLabel.Size = new System.Drawing.Size(63, 69);
            this.BombsRemainingLabel.TabIndex = 2;
            this.BombsRemainingLabel.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TimerLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.TimerLabel.Location = new System.Drawing.Point(12, 9);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(63, 69);
            this.TimerLabel.TabIndex = 3;
            this.TimerLabel.Text = "0";
            // 
            // DiffSelectButton
            // 
            this.DiffSelectButton.BackColor = System.Drawing.Color.Yellow;
            this.DiffSelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DiffSelectButton.ForeColor = System.Drawing.Color.Black;
            this.DiffSelectButton.Location = new System.Drawing.Point(557, 9);
            this.DiffSelectButton.Name = "DiffSelectButton";
            this.DiffSelectButton.Size = new System.Drawing.Size(167, 69);
            this.DiffSelectButton.TabIndex = 4;
            this.DiffSelectButton.Text = "Select new difficulty";
            this.DiffSelectButton.UseVisualStyleBackColor = false;
            this.DiffSelectButton.Click += new System.EventHandler(this.DiffSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(124, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "seconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(783, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "mines left:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1082, 648);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DiffSelectButton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.BombsRemainingLabel);
            this.Controls.Add(this.RestartButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Minesweeper";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Label BombsRemainingLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Button DiffSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

