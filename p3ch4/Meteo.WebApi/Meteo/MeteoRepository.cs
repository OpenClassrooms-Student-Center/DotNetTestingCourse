using Dapper;
using System;
using System.Data.SqlClient;

namespace Meteo.WebApi.Meteo
{
    public class MeteoRepository
    {
        private readonly string _connectionstring;

        public MeteoRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public string QuelTempsFaitIl(DateTime dateSouhaitee)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var ligne = connection.QueryFirst("select Valeur from [dbo].InfosMeteo where DATE = Convert(date, @date)", new { date = dateSouhaitee });
                return ligne.Valeur;
            }
        }
    }
}
