using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TicTacToe1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool checker = false; // для розуміння черговості ходу 
        int plusone;

        void Enable_False()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        void ResetGame()
        {
           
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            button1.BackColor = DefaultBackColor;
            button2.BackColor = DefaultBackColor;
            button3.BackColor = DefaultBackColor;
            button4.BackColor = DefaultBackColor;
            button5.BackColor = DefaultBackColor;
            button6.BackColor = DefaultBackColor;
            button7.BackColor = DefaultBackColor;
            button8.BackColor = DefaultBackColor;
            button9.BackColor = DefaultBackColor;

         
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

           
            checker = false;
        }

        void NewGame()
        {
            
            ResetGame();

            label3.Text = "0"; 
            label4.Text = "0"; 
        }

        void score()
        {
            if (CheckWin(button1, button2, button3) || CheckWin(button4, button5, button6) ||
                CheckWin(button7, button8, button9) || CheckWin(button1, button4, button7) ||
                CheckWin(button2, button5, button8) || CheckWin(button3, button6, button9) ||
                CheckWin(button1, button5, button9) || CheckWin(button3, button5, button7))
            {
                return; 
            }
        }

        bool CheckWin(Button b1, Button b2, Button b3)
        {
            if (b1.Text != "" && b1.Text == b2.Text && b2.Text == b3.Text)
            {
                Color winColor = b1.Text == "X" ? Color.Blue : Color.Pink;

                b1.BackColor = winColor;
                b2.BackColor = winColor;
                b3.BackColor = winColor;

                string winner = b1.Text == "X" ? "Гравець Х" : "Гравець O";
                MessageBox.Show($"Переможець {winner}", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
                Label scoreLabel = b1.Text == "X" ? label3 : label4;
                if (int.TryParse(scoreLabel.Text, out int currentScore))
                {
                    scoreLabel.Text = (currentScore + 1).ToString();
                }
                else
                {
                    scoreLabel.Text = "1"; 
                }

                Enable_False(); 
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e) { MakeMove(button1); }
        private void button2_Click(object sender, EventArgs e) { MakeMove(button2); }
        private void button3_Click(object sender, EventArgs e) { MakeMove(button3); }
        private void button4_Click(object sender, EventArgs e) { MakeMove(button4); }
        private void button5_Click(object sender, EventArgs e) { MakeMove(button5); }
        private void button6_Click(object sender, EventArgs e) { MakeMove(button6); }
        private void button7_Click(object sender, EventArgs e) { MakeMove(button7); }
        private void button8_Click(object sender, EventArgs e) { MakeMove(button8); }
        private void button9_Click(object sender, EventArgs e) { MakeMove(button9); }

        void MakeMove(Button button)
        {
            if (button.Text == "")
            {
                button.Text = checker ? "O" : "X";
                checker = !checker;
                button.Enabled = false;
                score();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "0"; 
            label4.Text = "0"; 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetGame(); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NewGame(); 
        }
    }
}



