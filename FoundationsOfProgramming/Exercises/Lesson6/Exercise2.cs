using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BasicForStuding;
using FileToArray;
using FoundationsOfProgramming.Exercises.ForExercises;

namespace FoundationsOfProgramming.Exercises.Lesson6
{
    public class Exercise2 : BaseExercise
    {
        private int minX;

        private int maxX;

        private double min;

        public Exercise2(BaseExercise next) : base(next) {
            Funcs = new List<Func<double, double, double>> {
                F1,
                F2,
                F3
            };
        }

        public override string Description { get; set; } = "Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.\r\n" +
                                                           "а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов, в котором хранятся различные функции.\r\n" +
                                                           "б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. " +
                                                           "Пусть она возвращает минимум через параметр (с использованием модификатора out).";

        public override string Name { get; set; } = "Модифицировать программу нахождения минимума функции.";

        public List<Func<double, double, double>> Funcs { get; }

        protected override void SetResult() {
            Result = $"Min is {min}";
        }

        protected override void ExecuteExercise() {
            Func<double, double, double> func = GetResultFromChoice();
            minX = GetInt32FromUserDate($"Enter min x ");
            maxX = GetInt32FromUserDate($"Enter max x ");
            SaveFunc("data.bin", minX, maxX, 0.5, func);
            Load("data.bin", out min);
        }

        public double F1(double x, double y) {
            return x * x - 50 * x + y;
        }

        public double F2(double x, double y) {
            return Math.Pow(x, 2) - Math.Pow(y, 2);
        }

        public double F3(double x, double y) {
            return Math.Pow(x - y, 3);
        }

        public void SaveFunc(string fileName, double a, double b, double h, Func<double, double, double> func) {
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)) {
                using (var bw = new BinaryWriter(fs)) {
                    double x = a;
                    while (x <= b) {
                        bw.Write(func(x, b));
                        x += h;
                    }
                }
            }
        }

        public void Load(string fileName, out double min) {
            min = double.MaxValue;
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
                using (var bw = new BinaryReader(fs)) {
                    double d;
                    for (var i = 0; i < fs.Length / sizeof(double); i++) {
                        d = bw.ReadDouble();
                        if (d < min)
                            min = d;
                    }
                }
            }
        }

        private void WriteIntoFile(Func<double, double, double> f, double x, double y, BinaryWriter writer) {
            writer.ThrowExIfNull(nameof(writer));
            writer.Write(f(x, y));
        }

        private Func<double, double, double> GetResultFromChoice() {
            ConsoleKeyInfo key = GetFuncChoice();

            return GetFunc(key.Key);
        }

        private ConsoleKeyInfo GetFuncChoice() {
            Console.WriteLine("Functions:");
            for (var i = 0; i < Funcs.Count; i++) {
                Console.WriteLine($"{i + 1} - F{i + 1}");
            }

            return Console.ReadKey(true);
        }

        private Func<double, double, double> GetFunc(ConsoleKey key) {
            switch (key) {
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    return Funcs[0];
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    return Funcs[1];
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    return Funcs[2];

                default:
                    WriteExceptionMessage($"Try again");
                    key = Console.ReadKey(true).Key;
                    return GetFunc(key);
            }
        }
    }
}
