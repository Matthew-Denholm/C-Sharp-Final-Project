namespace Final_Project
{
    partial class MainScreen
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
            this.Button_P2 = new System.Windows.Forms.Button();
            this.Button_P3 = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_P2
            // 
            this.Button_P2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_P2.ForeColor = System.Drawing.Color.Black;
            this.Button_P2.Location = new System.Drawing.Point(0, -1);
            this.Button_P2.Name = "Button_P2";
            this.Button_P2.Size = new System.Drawing.Size(150, 50);
            this.Button_P2.TabIndex = 0;
            this.Button_P2.Text = "2 Players";
            this.Button_P2.UseVisualStyleBackColor = true;
            this.Button_P2.Click += new System.EventHandler(this.Button_P2_Click);
            // 
            // Button_P3
            // 
            this.Button_P3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_P3.ForeColor = System.Drawing.Color.Black;
            this.Button_P3.Location = new System.Drawing.Point(156, -1);
            this.Button_P3.Name = "Button_P3";
            this.Button_P3.Size = new System.Drawing.Size(150, 50);
            this.Button_P3.TabIndex = 1;
            this.Button_P3.Text = "3 Players";
            this.Button_P3.UseVisualStyleBackColor = true;
            this.Button_P3.Click += new System.EventHandler(this.Button_P3_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Exit.ForeColor = System.Drawing.Color.Black;
            this.Button_Exit.Location = new System.Drawing.Point(72, 55);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(150, 75);
            this.Button_Exit.TabIndex = 2;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(324, 149);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_P3);
            this.Controls.Add(this.Button_P2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainScreen";
            this.Text = "LoadScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_P2;
        private System.Windows.Forms.Button Button_P3;
        private System.Windows.Forms.Button Button_Exit;
    }
}

