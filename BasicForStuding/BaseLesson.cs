using System;
using System.Collections.Generic;

namespace BasicForStuding
{
    public abstract class BaseLesson : BaseStudingClass
    {
        protected BaseLesson(BaseLesson next) : base(next) { }

        public List<BaseExercise> Exercises { get; protected set; }

        public override (bool Next, bool Previous, bool Close) Execute() {
            NextAction = default;
            while (!NextAction.Close && !NextAction.Next && !NextAction.Previous) {
                WriteGeneralInformation();
                GoToNextAction();
            }

            return NextAction;
        }

        protected override void WriteGeneralInformation() {
            Description += "\r\nAuthor Tokarev Vladimir";
            base.WriteGeneralInformation();
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteAllExercises();
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void SetNextAction(ConsoleKeyInfo key) {
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

            NextAction = nextAction;
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
            Console.WriteLine("Exercises:");
            for (int i = 0; i < Exercises.Count; i++) {
                Console.WriteLine($"{i} - {Exercises[i].Name}");
            }
        }
    }
}
