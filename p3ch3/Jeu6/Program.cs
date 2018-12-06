namespace Jeu6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Jeu5;Integrated Security=True;";
            var ihm = new Ihm(new ConsoleDeSortie(), new De(), new MeteoRepository(connectionstring));
            ihm.Demarre();
        }
    }
}
