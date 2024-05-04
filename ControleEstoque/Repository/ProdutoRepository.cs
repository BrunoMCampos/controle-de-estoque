using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;

namespace ControleEstoque.Repository.ProdutoRepository
{
    internal class ProdutoRepository
    {
        public ProdutoRepository()
        {
        }

        public Produto GetProdutoById(int id)
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
                    Produto produto = new Produto(
                        (int)dataReader["id"],
                        (string)dataReader["nome"],
                        (string)dataReader["unidade"]
                    );
                    if (!dataReader.IsDBNull(2))
                    {
                        produto.Descricao = (string)dataReader["descricao"];
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        produto.Codigo = (string)dataReader["codigo"];
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        produto.Codigo = (string)dataReader["unidade"];
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        produto.UrlImagem = (string)dataReader["url_imagem"];
                    }
                    Connection.Disconnect();
                    return produto;
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

        public Produto GetProdutoByName(string name)
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
                    Produto produto = new Produto(
                        (int)dataReader["id"],
                        (string)dataReader["nome"],
                        (string)dataReader["unidade"]
                    );
                    if (!dataReader.IsDBNull(2))
                    {
                        produto.Descricao = (string)dataReader["descricao"];
                    }
                    if (!dataReader.IsDBNull(3))
                    {
                        produto.Codigo = (string)dataReader["codigo"];
                    }
                    if (!dataReader.IsDBNull(4))
                    {
                        produto.Codigo = (string)dataReader["unidade"];
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        produto.UrlImagem = (string)dataReader["url_imagem"];
                    }
                    Connection.Disconnect();
                    return produto;
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

        public bool InsertProduto(Produto produto)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "INSERT INTO produto (nome, descricao, codigo, unidade, url_imagem) " +
                        "VALUES (@nome, @descricao, @codigo, @unidade, @url_imagem)",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@nome", produto.Nome);
                query.Parameters.AddWithValue("@descricao", produto.Descricao);
                query.Parameters.AddWithValue("@codigo", produto.Codigo);
                query.Parameters.AddWithValue("@unidade", produto.Unidade);
                query.Parameters.AddWithValue("@url_imagem", produto.UrlImagem);

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

        public bool AlterProduto(Produto produto)
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
                query.Parameters.AddWithValue("@nome", produto.Nome);
                query.Parameters.AddWithValue("@descricao", produto.Descricao);
                query.Parameters.AddWithValue("@codigo", produto.Codigo);
                query.Parameters.AddWithValue("@unidade", produto.Unidade);
                query.Parameters.AddWithValue("@url_imagem", produto.UrlImagem);

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
        public bool DeleteProduto(Produto produto)
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
