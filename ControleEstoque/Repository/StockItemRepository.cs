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
                        "SELECT " +
                        "e.*,p.description,p.cod,p.name,p.unit,p.url_image " +
                        "FROM " +
                        "stock e, product p " +
                        "WHERE " +
                        "e.id = @id LIMIT 1",
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
                            (int)dataReader["product_id"],
                            dataReader["name"].ToString(),
                            dataReader["description"].ToString(),
                            dataReader["cod"].ToString(),
                            dataReader["unit"].ToString(),
                            dataReader["url_image"].ToString()
                        ),
                        (int)dataReader["stock_amount"]
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
                            "SELECT e.*, p.description, p.cod, p.name, p.unit, p.url_image FROM stock e, product p " +
                            "WHERE e.product_id = p.id AND e.stock_amount > 0 LIMIT 20",
                            Connection.getConnection()
                        );
                }
                else
                {
                    query = new MySqlCommand(
                            "SELECT e.*, p.description, p.cod, p.name, p.unit, p.url_image FROM stock e, product p " +
                            "WHERE e.product_id = p.id LIMIT 20",
                            Connection.getConnection()
                        );
                }
                Connection.Connect();
                MySqlDataReader dataReader = query.ExecuteReader();

                List<StockItem> Items = new List<StockItem>();
                while (dataReader.Read())
                {
                    double doubleStockAmount = Double.Parse(dataReader["stock_amount"].ToString());

                    StockItem item = new StockItem(
                        (int)dataReader["id"],
                        new Product(
                            (int)dataReader["product_id"],
                            dataReader["name"].ToString(),
                            dataReader["description"].ToString(),
                            dataReader["cod"].ToString(),
                            dataReader["unit"].ToString(),
                            dataReader["url_image"].ToString()
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
