using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibary
{
    class Program
    {
        private static void FillDictionary(Dictionary<string,string> dictionary)
        {
            List<string> figures = new List<string>();
            FillList(figures);
            int id = 0;
            foreach(var figure in figures)
            {
                id++;
                dictionary.Add(Convert.ToString(id), figure);
            }
        }
        private static void FillList(List<string> figures)
        {
            figures.Add("Найти площядь прямоугольный треугольник по 3 сторонам");
            figures.Add("Найти площядь круга по радиусу");
        }
        private static void ShowChoise(Dictionary<string, string> dictionary)
        {
            FillDictionary(dictionary);
            foreach (KeyValuePair<string,string> entry in dictionary)
            {
                Console.WriteLine($"({entry.Key}){entry.Value}");
            }
        }
        
        static void Main(string[] args)
        {
            Figure figure;
            Dictionary<string, string> chose = new Dictionary<string, string>();
            Console.WriteLine("*******************************************");
            Console.WriteLine("ЭТО ПРОГРАММА ДЛЯ ВЫЧЕСЛЕНИЕ ПЛОЩЯДЬ ФИГУРЫ");
            Console.WriteLine("*******************************************");
            ShowChoise(chose);
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Write("Сторона a<<<");
                    string sideA = Console.ReadLine();
                    //
                    Console.Write("Сторона b<<<");
                    string sideB = Console.ReadLine();
                    //
                    Console.Write("Сторона c<<<");
                    string sideC = Console.ReadLine();

                    figure = new Figure(Convert.ToInt32(sideA), Convert.ToInt32(sideB), Convert.ToInt32(sideC));
                    figure.FindFigure();
                    break;
                case "2":
                    Console.Write("Радиус круга<<<");
                    string raduis = Console.ReadLine();

                    figure = new Figure(Convert.ToInt32(raduis));
                    figure.FindFigure();
                    break;
            }
            Console.ReadLine();
        }
    }
}
