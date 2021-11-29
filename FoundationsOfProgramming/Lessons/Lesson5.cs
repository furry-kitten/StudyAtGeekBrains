using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.Lesson5;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson5 : BaseLesson
    {
        public Lesson5(BaseLesson next) : base(next) {
            var exercise4 = new Exercise4(null);
            var exercise3 = new Exercise3(exercise4);
            var exercise2 = new Exercise2(exercise3);
            var exercise1 = new Exercise1(exercise2);

            Exercises = new List<BaseExercise> {
                exercise1,
                exercise2,
                exercise3,
                exercise4
            };
        }
        public override string Description { get; set; }
        public override string Name { get; set; } = "Символы, строки, регулярные выражения.";
    }
}
