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
    public partial class Frm_ConsultaTipoPagamento : Form
    {

        public int codigo = 0;
        public Frm_ConsultaTipoPagamento()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {

            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            DALTipoPagamento  tipoPagamento = new DALTipoPagamento(dalConexao);

            DgvDados.DataSource = tipoPagamento.Localizar(txtValor.Text);

        }

        private void Frm_ConsultaTipoPagamento_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            DgvDados.Columns[0].HeaderText = "Código";                            //Mudara o nome da Coluna "Cat_Cod" por "Codigo"
            DgvDados.Columns[0].Width = 570;                                     //Mudara o tamanho da coluna do Código pra 40 Pixels
            DgvDados.Columns[1].HeaderText = "Tipo de pagamento";                              //Mudara o nome da Coluna "Cat_nome" por "Categoria"
            DgvDados.Columns[1].Width = 570;
        }

        private void DgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)     //verifcia se a linha que o usuario selecionou é maior do que 0
            {
                //ALTÉRA A PROPRIEDADE CODIGO, ADICIONANDO UM VALOR QUE SE ENCONTRA NA CELULA 0 DA LINHA SELECIONA 
                //PELO USUARIO NO DATAGRIDVIWER !
                codigo = Convert.ToInt32(DgvDados.Rows[e.RowIndex].Cells[0].Value); //Cells[0] = CELULA 0 -- //Rows.[e.RowIndex] == LINHA SELECIONADA PELO USUSARIO.    
                Close();
            }
        }
    }
}
