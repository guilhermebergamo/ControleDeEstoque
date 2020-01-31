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


namespace GUI
{
    public partial class Frm_ConsultaFornecedor : Form
    {
        public int Codigo = 0;

        public Frm_ConsultaFornecedor()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            DALFornecedor dalFornecedor = new DALFornecedor(dalConexao);

            if (rbNome.Checked == true)
            {
                DgvDados.DataSource = dalFornecedor.LocalizarPorNOME(txtValor.Text);

            }
            else
            {
                DgvDados.DataSource = dalFornecedor.LocalizaPorCNPJ(txtValor.Text);
            }
        }

        private void Frm_ConsultaFornecedor_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);

            DgvDados.Columns[0].HeaderText = "Código";
            DgvDados.Columns[0].Width = 100;

            DgvDados.Columns[1].HeaderText = "Nome";
            DgvDados.Columns[1].Width = 100;

            DgvDados.Columns[2].HeaderText = "Razão Social";
            DgvDados.Columns[2].Width = 100;

            DgvDados.Columns[3].HeaderText = "Inscrição Estadual";
            DgvDados.Columns[3].Width = 100;

            DgvDados.Columns[4].HeaderText = "CNPJ";
            DgvDados.Columns[4].Width = 100;

            DgvDados.Columns[5].HeaderText = "CEP";
            DgvDados.Columns[5].Width = 100;

            DgvDados.Columns[6].HeaderText = "Endereço";
            DgvDados.Columns[6].Width = 100;

            DgvDados.Columns[7].HeaderText = "Bairro";
            DgvDados.Columns[7].Width = 100;

            DgvDados.Columns[8].HeaderText = "Telefone";
            DgvDados.Columns[8].Width = 100;

            DgvDados.Columns[9].HeaderText = "Celular";
            DgvDados.Columns[9].Width = 100;

            DgvDados.Columns[10].HeaderText = "E-mail";
            DgvDados.Columns[10].Width = 100;

            DgvDados.Columns[11].HeaderText = "Numero";
            DgvDados.Columns[11].Width = 100;

            DgvDados.Columns[12].HeaderText = "Cidade";
            DgvDados.Columns[12].Width = 100;

            DgvDados.Columns[13].HeaderText = "Estado";
            DgvDados.Columns[13].Width = 100;
            
        }

        private void DgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Codigo = Convert.ToInt32(DgvDados.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }
    }
}
