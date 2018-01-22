using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Carreau
    {
        public int Hauteur { get; set; }
        public int Largeur { get; set; }

    }
    class Program
    {
        public void Position(List<Carreau> Laliste)
        {

        }

        static void Affichage()
        {
            Console.WriteLine("          1            2            3");
            Console.WriteLine("      ______________________________________");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine(" 1   |            |            |            |");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine("     |____________|____________|____________|");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine(" 2   |            |            |            |");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine("     |____________|____________|____________|");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine(" 3   |            |            |            |");
            Console.WriteLine("     |            |            |            |");
            Console.WriteLine("     |____________|____________|____________|");

        }
        static void Xrender(int x, int y)
        {
            Console.SetCursorPosition(x, Console.CursorTop = y);
            Console.WriteLine(@"\  /");
            Console.SetCursorPosition(x, Console.CursorTop = y + 1);
            Console.WriteLine(@" \/");
            Console.SetCursorPosition(x, Console.CursorTop = y + 2);
            Console.WriteLine(@" /\ ");
            Console.SetCursorPosition(x, Console.CursorTop = y + 3);
            Console.WriteLine(@"/  \");
        }
        public static void AddNewSpot(List<Carreau> LaListe, List<Carreau> Liste2, int Valeurx, int Valeury)
        {
            bool Ajouter = true;

            Ajouter = CheckIfUsed(Liste2, Valeurx, Valeury);

            if (Ajouter == true)
            {
                foreach (Carreau c in LaListe)
                {
                    if (c.Hauteur == Valeury & c.Largeur == Valeurx)
                        Console.WriteLine("nonvald");
                    else
                        LaListe.Add(new Carreau() { Hauteur = Valeury, Largeur = Valeury });
                }
            }
        }
        public static bool CheckIfUsed(List<Carreau> Liste2 , int x , int y)
        {
            foreach(Carreau c in Liste2)
            {
                if (c.Hauteur == y & c.Largeur == x)
                    Console.WriteLine("nonvald");
                return false;
            }
            return true;
        }
        static List<Carreau> Listex;
        static List<Carreau> Liste0;
        static void Main(string[] args)
        {
            Affichage();
            List<Carreau> Liste0 = new List<Carreau>();
            List<Carreau> Listex = new List<Carreau>();
           
           // x y lequel

        }
    }
}