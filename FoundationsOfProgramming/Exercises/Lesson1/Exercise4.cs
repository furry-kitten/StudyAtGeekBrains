using System;
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
        public Exercise4(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.\r\nа) с использованием третьей переменной;\r\nб) *без использования третьей переменной.";

        public override string Name { get; set; } = "Написать программу обмена значениями двух переменных типа int";

        public int Num1 { get; private set; }

        public int Num2 { get; private set; }

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
            ints.Push(Num1);
            ints.Push(Num2);
            Num1 = ints.Pop();
            Num2 = ints.Pop();
        }

        private void GetNumbers() {
            Num1 = GetInt32FromUserDate("Enter first number ");
            Num2 = GetInt32FromUserDate("Enter second number ");
        }

        protected override void SetResult() {
            Result += $"First number: {Num1} second number: {Num2}";
        }
    }
}
