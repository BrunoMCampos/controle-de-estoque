using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
            }
            finally
            {
                Connection.Disconnect();
            }
            return "";
        }

        public bool InsertLoginCredentials(Login login)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "INSERT INTO login (user, password, privileges) " +
                        "VALUES (@user, @password, @privileges)",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@user", login.User);
                query.Parameters.AddWithValue("@password", login.Password);
                query.Parameters.AddWithValue("@privileges", login.Privileges.ToString());

                Connection.Connect();
                query.ExecuteNonQuery();
                Connection.Disconnect();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool isUserRegistered(string user)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                    "SELECT user FROM login WHERE upper(user) = @user LIMIT 1",
                    Connection.getConnection()
                );
                query.Parameters.AddWithValue("@user", user.ToUpper());

                Connection.Connect();

                MySqlDataReader dataReader = query.ExecuteReader();

                if (dataReader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                Connection.Disconnect();
            }
        }

        public EnumPrivileges GetPrivilegesByUser(string user)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                    "SELECT privileges FROM login WHERE upper(user) = @user LIMIT 1",
                    Connection.getConnection()
                );
                query.Parameters.AddWithValue("@user", user.ToUpper());

                Connection.Connect();

                MySqlDataReader dataReader = query.ExecuteReader();

                if (dataReader.Read())
                {
                    return (EnumPrivileges)Enum.Parse(typeof(EnumPrivileges), dataReader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Connection.Disconnect();
            }
            return EnumPrivileges.GUEST;
        }

        public List<Login> GetAllUsers()
        {
            List<Login> loginList = new List<Login>();
            try
            {
                MySqlCommand query = new MySqlCommand(
                    "SELECT * FROM login",
                    Connection.getConnection()
                );

                Connection.Connect();

                MySqlDataReader dataReader = query.ExecuteReader();

                while (dataReader.Read())
                {
                    double doubleStockAmount = Double.Parse(dataReader["quantidade_estoque"].ToString());

                    Login login = new Login(
                        dataReader["user"].ToString(),
                        dataReader["password"].ToString(),
                        (EnumPrivileges)Enum.Parse(typeof(EnumPrivileges), dataReader["privileges"].ToString())
                        );

                    loginList.Add(login);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Connection.Disconnect();
            }
            return loginList;
        }
    }
}
