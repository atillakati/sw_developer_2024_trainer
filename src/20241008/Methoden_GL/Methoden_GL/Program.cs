using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methoden_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayHelloWorld();

            DisplayMessage("C# ist cool!");

            DisplayColoredMessage("Fehler: Zeit abgelaufen!", ConsoleColor.Red);
            DisplayMessage("C# ist cool!");

            string[] myNameList = CreateAndInitArray(50, "leer");
        }

        //Signatur
        //Rückgabetype Methodenbezeichnung( Parameterliste ) 
        static string[] CreateAndInitArray(int elementCount, string initValue)
        {
            string[] aArray = new string[elementCount];

            for(int i = 0; i<elementCount; i++)
            {
                aArray[i] = initValue;
            }

            return aArray;
        }

        static void DisplayColoredMessage(string messageText, ConsoleColor messageColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;
            Console.WriteLine(messageText);
            Console.ForegroundColor = oldColor;
        }

        static void DisplayMessage(string messageText)
        {
            Console.WriteLine(messageText);
        }

        static void DisplayHelloWorld()
        {
            Console.WriteLine("Hello World.");
        }
    }
}
