﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson1
{
    public class Exercise4: BaseExercise
    {
        public override string Description { get; set; } = "Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.\r\nа) с использованием третьей переменной;\r\nб) *без использования третьей переменной.";

        public override string Name { get; set; } = "Написать программу обмена значениями двух переменных типа int";

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
