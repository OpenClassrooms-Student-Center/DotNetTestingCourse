using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace Jeu7.UnitTests
{
    [TestClass]
    public class JeuTests
    {
        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer supérieur au second, alors le résultat est gagné avec un point sans perdre de points de vie")]
        public async Task Tour_AvecUnDeSuperieurAuSecond_RetourneGagneAvecUnPointEtSansPerdreDePointsDeVie()
        {
            // Arrange
            var fournisseurMeteo = Mock.Of<IFournisseurMeteo>();
            Jeu jeu = new Jeu(fournisseurMeteo);

            // Act
            var resultat = await jeu.Tour(6, 1);

            // Assert
            resultat.Should().Be(Resultat.Gagne);
            jeu.Heros.Points.Should().Be(1);
            jeu.Heros.PointDeVies.Should().Be(15);
        }

        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer égal au second, alors le résultat est gagné avec un point sans perdre de points de vie")]
        public async Task Tour_AvecUnDeEgalAuSecond_RetourneGagneAvecUnPointEtSansPerdreDePointsDeVie()
        {
            // Arrange
            var fournisseurMeteo = Mock.Of<IFournisseurMeteo>();
            Jeu jeu = new Jeu(fournisseurMeteo);

            // Act
            var resultat = await jeu.Tour(5, 5);

            // Assert
            resultat.Should().Be(Resultat.Gagne);
            jeu.Heros.Points.Should().Be(1);
            jeu.Heros.PointDeVies.Should().Be(15);
        }

        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer inférieur au second et du soleil, alors le résultat est perdu, sans points et en perdant des points de vie")]
        public async Task Tour_AvecUnDeInferieurAuSecond_RetournePerduSansPointEnPerdantDesPointsDeVie()
        {
            // Arrange
            var fournisseurMeteo = Mock.Of<IFournisseurMeteo>();
            Jeu jeu = new Jeu(fournisseurMeteo);

            // Act
            var resultat = await jeu.Tour(2, 4);

            // Assert
            resultat.Should().Be(Resultat.Perdu);
            jeu.Heros.Points.Should().Be(0);
            jeu.Heros.PointDeVies.Should().Be(13);
        }

        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer inférieur au second et de la pluie, alors le résultat est perdu, sans points et en classiquement des points de vie")]
        public async Task Tour_AvecUnDeInferieurAuSecond_EtDuVent_RetournePerduSansPointEnPerdantClassiquementDesPointsDeVie()
        {
            // Arrange
            var fournisseurMeteo = Mock.Of<IFournisseurMeteo>();
            Mock.Get(fournisseurMeteo).Setup(m => m.QuelTempsFaitIl(It.IsAny<DateTime>())).Returns(Task.FromResult(Meteo.Pluie));
            Jeu jeu = new Jeu(fournisseurMeteo);

            // Act
            var resultat = await jeu.Tour(2, 4);

            // Assert
            resultat.Should().Be(Resultat.Perdu);
            jeu.Heros.Points.Should().Be(0);
            jeu.Heros.PointDeVies.Should().Be(13);
        }

        [TestMethod]
        [Description("Etant donné un tour de jeu, lorsque j'ai un lancer inférieur au second et du vent, alors le résultat est perdu, sans points et en perdant deux fois plus de points de vie")]
        public async Task Tour_AvecUnDeInferieurAuSecond_EtDuVent_RetournePerduSansPointEnPerdantDeuxFoisPlusDePointsDeVie()
        {
            // Arrange
            var fournisseurMeteo = Mock.Of<IFournisseurMeteo>();
            Mock.Get(fournisseurMeteo).Setup(m => m.QuelTempsFaitIl(It.IsAny<DateTime>())).Returns(Task.FromResult(Meteo.Tempete));
            Jeu jeu = new Jeu(fournisseurMeteo);

            // Act
            var resultat = await jeu.Tour(2, 4);

            // Assert
            resultat.Should().Be(Resultat.Perdu);
            jeu.Heros.Points.Should().Be(0);
            jeu.Heros.PointDeVies.Should().Be(11);
        }
    }
}