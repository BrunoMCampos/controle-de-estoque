using ControleEstoque.Classes;
using ControleEstoque.WindowController;
using System;
using System.IO;
using System.Windows.Forms;

namespace ControleEstoque
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("C:/Controle de Estoque/Imagens"))
            {
                Directory.CreateDirectory("C:/Controle de Estoque/Imagens");
            }
            Connection.SetConnectionString("localhost", "stock_control", "root", "root");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin formLogin = new FormLogin
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DialogResult resultado = formLogin.ShowDialog();

            if (resultado == DialogResult.Yes)
            {
                Controller.currentUser = new Login("admin","123456",EnumPrivileges.ADMINISTRATOR);
                Controller.createMainForm();
                Application.Run(Controller.GetFormMain());
                //Application.Run(new FormControleEstoque());
            }
        }
    }
}
