using ControleEstoque.Classes;
using System.Windows.Forms;

namespace ControleEstoque.WindowController
{
    static class Controller
    {
        private static FormProduto formProduto;
        private static FormAlterarEstoque formAlterarEstoque;

        public static DialogResult ShowFormAddProduto()
        {
            formProduto = new FormProduto
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            return formProduto.ShowDialog();
        }

        public static DialogResult ShowFormAlterarProduto(Produto produto)
        {
            formProduto = new FormProduto();
            formProduto.Produto = produto;
            formProduto.StartPosition = FormStartPosition.CenterScreen;
            return formProduto.ShowDialog();
        }

        public static DialogResult ShowFormAdicionarSaldo(ItemEstoque itemEstoque)
        {
            formAlterarEstoque = new FormAlterarEstoque("Adicionar Saldo", EnumMovementType.Add, itemEstoque);
            formAlterarEstoque.StartPosition = FormStartPosition.CenterScreen;
            return formAlterarEstoque.ShowDialog();
        }

        public static DialogResult ShowFormSubtrairSaldo(ItemEstoque itemEstoque)
        {
            formAlterarEstoque = new FormAlterarEstoque("Subtrair Saldo", EnumMovementType.Subtract, itemEstoque);
            formAlterarEstoque.StartPosition = FormStartPosition.CenterScreen;
            return formAlterarEstoque.ShowDialog();
        }
    }
}
