using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jeu4.UnitTests
{
    [TestClass]
    public class JeuTests
    {
        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer supérieur au second, alors le résultat est gagné avec un point sans perdre de points de vie")]
        public void Tour_AvecUnDeSuperieurAuSecond_RetourneGagneAvecUnPointEtSansPerdreDePointsDeVie()
        {
            // Arrange
            Jeu jeu = new Jeu();

            // Act
            var resultat = jeu.Tour(6, 1);

            // Assert
            resultat.Should().Be(Resultat.Gagne);
            jeu.Heros.Points.Should().Be(1);
            jeu.Heros.PointDeVies.Should().Be(15);
        }

        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer égal au second, alors le résultat est gagné avec un point sans perdre de points de vie")]
        public void Tour_AvecUnDeEgalAuSecond_RetourneGagneAvecUnPointEtSansPerdreDePointsDeVie()
        {
            // Arrange
            Jeu jeu = new Jeu();

            // Act
            var resultat = jeu.Tour(5, 5);

            // Assert
            resultat.Should().Be(Resultat.Gagne);
            jeu.Heros.Points.Should().Be(1);
            jeu.Heros.PointDeVies.Should().Be(15);
        }

        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer inférieur au second, alors le résultat est perdu, sans points et en perdant des pointss de vie")]
        public void Tour_AvecUnDeInferieurAuSecond_RetournePerduSansPointEnPerdantDesPointsDeVie()

        {
            // Arrange
            Jeu jeu = new Jeu();

            // Act
            var resultat = jeu.Tour(2, 4);

            // Assert
            resultat.Should().Be(Resultat.Perdu);
            jeu.Heros.Points.Should().Be(0);
            jeu.Heros.PointDeVies.Should().Be(13);
        }
    }
}

