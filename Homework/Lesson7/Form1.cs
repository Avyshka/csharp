using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lesson7
{
    public partial class Form1 : Form
    {
        private readonly List<int> commands = new List<int>();
        private int value;
        private int goal;
        private int minScore;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Doubler";
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Reset";
            btnCancel.Text = "Cancel";
            lblCountCommands.Text = "0";

            pnlGame.Visible = false;
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            btnPlayGame.Enabled = false;
            pnlGame.Visible = true;
            goal = new Random().Next(20, 100);
            ResetGame();
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            value++;
            MakeStep();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            value *= 2;
            MakeStep();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (commands.Count > 0)
            {
                commands.Remove(commands[^1]);
                value = commands.Count > 0 ? commands[^1] : 1;

                PrintValue();
                PrintCountCommands();
            }
        }

        private void MakeStep()
        {
            PrintValue();
            AddCommand();
            PrintCountCommands();
            CheakGoal();
        }

        private void PrintValue()
        {
            lblNumber.Text = value.ToString();
        }

        private void PrintCountCommands()
        {
            string text = commands.Count > 0 ? $"Commands count: {commands.Count}" : "";
            lblCountCommands.Text = text;
        }

        private void PrintGoal()
        {
            lblGoal.Text = $"Your goal: {goal}";
        }

        private void AddCommand()
        {
            commands.Add(value);
        }

        private void ResetGame()
        {
            commands.Clear();
            value = 1;
            PrintValue();
            PrintCountCommands();
            PrintGoal();
            CalcBestScore(goal);
        }

        private void CheakGoal()
        {
            if (value == goal)
            {
                pnlGame.Visible = false;
                btnPlayGame.Enabled = true;
                MessageBox.Show(
                    $"Congratulation!\nYour score: {commands.Count}\nThe min score: {minScore}",
                    "You won!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void CalcBestScore(int value)
        {
            minScore = 0;
            do
            {
                if (value % 2 == 0)
                {
                    value /= 2;
                }
                else
                {
                    value--;
                }
                minScore++;
            } while (value > 1);
        }
    }
}
