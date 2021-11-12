using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson3
{
    public class Exercise2 : BaseExercise
    {
        public Exercise2(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Написать метод подсчета количества цифр числа.";

        public override string Name { get; set; } = "Подсчет количества цифр числа";

        public string UserNum { get; private set; }

        public int Count { get; private set; }

        protected override void ExecuteExercise() {
            GetNumber();
            SetCount();
        }

        private void GetNumber() {
            UserNum = GetStringFromUserDate("Enter number ");
            string[] parts = UserNum.Split(' ');
            UserNum = String.Empty;
            foreach (string part in parts) {
                UserNum = $"{UserNum}{part}";
            }
        }

        private void SetCount() {
            try {
                ulong value = GetUInt64(UserNum);
                UserNum = value.ToString();
                Count = UserNum.Length;
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                ExecuteExercise();
            }
        }

        protected override void SetResult() {
            Result = $"Number '{UserNum}' consists of {Count} digits";
        }
    }
}
