using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BasicForStuding;

namespace FileToArray
{
    public class Exercise5
    {
        private int[][] array;

        public Exercise5() {
            GenerateArray();
        }

        public int Maximum => array.Select(ints => ints.Max()).ToList().Max();

        public int Minimum => array.Select(ints => ints.Min()).ToList().Min();

        public int[][] ReadFile(string filePath) {
            var stringData = new List<string>();
            try {
                if (string.IsNullOrEmpty(filePath)) {
                    throw new FileNotFoundException("No name file");
                }

                if (filePath[filePath.Length - 1] == '\\') {
                    throw new FileNotFoundException($"'{filePath}' is directory.");
                }

                using (var stream = new StreamReader(filePath)) {
                    var index = 0;
                    while (!stream.EndOfStream) {
                        string data = stream.ReadLine();
                        if (!string.IsNullOrEmpty(data)) {
                            stringData.Add(data);
                        }
                    }

                    if (index < 1) {
                        throw new FileLoadException($"File ({filePath}) is short or empty, please create file with authentication data and restart program");
                    }
                }

                var dataToReturn = new int[stringData.Count][];

                for (var i = 0; i < stringData.Count; i++) {
                    dataToReturn[i] = ConvertToIntArray(stringData[i]);
                }

                return dataToReturn;
            } catch (FileNotFoundException) {
                WriteExceptionMessage($"Please create file {filePath}");
                return null;
            } catch (Exception e) {
                WriteExceptionMessage(e.Message);
                return null;
            }
        }

        public void WriteArrayIntoFile(string filePath) {
            FileInfo file = filePath[filePath.Length - 1] == '\\' ? CreateFile(filePath) : new FileInfo(filePath);
            using (var writer = new StreamWriter(file.FullName)) {
                foreach (int[] ints in array) {
                    string str = StaticExercise1.ConvertArrayToString(ints);
                    writer.WriteLine(str);
                }
            }
        }

        private FileInfo CreateFile(string filePath) {
            var directory = new DirectoryInfo(filePath);
            FileInfo[] files = directory.GetFiles("Array*.txt", SearchOption.TopDirectoryOnly);
            var fileName = (files.Length + 1).ToString("'Array'0#");
            return new FileInfo($@"{filePath}\{fileName}");
        }

        public void GenerateArray(int sizeX = 20, int sizeY = 20) {
            var rdm = new Random();
            const int limit = 10000;
            var localArray = new int[sizeY][];
            for (var j = 0; j < sizeY; j++) {
                localArray[j] = new int[sizeX];
                for (var i = 0; i < sizeX; i++) {
                    localArray[j][i] = rdm.Next(-1 * limit, limit);
                }
            }

            array = localArray;
        }

        public int GetSum(int? above = null) {
            var sum = 0;
            above = above ?? Minimum - 1;
            foreach (int[] ints in array) {
                foreach (int number in ints) {
                    if (number > above) {
                        sum += number;
                    }
                }
            }

            return sum;
        }

        public int GetIndexOfMaximum(out int numberOfMax) {
            int index = -1, i = 0, max = Maximum;
            while (index == -1) {
                index = array[i++].ToList().IndexOf(max);
            }

            numberOfMax = index + 1;

            return index;
        }

        private int[] ConvertToIntArray(string stringWithArray) {
            var data = new List<int>();
            string[] stringData = stringWithArray.Split(' ', '.', ',');
            foreach (string number in stringData) {
                data.Add(Convert.ToInt32(number));
            }

            return data.ToArray();
        }

        private static void WriteExceptionMessage(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
