namespace ControleEstoque
{
    partial class FormAlterarEstoque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxMotivo = new System.Windows.Forms.ComboBox();
            this.textBoxJustificativa = new System.Windows.Forms.TextBox();
            this.textBoxNovoSaldo = new System.Windows.Forms.TextBox();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.textBoxMovimentacao = new System.Windows.Forms.TextBox();
            this.textBoxSaldoAtual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrincipal.AutoSize = true;
            this.panelPrincipal.Controls.Add(this.buttonCancelar);
            this.panelPrincipal.Controls.Add(this.buttonSalvar);
            this.panelPrincipal.Controls.Add(this.comboBoxMotivo);
            this.panelPrincipal.Controls.Add(this.textBoxJustificativa);
            this.panelPrincipal.Controls.Add(this.textBoxNovoSaldo);
            this.panelPrincipal.Controls.Add(this.textBoxQuantidade);
            this.panelPrincipal.Controls.Add(this.textBoxMovimentacao);
            this.panelPrincipal.Controls.Add(this.textBoxSaldoAtual);
            this.panelPrincipal.Controls.Add(this.label6);
            this.panelPrincipal.Controls.Add(this.label5);
            this.panelPrincipal.Controls.Add(this.label4);
            this.panelPrincipal.Controls.Add(this.label3);
            this.panelPrincipal.Controls.Add(this.label2);
            this.panelPrincipal.Controls.Add(this.label1);
            this.panelPrincipal.Location = new System.Drawing.Point(12, 12);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(293, 292);
            this.panelPrincipal.TabIndex = 0;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(7, 264);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(125, 23);
            this.buttonCancelar.TabIndex = 14;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(139, 264);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(125, 23);
            this.buttonSalvar.TabIndex = 13;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // comboBoxMotivo
            // 
            this.comboBoxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMotivo.FormattingEnabled = true;
            this.comboBoxMotivo.Location = new System.Drawing.Point(90, 148);
            this.comboBoxMotivo.Name = "comboBoxMotivo";
            this.comboBoxMotivo.Size = new System.Drawing.Size(174, 21);
            this.comboBoxMotivo.TabIndex = 12;
            this.comboBoxMotivo.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxMotivo_Validating);
            // 
            // textBoxJustificativa
            // 
            this.textBoxJustificativa.Location = new System.Drawing.Point(90, 181);
            this.textBoxJustificativa.Margin = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.textBoxJustificativa.Multiline = true;
            this.textBoxJustificativa.Name = "textBoxJustificativa";
            this.textBoxJustificativa.Size = new System.Drawing.Size(174, 70);
            this.textBoxJustificativa.TabIndex = 11;
            // 
            // textBoxNovoSaldo
            // 
            this.textBoxNovoSaldo.Enabled = false;
            this.textBoxNovoSaldo.Location = new System.Drawing.Point(90, 115);
            this.textBoxNovoSaldo.Name = "textBoxNovoSaldo";
            this.textBoxNovoSaldo.Size = new System.Drawing.Size(100, 20);
            this.textBoxNovoSaldo.TabIndex = 9;
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(90, 82);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantidade.TabIndex = 8;
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantidade_KeyPress);
            this.textBoxQuantidade.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxQuantidade_Validating);
            // 
            // textBoxMovimentacao
            // 
            this.textBoxMovimentacao.Enabled = false;
            this.textBoxMovimentacao.Location = new System.Drawing.Point(90, 49);
            this.textBoxMovimentacao.Name = "textBoxMovimentacao";
            this.textBoxMovimentacao.Size = new System.Drawing.Size(100, 20);
            this.textBoxMovimentacao.TabIndex = 7;
            // 
            // textBoxSaldoAtual
            // 
            this.textBoxSaldoAtual.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSaldoAtual.Enabled = false;
            this.textBoxSaldoAtual.Location = new System.Drawing.Point(90, 16);
            this.textBoxSaldoAtual.Name = "textBoxSaldoAtual";
            this.textBoxSaldoAtual.Size = new System.Drawing.Size(102, 20);
            this.textBoxSaldoAtual.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Justificativa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Motivo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Novo Saldo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Movimentação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Atual:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormAlterarEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 313);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FormAlterarEstoque";
            this.ShowIcon = false;
            this.Text = "QuantidadeEstoque";
            this.Load += new System.EventHandler(this.FormAlterarEstoque_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxJustificativa;
        private System.Windows.Forms.TextBox textBoxNovoSaldo;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.TextBox textBoxMovimentacao;
        private System.Windows.Forms.TextBox textBoxSaldoAtual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMotivo;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}