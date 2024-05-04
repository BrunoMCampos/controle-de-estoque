namespace ControleEstoque.Classes
{
    public class ItemEstoque
    {
        private int id;
        private double quantidadeEstoque;
        private Produto produto;

        public ItemEstoque(int id, Produto produto, double quantidadeEstoque)
        {
            this.id = id;
            this.produto = produto;
            this.quantidadeEstoque = quantidadeEstoque;
        }

        public int Id { get => id; set => id = value; }
        public double QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public Produto Produto { get => produto; set => produto = value; }

    }
}
