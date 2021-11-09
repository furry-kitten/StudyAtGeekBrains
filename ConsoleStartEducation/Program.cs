using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoundationsOfProgramming;
using FoundationsOfProgramming.Lessons;

namespace ConsoleStartEducation
{
    class Program
    {
        static void Main(string[] args) {
            var lesson2 = new Lesson2(null);
            var lesson1 = new Lesson1(lesson2);
            lesson1.Execute();
        }
    }
}
