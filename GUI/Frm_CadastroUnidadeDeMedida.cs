using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using DLL;
using Modelo;

namespace GUI
{
    public partial class Frm_CadastroUnidadeDeMedida : GUI.Frm_ModeloDeFormularioDeCadastro
    {
        public Frm_CadastroUnidadeDeMedida()
        {
            InitializeComponent();
        }

        public void LimpaTela()
        {
            txtCod.Clear();
            txtUnidadeMedida.Clear();
        }

      
        private void btInserir_Click(object sender, EventArgs e)
        {
            Operacao = "inserir";
            AlterarBotoes(2);

        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            Operacao = "alterar";
            AlterarBotoes(2);

            txtUnidadeMedida.Focus();
            txtUnidadeMedida.TabIndex = 0;            
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //cria uma caixa de dialogo
                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o registro ?", "Aviso", MessageBoxButtons.YesNo);

                if (dialogResult.ToString() == "Yes")       //se for sim
                {
                    DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);     //cria dal conexao com 2 parametros
                    BLLUnidadeDeMedida bllunidadedeMedida = new BLLUnidadeDeMedida(dalConexao); //cria unidademedida passando 1 parametro
                    bllunidadedeMedida.Excluir(Convert.ToInt32(txtCod.Text));       //chama EXCLUIR e convert oque ta no campo txtCod para inteiro.

                    //MessageBox.Show("Item excluido com sucesso !", "Aviso", MessageBoxButtons.OK);
                }
                LimpaTela();                    
                AlterarBotoes(1);                
            }
            catch (Exception)
            {
                throw new Exception("Impóssivel excluir o registro. \n O registro está sendo utilizado em outro local !");
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            ModeloUnidadeDeMedida modelounidadedeMedida = new ModeloUnidadeDeMedida();  //criar modelo da unidade medida              
            modelounidadedeMedida.UmedNome = txtUnidadeMedida.Text;     //preenche o modelo pegando o nome da tela da unidade medida

            DALConexao dalconexao = new DALConexao(DadosDaConexao.StringDeConexao);     //cria conexao
            BLLUnidadeDeMedida bllunidadedeMedida = new BLLUnidadeDeMedida(dalconexao);     //cria bll       

            //if (modelounidadedeMedida.UmedCod.Length == 1)
            //{
            //    if (Operacao == "inserir")      //se for inserir
            //    {
            //        //salvar
            //        bllunidadedeMedida.Incluir(modelounidadedeMedida);
            //        MessageBox.Show("Cadastro efetuado com sucesso ! \n Código :" + modelounidadedeMedida.UmedCod.ToString());      //mensagem ao usuario
            //    }
            //}
            if (Operacao == "inserir")      //se for inserir
            {
                //salvar
                bllunidadedeMedida.Incluir(modelounidadedeMedida);
                MessageBox.Show("Cadastro efetuado com sucesso :\n Código " + modelounidadedeMedida.UmedCod.ToString());      //mensagem ao usuario
            }
            else
            {
                //alterar
                modelounidadedeMedida.UmedCod = Convert.ToInt32(txtCod.Text);       //le o codigo da unidade medida da tela 
                bllunidadedeMedida.Alterar(modelounidadedeMedida);      //chama o altera
                MessageBox.Show("Cadastro alterado com sucesso !");     //exibe menssagem
            }
            LimpaTela();
            AlterarBotoes(1);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
            AlterarBotoes(1);
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaUnidadeDeMedida frmconsultaunidadedeMedida = new Frm_ConsultaUnidadeDeMedida();     //cria o formulario
            frmconsultaunidadedeMedida.ShowDialog();

            if (frmconsultaunidadedeMedida.Codigo != 0)     //caso usuario tenha colocado um codigo
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);     //cria conexao
                BLLUnidadeDeMedida bllunidadedeMedida = new BLLUnidadeDeMedida(dalConexao);     //cria bll 

                ModeloUnidadeDeMedida modelounidadedeMedida = bllunidadedeMedida.CarregaModeloUnidadeDeMedida(frmconsultaunidadedeMedida.Codigo);    //cria modelo...chama CARREGAMODELO UND MEDIDA...   
                txtCod.Text = modelounidadedeMedida.UmedCod.ToString();     //exibe na tela o retorno
                txtUnidadeMedida.Text = modelounidadedeMedida.UmedNome; //exibe o nome da unidade de medidA

                AlterarBotoes(3);
            }
            else
            {
                LimpaTela();
                AlterarBotoes(1);
            }

        }

        private void txtUnidadeMedida_Leave(object sender, EventArgs e)
        {
            //evento LEAVE - O FOCO DEIXAR O TEXTBOX..QUANDO ELE FOR DEIXAR O TEXTBOX

            
            if (Operacao == "inserir")
            {
                int R = 0;

                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUnidadeDeMedida bllunidadedeMedida = new BLLUnidadeDeMedida(dalConexao);

                R = bllunidadedeMedida.VerificaUnidadeDeMedida(txtUnidadeMedida.Text);

                if (R > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Já existe um registro com esse valor. \n Deseja alterar o registro ?", "Aviso", MessageBoxButtons.YesNo);
                    if (dialogResult.ToString() == "Yes")
                    {
                        txtUnidadeMedida.Focus();

                        Operacao = "alterar";

                        ModeloUnidadeDeMedida modelo = bllunidadedeMedida.CarregaModeloUnidadeDeMedida(R);
                        txtCod.Text = modelo.UmedCod.ToString();
                        txtUnidadeMedida.Text = modelo.UmedNome;
                        //AlterarBotoes(3);

                        //REVER VIDEO E COMENTAR TUDO, ENTENDENDO PASSO A PASSO OQUE FOI FEITO.
                        //EP 22

                    }
                }
            }
        }

        private void Frm_UnidadeDeMedida_KeyDown(object sender, KeyEventArgs e)
        {
            //,KeyDown == Evento

            //KeyCode ==    lida com pressionamentos de tecla. 
            //Você tem um controle TextBox no aplicativo Windows Forms e 
            //precisa detectar Enter.O TextBox permite que seus usuários 
            //digitem letras nele, e você precisa detectar quando uma certa tecla é pressionada.

            //Keys == Um valor Keys que é o código de tecla do evento

            if (e.KeyCode == Keys.Enter)
            {
                //SelectNextControl ==  
                SelectNextControl(ActiveControl, e.Shift, true, true, true);
            }
         
        }
    }          
}
