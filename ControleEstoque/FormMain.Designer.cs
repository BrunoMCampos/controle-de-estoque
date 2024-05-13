namespace ControleEstoque
{
    partial class FormMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonSubtractStock = new System.Windows.Forms.Button();
            this.buttonAddStock = new System.Windows.Forms.Button();
            this.buttonUpdateProduct = new System.Windows.Forms.Button();
            this.checkBoxOnlyPositive = new System.Windows.Forms.CheckBox();
            this.buttonUpdateTable = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.buttonStockUpdateRecords = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonStockUpdateRecords);
            this.panel1.Controls.Add(this.buttonDeleteProduct);
            this.panel1.Controls.Add(this.buttonSubtractStock);
            this.panel1.Controls.Add(this.buttonAddStock);
            this.panel1.Controls.Add(this.buttonUpdateProduct);
            this.panel1.Controls.Add(this.checkBoxOnlyPositive);
            this.panel1.Controls.Add(this.buttonUpdateTable);
            this.panel1.Controls.Add(this.buttonAddProduct);
            this.panel1.Location = new System.Drawing.Point(655, 232);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(300, 287);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(152, 5);
            this.buttonDeleteProduct.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(138, 23);
            this.buttonDeleteProduct.TabIndex = 5;
            this.buttonDeleteProduct.Text = "Excluir Produto";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // buttonSubtractStock
            // 
            this.buttonSubtractStock.Location = new System.Drawing.Point(152, 31);
            this.buttonSubtractStock.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.buttonSubtractStock.Name = "buttonSubtractStock";
            this.buttonSubtractStock.Size = new System.Drawing.Size(138, 23);
            this.buttonSubtractStock.TabIndex = 4;
            this.buttonSubtractStock.Text = "Diminuir Estoque";
            this.buttonSubtractStock.UseVisualStyleBackColor = true;
            this.buttonSubtractStock.Click += new System.EventHandler(this.buttonSubtractStock_Click);
            // 
            // buttonAddStock
            // 
            this.buttonAddStock.Location = new System.Drawing.Point(5, 57);
            this.buttonAddStock.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.buttonAddStock.Name = "buttonAddStock";
            this.buttonAddStock.Size = new System.Drawing.Size(138, 23);
            this.buttonAddStock.TabIndex = 3;
            this.buttonAddStock.Text = "Aumentar Estoque";
            this.buttonAddStock.UseVisualStyleBackColor = true;
            this.buttonAddStock.Click += new System.EventHandler(this.buttonAddStock_Click);
            // 
            // buttonUpdateProduct
            // 
            this.buttonUpdateProduct.Location = new System.Drawing.Point(5, 31);
            this.buttonUpdateProduct.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.buttonUpdateProduct.Name = "buttonUpdateProduct";
            this.buttonUpdateProduct.Size = new System.Drawing.Size(138, 23);
            this.buttonUpdateProduct.TabIndex = 2;
            this.buttonUpdateProduct.Text = "Alterar Produto";
            this.buttonUpdateProduct.UseVisualStyleBackColor = true;
            this.buttonUpdateProduct.Click += new System.EventHandler(this.buttonUpdateProduct_Click);
            // 
            // checkBoxOnlyPositive
            // 
            this.checkBoxOnlyPositive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxOnlyPositive.AutoSize = true;
            this.checkBoxOnlyPositive.Location = new System.Drawing.Point(18, 260);
            this.checkBoxOnlyPositive.Name = "checkBoxOnlyPositive";
            this.checkBoxOnlyPositive.Size = new System.Drawing.Size(269, 17);
            this.checkBoxOnlyPositive.TabIndex = 1;
            this.checkBoxOnlyPositive.Text = "Mostrar Apenas Produtos com Estoque Maior que 0";
            this.checkBoxOnlyPositive.UseVisualStyleBackColor = true;
            this.checkBoxOnlyPositive.CheckedChanged += new System.EventHandler(this.checkBoxOnlyPositive_CheckedChanged);
            // 
            // buttonUpdateTable
            // 
            this.buttonUpdateTable.Location = new System.Drawing.Point(5, 5);
            this.buttonUpdateTable.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.buttonUpdateTable.Name = "buttonUpdateTable";
            this.buttonUpdateTable.Size = new System.Drawing.Size(138, 23);
            this.buttonUpdateTable.TabIndex = 0;
            this.buttonUpdateTable.Text = "Atualizar Tabela";
            this.buttonUpdateTable.UseVisualStyleBackColor = true;
            this.buttonUpdateTable.Click += new System.EventHandler(this.buttonUpdateTable_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(152, 57);
            this.buttonAddProduct.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(138, 23);
            this.buttonAddProduct.TabIndex = 0;
            this.buttonAddProduct.Text = "Adicionar Produto";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dataGridViewStock);
            this.panel2.Location = new System.Drawing.Point(12, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 456);
            this.panel2.TabIndex = 0;
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToAddRows = false;
            this.dataGridViewStock.AllowUserToDeleteRows = false;
            this.dataGridViewStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStock.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStock.MultiSelect = false;
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.ReadOnly = true;
            this.dataGridViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStock.Size = new System.Drawing.Size(637, 456);
            this.dataGridViewStock.TabIndex = 0;
            this.dataGridViewStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStock_CellContentClick_1);
            this.dataGridViewStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEstoque_CellDoubleClick);
            this.dataGridViewStock.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEstoque_CellMouseClick);
            this.dataGridViewStock.SelectionChanged += new System.EventHandler(this.dataGridViewStock_SelectionChanged);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(658, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(297, 214);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBoxProductName);
            this.panel3.Controls.Add(this.labelProductName);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(639, 42);
            this.panel3.TabIndex = 2;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(118, 10);
            this.textBoxProductName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(509, 20);
            this.textBoxProductName.TabIndex = 1;
            this.textBoxProductName.TextChanged += new System.EventHandler(this.textBoxProductName_TextChanged);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(20, 13);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(93, 13);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Nome do Produto:";
            // 
            // buttonStockUpdateRecords
            // 
            this.buttonStockUpdateRecords.Location = new System.Drawing.Point(5, 86);
            this.buttonStockUpdateRecords.Name = "buttonStockUpdateRecords";
            this.buttonStockUpdateRecords.Size = new System.Drawing.Size(285, 23);
            this.buttonStockUpdateRecords.TabIndex = 6;
            this.buttonStockUpdateRecords.Text = "Registro de Alterações de Estoque";
            this.buttonStockUpdateRecords.UseVisualStyleBackColor = true;
            this.buttonStockUpdateRecords.Click += new System.EventHandler(this.buttonStockUpdateRecords_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 526);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(981, 565);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Controle de Estoque";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonUpdateTable;
        private System.Windows.Forms.CheckBox checkBoxOnlyPositive;
        private System.Windows.Forms.Button buttonUpdateProduct;
        private System.Windows.Forms.Button buttonAddStock;
        private System.Windows.Forms.Button buttonSubtractStock;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Button buttonStockUpdateRecords;
    }
}