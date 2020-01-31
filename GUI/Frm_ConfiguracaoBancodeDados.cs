using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace GUI
{
    public partial class Frm_ConfiguracaoBancodeDados : Form
    {
        public Frm_ConfiguracaoBancodeDados()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            // C:\Users\Diego Perillo\Desktop\Projetos Visual Studio\ControleDeEstoque\ControleDeEstoque\GUI\bin\Debug

            //PEGA DADOS DA TELA E GRAVA

            //StreamWriter objeto para gravar um arquivo que lista os diretórios na unidade C e, em seguida, 
            //usa StreamReader um objeto para ler e exibir cada nome de diretório.
            try
            {
                //CRIA OU ABRE UM ARQUIVO TEXTO.
                //CRIA NO LUGAR QUE O EXECUTAVEL DO PROGRAMA ESTA.
                //GRAVARA OS DADOS NO ARQUIVO
                //FECHARA
                //SE DER ERRO CAI NO CATCH

                StreamWriter arquivo = new StreamWriter("configuracaoBanco.txt", false); //CRIA ARQUIVO TEXTO, OU ABRIR ARQUIVO TEXTO... TRUE, INFORMA QUE PODE EDITAR O ARQUIVO. ASCII TIPO DE CODIFICAÇÃO
                arquivo.WriteLine(txtServidor.Text);        //MANDA ESCREVER A LINHA NO ARQUIVO.
                arquivo.WriteLine(txtBanco.Text);           //MANDA ESCREVER A LINHA NO ARQUIVO.
                arquivo.WriteLine(txtUsuario.Text);         //MANDA ESCREVER A LINHA NO ARQUIVO.
                arquivo.WriteLine(txtSenha.Text);           //MANDA ESCREVER A LINHA NO ARQUIVO.
                arquivo.Close();

                MessageBox.Show("Arquivo atualizado com sucesso !");
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void Frm_ConfiguracaoBancodeDados_Load(object sender, EventArgs e)
        {   //IRÁ ACESSAR OS DADOS DO ARQUIVO TEXTO E IRÁ PREENCHER OS DADOS NA TELA.


            try
            {      //um objeto para ler e exibir cada nome de diretório. 
                
                StreamReader arquivo = new StreamReader("configuracaoBanco.txt");
                txtServidor.Text = arquivo.ReadLine();      //LÊ AS LINHAS DO ARQUIVO E GUARDA NO CAMPO TXT
                txtBanco.Text = arquivo.ReadLine();         //LÊ AS LINHAS DO ARQUIVO E GUARDA NO CAMPO TXT
                txtUsuario.Text = arquivo.ReadLine();       //LÊ AS LINHAS DO ARQUIVO E GUARDA NO CAMPO TXT
                txtSenha.Text = arquivo.ReadLine();         //LÊ AS LINHAS DO ARQUIVO E GUARDA NO CAMPO TXT
                arquivo.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btTestar_Click(object sender, EventArgs e)
        {
            try
            {
                DadosDaConexao.Servidor = txtServidor.Text;
                DadosDaConexao.Banco = txtBanco.Text;
                DadosDaConexao.Usuario = txtUsuario.Text;
                DadosDaConexao.Senha = txtSenha.Text;

                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DadosDaConexao.StringDeConexao;
                conexao.Open();
                conexao.Close();

                MessageBox.Show("Conexao efetuada com sucesso !");

            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao se conectar ao Bando de Dados. Verifique !");
            }
            
        }
    }
}
