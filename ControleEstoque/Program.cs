using ControleEstoque.Classes;
using System;
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
            Connection.SetConnectionString("localhost", "controle_de_estoque", "magnuz", "123456");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*if (connection.TestConnection())
            {
                FormLogin formLogin = new FormLogin
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                DialogResult resultado = formLogin.ShowDialog();

                if (resultado == DialogResult.Yes)
                {*/
                    Application.Run(new FormMain { StartPosition = FormStartPosition.CenterScreen });
                /*}
            }
            else
            {
                MessageBox.Show(connection.GetErrorMessage(), "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }
    }
}
