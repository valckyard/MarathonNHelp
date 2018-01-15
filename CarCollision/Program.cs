using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CarCollision
{
    public class BrickPos
    {
        public int HeightClass { get; set; }
        public int LaneClass { get; set; }
        public int CompteurClass { get; set; }
    }
    class Program


    {  // car part ▀▀ back  ◘◘◘◘
        static Random Rand = new Random();
        static void CarRenderLeft()
        {
            for (int x = 0; x < 4; ++x)
            {
                int Derriere = 27;
                int RightLane = 4;
                int Avant = 28;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((RightLane), Console.CursorTop = Derriere);
                Console.WriteLine("┌┐");
                Console.SetCursorPosition((RightLane), Console.CursorTop = Avant);
                Console.WriteLine("██");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }


        static void CarRenderRight()
        {
            for (int x = 0; x < 4; ++x)
            {
                int Derriere = 27;
                int RightLane = 9;
                int Avant = 28;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((RightLane), Console.CursorTop = Derriere);
                Console.WriteLine("┌┐");
                Console.SetCursorPosition((RightLane), Console.CursorTop = Avant);
                Console.WriteLine("██");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        
        static void RoadRender(int RoadScore)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("░░");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("I");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    |");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("░░");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("░░");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("I");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("    |");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("░░");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"                 SCORE: {RoadScore}");


            for (int y = 0; y < 28; y++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("░░");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|    ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("I");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("    |");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("░░");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void OldBrickRenderDec(ref List<BrickPos> Pos)
        {
            if (Pos.Count != 0)
            {

                foreach (CarCollision.BrickPos p in Pos.ToList())
                {
                    p.CompteurClass = (p.CompteurClass) + 1;
                    p.HeightClass = (p.HeightClass) + 1;
                    if ((p.HeightClass) > 29)
                    {
                        Pos.Remove(p);
                    }
                    else if (p.HeightClass > 2 & p.HeightClass < 30)
                    {
                        Console.SetCursorPosition(p.LaneClass, Console.CursorTop = p.HeightClass);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("╬╬╬╬");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
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

        static void BrickWallRender(ref List<BrickPos> Bricks, int Difficulty)
        {
            int ChancesOfHappeing = 0;

            if (Difficulty == 1)
            ChancesOfHappeing = Rand.Next(0, 5);
            if (Difficulty == 2)
            ChancesOfHappeing = Rand.Next(0, 4);
            if (Difficulty == 3)
            ChancesOfHappeing = Rand.Next(0, 3);
            if (Difficulty == 4)
            ChancesOfHappeing = Rand.Next(0,2);
            if (Difficulty == 5)
            ChancesOfHappeing = 0;

            if (ChancesOfHappeing == 0)
            {
                int Compteur = 0;
                int Height = -5;//Rand.Next(0, 30);
                int RightLane = 3; 
                int LeftLane = 8; 
                int Side = Rand.Next(1, 3); // Right or Left
                if (Side == 1)
                    Side = RightLane;
                else
                    Side = LeftLane;

                // Console.SetCursorPosition((Side), Console.CursorTop = Height);
                //Console.WriteLine("----");

                //cree les cartes avec type i et nomcarte j dans mes enums  //cree les cartes avec type i et nomcarte j dans mes enums
                Bricks.Add(new BrickPos() { HeightClass = Height, LaneClass = Side , CompteurClass = Compteur });

                /*
                Bricks[Bricks.Count - 1].HeightClass = Height;
                Bricks[Bricks.Count - 1].LaneClass = Side;
                    Bricks[Bricks.Count -1].CompteurClass = Compteur;
            */
                }
            //else
            {
                //fuck off yen a pas
            }
        }

    
        static void DoubleBrickTooClose(ref List<BrickPos> Pos)
        {
            //int deleted = 0;
            foreach (CarCollision.BrickPos p in Pos.ToList())
                if (p.CompteurClass < 5 & Pos.Count > 2)
                {
                    foreach (CarCollision.BrickPos p2 in Pos.ToList())
                        if (((p.HeightClass) - 1 == p2.HeightClass | (p.HeightClass) - 2 == p2.HeightClass) & (p.LaneClass != p2.LaneClass))
                        {
                            int LR = Rand.Next(1, 3);
                            if (LR == 1)
                            {
                                Pos.Remove(p);
                                //deleted = 1;
                                break;
                            }
                            else
                            {
                                Pos.Remove(p2);
                                //deleted = 1;
                                break;
                            }

                        }
                        else if (((p.HeightClass) - 1 == p2.HeightClass | (p.HeightClass) - 2 == p2.HeightClass) & (p.LaneClass == p2.LaneClass))
                        {

                            {
                                Pos.Remove(p2);
                                //deleted = 1;
                                break;
                            }


                        }
                }
            //if (deleted == 1)
              //  DoubleBrickTooClose(ref Pos);

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

        static void OverlapCheck(bool CarLane, List<BrickPos> Pos,int Score)
        {

            foreach(CarCollision.BrickPos p in Pos.ToList())
            {
                if (p.HeightClass > 26 & p.HeightClass < 29)
                {
                    if (p.LaneClass == 8 & CarLane == true)
                    {
                        GameOver(Score);
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                    else if (p.LaneClass == 3 & CarLane == false)
                    {
                        GameOver(Score);
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                }
            }
        }
        static void IntroQuestions(ref int Speed, ref int Difficulty)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"_________                       _________");
            Console.WriteLine(@"__  ____/ _____ ________        __   ____/ _____ _______ ________");
            Console.WriteLine(@"_  /     _  __ ` / _  ___ /     _ /   __ _  __  `/_  __`__ \  _  \");
            Console.WriteLine(@"/ / ___  / /_ / / _   /          / /_/ / / /_/  /_  / / / / / __ /");
            Console.WriteLine(@"\____ /  \__,_ / / _ /           \____/  \__,_ / / / /_/ /_/\___/");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            Console.WriteLine("Difficulty Level : 1- Very Easy          Speed : S - Slow");
            Console.WriteLine("                   2- Easy                       N - Normal");
            Console.WriteLine("                   3- Normal                     F - Fast");
            Console.WriteLine("                   4- Hard                       R - Ridonculous");
            Console.WriteLine("                   5- Very Hard ");
            //while (Difficulty == 0 & Speed == 0)
            do
            {
                
                    
                    var  THEKEY = Console.ReadKey();

                    switch (THEKEY.Key)
                    {
                        case ConsoleKey.D1:
                            Difficulty = 1;
                            Console.WriteLine();
                            Console.WriteLine("Difficulty Set ! Very Easy!");
                            break;
                        case ConsoleKey.D2:
                            Difficulty = 2;
                            Console.WriteLine("Difficulty Set ! Easy!");
                            break;
                        case ConsoleKey.D3:
                            Difficulty = 3;
                            Console.WriteLine("Difficulty Set ! Normal!");
                            break;
                        case ConsoleKey.D4:
                            Difficulty = 4;
                            Console.WriteLine("Difficulty Set ! Hard!");
                            break;
                        case ConsoleKey.D5:
                            Difficulty = 5;
                            Console.WriteLine("Difficulty Set ! Very Hard!");
                            break;

                        case ConsoleKey.S:
                            Speed = 400;
                            Console.WriteLine("Speed Set ! Slow!");
                            break;
                        case ConsoleKey.N:
                            Speed = 200;
                            Console.WriteLine("Speed Set ! Normal!");
                            break;
                        case ConsoleKey.F:
                            Speed = 100;
                            Console.WriteLine("Speed Set ! Fast!");
                            break;
                        case ConsoleKey.R:
                            Speed = 25;
                            Console.WriteLine("Speed Set ! Ridonculous!");
                            break;
                    }
                
            } while (Difficulty == 0 | Speed == 0);


        }

        static void GameOver(int score)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;

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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"SCORE : {score}");

        }

        // var statiques
        static bool LeftRight;
        static List<BrickPos> BrickPosition;

        static void Main(string[] args)
        {
            // dec var
            LeftRight = false;
            BrickPosition = new List<BrickPos>();
            int Speed = 0;
            int Difficulty = 0;

            IntroQuestions(ref Speed, ref Difficulty);



            int Road = 10000000;


            for (int x = 0; x < Road; ++x)
            {
                RoadRender(x);

                OldBrickRenderDec(ref BrickPosition); // old brick goes down one
                BrickWallRender(ref BrickPosition , Difficulty);  // 
                KeyMachinRightLeft(ref LeftRight);
                CarDirectSwitch(ref LeftRight);
                Thread.Sleep(Speed);
                Console.Clear();
                DoubleBrickTooClose(ref BrickPosition);
                OverlapCheck(LeftRight, BrickPosition, x);
            }
        }
    }
}
