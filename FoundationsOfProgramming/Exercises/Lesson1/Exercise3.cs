using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson1
{
    public class Exercise3 : BaseExercise
    {
        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);\r\nб) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.";

        public override string Name { get; set; } = "Подсчитать расстояние между точками";

        public double X1 { get; set; }

        public double X2 { get; set; }

        public double Y1 { get; set; }

        public double Y2 { get; set; }

        public double Distance { get; set; }

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

            X1 = Convert.ToDouble(firstPointCoordinates[0]);
            Y1 = Convert.ToDouble(firstPointCoordinates[1]);
            X2 = Convert.ToDouble(secondPointCoordinates[0]);
            Y2 = Convert.ToDouble(secondPointCoordinates[1]);
        }

        protected override void SetResult() {
            Distance = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            Result = $"The {nameof(Distance)} of points A({X1},{Y1}) B({X2},{Y2}) is {Distance}";
        }
    }
}
