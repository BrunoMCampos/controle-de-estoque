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

        public Product(int id, string name, string unit)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
        }

        public Product(string name, string description, string cod, string unit, string urlImage)
        {
            this.name = name;
            this.description = description;
            this.cod = cod;
            this.unit = unit;
            this.urlImage = urlImage;
        }

        public Product(int id, string name, string description, string cod, string unit, string urlImage)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.cod = cod;
            this.unit = unit;
            this.urlImage = urlImage;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Cod { get => cod; set => cod = value; }
        public string Unit { get => unit; set => unit = value; }
        public string UrlImage { get => urlImage; set => urlImage = value; }
    }
}
