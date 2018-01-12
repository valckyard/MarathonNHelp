using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HoroChinouais
{
    class Program
    {
        public static void DecrypHoro(int Annee)
        {
            int x = Annee % 12;
            switch (x)
            {
                case 4:
                    Console.WriteLine("Rat!");
                    break;
                case 5:
                    Console.WriteLine("Buffalo!");
                    break;
                case 6:
                    Console.WriteLine("Tiger!");
                    break;
                case 7:
                    Console.WriteLine("Rabbit!");
                    break;
                case 8:
                    Console.WriteLine("Dragon!");
                    break;
                case 9:
                    Console.WriteLine("Snake!");
                    break;
                case 10:
                    Console.WriteLine("Horse!");
                    break;
                case 11:
                    Console.WriteLine("Ram!");
                    break;
                case 0:
                    Console.WriteLine("Monkey!");
                    break;
                case 1:
                    Console.WriteLine("Rooster!");
                    break;
                case 2:
                    Console.WriteLine("Dog!");
                    break;
                case 3:
                    Console.WriteLine("Pig!");
                    break;
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue Dans le Jeu de Horoscope Chinoua!");
            Console.WriteLine("------------------------------------------");

            int Annee;
            Console.WriteLine("Votre Annee de naissance de Naissance yyyy :");
            while ((int.TryParse(Console.ReadLine(), out Annee) == false) & (Annee < 1900) & (Annee > 2020)) { Console.WriteLine("Prends Moi pas pour un cave"); }
            DecrypHoro(Annee);

            Console.Read();
        }
    }
}

