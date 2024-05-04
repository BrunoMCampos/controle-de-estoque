using ControleEstoque.Classes;
using ControleEstoque.Repository.ProdutoRepository;
using System;
using System.IO;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormProduto : Form
    {
        private bool validSubmit = false;
        private ProdutoRepository produtoRepository = new ProdutoRepository();

        private Produto produto;

        internal Produto Produto { get => produto; set => produto = value; }

        public FormProduto()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            openFileDialogSelectImage.Filter = "PNG|*.png|JPG|*.jpg|JPEG|*.jpeg";

            if (openFileDialogSelectImage.ShowDialog() == DialogResult.OK)
            {
                textBoxUrlImagem.Text = openFileDialogSelectImage.FileName;
                pictureBoxImagem.ImageLocation = openFileDialogSelectImage.FileName;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void clearFields()
        {
            if (produto != null)
            {
                textBoxCodigo.Text = produto.Codigo;
                textBoxNome.Text = produto.Nome;
                textBoxDescricao.Text = produto.Descricao;
                textBoxUnidade.Text = produto.Unidade;
                textBoxUrlImagem.Text = produto.UrlImagem;
                pictureBoxImagem.ImageLocation = produto.UrlImagem;
                validarFormulario();
            }
            else
            {
                textBoxCodigo.Clear();
                textBoxNome.Clear();
                textBoxDescricao.Clear();
                textBoxUnidade.Clear();
                textBoxUrlImagem.Clear();
                pictureBoxImagem.ImageLocation = "";
            }
            pictureBoxImagem.Refresh();
            errorProvider1.Clear();

        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void validarFormulario()
        {
            if (textBoxNome.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxNome, "Entre com um nome");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxNome, "");
                validSubmit = true;
            }
            if (textBoxUnidade.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxUnidade, "Entre com uma unidade");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxUnidade, "");
                validSubmit = true;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (validSubmit)
            {
                Produto produtoPesquisado = produtoRepository.GetProdutoByName(textBoxNome.Text);
                if (produtoPesquisado != null)
                {
                    if (produto == null && textBoxNome.Text.ToUpper().Equals(produtoPesquisado.Nome.ToUpper()))
                    {
                        MessageBox.Show("Nome já cadastrado para outro produto. Insira um novo nome e tente novamente", "Nome já cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider1.SetError(textBoxNome, "Nome já em uso");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha os campos requisitados e tente novamente!", "Erros encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validarFormulario();
                return;
            }
            if (produto != null)
            {
                Produto produtoAlterado = new Produto(
                    produto.Id,
                    textBoxNome.Text,
                    textBoxDescricao.Text,
                    textBoxCodigo.Text,
                    textBoxUnidade.Text,
                    textBoxUrlImagem.Text
                    );

                string novaUrlImagem = "../../Assets/Imagens/" + produtoAlterado.Nome + Path.GetExtension(produtoAlterado.UrlImagem);

                if(produto.UrlImagem.Length > 0)
                {
                    File.Delete(produto.UrlImagem);
                }
                if (File.Exists(produtoAlterado.UrlImagem))
                {
                    File.Copy(Path.GetFullPath(produtoAlterado.UrlImagem), novaUrlImagem);
                } else
                {
                    MessageBox.Show("Arquivo de imagem especificado não encontrado, selecione um novo arquivo e tente novamente.", "Erro ao salvar imagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                produtoAlterado.UrlImagem = novaUrlImagem;

                if (produtoRepository.AlterProduto(produtoAlterado))
                {
                    MessageBox.Show("Produto alterado com sucesso!", "Alteração Efetuada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult = DialogResult.OK;
                }

            }
            else
            {
                Produto produto = new Produto(
                    textBoxNome.Text,
                    textBoxDescricao.Text,
                    textBoxCodigo.Text,
                    textBoxUnidade.Text,
                    textBoxUrlImagem.Text
                    );

                string novaUrlImagem = "../../Assets/Imagens/" + produto.Nome + Path.GetExtension(produto.UrlImagem);

                try
                {
                    if (File.Exists(produto.UrlImagem))
                    {
                        File.Copy(Path.GetFullPath(produto.UrlImagem), novaUrlImagem);
                    }
                    else
                    {
                        MessageBox.Show("Arquivo de imagem especificado não encontrado, selecione um novo arquivo e tente novamente.", "Erro ao salvar imagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                produto.UrlImagem = novaUrlImagem;

                if (produtoRepository.InsertProduto(produto))
                {
                    MessageBox.Show("Produto cadastrado com sucesso!", "Cadastro Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult result = MessageBox.Show("Deseja cadastrar um novo produto?", "Novo Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        clearFields();
                    }
                }
            }
        }

        private void textBoxNome_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxNome.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxNome, "Entre com um nome");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxNome, "");
                validSubmit = true;
            }
        }

        private void textBoxUnidade_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxUnidade.Text.Length == 0)
            {
                errorProvider1.SetError(textBoxUnidade, "Entre com uma unidade");
                validSubmit = false;

            }
            else
            {
                errorProvider1.SetError(textBoxUnidade, "");
                validSubmit = true;
            }
        }

        private void FormAddProduto_Load(object sender, EventArgs e)
        {
            if (produto != null)
            {
                clearFields();
            }
        }
    }
}
