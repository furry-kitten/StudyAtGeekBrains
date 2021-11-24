using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileToArray
{
    public static class StaticExercise1
    {
        public static int GetCount(IEnumerable<int> array) {
            var exercise1 = new Exercise1();
            exercise1.Array = array.ToArray();

            return exercise1.Count;
        }

        public static int[] ReadFile(string filePath) {
            try {
                if (String.IsNullOrEmpty(filePath)) {
                    throw new FileNotFoundException("No name file");
                }

                if (filePath[filePath.Length - 1] == '\\') {
                    throw new FileNotFoundException($"'{filePath}' is directory.");
                }

                var array = new List<int>();
                using (var stream = new StreamReader(filePath)) {
                    var dataArray = new List<string>();
                    while (!stream.EndOfStream) {
                        string data = stream.ReadLine();
                        if (!String.IsNullOrEmpty(data)) {
                            dataArray.AddRange(data.Split(' ', '.', ','));
                        }
                    }

                    if (dataArray.Count < 1) {
                        throw new FileLoadException($"File ({filePath}) is short or empty, please create file with authentication data and restart program");
                    }

                    foreach (string stringNumber in dataArray) {
                        array.Add(Convert.ToInt32(stringNumber));
                    }
                }

                return array.ToArray();
            } catch (FileNotFoundException exception) {
                WriteExceptionMessage($"Please create file {filePath}");
                return null;
            } catch (Exception e) {
                WriteExceptionMessage(e.Message);
                return null;
            }
        }

        public static string ConvertArrayToString(int[] ints) {
            var str = String.Empty;
            foreach (int number in ints) {
                str = $"{str} {number}";
            }

            return str;
        }

        public static string ArrayToString<T>(IEnumerable<T> array, string format) {
            var strBuilder = new StringBuilder();

            foreach (T word in array) {
                strBuilder.AppendFormat(format, word);
            }

            return strBuilder.ToString().Trim();
        }

        private static void WriteExceptionMessage(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
