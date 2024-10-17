using System;


namespace Uebung_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punkt p1 = new Punkt
            {
                xPos = 5,
                yPos = 8,
                Name = "p1",
                Color = ConsoleColor.Yellow
            };

            Punkt p2;            


            //punkte kopieren und verändern
            p2 = p1;            
            if(p1 == p2)
            {
                Console.WriteLine("Die Punkte sind gleich!");
            }
            else
            {
                Console.WriteLine("Die Punkte sind unterschiedlich!");
            }

            p2.Name = "p2";
            p2.xPos = 15;

            DrawPoint(p2);
            Console.WriteLine(p2.Name);

            DrawPoint(p1);

            Console.WriteLine();
        }


        private static void DrawPoint(Punkt pointToDraw)
        {
            //if(pointToDraw == null)
            //{
            //    return;
            //}

            ConsoleColor oldColor = Console.ForegroundColor;

            Console.SetCursorPosition(pointToDraw.xPos, pointToDraw.yPos);
            Console.ForegroundColor = pointToDraw.Color;

            Console.Write(pointToDraw.Name);
            Console.ForegroundColor = oldColor;

            //hack
            pointToDraw.Name = "NoName";
        }
    }
}
