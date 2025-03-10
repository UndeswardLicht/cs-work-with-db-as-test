using System.Data;
using MySql.Data.MySqlClient;

namespace SQLQueries_Test.Utilities
{
    internal static class CustomDataRetriever
    {
        public static DataTable GetData(MySqlConnection con, string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
