using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_du_pendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mots = new List<string>();
            string rejouer = "o";
            int coup = 10;
            bool gagne = false;
            string motCache = "";
            string motEtoile = "";

            string motSource = " un deux cinq rouge membre conseil donner reponse etat son armement peu apres vacances annonce mercredi evident regime affirmer arme";
            mots.AddRange(motSource.Split(' '));

            while (rejouer.ToLower().Equals("o"))
            {
                gagne = false;
                coup = 10;
                motCache = ChoisirMot(mots);
                //Pour Voir le mot cacher :
                //Console.WriteLine(motCache);
                motEtoile = GenererMotEtoile(motCache);
                

                while (coup > 0 && !gagne)
                {
                    Console.WriteLine("Il vous reste {0} coups à jouer", coup);
                    Console.WriteLine("le mot secret est : {0}", motEtoile);

                    string lettre = GetCaractere();

                    string nouveauMotEtoile = TestCaractere(motCache, motEtoile, lettre);

                    gagne = TestGagne(motCache, nouveauMotEtoile);

                    if (!gagne && nouveauMotEtoile == motEtoile)
                    {
                        coup--;
                    }

                    motEtoile = nouveauMotEtoile;

                }

                if (gagne)
                {
                    Console.WriteLine("Bravo vous avez gagné, le mot secret était : {0}", motCache);
                }
                else
                {
                    Console.WriteLine("Désolé vous avez perdu ! le mot secret était : {0}", motCache);
                }

                Console.WriteLine("Voulez-vous rejouer ? (o / n)");
                rejouer = Console.ReadLine();
            }
        }

        static string GetCaractere()
        {
            Console.WriteLine("Proposez une lettre : ");
            return Console.ReadLine();
        }

        static int GetNombreAleatoire(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        static string ChoisirMot(List<string> mots)
        {
            return mots[GetNombreAleatoire(0, mots.Count)];
        }

        static string GenererMotEtoile(string motCache)
        {
            return new String('*', motCache.Length);
        }

        static string TestCaractere(string motCache, string motEtoile, string lettre)
        {
            string mot = "";

            for (int i = 0; i < motCache.Length; i++) 
            { 
                if (motCache[i] == lettre[0])
                {
                    mot += lettre;
                }
                else
                {
                    mot += motEtoile[i];
                }
            }
            return mot;
        }

        static bool TestGagne(string motCache, string motSaisie)
        {
            return motCache == motSaisie;

        }



    }
}
