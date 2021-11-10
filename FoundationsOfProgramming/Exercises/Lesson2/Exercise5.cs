using BasicForStuding;
using L1 = FoundationsOfProgramming.Exercises.Lesson1;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise5 : L1.Exercise2
    {
        private const string Format = "Your body mass index is {0}.\r\n{1}";

        private const string Normal = "Your BMI is normal.";

        private const string Overweight = "You are overweight.";

        private const string Underweight = "You are underweight.";

        private const string DegreeOfObesity = "You have the {0} degree of obesity.";

        private const string FirstDegreeOfObesity = "first";

        private const string SecondDegreeOfObesity = "second";

        private const string ThirdDegreeOfObesity = "third";

        public Exercise5(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.\r\n" +
                                                           "б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.";

        public override string Name { get; set; } = "Рассчитать индекс массы тела";

        protected override void SetResult() {
            string advice = GetAdvice();
            Result = string.Format(Format, Bmi, advice);
        }

        private string GetAdvice() {
            if (Bmi > 18.5) {
                if (Bmi > 25) {
                    if (Bmi > 30) {
                        if (Bmi > 35) {
                            if (Bmi > 40) {
                                return string.Format(DegreeOfObesity, ThirdDegreeOfObesity);
                            }

                            return string.Format(DegreeOfObesity, SecondDegreeOfObesity);
                        }

                        return string.Format(DegreeOfObesity, FirstDegreeOfObesity);
                    }

                    return Overweight;
                }

                return Normal;
            }

            return Underweight;
        }
    }
}
