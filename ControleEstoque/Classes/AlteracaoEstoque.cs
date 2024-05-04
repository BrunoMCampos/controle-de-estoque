namespace ControleEstoque.Classes
{
    internal class AlteracaoEstoque
    {
        private int id;
        private ItemEstoque itemEstoque;
        private double saldoInicial;
        private EnumMovementType movimentacao;
        private double quantidadeMovimentada;
        private double saldoFinal;
        private string motivo;
        private string justificativa;

        public AlteracaoEstoque(ItemEstoque itemEstoque, double saldoInicial, EnumMovementType movimentacao, double quantidadeMovimentada, double saldoFinal, string motivo, string justificativa)
        {
            this.ItemEstoque = itemEstoque;
            this.SaldoInicial = saldoInicial;
            this.Movimentacao = movimentacao;
            this.QuantidadeMovimentada = quantidadeMovimentada;
            this.SaldoFinal = saldoFinal;
            this.Motivo = motivo;
            this.Justificativa = justificativa;
        }

        public int Id { get => id; set => id = value; }
        public double SaldoInicial { get => saldoInicial; set => saldoInicial = value; }
        public EnumMovementType Movimentacao { get => movimentacao; set => movimentacao = value; }
        public double QuantidadeMovimentada { get => quantidadeMovimentada; set => quantidadeMovimentada = value; }
        public double SaldoFinal { get => saldoFinal; set => saldoFinal = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Justificativa { get => justificativa; set => justificativa = value; }
        internal ItemEstoque ItemEstoque { get => itemEstoque; set => itemEstoque = value; }
    }
}
