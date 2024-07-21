namespace ControleEstoque.Classes
{
    public class StockItem
    {
        private int id;
        private double stockAmount;
        private Product product;

        public StockItem(int id, Product product, double stockAmount)
        {
            this.id = id;
            this.product = product;
            this.stockAmount = stockAmount;
        }

        public int Id { get => id; set => id = value; }
        public double StockAmount { get => stockAmount; set => stockAmount = value; }
        public Product Product { get => product; set => product = value; }

    }
}
