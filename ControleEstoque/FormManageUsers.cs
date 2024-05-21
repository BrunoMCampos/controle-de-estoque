using ControleEstoque.Classes;
using ControleEstoque.Repository;
using ControleEstoque.WindowController;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormManageUsers : Form
    {
        LoginRepository loginRepository = new LoginRepository();

        public FormManageUsers()
        {
            InitializeComponent();
        }

        private void FormManageUsers_Load(object sender, EventArgs e)
        {
            List<Login> users = loginRepository.GetAllUsersExceptByCurrentUser(Controller.currentUser.Id);
            ReloadTable(users);
        }

        private void ReloadTable(List<Login> users)
        {
            DataTableUserConstructor tableConstructor = new DataTableUserConstructor();

            tableConstructor.addItem(users);

            this.dataGridViewUsers.DataSource = tableConstructor.getDataTable();
            this.dataGridViewUsers.Refresh();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Login> users = loginRepository.GetLoginWithUserContainingTextExceptByCurrentUser(textBoxSearchUser.Text, Controller.currentUser.Id);
            ReloadTable(users);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(dataGridViewUsers.SelectedRows.Count > 0)
            {
                int loginId = Int32.Parse(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
                if (MessageBox.Show(
                    "Deseja realmente excluir o usuário selecionado? \n" +
                    "Ele não poderá mais ser utilizado para acessar o sistema e perderá todos os privilégios, " +
                    "sendo necessário novo cadastro para sua futura utilização.",
                    "Excluir Usuário",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (loginRepository.DeleteLoginCredentials(loginId))
                    {
                        MessageBox.Show("Usuário excluído com sucesso!","Excluir Usuário",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            if(dataGridViewUsers.SelectedRows.Count > 0)
            {
                int loginId = Int32.Parse(dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());

                if(MessageBox.Show(
                    "Deseja realmente resetar a senha do usuário selecionado?",
                    "Resetar Senha",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(loginRepository.setLoginResetPassword(loginId, true))
                    {
                        MessageBox.Show(
                            "Senha resetada com sucesso. \n" +
                            "Utilizar a senha: 123456 para próximo acesso.\n" +
                            "Uma nova senha será solicitada após acesso o sistema.",
                            "Resetar Senha",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonUpdatePrivileges_Click(object sender, EventArgs e)
        {

        }
    }
}
