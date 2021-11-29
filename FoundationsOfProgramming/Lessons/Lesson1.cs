﻿using System.Collections.Generic;
using BasicForStuding;
using FoundationsOfProgramming.Exercises.Lesson1;

namespace FoundationsOfProgramming.Lessons
{
    public class Lesson1 : BaseLesson
    {
        public Lesson1(BaseLesson next) : base(next) {
            var exercise5 = new Exercise5(null);
            var exercise4 = new Exercise4(exercise5);
            var exercise3 = new Exercise3(exercise4);
            var exercise2 = new Exercise2(exercise3);
            var exercise1 = new Exercise1(exercise2);

            Exercises = new List<BaseExercise> {
                exercise1,
                exercise2,
                exercise3,
                exercise4,
                exercise5
            };

            Description = $"In this lesson we have {Exercises.Count} exercises";
        }

        public override string Description { get; set; }

        public override string Name { get; set; } = "C# language basics";
    }
}
