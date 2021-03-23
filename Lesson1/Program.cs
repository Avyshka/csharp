/*
 * @author Aivar Sergeev
 * @description
    1. Написать программу «Анкета». Последовательно задаются вопросы
    (имя, фамилия, возраст, рост, вес). В результате вся информация выводится
    в одну строчку:
        а) используя  склеивание;
	    б) используя форматированный вывод;
	    в) используя вывод со знаком $.

    2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ)
    по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.

    3. а) Написать программу, которая подсчитывает расстояние между точками
    с координатами x1, y1 и x2,y2 по формуле
    r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат,
    используя спецификатор формата .2f (с двумя знаками после запятой);

       б) *Выполнить предыдущее задание, оформив вычисления расстояния между
    точками в виде метода.

    4. Написать программу обмена значениями двух переменных:
        а) с использованием третьей переменной;
	    б) *без использования третьей переменной.

    5. а) Написать программу, которая выводит на экран ваше имя, фамилию и
    город проживания.
       б) *Сделать задание, только вывод организовать в центре экрана.
       в) **Сделать задание б с использованием собственных методов
    (например, Print(string ms, int x,int y).

    6. *Создать класс с методами, которые могут пригодиться в вашей
    учебе (Print, Pause).
 */
using System;

namespace Lesson1
{
    // 6. My class with methods
    class Utils
    {
        static public string GetResponse(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();
            Console.Clear();
            return answer;
        }

        static public double GetBodyMassIndex(double weigth, double height)
        {
            double heightInMeters = height * .01;
            return weigth / (heightInMeters * heightInMeters);
        }

        static public double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        static public void PrintMessageInPosition(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 1. Questionnaire

            string answer1 = Utils.GetResponse("What is your name?");
            string answer2 = Utils.GetResponse("What is your surname?");
            string answer3 = Utils.GetResponse("How old are you?");
            string answer4 = Utils.GetResponse("What is your weight?");
            string answer5 = Utils.GetResponse("What is your height?");

            Console.WriteLine(
                "name: " + answer1 +
                ", surname: " + answer2 +
                ", age: " + answer3 +
                ", weight: " + answer4 +
                ", height: " + answer5
            );
            Console.WriteLine(
                "name: {0}, surname: {1}, age: {2}, weight: {3}, height: {4}",
                answer1,
                answer2,
                answer3,
                answer4,
                answer5
            );
            Console.WriteLine($"name: {answer1}, surname: {answer2}, age: {answer3}, weight: {answer4}, height: {answer5}");

            Console.ReadLine();
            #endregion


            #region 2. Body mass index

            Console.Clear();

            double weight = double.Parse(Utils.GetResponse("Please input your weight: "));
            double height = double.Parse(Utils.GetResponse("Please input your height: "));

            Console.WriteLine("BMI: {0:F2}", Utils.GetBodyMassIndex(weight, height));

            Console.ReadLine();
            #endregion


            #region 3. Distance between two points

            Console.Clear();
            double x1 = double.Parse(Utils.GetResponse("Please set x1: "));
            double y1 = double.Parse(Utils.GetResponse("Please set y1: "));
            double x2 = double.Parse(Utils.GetResponse("Please set x2: "));
            double y2 = double.Parse(Utils.GetResponse("Please set y2: "));
            Console.Write("Distance: {0:F2}", Utils.GetDistance(x1, y1, x2, y2));

            Console.ReadLine();
            #endregion


            #region 4. Change values

            // #1
            Console.Clear();
            int a = 1;
            int b = 2;
            Console.WriteLine("a = {0}, b = {1}", a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("a = {0}, b = {1}", a, b);

            // #2
            int c = 3;
            int d = 4;
            Console.WriteLine("c = {0}, d = {1}", c, d);
            c = (d + c) - (d = c);
            Console.WriteLine("c = {0}, d = {1}", c, d);

            Console.ReadLine();
            #endregion


            #region 5. My info in the center

            Console.Clear();

            string message = "Aivar Sergeev Minsk";
            int posX = (int)(Console.WindowWidth * .5 - (message.Length * .5));
            int posY = (int)(Console.WindowHeight * .5);

            Utils.PrintMessageInPosition(message, posX, posY);

            Console.ReadLine();
            #endregion
        }
    }
}
