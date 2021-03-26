/*
 * @author Aivar Sergeev
 * @description
 *  1. Написать метод, возвращающий минимальное из трёх чисел.
 *  2. Написать метод подсчета количества цифр числа.
 *  3. С клавиатуры вводятся числа, пока не будет введен 0.
 *     Подсчитать сумму всех нечетных положительных чисел.
 *  4. Реализовать метод проверки логина и пароля. На вход метода подается
 *     логин и пароль. На выходе истина, если прошел авторизацию, и ложь,
 *     если не прошел (Логин: root, Password: GeekBrains). Используя метод
 *     проверки логина и пароля, написать программу: пользователь вводит
 *     логин и пароль, программа пропускает его дальше или не пропускает.
 *     С помощью цикла do while ограничить ввод пароля тремя попытками.
 *  5. а) Написать программу, которая запрашивает массу и рост человека,
 *        вычисляет его индекс массы и сообщает, нужно ли человеку похудеть,
 *        набрать вес или всё в норме.
 *     б) *Рассчитать, на сколько кг похудеть или сколько кг набрать
 *        для нормализации веса.
 *  6. *Написать программу подсчета количества «хороших» чисел в диапазоне
 *     от 1 до 1 000 000 000. «Хорошим» называется число, которое делится
 *     на сумму своих цифр. Реализовать подсчёт времени выполнения программы,
 *     используя структуру DateTime.
 *  7. a) Разработать рекурсивный метод, который выводит на экран числа
 *        от a до b(a<b).
 *     б) *Разработать рекурсивный метод, который считает сумму чисел
 *        от a до b.
 */
using System;

namespace Lesson2
{
    class Utils
    {
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

        static public int Min(int a, int b, int c)
        {
            if (a < b && a < c)
            {
                return a;
            }
            else if (b < a && b < c)
            {
                return b;
            }
            return c;
        }

        static public int GetLength(int number)
        {
            int length = number == 0 ? 1 : 0;
            while (number > 0)
            {
                number /= 10;
                length++;
            }
            return length;
        }

        static public bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static public bool Authorization(string login, string password)
        {
            return login == "root" && password == "GeekBrains";
        }

        static public double GetBodyMassIndex(double weigth, double height)
        {
            double heightInMeters = height * .01;
            return weigth / (heightInMeters * heightInMeters);
        }

        static public double GetWeightByBMI(double bmi, double height)
        {
            double heightInMeters = height * .01;
            return bmi * (heightInMeters * heightInMeters);
        }

        static public bool IsGoodNumber(int number)
        {
            return number % NumberSumm(number) == 0;
        }

        static int NumberSumm(int n)
        {
            int s = 0;
            while (n != 0)
            {
                s += n % 10;
                n /= 10;
            }
            return s;
        }

        public static void PrintRange(int start, int end)
        {
            if (start <= end)
            {
                Console.WriteLine(start);
                PrintRange(start + 1, end);
            }
        }

        public static int PrintSum(int start, int end)
        {
            if (start == end)
            {
                return end;
            }
            else
            {
                return PrintSum(start + 1, end) + start;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int taskNumber;
            do
            {
                GoToMenu();
                taskNumber = int.Parse(Console.ReadLine());
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
                    case 4:
                        RunTask4();
                        break;
                    case 5:
                        RunTask5();
                        break;
                    case 6:
                        RunTask6();
                        break;
                    case 7:
                        RunTask7();
                        break;
                    default:
                        ShowWarning(taskNumber);
                        break;
                }
            } while (taskNumber != 0);
        }

        static void GoToMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] - Task 1 (min)");
            Console.WriteLine("[2] - Task 2 (number length)");
            Console.WriteLine("[3] - Task 3 (sum of positive odd numbers)");
            Console.WriteLine("[4] - Task 4 (login, passvord - root, GeekBrains)");
            Console.WriteLine("[5] - Task 5 (BMI)");
            Console.WriteLine("[6] - Task 6 (Sum of good numbers)");
            Console.WriteLine("[7] - Task 7 (Recursion)");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("What task do you want to check? ");
        }

        static void ShowWarning(int answer)
        {
            Console.Clear();
            Console.Write("The task {0} is missing. ", answer);
            Utils.PressAnyKey();
        }

        static void RunTask1()
        {
            Console.Clear();

            int a = int.Parse(Utils.GetResponse("Please input the first number: "));
            int b = int.Parse(Utils.GetResponse("Please input the second number: "));
            int c = int.Parse(Utils.GetResponse("Please input the third number: "));

            Console.Clear();
            Console.WriteLine("The min number is: {0}", Utils.Min(a, b, c));

            Utils.PressAnyKey();
        }

        static void RunTask2()
        {
            Console.Clear();

            int a = int.Parse(Utils.GetResponse("Please input any number: "));
            Console.WriteLine("The length of number {0} is {1}", a, Utils.GetLength(a));

            Utils.PressAnyKey();
        }

        static void RunTask3()
        {
            Console.Clear();

            int number, sum = 0;
            do
            {
                number = int.Parse(Utils.GetResponse("Please input any number (0 - exit): "));
                if (number > 0 && Utils.IsOdd(number))
                {
                    sum += number;
                }
            } while (number != 0);

            Console.Clear();
            Console.WriteLine("The sum of the numbers is {0}", sum);

            Utils.PressAnyKey();
        }

        static void RunTask4()
        {
            string login, password;
            int trying = 0;
            int tryingTotal = 3;
            do
            {
                Console.Clear();

                login = Utils.GetResponse("Please input the login: ");
                password = Utils.GetResponse("Please input the password: ");

                Console.Clear();
                if (Utils.Authorization(login, password))
                {
                    Console.WriteLine("Congratulation!");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    trying++;
                    string msg = trying < 3
                        ? "You inputed an invalid login or password. Please try again..."
                        : "Sorry, you've wasted all your tries";
                    Console.WriteLine(msg);
                    Console.ReadKey();
                }
            } while (trying < tryingTotal);

            Utils.PressAnyKey();
        }

        static void RunTask5()
        {
            Console.Clear();

            const double NORMAL_BMI_MIN = 18.5;
            const double NORMAL_BMI_MAX = 25;

            double weight = double.Parse(Utils.GetResponse("Please input your weight: "));
            double height = double.Parse(Utils.GetResponse("Please input your height: "));
            double bmi = Utils.GetBodyMassIndex(weight, height);

            double normalWeightMin = Utils.GetWeightByBMI(NORMAL_BMI_MIN, height);
            double normalWeightMax = Utils.GetWeightByBMI(NORMAL_BMI_MAX, height);

            string msg = "Your weight is normal";
            if (bmi > NORMAL_BMI_MAX)
            {
                double extraWeight = weight - normalWeightMax;
                msg = $"You need to lose {extraWeight:F2} kilo";
            }
            else if (bmi < NORMAL_BMI_MIN)
            {
                double extraWeight = normalWeightMin - weight;
                msg = $"You need to gain {extraWeight:F2} kilo";
            }
            Console.Clear();
            Console.WriteLine(msg);

            Utils.PressAnyKey();
        }
        
        static void RunTask6()
        {
            Console.Clear();
            Console.Write("Calculating...");

            DateTime timeStamp = DateTime.Now;

            int count = 0;
            for (int i = 1; i < 1000000000; i++)
            {
                if (Utils.IsGoodNumber(i))
                {
                    count++;
                }
            }
            Console.Clear();
            Console.WriteLine("Count of good numbers is {0}\nTotal time: {1}", count, DateTime.Now - timeStamp);
            Utils.PressAnyKey();
        }

        static void RunTask7()
        {
            Console.Clear();

            int a = int.Parse(Utils.GetResponse("Please input the first number: "));
            int b = int.Parse(Utils.GetResponse("Please input the second number: "));

            Utils.PrintRange(a, b);
            Console.WriteLine("\nThe sum from {0} to {1} is {2}", a, b, Utils.PrintSum(a, b));

            Utils.PressAnyKey();
        }
    }
}
