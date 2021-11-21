using BasicForStuding;
using FA = FileToArray;

namespace FoundationsOfProgramming.Exercises.Lesson4
{
    public class Exercise1 : BaseExercise
    {
        private int[] array;

        private int count;

        public Exercise1(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. " +
                                                           "Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. " +
                                                           "В данной задаче под парой подразумевается два подряд идущих элемента массива.\r\n" +
                                                           "Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.";

        public override string Name { get; set; } = "Написать программу, позволяющую найти и вывести количество пар элементов массива.";

        public int[] Array => array;

        public int Count => count;

        protected override void ExecuteExercise() {
            var exercise1 = new FA.Exercise1();
            exercise1.GenerateArray();
            array = exercise1.Array;
            count = exercise1.Count;
        }

        protected override void SetResult() {
            Result = $"Number of pairs is {count}";
        }
    }
}
