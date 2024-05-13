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
                        "INSERT INTO alteracao_estoque " +
                        "(estoque_id, saldo_inicial, movimentacao, quantidade_movimentada, saldo_final, motivo, justificativa, data_hora_alteracao) " +
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
                        "SELECT * FROM alteracao_estoque " +
                        "WHERE " +
                        "estoque_id = @stockId " +
                        "ORDER BY data_hora_alteracao DESC",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@stockId", stockItem.Id.ToString());

                Connection.Connect();

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    StockUpdateRecord stockUpdate = new StockUpdateRecord(
                        stockItem,
                        Double.Parse(reader["saldo_inicial"].ToString()),
                        (EnumMovementType) Int32.Parse(reader["movimentacao"].ToString()),
                        Double.Parse(reader["quantidade_movimentada"].ToString()),
                        Double.Parse(reader["saldo_final"].ToString()),
                        reader["motivo"].ToString(),
                        reader["justificativa"].ToString(),
                        DateTime.Parse(reader["data_hora_alteracao"].ToString())
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
    }
}
