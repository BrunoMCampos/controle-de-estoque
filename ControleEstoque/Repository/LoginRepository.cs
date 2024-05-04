using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ControleEstoque.Repository
{
    internal class LoginRepository
    {
        public string GetPasswordByUser(string user)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                    "SELECT password FROM login WHERE user = @user LIMIT 1",
                    Connection.getConnection()
                );
                query.Parameters.AddWithValue("@user", user);

                Connection.Connect();

                MySqlDataReader dataReader = query.ExecuteReader();

                if (dataReader.Read())
                {
                    return dataReader.GetString(0);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            } finally { 
                Connection.Disconnect();
            }
            return "";
        }
    }
}
