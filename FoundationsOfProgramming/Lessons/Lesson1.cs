using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises;
using FoundationsOfProgramming.Exercises.Lesson1;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson1 : BaseLesson
    {
        public Lesson1() => Next = new Lesson2();

        public override string Description { get; set; } = "In this lesson we have 5 exercises";

        public override string Name { get; set; } = "C# language basics";

        public override List<BaseExercise> Exercises { get; } = new List<BaseExercise> {
            new Exercise1(),
            new Exercise2(),
            new Exercise3(),
            new Exercise4(),
            new Exercise5()
        };

        //protected override void ExecuteExercise() {
        //    var exercise1 = new Exercise1();
        //    exercise1.Execute();
        //}
    }
}
