using System;
using Modelo;
using DAL;
using DLL;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_CadastroCategoria : GUI.Frm_ModeloDeFormularioDeCadastro
    {   
        public Frm_CadastroCategoria()
        {
            InitializeComponent();
        }
        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }
        private void Frm_CadastroCategoria_Load(object sender, EventArgs e)
        {
            this.AlterarBotoes(1);
        }
        private void btInserir_Click(object sender, EventArgs e)
        {
            this.Operacao = "inserir";
            this.AlterarBotoes(2);
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.AlterarBotoes(1);
        }
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                                                //criar uma conexao
                ModeloCategoria modelo = new ModeloCategoria();
                modelo.CatNome = txtNome.Text;
                                                    //objeto para gravar os dados do banco  
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria BLL = new BLLCategoria(cx);

                if (Operacao == "inserir")
                {
                    
                    BLL.Incluir(modelo);                        //CADASTRA NOVA CATEGORIA
                   MessageBox.Show("Cadastro efetuado : codigo " + modelo.CatCod.ToString());                   
                }
                else
                {
                    modelo.CatCod = Convert.ToInt32(txtCodigo.Text);    //ALTERA UMA CATEGORIA
                    BLL.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }
                LimpaTela();
                AlterarBotoes(1);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btAlterar_Click(object sender, EventArgs e)
        {
            Operacao = "Alterar"; 
            AlterarBotoes(2);
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _dialogResult = MessageBox.Show("Deseja realmente exlcuir o registro ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_dialogResult.ToString() == "Yes")
                {
                    DALConexao _dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLCategoria _bllCategoria = new BLLCategoria(_dalConexao);
                    _bllCategoria.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.AlterarBotoes(2);
                    this.LimpaTela();
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro.\nO registro esta sendo utilizado em outro local.");
                AlterarBotoes(3);                
            }
        }
        private void btLocalizar_Click(object sender, EventArgs e)
        {

            Frm_ConsultaCategoria consultaCategoria = new Frm_ConsultaCategoria();         //CRIA O FORMULARIO DE CONSULTA DA CATEGORIA
            consultaCategoria.ShowDialog();                                                //EXIBE O FORMULARIO

            if (consultaCategoria.Codigo != 0)       //VERIFICA SE O CODIGO É DIFERENTE DE 0 - ENTAO ELE SELECIONOU UMA CATEGORIA PARA ALTERAR
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);        //CRIA A CONEXAO
                BLLCategoria bllCategoria = new BLLCategoria(dalConexao);                     //CRIA A CONEXAO

                ModeloCategoria modeloCategoria = bllCategoria.CarregaModeloCategoria(consultaCategoria.Codigo); //CRIA O DLL. carrega o modelo ! Apartir do modelo criado por meio do CarregaModelo, e tem como parametro o CODIGO  que o usuario selecionou.
                txtCodigo.Text = modeloCategoria.CatCod.ToString();                //PEGA AS INFORMACOES E VOLTA NA TELA
                txtNome.Text = modeloCategoria.CatNome;                        //PEGA AS INFORMACOES E VOLTA NA TELA

                AlterarBotoes(3);
            }
            else
            {
                LimpaTela();
                AlterarBotoes(1);
            }
            consultaCategoria.Dispose();

        }

        private void BOTAODOIGOR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IGOR É VIADIN");
        }
    }
}
