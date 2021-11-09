using System;

namespace BasicForStuding
{
    public abstract class BaseExercise : BaseStudingClass
    {
        protected BaseExercise(BaseExercise next) : base(next) { }

        public string Result { get; protected set; }

        public override (bool Next, bool Previous, bool Close) Execute() {
            (bool Next, bool Previous, bool Close) nextAction = default;

            while (!nextAction.Close && !nextAction.Next && !nextAction.Previous) {
                WriteGeneralInformation();
                ExecuteExercise();
                GetResult();
                nextAction = GoToNextAction();

                if (nextAction.Next) {
                    (bool Next, bool Previous, bool Close) nextActionOfNextExercise;
                    if (Next != null) {
                        nextActionOfNextExercise = Next.Execute();
                    } else {
                        nextAction = nextActionOfNextExercise = default;
                    }

                    if (nextActionOfNextExercise.Previous &&
                        !nextActionOfNextExercise.Close) {
                        nextAction = default;
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

        protected abstract void SetResult();

        protected abstract void ExecuteExercise();
    }
}
