using BCrypt.Net;
using ControleEstoque.Classes;
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
    public partial class FormUser : Form
    {
        LoginRepository loginRepository = new LoginRepository();

        Login login;

        public FormUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            comboBoxPrivileges.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                if (loginRepository.isUserRegistered(textBoxUser.Text))
                {
                    MessageBox.Show("Usuário já cadastrado na base de dados!","Dados inválidos!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else
                {
                    EnumPrivileges privileges = extractEnumFromCombobox();

                    string hashPassword = BCrypt.Net.BCrypt.HashPassword(textBoxPassword.Text);

                    Login login = new Login(textBoxUser.Text, hashPassword, privileges);

                    if (loginRepository.InsertLoginCredentials(login))
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Cadastro Efetuado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private EnumPrivileges extractEnumFromCombobox()
        {
            switch (comboBoxPrivileges.SelectedItem.ToString())
            {
                case "Administrador":
                    return EnumPrivileges.ADMINISTRATOR;

                case "Convidado":
                    return EnumPrivileges.GUEST;

                case "Usuário Padrão":
                    return EnumPrivileges.DEFAULT_USER;

                default:
                    return EnumPrivileges.GUEST;
            }
        }

        private bool validateForm()
        {
            if (textBoxUser.Text.Length < 4)
            {
                MessageBox.Show("Entre com um usuário com ao menos 4 caracteres!", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(textBoxUser, "Entre com um usuário com ao menos 4 caracteres");
                return false;
            }
            if (textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("Entre com uma senha com ao menos 6 caracteres!", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(textBoxPassword, "Entre com uma senha com ao menos 6 caracteres");
                return false;
            }
            if (comboBoxPrivileges.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione o nível de privilégio do usuário a ser criado!", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(comboBoxPrivileges, "Selecione o nível de privilégio do usuário a ser criado");
                return false;
            }
            return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPassword.Clear();
            textBoxUser.Clear();
            comboBoxPrivileges.SelectedIndex = 0;
        }
    }
}
