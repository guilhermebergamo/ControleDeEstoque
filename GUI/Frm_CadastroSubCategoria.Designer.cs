namespace GUI
{
    partial class Frm_CadastroSubCategoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_CatCod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ScatCod = new System.Windows.Forms.TextBox();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.PnBotoes.SuspendLayout();
            this.PnDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btInserir
            // 
            this.btInserir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btInserir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btInserir.Location = new System.Drawing.Point(26, 3);
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.ForeColor = System.Drawing.Color.Transparent;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLocalizar.Location = new System.Drawing.Point(157, 3);
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAlterar.Location = new System.Drawing.Point(288, 3);
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(419, 3);
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(550, 3);
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(681, 3);
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // PnBotoes
            // 
            this.PnBotoes.BackColor = System.Drawing.Color.Black;
            this.PnBotoes.Location = new System.Drawing.Point(-11, -1);
            this.PnBotoes.Size = new System.Drawing.Size(791, 105);
            // 
            // PnDados
            // 
            this.PnDados.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PnDados.Controls.Add(this.btAdd);
            this.PnDados.Controls.Add(this.txt_Nome);
            this.PnDados.Controls.Add(this.txt_ScatCod);
            this.PnDados.Controls.Add(this.label3);
            this.PnDados.Controls.Add(this.cb_CatCod);
            this.PnDados.Controls.Add(this.label2);
            this.PnDados.Controls.Add(this.label1);
            this.PnDados.ForeColor = System.Drawing.Color.Black;
            this.PnDados.Location = new System.Drawing.Point(-6, 120);
            this.PnDados.Size = new System.Drawing.Size(791, 455);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(187, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome da SubCtegoria :";
            // 
            // cb_CatCod
            // 
            this.cb_CatCod.FormattingEnabled = true;
            this.cb_CatCod.Location = new System.Drawing.Point(26, 158);
            this.cb_CatCod.Name = "cb_CatCod";
            this.cb_CatCod.Size = new System.Drawing.Size(131, 21);
            this.cb_CatCod.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome da Categoria";
            this.label3.Click += new System.EventHandler(this.lblNomeCategoria_Click);
            // 
            // txt_ScatCod
            // 
            this.txt_ScatCod.Enabled = false;
            this.txt_ScatCod.Location = new System.Drawing.Point(23, 63);
            this.txt_ScatCod.Name = "txt_ScatCod";
            this.txt_ScatCod.Size = new System.Drawing.Size(59, 20);
            this.txt_ScatCod.TabIndex = 4;
            // 
            // txt_Nome
            // 
            this.txt_Nome.Location = new System.Drawing.Point(191, 158);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(582, 20);
            this.txt_Nome.TabIndex = 5;
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(26, 185);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(130, 20);
            this.btAdd.TabIndex = 6;
            this.btAdd.Text = "Cadastrar";
            this.btAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // Frm_CadastroSubCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(774, 565);
            this.Name = "Frm_CadastroSubCategoria";
            this.Load += new System.EventHandler(this.Frm_CadastroSubCategoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_CadastroSubCategoria_KeyDown);
            this.PnBotoes.ResumeLayout(false);
            this.PnDados.ResumeLayout(false);
            this.PnDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.TextBox txt_ScatCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_CatCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAdd;
    }
}
