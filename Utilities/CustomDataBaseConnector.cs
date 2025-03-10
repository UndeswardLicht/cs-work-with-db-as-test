using MySql.Data.MySqlClient;

namespace SQLQueries_Test.Utilities
{
    internal static class CustomDataBaseConnector
    {
        //TODO delete this later
        public static MySqlConnection ConnectToDb()
        {
            string conString = "server=localhost;uid=root;pwd=12345;database=union_reporting;";
            MySqlConnection con = new MySqlConnection(conString);
            return con;
        }
    }
}
