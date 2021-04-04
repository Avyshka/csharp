/**
 * @author Aivar Sergeev
 * @description
 * 
 * 1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать
 *    целые значения от –10 000 до 10 000 включительно. Написать программу,
 *    позволяющую найти и вывести количество пар элементов массива, в которых
 *    хотя бы одно число делится на 3. В данной задаче под парой подразумевается 
 *    два подряд идущих элемента массива. Например, для массива из пяти 
 *    элементов: 6; 2; 9; –3; 6 – ответ: 4.
 *    
 * 2. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор,
 *       создающий массив заданной размерности и заполняющий массив числами от
 *       начального значения с заданным шагом. Создать свойство Sum, которые
 *       возвращают сумму элементов массива, метод Inverse, меняющий знаки
 *       у всех элементов массива, метод Multi, умножающий каждый элемент массива
 *       на определенное число, свойство MaxCount, возвращающее количество 
 *       максимальных элементов. В Main продемонстрировать работу класса.
 *    б) Добавить конструктор и методы, которые загружают данные из файла
 *       и записывают данные в файл.
 *       
 * 3. Решить задачу с логинами из предыдущего урока, только логины и пароли
 *    считать из файла в массив. Создайте структуру Account, содержащую
 *    Login и Password.
 *    
 * 4. *а) Реализовать класс для работы с двумерным массивом. Реализовать
 *        конструктор, заполняющий массив случайными числами. Создать методы,
 *        которые возвращают сумму всех элементов массива, сумму всех элементов
 *        массива больше заданного, свойство, возвращающее минимальный элемент
 *        массива, свойство, возвращающее максимальный элемент массива, метод,
 *        возвращающий номер максимального элемента массива (через параметры,
 *        используя модификатор ref или out)
 *    *б) Добавить конструктор и методы, которые загружают данные из файла
 *        и записывают данные в файл.
 *    Дополнительные задачи
 *     в) Обработать возможные исключительные ситуации при работе с файлами.
 */
using System;
using System.IO;

namespace Lesson4
{
    class Utils
    {
        static public void GoToMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] - Task 1 (Search numbers in Array)");
            Console.WriteLine("[2] - Task 2 (Class MyArray)");
            Console.WriteLine("[3] - Task 3 (Login & Password)");
            Console.WriteLine("[4] - Task 4 (2D Array)");
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

        static public int[] GetRandomArray(int size, int min, int max)
        {
            int[] arr = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(min, max + 1);
            }
            return arr;
        }

        static public bool IsMultipleThree(int number)
        {
            return number % 3 == 0;
        }

        static public int[] ReadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string[] parsedData = reader.ReadLine().Split(",");
                reader.Close();

                return Array.ConvertAll(parsedData, int.Parse);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        static public int[,] ReadArray2DFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                int countLines = File.ReadAllLines(fileName).Length;

                string[] arr = new string[countLines];
                for (int i = 0; i < countLines; i++)
                {
                    arr[i] = reader.ReadLine();
                }
                reader.Close();

                int countElements = arr[0].Split(",").Length;
                int[,] arr2D = new int[countLines, countElements];

                for (int i = 0; i < countLines; i++)
                {
                    string[] tmp = arr[i].Split(",");
                    for (int j = 0; j < countElements; j++)
                    {
                        arr2D[i, j] = int.Parse(tmp[j]);
                    }
                }
                return arr2D;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        static public void WriteArrayToFile(string fileName, int[] arr)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(string.Join(",", arr));
            writer.Close();
        }
        
        static public void WriteArray2DToFile(string fileName, int[,] arr)
        {
            StreamWriter writer = new StreamWriter(fileName);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string str = "";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    string separator = j == arr.GetLength(1) - 1 ? "" : ",";
                    str += arr[i, j] + separator;
                }
                writer.WriteLine(str);
            }
            writer.Close();
        }

        static public string[] ReadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                int countLines = File.ReadAllLines(fileName).Length;
                string[] arr = new string[countLines];
                for (int i = 0; i < countLines; i++)
                {
                    arr[i] = reader.ReadLine();
                }
                reader.Close();
                return arr;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        static public bool Authorization(Account account)
        {
            return account.login == "root" && account.password == "GeekBrains";
        }
    }

    class MyArray
    {
        private int[] arr;

        #region Constructors
        public MyArray(int[] arr)
        {
            this.arr = arr;
        }
        
        public MyArray(int size, int startValue, int step)
        {
            arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                this[i] = startValue + i * step;
            }
        }

        public MyArray(string fileName)
        {
            ReadFromFile(fileName);
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"[{string.Join(",", arr)}]";
        }
        
        public void Multi(int multiplier)
        {
            for (int i = 0; i < Length; i++)
            {
                this[i] *= multiplier;
            }
        }
        
        public void Inverse()
        {
            for (int i = 0; i < Length; i++)
            {
                this[i] = -this[i];
            }
        }

        public void ReadFromFile(string fileName)
        {
            arr = Utils.ReadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + fileName);
        }

        public void WriteToFile(string fileName)
        {
            Utils.WriteArrayToFile(AppDomain.CurrentDomain.BaseDirectory + fileName, arr);
        }
        #endregion

        #region Properties
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int Length
        {
            get { return arr.Length; }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < Length; i++)
                {
                    sum += this[i];
                }
                return sum;
            }
        }

        public int Max
        {
            get
            {
                int max = this[0];
                foreach (int value in arr)
                {
                    if (value > max)
                    {
                        max = value;
                    }
                }
                return max;
            }
        }

        public int MaxCount
        {
            get
            {
                int count = 0;
                int max = Max;
                foreach(int value in arr)
                {
                    if (value == max)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        #endregion
    }

    struct Account
    {
        public string login;
        public string password;
    }

    class Array2D
    {
        private int[,] arr;

        #region Constructors
        public Array2D(int[,] arr)
        {
            this.arr = arr;
        }

        public Array2D(int col, int row, int min = 0, int max = 100)
        {
            arr = new int[col, row];
            Random rand = new Random();
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    this[i, j] = rand.Next(min, max + 1);
                }
            }
        }

        public Array2D(string fileName)
        {
            ReadFromFile(fileName);
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                str += "[\t";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    str += arr[i, j] + "\t";
                }
                str += "]\n";
            }
            return $"{str}";
        }

        public int Sum()
        {
            int sum = 0;
            foreach (int value in arr)
            {
                sum += value;
            }
            return sum;
        }
        
        public int Sum(int limit)
        {
            int sum = 0;
            foreach (int value in arr)
            {
                sum += value > limit ? value : 0;
            }
            return sum;
        }
        
        public void MaxPosition(out int col, out int row)
        {
            col = -1;
            row = -1;
            int max = this[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (this[i, j] > max) {
                        max = this[i, j];
                        col = i;
                        row = j;
                    }
                }
            }
        }

        public void ReadFromFile(string fileName)
        {
            arr = Utils.ReadArray2DFromFile(AppDomain.CurrentDomain.BaseDirectory + fileName);
        }

        public void WriteToFile(string fileName)
        {
            Utils.WriteArray2DToFile(AppDomain.CurrentDomain.BaseDirectory + fileName, arr);
        }
        #endregion

        #region Properties
        public int this[int col, int row]
        {
            get { return arr[col, row]; }
            set { arr[col, row] = value; }
        }

        public int Min
        {
            get
            {
                int min = this[0, 0];
                foreach (int value in arr)
                {
                    if (value < min)
                    {
                        min = value;
                    }
                }
                return min;
            }
        }
        
        public int Max
        {
            get
            {
                int max = this[0, 0];
                foreach (int value in arr)
                {
                    if (value > max)
                    {
                        max = value;
                    }
                }
                return max;
            }
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
                    case 4:
                        RunTask4();
                        break;
                }
            } while (taskNumber != 0);
        }

        static void RunTask1()
        {
            Console.Clear();

            int sizeArray = 20;
            int minValue = -10000;
            int maxValue = 10000;

            int[] numbers = Utils.GetRandomArray(sizeArray, minValue, maxValue);

            int countMatches = 0;

            bool isMultipleThreeLast = Utils.IsMultipleThree(numbers[0]);
            bool isMultipleThreeCurrent;
            for (int i = 1; i < numbers.Length; i++)
            {
                isMultipleThreeCurrent = Utils.IsMultipleThree(numbers[i]);
                if (isMultipleThreeLast || isMultipleThreeCurrent)
                {
                    countMatches++;
                }
                isMultipleThreeLast = isMultipleThreeCurrent;
            }
            Console.WriteLine("Count of matches {0}", countMatches);

            Utils.PressAnyKey();
        }

        static void RunTask2()
        {
            Console.Clear();

            MyArray myArray = new MyArray(10, 1, 2);
            Console.WriteLine("Initial array: {0}", myArray.ToString());

            Console.WriteLine("Sum of all elements is {0}", myArray.Sum);

            int multiplier = 2;
            myArray.Multi(multiplier);
            Console.WriteLine("Multi by {0}: {1}", multiplier, myArray.ToString());

            Console.WriteLine("Max element is {0}. Count of max elements is {1}", myArray.Max, myArray.MaxCount);

            myArray.Inverse();
            Console.WriteLine("Inverse: {0}", myArray.ToString());

            string fileName = "MyArray.txt";

            myArray.WriteToFile(fileName);
            Console.WriteLine("Array {0} was written to file '{1}'", myArray.ToString(), fileName);

            MyArray myArrayFromFile = new MyArray(fileName);
            Console.WriteLine("New array from file '{0}': {1}", fileName, myArrayFromFile.ToString());

            Utils.PressAnyKey();
        }

        static void RunTask3()
        {
            Console.Clear();
            string[] logins = Utils.ReadFromFile("Logins.txt");
            string[] passwords = Utils.ReadFromFile("Passwords.txt");

            Console.WriteLine($"Logins: [{string.Join(", ", logins)}]");
            Console.WriteLine($"Passwords: [{string.Join(", ", passwords)}]\n");

            for (int i = 0; i < logins.Length; i++)
            {
                Account account;
                account.login = logins[i];
                for (int j = 0; j < passwords.Length; j++)
                {
                    account.password = passwords[j];
                    if (Utils.Authorization(account))
                    {
                        Console.WriteLine($"SUCCESS: Login: {account.login}, password: {account.password}");
                        Utils.PressAnyKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"FAILD: Login: {account.login}, password: {account.password}");
                    }
                }
            }
            Console.WriteLine("Login and password not found!");
            Utils.PressAnyKey();
        }

        static void RunTask4()
        {
            Console.Clear();

            Array2D arr = new Array2D(6, 7);
            Console.WriteLine($"Initial array:\n{arr.ToString()}");

            Console.WriteLine("Sum all elements: {0}", arr.Sum());
            int limitSum = 50;
            Console.WriteLine("Sum all elements more than {0}: {1}", limitSum, arr.Sum(limitSum));
            Console.WriteLine("Max element: {0}", arr.Max);
            Console.WriteLine("Min element: {0}", arr.Min);

            arr.MaxPosition(out int col, out int row);
            Console.WriteLine("Position of max element: [{0}, {1}]", col, row);

            string fileName = "Array2D.txt";
            arr.WriteToFile(fileName);
            Console.WriteLine("Array \n{0} was written to file '{1}'", arr.ToString(), fileName);

            Array2D arrFromFile = new Array2D(fileName);
            Console.WriteLine($"Array from file:\n{arrFromFile.ToString()}");

            Utils.PressAnyKey();
        }
    }
}
