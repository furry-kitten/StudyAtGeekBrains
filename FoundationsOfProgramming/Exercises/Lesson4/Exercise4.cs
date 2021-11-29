using System;
using System.IO;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.ForExercises;
using L2 = FoundationsOfProgramming.Exercises.Lesson2;

namespace FoundationsOfProgramming.Exercises.Lesson4
{
    public class Exercise4 : L2.Exercise4
    {
        private string filePath = $@"{Environment.CurrentDirectory}\Default.lgnpsw";

        private readonly Account forAuthorization;

        public Exercise4(BaseExercise next) : base(next) {
            string[] authenticationData = new string[2];
            try {
                using (var stream = new StreamReader(filePath)) {
                    var index = 0;
                    while (!stream.EndOfStream) {
                        string data = stream.ReadLine();
                        if (!string.IsNullOrEmpty(data) &&
                            index < 2) {
                            authenticationData[index++] = data;
                        }
                    }

                    if (index < 2) {
                        throw new FileLoadException($"File ({filePath}) is short or empty, please create file with authentication data and restart program");
                    }

                    forAuthorization = new Account(authenticationData[0], authenticationData[1]);
                }
            } catch (FileNotFoundException exception) {
                WriteExceptionMessage("Please create file with authentication data Default.lgnpsw");
            } catch (Exception e) {
                WriteExceptionMessage(e.Message);
                Console.ReadKey();
            }
        }

        public override string Description { get; set; } = "Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. " +
                                                           "На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). " +
                                                           "Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. " +
                                                           "С помощью цикла do while ограничить ввод пароля тремя попытками.";

        public override string Name { get; set; } = "Аутентификация";

        public override bool IsAuthorized => Account != null && Account.Login == forAuthorization.Login && Account.Password == forAuthorization.Password;

        internal Account Account { get; set; }

        protected override void Authorization() {
            int i = 0;
            do {
                if (!IsAuthorized) {
                    string login = GetStringFromUserDate($"Login: ");
                    string password = GetStringFromUserDate($"Password: ");
                    Account = new Account(login, password);
                    i++;
                }

                if (!IsAuthorized) {
                    WriteExceptionMessage("Access denied.");
                }
            } while (!IsAuthorized && i < 3);
        }
    }
}
