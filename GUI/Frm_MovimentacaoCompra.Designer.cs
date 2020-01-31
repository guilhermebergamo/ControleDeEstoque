namespace GUI
{
    partial class Frm_MovimentacaoCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MovimentacaoCompra));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btInserir = new System.Windows.Forms.Button();
            this.pnDados = new System.Windows.Forms.Panel();
            this.pnFinalizaCompra = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btSalvarFinal = new System.Windows.Forms.Button();
            this.btCancelarFinal = new System.Windows.Forms.Button();
            this.lbTotaldaCompra = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvParcelas = new System.Windows.Forms.DataGridView();
            this.pco_cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pco_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pco_datavector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btAddProd = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lProduto = new System.Windows.Forms.Label();
            this.btLocalizarCodigo = new System.Windows.Forms.Button();
            this.txtProCod = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lFornecedor = new System.Windows.Forms.Label();
            this.btLocalizaFornecedor = new System.Windows.Forms.Button();
            this.txtForCod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DgvItens = new System.Windows.Forms.DataGridView();
            this.ProCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProUnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNParcelas = new System.Windows.Forms.ComboBox();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDataCompra = new System.Windows.Forms.DateTimePicker();
            this.txtNfiscal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.pnDados.SuspendLayout();
            this.pnFinalizaCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItens)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btSalvar);
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Controls.Add(this.btExcluir);
            this.panel2.Controls.Add(this.btLocalizar);
            this.panel2.Controls.Add(this.btAlterar);
            this.panel2.Controls.Add(this.btInserir);
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(-5, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 22);
            this.panel2.TabIndex = 2;
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btSalvar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.ForeColor = System.Drawing.Color.White;
            this.btSalvar.Location = new System.Drawing.Point(578, 1);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 21);
            this.btSalvar.TabIndex = 2;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Location = new System.Drawing.Point(692, 1);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 21);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btExcluir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.Color.White;
            this.btExcluir.Location = new System.Drawing.Point(436, 1);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 21);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btLocalizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLocalizar.ForeColor = System.Drawing.Color.White;
            this.btLocalizar.Location = new System.Drawing.Point(159, 1);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(75, 21);
            this.btLocalizar.TabIndex = 1;
            this.btLocalizar.Text = "Localizar";
            this.btLocalizar.UseVisualStyleBackColor = false;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btAlterar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAlterar.ForeColor = System.Drawing.Color.White;
            this.btAlterar.Location = new System.Drawing.Point(299, 1);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(75, 21);
            this.btAlterar.TabIndex = 3;
            this.btAlterar.Text = "Alterar";
            this.btAlterar.UseVisualStyleBackColor = false;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btInserir
            // 
            this.btInserir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btInserir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInserir.ForeColor = System.Drawing.Color.White;
            this.btInserir.Location = new System.Drawing.Point(17, 1);
            this.btInserir.Name = "btInserir";
            this.btInserir.Size = new System.Drawing.Size(75, 21);
            this.btInserir.TabIndex = 0;
            this.btInserir.Text = "Inserir";
            this.btInserir.UseVisualStyleBackColor = false;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // pnDados
            // 
            this.pnDados.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnDados.Controls.Add(this.pnFinalizaCompra);
            this.pnDados.Controls.Add(this.label15);
            this.pnDados.Controls.Add(this.label11);
            this.pnDados.Controls.Add(this.btAddProd);
            this.pnDados.Controls.Add(this.label14);
            this.pnDados.Controls.Add(this.txtValor);
            this.pnDados.Controls.Add(this.label13);
            this.pnDados.Controls.Add(this.txtQtde);
            this.pnDados.Controls.Add(this.label12);
            this.pnDados.Controls.Add(this.lProduto);
            this.pnDados.Controls.Add(this.btLocalizarCodigo);
            this.pnDados.Controls.Add(this.txtProCod);
            this.pnDados.Controls.Add(this.label10);
            this.pnDados.Controls.Add(this.label9);
            this.pnDados.Controls.Add(this.lFornecedor);
            this.pnDados.Controls.Add(this.btLocalizaFornecedor);
            this.pnDados.Controls.Add(this.txtForCod);
            this.pnDados.Controls.Add(this.label8);
            this.pnDados.Controls.Add(this.DgvItens);
            this.pnDados.Controls.Add(this.label7);
            this.pnDados.Controls.Add(this.dtDataInicial);
            this.pnDados.Controls.Add(this.label6);
            this.pnDados.Controls.Add(this.cbTipoPagamento);
            this.pnDados.Controls.Add(this.label5);
            this.pnDados.Controls.Add(this.cbNParcelas);
            this.pnDados.Controls.Add(this.txtTotalCompra);
            this.pnDados.Controls.Add(this.label4);
            this.pnDados.Controls.Add(this.label3);
            this.pnDados.Controls.Add(this.dtDataCompra);
            this.pnDados.Controls.Add(this.txtNfiscal);
            this.pnDados.Controls.Add(this.label2);
            this.pnDados.Controls.Add(this.txtComCod);
            this.pnDados.Controls.Add(this.label1);
            this.pnDados.Location = new System.Drawing.Point(3, 29);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(768, 535);
            this.pnDados.TabIndex = 3;
            // 
            // pnFinalizaCompra
            // 
            this.pnFinalizaCompra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnFinalizaCompra.Controls.Add(this.label18);
            this.pnFinalizaCompra.Controls.Add(this.lbTotal);
            this.pnFinalizaCompra.Controls.Add(this.btSalvarFinal);
            this.pnFinalizaCompra.Controls.Add(this.btCancelarFinal);
            this.pnFinalizaCompra.Controls.Add(this.lbTotaldaCompra);
            this.pnFinalizaCompra.Controls.Add(this.label16);
            this.pnFinalizaCompra.Controls.Add(this.dgvParcelas);
            this.pnFinalizaCompra.Controls.Add(this.label19);
            this.pnFinalizaCompra.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnFinalizaCompra.Location = new System.Drawing.Point(9, 375);
            this.pnFinalizaCompra.Name = "pnFinalizaCompra";
            this.pnFinalizaCompra.Size = new System.Drawing.Size(474, 149);
            this.pnFinalizaCompra.TabIndex = 4;
            this.pnFinalizaCompra.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(420, 128);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "R$";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.BackColor = System.Drawing.Color.Red;
            this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(439, 128);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(34, 13);
            this.lbTotal.TabIndex = 29;
            this.lbTotal.Text = "00,00";
            // 
            // btSalvarFinal
            // 
            this.btSalvarFinal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btSalvarFinal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvarFinal.ForeColor = System.Drawing.Color.White;
            this.btSalvarFinal.Location = new System.Drawing.Point(216, 0);
            this.btSalvarFinal.Name = "btSalvarFinal";
            this.btSalvarFinal.Size = new System.Drawing.Size(75, 21);
            this.btSalvarFinal.TabIndex = 27;
            this.btSalvarFinal.Text = "Salvar";
            this.btSalvarFinal.UseVisualStyleBackColor = false;
            this.btSalvarFinal.Click += new System.EventHandler(this.btSalvarFinal_Click);
            // 
            // btCancelarFinal
            // 
            this.btCancelarFinal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btCancelarFinal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelarFinal.ForeColor = System.Drawing.Color.White;
            this.btCancelarFinal.Location = new System.Drawing.Point(330, 0);
            this.btCancelarFinal.Name = "btCancelarFinal";
            this.btCancelarFinal.Size = new System.Drawing.Size(75, 21);
            this.btCancelarFinal.TabIndex = 28;
            this.btCancelarFinal.Text = "Cancelar";
            this.btCancelarFinal.UseVisualStyleBackColor = false;
            // 
            // lbTotaldaCompra
            // 
            this.lbTotaldaCompra.AutoSize = true;
            this.lbTotaldaCompra.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotaldaCompra.Location = new System.Drawing.Point(334, 128);
            this.lbTotaldaCompra.Name = "lbTotaldaCompra";
            this.lbTotaldaCompra.Size = new System.Drawing.Size(90, 13);
            this.lbTotaldaCompra.TabIndex = 3;
            this.lbTotaldaCompra.Text = "Total da Compra";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Dados do Pagamento";
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pco_cod,
            this.pco_valor,
            this.pco_datavector});
            this.dgvParcelas.Location = new System.Drawing.Point(4, 25);
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.ReadOnly = true;
            this.dgvParcelas.Size = new System.Drawing.Size(467, 101);
            this.dgvParcelas.TabIndex = 0;
            // 
            // pco_cod
            // 
            this.pco_cod.HeaderText = "Parcela";
            this.pco_cod.Name = "pco_cod";
            this.pco_cod.ReadOnly = true;
            // 
            // pco_valor
            // 
            this.pco_valor.HeaderText = "Valor da Parcela";
            this.pco_valor.Name = "pco_valor";
            this.pco_valor.ReadOnly = true;
            // 
            // pco_datavector
            // 
            this.pco_datavector.HeaderText = "Data do Vencimento";
            this.pco_datavector.Name = "pco_datavector";
            this.pco_datavector.ReadOnly = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(2, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(471, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(644, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "R$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(635, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "R$";
            // 
            // btAddProd
            // 
            this.btAddProd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddProd.Location = new System.Drawing.Point(711, 143);
            this.btAddProd.Name = "btAddProd";
            this.btAddProd.Size = new System.Drawing.Size(42, 19);
            this.btAddProd.TabIndex = 35;
            this.btAddProd.Text = "+";
            this.btAddProd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAddProd.UseVisualStyleBackColor = true;
            this.btAddProd.Click += new System.EventHandler(this.btAddProd_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Itens da compra";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(653, 122);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(651, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Valor Unitário";
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(530, 122);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(100, 20);
            this.txtQtde.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(528, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Quantidade";
            // 
            // lProduto
            // 
            this.lProduto.AutoSize = true;
            this.lProduto.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProduto.Location = new System.Drawing.Point(186, 129);
            this.lProduto.Name = "lProduto";
            this.lProduto.Size = new System.Drawing.Size(250, 13);
            this.lProduto.TabIndex = 29;
            this.lProduto.Text = "Informe o código do produto ou clique em localizar";
            // 
            // btLocalizarCodigo
            // 
            this.btLocalizarCodigo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLocalizarCodigo.Location = new System.Drawing.Point(121, 126);
            this.btLocalizarCodigo.Name = "btLocalizarCodigo";
            this.btLocalizarCodigo.Size = new System.Drawing.Size(64, 20);
            this.btLocalizarCodigo.TabIndex = 28;
            this.btLocalizarCodigo.Text = "Localizar";
            this.btLocalizarCodigo.UseVisualStyleBackColor = true;
            this.btLocalizarCodigo.Click += new System.EventHandler(this.btLocalizarCodigo_Click);
            // 
            // txtProCod
            // 
            this.txtProCod.Location = new System.Drawing.Point(15, 126);
            this.txtProCod.Name = "txtProCod";
            this.txtProCod.Size = new System.Drawing.Size(100, 20);
            this.txtProCod.TabIndex = 27;
            this.txtProCod.Leave += new System.EventHandler(this.txtProCod_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Código Produto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(754, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // lFornecedor
            // 
            this.lFornecedor.AutoSize = true;
            this.lFornecedor.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFornecedor.Location = new System.Drawing.Point(186, 76);
            this.lFornecedor.Name = "lFornecedor";
            this.lFornecedor.Size = new System.Drawing.Size(262, 13);
            this.lFornecedor.TabIndex = 24;
            this.lFornecedor.Text = "Informe o código do fornecedor ou clique em localizar";
            // 
            // btLocalizaFornecedor
            // 
            this.btLocalizaFornecedor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLocalizaFornecedor.Location = new System.Drawing.Point(118, 72);
            this.btLocalizaFornecedor.Name = "btLocalizaFornecedor";
            this.btLocalizaFornecedor.Size = new System.Drawing.Size(67, 21);
            this.btLocalizaFornecedor.TabIndex = 23;
            this.btLocalizaFornecedor.Text = "Localizar";
            this.btLocalizaFornecedor.UseVisualStyleBackColor = true;
            this.btLocalizaFornecedor.Click += new System.EventHandler(this.btLocalizaFornecedor_Click);
            // 
            // txtForCod
            // 
            this.txtForCod.Location = new System.Drawing.Point(15, 73);
            this.txtForCod.Name = "txtForCod";
            this.txtForCod.Size = new System.Drawing.Size(97, 20);
            this.txtForCod.TabIndex = 22;
            this.txtForCod.Leave += new System.EventHandler(this.txtForCod_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Código Fornecedor";
            // 
            // DgvItens
            // 
            this.DgvItens.AllowUserToAddRows = false;
            this.DgvItens.AllowUserToDeleteRows = false;
            this.DgvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvItens.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProCod,
            this.ForNome,
            this.ForQtde,
            this.ProUnd,
            this.ValorTotal});
            this.DgvItens.Location = new System.Drawing.Point(3, 193);
            this.DgvItens.Name = "DgvItens";
            this.DgvItens.ReadOnly = true;
            this.DgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvItens.Size = new System.Drawing.Size(739, 130);
            this.DgvItens.TabIndex = 20;
            this.DgvItens.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItens_CellDoubleClick);
            // 
            // ProCod
            // 
            this.ProCod.HeaderText = "Código";
            this.ProCod.Name = "ProCod";
            this.ProCod.ReadOnly = true;
            this.ProCod.Width = 70;
            // 
            // ForNome
            // 
            this.ForNome.HeaderText = "Nome";
            this.ForNome.Name = "ForNome";
            this.ForNome.ReadOnly = true;
            this.ForNome.Width = 300;
            // 
            // ForQtde
            // 
            this.ForQtde.HeaderText = "Quantidade";
            this.ForQtde.Name = "ForQtde";
            this.ForQtde.ReadOnly = true;
            // 
            // ProUnd
            // 
            this.ProUnd.HeaderText = "Valor Unitário";
            this.ProUnd.Name = "ProUnd";
            this.ProUnd.ReadOnly = true;
            this.ProUnd.Width = 110;
            // 
            // ValorTotal
            // 
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Width = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(263, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Data Inicial";
            // 
            // dtDataInicial
            // 
            this.dtDataInicial.Location = new System.Drawing.Point(260, 343);
            this.dtDataInicial.Name = "dtDataInicial";
            this.dtDataInicial.Size = new System.Drawing.Size(223, 20);
            this.dtDataInicial.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo de pagamento";
            // 
            // cbTipoPagamento
            // 
            this.cbTipoPagamento.FormattingEnabled = true;
            this.cbTipoPagamento.Location = new System.Drawing.Point(133, 342);
            this.cbTipoPagamento.Name = "cbTipoPagamento";
            this.cbTipoPagamento.Size = new System.Drawing.Size(121, 21);
            this.cbTipoPagamento.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nº de parcelas";
            // 
            // cbNParcelas
            // 
            this.cbNParcelas.FormattingEnabled = true;
            this.cbNParcelas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbNParcelas.Location = new System.Drawing.Point(6, 342);
            this.cbNParcelas.Name = "cbNParcelas";
            this.cbNParcelas.Size = new System.Drawing.Size(121, 21);
            this.cbNParcelas.TabIndex = 8;
            this.cbNParcelas.Text = "1";
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Location = new System.Drawing.Point(665, 427);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCompra.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(662, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(527, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data da Compra";
            // 
            // dtDataCompra
            // 
            this.dtDataCompra.Location = new System.Drawing.Point(530, 18);
            this.dtDataCompra.Name = "dtDataCompra";
            this.dtDataCompra.Size = new System.Drawing.Size(223, 20);
            this.dtDataCompra.TabIndex = 4;
            // 
            // txtNfiscal
            // 
            this.txtNfiscal.Location = new System.Drawing.Point(297, 21);
            this.txtNfiscal.Name = "txtNfiscal";
            this.txtNfiscal.Size = new System.Drawing.Size(100, 20);
            this.txtNfiscal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº Nota Fiscal";
            // 
            // txtComCod
            // 
            this.txtComCod.Enabled = false;
            this.txtComCod.Location = new System.Drawing.Point(14, 21);
            this.txtComCod.Name = "txtComCod";
            this.txtComCod.Size = new System.Drawing.Size(61, 20);
            this.txtComCod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // Frm_MovimentacaoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(776, 565);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.panel2);
            this.Name = "Frm_MovimentacaoCompra";
            this.Text = "Formulário de Compra";
            this.Load += new System.EventHandler(this.Frm_MovimentacaoCompra_Load);
            this.panel2.ResumeLayout(false);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnFinalizaCompra.ResumeLayout(false);
            this.pnFinalizaCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btInserir;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDataCompra;
        private System.Windows.Forms.TextBox txtNfiscal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDataInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbTipoPagamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNParcelas;
        private System.Windows.Forms.Label lFornecedor;
        private System.Windows.Forms.Button btLocalizaFornecedor;
        private System.Windows.Forms.TextBox txtForCod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DgvItens;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lProduto;
        private System.Windows.Forms.Button btLocalizarCodigo;
        private System.Windows.Forms.TextBox txtProCod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btAddProd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProUnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnFinalizaCompra;
        private System.Windows.Forms.Button btSalvarFinal;
        private System.Windows.Forms.Button btCancelarFinal;
        private System.Windows.Forms.Label lbTotaldaCompra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvParcelas;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn pco_datavector;
    }
}