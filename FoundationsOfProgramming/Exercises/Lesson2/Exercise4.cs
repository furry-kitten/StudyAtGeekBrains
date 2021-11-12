using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise4 : BaseExercise
    {
        private const string Login = "root";

        private const string Password = "GeekBrains";

        private const string Error = "Too many attempts";

        public Exercise4(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. " +
                                                           "На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). " +
                                                           "Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. " +
                                                           "С помощью цикла do while ограничить ввод пароля тремя попытками.";

        public override string Name { get; set; } = "Аутентификация";

        public bool IsAuthorized { get; private set; }

        protected override void ExecuteExercise() {
            Authorization();
        }

        private void Authorization() {
            int i = 0;
            do {
                string login = GetStringFromUserDate($"{nameof(Login)}: ");
                string password = GetStringFromUserDate($"{nameof(Password)}: ");
                bool isLoginEqual = string.Equals(Login, login);
                bool isPasswordEqual = string.Equals(Password, password);
                IsAuthorized = isLoginEqual && isPasswordEqual;
            } while (!IsAuthorized && i++ < 2);
        }

        protected override void SetResult() {
            Result = IsAuthorized ? "Access is allowed" : $"Access denied\r\n{Error}";
        }
    }
}
