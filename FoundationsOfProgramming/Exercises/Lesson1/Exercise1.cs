using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson1
{
    public class Exercise1 : BaseExercise
    {
        private string fullName;

        private byte age;

        private byte growth;

        private short weight;

        private string format = "\nInformation about you" +
                                "\nfull name\t|\t{0}" +
                                $"\n{nameof(age)}\t\t|\t{1}" +
                                $"\n{nameof(growth)}\t\t|\t{2}" +
                                $"\n{nameof(weight)}\t\t|\t{3}";

        public Exercise1(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:\r\nа) используя склеивание;\r\nб) используя форматированный вывод;\r\nв) используя вывод со знаком $.";

        public override string Name { get; set; } = "Написать программу «Анкета»";

        protected override void ExecuteExercise() {
            SetFio();
            SetPersonParametrs();
        }

        protected override void SetResult() {
            Result = string.Format(format, fullName, age, growth, weight);
        }

        private void SetPersonParametrs() {
            Console.Write($"Your {nameof(age)}: ");
            string stringAge = Console.ReadLine();
            age = Convert.ToByte(stringAge);

            Console.Write($"Your {nameof(growth)}: ");
            string stringGrowth = Console.ReadLine();
            growth = Convert.ToByte(stringGrowth);

            Console.Write($"Your {nameof(weight)}: ");
            string stringWeight = Console.ReadLine();
            weight = Convert.ToInt16(stringWeight);
        }

        private void SetFio() {
            Console.Write("Your name: ");
            string name = Console.ReadLine();

            Console.Write("Your surname: ");
            string surname = Console.ReadLine();

            fullName = $"{name} {surname}";
        }
    }
}
