using ControleEstoque.Classes;
using ControleEstoque.Repository;
using ControleEstoque.Repository.ProdutoRepository;
using ControleEstoque.WindowController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormMain : Form
    {

        StockItemRepository itemRepository = new StockItemRepository();
        ProductRepository produtoRepository = new ProductRepository();
        List<StockItem> itemsStock = new List<StockItem>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            buttonUpdateTable_Click(sender, e);
        }

        private void buttonUpdateTable_Click(object sender, EventArgs e)
        {
            DataTableStockConstructor tableConstructor = new DataTableStockConstructor();

            itemsStock = itemRepository.GetAllStockItems(checkBoxOnlyPositive.Checked);

            tableConstructor.addItem(itemsStock);

            dataGridViewStock.DataSource = tableConstructor.getDataTableEstoque();
            dataGridViewStock.Refresh();
            dataGridViewStock.ClearSelection();

            pictureBoxImage.ImageLocation = "";
            pictureBoxImage.Refresh();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (Controller.ShowFormAddProduto() == DialogResult.OK)
            {
                buttonUpdateTable_Click(sender, e);
            }
        }

        private void checkBoxOnlyPositive_CheckedChanged(object sender, EventArgs e)
        {
            buttonUpdateTable_Click(sender, e);
        }

        private void dataGridViewEstoque_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pictureBoxImage.ImageLocation = itemsStock[e.RowIndex].Product.UrlImage;
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            Product productToUpdate = itemsStock[dataGridViewStock.SelectedRows[0].Index].Product;
            if (Controller.ShowFormAlterarProduto(productToUpdate) == DialogResult.OK)
            {
                buttonUpdateTable_Click(sender, e);
            }
        }

        private void buttonAddStock_Click(object sender, EventArgs e)
        {
            showFormUpdateStock(sender, e, EnumMovementType.Add);
        }

        private void showFormUpdateStock(object sender, EventArgs e, EnumMovementType movement)
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                StockItem item = itemsStock[dataGridViewStock.SelectedRows[0].Index];
                DialogResult dialog = DialogResult.OK;
                if (movement == EnumMovementType.Subtract)
                {
                    dialog = Controller.ShowFormSubtrairSaldo(item);
                }
                else if (movement == EnumMovementType.Add)
                {
                    dialog = Controller.ShowFormSubtrairSaldo(item);
                }
                if (dialog == DialogResult.OK)
                {
                    buttonUpdateTable_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para realizar a alteração de estoque.", "Seleção Incorreta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonSubtractStock_Click(object sender, EventArgs e)
        {
            showFormUpdateStock(sender, e, EnumMovementType.Subtract);
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                Product produto = itemsStock[dataGridViewStock.SelectedRows[0].Index].Product;
                string nomeProduto = itemsStock[dataGridViewStock.SelectedRows[0].Index].Product.Name;
                string message = "Deseja realmente excluir o produto " + nomeProduto;
                DialogResult result = MessageBox.Show(message, "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (produtoRepository.DeleteProduto(produto))
                    {
                        if (produto.UrlImage != null && produto.UrlImage.Length > 0)
                        {
                            try
                            {
                                File.Delete(produto.UrlImage);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.StackTrace);
                            }
                        }
                    }
                    buttonUpdateTable_Click(sender, e);
                }
            }
        }

        private void dataGridViewEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdateProduct_Click(sender, e);
        }

        private void dataGridViewStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                pictureBoxImage.ImageLocation = itemsStock[dataGridViewStock.SelectedRows[0].Index].Product.UrlImage;
            }
        }

        private void dataGridViewStock_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                pictureBoxImage.ImageLocation = itemsStock[dataGridViewStock.SelectedRows[0].Index].Product.UrlImage;
            }
        }
    }
}
