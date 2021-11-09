using BasicForStuding;
using L1 = FoundationsOfProgramming.Exercises.Lesson1;

namespace FoundationsOfProgramming.Exercises.Lesson2
{
    public class Exercise5 : L1.Exercise2
    {
        public Exercise5(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.\r\n" +
                                                           "б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.";

        public override string Name { get; set; } = "Рассчитать индекс массы тела";

        protected override void SetResult() {
            Result = $"Your body mass index is {Bmi}";
        }
    }
}
