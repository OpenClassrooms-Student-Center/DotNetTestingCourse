using Dapper;
using System;
using System.Data.SqlClient;

namespace Jeu6
{
    public class MeteoRepository : IFournisseurMeteo
    {
        private readonly string _connectionstring;

        public MeteoRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public Meteo QuelTempsFaitIl(DateTime dateSouhaitee)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var ligne = connection.QueryFirst("select Valeur from [dbo].InfosMeteo where DATE = Convert(date, @date)", new { date = dateSouhaitee });
                return Enum.Parse(typeof(Meteo), ligne.Valeur);
            }
        }
    }
}
