using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;

namespace ControleEstoque.Repository.ProdutoRepository
{
    internal class ProductRepository
    {
        public ProductRepository()
        {
        }

        public Product GetProductById(int id)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "SELECT * FROM product WHERE id = @id LIMIT 1",
                        Connection.getConnection()
                    );

                query.Parameters.AddWithValue("@id", id);
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();


                if (dataReader.Read())
                {
                    Product product = new Product(
                        (int)dataReader["id"],
                        (string)dataReader["name"],
                        (string)dataReader["unit"]
                    );
                    if (!dataReader.IsDBNull(2))
                    {
                        product.Description = (string)dataReader["description"];
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        product.Cod = (string)dataReader["cod"];
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        product.Cod = (string)dataReader["unit"];
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        product.UrlImage = (string)dataReader["url_image"];
                    }
                    Connection.Disconnect();
                    return product;
                }

                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Code);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public Product GetProductByName(string name)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "SELECT * FROM product WHERE name = @name LIMIT 1",
                        Connection.getConnection()
                    );

                query.Parameters.AddWithValue("@name", name);
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();


                if (dataReader.Read())
                {
                    Product product = new Product(
                        (int)dataReader["id"],
                        (string)dataReader["name"],
                        (string)dataReader["unit"]
                    );
                    if (!dataReader.IsDBNull(2))
                    {
                        product.Description = (string)dataReader["description"];
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        product.Cod = (string)dataReader["cod"];
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        product.Cod = (string)dataReader["unit"];
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        product.UrlImage = (string)dataReader["url_image"];
                    }
                    Connection.Disconnect();
                    return product;
                }

                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Code);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public bool InsertProduto(Product produto)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "INSERT INTO product (name, description, cod, unit, url_image) " +
                        "VALUES (@name, @description, @cod, @unit, @url_image)",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@name", produto.Name);
                query.Parameters.AddWithValue("@description", produto.Description);
                query.Parameters.AddWithValue("@cod", produto.Cod);
                query.Parameters.AddWithValue("@unit", produto.Unit);
                query.Parameters.AddWithValue("@url_image", produto.UrlImage);

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

        public bool UpdateProduct(Product produto)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "UPDATE product SET " +
                        "name = @name, " +
                        "description = @description, " +
                        "cod = @cod, " +
                        "unit = @unit, " +
                        "url_image = @url_image " +
                        "WHERE " +
                        "id = @id",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@id", produto.Id);
                query.Parameters.AddWithValue("@name", produto.Name);
                query.Parameters.AddWithValue("@description", produto.Description);
                query.Parameters.AddWithValue("@cod", produto.Cod);
                query.Parameters.AddWithValue("@unit", produto.Unit);
                query.Parameters.AddWithValue("@url_image", produto.UrlImage);

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
        
        public bool DeleteProduto(Product produto)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "DELETE FROM product WHERE id = @id",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@id", produto.Id);

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
    }
}
