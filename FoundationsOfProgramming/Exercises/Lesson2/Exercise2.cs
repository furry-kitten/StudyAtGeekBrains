using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise2 : BaseExercise
    {
        private double weight;

        private double height;

        private double bmi; // body mass index

        public Exercise2() {
            Next = new Exercise3();
        }

        public override string Description { get; set; } = "Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.";

        public override string Name { get; set; } = "Рассчитать индекс массы тела";

        protected override void ExecuteExercise() {
            SetPersonParameters();
            SetBmi();
        }

        protected override void SetResult() {
            Result = $"Your body mass index is {bmi}";
        }

        private void SetBmi() {
            bmi = weight / Math.Pow(height, 2);
        }

        private void SetPersonParameters() {
            Console.Write($"Enter your {nameof(weight)} (kg) ");
            string stringWeight = Console.ReadLine();
            weight = Convert.ToDouble(stringWeight);

            Console.Write($"Enter your {nameof(height)} (m) ");
            string stringHeight = Console.ReadLine();
            height = Convert.ToDouble(stringHeight);
        }
    }
}
