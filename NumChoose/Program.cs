using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumChoose
{
    class Program
    {
        static bool WinValue = false;
        public static void Main(string[] args)
        {
            Random Rand = new Random();
            int TheNumber = Rand.Next(0, 10);
            int AwnserParsed;

            do
            {
                Console.WriteLine("Bienvenue Dans le Jeu de Nombre Aleatoire");
                Console.WriteLine("------------------------------------------");

                Console.WriteLine("Choisi un nombre entre 1 et 20! :");
                while ((int.TryParse(Console.ReadLine(), out AwnserParsed) == false) & (AwnserParsed < 1) & (AwnserParsed > 20)) { Console.WriteLine("Ce n'est pas un nombre valide!"); }
                if (AwnserParsed == TheNumber)
                {
                    WinValue = true;
                    Console.WriteLine("Win Motherfucker !");
                    Console.WriteLine();
                }
                else
                {
                    WinValue = false;
                    Console.WriteLine("Try Again you suck !");
                    Console.WriteLine();
                }
            } while (WinValue == false);
            Console.ReadLine();
        }
    }
}
