using System;

namespace Jeu4
{
    public class Ihm
    {
        private readonly IConsole _console;
        private readonly ILanceurDeDe _lanceurDeDe;

        public Ihm(IConsole console, ILanceurDeDe lanceurDeDe)
        {
            _console = console;
            _lanceurDeDe = lanceurDeDe;
        }

        public void Demarre()
        {
            var jeu = new Jeu();
            _console.EcrireLigne($"A l'attaque : points/vie {jeu.Heros.Points}/{jeu.Heros.PointDeVies}");
            while (jeu.Heros.PointDeVies > 0)
            {
                var resultat = jeu.Tour(_lanceurDeDe.Lance(), _lanceurDeDe.Lance());
                switch (resultat)
                {
                    case Resultat.Gagne:
                        _console.Ecrire($"Monstre battu");
                        break;
                    case Resultat.Perdu:
                        _console.Ecrire($"Combat perdu");
                        break;
                }
                _console.EcrireLigne($": points/vie {jeu.Heros.Points}/{jeu.Heros.PointDeVies}");
            }
        }
    }
}
