using System.Collections.Generic;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson3
{
    public class Exercise3 : BaseExercise
    {
        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "С клавиатуры вводятся числа, пока не будет введен 0.\r\nПодсчитать сумму всех нечетных положительных чисел.";

        public override string Name { get; set; } = "Подсчитать сумму всех нечетных положительных чисел.";

        public List<double> Numbers { get; private set; }

        public double Sum { get; private set; }

        protected override void ExecuteExercise() {
            GetNumbers();
            SetSum();
        }

        private void GetNumbers() {
            Numbers = new List<double>();
            string messageForUser = "Enter the number (0 for stop) ";
            double newNum = GetDoubleFromUserDate(messageForUser);
            while (newNum > 0 || newNum < 0) {
                Numbers.Add(newNum);
                newNum = GetDoubleFromUserDate(messageForUser);
            }
        }

        private void SetSum() {
            Sum = 0;
            List<double> positiveNumbers = Numbers.FindAll(num => num > 0);
            foreach (double number in positiveNumbers) {
                Sum += number;
            }
        }

        protected override void SetResult() {
            Result = $"Total numbers: {Numbers.Count}\r\n" + 
                     $"The sum of positive: {Sum}";
        }
    }
}
