using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lesson7.Properties;

namespace Lesson7
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        private Stack<int> stack = new Stack<int>();

        private int computerNumber;

        private int userNumber;

        private int minSteps;

        private int step;

        public Form1() {
            InitializeComponent();
        }

        private void btnRestart_Click(object sender, EventArgs e) {
            UpdateGameState(userNumber = 0, random.Next(50));
        }

        private void CalculateMinSteps() {
            minSteps = 0;
            int number = computerNumber;
            while (number != 0) {
                if (number % 2 == 0) {
                    number /= 2;
                    minSteps++;
                } else {
                    number -= 1;
                    minSteps++;
                    if (number > 0) {
                        number /= 2;
                        minSteps++;
                    }
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e) {
            step++;
            AddToStack();
            UpdateGameState(++userNumber);
            CheckWin();
        }

        private void btnMultiply_Click(object sender, EventArgs e) {
            step++;
            AddToStack();
            UpdateGameState(userNumber *= 2);
            CheckWin();
        }

        private void AddToStack() {
            stack.Push(userNumber);
        }

        private void RevertFromStack() => userNumber = stack.Pop();

        private void UpdateGameState(int userNumber) {
            lbUserNumber.Text = $"{userNumber}";
        }

        private void UpdateGameState(int userNumber, int computerNumber) {
            UpdateGameState(userNumber);
            this.computerNumber = computerNumber;
            RndNumber.Text = $"{computerNumber}";
            step = 0;
            CalculateMinSteps();
        }

        private void CheckWin() {
            if (computerNumber == userNumber) {
                string message = step > minSteps ? $"Вы завершили игру за {step} шагов, а можно за {minSteps}" : $"Вы успешно завершили игру за {step} шагов";
                MessageBox.Show(message, "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    UpdateGameState(userNumber *= 0, random.Next(50));
                } else {
                    Close();
                }
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e) {
            computerNumber = random.Next(50);
            MenuPanel.Visible = false;
            btnCancel.Visible = true;
            UpdateGameState(userNumber = 0, computerNumber);
            MessageBox.Show(string.Format(Resources.FirstMessage, computerNumber, minSteps));
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            RevertFromStack();
            step--;
            UpdateGameState(userNumber);
        }
    }
}