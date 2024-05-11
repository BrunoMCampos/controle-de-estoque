using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Repository
{
    internal class StockItemRepository
    {
        public StockItemRepository() { }

        public StockItem GetStockItemById(int id)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "SELECT e.*,p.descricao,p.codigo,p.nome,p.unidade,p.url_imagem FROM estoque e, produto p WHERE e.id = @id LIMIT 1",
                        Connection.getConnection()
                    );

                query.Parameters.AddWithValue("@id", id);
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();

                if (dataReader.Read())
                {
                    StockItem item = new StockItem(
                        (int)dataReader["id"],
                        new Product(
                            (int)dataReader["produto_id"],
                            dataReader["nome"].ToString(),
                            dataReader["descricao"].ToString(),
                            dataReader["codigo"].ToString(),
                            dataReader["unidade"].ToString(),
                            dataReader["url_imagem"].ToString()
                        ),
                        (int)dataReader["quantidade_estoque"]
                    );
                    Connection.Disconnect();
                    return item;
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

        public List<StockItem> GetAllStockItems(bool onlyPositiveAmount)
        {
            try
            {
                MySqlCommand query;
                if (onlyPositiveAmount)
                {
                    query = new MySqlCommand(
                            "SELECT e.*,p.descricao,p.codigo,p.nome,p.unidade,p.url_imagem FROM estoque e, produto p WHERE e.produto_id = p.id AND e.quantidade_estoque > 0 LIMIT 20",
                            Connection.getConnection()
                        );
                }
                else
                {
                    query = new MySqlCommand(
                            "SELECT e.*,p.descricao,p.codigo,p.nome,p.unidade,p.url_imagem FROM estoque e, produto p WHERE e.produto_id = p.id LIMIT 20",
                            Connection.getConnection()
                        );
                }
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();

                List<StockItem> Items = new List<StockItem>();
                while (dataReader.Read())
                {
                    double doubleStockAmount = Double.Parse(dataReader["quantidade_estoque"].ToString());

                    StockItem item = new StockItem(
                        (int)dataReader["id"],
                        new Product(
                            (int)dataReader["produto_id"],
                            dataReader["nome"].ToString(),
                            dataReader["descricao"].ToString(),
                            dataReader["codigo"].ToString(),
                            dataReader["unidade"].ToString(),
                            dataReader["url_imagem"].ToString()
                        ),
                        doubleStockAmount
                    );
                    Items.Add(item);
                }
                Connection.Disconnect();
                return Items;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Code);
                Console.WriteLine(ex.StackTrace);
                return new List<StockItem>();
            }
        }


    }
}
