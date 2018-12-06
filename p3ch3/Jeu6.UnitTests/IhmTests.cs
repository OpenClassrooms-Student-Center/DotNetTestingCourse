using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Jeu6.UnitTests
{
    [TestClass]
    public class IhmTests
    {
        [TestMethod]
        public void Ihm_AvecUnJeuDeDonnees_LeJoueurGagne()
        {
            // arrange
            var fausseConsole = new FausseConsole();
            var fauxDe = Mock.Of<ILanceurDeDe>();
            var sequence = Mock.Get(fauxDe).SetupSequence(de => de.Lance());
            foreach (var lancer in new[] { 4, 5, 1, 1, 4, 3, 5, 6, 6, 6, 1, 2, 4, 2, 3, 2, 6, 4, 5, 1, 1, 4, 3, 5, 6, 6, 6, 1, 2, 4, 2, 3, 2, 6 })
            {
                sequence.Returns(lancer);
            }
            var fournisseurMeteo = Mock.Of<IFournisseurMeteo>();
            var ihm = new Ihm(fausseConsole, fauxDe, fournisseurMeteo);

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
