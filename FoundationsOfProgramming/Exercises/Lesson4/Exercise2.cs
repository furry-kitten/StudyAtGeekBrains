using System;
using BasicForStuding;
using FileToArray;

namespace FoundationsOfProgramming.Exercises.Lesson4
{
    public class Exercise2 : BaseExercise
    {
        public Exercise2(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а)Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;\r\n" +
                                                           "б)Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;\r\n" +
                                                           "в)*Добавьте обработку ситуации отсутствия файла на диске.";

        public override string Name { get; set; } = "Реализуйте задачу 1 в виде статического класса StaticClass.";

        public int[] Array { get; private set; }

        protected override void SetResult() {
            var str = String.Empty;
            foreach (int number in Array) {
                str = $"{str} {number}";
            }
            Result = $"{str}";
        }

        protected override void ExecuteExercise() {
            while (Array == null) {
                string filePath = GetStringFromUserDate($"Enter the file path ");
                Array = StaticExercise1.ReadFile(filePath);
            }
        }
    }
}
