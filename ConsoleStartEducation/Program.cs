using FoundationsOfProgramming.Lessons;

namespace ConsoleStartEducation
{
    class Program
    {
        static void Main(string[] args) {
            var lesson6 = new Lesson6(null);
            var lesson5 = new Lesson5(lesson6);
            var lesson4 = new Lesson4(lesson5);
            var lesson3 = new Lesson3(lesson4);
            var lesson2 = new Lesson2(lesson3);
            var lesson1 = new Lesson1(lesson2);
            lesson1.Execute();
        }
    }
}
