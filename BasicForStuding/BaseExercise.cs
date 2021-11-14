using System;

namespace BasicForStuding
{
    public abstract class BaseExercise : IBaseStudingClass
    {
        protected BaseExercise() { }

        public string Result { get; protected set; }

        public abstract string Description { get; set; }

        public abstract string Name { get; set; }

        public IBaseStudingClass Next { get; set; }

        public (bool Next, bool Previous, bool Close) Execute() {
            (bool Next, bool Previous, bool Close) nextAction = default;

            while (!nextAction.Close && !nextAction.Next && !nextAction.Previous) {
                WriteGeneralInformation();
                ExecuteExercise();
                GetResult();
                nextAction = GoToNextAction();

                if (nextAction.Next) {
                    (bool Next, bool Previous, bool Close) nextActionOfNextExercise = Next.Execute();

                    if (nextActionOfNextExercise.Previous &&
                        !nextActionOfNextExercise.Close) {
                        WriteGeneralInformation();
                        nextAction = GoToNextAction();
                    }
                }
            }

            return nextAction;
        }

        protected virtual void GetResult() {
            SetResult();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected abstract void ExecuteExercise();

        protected void Clean() => Console.Clear();

        private void WriteGeneralInformation() {
            Clean();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"**********************{Name}**********************");
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private (bool Next, bool Previous, bool Close) GoToNextAction() {
            ConsoleKeyInfo key = GetChoice();
            
            return GetNextAction(key);
        }

        protected ConsoleKeyInfo GetChoice() {
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

        protected (bool Next, bool Previous, bool Close) GetNextAction(ConsoleKeyInfo key) {
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

        protected abstract void SetResult();
    }
}
