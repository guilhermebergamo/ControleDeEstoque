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
    public partial class Frm_ConsultaCompra : Form
    {
        public Frm_ConsultaCompra()
        {
            InitializeComponent();
        }

        private void Frm_ConsultaCompra_Load(object sender, EventArgs e)
        {
            pnFornecedor.Visible = false;
        }

        public void ExecutaConsulta(int Opcao )
        {
            //Opcao 1 == todas as compra
            //opcao 2 == Fornecedor
            //opcao 3 == data compra
            //opcao 4 parcelas em aberto
        }

        public void AtualizaDataGridCompra()
        {
            //TROCAR A POSIÇÃO DO TOTAL E DO FORNECEDOR

            //FAZER ALGUNS AJUSTES REFERENTE A POSIÇÃO DAS COLUANS

            //QUISER MUDAR A POSICAO DAS COLUNHAS É SÓ TROCAR O LUGAR DOS CAMPOS QUE ESTAO NO LocalizaCodFornecedor



            //    DgvDados.Columns[0].HeaderText = "Código da Compra"; //
            //    DgvDados.Columns[0].Width = 100;

            //    DgvDados.Columns[1].HeaderText = "Data da Compra"; //
            //    DgvDados.Columns[1].Width = 100;

            //    DgvDados.Columns[2].HeaderText = "Nº Nota Fiscal";
            //    DgvDados.Columns[2].Width = 100;

            //    DgvDados.Columns[3].HeaderText = "Total";
            //    DgvDados.Columns[3].Width = 100;

            //    DgvDados.Columns[4].HeaderText = "Nº das Parcelas";     //a
            //    DgvDados.Columns[4].Width = 100;           

            //    DgvDados.Columns[5].HeaderText = "Status da Compra";
            //    DgvDados.Columns[5].Width = 100;

            //    DgvDados.Columns[6].HeaderText = "Código Fornecedor";
            //    DgvDados.Columns[6].Width = 100;

            //    DgvDados.Columns[7].HeaderText = "Código tipo Pagamento";
            //    DgvDados.Columns[7].Width = 100;


            //-------------------------------------------------------------------------------------------

            //DgvDados.Columns[3].Visible = false;
            //DgvDados.Columns[5].Visible = false;
            //DgvDados.Columns[6].Visible = false;
            //DgvDados.Columns[7].Visible = false;



            //video 113 13 minuto
        }

        private void btLocalizarFornecedor_Click(object sender, EventArgs e)
        {
            Frm_ConsultaFornecedor consultaFornecedor = new Frm_ConsultaFornecedor();
            consultaFornecedor.ShowDialog();

            if (consultaFornecedor.Codigo != 0)
            {
                txtForCodigo.Text = consultaFornecedor.Codigo.ToString();

                DALConexao conexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bLLFornecedor = new BLLFornecedor(conexao);

                ModeloFornecedor ModeloFornecedor = bLLFornecedor.CarregaModeloFornecedor(consultaFornecedor.Codigo);
                lbForNome.Text = ($"Nome: {ModeloFornecedor.ForNome}");

                BLLCompra bllCompra = new BLLCompra(conexao);
                DgvDados.DataSource = bllCompra.LocalizaCodFornecedor(consultaFornecedor.Codigo);
                consultaFornecedor.Dispose();

                AtualizaDataGridCompra();
            }
            else
            {
                txtForCodigo.Text = "";
                lbForNome.Text = "Nome do fornecedor";                
            }
        }
        

        private void rbGeral_CheckedChanged_1(object sender, EventArgs e)
        {
            pnFornecedor.Visible = false;

            DgvDados.DataSource = null;

            pnData.Visible = false;

            if (rbGeral.Checked == true)
            {
                
                pnFornecedor.Visible = false;

                DALConexao conexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCompra bllCompra = new BLLCompra(conexao);

                DgvDados.DataSource = bllCompra.Localizar();            
            }

            if (rbData.Checked == true)
            {                
                pnFornecedor.Visible = false;
                pnData.Visible = true;
            }

            if (rbFornecedor.Checked == true)
            {
                pnFornecedor.Visible = true;
            }

            if (rbParcelas.Checked == true)
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCompra bllCompra = new BLLCompra(dalConexao);

                DgvDados.DataSource = bllCompra.LocalizarParcelasAbertas();

                pnFornecedor.Visible = false;
            }
        }

        private void btLocalizarData_Click(object sender, EventArgs e)
        {          
            DALConexao conexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCompra bllCompra = new BLLCompra(conexao);

            DgvDados.DataSource = bllCompra.LocalizarData(dtDataInicial.Value, dtDataFinal.Value);
        }
    }
}
