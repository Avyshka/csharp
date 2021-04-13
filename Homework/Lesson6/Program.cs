/**
 * @author Aivar Sergeev
 * @description
 * 
 * 1. Изменить программу вывода таблицы функции так, чтобы можно было передавать
 *    функции типа double (double, double). Продемонстрировать работу на функции
 *    с функцией a*x^2 и функцией a*sin(x).
 *    
 * 2. Модифицировать программу нахождения минимума функции так, чтобы можно было
 *    передавать функцию в виде делегата.
 * а) Сделать меню с различными функциями и представить пользователю выбор, для
 *    какой функции и на каком отрезке находить минимум. Использовать массив
 *    (или список) делегатов, в котором хранятся различные функции.
 * б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
 *    Пусть она возвращает минимум через параметр (с использованием модификатора
 *    out).
 * 
 * 3. Переделать программу Пример использования коллекций для решения следующих
 *    задач:
 * а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
 * б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе
 *    учатся (*частотный массив);
 * в) отсортировать список по возрасту студента;
 * г) *отсортировать список по курсу и возрасту студента;
 * 
 * 4. **Считайте файл различными способами. Смотрите “Пример записи файла
 *    различными способами”. Создайте методы, которые возвращают массив byte 
 *    (FileStream, BufferedStream), строку для StreamReader и массив int
 *    для BinaryReader.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace Lesson6
{
    class Utils
    {
        static public void GoToMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] - Task 1 (Delegats)");
            Console.WriteLine("[2] - Task 2 (Min delegat)");
            Console.WriteLine("[3] - Task 3 (Students)");
            Console.WriteLine("[4] - Task 4 (File reader)");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("What task do you want to check? ");
        }

        static public void ShowWarning(int answer)
        {
            Console.Clear();
            Console.Write("The task {0} is missing. ", answer);
            PressAnyKey();
        }

        static public void PressAnyKey()
        {
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }

        static public void PrintColorLine(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        #region Task1
        public static void Table(FunTask1 F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc1(double x, double a)
        {
            return a * x * x;
        }

        public static double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }
        #endregion

        #region Task2
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return Math.Sin(x);
        }

        public static double F3(double x)
        {
            return 2 * x + 3;
        }

        public static double F4(double x)
        {
            return 5 * x / (x * x);
        }

        public static void SaveFunc(FunTask2 F, string fileName, double min, double max, double step)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = min;
            while (x <= max)
            {
                bw.Write(F(x));
                x += step;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            min = double.MaxValue;
            double d;

            long length = fs.Length / sizeof(double);
            double[] values = new double[length];

            for (int i = 0; i < length; i++)
            {
                d = br.ReadDouble();
                values[i] = d;
                if (d < min) min = d;
            }
            br.Close();
            fs.Close();

            return values;
        }

        static public void Task2Menu()
        {
            Console.Clear();
            Console.WriteLine("Function menu:");
            Console.WriteLine("[1] - x^2 + 50x + 10");
            Console.WriteLine("[2] - Sin(x)");
            Console.WriteLine("[3] - 2x + 3");
            Console.WriteLine("[4] - 5x / x^2");
            Console.WriteLine("[0] - Exit");
        }
        #endregion

        #region Task3
        static public int SortByAge(Student st1, Student st2)
        {
           return st1.age - st2.age;
        }
        
        static public int SortByCourseAndAge(Student st1, Student st2)
        {
           return (st1.course - st2.course) + (st1.age - st2.age);
        }

        static public bool FindByCourse(Student st)
        {
            return st.course == 5 || st.course == 6;
        }
        #endregion
    }

    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;

        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    public delegate double FunTask1(double x, double y);

    public delegate double FunTask2(double x);

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
                    case 4:
                        RunTask4();
                        break;
                }
            } while (taskNumber != 0);
        }

        static void RunTask1()
        {
            Console.Clear();

            Console.WriteLine("Function table [ a * x^2]:");
            Utils.Table(new FunTask1(Utils.MyFunc1), -2, 10, 2);

            Console.WriteLine("Again the same table, but the call is organized in a new way");
            Utils.Table(Utils.MyFunc1, -2, 10, 2);

            Console.WriteLine("Function table [a * Sin(x)]:");
            Utils.Table(Utils.MyFunc2, -2, 10, 2);

            Console.WriteLine("Function table [x * y]:");
            Utils.Table(delegate (double x, double y) { return x * y; }, 0, 5, 3);

            Utils.PressAnyKey();
        }

        static void RunTask2()
        {
            Console.Clear();

            FunTask2[] functions = {
                Utils.F1,
                Utils.F2,
                Utils.F3,
                Utils.F4
            };

            int functionIndex;
            do
            {
                bool validate;

                Utils.Task2Menu();

                Console.Write("What kind os function do you want to calculate? ");
                validate = int.TryParse(Console.ReadLine(), out functionIndex);
                if (functionIndex != 0)
                {
                    if (validate)
                    {
                        if (functionIndex < 1 || functions.Length < functionIndex)
                        {
                            Console.Clear();
                            Console.WriteLine("The function {0} is missing. ", functionIndex);
                            Utils.PressAnyKey();
                            continue;
                        }
                    }
                    else
                    {
                        functionIndex = -1;
                        Console.Clear();
                        Console.WriteLine("Data entry error");
                        Utils.PressAnyKey();
                        continue;
                    }

                    Console.Write("Please input the MIN range: ");
                    validate = int.TryParse(Console.ReadLine(), out int min);
                    if (!validate)
                    {
                        Console.Clear();
                        Console.WriteLine("Data entry error");
                        Utils.PressAnyKey();
                        continue;
                    }

                    Console.Write("Please input the MAX range: ");
                    validate = int.TryParse(Console.ReadLine(), out int max);
                    if (!validate)
                    {
                        Console.Clear();
                        Console.WriteLine("Data entry error");
                        Utils.PressAnyKey();
                        continue;
                    }

                    Utils.SaveFunc(functions[functionIndex - 1], "data.bin", min, max, 0.5);
                    double[] values = Utils.Load("data.bin", out double minValue);
                    Console.WriteLine("The min of function is {0}", minValue);
                    Console.WriteLine("All values from {0} to {1}:", min, max);
                    foreach (double value in values)
                    {
                        Console.WriteLine(value);
                    }

                    Utils.PressAnyKey();
                }

            } while (functionIndex != 0);

            Utils.PressAnyKey();
        }

        static void RunTask3()
        {
            Console.Clear();

            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;

            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            list.Sort(new Comparison<Student>(Utils.SortByAge));
            Utils.PrintColorLine("\nSort by age:", ConsoleColor.Yellow);
            foreach (var v in list) Console.WriteLine("{0,10}: age - {1}", v.firstName, v.age);
            
            list.Sort(new Comparison<Student>(Utils.SortByCourseAndAge));
            Utils.PrintColorLine("\nSort by course and age:", ConsoleColor.Yellow);
            foreach (var v in list) Console.WriteLine("{0,10}: course - {1}, age - {2}", v.firstName, v.course, v.age);

            List<Student> filtered = list.FindAll(Utils.FindByCourse);
            Utils.PrintColorLine("\nFind all studends on 5 and 6 courses:", ConsoleColor.Yellow);
            foreach (var v in filtered) Console.WriteLine("{0,10}: course - {1}", v.firstName, v.course);

            int[] courses = new int[6];
            foreach (var v in list)
            {
                if (18 <= v.age && v.age <= 20)
                {
                    courses[v.course - 1]++;
                }
            }

            Utils.PrintColorLine("\nNumber of students aged 18 to 20 by course:", ConsoleColor.Yellow);
            for (int i = 0; i < courses.Length; i++)
            {
                Console.WriteLine($"{i + 1} course - {courses[i]} students");
            }

            Console.WriteLine();
            Utils.PrintColorLine((DateTime.Now - dt).ToString(), ConsoleColor.DarkGreen);

            Utils.PressAnyKey();
        }

        static void RunTask4()
        {
            Console.Clear();

            

            Utils.PressAnyKey();
        }
    }
}
