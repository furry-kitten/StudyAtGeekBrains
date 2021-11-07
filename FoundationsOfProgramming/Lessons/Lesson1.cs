using BasicForStuding;
using FoundationsOfProgramming.Exercises;
using FoundationsOfProgramming.Exercises.Lesson1;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson1 : BaseLesson
    {
        public override string Description { get; set; } = "In this lesson we have 5 exercises";

        public override string Name { get; set; } = "C# language basics";

        protected override void ExecuteExercise() {
            var exercise1 = new Exercise1();
            exercise1.Execute();
        }
    }
}
