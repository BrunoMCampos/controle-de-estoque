using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Repository
{
    public class StockUpdateRecordRepository
    {
        public bool InsertStockUpdateRecord(StockUpdateRecord alteracaoEstoque)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "INSERT INTO stock_update " +
                        "(stock_id, start_amount, movement_type, movement_amount, end_amount, reason, justification, update_date_time) " +
                        "VALUES " +
                        "(@estoque_id, @saldo_inicial, @movimentacao, @quantidade_movimentada, @saldo_final, @motivo, @justificativa, @data_hora_alteracao)",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@estoque_id", alteracaoEstoque.ItemEstoque.Id);
                query.Parameters.AddWithValue("@saldo_inicial", alteracaoEstoque.StartAmount);
                query.Parameters.AddWithValue("@movimentacao", alteracaoEstoque.MovementType);
                query.Parameters.AddWithValue("@quantidade_movimentada", alteracaoEstoque.MovementedAmount);
                query.Parameters.AddWithValue("@saldo_final", alteracaoEstoque.EndAmount);
                query.Parameters.AddWithValue("@motivo", alteracaoEstoque.Reason);
                query.Parameters.AddWithValue("@justificativa", alteracaoEstoque.Justification);
                query.Parameters.AddWithValue("@data_hora_alteracao", alteracaoEstoque.UpdateDateTime);

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

        public List<StockUpdateRecord> getAllRecordsByStockItem(StockItem stockItem)
        {
            List<StockUpdateRecord> stockUpdateRecordList = new List<StockUpdateRecord>();

            try
            {
                MySqlCommand query = new MySqlCommand(
                        "SELECT * FROM stock_update " +
                        "WHERE " +
                        "stock_id = @stockId " +
                        "ORDER BY update_date_time DESC",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@stockId", stockItem.Id.ToString());

                Connection.Connect();

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    StockUpdateRecord stockUpdate = new StockUpdateRecord(
                        stockItem,
                        Double.Parse(reader["start_amount"].ToString()),
                        (EnumMovementType) Int32.Parse(reader["movement_type"].ToString()),
                        Double.Parse(reader["movement_amount"].ToString()),
                        Double.Parse(reader["end_amount"].ToString()),
                        reader["reason"].ToString(),
                        reader["justification"].ToString(),
                        DateTime.Parse(reader["update_date_time"].ToString())
                    );

                    stockUpdateRecordList.Add(stockUpdate);
                }

                Connection.Disconnect();

                return stockUpdateRecordList;
            } catch (Exception e){ 
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return new List<StockUpdateRecord>(); 
            }
        }

        public List<StockUpdateRecord> getAllRecordsByStockItemBetweenDates(StockItem stockItem, DateTime startDate, DateTime endDate)
        {
            List<StockUpdateRecord> stockUpdateRecordList = new List<StockUpdateRecord>();

            // Primeiro iremos garantir que a data inicial tenha o horário 00:00:00, pegando apenas a data e atribuindo novamente à variável.
            startDate = startDate.Date;

            // Aqui faremos o mesmo, mas adicionaremos 1 dia e pegaremos apenas a data, deixando a hora de lado, assim teremos a hora 
            // 00:00:00 do dia seguinte, depois subtraímos 1 segundo e temos as 23:59:59 do dia anterior que é o que estamos pesquisando.
            endDate = endDate.Date.AddDays(1).Date.Subtract(new TimeSpan(0,0,1));

            try
            {
                MySqlCommand query = new MySqlCommand(
                        "SELECT * FROM stock_update " +
                        "WHERE " +
                        "stock_id = @stockId AND " +
                        "update_date_time BETWEEN @startDate AND @endDate " +
                        "ORDER BY update_date_time DESC",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@stockId", stockItem.Id.ToString());
                query.Parameters.AddWithValue("@startDate", startDate);
                query.Parameters.AddWithValue("@endDate", endDate);

                Connection.Connect();

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    StockUpdateRecord stockUpdate = new StockUpdateRecord(
                        stockItem,
                        Double.Parse(reader["start_amount"].ToString()),
                        (EnumMovementType)Int32.Parse(reader["movement_type"].ToString()),
                        Double.Parse(reader["movement_amount"].ToString()),
                        Double.Parse(reader["end_amount"].ToString()),
                        reader["reason"].ToString(),
                        reader["justification"].ToString(),
                        DateTime.Parse(reader["update_date_time"].ToString())
                    );

                    stockUpdateRecordList.Add(stockUpdate);
                }

                Connection.Disconnect();

                return stockUpdateRecordList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return new List<StockUpdateRecord>();
            }
        }
    }
}
