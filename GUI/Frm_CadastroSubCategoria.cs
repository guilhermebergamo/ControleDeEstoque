using DAL;
using DLL;
using Modelo;
using System;
using System.Windows.Forms;


namespace GUI
{
    public partial class Frm_CadastroSubCategoria : GUI.Frm_ModeloDeFormularioDeCadastro
    {
        public Frm_CadastroSubCategoria()
        {
            InitializeComponent();
        }
        public void LimpaTela()
        {
            txt_Nome.Clear();
            txt_ScatCod.Clear();
        }               
        private void lblNomeCategoria_Click(object sender, EventArgs e)
        {

        }
        private void Frm_CadastroSubCategoria_Load(object sender, EventArgs e)
        {
            AlterarBotoes(1);
            DALConexao _Codigo = new DALConexao(DadosDaConexao.StringDeConexao);        //CRIA A CONEXAO
            BLLCategoria _bllCategoria = new BLLCategoria(_Codigo);     //CRIA BLL DA CATEGORIA

            //COMBO BOX
            cb_CatCod.DataSource = _bllCategoria.Localizar("");     //DATASOURCE - SERVE PARA INDICAR A ORIGEM DOS DADOS -- PASSANDO TEXTO EM BRANCO PARA RETORNAR TODAS AS CATEGORIAS
            cb_CatCod.DisplayMember = "cat_nome";       //DISPLAYMEMBER = PARA INDICAR QUAL CAMPO ELE MOSTRARA NA TELA. CAMPO QUE CONTERá DENTRO DO DATASOURCE. QUERO QUE MOSTRE O CAMPO cat_nome
            cb_CatCod.ValueMember = "cat_cod";      //VALUEMEMBER = PARA GUARDAR O VALOR...ESTÁ GUARDANDO O VALOR CAT_COD              

        }
        private void btInserir_Click(object sender, EventArgs e)
        {
            AlterarBotoes(2);
            Operacao = "inserir";
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoes(1);
            LimpaTela();
        }
        private void btAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoes(2);
            Operacao = "alterar";
        }
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloSubCategoria modelosubCategoria = new ModeloSubCategoria();
                modelosubCategoria.ScatNome = txt_Nome.Text;       //ler os valores da tela
                modelosubCategoria.CatCod = Convert.ToInt32(cb_CatCod.SelectedValue);  //ler os valores da tela -- SelectedValue = VALOR SELECIONADO
                //GRAVA OS DADOS NO BANCO
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);        //CRIA CONEXAO
                BLLSubCategoria bllsubCategoria = new BLLSubCategoria(dalConexao);        //CRIA DLL DA SUBCATEGORIA

                if (Operacao == "inserir")
                {

                    bllsubCategoria.Incluir(modelosubCategoria);      //CHAMA INCLUIR
                    MessageBox.Show("Cadastro efetuado com sucesso : Código " + modelosubCategoria.ScatCod.ToString());  //MOSTRA NA TELA A MENSAGEM           
                }
                else
                {
                    //ALTERAR UMA CATEGORIA
                    modelosubCategoria.ScatCod = Convert.ToInt32(txt_ScatCod.Text);        //ler o codigo da subcategoria e pegar o valor da tela
                    bllsubCategoria.Alterar(modelosubCategoria);      //chama o ALTERAR
                    MessageBox.Show("Cadastro alterado com sucesso !");
                }
                LimpaTela();
                AlterarBotoes(1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);        //qualquer erro que der sera exibido uma mensagem na tela
            }       
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o registro ? ", "Aviso", MessageBoxButtons.YesNo);
                if (dialogResult.ToString() == "Yes")
                {
                    DALConexao dallConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLSubCategoria bllsubCategoria = new BLLSubCategoria(dallConexao);
                    bllsubCategoria.Excluir(Convert.ToInt32(txt_ScatCod.Text));
                    LimpaTela();
                    AlterarBotoes(1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outro local .");
                AlterarBotoes(3);
            }
        }
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaSubCategoria frmconsultasubCategoria = new Frm_ConsultaSubCategoria();     //cria formulario de consulta
            frmconsultasubCategoria.ShowDialog();      //Mostra na tela
            if (frmconsultasubCategoria.Codigo != 0)       //Se o codigo for diferente
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);        //cria a DAL 
                BLLSubCategoria consultasubCategoria = new BLLSubCategoria(dalConexao);       //Cria o BLL da subcategoria - passando pelo construtor
                ModeloSubCategoria modelosubCategoria = consultasubCategoria.CarregaModeloSubCategoria(frmconsultasubCategoria.Codigo);  //cria modelo da subcategoria. Chama CarregaModelo pda Subcat e preeenchendo a tela com os valores do codigo da subcategoria, com nome da subcategoria
                txt_ScatCod.Text = modelosubCategoria.ScatCod.ToString();        //preenche a tela com os valores 
                txt_Nome.Text = modelosubCategoria.ScatNome;       //preenche a tela com os valores 

                cb_CatCod.SelectedValue = modelosubCategoria.CatCod;       //combobox. pega valor do modelo,modifica o que esta exibindo na tela
                AlterarBotoes(3);       
            }
            else
            {
                LimpaTela();
                AlterarBotoes(1);
            }
            frmconsultasubCategoria.Dispose();
        }

        private void Frm_CadastroSubCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            //pula de um campo para o outro usando a tecla INTER 
            if (e.KeyCode == Keys.Enter)    
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);       //fazer com que uj
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Frm_CadastroCategoria cadastroCategoria = new Frm_CadastroCategoria();
            cadastroCategoria.ShowDialog();
            cadastroCategoria.Dispose();

            DALConexao _Codigo = new DALConexao(DadosDaConexao.StringDeConexao);        //CRIA A CONEXAO
            BLLCategoria _bllCategoria = new BLLCategoria(_Codigo);     //CRIA BLL DA CATEGORIA

            //COMBO BOX
            cb_CatCod.DataSource = _bllCategoria.Localizar("");     //DATASOURCE - SERVE PARA INDICAR A ORIGEM DOS DADOS -- PASSANDO TEXTO EM BRANCO PARA RETORNAR TODAS AS CATEGORIAS
            cb_CatCod.DisplayMember = "cat_nome";       //DISPLAYMEMBER = PARA INDICAR QUAL CAMPO ELE MOSTRARA NA TELA. CAMPO QUE CONTERá DENTRO DO DATASOURCE. QUERO QUE MOSTRE O CAMPO cat_nome
            cb_CatCod.ValueMember = "cat_cod";      //VALUEMEMBER = PARA GUARDAR O VALOR...ESTÁ GUARDANDO O VALOR CAT_COD              

        }
    }
}      
