using System;
using System.Data.SqlClient;
using Dapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jeu6.IntegrationTests
{
    [TestClass]
    public class FournisseurMeteoTests
    {
        private const string _connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestAuto;Integrated Security=True;";

        [TestInitialize]
        public void CreationTables()
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(@"CREATE TABLE [dbo].InfosMeteo
                                    (
	                                    [Valeur] VARCHAR(10) NOT NULL,
	                                    [Date] Datetime NOT NULL
                                    )");
            }
        }

        [TestMethod]
        public void QuelTempsFaitIl_AvecDuSoleil_RetourneDuSoleil()
        {
            // arrange
            Insertion("Soleil");
            IFournisseurMeteo fournisseurMeteo = new MeteoRepository(_connectionstring);

            // act
            var temps = fournisseurMeteo.QuelTempsFaitIl(DateTime.Now);

            // assert
            temps.Should().Be(Meteo.Soleil);
        }

        [TestMethod]
        public void QuelTempsFaitIl_AvecDeLaPluie_RetourneDeLaPluie()
        {
            // arrange
            Insertion("Pluie");
            IFournisseurMeteo fournisseurMeteo = new MeteoRepository(_connectionstring);

            // act
            var temps = fournisseurMeteo.QuelTempsFaitIl(DateTime.Now);

            // assert
            temps.Should().Be(Meteo.Pluie);
        }

        [TestMethod]
        public void QuelTempsFaitIl_AvecDeLaTempete_RetourneDeLaTempete()
        {
            // arrange
            Insertion("Tempete");
            IFournisseurMeteo fournisseurMeteo = new MeteoRepository(_connectionstring);

            // act
            var temps = fournisseurMeteo.QuelTempsFaitIl(DateTime.Now);

            // assert
            temps.Should().Be(Meteo.Tempete);
        }

        private void Insertion(string temps)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(@"INSERT INTO dbo.InfosMeteo values (@temps, Convert(date, getdate()))", new {  temps });
            }
        }

        [TestCleanup]
        public void SuppressionTables()
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(@"DROP TABLE [dbo].InfosMeteo");
            }
        }
    }
}
