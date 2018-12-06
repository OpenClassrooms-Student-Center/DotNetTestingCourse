using System;

namespace Jeu2
{
    public class Ihm
    {
        public void Demarre()
        {
            De de = new De();
            var jeu = new Jeu();
            Console.WriteLine($"A l'attaque : points/vie {jeu.Heros.Points}/{jeu.Heros.PointDeVies}");
            while (jeu.Heros.PointDeVies > 0)
            {
                var resultat = jeu.Tour(de.Lance(), de.Lance());
                switch (resultat)
                {
                    case Resultat.Gagne:
                        Console.Write($"Monstre battu");
                        break;
                    case Resultat.Perdu:
                        Console.Write($"Combat perdu");
                        break;
                }
                Console.WriteLine($": points/vie {jeu.Heros.Points}/{jeu.Heros.PointDeVies}");
            }
        }
    }
}
