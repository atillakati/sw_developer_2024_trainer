using System;
using System.ComponentModel;

namespace ArrayGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //constanten
            const int MAX_ELEMENT_COUNT = 15;

            //Deklaration
            string[] listOfNames;

            //Dimensionierung            
            listOfNames = new string[MAX_ELEMENT_COUNT];
            //listOfNames = new string[20];

            //Initialisierung            
            listOfNames[0] = string.Empty;
            listOfNames[1] = string.Empty;
            listOfNames[2] = string.Empty;
            listOfNames[3] = string.Empty;

            //Initialisierung "automatisch"
            for(int i=0; i< listOfNames.Length; i++)
            {
                listOfNames[i] = "Test" + i;
            }

            //Ausgabe der Werte
            for(int i = 0; i < listOfNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Element Index: {i} Wert: {listOfNames[i]}");
            }
        }
    }
}
