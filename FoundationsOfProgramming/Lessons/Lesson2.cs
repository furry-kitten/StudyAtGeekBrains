using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.Lesson2;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson2 : BaseLesson
    {
        public Lesson2(BaseLesson next) : base(next) {
            var exercise7 = new Exercise7(null);
            var exercise6 = new Exercise6(exercise7);
            var exercise5 = new Exercise5(exercise6);
            var exercise4 = new Exercise4(exercise5);
            var exercise3 = new Exercise3(exercise4);
            var exercise2 = new Exercise2(exercise3);
            var exercise1 = new Exercise1(exercise2);

            Exercises = new List<BaseExercise> {
                exercise1,
                exercise2,
                exercise3,
                exercise4,
                exercise5,
                exercise6,
                exercise7
            };

            Description = $"In this lesson we have {Exercises.Count} exercises";
        }

        public override string Description { get; set; }

        public override string Name { get; set; } = "Управляющие конструкции";
    }
}
