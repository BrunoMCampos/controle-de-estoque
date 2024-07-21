namespace ControleEstoque.Classes
{
    public class Login
    {
        private int id;
        private string user;
        private string password;
        private EnumPrivileges privileges;
        private bool resetPassword;

        public Login(int id, string user, string password, EnumPrivileges privileges, bool resetPassword)
        {
            this.user = user;
            this.password = password;
            this.privileges = privileges;
            this.id = id;
            this.resetPassword = resetPassword;
        }

        public Login(string user, string password, EnumPrivileges privileges)
        {
            this.user = user;
            this.password = password;
            this.privileges = privileges;
        }

        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public EnumPrivileges Privileges { get => privileges; set => privileges = value; }
        public int Id { get => id; set => id = value; }
        public bool ResetPassword { get => resetPassword; set => resetPassword = value; }
    }
}
