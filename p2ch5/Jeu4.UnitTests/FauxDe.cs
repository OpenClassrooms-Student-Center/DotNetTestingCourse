namespace Jeu4.UnitTests
{
    public class FauxDe : ILanceurDeDe
    {
        private readonly int[] _listeDeJets;
        private int _compteur;

        public FauxDe()
        {
            _listeDeJets = new[] { 4, 5, 1, 1, 4, 3, 5, 6, 6, 6, 1, 2, 4, 2, 3, 2, 6, 4, 5, 1, 1, 4, 3, 5, 6, 6, 6, 1, 2, 4, 2, 3, 2, 6 };
            _compteur = 0;
        }

        public int Lance()
        {
            int tirage = _listeDeJets[_compteur];
            _compteur++;
            return tirage;
        }
    }
}
