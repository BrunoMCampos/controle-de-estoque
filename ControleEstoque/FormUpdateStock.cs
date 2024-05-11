using ControleEstoque.Classes;
using ControleEstoque.Repository;
using System;
using System.Windows.Forms;

namespace ControleEstoque
{
    public partial class FormUpdateStock : Form
    {
        private EnumMovementType movementType;
        private bool isValidForm = false;
        private StockUpdateRecordRepository updateStockRepository = new StockUpdateRecordRepository();
        private StockItem stockItem;

        public FormUpdateStock(string formTitle, EnumMovementType movementType, StockItem stockItem)
        {
            InitializeComponent();
            this.Text = formTitle;
            this.movementType = movementType;
            this.stockItem = stockItem;
        }

        private void FormAlterarEstoque_Load(object sender, EventArgs e)
        {
            this.textBoxSaldoAtual.Text = stockItem.StockAmount.ToString();
            if(movementType == EnumMovementType.Add)
            {
                this.textBoxMovimentacao.Text = "Adicionar";
            } else
            {
                this.textBoxMovimentacao.Text = "Subtrair";
            }
            this.textBoxQuantidade.Text = "0";

            calcularNovoSaldo();

            definindoComboBoxMotivo();
        }

        private void definindoComboBoxMotivo()
        {
            this.comboBoxMotivo.Items.Clear();
            this.comboBoxMotivo.Items.Add("Selecione um Motivo");
            if (movementType == EnumMovementType.Subtract)
            {
                this.comboBoxMotivo.Items.Add("Consumo por Produção");
                this.comboBoxMotivo.Items.Add("Correção de Estoque");
            }
            else if (movementType == EnumMovementType.Add)
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
                double saldoAtualDouble = Double.Parse(stockItem.StockAmount.ToString());
                double quantidadeDouble = Double.Parse(textBoxQuantidade.Text);
                double novoSaldoDouble = 0;
                if (movementType == EnumMovementType.Add)
                {
                    novoSaldoDouble = saldoAtualDouble + quantidadeDouble;
                }
                else if (movementType == EnumMovementType.Subtract)
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
                isValidForm = false;
            }
            else
            {
                errorProvider1.SetError(textBoxQuantidade, "");
                isValidForm = true;
            }

            if (comboBoxMotivo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxMotivo, "Entre com um motivo para a movimentação");
                isValidForm = false;
            }
            else
            {
                errorProvider1.SetError(comboBoxMotivo, "");
                isValidForm = true;
            }

            return isValidForm;
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

                        StockUpdateRecord alteracaoEstoque = new StockUpdateRecord(
                            stockItem,
                            saldoAtualDouble,
                            this.movementType,
                            quantidadeDouble,
                            novoSaldoDouble,
                            comboBoxMotivo.Text,
                            textBoxJustificativa.Text,
                            DateTime.Now);

                        if (updateStockRepository.InsertStockUpdateRecord(alteracaoEstoque))
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

                    StockUpdateRecord alteracaoEstoque = new StockUpdateRecord(
                        stockItem,
                        saldoAtualDouble,
                        this.movementType,
                        quantidadeDouble,
                        novoSaldoDouble,
                        comboBoxMotivo.Text,
                        textBoxJustificativa.Text,
                        DateTime.Now);

                    if (updateStockRepository.InsertStockUpdateRecord(alteracaoEstoque))
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
                isValidForm = false;
            }
            else
            {
                errorProvider1.SetError(textBoxQuantidade, "");
                isValidForm = true;
            }
            calcularNovoSaldo();
        }

        private void comboBoxMotivo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (comboBoxMotivo.SelectedIndex == 0)
            {
                errorProvider1.SetError(comboBoxMotivo, "Entre com um motivo para a movimentação");
                isValidForm = false;
            }
            else
            {
                errorProvider1.SetError(comboBoxMotivo, "");
                isValidForm = true;
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
