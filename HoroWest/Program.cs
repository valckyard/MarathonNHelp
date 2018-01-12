using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoroWest
{
    class Program
    {
        static void DecryptHoroWest(int j,int m,int NbJr )
        {


        }
        static int JrAnnee;
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue Dans le Jeu de Horoscope Chinoua!");
            Console.WriteLine("------------------------------------------");
            int Jour;
            int Mois;
            int Annee;
            Console.WriteLine("Votre Jour de Naissance jj :");
            while ((int.TryParse(Console.ReadLine(), out Jour)== false) & (Jour < 1) & (Jour > 31)) { Console.WriteLine("Fuck you tul sais que c pas valide..."); }
            Console.WriteLine("Votre mois de Naissance mm :");
            while ((int.TryParse(Console.ReadLine(), out Mois) == false) & (Mois < 1) & (Mois > 13)) { Console.WriteLine("Fuck you tul sais que c pas valide..."); }
            Console.WriteLine("Votre Annee de Naissance yyyy :");
            while ((int.TryParse(Console.ReadLine(), out Annee) == false) & (Annee < 1900) & (Annee > 2020)) { Console.WriteLine("Prends Moi pas pour un cave"); }
            /*
             * 
                si l'année est divisible par 4 et non divisible par 100, ou
                si l'année est divisible par 400.
            */
            if (((Annee % 4 == 0) & (Annee % 400 != 0)) | (Annee % 400 == 0))
            {
                // annne bisex 
                JrAnnee = 365;
            }
            else
            {
                JrAnnee = 366;
            }


        }
    }
}
