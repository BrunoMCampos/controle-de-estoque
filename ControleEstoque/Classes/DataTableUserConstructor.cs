using System.Collections.Generic;
using System.Data;

namespace ControleEstoque.Classes
{
    public class DataTableUserConstructor
    {
        private DataTable table = new DataTable();

        public DataTableUserConstructor()
        {
            table.Columns.Add("ID");
            table.Columns.Add("Usuário");
            table.Columns.Add("Privilégios");
        }

        public void removeAll()
        {
            table.Rows.Clear();
        }

        public void addItem(Login login)
        {
            table.Rows.Add(login);
        }

        public void addItem(List<Login> loginList)
        {
            foreach (Login login in loginList)
            {
                table.Rows.Add(
                    login.Id,
                    login.User,
                    login.Privileges);
            }
        }

        public DataTable getDataTable()
        {
            return table;
        }
    }
}
