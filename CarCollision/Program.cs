using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CarCollision
{
    class Program


    {  // car part ▀▀ back  ◘◘◘◘
        static Random Rand = new Random();
        static void CarRenderLeft()
        {
            for (int x = 0; x < 4; ++x)
            {
                int Derriere = 27;
                int RightLane = 2;
                int Avant = 28;
                Console.SetCursorPosition((RightLane), Console.CursorTop = Derriere);
                Console.WriteLine("▄▄");
                Console.SetCursorPosition((RightLane), Console.CursorTop = Avant);
                Console.WriteLine("██");
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
                Console.WriteLine("▄▄");
                Console.SetCursorPosition((RightLane), Console.CursorTop = Avant);
                Console.WriteLine("██");
            }
        }


        static void RoadRender(int RoadScore)
        {
            Console.WriteLine("|    I    |");
            Console.WriteLine($"|    I    |             SCORE: {RoadScore}");
            for (int y = 0; y < 28; y++)
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

        static void BrickWallRender(ref List<int> LHeight, ref List<int> LLane)
        {
            int ChancesOfHappeing = Rand.Next(0, 5);
            // if (ChancesOfHappeing == 0)
            {
                int Height = -5;//Rand.Next(0, 30);
                int RightLane = 1; // a 4
                int LeftLane = 6; // a 10
                int Side = Rand.Next(1, 3); // Right or Left
                if (Side == 1)
                    Side = RightLane;
                else
                    Side = LeftLane;

               // Console.SetCursorPosition((Side), Console.CursorTop = Height);
                //Console.WriteLine("----");
                LHeight.Add(Height);
                LLane.Add(Side);
            }
            //else
            {
                //fuck off yen a pas
            }
        }

        static void OldBrickRenderDec(ref List<int> LHeight, ref List<int> LLane)
        {
            if (LHeight.Count != 0)
            {

                for (int x = 0; x < LHeight.Count; ++x)
                {
                    LHeight[x] = (LHeight[x]) + 1;
                    if ((LHeight[x]) > 29)
                    {
                        LHeight.RemoveAt(x);
                        LLane.RemoveAt(x);
                    }
                    else if (LHeight[x] > 2 & LHeight[x] <30)
                    {
                        Console.SetCursorPosition(LLane[x], Console.CursorTop = LHeight[x]);
                        Console.WriteLine("----");
                    }
                }
            }
        }
        static void DoubleBrickTooClose(bool CarLane, List<int> Height, List<int> Lane)
        {
            if (Height.Count > 5)
            {
                for (int h = 0; h < (Height.Count -4) ; ++h)
                {
                    for (int hall = 1; hall < (Height.Count - 4); ++hall)
                    {

                        if (((Height[h]) - 1 == Height[hall] | (Height[h] - 2) == Height[hall] ) & (Lane[h] != Lane[hall]))
                        {
                            int LR = Rand.Next(1, 3);
                            if (LR == 1)
                            {
                                Height.RemoveAt(h);
                                Lane.RemoveAt(h);
                            }
                            else
                            {
                                Height.RemoveAt(hall);
                                Lane.RemoveAt(hall);
                            }

                        }
                        else if (((Height[h]) - 1 == Height[hall] | (Height[h] - 2) == Height[hall] ) & (Lane[h] == Lane[hall]))
                        {

                            {
                                Height.RemoveAt(hall); //unstable ass part
                                Lane.RemoveAt(hall);
                            }

                        }
                    }
                }
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

        static void OverlapCheck(bool CarLane, List<int> Height, List<int> Lane)
        {

            for (int x = 0; x < Height.Count; ++x)
            {
                if (Height[x] > 26 & Height[x] < 29)
                {
                    if (Lane[x] == 6 & CarLane == true)
                    {
                        GameOver();
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                    else if (Lane[x] == 1 & CarLane == false)
                    {
                        GameOver();
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                }
            }
        }


        static void GameOver()
        {
            Console.WriteLine(@"  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ");
            Console.WriteLine(@" ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒");
            Console.WriteLine(@"▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒");
            Console.WriteLine(@"░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ");
            Console.WriteLine(@"░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒");
            Console.WriteLine(@" ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░");
            Console.WriteLine(@"  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░");
            Console.WriteLine(@"░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ");
            Console.WriteLine(@"      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ");
            Console.WriteLine(@"                                                     ░                   ");
            Console.WriteLine(@" ███▄    █  ██▓  ▄████  ▄▄▄       █    ██ ▓█████▄  ▐██▌                  ");
            Console.WriteLine(@" ██ ▀█   █ ▓██▒ ██▒ ▀█▒▒████▄     ██  ▓██▒▒██▀ ██▌ ▐██▌                  ");
            Console.WriteLine(@"▓██  ▀█ ██▒▒██▒▒██░▄▄▄░▒██  ▀█▄  ▓██  ▒██░░██   █▌ ▐██▌                  ");
            Console.WriteLine(@"▓██▒  ▐▌██▒░██░░▓█  ██▓░██▄▄▄▄██ ▓▓█  ░██░░▓█▄   ▌ ▓██▒                  ");
            Console.WriteLine(@"▒██░   ▓██░░██░░▒▓███▀▒ ▓█   ▓██▒▒▒█████▓ ░▒████▓  ▒▄▄                   ");
            Console.WriteLine(@"░ ▒░   ▒ ▒ ░▓   ░▒   ▒  ▒▒   ▓▒█░░▒▓▒ ▒ ▒  ▒▒▓  ▒  ░▀▀▒                  ");
            Console.WriteLine(@"░ ░░   ░ ▒░ ▒ ░  ░   ░   ▒   ▒▒ ░░░▒░ ░ ░  ░ ▒  ▒  ░  ░                  ");
            Console.WriteLine(@"   ░   ░ ░  ▒ ░░ ░   ░   ░   ▒    ░░░ ░ ░  ░ ░  ░     ░                  ");
            Console.WriteLine(@"         ░  ░        ░       ░  ░   ░        ░     ░                     ");
            Console.WriteLine(@"                                           ░                        ");
        }

        // var statiques
        static bool LeftRight;
        static List<int> BrickPosHeight;
        static List<int> BrickPosLane;

        static void Main(string[] args)
        {
            // dec var
            LeftRight = false;
            BrickPosHeight = new List<int>();
            BrickPosLane = new List<int>();
            int Road = 10000000;

            for (int x = 0; x < Road; ++x)
            {
                RoadRender(x);
                
                OldBrickRenderDec(ref BrickPosHeight, ref BrickPosLane); // old brick goes down one
                BrickWallRender(ref BrickPosHeight, ref BrickPosLane);  // 
                KeyMachinRightLeft(ref LeftRight);
                CarDirectSwitch(ref LeftRight);
                Thread.Sleep(500);
                Console.Clear();
                DoubleBrickTooClose(LeftRight, BrickPosHeight, BrickPosLane);
                OverlapCheck(LeftRight, BrickPosHeight, BrickPosLane);
            }
        }
    }
}
