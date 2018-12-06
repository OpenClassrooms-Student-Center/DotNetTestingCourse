using System;
using System.Threading.Tasks;

namespace Jeu7
{
    public class Jeu
    {
        private readonly IFournisseurMeteo _fournisseurMeteo;

        public Heros Heros { get; }

        public Jeu(IFournisseurMeteo fournisseurMeteo)
        {
            Heros = new Heros(15);
            _fournisseurMeteo = fournisseurMeteo;
        }

        public async Task<Resultat> Tour(int deHeros, int deMonstre)
        {
            if (GagneLeCombat(deHeros, deMonstre))
            {
                Heros.GagneUnCombat();
                return Resultat.Gagne;
            }
            else
            {
                var temps = await _fournisseurMeteo.QuelTempsFaitIl(DateTime.Now);
                if (temps == Meteo.Tempete)
                    Heros.PerdsUnCombat(2 * (deMonstre - deHeros));
                else
                    Heros.PerdsUnCombat(deMonstre - deHeros);
                return Resultat.Perdu;
            }
        }

        private bool GagneLeCombat(int de1, int de2)
        {
            return de1 >= de2;
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