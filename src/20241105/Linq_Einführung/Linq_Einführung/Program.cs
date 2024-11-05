using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Linq_Einführung
{
    //public delegate void DoSomething(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = PrintMessageUpperCase;

            //DoSomething action = PrintMessageUpperCase;

            action("Dies ist ein Delegate-Aufruf.");

            //anonyme Methoden
            action = delegate (string textMessage)
            {
                Console.WriteLine(textMessage.ToLower());
            };

            action("Aufruf über eine anonyme Methode...");

            //Linq
            action = (string message) =>
            {
                var parts = message.Split(' ');
                foreach (var part in parts)
                {
                    Console.WriteLine(part);
                }
            };

            action("Hier wurde Linq angewandt.");

            action = msg => Console.WriteLine(msg);
            action("Ohne Nix!");

            int[] numberList = new int[] { 2, 3, 4, 8, 6, 10, 12, 19, 25, 33, 48, 50 };

            var filteredNumbers = ExecuteFilter(numberList, IsLessThanFive);

            filteredNumbers = ExecuteFilter(numberList, x => x > 10);
            filteredNumbers = ExecuteFilter(numberList, x => x % 2 == 0);

            filteredNumbers = numberList.Where(x => x > 11);

            numberList.Select(x => x.ToString())
                      .Where(x => x.Length > 1)
                      .ToList()
                      .ForEach(x => Console.WriteLine(x));
        }

        private static bool IsLessThanFive(int number)
        {
            return number < 5;           
        }

        static IEnumerable<int> ExecuteFilter(IEnumerable<int> numberListToFilter, Predicate<int> filter)
        {
            var filteredNumbers = new List<int>();

            foreach (var number in numberListToFilter)
            {
                if (filter(number))
                {
                    filteredNumbers.Add(number);
                }
            }

            return filteredNumbers;
        }


        private static void PrintMessageUpperCase(string text)
        {
            Console.WriteLine(text.ToUpper());
        }
    }

    public delegate bool FilterMethodHandler(int number);
}
