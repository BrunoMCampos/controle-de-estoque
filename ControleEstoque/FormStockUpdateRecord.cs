using ControleEstoque.Classes;
using ControleEstoque.Repository;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormStockUpdateRecord : Form
    {
        private StockItem stockItem;
        private StockUpdateRecordRepository stockUpdateRecordRepository = new StockUpdateRecordRepository();

        public FormStockUpdateRecord(StockItem stockItem)
        {
            InitializeComponent();
            this.stockItem = stockItem;
        }

        private void FormStockUpdateRecord_Load(object sender, System.EventArgs e)
        {
            this.labelProductName.Text = stockItem.Product.Name;
            this.textBoxCurrentAmount.Text = stockItem.StockAmount.ToString();

            treeView1.Nodes.Clear();

            List<StockUpdateRecord> listStockUpdateRecords = stockUpdateRecordRepository.getAllRecordsByStockItem(stockItem);
            createNodes(listStockUpdateRecords);
        }

        private void createNodes(List<StockUpdateRecord> listStockUpdateRecords)
        {
            // Percorre toda a lista com um for, porque iremos alterar a lista durante o processo
            for(int i = 0; i < listStockUpdateRecords.Count; i++)
            {
                // Os nodes serão ordenados apresentando primeiro a data, então pegamos a data do primeiro elemento e deixamos a key
                // dela como a própria data
                treeView1.Nodes.Add(
                    listStockUpdateRecords[i].UpdateDateTime.Date.ToShortDateString(),
                    listStockUpdateRecords[i].UpdateDateTime.Date.ToShortDateString()
                 );

                // Aqui pegamos todos os registros da lista que apresentam a mesma data já adicionada e removemos o primeiro item
                // que é o item atual do "for"
                List<StockUpdateRecord> sameDateRecords = listStockUpdateRecords.FindAll(record => record.UpdateDateTime.Date.Equals(listStockUpdateRecords[i].UpdateDateTime.Date));
                sameDateRecords.RemoveAt(0); 

                // Para cada um destes registros com a mesma data iremos adicionar da seguinte forma: Time - EnumMovementType - Amount
                sameDateRecords.ForEach(record =>
                {
                    string movementType = "";
                    Color backColor = Color.Transparent;
                    if(record.MovementType == EnumMovementType.Add)
                    {
                        movementType = "Adição";
                        backColor = Color.Blue;
                    }
                    else
                    {
                        movementType = "Subtração";
                        backColor = Color.Red;
                    }

                    treeView1
                    .Nodes[listStockUpdateRecords[i].UpdateDateTime.Date.ToShortDateString()]
                    .Nodes.Add(
                        record.UpdateDateTime.TimeOfDay.ToString() + " - " +
                        movementType + " - " +
                        record.MovementedAmount.ToString()
                        ).ForeColor = backColor;
                    listStockUpdateRecords.Remove(record);
                });
            }
        }
    }
}
