namespace Jeu7
{
    public class Heros
    {
        public int PointDeVies { get; private set; }
        public int Points { get; private set; }

        public Heros(int pointDeVies)
        {
            PointDeVies = pointDeVies;
        }

        public void GagneUnCombat()
        {
            Points++;
        }

        public void PerdsUnCombat(int nb)
        {
            PointDeVies -= nb;
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