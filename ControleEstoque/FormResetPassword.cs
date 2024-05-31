using BCrypt.Net;
using ControleEstoque.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormResetPassword : Form
    {
        LoginRepository loginRespository = new LoginRepository();

        private int userId;

        public FormResetPassword(int id)
        {
            InitializeComponent();
            this.userId = id;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "O acesso ao sistema será bloqueado até a nova senha ser definida, deseja realmente retornar a tela de login?",
                "Atenção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            //textBoxConfirmPassword_Validating(sender, new CancelEventArgs());
        }

        private void textBoxConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxConfirmPassword.Text != textBoxPassword.Text)
            {
                errorProvider1.SetError(textBoxConfirmPassword, "As senhas não são iguais.");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(textBoxConfirmPassword.Text == textBoxPassword.Text)
            {
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(textBoxConfirmPassword.Text);
                if (loginRespository.updatePassword(userId, hashPassword))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "Senha alterada com sucesso!",
                        "Alteração de Senha",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
