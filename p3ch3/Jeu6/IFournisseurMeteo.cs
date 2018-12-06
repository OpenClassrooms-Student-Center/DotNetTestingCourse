using System;

namespace Jeu6
{
    public interface IFournisseurMeteo
    {
        Meteo QuelTempsFaitIl(DateTime dateSouhaitee);
    }
}
