using System;
using BasicForStuding;
using FA = FileToArray;
using static FileToArray.StaticExercise1;
using System.Collections.Generic;
using System.Linq;

namespace FoundationsOfProgramming.Exercises.Lesson4
{
    public class Exercise3 : BaseExercise
    {
        private FileToArray.Exercise1 exercise1;

        private int multyplier;

        public Exercise3(BaseExercise next) : base(next) { }

        public override string Description { get; set; } = "а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.\r\n" +
                                                           "б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки.";

        public override string Name { get; set; } = "Дописать класс для работы с одномерным массивом.";

        protected override void ExecuteExercise() {
            int length = GetInt32FromUserDate($"Enter array size ");
            int startItem = GetInt32FromUserDate($"Enter first element ");
            int step = GetInt32FromUserDate($"Enter the step ");
            multyplier = GetInt32FromUserDate($"Enter the {nameof(multyplier)} ");
            exercise1 = new FA.Exercise1(length, startItem, step);
        }

        public FA.Exercise1 Exercise1 => exercise1;

        protected override void SetResult() {
            Result = $"{nameof(exercise1.Sum)}: {exercise1.Sum}\r\n" +
                     $"{nameof(exercise1.Inverse)}: {ConvertArrayToString(exercise1.Inverse())}\r\n" +
                     $"{nameof(exercise1.MaxCount)}: {ConvertArrayToString(exercise1.MaxCount)}";
            exercise1.Multi(multyplier);
            Result += $"{nameof(exercise1.Multi)}: {ConvertArrayToString(exercise1.Array)}";
        }
    }
}
