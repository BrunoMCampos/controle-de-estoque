namespace ControleEstoque.Classes
{
    public class Login
    {
        private string user;
        private string password;
        private EnumPrivileges privileges;

        public Login(string user, string password, EnumPrivileges privileges)
        {
            this.user = user;
            this.password = password;
            this.privileges = privileges;
        }

        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public EnumPrivileges Privileges { get => privileges; set => privileges = value; }
    }
}
