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
        const int BottomRoad = 30;
        const int TopRoad = 0;
        const int DerriereVehicule = 27;
        static readonly int[] LaneMap = { 10, 15 }; // base 3 8 ... 10


        static void IntroQuestions(out int Difficulty, out int SpeedRef)
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

            Difficulty = 0;
            SpeedRef = 0;
            do
            {


                var THEKEY = Console.ReadKey();

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
                        SpeedRef = 225;
                        Console.WriteLine("Speed Set ! Slow!");
                        break;
                    case ConsoleKey.N:
                        SpeedRef = 150;
                        Console.WriteLine("Speed Set ! Normal!");
                        break;
                    case ConsoleKey.F:
                        SpeedRef = 75;
                        Console.WriteLine("Speed Set ! Fast!");
                        break;
                    case ConsoleKey.R:
                        SpeedRef = 25;
                        Console.WriteLine("Speed Set ! Ridonculous!");
                        break;
                }

            } while (Difficulty == 0 | SpeedRef == 0);

        }

        // IN
        static int KeyLeftRight() // Key PRESS
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.LeftArrow)
                    return -1;

                if (key.Key == ConsoleKey.RightArrow)
                    return 1;

                // insurance
                /*
                if (KeyPosition > 1)
                    KeyPosition = 1;
                else if (KeyPosition < -1)
                    KeyPosition = -1;
                    */
            }


            return 0;
        }

        static void UpdateCarPos(ref int carPos, int deltaPos)
        {
            carPos = Clamp(carPos + deltaPos, 0, LaneMap.Length - 1);
//            if (carPos < 0) carPos = 0;
//            if (carPos >= LaneMap.Length) carPos = LaneMap.Length - 1;
        }

        static int Clamp(int val, int min, int max)
        {
            if (val < min)
                return min;
            if (val > max)
                return max;
            return val;
        }


        static Random Rand = new Random();



        static void CarRender(int CarPos)
        {
            for (int x = 0; x < LaneMap.Length; ++x)
            {
                if (x == CarPos)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(LaneMap[x]+1, Console.CursorTop = DerriereVehicule);
                    Console.WriteLine("┌┐");
                    Console.SetCursorPosition(LaneMap[x]+1, Console.CursorTop = DerriereVehicule + 1);
                    Console.WriteLine("██");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(LaneMap[x]+1, Console.CursorTop = DerriereVehicule);
                    Console.WriteLine("  ");
                    Console.SetCursorPosition(LaneMap[x]+1, Console.CursorTop = DerriereVehicule + 1);
                    Console.WriteLine("  ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        
        static void RoadRender()
        {
            int RoadSide = LaneMap[0] - 3;
            Console.SetCursorPosition(RoadSide, Console.CursorTop = TopRoad);
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
            Console.SetCursorPosition(RoadSide, Console.CursorTop = TopRoad+1);
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
            Console.WriteLine($"                 SCORE:");


            for (int y = 0; y < BottomRoad -2; y++)
            {
                Console.SetCursorPosition(RoadSide, Console.CursorTop = TopRoad +(y+2));
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
        static void ScoreRender(int Score)
        {
            int RoadSide = LaneMap[0] - 3;
            Console.SetCursorPosition(RoadSide + 39, Console.CursorTop = TopRoad +1);
            Console.WriteLine($"{Score}");
        }
        static void OldBrickRenderDec(List<BrickPos> Pos)
        {
            if (Pos.Count != 0)
            {

                foreach (CarCollision.BrickPos p in Pos.ToList())
                {
                    p.CompteurClass = (p.CompteurClass) + 1;
                    p.HeightClass = (p.HeightClass) + 1;
                    if ((p.HeightClass) > BottomRoad)
                    {
                        Pos.Remove(p);
                    }
                    else if (p.HeightClass > TopRoad + 1 & p.HeightClass < BottomRoad)
                    {
                        Console.SetCursorPosition(LaneMap[p.LaneClass], Console.CursorTop = p.HeightClass-1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(LaneMap[p.LaneClass], Console.CursorTop = p.HeightClass);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("╬╬╬╬");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if(p.HeightClass == BottomRoad)
                    {
                        Console.SetCursorPosition(LaneMap[p.LaneClass], Console.CursorTop = p.HeightClass - 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }


        // lg
        static void BrickWallRender(List<BrickPos> Bricks, int Difficulty)
        {
            int ChancesOfHappeing = 0;

            if (Difficulty == 1)
            ChancesOfHappeing = Rand.Next(0, 20);
            if (Difficulty == 2)
            ChancesOfHappeing = Rand.Next(0, 10);
            if (Difficulty == 3)
            ChancesOfHappeing = Rand.Next(0, 5);
            if (Difficulty == 4)
            ChancesOfHappeing = Rand.Next(0, 2);
            if (Difficulty == 5)
            ChancesOfHappeing = 0;
            
            if (ChancesOfHappeing == 0)
            {
                bool NewBrickTF = true;
                foreach (BrickPos b in Bricks)
                {
                    if (b.HeightClass < TopRoad+3)
                        NewBrickTF = false;
                }
                if (NewBrickTF == true)
                {
                    int Compteur = 0;
                    int Height = TopRoad;//Rand.Next(0, 30);
                    int Side = Rand.Next(LaneMap.Length); // Right or Left

                    Bricks.Add(new BrickPos() { HeightClass = Height, LaneClass = Side, CompteurClass = Compteur });
                }
                }

        }

    
        static void DoubleBrickTooClose(List<BrickPos> Pos)
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


        static void OverlapCheck(int CarPos, List<BrickPos> Pos, int Score)
        {

            foreach(CarCollision.BrickPos p in Pos.ToList())
            {
                if (p.HeightClass >= DerriereVehicule + 1 & p.HeightClass < BottomRoad - 1)
                {
                    if (p.LaneClass == CarPos)
                    {
                        GameOver(Score);
                        Console.ReadLine();
                        Console.Clear();
                        Game();
                        //Environment.Exit(1);
                    }
                }
            }
        }




        static void CarDirectOut(int CarPos) // Direction Switch
        {
                    CarRender(CarPos);
        }

        static void GameOver(int Score)
        {

            Console.Clear();
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
            Console.WriteLine($"SCORE : {Score}");

        }

        static void INPUTENTREE(List<BrickPos> BrickPosition, int Difficulty, out int DeltaPosition)
        {
            DeltaPosition = KeyLeftRight();                     //d'input
            BrickWallRender(BrickPosition, Difficulty);// new construct
        }

        static void UPDATE(ref int CarPos, int DeltaPosition, int Score)
        {
            UpdateCarPos(ref CarPos, DeltaPosition);// Calc POS
           // DoubleBrickTooClose(BrickPosition);    // Verif
            OverlapCheck(CarPos, BrickPosition, Score);// Verif
        }

        static void RENDER(int CarPos, List<BrickPos> BrickPosition, int Score)
        {
            CarDirectOut(CarPos);               // Out Renderer
            OldBrickRenderDec(BrickPosition); // Out Renderer
            ScoreRender(Score); //12
        }

        // var statiques
        static List<BrickPos> BrickPosition;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game();
        }
        static void Game()
        {
            int SpeedRef = 0;
            int Difficulty = 0;
            BrickPosition = new List<BrickPos>();

            IntroQuestions(out Difficulty, out SpeedRef);
            Console.Clear();


            int Road = 10000000;
            int CarPos = 0;

            RoadRender();


            for (int x = 0; x < Road; ++x)
            {
                INPUTENTREE(BrickPosition, Difficulty,out int DeltaPosition);
                UPDATE(ref CarPos, DeltaPosition, x);
                RENDER(CarPos, BrickPosition, x);
                Thread.Sleep(SpeedRef);
            }
        }
    }
}
