using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2048
{
    public partial class GameForm : Form
    {
        MainSquare mainSquare = new MainSquare();
        GameLogic gm = new GameLogic();
        public GameForm()
        {
            InitializeComponent();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            gm.Start(ref mainSquare);
            mainSquare.Score = 0;
            Refresh();
            ScoreTextBox.Text = Convert.ToString(mainSquare.Score);
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font("Arial", 32);
            SolidBrush b = new SolidBrush(Color.Black);
            Pen p = new Pen(Color.Black);
            e.Graphics.DrawLine(p, 100, 0, 100, 400);
            e.Graphics.DrawLine(p, 200, 0, 200, 400);
            e.Graphics.DrawLine(p, 300, 0, 300, 400);
            e.Graphics.DrawLine(p, 0, 100, 400, 100);
            e.Graphics.DrawLine(p, 0, 200, 400, 200);
            e.Graphics.DrawLine(p, 0, 300, 400, 300);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mainSquare.SquareMatrix[i, j] != 0)
                    {
                        if (mainSquare.SquareMatrix[i, j] < 10)
                            e.Graphics.DrawString(Convert.ToString(mainSquare.SquareMatrix[i, j]), f, b, 25 + 100 * i, 25 + 100 * j);
                        else if (mainSquare.SquareMatrix[i, j] > 10 && mainSquare.SquareMatrix[i, j] < 100)
                            e.Graphics.DrawString(Convert.ToString(mainSquare.SquareMatrix[i, j]), f, b, 20 + 100 * i, 25 + 100 * j);
                        else if (mainSquare.SquareMatrix[i, j] > 100 && mainSquare.SquareMatrix[i, j] < 1000)
                            e.Graphics.DrawString(Convert.ToString(mainSquare.SquareMatrix[i, j]), f, b, 5 + 100 * i, 25 + 100 * j);
                        else if (mainSquare.SquareMatrix[i, j] > 1000 && mainSquare.SquareMatrix[i, j] < 10000)
                            e.Graphics.DrawString(Convert.ToString(mainSquare.SquareMatrix[i, j]), f, b, 100 * i, 25 + 100 * j);
                        else 
                            e.Graphics.DrawString(Convert.ToString(mainSquare.SquareMatrix[i, j]), f, b, 25 + 100 * i, 25 + 100 * j);
                    }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            gm.Start(ref mainSquare);
            Invalidate();
        }
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    gm.MoveUp(ref mainSquare);
                    Refresh();
                    ScoreTextBox.Text = Convert.ToString(mainSquare.Score);
                    break;
                case Keys.S:
                    gm.MoveDown(ref mainSquare);
                    Refresh();
                    ScoreTextBox.Text = Convert.ToString(mainSquare.Score);
                    break;
                case Keys.D:
                    gm.MoveRight(ref mainSquare);
                    Refresh();
                    ScoreTextBox.Text = Convert.ToString(mainSquare.Score);
                    break;
                case Keys.A:
                    gm.MoveLeft(ref mainSquare);
                    Refresh();
                    ScoreTextBox.Text = Convert.ToString(mainSquare.Score);
                    break;
                default:
                    break;
            }
        }

    }
}
