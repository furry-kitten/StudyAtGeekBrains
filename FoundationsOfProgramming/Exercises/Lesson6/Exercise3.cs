using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicForStuding;
using FileToArray;
using FoundationsOfProgramming.Exercises.ForExercises;

namespace FoundationsOfProgramming.Exercises.Lesson6
{
    public class Exercise3 : BaseExercise
    {
        private int bakalavr;

        private int magistr;

        private int junior;

        private DateTime dt;

        private List<StudentClass> students = new List<StudentClass>();

        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Переделать программу Пример использования коллекций для решения следующих задач:\r\n" +
                                                           "а) Подсчитать количество студентов учащихся на 5 и 6 курсах;\r\n" +
                                                           "б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);\r\n" +
                                                           "в) отсортировать список по возрасту студента;\r\n" +
                                                           "г) *отсортировать список по курсу и возрасту студента;\r\n";

        public override string Name { get; set; } = "Переделать программу Пример использования коллекций.";

        protected override void ExecuteExercise() {
            dt = DateTime.Now;
            FillListFromFile();
            magistr = students.FindAll(student => student.Course >= 5).Count;
            junior = students.FindAll(student => student.Age >= 18 && student.Age < 20).Count;
        }

        private void FillListFromFile() {
            using (var sr = new StreamReader("students_1.csv")) {
                while (!sr.EndOfStream) {
                    try {
                        string[] s = sr.ReadLine()?.Split(';');
                        s.ThrowExIfNull(nameof(s));
                        var student = new StudentClass {
                            FirstName = s[0],
                            SecondName = s[1],
                            Univercity = s[2],
                            Faculty = s[3],
                            Department = s[4],
                            Age = Convert.ToInt32(s[5]),
                            Course = Convert.ToInt32(s[6]),
                            Group = Convert.ToInt32(s[7]),
                            City = s[8]
                        };

                        students.Add(student);
                    } catch (Exception exception) {
                        WriteExceptionMessage(exception.Message);
                    }
                }
            }
        }

        protected override void SetResult() {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Всего студентов: {students.Count}");
            stringBuilder.AppendLine($"Магистров: {magistr}");
            stringBuilder.AppendLine($"Juniors: {junior}\r\n");
            stringBuilder.AppendLine($"Sort by age:\r\nSecond\tfirst\tage\tcourse\r\n{StaticExercise1.ArrayToString(students.OrderBy(student => student.Age), "{0}\r\n")}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Sort by course and age:\r\nSecond\tfirst\tage\tcourse\r\n{StaticExercise1.ArrayToString(students.OrderBy(student => student.Course).ThenBy(student=>student.Age), "{0}\r\n")}");
            stringBuilder.AppendLine($"\r\n{DateTime.Now - dt}");

            Result = stringBuilder.ToString();
        }
    }
}
