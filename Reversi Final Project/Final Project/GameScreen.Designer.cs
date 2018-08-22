namespace TicTacToe
{
    partial class Form1
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
            this.LabelWinner = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Black = new System.Windows.Forms.Button();
            this.button_White = new System.Windows.Forms.Button();
            this.button_Red = new System.Windows.Forms.Button();
            this.button_Blue = new System.Windows.Forms.Button();
            this.button_Green = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelWinner
            // 
            this.LabelWinner.AutoSize = true;
            this.LabelWinner.Location = new System.Drawing.Point(208, 15);
            this.LabelWinner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelWinner.Name = "LabelWinner";
            this.LabelWinner.Size = new System.Drawing.Size(53, 17);
            this.LabelWinner.TabIndex = 0;
            this.LabelWinner.Text = "Winner";
            this.LabelWinner.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Black
            // 
            this.button_Black.BackColor = System.Drawing.Color.Black;
            this.button_Black.Location = new System.Drawing.Point(16, 15);
            this.button_Black.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Black.Name = "button_Black";
            this.button_Black.Size = new System.Drawing.Size(85, 79);
            this.button_Black.TabIndex = 9;
            this.button_Black.UseVisualStyleBackColor = false;
            this.button_Black.Visible = false;
            // 
            // button_White
            // 
            this.button_White.BackColor = System.Drawing.Color.White;
            this.button_White.Location = new System.Drawing.Point(16, 15);
            this.button_White.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_White.Name = "button_White";
            this.button_White.Size = new System.Drawing.Size(85, 79);
            this.button_White.TabIndex = 10;
            this.button_White.UseVisualStyleBackColor = false;
            this.button_White.Visible = false;
            // 
            // button_Red
            // 
            this.button_Red.BackColor = System.Drawing.Color.Red;
            this.button_Red.Location = new System.Drawing.Point(16, 15);
            this.button_Red.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Red.Name = "button_Red";
            this.button_Red.Size = new System.Drawing.Size(85, 79);
            this.button_Red.TabIndex = 10;
            this.button_Red.UseVisualStyleBackColor = false;
            this.button_Red.Visible = false;
            // 
            // button_Blue
            // 
            this.button_Blue.BackColor = System.Drawing.Color.Blue;
            this.button_Blue.Location = new System.Drawing.Point(16, 15);
            this.button_Blue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Blue.Name = "button_Blue";
            this.button_Blue.Size = new System.Drawing.Size(85, 79);
            this.button_Blue.TabIndex = 10;
            this.button_Blue.UseVisualStyleBackColor = false;
            this.button_Blue.Visible = false;
            // 
            // button_Green
            // 
            this.button_Green.BackColor = System.Drawing.Color.Green;
            this.button_Green.Location = new System.Drawing.Point(16, 15);
            this.button_Green.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Green.Name = "button_Green";
            this.button_Green.Size = new System.Drawing.Size(85, 79);
            this.button_Green.TabIndex = 10;
            this.button_Green.UseVisualStyleBackColor = false;
            this.button_Green.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "Player1:\r\nPlayer2:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(319, 116);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_White);
            this.Controls.Add(this.button_Black);
            this.Controls.Add(this.button_Green);
            this.Controls.Add(this.button_Red);
            this.Controls.Add(this.button_Blue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LabelWinner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Reversi - Game";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelWinner;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Black;
        private System.Windows.Forms.Button button_White;
        private System.Windows.Forms.Button button_Red;
        private System.Windows.Forms.Button button_Blue;
        private System.Windows.Forms.Button button_Green;
        private System.Windows.Forms.Label label1;
    }
}

