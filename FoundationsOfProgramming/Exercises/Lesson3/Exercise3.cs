using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.ForExercises;

namespace FoundationsOfProgramming.Exercises.Lesson3
{
    public class Exercise3 : Exercise1
    {
        private FractionalNumber firstNumber;

        private FractionalNumber secondNumber;

        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "С клавиатуры вводятся числа, пока не будет введен 0.\r\nПодсчитать сумму всех нечетных положительных чисел.";

        public override string Name { get; set; } = "Подсчитать сумму всех нечетных положительных чисел.";

        public List<double> Numbers { get; private set; }

        public double Sum { get; private set; }

        protected override void ExecuteExercise() {
            FractionalNumber[] complexNumbers = GetComplexNumbers();
            firstNumber = complexNumbers[0];
            secondNumber = complexNumbers[1];
        }

        protected override void SetResult() {
            Result = $"({firstNumber}) + ({secondNumber}) = {firstNumber + secondNumber}\n" +
                     $"({firstNumber}) - ({secondNumber}) = {firstNumber - secondNumber}\n" +
                     $"({firstNumber}) * ({secondNumber}) = {firstNumber * secondNumber}\n" +
                     $"({firstNumber}) / ({secondNumber}) = {firstNumber / secondNumber}";
        }

        private FractionalNumber[] GetComplexNumbers() {
            var fractionalNumberName = "fractional number";
            int termOfFirstNumber = GetInt32FromUserDate($"Your term of first {fractionalNumberName} number: ");
            int nominatorOfFirstNumber = GetInt32FromUserDate($"Your nominator of first {fractionalNumberName} number: ");
            int termOfSecondNumber = GetInt32FromUserDate($"Your term second of {fractionalNumberName} number: ");
            int nominatorOfSecondNumber = GetInt32FromUserDate($"Your nominator of second {fractionalNumberName} number: ");

            return new[] {
                new FractionalNumber(termOfFirstNumber, nominatorOfFirstNumber),
                new FractionalNumber(termOfSecondNumber, nominatorOfSecondNumber)
            };
        }
    }
}
