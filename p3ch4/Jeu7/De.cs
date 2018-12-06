using System;

namespace Jeu7
{
    public class De : ILanceurDeDe
    {
        private Random random;

        public De()
        {
            random = new Random();
        }

        public int Lance()
        {
            return random.Next(1, 7);
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