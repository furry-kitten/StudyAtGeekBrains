using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundationsOfProgramming.Exercises.ForExercises
{
    internal struct FractionalNumber
    {
        private double nominator;
        private double term;

        internal FractionalNumber(double term, double nominator) {
            var gcd = GCD(term, nominator);
            this.term = term / gcd;
            this.nominator = nominator / gcd;
        }

        internal double Term {
            get => term;
            set => term = value;
        }

        internal double Nominator {
            get => nominator;
            set {
                if (value == 0) {
                    throw new ArgumentException($"{nameof(Nominator)} cannot be 0");
                }

                nominator = value;
            }
        }

        public override string ToString() {
            if (term == 0) {
                return "0";
            }

            if(Math.Abs(Term) > nominator) {
                int isTermLessThanZero = term < 0 ? -1 : 1;
                var realPart = Math.Abs((int)(term / nominator));

                return $"{realPart}({isTermLessThanZero * (Math.Abs(term) - nominator * realPart)})/({nominator})";
            }

            return $"({term})/({nominator})";
        }

        public static FractionalNumber operator +(FractionalNumber number1, FractionalNumber number2) =>
            Plus(number1, number2);

        public static FractionalNumber operator -(FractionalNumber number1, FractionalNumber number2) =>
            Minus(number1, number2);

        public static FractionalNumber operator *(FractionalNumber number1, FractionalNumber number2) =>
            Multiplication(number1, number2);

        public static FractionalNumber operator /(FractionalNumber number1, FractionalNumber number2) =>
            Compartition(number1, number2);

        private static double GCD(double firstNumber, double secondNumber) {
            while (secondNumber != 0) {
                double tempNumber = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = tempNumber;
            }
            return Math.Abs(firstNumber);
        }

        private static FractionalNumber Plus(FractionalNumber number1, FractionalNumber number2) {
            if (number1.Nominator == number2.Nominator) {
                return new FractionalNumber(number1.Term + number2.Term, number1.Nominator);
            } else {
                double newNominator = number1.Nominator * number2.Nominator;
                double newTerm = number1.Term * number2.Nominator + number2.Term * number1.Nominator;

                return new FractionalNumber(newTerm, newNominator);
            }
        }

        private static FractionalNumber Minus(FractionalNumber number1, FractionalNumber number2) {
            if (number1.Nominator == number2.Nominator) {
                return new FractionalNumber(number1.Term - number2.Term, number1.Nominator);
            } else {
                double newNominator = number1.Nominator * number2.Nominator;
                double newTerm = number1.Term * number2.Nominator - number2.Term * number1.Nominator;

                return new FractionalNumber(newTerm, newNominator);
            }
        }

        private static FractionalNumber Multiplication(FractionalNumber number1, FractionalNumber number2) => new FractionalNumber(number1.Term * number2.Term, number1.Nominator * number2.Nominator);

        private static FractionalNumber Compartition(FractionalNumber number1, FractionalNumber number2) => new FractionalNumber(number1.Term * number2.Nominator, number1.Nominator * number2.Term);
    }
}
