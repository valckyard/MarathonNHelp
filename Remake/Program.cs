using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace crissdemarde
{
    class AlexGosseDesTrucs
    {
        public static void ShowHandCompleteNVAL(string Joueur, List<int> Main, out int Valtot)
        {
            Program.CalcValeursCartes(Main, out Valtot);
            Console.WriteLine($"------ {Joueur} --------");
            foreach (int Carte in Main)
            {
                Console.WriteLine(Program.CarteEnTexte(Carte));
            }
            Console.WriteLine("------------------------");
            Console.WriteLine($"Valeur Main {Joueur} : {Valtot}");
            Console.WriteLine();
        }
        static void CalcShowDrawCard(int[] Paquet, int Compteur, ref int ValTot)
        {
            int x = Paquet[Compteur] % 13;
            if (x < 10)
            {
                ValTot += x + 1;
            }
            else if (x > 9)
            {
                ValTot += 10;
            }

            if (x == 0)
            {
                Program.ASChk(ref ValTot);
            }
            Console.WriteLine($"{Program.CarteEnTexte(Paquet[Compteur])} New ValTOT : {ValTot}");
        }


        public static void HitShowADDVal(string Joueur,int[] Paquet,ref int Compteur, ref List<int> Main, ref int ValTot)
        {
            Console.WriteLine($"------ {Joueur} Hit!------");
            Main.Add(Paquet[Compteur]);
            CalcShowDrawCard(Paquet, Compteur, ref ValTot);
            Compteur++;
            Console.WriteLine();
        }

    }
    class Program
    {
        static Random rand = new Random(); // random au debut et hors methode a cause des repetitions et reeutilisation

        static void CreerDeck(ref int[] deck) // Procédure pour créer le deck
        {
            deck = new int[52];
            for (int i = 0; i < 52; ++i)
                deck[i] = i;
        }

        static void BrasserDeck(ref int[] deck) // Procédure pour brasser les cartes 
        {

            for (int i = 0; i < deck.Length; ++i)
            {
                int j = rand.Next() % deck.Length;
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }
        static void Pigeunecarte(ref int[] Paq, ref int CompteurPaq, ref List<int> Pigeur)
        {
            Pigeur.Add(Paq[CompteurPaq]);  // le pigeur ajoute une carte reference au compteur du paquet PS: la liste ne requiert pas ade compteur a cause de la fonction .Add()
            CompteurPaq++;                  // ajoute 1 au compteur de la table de int[]
        }
        public static string CarteEnTexte(int carte) // Ici j'ai mes valeurs de carte // Retour de la String pour la main
        {
            string[] Valeurs = { "As    ", "Deux  ", "Trois ", "Quatre", "Cinq  ", "Six   ", "Sept  ", "Huit  ", "Neuf  ", "Dix   ", "Valet ", "Dame  ", "Roi   " };
            string[] Suites = { " de Coeur  ", " de Trefle ", " de Pique  ", " de Carreau" }; // table de Suites
            int val = carte % 13;   // 0 a 12 peut importe le nombre
            int suite = carte / 13; // 13 et moins coeur =1 / 26 moins trefle =2 / 39 moins pique =3 / autre Carreau =4
            string txtVal = Valeurs[val];     // 0 a 12 donnant le "nombre/valeur"
            string txtSuite = Suites[suite]; // la suite[] est definie par suite carte /13
            return $"  | {txtVal} |{txtSuite} |";
        }
        public static void CalcValeursCartes(List<int> Main, out int ValTotOut)
        {
            int ValTot = 0; // initialise
            foreach (int Carte in Main)
            {
                int x = Carte % 13;
                if (x < 10)
                {
                    ValTot += x + 1;
                }
                else if (x > 9)
                {
                    ValTot += 10;
                }
            }
            foreach (var Carte in Main) // define AS
            {
                int x = Carte % 13;
                if (x == 0)
                {
                    ASChk(ref ValTot);
                }
            }

            ValTotOut = ValTot;
        }
        public static void ASChk(ref int ValeurTot)
        {
            if (ValeurTot < 12)
            {
                ValeurTot += 10;
            }
            else
            {
                //meh ValToT += 0; //y vaut deja 1
            }
        }

        //Mainsdesjoueurs DECLARE
        static int[] Paq;
        static int CompteurPaq = 0;
        static List<int> MainJoueur;
        static List<int> MainCroupier;

        static void Main(string[] args)
        {
            //init du jeu
            Paq = new int[52];
            MainJoueur = new List<int>(); // listes sont simple et nont pas besoin du compteur buggy ... et peuvent etre cree vides
            MainCroupier = new List<int>(); // au bout de la ligne se sont des int[] mais plus facile a ajouter des variables
            CreerDeck(ref Paq);
            BrasserDeck(ref Paq);
            Pigeunecarte(ref Paq, ref CompteurPaq, ref MainJoueur);
            Pigeunecarte(ref Paq, ref CompteurPaq, ref MainCroupier);
            Pigeunecarte(ref Paq, ref CompteurPaq, ref MainJoueur);
            Pigeunecarte(ref Paq, ref CompteurPaq, ref MainCroupier);


            //// Block TEST///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine(Paq[0]); // affiche la premiere carte du paquet pour verifier les donnes TEST//                           //
            Console.WriteLine(MainJoueur[0]); // idem joueur ~ list fonctionne de la meme facon que la tableau de int[]                 //  
                                              //
                                              //joueur toutes ses cartes                                                                                                  //
            foreach (int x in MainJoueur)                                                                                               //
            {                                                                                                                           //
                Console.WriteLine(CarteEnTexte(x));                                                                                      //
            }                                                                                                                           //
            // idem croupier                                                                                                            //
            foreach (int x in MainCroupier)                                                                                             //
            {                                                                                                                           //
                Console.WriteLine(CarteEnTexte(x));                                                                                     //
            }                                                                                                                           //
            //// Block TEST///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.ReadLine();
            Console.Clear(); // Clear Test//

            CalcValeursCartes(MainJoueur, out int JVal);
            Console.WriteLine($"Valeur Main Joueur: {JVal}");
            CalcValeursCartes(MainCroupier, out int CVal);
            Console.WriteLine($"Valeur Main Croup: {CVal}");

            Console.ReadLine();
            Console.Clear(); // Clear Test//

            // new interface 
            AlexGosseDesTrucs.ShowHandCompleteNVAL("Joueur", MainJoueur, out JVal);
            AlexGosseDesTrucs.ShowHandCompleteNVAL("Croupier", MainCroupier, out CVal);
            do
            {
                Thread.Sleep(500);
                AlexGosseDesTrucs.HitShowADDVal("Joueur" ,Paq,ref CompteurPaq, ref MainJoueur, ref JVal);
                AlexGosseDesTrucs.HitShowADDVal("Croupier", Paq, ref CompteurPaq, ref MainCroupier, ref CVal);
                Console.ReadKey();
            } while (true);

        }
    }
}