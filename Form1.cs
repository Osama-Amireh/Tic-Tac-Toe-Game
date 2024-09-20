using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_GameF.Properties;

namespace Tic_Tac_Toe_GameF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        enum enWinner
        {
            player1, player2, Draw, InProgress
        };
        struct stGameStatues
        {
            public enWinner Winner;
            public bool GameOver;
            public short PalyCount;
        }
        stGameStatues GameStatues;

enPlayerTurn PlayerTurn = enPlayerTurn.player1;
        enum enPlayerTurn {player1,player2 }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255);
            Pen pen = new Pen(White);
            pen.Width = 15;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            e.Graphics.DrawLine(pen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(pen, 400, 460, 1050, 460);
            e.Graphics.DrawLine(pen, 610, 140, 610, 620);
            e.Graphics.DrawLine(pen, 840, 140, 840, 620);
        }
        void endGame()
        {
            LBPlayer.Text="Game Over";
            switch (GameStatues.Winner)
            {
                case enWinner.player1:
                    {
                        LBFinalresult.Text = "Player 1";
                        break;
                    }
                case enWinner.player2:
                    {
                        LBFinalresult.Text = "Player 2";
                        break;
                    }
                case enWinner.Draw:
                    {
                        LBFinalresult.Text = "Draw";
                        break;
                    }

            }

            MessageBox.Show("Game Over","Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        bool checkValue(Button btn1, Button btn2, Button btn3)
        {
            if(btn1.Tag.ToString()== btn2.Tag.ToString()&&btn3.Tag.ToString()==btn2.Tag.ToString()&&btn1.Tag.ToString()!="?")
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor=Color.GreenYellow; 
                btn3.BackColor=Color.GreenYellow;
                if(btn1.Tag.ToString()=="X")
                {
                    GameStatues.Winner = enWinner.player1;
                    GameStatues.GameOver = true;
                    endGame();
                }
                else
                {
                    GameStatues.Winner = enWinner.player2;
                    GameStatues.GameOver = true;
                    endGame();
                }
                return true;
            }
            if (GameStatues.PalyCount == 9)
            {
                GameStatues.Winner = enWinner.Draw;
                GameStatues.GameOver = true;
                endGame();
                return true;
            }
            else
            {
                GameStatues.Winner = enWinner.InProgress;
                GameStatues.GameOver = false;
            }
            return false;
        }
        void CheckWinner()
        {

            if (checkValue(button1, button2, button3))
                return;
            if (checkValue(button4, button5, button6))
                return;
            if (checkValue(button7, button8, button9))
                return;
            if (checkValue(button1, button4, button7))
                return;
            if (checkValue(button2, button5, button8))
                return;
            if (checkValue(button3, button6, button9))
                return;
            if (checkValue(button1, button5, button9))
                return;
            if (checkValue(button3, button5, button7))
                return;


        }
        void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?"&&GameStatues.GameOver != true)
            {
                switch (PlayerTurn)
                {
                    case enPlayerTurn.player1 :
                        {
                            btn.Image = Resources.X;
                            PlayerTurn = enPlayerTurn.player2;
                            GameStatues.PalyCount++;
                            LBPlayer.Text = "Player 2";
                            btn.Tag = "X";
                            CheckWinner();
                            break;
                        }
                    case enPlayerTurn.player2:
                        {


                            btn.Image = Resources.O;
                            PlayerTurn = enPlayerTurn.player1;
                            GameStatues.PalyCount++;
                            LBPlayer.Text = "Player 1";
                            btn.Tag = "O";

                            CheckWinner();
                            break;
                        }


                }

            }
            else 
            {
                MessageBox.Show("Wrong Choose", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);

        }
     
        void ResetButton(Button Btn)
        {
            Btn.Image = Resources.question_mark_96;
            Btn.Tag = "?";
            Btn.BackColor = Color.Transparent;

        }
        private void BTNRestart_Click(object sender, EventArgs e)
        {
            ResetButton(button1);
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);

            PlayerTurn = enPlayerTurn.player1;
            LBPlayer.Text = "Player 1";
            GameStatues.PalyCount = 0;
            GameStatues.GameOver = false;
            GameStatues.Winner = enWinner.InProgress;
            LBFinalresult.Text = "In Progress";


        }
    }
}
