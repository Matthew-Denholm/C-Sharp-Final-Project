using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe;

namespace Final_Project
{
    
    
    public partial class MainScreen : Form
    {
        int l = Screen.PrimaryScreen.WorkingArea.Width;
        int h = Screen.PrimaryScreen.WorkingArea.Height;

        public static int boardSize2, length2;
        public MainScreen()
        {
            InitializeComponent();

            //Placing and Sizing Buttons for different Screen sizes
            //Button for 2 Player Game
            Button_P2.Width = l / 3;
            Button_P2.Height = h / 5;
            Button_P2.Left = 50;
            Button_P2.Top = 50;
            //Button for 3 Player Game
            Button_P3.Width = l / 3;
            Button_P3.Height = h / 5;
            int P3Width = Button_P3.Size.Width;
            Button_P3.Left = l - (P3Width + 50);
            Button_P3.Top = 50;
            //Button for Exit
            Button_Exit.Width = l / 3;
            Button_Exit.Height = h / 5;
            int ExitWidth = Button_Exit.Size.Width;
            Button_Exit.Left = ((l / 2) - (ExitWidth / 2));
            Button_Exit.Top = h / 2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_P2_Click(object sender, EventArgs e)
        {
            boardSize2 = 65;
            length2 = 8;
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Button_P3_Click(object sender, EventArgs e)
        {
            boardSize2 = 82;
            length2 = 9;
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
