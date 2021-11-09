using System;
using System.Collections.Generic;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise6: BaseExercise
    {
        public Exercise6(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. " +
                                                           "«Хорошим» называется число, которое делится на сумму своих цифр. " +
                                                           "Реализовать подсчёт времени выполнения программы, используя структуру DateTime.";

        public override string Name { get; set; } = "Подсчета количества «хороших» чисел.";

        public int num1 { get; private set; }

        public int num2 { get; private set; }

        protected override void ExecuteExercise() {
            GetNumbers();
            ChangeNumbersValue();
        }

        private void ChangeNumbersValue() {
            Result = String.Empty;
            SetResult();

            //var temp = num1;
            //num1 = num2;
            //num2 = temp;
            var ints = new Stack<int>();
            ints.Push(num1);
            ints.Push(num2);
            num1 = ints.Pop();
            num2 = ints.Pop();
        }

        private void GetNumbers() {
            Console.Write("Enter first number ");
            string stringNum1 = Console.ReadLine();

            Console.Write("Enter second number ");
            string stringNum2 = Console.ReadLine();

            num1 = Convert.ToInt32(stringNum1);
            num2 = Convert.ToInt32(stringNum2);
        }

        protected override void SetResult() {
            Result += $"First number: {num1} second number: {num2}";
        }
    }
}
