/**
 * @author Aivar Sergeev
 * @description
 * 1. С помощью рефлексии выведите все свойства структуры DateTime
 */
using System;
using System.Reflection;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("All DateTime properties:");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("|      Property Type|  Property Name|  Can Read|  Can Write|");
            Console.ResetColor();

            Type typeOfDateTime = typeof(DateTime);
            PropertyInfo[] allProperties = typeOfDateTime.GetProperties();

            foreach (PropertyInfo prop in allProperties)
            {
                Console.WriteLine("|{0,19}|{1,15}|{2,10}|{3,11}|", prop.PropertyType, prop.Name, prop.CanRead, prop.CanWrite);
            }
            Console.ReadKey();
        }
    }
}
