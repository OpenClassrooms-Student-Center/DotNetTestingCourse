using System.Collections.Generic;

namespace OC.Exercice
{
    public interface IFabriqueDeMonstres
    {
        IEnumerable<IMonstre> GetMonstres();
    }
}