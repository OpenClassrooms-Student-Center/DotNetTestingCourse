using System;

namespace Jeu7
{
    public class ConsoleDeSortie : IConsole
    {
        public void Ecrire(string message)
        {
            Console.Write(message);
        }

        public void EcrireLigne(string message)
        {
            Console.WriteLine(message);
        }
    }

    //public class FournisseurMeteo : IFournisseurMeteo
    //{
    //    private static HttpClient _httpClient = new HttpClient();

    //    public Meteo QuelTempsFaitIl(DateTime dateSouhaitee)
    //    {
    //        _httpClient.GetAsync()
    //        throw new NotImplementedException();
    //    }
    //}
}