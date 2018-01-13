using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CarCollision
{
    class Program
    {
        Random Rand = new Random();
        static void CarRenderLeft()
        {
            for (int x = 0; x < 4; ++x)
            {
                int Derriere = 27;
                int RightLane = 2;
                int Avant = 28;
                Console.SetCursorPosition((RightLane), Console.CursorTop = Derriere);
                Console.WriteLine("__");
                Console.SetCursorPosition((RightLane), Console.CursorTop = Avant);
                Console.WriteLine("[]");
            }
        }


        static void CarRenderRight() 
        {
            for (int x = 0; x < 4; ++x)
            {
                int Derriere = 27;
                int RightLane = 7;
                int Avant = 28;
                Console.SetCursorPosition((RightLane), Console.CursorTop = Derriere);
                Console.WriteLine("__");
                Console.SetCursorPosition((RightLane), Console.CursorTop = Avant);
                Console.WriteLine("[]");
            }
        }


        static void RoadRender()
        {
            for (int y = 0; y < 30; y++)
            {
                Console.WriteLine("|    I    |");
            }
        }


        static void KeyMachinRightLeft(ref bool direct) // Key PRESS
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                direct = ((key.Key == ConsoleKey.LeftArrow) == false);
                direct = ((key.Key == ConsoleKey.RightArrow) == true);
            }
        }


        static void CarDirectSwitch(ref bool Key) // Direction Switch
        {
            switch (Key)
            {
                case false:
                    CarRenderLeft();
                    break;

                case true:
                    CarRenderRight();
                    break;
            }
        }


        static bool LeftRight;

        static void Main(string[] args)
        {
            LeftRight = false;


            int Road = 10000000;



            for (int x = 0; x < Road; ++x)
            {
                RoadRender();
                KeyMachinRightLeft(ref LeftRight);
                CarDirectSwitch(ref LeftRight);
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}
