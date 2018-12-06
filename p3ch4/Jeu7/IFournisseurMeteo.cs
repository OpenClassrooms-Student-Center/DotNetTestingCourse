using System;
using System.Threading.Tasks;

namespace Jeu7
{
    public interface IFournisseurMeteo
    {
        Task<Meteo> QuelTempsFaitIl(DateTime dateSouhaitee);
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