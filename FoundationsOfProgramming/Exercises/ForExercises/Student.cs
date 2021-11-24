using BasicForStuding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoundationsOfProgramming.Exercises.ForExercises
{
    internal struct Student
    {
        private string lastName;

        private string firstName;

        private byte[] marks;

        internal Student(string lastName, string firstName, byte[] marks) {
            this.lastName = lastName;
            this.firstName = firstName;
            this.marks = marks;
        }

        internal string LastName => lastName;

        internal string FirstName => firstName;

        internal byte[] Marks => marks;

        internal double MeanScore => GetMeanScore();

        public override string ToString() => $"{lastName} {firstName}";

        private double GetMeanScore() {
            double meanScore = 0.0;

            foreach (byte mark in marks) {
                meanScore += (double) mark / 3;
            }

            return meanScore;
        }
    }
}
