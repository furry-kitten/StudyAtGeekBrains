using System;
using System.Collections.Generic;
using System.Linq;

namespace FileToArray
{
    public class Exercise1
    {
        private int[] array;

        public Exercise1() { }

        public Exercise1(int size, int startItem, int step) {
            var newArray = new List<int> {
                startItem
            };

            for (var i = 0; i < size; i++) {
                startItem += step;
                newArray.Add(startItem);
            }

            array = newArray.ToArray();
        }

        public int[] Array {
            get => array;
            set => array = value;
        }

        public int Count => GetCount();

        public int Sum => GetSum();

        public int[] MaxCount => GetAllMaximums();

        public void GenerateArray(int size = 20) {
            var rdm = new Random();
            const int limit = 10000;
            array = new int[size];
            for (var i = 0; i < size; i++) {
                array[i] = rdm.Next(-1 * limit, limit);
            }
        }

        public int[] Inverse() => array.Select(item => item * (-1)).ToArray();

        public void Multi(int multiplier) {
            for (var i = 0; i < array.Length; i++) {
                array[i] = array[i] * multiplier;
            }
        }

        private int GetCount() {
            IEnumerable<int> indexes = GetIndexOfNumbersMultiplesOfThree();
            int count = GetCountPairs(indexes);

            return count;
        }

        private IEnumerable<int> GetIndexOfNumbersMultiplesOfThree() {
            var indexesOfNumbersMultiplesOfThree = new List<int>();
            List<int> numbersMultiplesOfThree = array.ToList().FindAll(number => number % 3 == 0);
            var lastIndex = 0;
            foreach (int number in numbersMultiplesOfThree) {
                lastIndex = array.ToList().FindIndex(lastIndex, num => num == number);
                indexesOfNumbersMultiplesOfThree.Add(lastIndex);
            }

            return indexesOfNumbersMultiplesOfThree;
        }

        private int GetCountPairs(IEnumerable<int> indexes) {
            var countPairs = 0;
            int[] enumerable = indexes as int[] ?? indexes.ToArray();
            foreach (int index in enumerable) {
                if (index > 0 && array[index - 1] % 3 != 0) {
                    Console.WriteLine($"{array[index - 1]} { array[index]}");
                    countPairs++;
                }

                if (index < array.Length - 1 && array[index + 1] % 3 != 0) {
                    Console.WriteLine($"{ array[index]} {array[index + 1]}");
                    countPairs++;
                }
            }

            return countPairs;
        }

        private int GetSum() {
            var sum = 0;
            foreach (int item in array) {
                sum += item;
            }

            return sum;
        }

        private int[] GetAllMaximums() {
            var maxs = new List<int>();
            maxs = array.ToList().FindAll(number => number == array.Max());

            return maxs.ToArray();
        }
    }
}
