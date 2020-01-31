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
using GUI;
using DLL;
using Modelo;

namespace GUI
{
    public partial class Frm_CadastroTipoDePagamento : Form
    {
        Frm_ModeloDeFormularioDeCadastro mod = new Frm_ModeloDeFormularioDeCadastro();
        public Frm_CadastroTipoDePagamento()
        {
            InitializeComponent();
        }

        public int codigo = 0;

        public void AlterarBotoes(int op)
        {

            PnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;

            if (op == 1)
            {

                btInserir.Enabled = true;
                btLocalizar.Enabled = true;

            }

            if (op == 2)
            {

                PnDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;

            }

            if (op == 3)
            {

                btAlterar.Enabled = true;
                btExcluir.Enabled = true;
                btCancelar.Enabled = true;
            }
        }


        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
        }

        private void Frm_CadastroTipoDePagamento_Load(object sender, EventArgs e)
        {

            this.AlterarBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {

            AlterarBotoes(2);
            mod.Operacao = "inserir";

        }
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaTipoPagamento consultaPagamento = new Frm_ConsultaTipoPagamento();         //CRIA O FORMULARIO DE CONSULTA DA CATEGORIA
            consultaPagamento.ShowDialog();                                                //EXIBE O FORMULARIO

            if (consultaPagamento.codigo != 0)       //VERIFICA SE O CODIGO É DIFERENTE DE 0 - ENTAO ELE SELECIONOU UMA CATEGORIA PARA ALTERAR
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);        //CRIA A CONEXAO
                BLLTipoPagamento bllPagamento = new BLLTipoPagamento(dalConexao);                   //CRIA A CONEXAO

                ModeloTipoPagamento modeloPagamento = bllPagamento.CarregaModeloTipoPagamento(consultaPagamento.codigo); //CRIA O DLL. carrega o modelo ! Apartir do modelo criado por meio do CarregaModelo, e tem como parametro o CODIGO  que o usuario selecionou.
                txtCodigo.Text = modeloPagamento.TpaCod.ToString();                //PEGA AS INFORMACOES E VOLTA NA TELA
                txtNome.Text = modeloPagamento.TpaNome;                        //PEGA AS INFORMACOES E VOLTA NA TELA

                AlterarBotoes(3);
            }
            else
            {
                LimpaTela();
                AlterarBotoes(1);
            }
            consultaPagamento.Dispose();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            mod.Operacao = "Alterar";
            AlterarBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult _dialogResult = MessageBox.Show("Deseja realmente exlcuir o registro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_dialogResult.ToString() == "Yes")
                {
                    DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);

                    BLLTipoPagamento tipoPagamento = new BLLTipoPagamento(dalConexao);
                    tipoPagamento.Excluir(Convert.ToInt32(txtCodigo.Text));
                    LimpaTela();
                    mod.AlterarBotoes(1);
                    
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                mod.AlterarBotoes(3);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            AlterarBotoes(1);
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                //criar uma conexao
                ModeloTipoPagamento modelo = new ModeloTipoPagamento();
                modelo.TpaNome = txtNome.Text;

                //objeto para gravar os dados do banco  
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLTipoPagamento BLL = new BLLTipoPagamento(cx);

                if (mod.Operacao == "inserir")
                {

                    BLL.Incluir(modelo);                        //CADASTRA NOVA CATEGORIA
                    MessageBox.Show("Cadastro efetuado : codigo " + modelo.TpaCod.ToString());
                }
                else
                {
                    modelo.TpaCod = Convert.ToInt32(txtCodigo.Text);    //ALTERA UMA CATEGORIA
                    BLL.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }
                LimpaTela();
                mod.AlterarBotoes(1);
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
