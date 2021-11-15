using System;
using System.Collections.Generic;
using System.Linq;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise1 : BaseExercise
    {
        private int minNumber;

        public Exercise1(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Написать метод, возвращающий минимальное из трёх чисел.";

        public override string Name { get; set; } = "Найти минимум";

        protected override void ExecuteExercise() {
            int[] numbers = GetNumbers();
            minNumber = GetMin(numbers);
            SetResult();
        }

        protected override void SetResult() {
            Result = $"Minimum is {minNumber}";
        }

        private int[] GetNumbers() {
            int num1 = GetInt32FromUserDate($"Your first number: ");
            int num2 = GetInt32FromUserDate($"Your second number: ");
            int num3 = GetInt32FromUserDate($"Your third number: ");

            return new[] {num1, num2, num3};
        }

        private int GetMin(IEnumerable<int> numbers) {
            int min = numbers.First();
            foreach (int number in numbers) {
                if (min > number) {
                    min = number;
                }
            }

            return min;
        }
    }
}
