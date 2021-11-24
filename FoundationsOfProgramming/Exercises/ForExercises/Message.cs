using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FoundationsOfProgramming.Exercises.ForExercises
{
    public static class Message
    {
        public static string[] GetWordsWithLength(string message, int lettersCount) {
            var words = new List<string>();
            Regex reg = GetRegularExpression(lettersCount);
            MatchCollection matches = reg.Matches(message);

            foreach (Match match in matches) {
                words.Add(match.Value);
            }

            return words.ToArray();
        }

        public static string[] RemoveWordsWithEndCharacter(string message, char symbol) {
            var words = new List<string>();
            Regex reg = GetRegularExpression(symbol);
            MatchCollection matches = reg.Matches(message);

            foreach (Match match in matches) {
                if (!string.IsNullOrEmpty(match.Value)) {
                    words.Add(match.Value);
                }
            }

            return words.ToArray();
        }

        //public static string[] GetWordsWithLength(string message, int lettersCount) {
        //    var strs = new List<string>();
        //    Regex reg = GetRegularExpression(lettersCount);
        //    MatchCollection matches = reg.Matches(message);

        //    foreach (Match match in matches) {
        //        strs.Add(match.Value);
        //    }

        //    return strs.ToArray();
        //}

        private static Regex GetRegularExpression(int lettersCount) {
            var strBuilder = new StringBuilder(@"\b\w{");
            strBuilder.Append(lettersCount);
            strBuilder.Append(@",}\b");

            //return new Regex(@"\b\w{3,}\b");
            return new Regex(strBuilder.ToString());
        }

        private static Regex GetRegularExpression(char symbol) {
            var strBuilder = new StringBuilder(@"\b\w*(?<!");
            strBuilder.Append(symbol);
            strBuilder.Append(@")\b");

            //return new Regex(@"\b\w*(?<!r)\b");
            return new Regex(strBuilder.ToString());
        }

        //private static Regex GetRegularExpressionBiggestWord(int lettersCount) {
        //    var strBuilder = new StringBuilder(@"\b\w{");
        //    strBuilder.Append(lettersCount);
        //    strBuilder.Append(@",} +|\b ?\w{");
        //    strBuilder.Append(lettersCount);
        //    strBuilder.Append(@",}\z");

        //    return new Regex(/*strBuilder.ToString()*/@"\b\w{3} +|\b ?\w{3}\za/\w[a-z]{0,}/gi");
        //}
    }
}
