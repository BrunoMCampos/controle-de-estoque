using ControleEstoque.Classes;
using ControleEstoque.Repository;
using System.Collections.Generic;
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
            for(int i = 0; i < listStockUpdateRecords.Count; i++)
            {
                treeView1.Nodes.Add(
                    listStockUpdateRecords[i].UpdateDateTime.Date.ToString(),
                    listStockUpdateRecords[i].UpdateDateTime.Date.ToString()
                    );

                List<StockUpdateRecord> sameDateRecords = listStockUpdateRecords.FindAll(record => record.UpdateDateTime.Date.Equals(listStockUpdateRecords[i].UpdateDateTime.Date));
                sameDateRecords.RemoveAt(0);

                sameDateRecords.ForEach(record =>
                {
                    treeView1.Nodes[listStockUpdateRecords[i].UpdateDateTime.Date.ToString()].Nodes.Add(
                        record.MovementedAmount.ToString() + " " + record.MovementType.ToString()
                        );
                    listStockUpdateRecords.Remove(record);
                });
            }
        }
    }
}
