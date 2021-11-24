using System;
using System.Collections.Generic;
using System.Text;
using BasicForStuding;
using FileToArray;
using FoundationsOfProgramming.Exercises.ForExercises;

namespace FoundationsOfProgramming.Exercises.Lesson5
{
    public class Exercise2 : BaseExercise
    {
        public Exercise2(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "  Разработать статический класс Message, содержащий следующие статические методы для обработки текста:\r\n" +
                                                           "а) Вывести только те слова сообщения, которые содержат не более n букв.\r\n" +
                                                           "б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.\r\n" +
                                                           "в) Найти самое длинное слово сообщения.\r\n" +
                                                           "г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.";

        public override string Name { get; set; } = "Разработать статический класс Message.";

        public Dictionary<string, string[]> AcceptableWords { get; private set; }

        protected override void SetResult() {
            var format = "{0} ";
            Result = $"А) {StaticExercise1.ArrayToString(AcceptableWords["1"], format)}\n" +
                     $"Б) {StaticExercise1.ArrayToString(AcceptableWords["2"], format)}\n" +
                     $"В) {StaticExercise1.ArrayToString(new[] { AcceptableWords["3"][0] }, format)}\n" +
                     $"Г) {StaticExercise1.ArrayToString(AcceptableWords["4"], format)}\n";
        }

        protected override void ExecuteExercise() {
            string message = GetStringFromUserDate($"Enter the string ");
            if (message.Trim().Length == 0) {
                WriteExceptionMessage("Try again.");
                ExecuteExercise();

                return;
            }

            AcceptableWords = new Dictionary<string, string[]> {
                ["1"] = FirstPart(message),
                ["2"] = SecondPart(message),
                ["3"] = ThirdPart(message)
            };
            AcceptableWords.Add("4", FourthPart());
        }

        private string[] FirstPart(string message) {
            int lettersCount = GetInt32FromUserDate($"Enter letters count ");

            return Message.GetWordsWithLength(message, lettersCount);
        }

        private string[] SecondPart(string message) {
            char symbol = GetCharFromUserData($"Enter a character at the end of a word to remove a word ");

            return Message.RemoveWordsWithEndCharacter(message, symbol);
        }

        private string[] ThirdPart(string message) {
            string[] words = message.Split(' ');
            var biggestWords = new List<string> {
                words[0]
            };

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > biggestWords[0].Length) {
                    biggestWords.Clear();
                    biggestWords.Add(words[i]);
                } else if (words[i].Length == biggestWords[0].Length) {
                    biggestWords.Add(words[i]);
                }
            }

            return biggestWords.ToArray();
        }

        private string[] FourthPart() {
            string[] biggestWords = AcceptableWords["3"];
            var stringBuilder = new StringBuilder();

            foreach (string word in biggestWords) {
                stringBuilder.AppendFormat("{0} ", word);
            }

            return new[] {
                stringBuilder.ToString()
            };
        }
    }
}
