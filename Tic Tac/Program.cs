using System;
using System.Collections.Generic;
using System.Linq;

namespace Tic_Tac
{
    public enum CaseGrid
    {
        C1,
        C2,
        C3,
        C4,
        C5,
        C6,
        C7,
        C8,
        C9,
    }

    public enum ValeurCase
    {
        Vide,
        X,
        O,
    }
    public class GridClass
    {
        public bool Used { get; set; }
        public ValeurCase Valeur { get; set; }
        public CaseGrid Nom { get; set; }
    }

    internal class Program
    {
        static void Grid()
        {
            _myGrid = new List<GridClass>();
            for (int x = 0; x < 9; x++)
            {
                _myGrid.Add(new GridClass() {Used = false, Nom = (CaseGrid)x });
            }
        }

        public static void Affichage()
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine("-----------");
            Console.WriteLine("   |   |   ");
            Console.WriteLine("-----------");
            Console.WriteLine("   |   |   ");
        }
        public static void AffichageUpdate()
        {
            foreach (GridClass g in _myGrid.ToList())
            {

                switch (g.Nom)
                {
                    case CaseGrid.C1:
                        Console.SetCursorPosition(1, 0);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("1");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C2:
                        Console.SetCursorPosition(5, 0);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("2");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C3:
                        Console.SetCursorPosition(9, 0);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("3");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C4:
                        Console.SetCursorPosition(1, 2);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("4");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C5:
                        Console.SetCursorPosition(5, 2);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("5");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C6:
                        Console.SetCursorPosition(9, 2);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("6");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C7:
                        Console.SetCursorPosition(1, 4);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("7");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C8:
                        Console.SetCursorPosition(5, 4);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("8");
                                }
                                break;
                        }
                        break;
                    case CaseGrid.C9:
                        Console.SetCursorPosition(9, 4);
                        switch (g.Used)
                        {
                            case true:
                                {
                                    WriteXo(g);
                                }
                                break;
                            case false:
                                {
                                    Console.Write("9");
                                }
                                break;
                        }
                        break;
                }
                Console.SetCursorPosition(0, 10);
            }
        }

        public static void WriteXo(GridClass g)
        {
            switch (g.Valeur)
            {
                case ValeurCase.O:
                    {
                        Console.Write("O");
                        break;
                    }
                case ValeurCase.X:
                    {
                        Console.Write("X");
                        break;
                    }
            }
        }

        static void PlayerSwitch()
        {
            if (Player == 1)
                Player = 2;
            else
                Player = 1;
        }

        static void WinLoseCheck() // make more efficient
        {
            foreach(GridClass c in _myGrid)
            {

            }
            if ((_myGrid[0].Used & _myGrid[1].Used & _myGrid[2].Used) == (true))
            { bool win = true;
                for (int x = 0; x < 3; ++x)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                { Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[3].Used & _myGrid[4].Used & _myGrid[5].Used) == (true))
            {
                bool win = true;
                for (int x = 3; x < 6; ++x)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = !win;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[6].Used & _myGrid[7].Used & _myGrid[8].Used) == (true))
            {
                bool win = true;
                for (int x = 6; x < 9; ++x)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[0].Used & _myGrid[3].Used & _myGrid[6].Used) == (true))
            {
                bool win = true;
                for (int x = 0; x < 7; x += 3)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[1].Used & _myGrid[4].Used & _myGrid[7].Used) == (true))
            {
                bool win = true;
                for (int x = 1; x < 8; x += 3)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[2].Used & _myGrid[5].Used & _myGrid[8].Used) == (true))
            {
                bool win = true;
                for (int x = 2; x < 9; x += 3)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[0].Used & _myGrid[4].Used & _myGrid[8].Used) == (true))
            {
                bool win = true;
                for (int x = 0; x < 9; x += 4)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
            if ((_myGrid[2].Used & _myGrid[4].Used & _myGrid[6].Used) == true)
            {
                bool win = true;
                for (int x = 2; x < 7; x += 2)
                {
                    if (_myGrid[x].Valeur != (ValeurCase)Player)
                    {
                        win = false;
                    }
                }
                if (win == true)
                {
                    Console.Write("Win");
                    Console.WriteLine("    Push any Key to start a New Game!");
                    Console.ReadLine();
                    Console.Clear();
                    NewGame();
                }
            }
        }// on win NewGame();

        static void PlayerChoice()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine($"What Case _player{Player}?");
            Console.SetCursorPosition(0, 11);
            int y;
            while (int.TryParse(Console.ReadLine(), out y) == false)
            {

                if (y < 1 | y > 9)
                    PlayerChoice();
            }


            for (int x = 1; x < 10; x++)
            {
                if (x == y)
                {
                    if (_myGrid[x - 1].Used == true)
                    {
                        PlayerChoice();
                    }
                    if (_myGrid[x - 1].Used == false)
                    {
                        _myGrid[x - 1].Used = true;
                        _myGrid[x - 1].Valeur = (ValeurCase)Player;
                    }
                }
            }
        }

        private static List<GridClass> _myGrid;
        public static int Player; // 1 is O 2 is X

        private static void Main() => NewGame();

        private static void NewGame()
        {
            Player = 1;
            Grid();
            Affichage();
            Run();
        }

        private static void Run()
        {
            AffichageUpdate();
            PlayerChoice();
            WinLoseCheck();
            PlayerSwitch();
            Run();

        }
    }
}
