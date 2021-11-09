using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise3 : BaseExercise
    {
        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "С клавиатуры вводятся числа, пока не будет введен 0.\r\nПодсчитать сумму всех нечетных положительных чисел.";

        public override string Name { get; set; } = "Подсчитать сумму всех нечетных положительных чисел.";

        public double x1 { get; set; }

        public double x2 { get; set; }

        public double y1 { get; set; }

        public double y2 { get; set; }

        public double distance { get; set; }

        protected override void ExecuteExercise() {
            GetPoints();
        }

        private void GetPoints() {
            Console.Write("Enter first point coordinates using whitespace (for example \"1 3\" where 1 - x, 3 - y)");
            string firstPoint = Console.ReadLine();

            Console.Write("Enter second point coordinates using whitespace (for example \"1 3\" where 1 - x, 3 - y)");
            string secondPoint = Console.ReadLine();

            ParsePoints(firstPoint, secondPoint);
        }

        private void ParsePoints(string firstPoint, string secondPoint) {
            string[] firstPointCoordinates = firstPoint.Split(' ');
            string[] secondPointCoordinates = secondPoint.Split(' ');

            x1 = Convert.ToDouble(firstPointCoordinates[0]);
            y1 = Convert.ToDouble(firstPointCoordinates[1]);
            x2 = Convert.ToDouble(secondPointCoordinates[0]);
            y2 = Convert.ToDouble(secondPointCoordinates[1]);
        }

        protected override void SetResult() {
            distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Result = $"The {nameof(distance)} of points A({x1},{y1}) B({x2},{y2}) is {distance}";
        }
    }
}
