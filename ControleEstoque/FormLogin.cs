using ControleEstoque.Classes;
using ControleEstoque.Repository;
using ControleEstoque.WindowController;
using System;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormLogin : Form
    {
        private readonly LoginRepository loginRepository = new LoginRepository();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string user = textBoxUser.Text;
            string password = textBoxPassword.Text;

            string dataBasePassword = loginRepository.GetPasswordByUser(user);

            if (dataBasePassword != null && dataBasePassword.Length > 0)
            {
                bool passwordVerification = BCrypt.Net.BCrypt.Verify(password, dataBasePassword);
                if (passwordVerification)
                {
                    int id = loginRepository.getIdByUser(user);
                    Login currentUser = new Login(id, user, password, loginRepository.GetPrivilegesByUser(user));
                    Controller.currentUser = currentUser;
                    Controller.createMainForm();
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    showErrorMessage();
                }
            }
            else
            {
                showErrorMessage();
            }

        }

        private static void showErrorMessage()
        {
            MessageBox.Show(
                                "Usuário ou senha inválidos, por favor, tente novamente.",
                                "Dados Incorretos para Login",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
        }
    }
}
