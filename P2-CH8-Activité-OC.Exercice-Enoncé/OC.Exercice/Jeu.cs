using System.Collections.Generic;

namespace OC.Exercice
{
    public class Jeu
    {
        private readonly IFournisseurMeteo _fournisseurMeteo;
        private Queue<IMonstre> _monstres;
        private IMonstre _monstreCourant;

        public Heros Heros { get; }


        public Jeu(IFournisseurMeteo fournisseurMeteo, IFabriqueDeMonstres fabriqueDeMonstres)
        {
            Heros = new Heros(15);
            _monstres = new Queue<IMonstre>(fabriqueDeMonstres.GetMonstres());

            _fournisseurMeteo = fournisseurMeteo;
            _monstreCourant = _monstres.Dequeue();
        }

        public Resultat Tour(int deHeros, int deMonstre)
        {
            if (!_monstreCourant.EstVivant())
            {
                _monstreCourant = _monstres.Dequeue();
            }

            if (GagneLeCombat(deHeros, deMonstre))
            {
                Heros.GagneUnCombat();
                _monstreCourant.PerdsUnCombat(deHeros - deMonstre);
                return Resultat.Gagne;
            }
            else
            {
                var temps = _fournisseurMeteo.QuelTempsFaitIl();
                if (temps == Meteo.Tempete)
                    Heros.PerdsUnCombat(2 * (deMonstre - deHeros));
                else
                    Heros.PerdsUnCombat(deMonstre - deHeros);
                return Resultat.Perdu;
            }
        }

        private bool GagneLeCombat(int de1, int de2)
        {
            return de1 >= de2;
        }

        public bool EstTermine()
        {
            return Heros.PointDeVies <= 0 || _monstres.Count == 0;
        }
    }
}