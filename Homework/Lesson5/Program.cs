/**
 * @author Aivar Sergeev
 * @description
 * 
 * 1. Создать программу, которая будет проверять корректность ввода логина.
 *    Корректным логином будет строка от 2 до 10 символов, содержащая только
 *    буквы латинского алфавита или цифры, при этом цифра не может быть первой:
 *    а) без использования регулярных выражений;
 *    б) *с использованием регулярных выражений.
 * 
 * 2. Разработать класс Message, содержащий следующие статические методы для
 *    обработки текста:
 *    а) Вывести только те слова сообщения, которые содержат не более n букв.
 *    б) Удалить из сообщения все слова, которые заканчиваются на заданный
 *       символ.
 *    в) Найти самое длинное слово сообщения.
 *    г) Сформировать строку с помощью StringBuilder из самых длинных слов
 *       сообщения.
 *    Продемонстрируйте работу программы на текстовом файле с вашей программой.
 * 
 * 3. *Для двух строк написать метод, определяющий, является ли одна строка
 *    перестановкой другой. Регистр можно не учитывать:
 *    а) с использованием методов C#;
 *    б) *разработав собственный алгоритм.
 *    Например:
 *    badc являются перестановкой abcd.
 * 
 * 4. Задача ЕГЭ.
 *    *На вход программе подаются сведения о сдаче экзаменов учениками 9-х
 *    классов некоторой средней школы. В первой строке сообщается количество
 *    учеников N, которое не меньше 10, но не превосходит 100, каждая
 *    из следующих N строк имеет следующий формат:
 *    <Фамилия> <Имя> <оценки>,
 *    где <Фамилия> — строка, состоящая не более чем из 20 символов,
 *    <Имя> — строка, состоящая не более чем из 15 символов,
 *    <оценки> — через пробел три целых числа, соответствующие оценкам по
 *    пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки>
 *    разделены одним пробелом.
 *    
 *    Пример входной строки:
 *    Иванов Петр 4 5 3
 *    Требуется написать как можно более эффективную программу, которая будет
 *    выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
 *    Если среди остальных есть ученики, набравшие тот же средний балл,
 *    что и один из трёх худших, следует вывести и их фамилии и имена.
 *    
 *    Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы.
 *    Переписывайте в начало программы условие и свою фамилию.
 *    Все программы сделать в одном решении. Для решения задач используйте 
 *    неизменяемые строки (string).
 * 
 * 5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ,
 *    правда это или нет. Например: «Шариковую ручку изобрели в древнем Египте»,
 *    «Да». Компьютер загружает эти данные, случайным образом выбирает
 *    5 вопросов и задаёт их игроку. Игрок отвечает Да или Нет на каждый вопрос
 *    и набирает баллы за каждый правильный ответ. Список вопросов ищите во
 *    вложении или воспользуйтесь интернетом.
 */
using System;
using System.Text.RegularExpressions;

namespace Lesson5
{
    class Utils
    {
        static public void GoToMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] - Task 1 (Validation of login)");
            Console.WriteLine("[2] - Task 2 (Class Message)");
            Console.WriteLine("[3] - Task 3 (Swapped strings)");
            Console.WriteLine("[4] - Task 4 (2D Array)");
            Console.WriteLine("[5] - Task 5 (Quiz)");
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
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public bool ValidateLoginRegEx(string login)
        {
            Regex regex = new Regex(@"^\D[\w]{1,9}$");
            return regex.IsMatch(login);
        }
        
        static public bool ValidateLogin(string login)
        {
            int minLength = 2;
            int maxLength = 10;

            if (login.Length < minLength || maxLength < login.Length)
            {
                return false;
            }
            for (int i = 0; i < login.Length; i++)
            {
                char symbol = login[i];
                if (NotUpperLatinChar(symbol) && NotLowerLatinChar(symbol) && NaN(symbol))
                {
                    return false;
                }
            }
            return NaN(login[0]);
        }

        static bool NotUpperLatinChar(char symbol)
        {
            int firstUpperLatinIndex = 65;
            int secondUpperLatinIndex = 90;
            return symbol < firstUpperLatinIndex || secondUpperLatinIndex < symbol;
        }
        
        static bool NotLowerLatinChar(char symbol)
        {
            int firstLowerLatinIndex = 97;
            int secondLowerLatinIndex = 122;
            return symbol < firstLowerLatinIndex || secondLowerLatinIndex < symbol;
        }

        static bool NaN(char symbol)
        {
            int firstNumberIndex = 48;
            int secondNumberIndex = 57;
            return symbol < firstNumberIndex || secondNumberIndex < symbol;
        }
    }

    class Message
    {
        private static string[] separators = { ".", ",", ";", "!", "?", ":", " " };

        public static void PrintWordsByLength(string msg, int wordLengthMax)
        {
            string[] words = msg.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            Console.Write("Found words with length no more than ");
            Utils.PrintColorLine(wordLengthMax.ToString(), ConsoleColor.Red);

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string word in words)
            {
                if (word.Length <= wordLengthMax)
                {
                    Console.WriteLine($" - {word}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RemoveWithLastSymbol(string msg, char lastSymbol)
        {
            string[] words = msg.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Removed words:");
            foreach (string word in words)
            {
                if (word[word.Length - 1] == lastSymbol)
                {
                    Console.WriteLine($" - {word}");
                }
            }
        }

        public static void FindLongestWord(string msg)
        {
            string[] words = msg.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = words[0];

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            Console.Write("The longest word is ");
            Utils.PrintColorLine(longestWord, ConsoleColor.Green);
        }

        public static void PrintAllLongestWords(string msg)
        {
            string[] words = msg.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int wordLengthMax = GetMaxWordLength(words);

            Console.Write("Found words with max length ");
            Utils.PrintColorLine(wordLengthMax.ToString(), ConsoleColor.Red);

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string word in words)
            {
                if (word.Length <= wordLengthMax)
                {
                    Console.WriteLine($" - {word}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
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
                    case 5:
                        RunTask5();
                        break;
                }
            } while (taskNumber != 0);
        }

        static void RunTask1()
        {
            string login;
            bool isValidLogin;
            do
            {
                Console.Clear();
                Console.Write("Please input your login (exit - 0): ");
                login = Console.ReadLine();
                isValidLogin = Utils.ValidateLoginRegEx(login);

                if (login != "0")
                {
                    Console.WriteLine("Login '{0}' is {1}", login, isValidLogin ? "valid" : "invalid");
                    if (isValidLogin)
                    {
                        break;
                    }
                    Console.ReadKey();
                }
            } while (login != "0");

            Utils.PressAnyKey();
        }

        static void RunTask2()
        {
            Console.Clear();

            string msg = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam urna.";
            Console.Write("initial message: ");
            Utils.PrintColorLine(msg, ConsoleColor.Yellow);

            Message.PrintWordsByLength(msg, 5);
            Message.FindLongestWord(msg);

            Utils.PressAnyKey();
        }

        static void RunTask3()
        {
            Console.Clear();
            
            Utils.PressAnyKey();
        }

        static void RunTask4()
        {
            Console.Clear();

            Utils.PressAnyKey();
        }

        static void RunTask5()
        {
            Console.Clear();

            Utils.PressAnyKey();
        }
    }
}
