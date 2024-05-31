using ControleEstoque.Classes;
using ControleEstoque.Repository.ProdutoRepository;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormProduct : Form
    {
        private bool validSubmit = false;
        private ProductRepository produtoRepository = new ProductRepository();
        private Product product;

        internal Product Produto { get => product; set => product = value; }

        public FormProduct(string title)
        {
            InitializeComponent();

            labelTitle.Text = title;
            Text = title;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Abrir um FileDialog para permitir a seleção da imagem com os formatos abaixo.
            openFileDialogSelectImage.Filter = "PNG|*.png;|JPG|*.jpg;|JPEG|*.jpeg";

            // Se a imagem for selecionada o pictureBox deve ter o imageLocation atualizado e 
            // a textboxUrlImagem deve ser seu text alterado
            if (openFileDialogSelectImage.ShowDialog() == DialogResult.OK)
            {
                textBoxUrlImage.Text = openFileDialogSelectImage.FileName;
                pictureBoxImage.ImageLocation = openFileDialogSelectImage.FileName;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Caso o botão cancelar for pressionado a tela deve ser fechada.
            // Como ela sempre é aberta como um Dialog devemos retornar um "OK".
            DialogResult = DialogResult.OK;
        }

        private void clearFields()
        {
            if (product != null)
            {
                textBoxCod.Text = product.Cod;
                textBoxName.Text = product.Name;
                textBoxDescription.Text = product.Description;
                textBoxUnit.Text = product.Unit;
                textBoxUrlImage.Text = product.UrlImage;
                pictureBoxImage.ImageLocation = product.UrlImage;
                validarFormulario();
            }
            else
            {
                textBoxCod.Clear();
                textBoxName.Clear();
                textBoxDescription.Clear();
                textBoxUnit.Clear();
                textBoxUrlImage.Clear();
                pictureBoxImage.ImageLocation = "";
            }
            pictureBoxImage.Refresh();
            errorProvider1.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void validarFormulario()
        {
            if (textBoxName.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxName, "Entre com um nome");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxName, "");
                validSubmit = true;
            }
            if (textBoxUnit.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxUnit, "Entre com uma unidade");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxUnit, "");
                validSubmit = true;
            }
        }

        private bool isNamePresentInDatabase()
        {
            // A variável "product" representa um produto enviado para este formulário para
            // ser alterado.
            //
            // Começamos verificando se o nome digitado é igual ao nome original
            // deste produto, caso se trate de uma alteração, lembrando que devemos verificar
            // primeiro se o "product" não é nulo para evitar "NullPointer".
            //
            // Caso este seja o caso não há necessidade de prosseguir com a verificação,
            // pois o nome realmente constara como igual na base de dados e será modificado sem
            // problemas com o "update" do sql.
            if (product != null && product.Name.ToUpper().Equals(textBoxName.Text.ToUpper()))
            {
                return false;
            }

            // Realiza uma pesquisa com o nome inserido na "textBoxName" e atribui o retorno
            // para uma variável com o nome 
            Product productSearched = produtoRepository.GetProductByName(textBoxName.Text);

            // Caso algum produto seja retornado da pesquisa, então temos o nome já cadastrado
            // na base de dados, resta verificar se estamos alterando um produto, pois neste caso o 
            // nome igual realmente aparecerá no banco de dados, mas ele será alterado com o
            // "update", portanto não haverá problemas
            if (productSearched != null)
            {
                if (textBoxName.Text.ToUpper().Equals(productSearched.Name.ToUpper()))
                {
                    MessageBox.Show(
                        "Nome já cadastrado para outro produto. Insira um novo nome e tente novamente",
                        "Nome já cadastrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    errorProvider1.SetError(textBoxName, "Nome já em uso");
                    return true;
                }
            }
            // Caso a pesquisa no banco de dados retorne "null" não temos o nome cadastrado na
            // base de dados, portanto temos um retorno como "false"
            return false;
        }

        private Product prepareProductForUpdate()
        {
            // Criamos um novo produto com os dados do formulário e o id do produto
            // a ser alterado (retirado da variável "product")
            Product modifiedProduct = new Product(
                product.Id,
                textBoxName.Text,
                textBoxDescription.Text,
                textBoxCod.Text,
                textBoxUnit.Text,
                textBoxUrlImage.Text
                );

            // Criamos o caminho onde a imagem deve ser salva dentro da pasta do sistema. 
            string newUrlImage = "C:/Controle de Estoque/Imagens/" + modifiedProduct.Name + Path.GetExtension(modifiedProduct.UrlImage);

            // Verificamos se a nova imagem definida é diferente da anterior
            if(modifiedProduct.UrlImage != product.UrlImage)
            {
                // Verificamos se a nova imagem de fato existe
                if (File.Exists(modifiedProduct.UrlImage))
                {
                    // Caso o produto já apresente uma imagem cadastrada efetuamos o delete
                    if (product.UrlImage.Length > 0)
                    {
                        if (File.Exists(product.UrlImage))
                        {
                            File.Delete(product.UrlImage);
                        }
                    }
                    
                    // E copiamos a nova imagem
                    File.Copy(Path.GetFullPath(modifiedProduct.UrlImage), newUrlImage);
                }
                // Caso a nova imagem não possa ser encontrada não será efetuada alteração na
                // imagem do produto e o processo de alteração será cancelado.
                else
                {
                    MessageBox.Show(
                        "Arquivo de imagem especificado não encontrado, selecione um novo arquivo e tente novamente.",
                        "Erro ao salvar imagem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
            }
            
            

            // Caso tudo tenha ido bem alteramos o caminho da imagem do produto para a nova url.
            modifiedProduct.UrlImage = newUrlImage;

            // E retornamos o produto com os dados para update.
            return modifiedProduct;
        }

        private Product prepareNewProductForInsert()
        {
            // Criamos o novo produto sem nenhum id, mas com todos os dados do formulário.
            Product newProduct = new Product(
                textBoxName.Text,
                textBoxDescription.Text,
                textBoxCod.Text,
                textBoxUnit.Text,
                textBoxUrlImage.Text
                );

            // Criamos a nova url onde será salva a imagem na pasta do sistema.
            string newUrlImage = "C:/Controle de Estoque/Imagens/" + newProduct.Name + Path.GetExtension(newProduct.UrlImage);

            try
            {
                // Verificamos se a imagem definida pelo usuário existe.
                if (File.Exists(newProduct.UrlImage))
                {
                    // Realiza a cópia da imagem para a pasta do sistema.
                    File.Copy(Path.GetFullPath(newProduct.UrlImage), newUrlImage);
                }
                // Caso a imagem não seja encontrada no computador uma mensagem é exibida e
                // a ação é cancelada sem cadastrar o produto no banco de dados.
                else
                {
                    MessageBox.Show(
                        "Arquivo de imagem especificado não encontrado, selecione um novo arquivo e tente novamente.",
                        "Erro ao salvar imagem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(
                    "Erro inesperado. Contate o administrador do sistema. \n \n Erro: FP-PNPFI",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Realizamos a atualização do local da imagem para a nova url onde foi
            // salva na pasta do sistema
            newProduct.UrlImage = newUrlImage;

            return newProduct;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Verificar se o formulário está valido por meio da variável "validSubmit" e, caso não
            // esteja, retorna uma mensagem de erro, realiza a validação do formulário novamente
            // para ativar o "errorprovider" caso ele não esteja sendo exibido e executa
            // o return para parar a execução do "Save"
            if (!validSubmit)
            {
                MessageBox.Show(
                    "Preencha os campos requisitados e tente novamente!",
                    "Erros encontrados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                validarFormulario();
                return;
            }

            // Verificar se o nome já está cadastrado na base de dados.
            if (isNamePresentInDatabase())
            {
                return;
            }

            // Verifica se "product" é nulo, caso não seja estamos lidando com a alteração
            // de um produto já existente
            if (product != null)
            {
                Product modifiedProduct = prepareProductForUpdate();

                if (modifiedProduct != null && produtoRepository.UpdateProduct(modifiedProduct))
                {
                    MessageBox.Show(
                        "Produto alterado com sucesso!",
                        "Alteração Efetuada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                    DialogResult = DialogResult.OK;
                } else
                {
                    MessageBox.Show(
                        "Erro ao alterar produto. \n \n FP-BTNSVModP",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            // Se "product" for nulo, então temos um novo produto para ser cadastrado.
            else
            {
                Product newProduct = prepareNewProductForInsert();

                // O produto é inserido na base de dados
                if (newProduct!= null && produtoRepository.InsertProduto(newProduct))
                {
                    MessageBox.Show(
                        "Produto cadastrado com sucesso!", 
                        "Cadastro Efetuado", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation
                        );
                    // Questiona o usuário se deseja cadastrar um novo produto
                    DialogResult result = MessageBox.Show(
                        "Deseja cadastrar um novo produto?", 
                        "Novo Cadastro", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question
                        );

                    // Realiza a limpeza do formulário caso a resposta seja sim
                    if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        clearFields();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Erro ao cadastrar produto. \n \n FP-BTNSVNewP",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        private void textBoxName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxName.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxName, "Entre com um nome");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxName, "");
                validSubmit = true;
            }
        }

        private void textBoxUnit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxUnit.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxUnit, "Entre com uma unidade");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxUnit, "");
                validSubmit = true;
            }
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            // Quando o formulário for carregado o sistema irá utilizar o método "clearFields" que
            // limpará os campos ou adicionará os dados do produto a ser alterado.
            // Esse método só será executado quando o produto não for nulo, pois caso contrário os
            // campos já estarão limpos. Isso visa diminuir o tempo de processamento.
            if (product != null)
            {
                clearFields();
            }
        }

        private void textBoxUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificação de equals para as teclas Left, Up, Down, Rigth e Backspace
            bool leftKey = e.KeyChar.Equals(Keys.Left);
            bool rigthKey = e.KeyChar.Equals(Keys.Right);
            bool upKey = e.KeyChar.Equals(Keys.Up);
            bool downKey = e.KeyChar.Equals(Keys.Down);

            // Por algum motivo o backspace tem que ser convertido para char antes
            // do equals, ou então ele gerara um false para o backspace
            bool backspace = e.KeyChar.Equals(Convert.ToChar(Keys.Back));

            // Verificando se nenhuma das teclas acima foi pressionada
            if (!upKey && !downKey && !leftKey && !rigthKey && !backspace)
            {
                // Fazendo a verificação do regex para ver se algo que não é uma letra
                // minúscula ou maiúscula foi pressionada
                if (Regex.Match(e.KeyChar.ToString(), "[^a-zA-Z]").Success)
                {
                    // Cancelando o evento de KeyPress caso encontre
                    e.Handled = true;
                }
            }

        }

        private void pictureBoxImage_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                Console.WriteLine(e.Error.ToString());
                Console.WriteLine(e.Error.StackTrace);
            }
        }
    }
}
