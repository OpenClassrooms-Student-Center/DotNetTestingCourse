namespace OC.Exercice
{
    public class Monstre : IMonstre
    {
        private bool _estVivant;

        public Monstre()
        {
            _estVivant = true;
        }

        public bool EstVivant()
        {
            return _estVivant;
        }

        public void PerdsUnCombat(int nb)
        {
            _estVivant = false;
        }
    }
}