namespace FoundationsOfProgramming.Exercises.ForExercises
{
    internal struct Complex
    {

        #region Поля (Fields)

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double imaginaryPart;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        private double realPart; // private

        #endregion

        #region Свойства

        public double ImaginaryPart {
            get => imaginaryPart;
            set => imaginaryPart = value;
        }

        public double RealPart {
            get => realPart;
            set => realPart = value;
        }

        #endregion

        #region Конструктор класса

        public Complex(double re, double im) {
            realPart = re;
            imaginaryPart = im;
        }
        #endregion

        #region Поведение (Methods)

        public Complex Plus(Complex complex) => new Complex(realPart + complex.RealPart, imaginaryPart + complex.ImaginaryPart);

        public Complex Minus(Complex complex) => new Complex(realPart - complex.RealPart, imaginaryPart - complex.ImaginaryPart);

        public Complex Multiplication(Complex complex) => new Complex(realPart * complex.RealPart + imaginaryPart * complex.ImaginaryPart * (-1), realPart * complex.ImaginaryPart + imaginaryPart * complex.RealPart);

        #endregion

        #region Операторы

        /// <summary>
        /// Перегрузка оператора +, сложение комплексных чисел
        /// </summary>
        /// <param name="complex1">Комплексное число</param>
        /// <param name="complex2">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public static Complex operator +(Complex complex1, Complex complex2) =>
            new Complex(complex1.RealPart + complex2.RealPart, complex1.ImaginaryPart + complex2.ImaginaryPart);

        /// <summary>
        /// Перегрузка оператора -, сложение комплексных чисел
        /// </summary>
        /// <param name="complex1">Комплексное число</param>
        /// <param name="complex2">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public static Complex operator -(Complex complex1, Complex complex2) =>
            new Complex(complex1.RealPart - complex2.RealPart, complex1.ImaginaryPart - complex2.ImaginaryPart);

        /// <summary>
        /// Перегрузка оператора *, сложение комплексных чисел
        /// </summary>
        /// <param name="complex1">Комплексное число</param>
        /// <param name="complex2">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public static Complex operator *(Complex complex1, Complex complex2) =>
            new Complex(complex1.RealPart * complex2.RealPart + complex1.ImaginaryPart * complex2.ImaginaryPart * (-1), complex1.RealPart * complex2.ImaginaryPart + complex1.ImaginaryPart * complex2.RealPart);

        #endregion

        public override string ToString() {
            bool isRealPartCollapsed = realPart == 0;
            bool isImaginaryPartCollapsed = imaginaryPart == 0;
            if (isImaginaryPartCollapsed) {
                return !isRealPartCollapsed ? $"{realPart}" : "0";
            }

            return !isRealPartCollapsed ? $"{realPart} + ({imaginaryPart}i)" : $"{imaginaryPart}i";
        }
    }
}
