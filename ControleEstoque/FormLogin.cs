using ControleEstoque.Repository;
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

            bool passwordVerification = BCrypt.Net.BCrypt.Verify(password, dataBasePassword);

            if (passwordVerification)
            {
                DialogResult = DialogResult.Yes;
            }
            else
            {
                MessageBox.Show(
                    "Usuário ou senha inválidos, por favor, tente novamente.", 
                    "Dados Incorretos para Login", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }

        }
    }
}
