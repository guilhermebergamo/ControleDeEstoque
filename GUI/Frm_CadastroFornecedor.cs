using System.Windows.Forms;
using DAL;
using DLL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferramentas;

namespace GUI
{
    public partial class Frm_CadastroFornecedor : Form
    {
        public Frm_CadastroFornecedor()
        {
            InitializeComponent();
        }
        Frm_ModeloDeFormularioDeCadastro frm = new Frm_ModeloDeFormularioDeCadastro();

        public void AlterarBotoes(int op)
        {

            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;
            btLocalizar.Enabled = false;

            if (op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
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

        public void LimpaTela()
        {

            txtCodigo.Clear();
            txtNome.Clear();
            txtRSocial.Clear();
            txtBairro.Clear();
            txtCelular.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtCNPJ.Clear();
            txtEmail.Clear();
            txtEstado.Clear();
            txtFone.Clear();
            txtNumero.Clear();
            txtIe.Clear();
            txtRua.Clear();
            lbValorIncorreto.Visible = false;
        }

        public enum Campo { CPF = 1, CNPJ = 2, CEP = 3 }

        public void Formatar(Campo Valor, TextBox txtTexto)
        {

            switch (Valor)
            {
                case Campo.CPF:
                    txtTexto.MaxLength = 14;                //DEFINE TAMANHO MAXIMO DO TEXTO (14)
                    if (txtTexto.Text.Length == 3)
                    {

                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                        //AUMENTA O TAMANHO DO TEXTBOX
                    }
                    else if (txtTexto.Text.Length == 7)
                    {

                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                        //AUMENTA O TAMANHO DO TEXTBOX
                    }
                    else if (txtTexto.Text.Length == 11)
                    {

                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;                      //AUMENTA O TAMANHO DO TEXTBOX
                    }

                    break;

                case Campo.CNPJ:
                    txtTexto.MaxLength = 18;
                    if (txtTexto.Text.Length == 2 || txtTexto.Text.Length == 6)
                    {

                        txtTexto.Text = txtTexto.Text + ".";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 10)
                    {

                        txtTexto.Text = txtTexto.Text + "/";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }
                    else if (txtTexto.Text.Length == 15)
                    {
                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;
                    }

                    break;

                case Campo.CEP:
                    txtTexto.MaxLength = 9;                                 //define tamanho maximo
                    if (txtTexto.Text.Length == 5)
                    {

                        txtTexto.Text = txtTexto.Text + "-";
                        txtTexto.SelectionStart = txtTexto.Text.Length + 1;     //FAZ CURSOS FICAR DISPONIVEL NA FRENTE DO TRAÇO
                    }

                    break;
            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {

            frm.Operacao = "inserir";
            AlterarBotoes(2);
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
                        
            Frm_ConsultaFornecedor consultaFornecedor = new Frm_ConsultaFornecedor();
            consultaFornecedor.ShowDialog();

            if (consultaFornecedor.Codigo != 0)
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bllFornecedor = new BLLFornecedor(dalConexao);
              
                ModeloFornecedor modelo = bllFornecedor.CarregaModeloFornecedor(consultaFornecedor.Codigo); //CRIA O DLL. carrega o modelo ! Apartir do modelo criado por meio do CarregaModelo, e tem como parametro o CODIGO  que o usuario selecionou.
                txtCodigo.Text = modelo.ForCod.ToString();              

                txtNome.Text = modelo.ForNome;
                txtRSocial.Text = modelo.ForRsocial;
                txtCNPJ.Text = modelo.ForCnpj;
                txtIe.Text = modelo.ForIe;
                txtCep.Text = modelo.ForCep;
                txtEstado.Text = modelo.ForEstado;
                txtCidade.Text = modelo.ForCidade;
                txtRua.Text = modelo.ForEndereco;
                txtNumero.Text = modelo.ForEndNumero;
                txtBairro.Text = modelo.ForBairro;
                txtEmail.Text = modelo.ForEmail;
                txtFone.Text = modelo.ForFone;
                txtCelular.Text = modelo.ForCelular;

                AlterarBotoes(3);
            }
            else
            {

                LimpaTela();
                AlterarBotoes(1);
            }

            consultaFornecedor.Dispose();
             
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {

            frm.Operacao = "alterar";
            AlterarBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Deseja realmente exlcuir o registro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult.ToString() == "Yes")
                {

                    DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLFornecedor bllFornecedor = new BLLFornecedor(dalConexao);
                    bllFornecedor.Excluir(Convert.ToInt32(txtCodigo.Text));

                    LimpaTela();
                    AlterarBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro.\nO registro esta sendo utilizado em outro local.");
                //AlterarBotoes(3);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //criar uma conexao
                ModeloFornecedor modelo = new ModeloFornecedor();
                modelo.ForNome = txtNome.Text;
                modelo.ForRsocial = txtRSocial.Text;
                modelo.ForCnpj = txtCNPJ.Text;
                modelo.ForIe = txtIe.Text;
                modelo.ForCep = txtCep.Text;
                modelo.ForCidade = txtCidade.Text;
                modelo.ForEstado = txtEstado.Text;
                modelo.ForEndereco = txtRua.Text;
                modelo.ForEndNumero = txtNumero.Text;
                modelo.ForBairro = txtBairro.Text;
                modelo.ForEmail = txtEmail.Text;
                modelo.ForFone = txtFone.Text;
                modelo.ForCelular = txtCelular.Text;

              
                //objeto para gravar os dados do banco  
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bllFornecedor = new BLLFornecedor(cx);

                if (frm.Operacao == "inserir")
                {

                    bllFornecedor.Incluir(modelo);                        //CADASTRA NOVA CATEGORIA
                    MessageBox.Show("Cadastro efetuado: Codigo " + modelo.ForCod.ToString());
                }
                else
                {

                    modelo.ForCod = Convert.ToInt32(txtCodigo.Text);    //ALTERA UMA CATEGORIA
                    bllFornecedor.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }

                LimpaTela();
                AlterarBotoes(1);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

            AlterarBotoes(1);
            LimpaTela();
        }

        private void txtCNPJ_Leave(object sender, EventArgs e)
        {

            lbValorIncorreto.Visible = false;

            if (Validacao.iscnpj(txtCNPJ.Text) == false)
            {
                lbValorIncorreto.Visible = true;
            }
        }



        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != (char)8)       // DIFERENTE DE BACKSPACE
            {

                Campo edit = Campo.CNPJ;
                Formatar(edit, txtCNPJ);
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {

            if (Validacao.ValidaCep(txtCep.Text) == false)
            {

                MessageBox.Show("O CEP è inválido !");

                txtBairro.Clear();
                txtEstado.Clear();
                txtCidade.Clear();
                txtRua.Clear();

            }
            else
            {

                if (BuscaEndereco.verificaCEP(txtCep.Text) == true)
                {

                    txtBairro.Text = BuscaEndereco.Bairro;
                    txtEstado.Text = BuscaEndereco.Estado;
                    txtCidade.Text = BuscaEndereco.Cidade;
                    txtRua.Text = BuscaEndereco.Endereco;
                }
                else
                {
                    //PODE LIMPAR OS CAMPOS 
                }

            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)           //Diferente de backspace
            {

                Campo edit = Campo.CEP;
                Formatar(edit, txtCep);
            } 
        }
    }
}
