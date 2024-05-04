using ControleEstoque.Classes;
using MySql.Data.MySqlClient;
using System;

namespace ControleEstoque.Repository
{
    internal class AlteracaoEstoqueRepository
    {
        //private AlteracaoEstoque alteracaoEstoque;

        public bool InsertAlteracaoEstoque(AlteracaoEstoque alteracaoEstoque)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                        "INSERT INTO alteracao_estoque " +
                        "(estoque_id, saldo_inicial, movimentacao, quantidade_movimentada, saldo_final, motivo, justificativa) " +
                        "VALUES " +
                        "(@estoque_id, @saldo_inicial, @movimentacao, @quantidade_movimentada, @saldo_final, @motivo, @justificativa)",
                        Connection.getConnection()
                    );
                query.Parameters.AddWithValue("@estoque_id", alteracaoEstoque.ItemEstoque.Id);
                query.Parameters.AddWithValue("@saldo_inicial", alteracaoEstoque.SaldoInicial);
                query.Parameters.AddWithValue("@movimentacao", alteracaoEstoque.Movimentacao);
                query.Parameters.AddWithValue("@quantidade_movimentada", alteracaoEstoque.QuantidadeMovimentada);
                query.Parameters.AddWithValue("@saldo_final", alteracaoEstoque.SaldoFinal);
                query.Parameters.AddWithValue("@motivo", alteracaoEstoque.Motivo);
                query.Parameters.AddWithValue("@justificativa", alteracaoEstoque.Justificativa);

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
