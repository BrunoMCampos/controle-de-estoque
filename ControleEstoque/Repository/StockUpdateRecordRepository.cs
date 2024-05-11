using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;

namespace ControleEstoque.Repository
{
    internal class StockUpdateRecordRepository
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
    }
}
