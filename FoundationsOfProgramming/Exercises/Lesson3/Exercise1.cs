using System;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.ForExercises;

namespace FoundationsOfProgramming.Exercises.Lesson3
{
    public class Exercise1 : BaseExercise
    {
        private Complex firstNumber;

        private Complex secondNumber;

        internal Complex Multiple { get; private set; }

        internal Complex Summary { get; private set; }

        internal Complex Difference { get; private set; }

        public Exercise1(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.\r\n" +
                                                           "а) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.\r\n" +
                                                           "б) Добавить диалог с использованием switch демонстрирующий работу класса.";

        public override string Name { get; set; } = "Дописать структуру Complex.";

        protected override void ExecuteExercise() {
            Complex[] complexNumbers = GetComplexNumbers();
            firstNumber = complexNumbers[0];
            secondNumber = complexNumbers[1];

            Multiple = firstNumber.Multiplication(secondNumber);
            Summary = firstNumber.Plus(secondNumber);
            Difference = firstNumber.Minus(secondNumber);

            ShowAllVariants();
        }

        protected override void SetResult() {
            //Result = $"({firstNumber}) + ({secondNumber}) = {Summary} ({firstNumber + secondNumber})\n" +
            //         $"({firstNumber}) - ({secondNumber}) = {Difference} ({firstNumber - secondNumber})\n" +
            //         $"({firstNumber}) * ({secondNumber}) = {Multiple} ({firstNumber * secondNumber})";
        }

        private void ShowAllVariants() {
            var key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Escape) {
                key = GetChoice();
                GetAction(key.Key);
            }
        }

        private ConsoleKeyInfo GetChoice() {
            Console.WriteLine();
            Console.WriteLine($"To get the result of summing of {firstNumber} and {secondNumber} press '+'");
            Console.WriteLine($"To get the result of subtracting of {firstNumber} and {secondNumber} press '-'");
            Console.WriteLine($"To get the result of multiplying of {firstNumber} and {secondNumber} press '*'");


            return Console.ReadKey(true);
        }

        private void GetAction(ConsoleKey key) {
            switch (key) {
                case ConsoleKey.OemMinus:
                case ConsoleKey.Subtract:
                    Result = $"({firstNumber}) - ({secondNumber}) = {Difference}\tusing operator ({firstNumber - secondNumber})";
                    GetResult();
                    break;
                case ConsoleKey.OemPlus:
                case ConsoleKey.Add:
                    Result = $"({firstNumber}) + ({secondNumber}) = {Summary}\tusing operator ({firstNumber + secondNumber})";
                    GetResult();
                    break;
                case ConsoleKey.Multiply:
                    Result = $"({firstNumber}) * ({secondNumber}) = {Multiple}\tusing operator ({firstNumber * secondNumber})";
                    GetResult();
                    break;
            }
        }

        private Complex[] GetComplexNumbers() {
            int realPartOfFirstNumber = GetInt32FromUserDate($"Your real part of first {nameof(Complex)} number: ");
            int imaginaryPartOfFirstNumber = GetInt32FromUserDate($"Your imaginary component of first {nameof(Complex)} number: ");
            int realPartOfSecondNumber = GetInt32FromUserDate($"Your real part of second {nameof(Complex)} number: ");
            int imaginaryPartOfSecondNumber = GetInt32FromUserDate($"Your imaginary component of second {nameof(Complex)} number: ");

            return new[] {
                new Complex(realPartOfFirstNumber, imaginaryPartOfFirstNumber),
                new Complex(realPartOfSecondNumber, imaginaryPartOfSecondNumber)
            };
        }
    }
}
