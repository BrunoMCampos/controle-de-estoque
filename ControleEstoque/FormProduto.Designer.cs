namespace ControleEstoque
{
    partial class FormProduto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.textBoxUnidade = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxUrlImagem = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.labelUrlImagem = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelUnidade = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.openFileDialogSelectImage = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.pictureBoxImagem);
            this.panel1.Controls.Add(this.textBoxDescricao);
            this.panel1.Controls.Add(this.textBoxUnidade);
            this.panel1.Controls.Add(this.textBoxNome);
            this.panel1.Controls.Add(this.textBoxUrlImagem);
            this.panel1.Controls.Add(this.textBoxCodigo);
            this.panel1.Controls.Add(this.labelUrlImagem);
            this.panel1.Controls.Add(this.labelCodigo);
            this.panel1.Controls.Add(this.labelUnidade);
            this.panel1.Controls.Add(this.labelDescricao);
            this.panel1.Controls.Add(this.labelNome);
            this.panel1.Controls.Add(this.buttonSalvar);
            this.panel1.Controls.Add(this.buttonLimpar);
            this.panel1.Controls.Add(this.buttonCancelar);
            this.panel1.Location = new System.Drawing.Point(12, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 419);
            this.panel1.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(300, 148);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(84, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Procurar";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImagem.Location = new System.Drawing.Point(21, 176);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(363, 201);
            this.pictureBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImagem.TabIndex = 2;
            this.pictureBoxImagem.TabStop = false;
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(71, 55);
            this.textBoxDescricao.MaxLength = 255;
            this.textBoxDescricao.Multiline = true;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(304, 63);
            this.textBoxDescricao.TabIndex = 2;
            // 
            // textBoxUnidade
            // 
            this.textBoxUnidade.Location = new System.Drawing.Point(71, 124);
            this.textBoxUnidade.MaxLength = 25;
            this.textBoxUnidade.Name = "textBoxUnidade";
            this.textBoxUnidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxUnidade.TabIndex = 3;
            this.textBoxUnidade.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxUnidade_Validating);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(71, 29);
            this.textBoxNome.MaxLength = 64;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(304, 20);
            this.textBoxNome.TabIndex = 1;
            this.textBoxNome.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNome_Validating);
            // 
            // textBoxUrlImagem
            // 
            this.textBoxUrlImagem.Enabled = false;
            this.textBoxUrlImagem.Location = new System.Drawing.Point(71, 150);
            this.textBoxUrlImagem.MaxLength = 523;
            this.textBoxUrlImagem.Name = "textBoxUrlImagem";
            this.textBoxUrlImagem.Size = new System.Drawing.Size(222, 20);
            this.textBoxUrlImagem.TabIndex = 0;
            this.textBoxUrlImagem.TabStop = false;
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Location = new System.Drawing.Point(71, 3);
            this.textBoxCodigo.MaxLength = 64;
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(138, 20);
            this.textBoxCodigo.TabIndex = 0;
            // 
            // labelUrlImagem
            // 
            this.labelUrlImagem.AutoSize = true;
            this.labelUrlImagem.Location = new System.Drawing.Point(18, 153);
            this.labelUrlImagem.Name = "labelUrlImagem";
            this.labelUrlImagem.Size = new System.Drawing.Size(47, 13);
            this.labelUrlImagem.TabIndex = 1;
            this.labelUrlImagem.Text = "Imagem:";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(22, 6);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(43, 13);
            this.labelCodigo.TabIndex = 1;
            this.labelCodigo.Text = "Código:";
            // 
            // labelUnidade
            // 
            this.labelUnidade.AutoSize = true;
            this.labelUnidade.Location = new System.Drawing.Point(15, 127);
            this.labelUnidade.Name = "labelUnidade";
            this.labelUnidade.Size = new System.Drawing.Size(50, 13);
            this.labelUnidade.TabIndex = 1;
            this.labelUnidade.Text = "Unidade:";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(7, 58);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(58, 13);
            this.labelDescricao.TabIndex = 1;
            this.labelDescricao.Text = "Descrição:";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(27, 32);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(38, 13);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome:";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(300, 383);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 7;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(168, 383);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpar.TabIndex = 6;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(21, 383);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTitulo);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 63);
            this.panel2.TabIndex = 1;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(65, 16);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(263, 33);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Adicionar Produto";
            // 
            // openFileDialogSelectImage
            // 
            this.openFileDialogSelectImage.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // FormAddProduto
            // 
            this.AcceptButton = this.buttonSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 509);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddProduto";
            this.ShowIcon = false;
            this.Text = "Adicionar Produto";
            this.Load += new System.EventHandler(this.FormAddProduto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelUrlImagem;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxUrlImagem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectImage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBoxUnidade;
        private System.Windows.Forms.Label labelUnidade;
    }
}