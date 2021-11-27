using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundationsOfProgramming.Exercises.ForExercises
{
    public class StudentClass
    {
        public string FirstName;

        public string SecondName;

        public string Univercity;

        public string Faculty;

        public string Department;

        public int Age;

        public int Course;

        public int Group;

        public string City;

        public StudentClass() { }

        public override string ToString() => $"{SecondName}\t{FirstName}\t{Age}\t{Course}";
    }
}
