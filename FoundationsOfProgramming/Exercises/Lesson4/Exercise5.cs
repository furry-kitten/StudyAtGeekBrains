using System;
using BasicForStuding;
using FA = FileToArray;

namespace FoundationsOfProgramming.Exercises.Lesson4
{
    public class Exercise5 : BaseExercise
    {
        private FA.Exercise5 exercise5;
        private int above;
        public Exercise5(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).\r\n" + 
                                                           "*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.\r\n" +
                                                           "**в) Обработать возможные исключительные ситуации при работе с файлами.";

        public override string Name { get; set; } = "Реализовать библиотеку.";

        public FA.Exercise5 E5 => exercise5;

        protected override void ExecuteExercise() {
            exercise5 = new FA.Exercise5();
            string stringAbove = GetStringFromUserDate($"Enter the threshold ");
            if (string.IsNullOrEmpty(stringAbove) || !char.IsDigit(stringAbove[0])) {
                above = Int32.MinValue;
            } else {
                above = GetInt32(stringAbove);
            }
        }

        public int Above => above;

        protected override void SetResult() {
            int number = 0;
            Result = $"Sum: {exercise5.GetSum()}\r\n" +
                     $"Sum with threshold '{above}': {exercise5.GetSum(above)}\r\n" +
                     $"{nameof(exercise5.Minimum)}: {exercise5.Minimum}\r\n" +
                     $"{nameof(exercise5.Maximum)}: index is {exercise5.GetIndexOfMaximum(out number)} numerical order is {number}";
        }
    }
}
