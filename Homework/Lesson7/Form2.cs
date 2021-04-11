using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    public partial class Form2 : Form
    {
        private readonly int MIN_VALUE = 1;
        private readonly int MAX_VALUE = 100;

        private int goalNumber;
        private int countAttempts;

        public Form2()
        {
            InitializeComponent();

            lblTitle.Text = $"Please guess my number\nfrom {MIN_VALUE} to {MAX_VALUE}";

            ResetGame();
        }

        private void ResetGame()
        {
            lblInfo.Text = "";
            goalNumber = new Random().Next(MIN_VALUE, MAX_VALUE);
            countAttempts = 0;
        }

        private void GameOver()
        {
            MessageBox.Show(
                $"Congratulation!\nMy number is {goalNumber}\nThe amount of your attempts is {countAttempts}",
                "You won!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            ResetGame();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            bool validInput = int.TryParse(txtInput.Text, out int guessedNumber);
            if (validInput)
            {
                countAttempts++;
                if (guessedNumber < goalNumber)
                {
                    lblInfo.Text = $"My number is over {guessedNumber}";
                }
                else if (guessedNumber > goalNumber)
                {
                    lblInfo.Text = $"My number is less than {guessedNumber}";
                }
                else
                {
                    GameOver();
                }
            }
            else
            {
                MessageBox.Show(
                    "Please input a number",
                    "Incorrect input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            txtInput.Text = "";
        }
    }
}
