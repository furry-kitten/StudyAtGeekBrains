using System.Collections.Generic;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise3 : BaseExercise
    {
        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "С клавиатуры вводятся числа, пока не будет введен 0. " +
                                                           "Подсчитать сумму всех нечетных положительных чисел.";

        public override string Name { get; set; } = "Подсчитать сумму всех нечетных положительных чисел.";

        public List<double> Numbers { get; protected set; }

        public double Sum { get; protected set; }

        protected override void ExecuteExercise() {
            GetNumbers();
            SetSum();
        }

        protected virtual void GetNumbers() {
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
                if(number % 2 == 1) {
                    Sum += number;
                }
            }
        }

        protected override void SetResult() {
            Result = $"Total numbers: {Numbers.Count}\r\n" +
                     $"The sum of positive: {Sum}";
        }
    }
}
