using System.Collections.Generic;
using System.Data;

namespace ControleEstoque.Classes
{
    internal class DataTableEstoqueConstructor
    {
        private DataTable table = new DataTable();

        public DataTableEstoqueConstructor()
        {
            table.Columns.Add("ID Estoque");
            table.Columns.Add("Código do Produto");
            table.Columns.Add("Nome do Produto");
            table.Columns.Add("Quantidade em Estoque");
            table.Columns.Add("Un.");
        }

        public void addItem(ItemEstoque item)
        {
            table.Rows.Add(item);
        }

        public void addItem(List<ItemEstoque> itens)
        {
            foreach (ItemEstoque itemEstoque in itens)
            {
                table.Rows.Add(
                    itemEstoque.Id,
                    itemEstoque.Produto.Codigo,
                    itemEstoque.Produto.Nome,
                    itemEstoque.QuantidadeEstoque,
                    itemEstoque.Produto.Unidade);
            }
        }

        public DataTable getDataTableEstoque()
        {
            return table;
        }
    }
}
