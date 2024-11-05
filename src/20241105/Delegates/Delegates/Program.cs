using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void DoSomethingHandler(string message);

    public delegate void ErrorMessageHandler(Exception ex);

    internal class Program
    {
        static void Main(string[] args)
        {
            DoSomethingHandler myMethod = PrintUppercaseMessage;
            
            myMethod("Das geht auch...");

            var alter = GetValue<int>("Bitte Alter eingeben: ", DisplayError);
        }

        private static void DisplayError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        private static void PrintUppercaseMessage(string text)
        {
            Console.WriteLine(text.ToUpper());
        }

        private static T GetValue<T>(string inputPrompt,
                                     ErrorMessageHandler messageHandler) where T : struct  
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
                catch(Exception ex) 
                {
                    //if (messageHandler != null)
                    //{
                    //    messageHandler(ex.InnerException);
                    //}

                    messageHandler?.Invoke(ex.InnerException);

                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return value;
        }
    }
}
