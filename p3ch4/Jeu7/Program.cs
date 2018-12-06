using System.Threading.Tasks;

namespace Jeu7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ihm = new Ihm(new ConsoleDeSortie(), new De(), new FournisseurMeteo("https://localhost:44361"));
            await ihm.Demarre();
        }
    }
}