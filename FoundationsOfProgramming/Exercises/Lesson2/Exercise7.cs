using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise7 : BaseExercise
    {
        public Exercise7(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).\r\n" +
                                                           "б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.";

        public override string Name { get; set; } = "Рекурсивный метод.";

        public double FirstNumber { get; private set; }

        public double SecondNumber { get; private set; }

        public double Sum { get; private set; } = 0;

        protected override void ExecuteExercise() {
            GetNumbers();
            WriteAllNumbersBetweenXAndY(FirstNumber);
            Sum = CalculeteSum(FirstNumber);
        }

        protected override void SetResult() {
            Result = $"Sum of all numbers between {FirstNumber} and {SecondNumber} is {Sum}";
        }

        private void GetNumbers() {
            FirstNumber = GetDoubleFromUserDate("Enter the first number ");
            SecondNumber = GetDoubleFromUserDate("Enter the second number ");
            if (FirstNumber > SecondNumber) {
                WriteExceptionMessage($"Second number must be greater than first number");
                GetNumbers();
            }
        }

        private void WriteAllNumbersBetweenXAndY(double startNumber) {
            if (startNumber > SecondNumber) {
                return;
            }

            var num1 = (int)startNumber;
            var num2 = (int)FirstNumber;
            int n = 10 - Math.Abs(num2 % 10);
            n = n == 10 ? 0 : n;
            int n1 = Math.Abs(num1) - n;
            bool isNumberTheTenth = Math.Abs(n1 % 10) == 0;
            Console.Write(isNumberTheTenth ? "\r\n" : " ");
            Console.Write($"{startNumber} ");
            WriteAllNumbersBetweenXAndY(++startNumber);
        }

        private double CalculeteSum(double startNumber) {
            if (startNumber >= SecondNumber) {
                return startNumber;
            }

            startNumber += CalculeteSum(++startNumber);

            return startNumber;
        }
    }
}
