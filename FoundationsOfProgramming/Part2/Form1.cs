using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Токарев Владимир
 * Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.
   a) Для ввода данных от человека используется элемент TextBox;
   б) **Реализовать отдельную форму c TextBox для ввода числа.
 */
namespace Part2
{
    public partial class Form1 : Form
    {
        private Form2 Form2;

        private Random random = new Random();

        private int currentNumber;

        private string messageForUser;

        private int steps;

        public Form1() {
            InitializeComponent();
            Form2 = new Form2 {
                FindByChance = SetAnswer,
            };
        }

        private void btnStart_Click(object sender, EventArgs e) {
            Form2.Visible = true;
            btnStart.Enabled = false;
            steps = 0;
            GenerateNumber();
        }

        private void GenerateNumber() {
            currentNumber = random.Next(1, 100);
        }

        private void SetAnswer(int userNumber) {
            if (userNumber != currentNumber) {
                messageForUser = userNumber > currentNumber ? "Меньше" : "Больше";
            } else {
                messageForUser = $"Угадал";
                Form2.Hide();
                btnStart.Enabled = true;
            }

            Answer.Text = messageForUser + $"\nСделано попыток: {++steps}";
        }
    }
}
