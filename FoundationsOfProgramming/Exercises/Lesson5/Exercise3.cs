using System.Text;
using BasicForStuding;
using FA = FileToArray;

namespace FoundationsOfProgramming.Exercises.Lesson5
{
    public class Exercise3 : BaseExercise
    {
        private string message;

        private string secondMessage;

        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.\r\n" +
                                                           "Например: badc являются перестановкой abcd..";

        public override string Name { get; set; } = "Перестановка строк.";

        private bool IsEqual { get; set; }

        protected override void ExecuteExercise() {
            message = GetStringFromUserDate("Enter the string ");
            secondMessage = GetStringFromUserDate("Enter the string ");
            if (message.Length != secondMessage.Length) {
                return;
            }

            string stringToChange = secondMessage;
            for (int i = 0; i < message.Length; i++) {
                if (message.Equals(stringToChange)) {
                    IsEqual = true;
                    break;
                }

                stringToChange = MoveCharactersInString(stringToChange);
                IsEqual = false;
            }
        }

        protected override void SetResult() {
            Result = IsEqual ? $"'{message}' is a permutation of string '{secondMessage}'" : $"'{message}' is not a permutation of string '{secondMessage}'";
        }

        private string MoveCharactersInString(string message) {
            var strBuilder = new StringBuilder();
            strBuilder.Append(message[message.Length - 1]);

            for (int i = 0; i < message.Length - 1; i++) {
                strBuilder.Append(message[i]);
            }

            return strBuilder.ToString();
        }
    }
}
