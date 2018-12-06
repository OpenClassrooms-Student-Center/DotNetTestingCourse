namespace OC.Exercice
{
    class Program
    {
        static void Main(string[] args)
        {
            var ihm = new Ihm(new ConsoleDeSortie(), new De(), new FournisseurMeteo(), new FabriqueDeMonstres());
            ihm.Demarre();
        }
    }
}