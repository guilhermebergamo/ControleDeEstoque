﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferramentas;
using Modelo;
using DAL;
using DLL;


namespace GUI
{
    public partial class Frm_CadastroCliente : Form
    {
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


        public Frm_CadastroCliente()
        {
            InitializeComponent();
        }
        //FLYFSTYLE TIPO DO BOTÃO

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
            txtCPFCNPJ.Clear();
            txtEmail.Clear();
            txtEstado.Clear();
            txtFone.Clear();
            txtNumero.Clear();
            txtRgIe.Clear();
            txtRua.Clear();

            rbFisica.Checked = true;
            lbValorIncorreto.Visible = false;
        }


        private void btLocalizar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaCliente consultaCliente = new Frm_ConsultaCliente();
            consultaCliente.ShowDialog();

            if (consultaCliente.Codigo != 0)
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCliente bllCliente = new BLLCliente(dalConexao);

                ModeloCliente modelo = bllCliente.CarregaModeloCliente(consultaCliente.Codigo); //CRIA O DLL. carrega o modelo ! Apartir do modelo criado por meio do CarregaModelo, e tem como parametro o CODIGO  que o usuario selecionou.
                txtCodigo.Text = modelo.CliCod.ToString();

                //PREENCHE RADIOBUTTON
                if (modelo.CliTipo == "Física")
                {

                    rbFisica.Checked = true;
                }
                else
                {

                    rbJuridica.Checked = true;
                }

                txtNome.Text = modelo.CliNome;
                txtRSocial.Text = modelo.CliRsocial;
                txtCPFCNPJ.Text = modelo.CliCpfCnpj;
                txtRgIe.Text = modelo.CliRgIe;
                txtCep.Text = modelo.CliCep;
                txtEstado.Text = modelo.CliEstado;
                txtCidade.Text = modelo.CliCidade;
                txtRua.Text = modelo.CliEndereco;
                txtNumero.Text = modelo.CliEndNumero;
                txtBairro.Text = modelo.CliBairro;
                txtEmail.Text = modelo.CliEmail;
                txtFone.Text = modelo.CliFone;
                txtCelular.Text = modelo.CliCelular;

                AlterarBotoes(3);
            }
            else
            {

                LimpaTela();
                AlterarBotoes(1);
            }

            consultaCliente.Dispose();
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
                    BLLCliente bllCliente = new BLLCliente(dalConexao);
                    bllCliente.Excluir(Convert.ToInt32(txtCodigo.Text));

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
                ModeloCliente modelo = new ModeloCliente();
                modelo.CliNome = txtNome.Text;
                modelo.CliRsocial = txtRSocial.Text;
                modelo.CliCpfCnpj = txtCPFCNPJ.Text;
                modelo.CliRgIe = txtRgIe.Text;
                modelo.CliCep = txtCep.Text;
                modelo.CliCidade = txtCidade.Text;
                modelo.CliEstado = txtEstado.Text;
                modelo.CliEndereco = txtRua.Text;
                modelo.CliEndNumero = txtNumero.Text;
                modelo.CliBairro = txtBairro.Text;
                modelo.CliEmail = txtEmail.Text;
                modelo.CliFone = txtFone.Text;
                modelo.CliCelular = txtCelular.Text;

                if (rbFisica.Checked == true)
                {

                    modelo.CliTipo = "Física";     //SE FOR 0 É PESSOA FISICA !
                    modelo.CliRsocial = "";
                }
                else
                {

                    modelo.CliTipo = "Jurídica";     //SE FOR 1 É PESSOA JURIDICA !
                }

                //objeto para gravar os dados do banco  
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCliente bllCliente = new BLLCliente(cx);

                if (frm.Operacao == "inserir")
                {

                    bllCliente.Incluir(modelo);                        //CADASTRA NOVA CATEGORIA
                    MessageBox.Show("Cadastro efetuado: Codigo " + modelo.CliCod.ToString());
                }
                else
                {

                    modelo.CliCod = Convert.ToInt32(txtCodigo.Text);    //ALTERA UMA CATEGORIA
                    bllCliente.Alterar(modelo);
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

        private void Frm_CadastroCliente_Load(object sender, EventArgs e)
        {

            AlterarBotoes(1);
            LimpaTela();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {

            frm.Operacao = "inserir";
            AlterarBotoes(2);

        }

        private void rbFisica_CheckedChanged(object sender, EventArgs e) //EVENTO CHECKEDCHANGED OU PODERIA SER EVENTO CLICK TAMBEM
        {

            if (rbFisica.Checked == true)
            {

                lbRSocial.Visible = false;
                txtRSocial.Visible = false;
                lbCPFCNPJ.Text = "CPF :";
                lbRGIE.Text = "RG :";
                txtCPFCNPJ.Clear();
            }
            else
            {

                lbRSocial.Visible = true;
                txtRSocial.Visible = true;
                lbCPFCNPJ.Text = "CNPJ :";
                lbRGIE.Text = "IE :";
                txtCPFCNPJ.Clear();


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

            if (e.KeyChar != (char)8)           //se for diferente de backspace
            {

                Campo edit = Campo.CEP;
                Formatar(edit, txtCep);


                //EVENTO LEAVE A TODO MOMENTO SEM PRECISAR APERTAR QUALQUER TECLAR ELE IRA VERIFICAR OS CEPS

                /*if (BuscaEndereco.verificaCEP(txtCep.Text) == true)
                {

                    txtBairro.Text = BuscaEndereco.bairro;
                    txtEstado.Text = BuscaEndereco.estado;
                    txtCidade.Text = BuscaEndereco.cidade;
                    txtRua.Text = BuscaEndereco.endereco;
                }
                else
                {
                    //PODE LIMPAR OS CAMPOS 
                }*/
            }
        }




        private void txtCPFCNPJ_Leave_1(object sender, EventArgs e)
        {

                                            //PARA VALIDAÇAO DO CPF E CNPJ, PODE USAR MASKEDTEXTBOX
            lbValorIncorreto.Visible = false;


            if (rbFisica.Checked == true)
            {

                if (Validacao.iscpf(txtCPFCNPJ.Text) == false)       //SIGNIFICA QUE USUARIO DIGITOU VALOR INCORRETO !
                {
                    lbValorIncorreto.Visible = true;                        //ATIVA "numero incorreto " !
                }
            }
            else
            {

                if (Validacao.iscnpj(txtCPFCNPJ.Text) == false)      //SIGNIFICA QUE USUARIO DIGITOU VALOR INCORRETO !
                {

                    lbValorIncorreto.Visible = true;
                }

            }
        }

        private void txtCPFCNPJ_KeyPress_1(object sender, KeyPressEventArgs e)
        {

           if (e.KeyChar != (char)8)
            {

                Campo edit = Campo.CPF;

                if (rbFisica.Checked == false)
                {

                    edit = Campo.CNPJ;
                    Formatar(edit, txtCPFCNPJ);
                }
                else
                {

                    edit = Campo.CPF;
                    Formatar(edit, txtCPFCNPJ);
                }
            }
        }
    }
}