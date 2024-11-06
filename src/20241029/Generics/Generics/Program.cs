using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var meineZahlenListe = CreateIntArray(15, 0);

            var datenListe1 = CreateArray<double>(5, 0.555);
            var datenListe2 = CreateArray<DateTime>(5, DateTime.MinValue);
            var datenListe3 = CreateArray<string>(2, string.Empty);

            List<string> namen = new List<string>();
            
            //int zahl = GetInt("Bitte eine Zahl eingeben: ");
            //double gewicht = GetDouble("Bitte Gewicht eingeben: ");

            var zahl2 = GetValue<int>("Bitte eine Zahl eingeben: ");
            var zahl1 = GetValue<double>("Bitte eine Zahl eingeben: ");
        }

        private static T GetValue<T>(string inputPrompt)
        {
            T value = default(T);
            bool inputIsValid = false;
            Type type = typeof(T);

            do
            {
                Console.Write(inputPrompt);

                try
                {
                    var method = type.GetMethod("Parse", new Type[] { typeof(string) });
                    value = (T)method.Invoke(null, new object[] { Console.ReadLine() });
                   
                    inputIsValid = true;
                }
                catch
                {
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return value;
        }

        private static T[] CreateArray<T>(int elementCount, T initialValue) 
        {
            var array = new T[elementCount];            

            for (int i = 0; i < elementCount; i++)
            {
                array[i] = initialValue;
            }

            return array;
        }

        private static int[] CreateIntArray(int elementCount, int initialValue)
        {
            var array = new int[elementCount];

            for (int i = 0; i < elementCount; i++)
            {
                array[i] = initialValue;
            }

            return array;
        }
    }
}
