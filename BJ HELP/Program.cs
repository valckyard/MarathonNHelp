using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_2018 //BONNE VERSION
{
    class Program
    {
        static void Affichermessagedebienvenue()
        {
            Console.WriteLine("Bienvenue! Jouons au Black Jack 2018! Commençons par brasser les cartes.");
            Console.WriteLine();
        }

        static void BrasserDeck(int[] deck) // Procédure pour brasser les cartes 
        {
            var rand = new Random();
            for (int i = 0; i < deck.Length; ++i)
            {
                int j = rand.Next() % deck.Length;
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        static void AfficherDesCartes() // Je viens décrire ce que AfficherDesCartes va faire
        {
            /*int carte = 30;// afficher seulement cette carte
            string maCarte = CarteEnTexte(carte);
            Console.WriteLine(maCarte);*/

            int[] deck = CreerDeck(); //Afficher le deck complet
            BrasserDeck(deck);

            foreach (var c in deck)
            {
                Console.Write($"{CarteEnTexte(c)}, ");
            }
            Console.WriteLine();
        }

        static void Affichermessagedebut()
        {
            Console.WriteLine("\nLes cartes sont brassées, commençons la distribution des cartes.");//la barre avec le n fait un espace
            Console.WriteLine();
        }

        static int[] CreerDeck() // Procédure pour créer le deck
        {
            int[] deck = new int[52];
            for (int i = 0; i < 52; ++i)
                deck[i] = i;
            return deck;
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="args"></param>
        static int[] PaquetJeu;
        static void Main(string[] args) //les sections static qui suivent sont le portrait de notre schéma ordinogramme(les algorithmes) on a fait les fontions pour nos rectangles de notre schéma
       
        {
            Affichermessagedebienvenue();
            AfficherDesCartes(); //Je lui nomme ce que je veux qu'il fasse 
            Affichermessagedebut();
        }

       

        static string CarteEnTexte(int carte) // Ici j'ai mes valeurs de carte
        {
            String Valeurs = "A23456789TVDR";
            String Suites = "CDPR";
            int val = carte % 13;
            int suite = carte / 13;
            char txtVal = Valeurs[val];
            char txtSuite = Suites[suite];
            return $"{txtVal}{txtSuite}";
        }


       

       
       

    }
}