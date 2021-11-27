using System;
using System.Text;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson6
{
    public class Exercise1 : BaseExercise
    {
        private StringBuilder stringBuilder = new StringBuilder();

        public delegate double Fun(double x);

        public delegate double Fun2(double x, double y);

        public Func<double, double> Func1;

        public Exercise1(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). " +
                                                           "Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).";

        public override string Name { get; set; } = "Изменить делегат.";

        protected override void SetResult() {
            Result = stringBuilder.ToString();
            stringBuilder = new StringBuilder();
        }

        protected override void ExecuteExercise() {
            double a = GetDoubleFromUserDate("Enter a = ");
            stringBuilder.AppendLine("Таблица функции MyFunc:");
            Table(MyFunc, -2, 2, a);
            stringBuilder.AppendLine("Таблица функции a*x^2:");
            Table((x, y) => y * Math.Sin(x), 0, 3, a);
        }

        public void Table(Func<double, double, double> func, double x, double b, double a) {
            stringBuilder.AppendLine("----- X ----- Y -----");
            while (x <= b) {
                stringBuilder.AppendLine($"| {x,8:F3} | {func(x, a),8:f3} |");
                x++;
            }
            stringBuilder.AppendLine("---------------------\r\n");
        }

        public double MyFunc(double x, double y) {
            return y * Math.Pow(x, 2);
        }

    }
}
