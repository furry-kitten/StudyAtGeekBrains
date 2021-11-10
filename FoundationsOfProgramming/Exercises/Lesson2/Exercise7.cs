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

        public string PersonalData { get; set; }

        public int CursorXPosition { get; set; }

        public int CursorYPosition { get; set; }

        protected override void GetResult() {
            Console.CursorLeft = CursorXPosition;
            Console.CursorTop = CursorYPosition;
            base.GetResult();
        }

        protected override void ExecuteExercise() {
            int halfLengthPersonalData = PersonalData.Length / 2;
            int halfWidthOfCurrentWindow = Console.WindowWidth / 2;
            int halfHeightOfCurrentWindow = Console.WindowHeight / 2;
            CursorXPosition = halfWidthOfCurrentWindow - halfLengthPersonalData;
            CursorYPosition = halfHeightOfCurrentWindow;
        }

        protected override void SetResult() {
            Result = PersonalData;
        }
    }
}
