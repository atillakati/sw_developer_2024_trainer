using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
            

            Radio soundMachine = new Radio();

            soundMachine.PowerStateChanged += SoundMachine_PowerStateChanged2; ;
            //soundMachine.PowerStateChanged += SoundMachine_PowerStateChanged1; ;

            soundMachine.SetPowerState(RadioState.On);
            soundMachine.Play();

            //soundMachine.PowerStateChanged -= SoundMachine_PowerStateChanged;

            while (true) ;
        }

        private static void SoundMachine_PowerStateChanged2(object sender, PowerStateChangedEventArgs e)
        {
            Console.WriteLine("Ereignis empfangen:");

            if (sender is Radio radio)
            {                
                Console.WriteLine(radio.ToString());
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            Console.SetCursorPosition(50, 0);
            Console.WriteLine(DateTime.Now.ToLongTimeString());

            Console.SetCursorPosition(left, top);

        }

        private static void SoundMachine_PowerStateChanged1(Radio radio)
        {
            Console.WriteLine("Ereignis empfangen:");
            Console.WriteLine(radio.ToString());
        }

        private static void SoundMachine_PowerStateChanged(Radio radio)
        {            
            Console.WriteLine("Radio wurde eingeschaltet.");
        }
    }
}
