using System;


namespace Wifi.ConsoleTools
{
    public abstract class Helper
    {
        public static DateTime GetDateTimeValue(string inputPrompt)
        {
            string inputString = string.Empty;
            bool inputIsNotValid = true;
            DateTime inputValue = DateTime.MinValue;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();

                try
                {
                    inputValue = DateTime.Parse(inputString);
                    inputIsNotValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\aERROR: " + ex.Message);
                    inputIsNotValid = true;
                }
            }
            while (inputIsNotValid);

            return inputValue;
        }

        public static int GetIntValue(string inputPrompt)
        {
            string inputString = string.Empty;
            bool inputIsNotValid = true;
            int inputValue = 0;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();

                try
                {
                    inputValue = int.Parse(inputString);
                    inputIsNotValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\aERROR: " + ex.Message);
                    inputIsNotValid = true;
                }
            }
            while (inputIsNotValid);

            return inputValue;
        }

        public static void CreateHeader()
        {
            Console.Clear();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Textart generated with https://tools.picsart.com/text/font-generator/text-art/
            Console.WriteLine("  _______   _ _            _                      __      __                     _ _                            ___  \r\n |__   __| (_) |          | |                     \\ \\    / /                    | | |                          |__ \\ \r\n    | | ___ _| |_ __   ___| |__  _ __ ___   ___ _ _\\ \\  / /__ _ ____      ____ _| | |_ _   _ _ __   __ _  __   __ ) |\r\n    | |/ _ \\ | | '_ \\ / _ \\ '_ \\| '_ ` _ \\ / _ \\ '__\\ \\/ / _ \\ '__\\ \\ /\\ / / _` | | __| | | | '_ \\ / _` | \\ \\ / // / \r\n    | |  __/ | | | | |  __/ | | | | | | | |  __/ |   \\  /  __/ |   \\ V  V / (_| | | |_| |_| | | | | (_| |  \\ V // /_ \r\n    |_|\\___|_|_|_| |_|\\___|_| |_|_| |_| |_|\\___|_|    \\/ \\___|_|    \\_/\\_/ \\__,_|_|\\__|\\__,_|_| |_|\\__, |   \\_/|____|\r\n                                                                                                    __/ |            \r\n                                                                                                   |___/             ");

            Console.ResetColor();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));
        }
    }
}
