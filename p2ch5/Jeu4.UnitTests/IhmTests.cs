using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jeu4.UnitTests
{
    [TestClass]
    public class IhmTests
    {
        [TestMethod]
        public void Ihm_AvecUnJeuDeDonnees_LeJoueurGagne()
        {
            // arrange
            var fausseConsole = new FausseConsole();
            var ihm = new Ihm(fausseConsole, new FauxDe());

            // act
            ihm.Demarre();

            // assert
            var resultat = fausseConsole.StringBuilder.ToString();
            resultat.Should().StartWith("A l'attaque : points/vie 0/15");
            resultat.Should().EndWith("Combat perdu: points/vie 9/0\r\n");
            resultat.Should().HaveLength(560);
        }
    }
}

