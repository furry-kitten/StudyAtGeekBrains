using System;

namespace BasicForStuding
{
    public abstract class BaseExercise<TNext> : IBaseStudingClass<TNext>
        where TNext : IBaseStudingClass<TNext>, new()
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public TNext Next { get; set; }

        protected BaseExercise() { }

        public (bool Next, bool Previous, bool Close) Execute() {
            (bool Next, bool Previous, bool Close) nextAction = default;

            while (!nextAction.Close && !nextAction.Next && !nextAction.Previous) {
                WriteGeneralInformation();
                ExecuteExercise();
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

        protected abstract void ExecuteExercise();

        protected void Clean() => Console.Clear();

        private void WriteGeneralInformation() {
            Clean();
            Console.WriteLine($"**********************{Name}**********************");
            Console.WriteLine(Description);
        }

        private (bool Next, bool Previous, bool Close) GoToNextAction() {
            ConsoleKeyInfo key = GetChoice();
            
            return GetNextAction(key);
        }

        protected ConsoleKeyInfo GetChoice() {
            Console.WriteLine("\nWhat shell we do next?");
            Console.WriteLine($"{ConsoleKey.Enter} - Perform/Repeat {Name}");

            if (Next != null) {
                Console.WriteLine($"{ConsoleKey.PageUp} - Next \"{Next.Name}\"");
            }

            Console.WriteLine($"{ConsoleKey.PageDown} - Previous");
            Console.WriteLine($"{ConsoleKey.Backspace} - Back");
            Console.WriteLine($"{ConsoleKey.Escape} - Close");

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
    }
}
