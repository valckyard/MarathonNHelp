using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ_Tutorial
{





    public class Paquet                             //######### Fonctions de Paquets #########//
    {
        static Random Randy = new Random();


        public static void CreePaq(ref int[] PaquetVide)
        {
            PaquetVide = new int[52];
            for (int i = 0; i < 52; ++i)
                PaquetVide[i] = i;
        }



        public static void BrassePaq(ref int[] PaquetNonBrasse)
        {
            for (int i = 0; i < PaquetNonBrasse.Length; ++i)
            {
                int j = Randy.Next() % PaquetNonBrasse.Length;
                int temp = PaquetNonBrasse[i];
                PaquetNonBrasse[i] = PaquetNonBrasse[j];
                PaquetNonBrasse[j] = temp;
            }
        }
    }




    public class Pige                               //######### Fonctions de Pige ##########//
    {


       public static void PigeCarte(int[] Paq, ref int CompteurPaq, ref List<int> Pigeur)   //////////////// PIGER UNE CARTE //////////////////////////////
        {
            Pigeur.Add(Paq[CompteurPaq]);  // le pigeur ajoute une carte reference au compteur du paquet
            CompteurPaq++;                  // ajoute 1 au compteur de la table de int[]
        }



        public static void HitPigeUneCarteAndVal(string Joueur, int[] Paquet, ref int Compteur, ref List<int> Main, ref int ValTot)  /////////PIGER UNE CARTE ET AJOUTER LA VALEUR AU TOTAL/////////
        {
            Console.WriteLine($"------ {Joueur} Hit!------");
            Main.Add(Paquet[Compteur]);
            Affichage.AfficherCarte(Paquet, Compteur, ValTot);
            ValCalc.ValeurCarteCalc(Paquet[Compteur], ref ValTot);
            Compteur++;
            Console.WriteLine();
        }
    }




    public class ValCalc                      //########### Fonctions de Calculs de Valeurs ###############//
    {


        public static void ValeurMainCalc(List<int> Main, out int ValTotOut)  /////////// CALCUL VALEUR D'UNE MAIN //////////////////////
        {
            int ValTot = 0; // initialise
            foreach (int Carte in Main)
            {
                int x = Carte % 13;

                if (x < 10)         // assigne les valeurs 1 a 10
                    ValTot += x + 1;

                else                // reste vaut 10
                    ValTot += 10;
            }

            Checks.CheckAsVal(Main, ref ValTot); // Ajuste la Valeur des AS de ValTot pour Soft Hands

            ValTotOut = ValTot;
        }



        public static void ValeurCarteCalc(int Carte, ref int ValTot)  /////////// CALCUL VALEUR DE UNE CARTE //////////////////////
        {
            int x = Carte % 13;
            if (x < 10)
            {
                ValTot += x + 1;
            }
            else
            {
                ValTot += 10;
            }

            if (x == 0)
            {
                if (ValTot < 12)
                {
                    ValTot += 10;
                }
                else
                {
                    ValTot += 0; //meh y vaut deja 1
                }
            }
        }
    }




    public class Affichage                             //############## Fonctions d'Affichage #############//
    {


        public static void AfficherCarte(int[] Paquet, int Compteur, int ValTot)
        {
            int carte = Paquet[Compteur];
            string[] Valeurs = { "As    ", "Deux  ", "Trois ", "Quatre", "Cinq  ", "Six   ", "Sept  ", "Huit  ", "Neuf  ", "Dix   ", "Valet ", "Dame  ", "Roi   " };
            string[] Suites = { " de Coeur  ", " de Trefle ", " de Pique  ", " de Carreau" }; // table de Suites
            int val = carte % 13;   // 0 a 12 peut importe le nombre
            int suite = carte / 13; // 13 et moins coeur =1 / 26 moins trefle =2 / 39 moins pique =3 / autre Carreau =4
            string txtVal = Valeurs[val];     // 0 a 12 donnant le "nombre/valeur"
            string txtSuite = Suites[suite]; // la suite[] est definie par suite carte /13
            Console.WriteLine($"  | {txtVal} |{txtSuite} | Nouvelle Valeur Totale : {ValTot}");
        }
    }




    public class Checks                                     //############### Fonctions de Verifications ###################//
    {


        public static void CheckAsVal(List<int> Main, ref int ValTot)         // Ajustements d'As
        {
            foreach (var Carte in Main) // Verifie tt les cartes pour un AS
            {
                int x = Carte % 13;
                if (x == 0)
                {
                    if (ValTot < 12)
                    {
                        ValTot += 10;
                    }
                    else
                    {
                        //meh ValToT += 0; //y vaut deja 1
                    }
                }
            }
        }



        public static void NaturalBJCHK(int ValTotCroupier, int ValTotJoueur)       // Groupe de verification de BlackJack Naturels
        {
            if ((ValTotCroupier == 21) & (ValTotJoueur == 21))
                Console.WriteLine($"Egalite Croupier a : {ValTotCroupier} et Joueur : {ValTotJoueur} ... yay 2 BlackJack....");
            else if ((ValTotCroupier == 21) | (ValTotJoueur == 21))
            {
                if (ValTotCroupier == 21)
                    Console.WriteLine($"BlackJack! Croupier ! =- {ValTotCroupier} -=   Joueur a : {ValTotJoueur} Pardu Nigausaure!");
                else
                    Console.WriteLine($"BlackJack! Joueur ! =- {ValTotJoueur} -=   Croupier a : {ValTotCroupier}  You are the winnerzzzzzzz!");
            }
        }
        public static void FinalCheck()         // Groupe de Verification Finale
        {
        }
    }

    class Program           // Classe du Jeu
    {
        // Creer les Variables statiques

        static int JValTot;
        static int CValTot;
        static int Compteur;
        static int[] Paq;
        static List<int> MainJoueur;
        static List<int> MainCroupier;

        static void Main(string[] args)

        {
            
            
            // Creer les Variables Locales
            Paq = new int[52];
            Paquet.CreePaq(ref Paq);           // Cree et Brasse Paq
            Paquet.BrassePaq(ref Paq);
            Compteur = 0;


            do //Debut partie <--------------------------------------
            {



                if (Compteur > 45)
                {
                    Paquet.CreePaq(ref Paq);       //Recree paq si trop utilise
                    Paquet.BrassePaq(ref Paq);
                    Compteur = 0;
                }

                MainJoueur = new List<int>();      // Cree Nouvelles Mains a Chaque Parties
                MainCroupier = new List<int>();


                Pige.PigeCarte(Paq, ref Compteur, ref MainJoueur);          // Pige 2x Joueur et 2x Croupier
                Pige.PigeCarte(Paq, ref Compteur, ref MainCroupier);
                Pige.PigeCarte(Paq, ref Compteur, ref MainJoueur);
                Pige.PigeCarte(Paq, ref Compteur, ref MainCroupier);



                ValCalc.ValeurMainCalc(MainJoueur, out JValTot);   // Calculer les Mains Croupier et Joueurs
                ValCalc.ValeurMainCalc(MainCroupier, out JValTot);


                //*****************************************************************************//



                //
                //Affichage des cartes Joueur et de la carte 1 Croupier
                //






                //********************************************************************************//

                Checks.NaturalBJCHK(CValTot, JValTot);
                if ((JValTot == 21) || (CValTot == 21))
                    return;


                // Demander Hit or Stand et mettre en ToUpper();

                bool gateway = false;
                do
                { 
                string[] hscheck = new string[] { "H", "S" };
                // Bla bla 
                string hs = Console.ReadLine().ToUpper();
          
                    switch (hs)
                    {
                        case "H":
                            Pige.HitPigeUneCarteAndVal("Joueur", Paq, ref Compteur, ref MainJoueur, ref JValTot);
                            // If Valeur totale joueur < 21
                            if (JValTot < 21)
                                return;
                            // If Valeur totale joueur > 20
                            else
                                continue;
                        case "S":
                            Pige.HitPigeUneCarteAndVal("Croupier", Paq, ref Compteur, ref MainCroupier, ref CValTot);
                            if (CValTot < 18)
                                return;
                            else
                                gateway = true;
                            continue;
                    }
                  
                } while (gateway == false);
                Checks.FinalCheck();
            } while (true);
        }
    }
}
