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
using DLL;

namespace GUI
{
    public partial class Frm_ConsultaUnidadeDeMedida : Form
    {
        public int Codigo = 0;

        public Frm_ConsultaUnidadeDeMedida()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUnidadeDeMedida bllunidadedeMedida = new BLLUnidadeDeMedida(dalConexao);
            DgvDados.DataSource = bllunidadedeMedida.localizar(txtValor.Text);
        }

        private void DgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }     

        private void Frm_ConsultaUnidadeDeMedida_Load(object sender, EventArgs e)
        {                                               //
            btLocalizar_Click(sender, e);
            DgvDados.Columns[0].HeaderText = "Código";
            DgvDados.Columns[0].Width = 80;
            DgvDados.Columns[1].HeaderText = "Unidade de Medida";
            DgvDados.Columns[1].Width = 660;
            
        }

        private void DgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Codigo = Convert.ToInt32(DgvDados.Rows[e.RowIndex].Cells[0].Value); //Cells[0] = CELULA 0 -- Rows.[e.RowIndex] == LINHA SELECIONADA PELO USUSARIO.
                Close();
            }
        }
    }
}
