using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundationsOfProgramming.Exercises.ForExercises
{
    internal class Complex
    {

        #region Поля (Fields)

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        private double re; // private

        #endregion

        #region Свойства

        public double Ip {
            get => im;

            set {
                if (value == 0) {
                    throw new Exception("Недопустимое значение.");
                }

                im = value;
            }
        }

        public double Rp {
            get => re;
            set => re = value;
        }

        #endregion

        #region Конструктор класса

        public Complex(double re, double im) {
            if (im == 0) {
                throw new Exception("Недопустимое значение.");
            }

            this.re = re;
            this.im = im;

        }

        private Complex() {

        }

        #endregion

        #region Поведение (Methods)

        public Complex Plus(Complex complex) => new Complex(re + complex.Rp, im + complex.Ip);

        public Complex Mines(Complex complex) => new Complex(re - complex.Rp, im - complex.Ip);

        public Complex Multiplication(Complex complex) => new Complex(re * complex.Rp + im * complex.Ip * (-1), re * complex.Ip + im * complex.Rp);

        #endregion

        public override string ToString() => re != 0 ? $"{re} + {im}i" : $"{im}i";
    }
}
