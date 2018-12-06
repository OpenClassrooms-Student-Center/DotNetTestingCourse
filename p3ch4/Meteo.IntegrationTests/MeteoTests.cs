using Dapper;
using FluentAssertions;
using Meteo.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Meteo.IntegrationTests
{
    [TestClass]
    public class MeteoTests
    {
        private const string _connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestAuto;Integrated Security=True;";
        private string _repetoire;

        [TestInitialize]
        public void CreationTables()
        {
            _repetoire = System.IO.Directory.GetCurrentDirectory();
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
        public async Task QuelTempsFaitIl_AvecDuSoleil_RetourneDuSoleil()
        {
            await Insertion("Soleil");

            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("TestsAuto")
                .UseContentRoot(_repetoire)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(_repetoire)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.TestsAuto.json")
                .Build()).UseStartup<Startup>();

            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                string result = await client.GetStringAsync("/api/meteo");
                result.Should().Be("Soleil");
            }
        }

        [TestMethod]
        public async Task QuelTempsFaitIl_AvecDeLaPluie_RetourneDeLaPluie()
        {
            await Insertion("Pluie");

            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("TestsAuto")
                .UseContentRoot(_repetoire)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(_repetoire)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.TestsAuto.json")
                .Build())
                .UseStartup<Startup>();

            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                string result = await client.GetStringAsync("/api/meteo");
                result.Should().Be("Pluie");
            }
        }

        [TestMethod]
        public async Task QuelTempsFaitIl_AvecDeLaTempete_RetourneDeLaTempete()
        {
            await Insertion("Tempete");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(_repetoire)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(_repetoire)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.TestsAuto.json")
                .Build()).UseEnvironment("TestsAuto").UseStartup<Startup>();

            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                string result = await client.GetStringAsync("/api/meteo");
                result.Should().Be("Tempete");
            }
        }

        private async Task Insertion(string temps)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                await connection.ExecuteAsync(@"INSERT INTO dbo.InfosMeteo values (@temps, Convert(date, getdate()))", new { temps });
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
