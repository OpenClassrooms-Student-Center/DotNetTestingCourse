namespace Jeu5
{
    public class Jeu
    {
        private readonly IFournisseurMeteo _fournisseurMeteo;

        public Heros Heros { get; }

        public Jeu(IFournisseurMeteo fournisseurMeteo)
        {
            Heros = new Heros(15);
            _fournisseurMeteo = fournisseurMeteo;
        }

        public Resultat Tour(int deHeros, int deMonstre)
        {
            if (GagneLeCombat(deHeros, deMonstre))
            {
                Heros.GagneUnCombat();
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
    }
}
