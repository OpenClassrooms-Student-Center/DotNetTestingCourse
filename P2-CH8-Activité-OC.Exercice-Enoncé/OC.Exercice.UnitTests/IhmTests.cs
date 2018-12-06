using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace OC.Exercice.UnitTests
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
            resultat.Should().EndWith("Le joueur est vainqueur !! Félicitations...\r\n");
            resultat.Should().HaveLength(139);
        }

        [TestMethod]
        public void Ihm_AvecUnJeuDeDonnees_LeJoueurPerds()
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
            resultat.Should().Be(@"A l'attaque : points/vie 0/15
Combat perdu: points/vie 0/14
Monstre battu: points/vie 1/14
Monstre battu: points/vie 2/14
Combat perdu: points/vie 2/13
Monstre battu: points/vie 3/13
Combat perdu: points/vie 3/12
Monstre battu: points/vie 4/12
Monstre battu: points/vie 5/12
Monstre battu: points/vie 6/12
Monstre battu: points/vie 7/12
Combat perdu: points/vie 7/9
Combat perdu: points/vie 7/7
Monstre battu: points/vie 8/7
Monstre battu: points/vie 9/7
Combat perdu: points/vie 9/5
Combat perdu: points/vie 9/4
Combat perdu: points/vie 9/0
Après un courageux combat, le joueur a malheureusement été vaincu ...
");
            resultat.Should().HaveLength(631);
        }
    }
}