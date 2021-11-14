using System;

namespace BasicForStuding
{
    public abstract class BaseExercise : BaseStudingClass
    {
        protected BaseExercise(BaseExercise next) : base(next) { }

        public string Result { get; protected set; }

        public override (bool Next, bool Previous, bool Close) Execute() {
            NextAction = default;
            while (!NextAction.Close && !NextAction.Next && !NextAction.Previous) {
                WriteGeneralInformation();
                ExecuteExercise();
                GetResult();
                GoToNextAction();
            }

            return NextAction;
        }

        protected virtual void GetResult() {
            Console.WriteLine();
            Console.CursorTop += 1;
            SetResult();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Result);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected short GetInt16FromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetInt16(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetInt16FromUserDate(messageForUser);
            }
        }

        protected int GetInt32FromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetInt32(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetInt32FromUserDate(messageForUser);
            }
        }

        protected long GetInt64FromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetInt64(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetInt64FromUserDate(messageForUser);
            }
        }

        protected ushort GetUInt16FromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetUInt16(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetUInt16FromUserDate(messageForUser);
            }
        }

        protected uint GetUInt32FromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetUInt32(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetUInt32FromUserDate(messageForUser);
            }
        }

        protected ulong GetUInt64FromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetUInt64(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetUInt64FromUserDate(messageForUser);
            }
        }

        protected double GetDoubleFromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetDouble(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetDoubleFromUserDate(messageForUser);
            }
        }

        protected short GetInt16(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToInt16(value);
        }

        protected int GetInt32(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToInt32(value);
        }

        protected long GetInt64(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToInt64(value);
        }

        protected ushort GetUInt16(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToUInt16(value);
        }

        protected uint GetUInt32(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToUInt32(value);
        }

        protected ulong GetUInt64(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToUInt64(value);
        }

        protected double GetDouble(string value) {
            value.ThrowExIfNull(nameof(value));
            return Convert.ToDouble(value);
        }

        protected T GetTypedValue<T>(string messageForUser)
            where T : unmanaged {
            object typedValue = default;
            if (typeof(T) == typeof(short)) {
                typedValue = GetInt16FromUserDate(messageForUser);
            } else if (typeof(T) == typeof(int)) {
                typedValue = GetInt32FromUserDate(messageForUser);
            } else if (typeof(T) == typeof(long)) {
                typedValue = GetInt64FromUserDate(messageForUser);
            } else if (typeof(T) == typeof(ushort)) {
                typedValue = GetInt16FromUserDate(messageForUser);
            } else if (typeof(T) == typeof(uint)) {
                typedValue = GetInt32FromUserDate(messageForUser);
            } else if (typeof(T) == typeof(ulong)) {
                typedValue = GetInt64FromUserDate(messageForUser);
            } else if (typeof(T) == typeof(double)) {
                typedValue = GetDoubleFromUserDate(messageForUser);
            }

            return (T)typedValue;
        }

        protected string GetStringFromUserDate(string messageForUser) {
            Console.Write(messageForUser);
            return Console.ReadLine();
        }

        protected abstract void SetResult();

        protected abstract void ExecuteExercise();
    }
}
