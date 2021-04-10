using System.Data.SqlClient;
using System.Configuration;

namespace Taller.Data
{
    public class TalleDataAccess 
    {
        public readonly SqlConnection _SqlConnection;
        public readonly SqlCommand _SqlCommand;
        public SqlDataReader _DataReader;

        public static TalleDataAccess GetInstance() => new TalleDataAccess();

        private TalleDataAccess()
        {
            _SqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };

            _SqlCommand = new SqlCommand
            {
                Connection = _SqlConnection
            };
        }

        public TalleDataAccess OpenConnection()
        {
            _SqlConnection.Open();

            return this;
        }

        public TalleDataAccess CloseConnection()
        {
            _SqlConnection.Close();

            return this;
        }

    }
}