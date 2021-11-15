using System;
using BasicForStuding;

namespace FoundationsOfProgramming.Exercises.Lesson1
{
    public class Exercise2 : BaseExercise
    {
        public double Weight { get; set; }

        public double Height { get; set; }

        public double Bmi { get; set; }

        public Exercise2(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.";

        public override string Name { get; set; } = "Рассчитать индекс массы тела";

        protected override void ExecuteExercise() {
            SetPersonParameters();
            SetBmi();
        }

        protected override void SetResult() {
            Result = $"Your body mass index is {Bmi}";
        }

        private void SetBmi() {
            Bmi = Weight / Math.Pow(Height, 2);
        }

        private void SetPersonParameters() {
            Weight = GetDoubleFromUserDate($"Enter your {nameof(Weight)} (kg) ");
            Height = GetDoubleFromUserDate($"Enter your {nameof(Height)} (m) ");
        }
    }
}
