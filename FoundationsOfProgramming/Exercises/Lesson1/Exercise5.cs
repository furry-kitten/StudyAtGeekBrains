using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson1
{
    public class Exercise5 : BaseExercise
    {
        public Exercise5(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.\r\nб) Сделать задание, только вывод организовать в центре экрана.\r\nв) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).";

        public override string Name { get; set; } = "Вывод личных данных";

        public string PersonalData { get; set; } = "Токарев Владимир (Санкт-Петербург)";

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
