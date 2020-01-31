using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DLL;


namespace GUI
{
    public partial class Frm_ConsultaProduto : Form
    {

        public int codigo = 0;


        public Frm_ConsultaProduto()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {

            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bllProduto = new BLLProduto(dalConexao);

            DgvDados.DataSource = bllProduto.Localizar(txtValor.Text);

        }

        private void Frm_ConsultaProduto_Load(object sender, EventArgs e)
        {
            //DgvDados.Rows[2].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btLocalizar_Click(sender, e);
            DgvDados.Columns[0].HeaderText = "Código";
            DgvDados.Columns[0].Width = 50;

            DgvDados.Columns[1].HeaderText = "Nome";
            DgvDados.Columns[1].Width = 150;

            DgvDados.Columns[2].HeaderText = "Descrição";
            DgvDados.Columns[2].Width = 300;

            DgvDados.Columns[3].HeaderText = "Foto";
            DgvDados.Columns[3].Width = 150;

            DgvDados.Columns[4].HeaderText = "Valor de pago";
            DgvDados.Columns[4].Width = 130;

            DgvDados.Columns[5].HeaderText = "Valor da venda";
            DgvDados.Columns[5].Width = 130;

            DgvDados.Columns[6].HeaderText = "Quantidade";
            DgvDados.Columns[6].Width = 120;

            DgvDados.Columns[7].HeaderText = "Unidade de medida";
            DgvDados.Columns[7].Width = 100;

            DgvDados.Columns[8].HeaderText = "Categoria";
            DgvDados.Columns[8].Width = 130;

            DgvDados.Columns[9].HeaderText = "Sub categoria";
            DgvDados.Columns[9].Width = 130;

            DgvDados.Columns[10].HeaderText = "Unidade de medida";
            DgvDados.Columns[10].Width = 130;

            DgvDados.Columns[11].HeaderText = "Categoria";
            DgvDados.Columns[11].Width = 130;

            DgvDados.Columns[12].HeaderText = "Sub categoria";
            DgvDados.Columns[12].Width = 130;

            //                  OCULTAR COLUNAS

            DgvDados.Columns["pro_foto"].Visible = false;
            DgvDados.Columns["pro_valorpago"].Visible = false;
            DgvDados.Columns["cat_cod"].Visible = false;
            DgvDados.Columns["scat_cod"].Visible = false;
            DgvDados.Columns["umed_cod"].Visible = false;
        }

        private void DgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)        //VERIFICA SE EXISTE LINHA
            {
                this.codigo = Convert.ToInt32(DgvDados.Rows[e.RowIndex].Cells[0].Value); //CELULAR 0, VALOR
                this.Close();
            }
        }
    }
}
