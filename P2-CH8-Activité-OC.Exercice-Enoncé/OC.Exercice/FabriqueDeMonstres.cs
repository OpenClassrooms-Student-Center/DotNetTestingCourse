using System;
using System.Collections.Generic;

namespace OC.Exercice
{
    public class FabriqueDeMonstres : IFabriqueDeMonstres
    {
        private readonly Random _random;
        public FabriqueDeMonstres()
        {
            _random = new Random();
        }

        public IEnumerable<IMonstre> GetMonstres()
        {
            int nbMonstres = _random.Next(1, 10);

            for (int i = 0; i < nbMonstres; i++)
            {
                if (_random.Next(0, 2) == 0)
                    yield return new Monstre();
                else
                {
                    int nbPtsDeVie = _random.Next(1, 10);
                    yield return new MonstreCostaud(nbPtsDeVie);
                }
            }
        }
    }
}