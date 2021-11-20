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

        public (bool Next, bool Previous, bool Close) NextAction { get; set; } = default;

        protected void WriteExceptionMessage(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected void Clean() => Console.Clear();

        protected virtual void WriteGeneralInformation() {
            Clean();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int halfLengthPersonalData = Name.Length / 2;
            int halfWidthOfCurrentWindow = Console.WindowWidth / 2;
            int widthOfCurrentWindow = halfWidthOfCurrentWindow - halfLengthPersonalData - 1;
            var squiggle = new string('~', widthOfCurrentWindow);
            Console.Write($"{squiggle}{Name}{squiggle}\r\n");
            Console.WriteLine(Description);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop += 2;
        }

        protected virtual void GoToNextAction() {
            ConsoleKeyInfo key = GetChoice();
            SetNextAction(key);

            if (NextAction.Next && Next == null) {
                NextAction = default;
                Clean();
                WriteExceptionMessage("Press any key for repeat");
                Console.ReadKey();
            }

            if (NextAction.Next) {
                NextAction = Next.Execute();
                if (NextAction.Previous && !NextAction.Close) {
                    NextAction = default;
                }
            }
        }

        protected virtual ConsoleKeyInfo GetChoice() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorTop += 1;
            Console.WriteLine("\nWhat shell we do next?");
            Console.WriteLine($"{ConsoleKey.Enter} - Perform/Repeat \"{Name}\"");
            if (Next != null) {
                Console.WriteLine($"{ConsoleKey.PageUp} - Next \"{Next.Name}\"");
            }

            Console.WriteLine($"{ConsoleKey.PageDown} - Previous");
            Console.WriteLine($"{ConsoleKey.Escape} - Close");
            Console.ForegroundColor = ConsoleColor.White;

            ConsoleKeyInfo key = Console.ReadKey();
            return key;
        }

        protected virtual void SetNextAction(ConsoleKeyInfo key) {
            (bool Next, bool Previous, bool Close) nextAction = default;

            switch (key.Key) {
                case ConsoleKey.Escape:
                    nextAction.Close = true;
                    break;
                case ConsoleKey.PageUp:
                    nextAction.Next = true;
                    break;
                case ConsoleKey.PageDown:
                    nextAction.Previous = true;
                    break;
            }

            NextAction = nextAction;
        }
    }
}
