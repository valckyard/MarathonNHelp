using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ_Tutorial
{
    public class Paquet     // Fonctions de Paquets
    {
        public static void CreePaq()
        {
        }

        public static void BrassePaq()
        {
        }
    }

    public class Pige       // Fonctions de Pige
    {
        public static void PigeCarte()          // Piger une carte
        {
        }

        public static void PigeCarteAndVal()    // Piger une carte et l'ajouter a ValTot
        {
        }
    }

    public class ValCalc    // Fonctions de Calculs de Valeurs
    {
        public static void ValeurMainCalc()     // Calcul de la valeur totale d'une main
        {
        }
    }

    public class Checks     // Fonctions de Verifications
    {
        public static void CheckAsVal()         // Ajustements d'As
        {
        }
        public static void NaturalBJCHK()       // Groupe de verification de BlackJack Naturels
        {
        }
        public static void FinalCheck()         // Groupe de Verification Finale
        {
        }
    }

    class Program           // Classe du Jeu
    { 
        static void Main(string[] args)
            // Creer les Variables statiques
        {
            // Creer les Variables Locales

            Paquet.CreePaq();           // Cree et Brasse Paq
            Paquet.BrassePaq();

            Pige.PigeCarte();           // 2x Joueur et 2x Croupier

            ValCalc.ValeurMainCalc();   // Calculer les Mains Croupier et Joueurs

            //
            //Affichage des cartes Joueur et de la carte 1 Croupier
            //

            Checks.NaturalBJCHK();

            // Demander Hit or Stand et mettre en ToUpper();

            string[] hscheck = new string[] { "H", "S" };
            string hs = Console.ReadLine().ToUpper();
            switch (hs)
            {
                case "H":
                    Pige.PigeCarteAndVal();
                    // If Valeur totale joueur < 21
                    return;
                    // If Valeur totale joueur > 20
                    break;
                case "S":
                    Pige.PigeCarteAndVal();
                    // If Valeur totale croupier < 21
                    return;
                    // If Valeur totale croupier > 20
                    break;
            }
            Checks.FinalCheck();
        }
    }
}
