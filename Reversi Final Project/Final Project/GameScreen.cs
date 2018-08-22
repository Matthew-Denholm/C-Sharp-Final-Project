using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project;

namespace TicTacToe
{

    public partial class Form1 : Form
    {
        int boardSize1 = MainScreen.boardSize2;
        int length1 = MainScreen.length2;
        Button[] arr;
        int i = 0;
        //int cc = 0; //counter for moves
        int l = Screen.PrimaryScreen.WorkingArea.Width;
        int h = Screen.PrimaryScreen.WorkingArea.Height;

        public Form1()
        {
            InitializeComponent();
            makeBoard(boardSize1, length1);
        }

        private void makeBoard(int boardSize, int length)
        {
            arr = new Button[boardSize];
            for (i = 1; i < boardSize; i++)
            {
                arr[i] = new Button();
                arr[i].AutoSize = false;
                arr[i].Visible = true;
                arr[i].Width = 50;
                arr[i].Height = 50;
                arr[i].Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                arr[i].ForeColor = Color.Gray;
                arr[i].BackColor = Color.Gray;
                arr[i].TextAlign = ContentAlignment.MiddleCenter;
                arr[i].Text = i.ToString();
                arr[i].Tag = i;
                arr[i].Click += new EventHandler(lbl_click);
                this.Controls.Add(arr[i]);
            }
            i = 0;
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    i += 1;
                    arr[i].Left = (x * 50) + (l / 3);
                    arr[i].Top = (y * 50) + (h / 3);
                }
            }
            setDefault(arr, boardSize);
        }

        private void setDefault(Button[] arr, int size)
        {
            if (size == 65)
            {
                button_White.Visible = true;
                arr[28].BackColor = Color.White;
                arr[29].BackColor = Color.Black;
                arr[37].BackColor = Color.White;
                arr[36].BackColor = Color.Black;

                arr[28].Enabled = false;
                arr[29].Enabled = false;
                arr[36].Enabled = false;
                arr[37].Enabled = false;
            }
            else if (size == 82)
            {
                button_Red.Visible = true;
                arr[31].BackColor = Color.Red;
                arr[32].BackColor = Color.Blue;
                arr[33].BackColor = Color.Green;
                arr[40].BackColor = Color.Blue;
                arr[41].BackColor = Color.Green;
                arr[42].BackColor = Color.Red;
                arr[49].BackColor = Color.Red;
                arr[50].BackColor = Color.Green;
                arr[51].BackColor = Color.Blue;

                arr[31].Enabled = false;
                arr[32].Enabled = false;
                arr[33].Enabled = false;
                arr[40].Enabled = false;
                arr[41].Enabled = false;
                arr[42].Enabled = false;
                arr[49].Enabled = false;
                arr[50].Enabled = false;
                arr[51].Enabled = false;
            }
        }

        private void Flip(int change, int square, Color color, string Direction)
        {
            //this switch statement will change the colors of the appropriate chips.
            switch (Direction)
            {
                case "up":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[square - length1].BackColor = color;
                            square = square - length1;
                        }
                        break;
                    }
                case "down":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[square + length1].BackColor = color;
                            square = square + length1;
                        }
                        break;
                    }
                case "left":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[square - 1].BackColor = color;
                            square = square - 1;
                        }
                        break;
                    }
                case "right":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[square + 1].BackColor = color;
                            square = square + 1;
                        }
                        break;
                    }
                case "upLeft":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[square - length1 - 1].BackColor = color;
                            square = square - length1 - 1;
                        }
                        break;
                    }
                case "upRight":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[(square - length1) + 1].BackColor = color;
                            square = square - length1 + 1;
                        }
                        break;
                    }
                case "downLeft":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[(square + length1) - 1].BackColor = color;
                            square = (square + length1) - 1;
                        }
                        break;
                    }
                case "downRight":
                    {
                        for (int c = change; c > 0; c--)
                        {
                            arr[square + length1 + 1].BackColor = color;
                            square = square + length1 + 1;
                        }
                        break;
                    }
                default:
                    break;
            }

        }

        private void check(int index, Color color) //check method for two player game. Changes the colors.
        {
            if (boardSize1 == 65)//two player game
            {
                if (color == Color.White)
                {
                    //These methods will check for validity
                    int place = index;
                    int count = 0;
                    string dir = "up";

                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Black)
                            {
                                count++;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }

                    Flip(count, index, color, dir);

                    //this check vertical down
                    place = index;
                    count = 0;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Black)
                            {
                                count++;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal left
                    place = index;
                    count = 0;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Black)
                            {
                                count++;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                }       
                            }
                        }
                    
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal right
                    place = index;
                    count = 0;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Black)
                            {
                                count++;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and left
                    place = index;
                    count = 0;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place/length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Black)
                            {
                                count++;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and right
                    place = index;
                    count = 0;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Black)
                            {
                                count++;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and left
                    place = index;
                    count = 0;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Black)
                            {
                                count++;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and right
                    place = index;
                    count = 0;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Black)
                            {
                                count++;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);
                }
                else if (color == Color.Black)
                {
                    //These methods will check for validity
                    int place = index;
                    int count = 0;
                    string dir = "up";

                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.White)
                            {
                                count++;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }

                    Flip(count, index, color, dir);

                    //this check vertical down
                    place = index;
                    count = 0;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.White)
                            {
                                count++;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal left
                    place = index;
                    count = 0;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.White)
                            {
                                count++;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count = 0;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal right
                    place = index;
                    count = 0;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.White)
                            {
                                count++;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count = 0;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and left
                    place = index;
                    count = 0;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.White)
                            {
                                count++;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and right
                    place = index;
                    count = 0;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.White)
                            {
                                count++;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and left
                    place = index;
                    count = 0;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.White)
                            {
                                count++;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and right
                    place = index;
                    count = 0;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.White)
                            {
                                count++;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);
                }
            }
            else if (boardSize1 == 82) //three player game
            {
                if (color == Color.Red) //Player 1
                {
                    //These methods will check for validity
                    int place = index;
                    int count = 0;
                    string dir = "up";

                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Blue || arr[place - length1].BackColor == Color.Green)
                            {
                                count++;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }

                    Flip(count, index, color, dir);

                    //this check vertical down
                    place = index;
                    count = 0;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Blue || arr[place + length1].BackColor == Color.Green)
                            {
                                count++;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal left
                    place = index;
                    count = 0;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Blue || arr[place - 1].BackColor == Color.Green)
                            {
                                count++;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal right
                    place = index;
                    count = 0;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Blue || arr[place + 1].BackColor == Color.Green)
                            {
                                count++;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count = 0;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and left
                    place = index;
                    count = 0;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Blue || arr[place - length1 - 1].BackColor == Color.Green)
                            {
                                count++;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and right
                    place = index;
                    count = 0;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Blue || arr[(place - length1) + 1].BackColor == Color.Green)
                            {
                                count++;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and left
                    place = index;
                    count = 0;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Blue || arr[(place + length1) - 1].BackColor == Color.Green)
                            {
                                count++;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and right
                    place = index;
                    count = 0;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Blue || arr[place + length1 + 1].BackColor == Color.Green)
                            {
                                count++;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);
                }
                else if (color == Color.Blue)//Player 2
                {
                    //These methods will check for validity
                    int place = index;
                    int count = 0;
                    string dir = "up";

                    //this check vertical up for blue.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Green || arr[place - length1].BackColor == Color.Red)
                            {
                                count++;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }

                    Flip(count, index, color, dir);

                    //this check vertical down
                    place = index;
                    count = 0;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Green || arr[place + length1].BackColor == Color.Red)
                            {
                                count++;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal left
                    place = index;
                    count = 0;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Green || arr[place - 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal right
                    place = index;
                    count = 0;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Green || arr[place + 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and left
                    place = index;
                    count = 0;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Green || arr[place - length1 - 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and right
                    place = index;
                    count = 0;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Green || arr[(place - length1) + 1].BackColor == Color.Red)
                            {
                                count++;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and left
                    place = index;
                    count = 0;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Green || arr[(place + length1) - 1].BackColor == Color.Red)
                            {
                                count++;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and right
                    place = index;
                    count = 0;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Green || arr[place + length1 + 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);
                }
                else if (color == Color.Green)//Player 3
                {
                    //These methods will check for validity
                    int place = index;
                    int count = 0;
                    string dir = "up";

                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Blue || arr[place - length1].BackColor == Color.Red)
                            {
                                count++;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }

                    Flip(count, index, color, dir);

                    //this check vertical down
                    place = index;
                    count = 0;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Blue || arr[place + length1].BackColor == Color.Red)
                            {
                                count++;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal left
                    place = index;
                    count = 0;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Blue || arr[place - 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check horizontal right
                    place = index;
                    count = 0;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Blue || arr[place + 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and left
                    place = index;
                    count = 0;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Blue || arr[place - length1 - 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal up and right
                    place = index;
                    count = 0;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Blue || arr[(place - length1) + 1].BackColor == Color.Red)
                            {
                                count++;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and left
                    place = index;
                    count = 0;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Blue || arr[(place + length1) - 1].BackColor == Color.Red)
                            {
                                count++;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);

                    //this check diagonal down and right
                    place = index;
                    count = 0;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count = 0;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count = 0;
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Blue || arr[place + length1 + 1].BackColor == Color.Red)
                            {
                                count++;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count = 0;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count = 0;
                    }
                    Flip(count, index, color, dir);
                }
            }
        }
        
        private Boolean Check(int index, Color color) //check method (prevents random placement) returns true if a valid move is selected
        {
            int place = index;
            bool count1 = false, count2 = false, count3 = false, count4 = false, count5 = false, count6 = false, count7 = false, count8 = false;
            if (boardSize1 == 65)
            {
                if (color == Color.White)
                {
                    string dir = "up";
                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Black)
                            {
                                count1 = true;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count1 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                                
                        }
                    }
                    catch (Exception e)
                    {
                        count1 = false;
                    }

                    //this check vertical down
                    place = index;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Black)
                            {
                                count2 = true;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count2 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count2 = false;
                    }

                    //this check horizontal left
                    place = index;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Black)
                            {
                                count3 = true;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count3 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                count3 = false;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count3 = false;
                    }

                    //this check horizontal right
                    place = index;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Black)
                            {
                                count4 = true;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count4 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                count4 = false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count4 = false;
                    }

                    //this check diagonal up and left
                    place = index;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count5 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count5 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Black)
                            {
                                count5 = true;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count5 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count5 = false;
                    }

                    //this check diagonal up and right
                    place = index;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count6 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count6 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Black)
                            {
                                count6 = true;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count6 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count6 = false;
                    }

                    //this check diagonal down and left
                    place = index;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count7 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count7 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Black)
                            {
                                count7 = true;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count7 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count7 = false;
                    }

                    //this check diagonal down and right
                    place = index;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count8 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.White)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count8 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Black)
                            {
                                count8 = true;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.White)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count8 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count8 = false;
                    }
                    if (count1 == true || count2 == true || count3 == true || count4 == true || count5 == true || count6 == true || count7 == true || count8 == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (color == Color.Black)
                {
                    string dir = "up";
                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.White)
                            {
                                count1 = true;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count1 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count1 = false;
                    }

                    //this check vertical down
                    place = index;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.White)
                            {
                                count2 = true;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count2 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count2 = false;
                    }

                    //this check horizontal left
                    place = index;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.White)
                            {
                                count3 = true;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count3 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                count3 = false;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count3 = false;
                    }

                    //this check horizontal right
                    place = index;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.White)
                            {
                                count4 = true;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count4 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                count4 = false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count4 = false;
                    }

                    //this check diagonal up and left
                    place = index;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count5 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count5 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.White)
                            {
                                count5 = true;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count5 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count5 = false;
                    }

                    //this check diagonal up and right
                    place = index;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count6 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count6 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.White)
                            {
                                count6 = true;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count6 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count6 = false;
                    }

                    //this check diagonal down and left
                    place = index;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count7 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count7 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.White)
                            {
                                count7 = true;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count7 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count7 = false;
                    }

                    //this check diagonal down and right
                    place = index;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.White)
                                {
                                    count8 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Black)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count8 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.White)
                            {
                                count8 = true;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Black)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count8 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count8 = false;
                    }
                    if (count1 == true || count2 == true || count3 == true || count4 == true || count5 == true || count6 == true || count7 == true || count8 == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (boardSize1 == 82)
            {
                if (color == Color.Red) //Player 1
                {
                    //These methods will check for validity
                    string dir = "up";

                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Blue || arr[place - length1].BackColor == Color.Green)
                            {
                                count1 = true;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count1 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count1 = false;
                    }

                    //this check vertical down
                    place = index;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Blue || arr[place + length1].BackColor == Color.Green)
                            {
                                count2 = true;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count2 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count2 = false;
                    }

                    //this check horizontal left
                    place = index;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Blue || arr[place - 1].BackColor == Color.Green)
                            {
                                count3 = true;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count3 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count3 = false;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count3 = false;
                    }

                    //this check horizontal right
                    place = index;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Blue || arr[place + 1].BackColor == Color.Green)
                            {
                                count4 = true;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count4 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Black)
                                {
                                    count4 = false;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count4 = false;
                    }

                    //this check diagonal up and left
                    place = index;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count5 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count5 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Blue || arr[place - length1 - 1].BackColor == Color.Green)
                            {
                                count5 = true;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count5 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count5 = false;
                    }

                    //this check diagonal up and right
                    place = index;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count6 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count6 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Blue || arr[(place - length1) + 1].BackColor == Color.Green)
                            {
                                count6 = true;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count6 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count6 = false;
                    }

                    //this check diagonal down and left
                    place = index;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count7 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count7 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Blue || arr[(place + length1) - 1].BackColor == Color.Green)
                            {
                                count7 = true;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count7 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count7 = false;
                    }

                    //this check diagonal down and right
                    place = index;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Green)
                                {
                                    count8 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Red)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count8 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Blue || arr[place + length1 + 1].BackColor == Color.Green)
                            {
                                count8  = true;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Red)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count8 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count8 = false;
                    }
                    if (count1 == true || count2 == true || count3 == true || count4 == true || count5 == true || count6 == true || count7 == true || count8 == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (color == Color.Blue)//Player 2
                {
                    //These methods will check for validity
                    string dir = "up";

                    //this check vertical up for Blue.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Green || arr[place - length1].BackColor == Color.Red)
                            {
                                count1  = true;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count1 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        count1 = false;
                    }

                    //this check vertical down
                    place = index;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Green || arr[place + length1].BackColor == Color.Red)
                            {
                                count2  = true;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count2 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count2 = false;
                    }

                    //this check horizontal left
                    place = index;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Green || arr[place - 1].BackColor == Color.Red)
                            {
                                count3  = true;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count3 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count3 = false;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count3 = false;
                    }

                    //this check horizontal right
                    place = index;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Green || arr[place + 1].BackColor == Color.Red)
                            {
                                count4  = true;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count4 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count4 = false;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count4 = false;
                    }

                    //this check diagonal up and left
                    place = index;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count5 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count5 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Green || arr[place - length1 - 1].BackColor == Color.Red)
                            {
                                count5  = true;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count5 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count5 = false;
                    }

                    //this check diagonal up and right
                    place = index;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count6 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count6 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Green || arr[(place - length1) + 1].BackColor == Color.Red)
                            {
                                count6  = true;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count6 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count6 = false;
                    }

                    //this check diagonal down and left
                    place = index;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count7 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count7 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Green || arr[(place + length1) - 1].BackColor == Color.Red)
                            {
                                count7  = true;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count7 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count7 = false;
                    }

                    //this check diagonal down and right
                    place = index;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Green || arr[place].BackColor == Color.Red)
                                {
                                    count8 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Blue)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count8 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Green || arr[place + length1 + 1].BackColor == Color.Red)
                            {
                                count8  = true;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Blue)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count8 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count8 = false;
                    }
                    if (count1 == true || count2 == true || count3 == true || count4 == true || count5 == true || count6 == true || count7 == true || count8 == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (color == Color.Green)//Player 3
                {
                    //These methods will check for validity
                    string dir = "up";

                    //this check vertical up for white.
                    try
                    {
                        while (place > 0) //calculation works
                        {
                            if (arr[place - length1].BackColor == Color.Blue || arr[place - length1].BackColor == Color.Red)
                            {
                                count1  = true;
                                place = place - length1;
                            }
                            else if (arr[place - length1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place - length1].BackColor == Color.Gray)
                            {
                                count1 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count1 = false;
                    }

                    //this check vertical down
                    place = index;
                    dir = "down";
                    try
                    {
                        while (place < boardSize1) //calculation works.
                        {
                            //this check vertical down for white.
                            if (arr[place + length1].BackColor == Color.Blue || arr[place + length1].BackColor == Color.Red)
                            {
                                count2  = true;
                                place = place + length1;
                            }
                            else if (arr[place + length1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place + length1].BackColor == Color.Gray)
                            {
                                count2 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count2 = false;
                    }

                    //this check horizontal left
                    place = index;
                    dir = "left";
                    try
                    {
                        while (place > length1 * ((int)Math.Ceiling(((double)index - length1) / length1))) //calculation works now
                        {
                            if (arr[place - 1].BackColor == Color.Blue || arr[place - 1].BackColor == Color.Red)
                            {
                                count3  = true;
                                place = place - 1;
                            }
                            else if (arr[place - 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place - 1].BackColor == Color.Gray)
                            {
                                count3 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == (length1 * ((int)Math.Ceiling(((double)index - length1) / length1)))) //this will turn out to be numbers on the left edge
                            { //if the leftmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count3 = false;
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        count3 = false;
                    }

                    //this check horizontal right
                    place = index;
                    dir = "right";
                    try
                    {
                        while (place < length1 * ((index + length1) / length1) + 1) //no need for ceiling function. automatically rounds down.
                        { //calculation works now.
                            if (arr[place + 1].BackColor == Color.Blue || arr[place + 1].BackColor == Color.Red)
                            {
                                count4  = true;
                                place = place + 1;
                            }
                            else if (arr[place + 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place + 1].BackColor == Color.Gray)
                            {
                                count4 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                            if (place == length1 * ((index + length1) / length1)) //this will turn out to be numbers on the right edge
                            { //if the rightmost space is also black, and no whites are inbetween, then cancel.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count4 = false;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count4 = false;
                    }

                    //this check diagonal up and left
                    place = index;
                    dir = "upLeft";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count5 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count5 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place - length1 - 1].BackColor == Color.Blue || arr[place - length1 - 1].BackColor == Color.Red)
                            {
                                count5  = true;
                                place = place - length1 - 1;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place - length1 - 1].BackColor == Color.Gray)
                            {
                                count5 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count5 = false;
                    }

                    //this check diagonal up and right
                    place = index;
                    dir = "upRight";
                    try
                    {
                        while (place > 0)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count6 = true;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count6 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place - length1) + 1].BackColor == Color.Blue || arr[(place - length1) + 1].BackColor == Color.Red)
                            {
                                count6  = true;
                                place = (place - length1) + 1;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[(place - length1) + 1].BackColor == Color.Gray)
                            {
                                count6 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count6 = false;
                    }

                    //this check diagonal down and left
                    place = index;
                    dir = "downLeft";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1) + 1)
                            { //if we are on the left edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count7 = false;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count7 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[(place + length1) - 1].BackColor == Color.Blue || arr[(place + length1) - 1].BackColor == Color.Red)
                            {
                                count7  = true;
                                place = (place + length1) - 1;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[(place + length1) - 1].BackColor == Color.Gray)
                            {
                                count7 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count7 = false;
                    }

                    //this check diagonal down and right
                    place = index;
                    dir = "downRight";
                    try
                    {
                        while (place < boardSize1)
                        {
                            if (place == length1 * (place / length1))
                            { //if we are on the right edge of the board, we'll check then break
                                //this will prevent continuing in weird locations.
                                if (arr[place].BackColor == Color.Blue || arr[place].BackColor == Color.Red)
                                {
                                    count8 = false;
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Green)
                                {
                                    break;
                                }
                                else if (arr[place].BackColor == Color.Gray)
                                {
                                    count8 = false;
                                    break;
                                }
                                else
                                {
                                    Skip(color);
                                    break;
                                }
                            }
                            if (arr[place + length1 + 1].BackColor == Color.Blue || arr[place + length1 + 1].BackColor == Color.Red)
                            {
                                count8  = true;
                                place = place + length1 + 1;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Green)
                            {
                                break;
                            }
                            else if (arr[place + length1 + 1].BackColor == Color.Gray)
                            {
                                count8 = false;
                                break;
                            }
                            else
                            {
                                Skip(color);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        count8 = false;
                    }
                    if (count1 == true || count2 == true || count3 == true || count4 == true || count5 == true || count6 == true || count7 == true || count8 == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void lbl_click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((Button)sender).Tag);
            if (LabelWinner.Visible == false)
            {
                if (boardSize1 == 65) //two player
                { //This if statements changes the selected button to the appropriate color. disables it after selection.
                    if (button_White.Visible == true && Convert.ToInt32(arr[index].Text) == index)
                    {
                        bool valid = Check(index, Color.White); //check to make sure move is valid.
                        if (valid)
                        {
                            arr[index].BackColor = Color.White;
                            arr[index].ForeColor = Color.White;
                            button_White.Visible = false;
                            button_Black.Visible = true;

                            arr[index].Enabled = false;
                            check(index, Color.White);
                        }

                    }
                    else if (button_Black.Visible == true && Convert.ToInt32(arr[index].Text) == index)
                    {
                        bool valid = Check(index, Color.Black);
                        if (valid)
                        {
                            arr[index].BackColor = Color.Black;
                            arr[index].ForeColor = Color.Black;
                            button_White.Visible = true;
                            button_Black.Visible = false;

                            arr[index].Enabled = false;
                            check(index, Color.Black);
                        }

                    }
                }
                else if (boardSize1 == 82)
                {
                    if (button_Red.Visible == true && Convert.ToInt32(arr[index].Text) == index) // && arr[index].Text != "X" && arr[index].Text != "O")
                    {
                        bool valid = Check(index, Color.Red); //check to make sure move is valid.
                        if (valid)
                        {
                            arr[index].BackColor = Color.Red;
                            arr[index].ForeColor = Color.Red;
                            button_Red.Visible = false;
                            button_Blue.Visible = true;

                            arr[index].Enabled = false;
                            check(index, Color.Red);
                        }

                    }
                    else if (button_Blue.Visible == true && Convert.ToInt32(arr[index].Text) == index)
                    {
                        bool valid = Check(index, Color.Blue);
                        if (valid)
                        {
                            arr[index].BackColor = Color.Blue;
                            arr[index].ForeColor = Color.Blue;
                            button_Blue.Visible = false;
                            button_Green.Visible = true;

                            arr[index].Enabled = false;
                            check(index, Color.Blue);
                        }

                    }
                    else if (button_Green.Visible == true && Convert.ToInt32(arr[index].Text) == index)
                    {
                        bool valid = Check(index, Color.Green);
                        if (valid)
                        {
                            arr[index].BackColor = Color.Green;
                            arr[index].ForeColor = Color.Green;
                            button_Green.Visible = false;
                            button_Red.Visible = true;

                            arr[index].Enabled = false;
                            check(index, Color.Green);
                        }

                    }
                }
                Results();
                if (Game())
                {
                    label1.Text = getWinner();
                }
            }
        }
        private void Skip(Color color)
        {
            if (color == Color.White)
            {
                button_White.Visible = false;
                button_Black.Visible = true;
            }
            else if (color == Color.Black)
            {
                button_White.Visible = true;
                button_Black.Visible = false;
            }
            else if (color == Color.Red)
            {
                button_Red.Visible = false;
                button_Blue.Visible = true;
            }
            else if (color == Color.Blue)
            {
                button_Blue.Visible = false;
                button_Green.Visible = true;
            }
            else if (color == Color.Green)
            {
                button_Green.Visible = false;
                button_Red.Visible = true;
            }
        }
        private String getWinner()
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            if (boardSize1 == 65) //score if game two player
            {
                for (int i = 1; i < boardSize1; i++)
                {
                    if (arr[i].BackColor == Color.White)
                        p1++;
                    else
                        p2++;
                }
                if (p1 > p2)
                {
                    return "Player 1 Wins!";
                }
                else if (p2 > p1)
                {
                    return "Player 2 Wins!";
                }
                else
                {
                    return "There was a tie";
                }
            }
            else if (boardSize1 == 82) //score if game three player
            {
                for (int i = 1; i < boardSize1; i++)
                {
                    if (arr[i].BackColor == Color.Red)
                        p1++;
                    else if (arr[i].BackColor == Color.Red)
                        p2++;
                    else
                        p3++;
                }
                if (p1 > p2 && p1 > p3)
                {
                    return "Player 1 Wins!";
                }
                else if (p2 > p1 && p2 > p3)
                {
                    return "Player 2 Wins!";
                }
                else if (p3 > p1 && p3 > p2)
                {
                    return "Player 3 Wins!";
                }
                else
                {
                    return "There was a tie";
                }
            }
            else
                return "Tie across the board.";
            
        }
        private void Results()
        { //updates results after every play
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            if (boardSize1 == 65)
            {
                for (int i = 1; i < boardSize1; i++)
                {
                    if (arr[i].BackColor == Color.Black)
                        p1++;
                    else if (arr[i].BackColor == Color.White)
                        p2++;
                }

                if (p1 == 0) //aka white has lost all pieces
                {
                    LabelWinner.Text = "Player 2 Wins!";
                }
                else if (p2 == 0)
                {
                    LabelWinner.Text = "Player 2 Wins!";
                }
                else
                    label1.Text = "Player 1: " + p1.ToString() + "\nPlayer 2: " + p2.ToString();
            }
            else if(boardSize1 == 82)
            {
                for (int i = 1; i < boardSize1; i++)
                {
                    if (arr[i].BackColor == Color.Red)
                        p1++;
                    else if (arr[i].BackColor == Color.Blue)
                        p2++;
                    else if (arr[i].BackColor == Color.Green)
                        p3++;
                }
                label1.Text = "Player 1: " + p1.ToString() + "\nPlayer 2: " + p2.ToString() + "\nPlayer 3: " + p3.ToString(); ;
            }
        }
        private Boolean Game() //checks to see if all the squares have been filled.
        {
            bool done = true;
            for (int i = 1; i < boardSize1; i++)
            {
                if (arr[i].BackColor == Color.Gray)
                {
                    done = false;
                    return done;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainScreen form2 = new MainScreen();
            form2.Show();
        }
    }
}