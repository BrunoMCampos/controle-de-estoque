using MySql.Data.MySqlClient;
using System.Data;

namespace ControleEstoque.Classes
{
    static class Connection
    {
        private static MySqlConnection mySqlConnection = new MySqlConnection();
        private static MySqlCommand mySqlCommand = new MySqlCommand();
        private static MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();

        private static string errorMessage;
        private static string connectionString;

        static Connection()
        {
        }

        public static void SetConnectionString(string server, string dataBase, string user, string password)
        {
            connectionString = "Persist Security Info=False;";
            connectionString += "Server=" + server + ";";
            connectionString += "Database=" + dataBase + ";";
            connectionString += "User=" + user + ";";
            connectionString += "Pwd=" + password + ";";
        }

        public static string GetErrorMessage()
        {
            return errorMessage;
        }

        public static MySqlConnection getConnection()
        {
            return mySqlConnection;
        }

        public static MySqlDataAdapter getDataAdapter()
        {
            return mySqlDataAdapter;
        }

        public static bool Connect()
        {
            try
            {
                Disconnect();
                mySqlConnection.ConnectionString = connectionString;
                mySqlCommand.Connection = mySqlConnection;
                mySqlConnection.Open();
                return true;
            }
            catch (MySqlException erro)
            {
                errorMessage = erro.Message.ToString();
                return false;
            }
        }

        public static bool Disconnect()
        {
            try
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
                return true;
            }
            catch (MySqlException erro)
            {
                errorMessage = erro.Message.ToString();
                return false;
            }
        }

        public static bool TestConnection()
        {
            if (Connect())
            {
                Disconnect();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
