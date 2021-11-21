using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise6 : BaseExercise
    {
        public Exercise6(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. " +
                                                           "«Хорошим» называется число, которое делится на сумму своих цифр. " +
                                                           "Реализовать подсчёт времени выполнения программы, используя структуру DateTime.";

        public override string Name { get; set; } = "Подсчета количества «хороших» чисел.";

        public int Count { get; private set; } = 1;

        public TimeSpan ProgramExecutionTime { get; private set; }

        protected override void ExecuteExercise() {
            DateTime startDateTime = DateTime.Now;
            SetCount();
            var currentTime = DateTime.Now;
            ProgramExecutionTime = currentTime.Subtract(startDateTime);
        }

        protected override void SetResult() {
            var executionTime = ProgramExecutionTime.ToString("G");
            Result = $"The number or good numbers between 1 and 1000000 is {Count}\r\nProgram execution time {executionTime}";
        }

        private void SetCount() {
            for (int i = 1; i < 1000000000; i++) {
                if (IsGoodNumber(i)) {
                    Count++;
                }
            }
        }

        private bool IsGoodNumber(long number) {
            int digitsSum = GetDigitsSumOfNumber(number.ToString());
            return number % digitsSum == 0;
        }

        private int GetDigitsSumOfNumber(string stringNumber) {
            var result = 0;
            foreach (char digit in stringNumber) {
                result += int.Parse($"{digit}");
            }

            return result;
        }
    }
}
