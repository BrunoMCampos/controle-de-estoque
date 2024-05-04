namespace ControleEstoque.Classes
{
    public class Produto
    {
        private int id;
        private string nome;
        private string descricao;
        private string codigo;
        private string unidade;
        private string urlImagem;

        public Produto(int id, string nome, string unidade)
        {
            this.id = id;
            this.nome = nome;
            this.unidade = unidade;
        }

        public Produto(string nome, string descricao, string codigo, string unidade, string urlImagem)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.codigo = codigo;
            this.unidade = unidade;
            this.urlImagem = urlImagem;
        }

        public Produto(int id, string nome, string descricao, string codigo, string unidade, string urlImagem)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.codigo = codigo;
            this.unidade = unidade;
            this.urlImagem = urlImagem;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Unidade { get => unidade; set => unidade = value; }
        public string UrlImagem { get => urlImagem; set => urlImagem = value; }
    }
}
