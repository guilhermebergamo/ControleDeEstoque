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
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }
        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CadastroCategoria _CadastroCategoria = new  Frm_CadastroCategoria();
            _CadastroCategoria.ShowDialog();                   //ShowDialog chama o Formulario e nao permite que o ususario faça outra coisa coisa na tela.
            _CadastroCategoria.Dispose();                      //Para encessar o objeto que criamos....Abre o formulario e depois elimina !
        }
        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaCategoria consultaCategoria = new Frm_ConsultaCategoria();
            consultaCategoria.ShowDialog();
            consultaCategoria.Dispose();
        }

        private void subCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CadastroSubCategoria _frmsubCategoria = new Frm_CadastroSubCategoria();
            _frmsubCategoria.ShowDialog();
            _frmsubCategoria.Dispose();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaSubCategoria _frmconsultasubCategoria = new Frm_ConsultaSubCategoria();
            _frmconsultasubCategoria.ShowDialog();
            _frmconsultasubCategoria.Dispose();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CadastroUnidadeDeMedida frm_unidadedeMedida = new Frm_CadastroUnidadeDeMedida();
            frm_unidadedeMedida.ShowDialog();
            frm_unidadedeMedida.Dispose();
        }

        private void subToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ConsultaUnidadeDeMedida frmconsultaunidadedeMedida = new Frm_ConsultaUnidadeDeMedida();
            frmconsultaunidadedeMedida.ShowDialog();
            frmconsultaunidadedeMedida.Dispose();

        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CadastroFornecedor frmFornecedor = new Frm_CadastroFornecedor();
            frmFornecedor.ShowDialog();
            frmFornecedor.Dispose();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CadastroProduto cadastroProduto = new Frm_CadastroProduto();
            cadastroProduto.ShowDialog();
            cadastroProduto.Dispose();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaProduto consultaProduto = new Frm_ConsultaProduto();
            consultaProduto.ShowDialog();
            consultaProduto.Dispose();
        }

        private void confifuraçõesBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ConfiguracaoBancodeDados configuracaoBancodeDados = new Frm_ConfiguracaoBancodeDados();
            configuracaoBancodeDados.ShowDialog();
            configuracaoBancodeDados.Dispose();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");       //ABRE CALCULADOR DO WINDONS 
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer");   //ABRE EXPLORER DO WINDONS
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");    //ABRE BLOCO DE NOTAS ADO WINDONS
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
                //VERIFICA CONEXAO COM O BANCO.
            try
            {
                StreamReader arquivo = new StreamReader("configuracaoBanco.txt");       //ABRE ARQUIVO TEXTO.
                DadosDaConexao.Servidor = arquivo.ReadLine();                           //LÊ OS ARQUIVO TEXTO E ARMAZENA
                DadosDaConexao.Banco = arquivo.ReadLine();                              //LÊ OS ARQUIVO TEXTO E ARMAZENA
                DadosDaConexao.Usuario = arquivo.ReadLine();                            //LÊ OS ARQUIVO TEXTO E ARMAZENA
                DadosDaConexao.Senha = arquivo.ReadLine();                              //LÊ OS ARQUIVO TEXTO E ARMAZENA
                arquivo.Close();                                        //ABRE

                //---TESTA CONEXAO--

                SqlConnection conexao = new SqlConnection();                            //CRIA CONEXAO PARA TESTE
                conexao.ConnectionString = DadosDaConexao.StringDeConexao;          //PASSA A STRING CONEXAO
                conexao.Open();
                conexao.Close();

            }
            catch (SqlException)        //SE DER ERRO DE BANCO
            {  

                MessageBox.Show("Erro ao se conectar no Banco\n"+
                                "Acesse as Ferramentas / Configurações, e informe os parâmetros de conexao !");
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }

        private void backupBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_BackupBancoDeDados backupbancodeDados = new Frm_BackupBancoDeDados();
            backupbancodeDados.ShowDialog();
            backupbancodeDados.Dispose();
        }

        private void tipoDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_CadastroTipoDePagamento tipoPagamento = new Frm_CadastroTipoDePagamento();
            tipoPagamento.ShowDialog();
            tipoPagamento.Dispose();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_CadastroCliente cadastroCliente = new Frm_CadastroCliente();
            cadastroCliente.ShowDialog();
            cadastroCliente.Dispose();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaCliente consultaCliente = new Frm_ConsultaCliente();
            consultaCliente.ShowDialog();
            consultaCliente.Dispose();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaFornecedor consultaFornecedor = new Frm_ConsultaFornecedor();
            consultaFornecedor.ShowDialog();
            consultaFornecedor.Dispose();
        }

        private void tipoDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaTipoPagamento tipoPagamento = new Frm_ConsultaTipoPagamento();
            tipoPagamento.ShowDialog();
            tipoPagamento.Dispose();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Sobre frmSobre = new Frm_Sobre();
            frmSobre.ShowDialog();
            frmSobre.Dispose();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MovimentacaoCompra movimentacaoCompra = new Frm_MovimentacaoCompra();
            movimentacaoCompra.ShowDialog();
            movimentacaoCompra.Dispose();
        }

        private void compraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ConsultaCompra consultaCompra = new Frm_ConsultaCompra();
            consultaCompra.ShowDialog();
            consultaCompra.Dispose();
        }
    }
}
