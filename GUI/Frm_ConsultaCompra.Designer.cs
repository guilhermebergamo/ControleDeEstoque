namespace GUI
{
    partial class Frm_ConsultaCompra
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
            this.DgvDados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbGeral = new System.Windows.Forms.RadioButton();
            this.rbParcelas = new System.Windows.Forms.RadioButton();
            this.rbFornecedor = new System.Windows.Forms.RadioButton();
            this.rbData = new System.Windows.Forms.RadioButton();
            this.pnFornecedor = new System.Windows.Forms.Panel();
            this.lbForNome = new System.Windows.Forms.Label();
            this.btLocalizarFornecedor = new System.Windows.Forms.Button();
            this.txtForCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnData = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtDataInicial = new System.Windows.Forms.DateTimePicker();
            this.btLocalizarData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnFornecedor.SuspendLayout();
            this.pnData.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvDados
            // 
            this.DgvDados.AllowUserToAddRows = false;
            this.DgvDados.AllowUserToDeleteRows = false;
            this.DgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvDados.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDados.Location = new System.Drawing.Point(12, 276);
            this.DgvDados.Name = "DgvDados";
            this.DgvDados.ReadOnly = true;
            this.DgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDados.Size = new System.Drawing.Size(1184, 279);
            this.DgvDados.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbGeral);
            this.groupBox1.Controls.Add(this.rbParcelas);
            this.groupBox1.Controls.Add(this.rbFornecedor);
            this.groupBox1.Controls.Add(this.rbData);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1184, 68);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar";
            // 
            // rbGeral
            // 
            this.rbGeral.AutoSize = true;
            this.rbGeral.Checked = true;
            this.rbGeral.Location = new System.Drawing.Point(54, 19);
            this.rbGeral.Name = "rbGeral";
            this.rbGeral.Size = new System.Drawing.Size(121, 17);
            this.rbGeral.TabIndex = 19;
            this.rbGeral.TabStop = true;
            this.rbGeral.Text = "Todas com compras";
            this.rbGeral.UseVisualStyleBackColor = true;
            this.rbGeral.CheckedChanged += new System.EventHandler(this.rbGeral_CheckedChanged_1);
            // 
            // rbParcelas
            // 
            this.rbParcelas.AutoSize = true;
            this.rbParcelas.Location = new System.Drawing.Point(1036, 19);
            this.rbParcelas.Name = "rbParcelas";
            this.rbParcelas.Size = new System.Drawing.Size(116, 17);
            this.rbParcelas.TabIndex = 18;
            this.rbParcelas.Text = "Parcelas em aberto";
            this.rbParcelas.UseVisualStyleBackColor = true;
            this.rbParcelas.CheckedChanged += new System.EventHandler(this.rbGeral_CheckedChanged_1);
            // 
            // rbFornecedor
            // 
            this.rbFornecedor.AutoSize = true;
            this.rbFornecedor.Location = new System.Drawing.Point(397, 19);
            this.rbFornecedor.Name = "rbFornecedor";
            this.rbFornecedor.Size = new System.Drawing.Size(79, 17);
            this.rbFornecedor.TabIndex = 16;
            this.rbFornecedor.Text = "Fornecedor";
            this.rbFornecedor.UseVisualStyleBackColor = true;
            this.rbFornecedor.CheckedChanged += new System.EventHandler(this.rbGeral_CheckedChanged_1);
            // 
            // rbData
            // 
            this.rbData.AutoSize = true;
            this.rbData.Location = new System.Drawing.Point(731, 19);
            this.rbData.Name = "rbData";
            this.rbData.Size = new System.Drawing.Size(101, 17);
            this.rbData.TabIndex = 17;
            this.rbData.Text = "Data da compra";
            this.rbData.UseVisualStyleBackColor = true;
            this.rbData.CheckedChanged += new System.EventHandler(this.rbGeral_CheckedChanged_1);
            // 
            // pnFornecedor
            // 
            this.pnFornecedor.Controls.Add(this.lbForNome);
            this.pnFornecedor.Controls.Add(this.btLocalizarFornecedor);
            this.pnFornecedor.Controls.Add(this.txtForCodigo);
            this.pnFornecedor.Controls.Add(this.label2);
            this.pnFornecedor.Location = new System.Drawing.Point(12, 76);
            this.pnFornecedor.Name = "pnFornecedor";
            this.pnFornecedor.Size = new System.Drawing.Size(270, 62);
            this.pnFornecedor.TabIndex = 23;
            // 
            // lbForNome
            // 
            this.lbForNome.AutoSize = true;
            this.lbForNome.Location = new System.Drawing.Point(4, 40);
            this.lbForNome.Name = "lbForNome";
            this.lbForNome.Size = new System.Drawing.Size(107, 13);
            this.lbForNome.TabIndex = 3;
            this.lbForNome.Text = "Nome do Fornecedor";
            // 
            // btLocalizarFornecedor
            // 
            this.btLocalizarFornecedor.Location = new System.Drawing.Point(119, 20);
            this.btLocalizarFornecedor.Name = "btLocalizarFornecedor";
            this.btLocalizarFornecedor.Size = new System.Drawing.Size(124, 20);
            this.btLocalizarFornecedor.TabIndex = 2;
            this.btLocalizarFornecedor.Text = "Localizar Fornecedor";
            this.btLocalizarFornecedor.UseVisualStyleBackColor = true;
            this.btLocalizarFornecedor.Click += new System.EventHandler(this.btLocalizarFornecedor_Click);
            // 
            // txtForCodigo
            // 
            this.txtForCodigo.Enabled = false;
            this.txtForCodigo.Location = new System.Drawing.Point(4, 20);
            this.txtForCodigo.Name = "txtForCodigo";
            this.txtForCodigo.Size = new System.Drawing.Size(109, 20);
            this.txtForCodigo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código do fornecedor";
            // 
            // pnData
            // 
            this.pnData.Controls.Add(this.label3);
            this.pnData.Controls.Add(this.dtDataFinal);
            this.pnData.Controls.Add(this.dtDataInicial);
            this.pnData.Controls.Add(this.btLocalizarData);
            this.pnData.Controls.Add(this.label4);
            this.pnData.Location = new System.Drawing.Point(12, 144);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(554, 62);
            this.pnData.TabIndex = 24;
            this.pnData.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Data Final";
            // 
            // dtDataFinal
            // 
            this.dtDataFinal.Location = new System.Drawing.Point(253, 20);
            this.dtDataFinal.Name = "dtDataFinal";
            this.dtDataFinal.Size = new System.Drawing.Size(227, 20);
            this.dtDataFinal.TabIndex = 26;
            // 
            // dtDataInicial
            // 
            this.dtDataInicial.Location = new System.Drawing.Point(3, 20);
            this.dtDataInicial.Name = "dtDataInicial";
            this.dtDataInicial.Size = new System.Drawing.Size(227, 20);
            this.dtDataInicial.TabIndex = 25;
            // 
            // btLocalizarData
            // 
            this.btLocalizarData.Location = new System.Drawing.Point(486, 20);
            this.btLocalizarData.Name = "btLocalizarData";
            this.btLocalizarData.Size = new System.Drawing.Size(62, 20);
            this.btLocalizarData.TabIndex = 2;
            this.btLocalizarData.Text = "Localizar";
            this.btLocalizarData.UseVisualStyleBackColor = true;
            this.btLocalizarData.Click += new System.EventHandler(this.btLocalizarData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data Inicial";
            // 
            // Frm_ConsultaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1208, 565);
            this.Controls.Add(this.pnData);
            this.Controls.Add(this.pnFornecedor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvDados);
            this.Name = "Frm_ConsultaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Compras";
            this.Load += new System.EventHandler(this.Frm_ConsultaCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFornecedor.ResumeLayout(false);
            this.pnFornecedor.PerformLayout();
            this.pnData.ResumeLayout(false);
            this.pnData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvDados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFornecedor;
        private System.Windows.Forms.RadioButton rbData;
        private System.Windows.Forms.RadioButton rbGeral;
        private System.Windows.Forms.RadioButton rbParcelas;
        private System.Windows.Forms.Panel pnFornecedor;
        private System.Windows.Forms.Button btLocalizarFornecedor;
        private System.Windows.Forms.TextBox txtForCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbForNome;
        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.Button btLocalizarData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDataInicial;
        private System.Windows.Forms.DateTimePicker dtDataFinal;
        private System.Windows.Forms.Label label3;
    }
}