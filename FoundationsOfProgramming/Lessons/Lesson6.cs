using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.Lesson6;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson6 : BaseLesson
    {
        public Lesson6(BaseLesson next) : base(next) {
            var exercise3 = new Exercise3(null);
            var exercise2 = new Exercise2(exercise3);
            var exercise1 = new Exercise1(exercise2);

            Exercises = new List<BaseExercise> {
                exercise1,
                exercise2,
                exercise3
            };
        }

        public override string Description { get; set; }

        public override string Name { get; set; } = "Делегаты, файлы, коллекции.";
    }
}
