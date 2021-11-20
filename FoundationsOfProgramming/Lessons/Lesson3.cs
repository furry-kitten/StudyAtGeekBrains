using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.Lesson3;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson3 : BaseLesson
    {
        public Lesson3(BaseLesson next) : base(next) {
            var exercise3 = new Exercise3(null);
            var exercise2 = new Exercise2(exercise3);
            var exercise1 = new Exercise1(exercise2);

            Exercises = new List<BaseExercise> {
                exercise1,
                exercise2,
                exercise3
            };

            Description = $"In this lesson we have {Exercises.Count} exercises";
        }

        public override string Description { get; set; }

        public override string Name { get; set; } = "Методы. От структур к объектам. Исключения.";
    }
}
