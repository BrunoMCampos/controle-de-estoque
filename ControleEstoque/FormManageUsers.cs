using ControleEstoque.Classes;
using ControleEstoque.Repository;
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
            List<Login> users = loginRepository.GetAllUsers();
        }
    }
}
