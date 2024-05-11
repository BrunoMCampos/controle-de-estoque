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
                        "SELECT * FROM produto WHERE id = @id LIMIT 1",
                        Connection.getConnection()
                    );

                query.Parameters.AddWithValue("@id", id);
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();


                if (dataReader.Read())
                {
                    Product product = new Product(
                        (int)dataReader["id"],
                        (string)dataReader["nome"],
                        (string)dataReader["unidade"]
                    );
                    if (!dataReader.IsDBNull(2))
                    {
                        product.Description = (string)dataReader["descricao"];
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        product.Cod = (string)dataReader["codigo"];
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        product.Cod = (string)dataReader["unidade"];
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        product.UrlImage = (string)dataReader["url_imagem"];
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
                        "SELECT * FROM produto WHERE nome = @nome LIMIT 1",
                        Connection.getConnection()
                    );

                query.Parameters.AddWithValue("@nome", name);
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();


                if (dataReader.Read())
                {
                    Product product = new Product(
                        (int)dataReader["id"],
                        (string)dataReader["nome"],
                        (string)dataReader["unidade"]
                    );
                    if (!dataReader.IsDBNull(2))
                    {
                        product.Description = (string)dataReader["descricao"];
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        product.Cod = (string)dataReader["codigo"];
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        product.Cod = (string)dataReader["unidade"];
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        product.UrlImage = (string)dataReader["url_imagem"];
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
                        "INSERT INTO produto (nome, descricao, codigo, unidade, url_imagem) " +
                        "VALUES (@nome, @descricao, @codigo, @unidade, @url_imagem)",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@nome", produto.Name);
                query.Parameters.AddWithValue("@descricao", produto.Description);
                query.Parameters.AddWithValue("@codigo", produto.Cod);
                query.Parameters.AddWithValue("@unidade", produto.Unit);
                query.Parameters.AddWithValue("@url_imagem", produto.UrlImage);

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
                        "UPDATE produto SET " +
                        "nome = @nome, " +
                        "descricao = @descricao, " +
                        "codigo = @codigo, " +
                        "unidade = @unidade, " +
                        "url_imagem = @url_imagem " +
                        "WHERE " +
                        "id = @id",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@id", produto.Id);
                query.Parameters.AddWithValue("@nome", produto.Name);
                query.Parameters.AddWithValue("@descricao", produto.Description);
                query.Parameters.AddWithValue("@codigo", produto.Cod);
                query.Parameters.AddWithValue("@unidade", produto.Unit);
                query.Parameters.AddWithValue("@url_imagem", produto.UrlImage);

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
                        "DELETE FROM produto WHERE id = @id",
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
