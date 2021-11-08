using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.Lesson2;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson2 : BaseLesson
    {
        public override string Description { get; set; }

        public override string Name { get; set; }

        public override List<BaseExercise> Exercises { get; } = new List<BaseExercise> {
            new Exercise1(),
            new Exercise2(),
            new Exercise3(),
            new Exercise4(),
            new Exercise5(),
            new Exercise6(),
            new Exercise7()
        };
    }
}
