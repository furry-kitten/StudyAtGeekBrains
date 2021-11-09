using System;

namespace BasicForStuding
{
    public abstract class BaseStudingClass : IBaseStudingClass
    {
        protected BaseStudingClass(IBaseStudingClass next) {
            Next = next;
        }

        public abstract string Description { get; set; }

        public abstract string Name { get; set; }

        public IBaseStudingClass Next { get; set; }

        public abstract (bool Next, bool Previous, bool Close) Execute();

        protected void WriteExceptionMessage(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected void Clean() => Console.Clear();

        protected virtual void WriteGeneralInformation() {
            Clean();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"**********************{Name}**********************");
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected virtual (bool Next, bool Previous, bool Close) GoToNextAction() {
            ConsoleKeyInfo key = GetChoice();

            return GetNextAction(key);
        }

        protected virtual ConsoleKeyInfo GetChoice() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nWhat shell we do next?");
            Console.WriteLine($"{ConsoleKey.Enter} - Perform/Repeat \"{Name}\"");
            if (Next != null) {
                Console.WriteLine($"{ConsoleKey.PageUp} - Next \"{Next.Name}\"");
            }

            Console.WriteLine($"{ConsoleKey.PageDown} - Previous");
            Console.WriteLine($"{ConsoleKey.Backspace} - Back");
            Console.WriteLine($"{ConsoleKey.Escape} - Close");
            Console.ForegroundColor = ConsoleColor.White;

            ConsoleKeyInfo key = Console.ReadKey();
            return key;
        }

        protected virtual (bool Next, bool Previous, bool Close) GetNextAction(ConsoleKeyInfo key) {
            (bool Next, bool Previous, bool Close) nextAction = default;

            switch (key.Key) {
                case ConsoleKey.Enter:
                    nextAction = default;
                    break;
                case ConsoleKey.Escape:
                    nextAction.Close = true;
                    break;
                case ConsoleKey.PageUp:
                    nextAction.Next = true;
                    break;
                case ConsoleKey.PageDown:
                    nextAction.Previous = true;
                    break;
                case ConsoleKey.Backspace:
                    nextAction.Previous = true;
                    nextAction.Close = true;
                    break;
            }

            return nextAction;
        }
    }
}
