using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DLL;
using Modelo;

namespace GUI
{
    public partial class Frm_CadastroProduto : Form
    {
        Frm_ModeloDeFormularioDeCadastro frm = new Frm_ModeloDeFormularioDeCadastro();

        Frm_CadastroCategoria frm2 = new Frm_CadastroCategoria();

        //Se estiver em branco nao existe foto. Se tiver algum valor == escolheu outra foto para colocar
        public string foto = "";

        public Frm_CadastroProduto()
        {            
            InitializeComponent();
        }

        public void AlterarBotoes(int op)       //gambiarra, arrumar depois...erro por conta de nao ter erdado o FRMmodelodefurmulariodecadastro
        {
            //Esse metodo existe dentro do Modelodeformulario de cadastro, e nao deve existir outro... ele deve ser chamado
            //passando as funcionalidade dele corretamente.
            pnDados.Enabled = false;
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
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQtde.Clear();

            foto = "";      //FOTO == VAZIO
            pbFoto.Image = null;        //FOTO == NULL

        }

        private void Frm_CadastroProduto_Load(object sender, EventArgs e)       //COMBO BOX DA CATEGORIA
        {
            AlterarBotoes(1);

            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bllCategoria = new BLLCategoria(dalConexao);


            //FONTE DE DADO DELE. RECEBE O VALOR CONTIDO
            cbCategoria.DataSource = bllCategoria.Localizar("");        //DATASOURCE == pega todas as propriedades do objeto pra preencher no DataSource. 
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";
            //alto completar
            cbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;        //tipo que sera de alto completar(SUGESTAO)
            cbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;  //itens do proprio combo box
            try
            {

                //COMBO BOX DA SUB CATEGOPRIA==
                BLLSubCategoria bllsubCategoria = new BLLSubCategoria(dalConexao);
                cbSubcategoria.DataSource = bllsubCategoria.LocalizaPorCategoria(Convert.ToInt32(cbCategoria.SelectedValue)); //CARREGA COMBO BOX, PASSANDO COMO PARAMETRO O CODIGO DA CATEGORIA QUE ESTÁ VINCULADO A SUBCATEGORIA . O RETORNO DO METODO ! 
                cbSubcategoria.DisplayMember = "scat_nome"; //mostra nome da subcategoria e passa para o campo do combo box
                cbSubcategoria.ValueMember = "scat_cod";    //mostra codigo da subcategoria e passa para o campo do combo box 

               

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            //UNIDADE DE MEDIDA==
            BLLUnidadeDeMedida bllunidadedeMedida = new BLLUnidadeDeMedida(dalConexao);
            cbUnidadeMedida.DataSource = bllunidadedeMedida.localizar("");                        //VAI RECEBER O RETORNO DO METODO ! 
            cbUnidadeMedida.DisplayMember = "umed_nome";
            cbUnidadeMedida.ValueMember = "umed_cod";
        }
        private void btInserir_Click(object sender, EventArgs e)
        {
            AlterarBotoes(2);
            frm.Operacao = "inserir";           
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(",") == false)        //nao conter o ponto
            {

                txtValorVenda.Text += ",00";        //adiciona
            }
            else
            {

                if (txtValorVenda.Text.IndexOf(",") == txtValorVenda.Text.Length - 1)        //se o PONTO é o ultimo catacter do texto
                {
                    txtValorVenda.Text += ",00";     //adiciona mais DOIS zeros
                }
            }
            try
            {

                double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {

                txtValorVenda.Text = "0,00";
            }
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {

                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {

                if (!txtValorPago.Text.Contains(","))
                {

                    e.KeyChar = ',';
                }
                else
                {

                    e.Handled = true;
                }
            }
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(",") == false)        //nao conter o ponto
            {
                txtValorPago.Text += ",00";        //adiciona
            }
            else
            {
                if (txtValorPago.Text.IndexOf(",") == txtValorPago.Text.Length - 1)        //se o PONTO é o ultimo catacter do texto
                {
                    txtValorPago.Text += "00";     //adiciona mais DOIS zeros
                }
            }
            try
            {
                double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0,00";
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {       //CODIGO QUE INCREMENTA VIRGULAS OU PONTO E ZEROS NOS VALORES DE QUANTIDADE


            //if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == ',' || e.KeyChar == '.')
            //{
            //    if (!txtQtde.Text.Contains("."))
            //    {
            //        e.KeyChar = '.';
            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
        }
        private void txtQtde_Leave(object sender, EventArgs e)
        {       //CODIGO QUE INCREMENTA ZEROS APOS O NUMERO DIGITADO !


            //if (txtQtde.Text.Contains(".") == false)        //nao conter o ponto
            //{
            //    txtQtde.Text += ".00";        //adiciona
            //}
            //else
            //{
            //    if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length -1)        //se o PONTO é o ultimo catacter do texto
            //    {
            //        txtQtde.Text += "00";     //adiciona mais DOIS zeros
            //    }
            //}
            //try
            //{
            //    double d = Convert.ToDouble(txtQtde.Text);      //AULA 31 FALANDO SOBRE A VALIDAÇÃO, REVER
            //}
            //catch
            //{
            //    txtQtde.Text = "0.00";
            //}

        }

        private void btAlterar_Click(object sender, EventArgs e)        //BOTAO ALTERAR(PRODUTO)
        {
            frm.Operacao = "alterar";
            AlterarBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)//BOTAO EXCLUIR(PRODUTO)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o produto ?", " Aviso", MessageBoxButtons.YesNo);

                if (dialogResult.ToString() == "Yes")
                {
                    DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLProduto bllProduto = new BLLProduto(dalConexao);
                    bllProduto.Excluir(Convert.ToInt32(txtCodigo.Text));

                    frm2.LimpaTela();
                    this.AlterarBotoes(1);                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Impossivél excluir o registro. \nO registro está sendo utilizado em outro local !");
            }                  
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)//quando mudar o indice selecionado !
        {

            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);            

            try
            {

                cbSubcategoria.Text = "";

                //COMBO BOX DA SUB CATEGOPRIA==
                BLLSubCategoria bllsubCategoria = new BLLSubCategoria(dalConexao);
                cbSubcategoria.DataSource = bllsubCategoria.LocalizaPorCategoria(Convert.ToInt32(cbSubcategoria.SelectedValue)); //CARREGA COMBO BOX, PASSANDO COMO PARAMETRO O CODIGO DA CATEGORIA QUE ESTÁ VINCULADO A SUBCATEGORIA . O RETORNO DO METODO ! 
                cbSubcategoria.DisplayMember = "scat_cod"; //mostra nome da subcategoria e passa para o campo do combo box
                cbSubcategoria.ValueMember = "scat_nome";    //mostra codigo da subcategoria e passa para o campo do combo box

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();     //OpenFileDialog é usado para localizar/selecionar arquivos em um computador.

            openFile.ShowDialog();      //Abre o arquivo

            if (!string.IsNullOrEmpty(openFile.FileName))    //NULA OU VAZIA, SE FOR DIFERENTE DISSO
            {
                //PROPRIEDADE FOTO RECEBE OQUE OPEN FILE ESTA ARMAZENANDO
                foto = openFile.FileName;       //FILENAME == contém o nome do arquivo selecionado na caixa de diálogo do arquivo
                pbFoto.Load(foto);              //CARREGA A FOTO
            }
        }        

        private void btCancelar_Click(object sender, EventArgs e)
        {

            this.AlterarBotoes(1);
            this.LimpaTela();

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {       //SALVAR OU ALTERAR UM CATEGORIA !
            try
            {

                ModeloProdutos modeloProduto = new ModeloProdutos();
                modeloProduto.ProNome = txtNome.Text;
                modeloProduto.ProDescricao = txtDescricao.Text;
                modeloProduto.ProValorPago = Convert.ToDouble(txtValorPago.Text);
                modeloProduto.ProValorVenda = Convert.ToDouble(txtValorVenda.Text);
                modeloProduto.ProQtde = Convert.ToInt32(txtQtde.Text);
                modeloProduto.UmedCod = Convert.ToInt32(cbUnidadeMedida.SelectedValue);     //ARMAZENA O CODIGO DA UNIDADE DE MEDIDA, PARA O CAMPO CODIGO !
                modeloProduto.CatCod = Convert.ToInt32(cbCategoria.SelectedValue);
                modeloProduto.ScatCod = Convert.ToInt32(cbSubcategoria.SelectedValue);

                
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bllProduto = new BLLProduto(dalConexao);

                if (frm.Operacao == "inserir")
                {   //CADASTRAR UMA NOVA CATEGORIA !

                    modeloProduto.CarregaImagem(foto);      //VALOR EM BRANCO == NAO FAZ NADA . TIVER ALGO == CRIA VETOR E ARMAZERA DENTRO
                    bllProduto.Incluir(modeloProduto);
                    MessageBox.Show("Cadastro efetuado com sucesso: Código " + modeloProduto.ProCod.ToString());

                }
                else
                {   //ALTERAR UMA CATEGORIA !

                    modeloProduto.ProCod = Convert.ToInt32(txtCodigo.Text);

                    if (this.foto == "Foto Original")
                    {

                        ModeloProdutos ms = bllProduto.CarregaModeloProduto(modeloProduto.ProCod);
                        modeloProduto.ProFoto = ms.ProFoto;                            
                    }
                    else
                    {

                        modeloProduto.CarregaImagem(this.foto);
                    }
                    
                    bllProduto.Alterar(modeloProduto);
                    MessageBox.Show("Cadastro alterado !");
                }

                LimpaTela();
                AlterarBotoes(1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            Frm_ConsultaProduto consultaProduto = new Frm_ConsultaProduto();
            consultaProduto.ShowDialog();

            if (consultaProduto.codigo != 0)
            {

                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bllProduto = new BLLProduto(dalConexao);
                ModeloProdutos modeloProduto = bllProduto.CarregaModeloProduto(consultaProduto.codigo); //parametro passando codigo que esta no formulario
                txtCodigo.Text = modeloProduto.CatCod.ToString();       

                //-----------COLOCA DADOS NA TELA---------------
                txtCodigo.Text = modeloProduto.ProCod.ToString(); //txtCodigo.text == PROCOD
                txtDescricao.Text = modeloProduto.ProDescricao;
                txtNome.Text = modeloProduto.ProNome;
                txtQtde.Text = modeloProduto.ProQtde.ToString();
                txtValorPago.Text = modeloProduto.ProValorPago.ToString();
                txtValorVenda.Text = modeloProduto.ProValorVenda.ToString();

                cbCategoria.SelectedValue = modeloProduto.CatCod;       //combobox categoria == categoria
                cbSubcategoria.SelectedValue = modeloProduto.ScatCod;
                cbUnidadeMedida.SelectedValue = modeloProduto.UmedCod;

                try
                {
                    //Cria um Image por meio do fluxo de dados especificado 
                    //opcionalmente usando as informações de gerenciamento 
                    //de cores inseridas e validando os dados da imagem.

                    MemoryStream ms = new MemoryStream(modeloProduto.ProFoto);  //PEGA VETOR QUE REPRESENTA FOTO E GUARDA NA MEMORYSTREAM      
                    pbFoto.Image = Image.FromStream(ms);        //RECEBE UMA IMAGEM QUE SERA CONVERTIDA DE UM DADO // Cria um Image do fluxo de dados especificado.
                    this.foto = "Foto Original";        //FOTO QUE ESTARA DENTRO DA MEMORIA DO COMPUTADOR !
                }
                catch { }

                AlterarBotoes(3);
            }
            
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {

        }

        private void cbSubcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }       

        private void btAdd_Categoria_Click(object sender, EventArgs e)
        {
            Frm_CadastroCategoria cadastroCategoria = new Frm_CadastroCategoria();
            cadastroCategoria.ShowDialog();
            cadastroCategoria.Dispose();

            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bllCategoria = new BLLCategoria(dalConexao);

            //FONTE DE DADO DELE. RECEBE O VALOR CONTIDO
            cbCategoria.DataSource = bllCategoria.Localizar("");        //DATASOURCE == pega todas as propriedades do objeto pra preencher no DataSource. 
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";

            try
            {

                //COMBO BOX DA SUB CATEGOPRIA==
                BLLSubCategoria _bllsubCategoria = new BLLSubCategoria(dalConexao);
                cbSubcategoria.DataSource = _bllsubCategoria.LocalizaPorCategoria((int)cbCategoria.SelectedValue); //CARREGA COMBO BOX, PASSANDO COMO PARAMETRO O CODIGO DA CATEGORIA QUE ESTÁ VINCULADO A SUBCATEGORIA . O RETORNO DO METODO ! 
                cbSubcategoria.DisplayMember = "scat_nome"; //mostra nome da subcategoria e passa para o campo do combo box
                cbSubcategoria.ValueMember = "scat_cod";    //mostra codigo da subcategoria e passa para o campo do combo box              

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        private void btAdd_Sub_Click(object sender, EventArgs e)
        {

            Frm_CadastroSubCategoria subCategoria = new Frm_CadastroSubCategoria();
            subCategoria.ShowDialog();
            subCategoria.Dispose();
            
            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);                

            try
            {

                //COMBO BOX DA SUB CATEGOPRIA==
                BLLSubCategoria bllsubCategoria = new BLLSubCategoria(dalConexao);
                cbSubcategoria.DataSource = bllsubCategoria.LocalizaPorCategoria(Convert.ToInt32(cbCategoria.SelectedValue)); //CARREGA COMBO BOX, PASSANDO COMO PARAMETRO O CODIGO DA CATEGORIA QUE ESTÁ VINCULADO A SUBCATEGORIA . O RETORNO DO METODO ! 
                cbSubcategoria.DisplayMember = "scat_nome"; //mostra nome da subcategoria e passa para o campo do combo box
                cbSubcategoria.ValueMember = "scat_cod";    //mostra codigo da subcategoria e passa para o campo do combo box              

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void btAdd_Und_Click(object sender, EventArgs e)
        {

            Frm_CadastroUnidadeDeMedida unidadeDeMedida = new Frm_CadastroUnidadeDeMedida();
            unidadeDeMedida.ShowDialog();
            unidadeDeMedida.Dispose();

            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUnidadeDeMedida bllMedida = new BLLUnidadeDeMedida(dalConexao);


            cbUnidadeMedida.DataSource = bllMedida.localizar("");
            cbUnidadeMedida.DisplayMember = "umed_nome";
            cbUnidadeMedida.ValueMember = "umed_cod";
        }
    }    
}
