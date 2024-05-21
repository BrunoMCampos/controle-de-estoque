using ControleEstoque.Classes;
using System.Windows.Forms;

namespace ControleEstoque.WindowController
{
    static class Controller
    {
        private static FormMain formMain;

        private static FormProduct formProduct;
        private static FormUpdateStock formUpdateStock;
        private static FormStockUpdateRecord formStockUpdateRecord;
        private static FormUser formAddUser;
        private static FormManageUsers formManageUsers;

        public static Login currentUser;

        public static void createMainForm()
        {
            formMain = new FormMain(currentUser.Privileges)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
        }

        public static FormMain GetFormMain()
        {
            return formMain;
        }

        public static DialogResult ShowFormAddProduct()
        {
            formProduct = new FormProduct("Adicionar Produto")
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            return formProduct.ShowDialog();
        }

        public static DialogResult ShowFormUpdateProduct(Product produto)
        {
            formProduct = new FormProduct("Alterar Produto");
            formProduct.Produto = produto;
            formProduct.StartPosition = FormStartPosition.CenterScreen;
            return formProduct.ShowDialog();
        }

        public static DialogResult ShowFormAdicionarSaldo(StockItem itemEstoque)
        {
            formUpdateStock = new FormUpdateStock("Adicionar Saldo", EnumMovementType.Add, itemEstoque);
            formUpdateStock.StartPosition = FormStartPosition.CenterScreen;
            return formUpdateStock.ShowDialog();
        }

        public static DialogResult ShowFormSubtrairSaldo(StockItem itemEstoque)
        {
            formUpdateStock = new FormUpdateStock("Subtrair Saldo", EnumMovementType.Subtract, itemEstoque);
            formUpdateStock.StartPosition = FormStartPosition.CenterScreen;
            return formUpdateStock.ShowDialog();
        }
        public static DialogResult ShowFormStockUpdateRecords(StockItem itemEstoque)
        {
            formStockUpdateRecord = new FormStockUpdateRecord(itemEstoque);
            formStockUpdateRecord.StartPosition = FormStartPosition.CenterScreen;
            return formStockUpdateRecord.ShowDialog();
        }

        public static DialogResult ShowFormAddUser()
        {
            formAddUser = new FormUser();
            formAddUser.StartPosition = FormStartPosition.CenterScreen;
            return formAddUser.ShowDialog();
        }

        public static DialogResult ShowFormManageUser()
        {
            formManageUsers = new FormManageUsers();
            formManageUsers.StartPosition = FormStartPosition.CenterScreen;
            return formManageUsers.ShowDialog();
        }
    }
}
