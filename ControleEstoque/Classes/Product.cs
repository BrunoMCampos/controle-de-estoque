namespace ControleEstoque.Classes
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private string cod;
        private string unit;
        private string urlImage;

        public Product(int id, string nome, string unidade)
        {
            this.id = id;
            this.name = nome;
            this.unit = unidade;
        }

        public Product(string nome, string descricao, string codigo, string unidade, string urlImagem)
        {
            this.name = nome;
            this.description = descricao;
            this.cod = codigo;
            this.unit = unidade;
            this.urlImage = urlImagem;
        }

        public Product(int id, string nome, string descricao, string codigo, string unidade, string urlImagem)
        {
            this.id = id;
            this.name = nome;
            this.description = descricao;
            this.cod = codigo;
            this.unit = unidade;
            this.urlImage = urlImagem;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Cod { get => cod; set => cod = value; }
        public string Unit { get => unit; set => unit = value; }
        public string UrlImage { get => urlImage; set => urlImage = value; }
    }
}
