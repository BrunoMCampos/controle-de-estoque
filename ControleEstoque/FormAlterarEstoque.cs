using ControleEstoque.Classes;
using ControleEstoque.Repository;
using System;
using System.Windows.Forms;

namespace ControleEstoque
{
    

    public partial class FormAlterarEstoque : Form
    {
        private EnumMovementType movimentacao;
        private bool formValido = false;
        private AlteracaoEstoqueRepository alteracaoEstoqueRepository = new AlteracaoEstoqueRepository();
        private ItemEstoque itemEstoque;

        public FormAlterarEstoque(string tituloForm, EnumMovementType movimentacao, ItemEstoque itemEstoque)
        {
            InitializeComponent();
            this.Text = tituloForm;
            this.movimentacao = movimentacao;
            this.itemEstoque = itemEstoque;
        }

        private void FormAlterarEstoque_Load(object sender, EventArgs e)
        {
            this.textBoxSaldoAtual.Text = itemEstoque.QuantidadeEstoque.ToString();
            this.textBoxMovimentacao.Text = movimentacao.ToString();
            this.textBoxQuantidade.Text = "0";

            calcularNovoSaldo();

            definindoComboBoxMotivo();
        }

        private void definindoComboBoxMotivo()
        {
            this.comboBoxMotivo.Items.Clear();
            this.comboBoxMotivo.Items.Add("Selecione um Motivo");
            if (movimentacao == EnumMovementType.Subtract)
            {
                this.comboBoxMotivo.Items.Add("Consumo por Produção");
                this.comboBoxMotivo.Items.Add("Correção de Estoque");
            }
            else if (movimentacao == EnumMovementType.Add)
            {
                this.comboBoxMotivo.Items.Add("Compra");
                this.comboBoxMotivo.Items.Add("Correção de Estoque");
            }
            this.comboBoxMotivo.SelectedIndex = 0;
        }

        private void calcularNovoSaldo()
        {
            try
            {
                double saldoAtualDouble = Double.Parse(itemEstoque.QuantidadeEstoque.ToString());
                double quantidadeDouble = Double.Parse(textBoxQuantidade.Text);
                double novoSaldoDouble = 0;
                if (movimentacao == EnumMovementType.Add)
                {
                    novoSaldoDouble = saldoAtualDouble + quantidadeDouble;
                }
                else if (movimentacao == EnumMovementType.Subtract)
                {
                    novoSaldoDouble = saldoAtualDouble - quantidadeDouble;
                }
                textBoxNovoSaldo.Text = novoSaldoDouble.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private bool validarFormulario()
        {
            if (textBoxQuantidade.TextLength == 0)
            {
                errorProvider1.SetError(textBoxQuantidade, "Entre com uma quantidade a ser movimentada");
                formValido = false;
            }
            else
            {
                errorProvider1.SetError(textBoxQuantidade, "");
                formValido = true;
            }

            if (comboBoxMotivo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxMotivo, "Entre com um motivo para a movimentação");
                formValido = false;
            }
            else
            {
                errorProvider1.SetError(comboBoxMotivo, "");
                formValido = true;
            }

            return formValido;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (!validarFormulario())
            {
                MessageBox.Show("Verifique os dados inseridos e tente novamente!", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double novoSaldoDouble = Double.Parse(textBoxNovoSaldo.Text);
                if (novoSaldoDouble < 0)
                {
                    DialogResult result = MessageBox.Show("Saldo final menor do que 0. Deseja continuar?", "Saldo Menor que 0", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        double saldoAtualDouble = Double.Parse(textBoxSaldoAtual.Text);
                        double quantidadeDouble = Double.Parse(textBoxQuantidade.Text);

                        AlteracaoEstoque alteracaoEstoque = new AlteracaoEstoque(
                            itemEstoque,
                            saldoAtualDouble,
                            this.movimentacao,
                            quantidadeDouble,
                            novoSaldoDouble,
                            comboBoxMotivo.Text,
                            textBoxJustificativa.Text);

                        if (alteracaoEstoqueRepository.InsertAlteracaoEstoque(alteracaoEstoque))
                        {
                            MessageBox.Show("Alteração realizada com sucesso!", "Alteração Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar o estoque, contate o administrador do sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    double saldoAtualDouble = Double.Parse(textBoxSaldoAtual.Text);
                    double quantidadeDouble = Double.Parse(textBoxQuantidade.Text);

                    AlteracaoEstoque alteracaoEstoque = new AlteracaoEstoque(
                        itemEstoque,
                        saldoAtualDouble,
                        this.movimentacao,
                        quantidadeDouble,
                        novoSaldoDouble,
                        comboBoxMotivo.Text,
                        textBoxJustificativa.Text);

                    if (alteracaoEstoqueRepository.InsertAlteracaoEstoque(alteracaoEstoque))
                    {
                        MessageBox.Show("Alteração realizada com sucesso!", "Alteração Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar o estoque, contate o administrador do sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void textBoxQuantidade_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxQuantidade.TextLength == 0)
            {
                errorProvider1.SetError(textBoxQuantidade, "Entre com uma quantidade a ser movimentada");
                formValido = false;
            }
            else
            {
                errorProvider1.SetError(textBoxQuantidade, "");
                formValido = true;
            }
            calcularNovoSaldo();
        }

        private void comboBoxMotivo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (comboBoxMotivo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxMotivo, "Entre com um motivo para a movimentação");
                formValido = false;
            }
            else
            {
                errorProvider1.SetError(comboBoxMotivo, "");
                formValido = true;
            }
            calcularNovoSaldo();
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
