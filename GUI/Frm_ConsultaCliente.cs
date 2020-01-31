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
using Modelo;

namespace GUI
{
    public partial class Frm_ConsultaCliente : Form
    {
        public Frm_ConsultaCliente()
        {
            InitializeComponent();
        }

        public int Codigo = 0;

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            DALCliente dalCliente = new DALCliente(dalConexao);

            if (rbNome.Checked == true)
            {
                DgvDados.DataSource = dalCliente.LocalizarPorNOME(txtValor.Text);

            }
            else
            {
                DgvDados.DataSource = dalCliente.LocalizarPorCPFCNPJ(txtValor.Text);
            }         

        }

        private void Frm_ConsultaCliente_Load(object sender, EventArgs e)
        {

            btLocalizar_Click(sender, e);
            DgvDados.Columns[0].HeaderText = "Código";
            DgvDados.Columns[0].Width = 50;

            DgvDados.Columns[1].HeaderText = "Nome";
            DgvDados.Columns[1].Width = 110;

            DgvDados.Columns[2].HeaderText = "CPF/CNPJ";
            DgvDados.Columns[2].Width = 110;

            DgvDados.Columns[3].HeaderText = "RG/IE";
            DgvDados.Columns[3].Width = 110;

            DgvDados.Columns[4].HeaderText = "Razão Social";
            DgvDados.Columns[4].Width = 110;

            DgvDados.Columns[5].HeaderText = "Tipo Cliente";
            DgvDados.Columns[5].Width = 110;

            DgvDados.Columns[6].HeaderText = "CEP";
            DgvDados.Columns[6].Width = 110;

            DgvDados.Columns[7].HeaderText = "Endereço";
            DgvDados.Columns[7].Width = 110;

            DgvDados.Columns[8].HeaderText = "Bairro";
            DgvDados.Columns[8].Width = 110;

            DgvDados.Columns[9].HeaderText = "Telefone";
            DgvDados.Columns[9].Width = 110;

            DgvDados.Columns[10].HeaderText = "Celular";
            DgvDados.Columns[10].Width = 110;

            DgvDados.Columns[11].HeaderText = "E-mail";
            DgvDados.Columns[11].Width = 150;

            DgvDados.Columns[12].HeaderText = "Numero";
            DgvDados.Columns[12].Width = 110;

            DgvDados.Columns[13].HeaderText = "Cidade";
            DgvDados.Columns[13].Width = 110;

            DgvDados.Columns[14].HeaderText = "Estado";
            DgvDados.Columns[14].Width = 110;

        }

        private void DgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Codigo = Convert.ToInt32(DgvDados.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
