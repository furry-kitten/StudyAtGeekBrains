using System;
using System.Collections.Generic;
using BasicForStuding;
using L2 = FoundationsOfProgramming.Exercises.Lesson2;

namespace FoundationsOfProgramming.Exercises.Lesson3
{
    public class Exercise2 : L2.Exercise3
    {
        public Exercise2(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). " +
                                                           "Требуется подсчитать сумму всех нечётных положительных чисел. " +
                                                           "Сами числа и сумму вывести на экран, используя tryParse";

        protected override void GetNumbers() {
            Numbers = new List<double>();
            string messageForUser = "Enter the number (0 for stop) ";
            double newNum = 0;
            while (newNum == 0) {
                newNum = GetDoubleFromUserDate(messageForUser);
            }

            while (newNum > 0 || newNum < 0) {
                Numbers.Add(newNum);
                newNum = GetDoubleFromUserDate(messageForUser);
            }
        }

        protected override void SetResult() {
            var neededNumbers = Numbers.FindAll(num => num % 2 == 1 && num > 0);
            Result = $"{neededNumbers[0]} + ";
            for (int i = 1; i < neededNumbers.Count; i++) 
            {
                Result += $"{neededNumbers[i]}";
                if (i + 1 < neededNumbers.Count) {
                    Result += " + ";
                } else {
                    Result += " = ";
                }
            }

            Result += $"{Sum}";
        }

        private new double GetDoubleFromUserDate(string messageForUser) {
            string stringValue = GetStringFromUserDate(messageForUser);
            try {
                return GetDouble(stringValue);
            } catch (Exception exception) {
                WriteExceptionMessage(exception.Message);
                return GetDoubleFromUserDate(messageForUser);
            }
        }

        private new double GetDouble(string value) {
            value.ThrowExIfNull(nameof(value));
            bool isConverted = double.TryParse(value, out double convertedValue);
            if (isConverted) {
                return convertedValue;
            }

            throw new ArgumentException($"Can not convert \'{value}\' to {nameof(Double)}");
        }
    }
}
