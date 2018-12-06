namespace Jeu5
{
    class Program
    {
        static void Main(string[] args)
        {
            var ihm = new Ihm(new ConsoleDeSortie(), new De(), new FournisseurMeteo());
            ihm.Demarre();
        }
    }
}
