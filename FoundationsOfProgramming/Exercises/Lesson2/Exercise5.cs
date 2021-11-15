using System;
using BasicForStuding;
using L1 = FoundationsOfProgramming.Exercises.Lesson1;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise5 : L1.Exercise2
    {
        private const string Format = "Your body mass index is {0}.\r\n{1}";

        private const string Normal = "Your BMI is normal.";

        private const string Overweight = "You are overweight. You have to lose {0} kg";

        private const string Underweight = "You are underweight. You have to gain {0} kg";

        private const string SeriousUnderweight = "You are seriously underweight. You have to gain {0} kg";

        private const string DegreeOfObesity = "You have the {0} degree of obesity. You have to lose {1} kg";

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
            const double normal1 = 18.5;
            const double normal2 = 25;
            double neededMass;
            if (Bmi >= 16.5) {
                if (Bmi >= 18.5) {
                    if (Bmi >= 25) {
                        if (Bmi >= 30) {
                            if (Bmi >= 35) {
                                if (Bmi >= 40) {
                                    neededMass = LoseWeight(normal2);

                                    return string.Format(DegreeOfObesity, ThirdDegreeOfObesity, neededMass.ToString("F"));
                                }

                                neededMass = LoseWeight(normal2);

                                return string.Format(DegreeOfObesity, SecondDegreeOfObesity, neededMass.ToString("F"));
                            }

                            neededMass = LoseWeight(normal2);

                            return string.Format(DegreeOfObesity, FirstDegreeOfObesity, neededMass.ToString("F"));
                        }

                        neededMass = LoseWeight(normal2);

                        return string.Format(Overweight, neededMass.ToString("F"));
                    }

                    return $"{Normal}";
                }

                neededMass = GainWeight(normal1);

                return string.Format(Underweight, neededMass.ToString("F"));
            }

            neededMass = GainWeight(normal1);

            return string.Format(SeriousUnderweight, neededMass.ToString("F"));
        }

        private double GainWeight(double i) {
            return (i - Bmi) * Math.Pow(Height, 2);
        }

        private double LoseWeight(double i) {
            return (Bmi - i) * Math.Pow(Height, 2);
        }
    }
}
