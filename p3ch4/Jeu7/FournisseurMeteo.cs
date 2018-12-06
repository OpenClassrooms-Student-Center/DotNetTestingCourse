using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jeu7
{
    public class FournisseurMeteo : IFournisseurMeteo
    {
        private static HttpClient httpClient = new HttpClient();
        private readonly string _url;

        public FournisseurMeteo(string url)
        {
            _url = url;
        }

        public async Task<Meteo> QuelTempsFaitIl(DateTime dateSouhaitee)
        {
            var result = await httpClient.GetStringAsync(_url + "/api/meteo");
            return (Meteo)Enum.Parse(typeof(Meteo), result);
        }
    }
}