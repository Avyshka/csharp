/*
 * @author Aivar Sergeev
 * @description
 * 
 *  1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
 *        Продемонстрировать работу структуры.
 *     б) Дописать класс Complex, добавив методы вычитания и произведения чисел.
 *        Проверить работу класса.
 *     в) Добавить диалог с использованием switch демонстрирующий работу класса.
 *     
 *  2. С клавиатуры вводятся числа, пока не будет введён 0 (каждое число
 *     в новой строке). Требуется подсчитать сумму всех нечётных
 *     положительных чисел. Сами числа и сумму вывести на экран,
 *     используя tryParse.
 *        
 *  3.   * Описать класс дробей — рациональных чисел, являющихся отношением двух
 *         целых чисел. Предусмотреть методы сложения, вычитания, умножения и
 *         деления дробей. Написать программу, демонстрирующую все разработанные
 *         элементы класса.
 *       * Добавить свойства типа int для доступа к числителю и знаменателю;
 *       * Добавить свойство типа double только на чтение, чтобы получить
 *         десятичную дробь числа;
 *      ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать
 *         исключение ArgumentException("Знаменатель не может быть равен 0");
 *     *** Добавить упрощение дробей.
 */
using System;

namespace Lesson3
{
    class Utils
    {
        static public void GoToMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] - Task 1 (complex numbers)");
            Console.WriteLine("[2] - Task 2 (sum of positive odd numbers)");
            Console.WriteLine("[3] - Task 3 (fractions)");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("What task do you want to check? ");
        }

        static public void ShowWarning(int answer)
        {
            Console.Clear();
            Console.Write("The task {0} is missing. ", answer);
            PressAnyKey();
        }

        static public double GetValidNumber(string question)
        {
            Console.Clear();

            bool isValidInput;
            double value;
            do
            {
                Console.Write(question);
                isValidInput = double.TryParse(Console.ReadLine(), out value);
                if (isValidInput)
                {
                    break;
                }
            } while (!isValidInput);

            return value;
        }

        static public string GetResponse(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();
            Console.Clear();
            return answer;
        }

        static public void PressAnyKey()
        {
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }

        static public bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static public bool IsPositive(int number)
        {
            return number >= 0;
        }

        static public int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

    }

    struct Complex
    {
        public double re;
        public double im;

        public Complex Add(Complex x)
        {
            Complex y;
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }

        public Complex Sub(Complex x)
        {
            Complex y;
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }
        
        public Complex Multi(Complex x)
        {
            Complex y;
            y.re = re * x.re - im * x.im;
            y.im = re * x.im + im * x.re;
            return y;
        }

        public override string ToString()
        {
            double newIm = im < 0 ? -im : im;
            string sign = im < 0 ? "-" : "+";
            return $"[{re} {sign} {newIm}i]";
        }
    }

    class Fraction
    {
        int numerator;
        int denominator;

        #region Properties
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
                SimplifyFraction();
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("The denominator in a fraction cannot be zero!");
                }
                denominator = value;
                SimplifyFraction();
            }
        }

        public double DecimalFraction
        {
            get {
                return (double)Numerator / (double)Denominator;
            }
        }
        #endregion

        #region Constructors
        public Fraction()
        {
            numerator = 1;
            denominator = 1;
        }
        
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        #endregion

        #region Methods
        private void SimplifyFraction()
        {
            if (Numerator != 0 && Denominator != 0)
            {
                int nod = Utils.NOD(Numerator, Denominator);
                if (nod > 1)
                {
                    Numerator /= nod;
                    Denominator /= nod;
                }
            }
        }

        public Fraction Add(Fraction f)
        {
            Fraction newFraction = new Fraction();
            newFraction.numerator = numerator * f.denominator + denominator * f.numerator;
            newFraction.denominator = denominator * f.denominator;
            return newFraction;
        }
        
        public Fraction Sub(Fraction f)
        {
            Fraction newFraction = new Fraction();
            newFraction.numerator = numerator * f.denominator - denominator * f.numerator;
            newFraction.denominator = denominator * f.denominator;
            return newFraction;
        }
        
        public Fraction Multi(Fraction f)
        {
            Fraction newFraction = new Fraction();
            newFraction.numerator = numerator * f.numerator;
            newFraction.denominator = denominator * f.denominator;
            return newFraction;
        }
        
        public Fraction Div(Fraction f)
        {
            Fraction newFraction = new Fraction();
            newFraction.numerator = numerator * f.denominator;
            newFraction.denominator = denominator * f.numerator;
            return newFraction;
        }

        public override string ToString()
        {
            return $"[{numerator} / {denominator}]";
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            int taskNumber;
            bool isValidInput;
            do
            {
                Utils.GoToMenu();
                isValidInput = int.TryParse(Console.ReadLine(), out taskNumber);
                if (!isValidInput)
                {
                    Utils.ShowWarning(taskNumber);
                    continue;
                }
                switch (taskNumber)
                {
                    case 0:
                        break;
                    case 1:
                        RunTask1();
                        break;
                    case 2:
                        RunTask2();
                        break;
                    case 3:
                        RunTask3();
                        break;
                    default:
                        Utils.ShowWarning(taskNumber);
                        break;
                }
            } while (taskNumber != 0);
        }

        static void RunTask1()
        {
            Console.Clear();

            Complex complex01;
            complex01.re = Utils.GetValidNumber("Please input the REAL part (Re) of the first complex number: ");
            complex01.im = Utils.GetValidNumber("Please input the IMAGINARY part (Im) of the first complex number: ");

            Complex complex02;
            complex02.re = Utils.GetValidNumber("Please input the REAL part (Re) of the second complex number: ");
            complex02.im = Utils.GetValidNumber("Please input the IMAGINARY part (Im) of the second complex number: ");

            string operationType;
            do
            {
                Console.Clear();
                Console.WriteLine($"The first number:  {complex01}");
                Console.WriteLine($"The second number: {complex02}");

                operationType = Utils.GetResponse("Please input the operation type (+, -, * or 0 for exit): ");
                switch (operationType)
                {
                    case "+":
                        Console.WriteLine($"{complex01} + {complex02} = {complex01.Add(complex02)}");
                        Utils.PressAnyKey();
                        break;
                    case "-":
                        Console.WriteLine($"{complex01} + {complex02} = {complex01.Sub(complex02)}");
                        Utils.PressAnyKey();
                        break;
                    case "*":
                        Console.WriteLine($"{complex01} + {complex02} = {complex01.Multi(complex02)}");
                        Utils.PressAnyKey();
                        break;
                    case "0":
                        return;
                }
            } while (true);
        }

        static void RunTask2()
        {
            Console.Clear();

            int number, sum = 0;
            bool isNumber;
            string allPositiveOddNumbers = "";
            do
            {
                Console.Write("Please input any number (0 - exit): ");
                isNumber = int.TryParse(Console.ReadLine(), out number);
                if (
                    isNumber &&
                    Utils.IsOdd(number) &&
                    Utils.IsPositive(number))
                {
                    sum += number;
                    allPositiveOddNumbers += allPositiveOddNumbers.Length > 0
                        ? $", {number}"
                        : number;
                }
                if (!isNumber)
                {
                    number = -1;
                }
            } while (number != 0);

            Console.WriteLine("The sum of the [{0}] is {1}", allPositiveOddNumbers, sum);

            Utils.PressAnyKey();
        }

        static void RunTask3()
        {
            Console.Clear();

            Fraction fraction1 = new ();
            fraction1.Numerator = (int)Utils.GetValidNumber("Please input the numerator for the first fraction: ");
            fraction1.Denominator = (int)Utils.GetValidNumber("Please input the denominator for the first fraction: ");

            Fraction fraction2 = new ();
            fraction2.Numerator = (int)Utils.GetValidNumber("Please input the numerator for the second fraction: ");
            fraction2.Denominator = (int)Utils.GetValidNumber("Please input the denominator for the second fraction: ");

            Console.WriteLine($"{fraction1} + {fraction2} = {fraction1.Add(fraction2)}");
            Console.WriteLine($"{fraction1} - {fraction2} = {fraction1.Sub(fraction2)}");
            Console.WriteLine($"{fraction1} * {fraction2} = {fraction1.Multi(fraction2)}");
            Console.WriteLine($"{fraction1} / {fraction2} = {fraction1.Div(fraction2)}");

            Console.WriteLine($"{fraction1.DecimalFraction}");
            Console.WriteLine($"{fraction2.DecimalFraction}");

            Utils.PressAnyKey();
        }
    }
}
