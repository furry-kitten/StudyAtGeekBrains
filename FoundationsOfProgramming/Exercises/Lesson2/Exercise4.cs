using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise4 : BaseExercise
    {
        public Exercise4(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. " +
                                                           "На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). " +
                                                           "Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. " +
                                                           "С помощью цикла do while ограничить ввод пароля тремя попытками.";

        public override string Name { get; set; } = "Вывод личных данных";

        public string PersonalData { get; set; } = "Аутентификация";

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
