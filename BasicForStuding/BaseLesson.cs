using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicForStuding
{
    public abstract class BaseLesson : IBaseStudingClass
    {
        public abstract string Description { get; set; }

        public abstract string Name { get; set; }

        public IBaseStudingClass Next { get; set; }

        public abstract List<BaseExercise> Exercises { get; }

        public (bool Next, bool Previous, bool Close) Execute() {
            (bool Next, bool Previous, bool Close) nextAction = default;

            while (!nextAction.Close && !nextAction.Next && !nextAction.Previous) {
                WriteGeneralInformation();
                nextAction = GoToNextAction();

                if (nextAction.Next) {
                    (bool Next, bool Previous, bool Close) nextActionOfNextExercise = Next.Execute();

                    if (nextActionOfNextExercise.Previous &&
                        !nextActionOfNextExercise.Close) {
                        Clean();
                        WriteGeneralInformation();
                        nextAction = GoToNextAction();
                    }
                }
            }

            return nextAction;
        }

        //protected abstract void ExecuteExercise();

        protected void Clean() => Console.Clear();

        private void WriteGeneralInformation() {
            Clean();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"**********************{Name}**********************");
            Console.WriteLine(Description);
            WriteAllExercises();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
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
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    ExecuteExercise(0);
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ExecuteExercise(1);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ExecuteExercise(2);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ExecuteExercise(3);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ExecuteExercise(4);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ExecuteExercise(5);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    ExecuteExercise(6);
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    ExecuteExercise(7);
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    ExecuteExercise(8);
                    break;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    ExecuteExercise(9);
                    break;
            }

            return nextAction;
        }

        protected virtual void ExecuteExercise(int i) {
            if (i < 0) {
                i = 0;
            } else if(i>Exercises.Count - 1) {
                i = Exercises.Count - 1;
            }

            Exercises[i].Execute();
        }

        protected virtual void WriteAllExercises() {
            for (int i = 0; i < Exercises.Count; i++) {
                Console.WriteLine($"{i} - {Exercises[i].Name}");
            }
        }

        private (bool Next, bool Previous, bool Close) GoToNextAction() {
            ConsoleKeyInfo key = GetChoice();

            return GetNextAction(key);
        }
    }
}
