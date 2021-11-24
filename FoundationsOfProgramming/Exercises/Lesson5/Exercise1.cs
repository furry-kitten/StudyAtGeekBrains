using System.Text.RegularExpressions;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson5
{
    public class Exercise1 : BaseExercise
    {
        private Regex isLoginCorrectRegex = new Regex(@"^\D\w{2,9}$");

        private string login;

        public Exercise1(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Создать программу, которая будет проверять корректность ввода логина. " +
                                                           "Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:\r\n" + 
                                                           "а) без использования регулярных выражений;\r\n" +
                                                           "б) **с использованием регулярных выражений.";

        public override string Name { get; set; } = "Проверка корректности ввода.";

        protected override void SetResult() {
            string message = IsCorrect() ? "correct" : "not correct";
            //string message = isLoginCorrectRegex.IsMatch(login) ? "correct" : "not correct";
            Result = $"Login '{login}' is {message}";
        }

        protected override void ExecuteExercise() {
            login = GetStringFromUserDate($"Enter the login ");
        }

        private bool IsCorrect() {
            if (!char.IsLetter(login[0]) || login.Length > 10 || login.Length < 2) {
                return false;
            }

            foreach (char letter in login) {
                if (!char.IsLetterOrDigit(letter)) {
                    return false;
                }
            }

            return true;
        }
    }
}
