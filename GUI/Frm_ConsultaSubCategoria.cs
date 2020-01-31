using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelo;
using DAL;
using DLL;


namespace GUI
{
    public partial class Frm_ConsultaSubCategoria : Form
    {
        public int Codigo = 0;
        public Frm_ConsultaSubCategoria()
        {
            InitializeComponent();
        }
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao _dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);        //cria conexao
            BLLSubCategoria _bllsubCategoria = new BLLSubCategoria(_dalConexao);        //cria subcategoria 
            Dgv_Dados.DataSource = _bllsubCategoria.Localizar(txtValor.Text);       //vinculou o retorno localizar no datasource
        }
        private void Frm_ConsultaSubCategoria_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            Dgv_Dados.Columns[0].HeaderText = "Código SubCategoria";
            Dgv_Dados.Columns[0].Width = 135;
            Dgv_Dados.Columns[1].HeaderText = "SubCategoria";
            Dgv_Dados.Columns[1].Width = 400;
            Dgv_Dados.Columns[2].HeaderText = "Código da Categoria";
            Dgv_Dados.Columns[2].Width = 70;
            Dgv_Dados.Columns[3].HeaderText = "Nome da Categoria";
            Dgv_Dados.Columns[3].Width = 135;
        }
        private void Dgv_Dados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   //linha selecionada
            if (e.RowIndex >= 0)        //Se a linha selecionada for maior que 0
            {//armazena o codigo
                Codigo = Convert.ToInt32(Dgv_Dados.Rows[e.RowIndex].Cells[0].Value); //Cells[0] = CELULA 0 -- //Rows.[e.RowIndex] == LINHA SELECIONADA PELO USUSARIO.
                Close();        //abre a linha selecionada e depois fecha
            }
        }
      
    }
}
