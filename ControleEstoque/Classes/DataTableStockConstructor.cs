using System.Collections.Generic;
using System.Data;

namespace ControleEstoque.Classes
{
    public class DataTableStockConstructor
    {
        private DataTable table = new DataTable();

        public DataTableStockConstructor()
        {
            table.Columns.Add("ID Estoque");
            table.Columns.Add("Código do Produto");
            table.Columns.Add("Nome do Produto");
            table.Columns.Add("Quantidade em Estoque");
            table.Columns.Add("Un.");
        }

        public void removeAll()
        {
            table.Rows.Clear();
        }

        public void addItem(StockItem item)
        {
            table.Rows.Add(item);
        }

        public void addItem(List<StockItem> itens)
        {
            foreach (StockItem itemEstoque in itens)
            {
                table.Rows.Add(
                    itemEstoque.Id,
                    itemEstoque.Product.Cod,
                    itemEstoque.Product.Name,
                    itemEstoque.StockAmount,
                    itemEstoque.Product.Unit);
            }
        }

        public DataTable getDataTableStock()
        {
            return table;
        }
    }
}
