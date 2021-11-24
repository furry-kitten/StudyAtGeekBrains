using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BasicForStuding;
using FileToArray;
using FoundationsOfProgramming.Exercises.ForExercises;
using L2 = FoundationsOfProgramming.Exercises.Lesson2;

namespace FoundationsOfProgramming.Exercises.Lesson5
{
    public class Exercise4 : BaseExercise
    {
        public override string Description { get; set; } = "На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. " +
                                                           "В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:\r\n" +
                                                           "<Фамилия> <Имя> <оценки>,\r\n" +
                                                           "где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:\r\n" +
                                                           "Иванов Петр 4 5 3\r\n" +
                                                           "Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.";

        public override string Name { get; set; } = "Задача ЕГЭ";

        public Exercise4(BaseExercise next) : base(next) { }

        internal List<Student> Students { get; set; }

        protected override void SetResult() {
            double minMeanScore = Students.Min(student => student.MeanScore);
            List<Student> worseMeanScore = Students.FindAll(student => student.MeanScore == minMeanScore);

            Result = StaticExercise1.ArrayToString(worseMeanScore, "{0}\n");
        }

        protected override void ExecuteExercise() {
            int count = GetInt32FromUserDate("Enter the number of students ");
            Students = new List<Student>();
            while (Students.Count < count) {
                try {
                    Console.WriteLine();
                    CreateStudent();
                } catch (Exception e) {
                    WriteExceptionMessage(e.Message);
                }
            }
        }

        private void CreateStudent() {
            string name = GetFirtName();
            string secondName = GetLastName();
            byte[] marks = GetMarks();

            Students.Add(new Student(secondName, name, marks));
        }

        private byte[] GetMarks() {
            var intMarks = new List<byte>();
            string marks = GetStringFromUserDate("Enter marks ");
            string[] splitMarks = marks.Split(' ');
            foreach (string mark in splitMarks) {
                var byteMark = Convert.ToByte(mark);
                if (byteMark <= 5) {
                    intMarks.Add(byteMark);
                }
            }

            if (intMarks.Count < 3) {
                throw new ArgumentException("Incorrect marks string");
            }
            return intMarks.ToArray();
        }

        private string GetLastName() {
            var reg = new Regex(@"^\D{0,20}");
            string value = GetStringFromUserDate("Enter the second name ");
            if (!reg.IsMatch(value)) {
                throw new ArgumentException("Incorrect second name");
            }

            return value;
        }

        private string GetFirtName() {
            var reg = new Regex(@"^\D{0,20}");
            string value = GetStringFromUserDate("Enter the first name ");
            if (!reg.IsMatch(value)) {
                throw new ArgumentException("Incorrect first name");
            }

            return value;
        }
    }
}
