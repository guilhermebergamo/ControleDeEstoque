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
using System.Windows.Forms;
using DAL;
using DLL;

namespace GUI
{
    public partial class Frm_MovimentacaoCompra : Form
    {

        Frm_ModeloDeFormularioDeCadastro frm = new Frm_ModeloDeFormularioDeCadastro();

        public double TotalCompra = 0;
        public Frm_MovimentacaoCompra()
        {
            InitializeComponent();
        }

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
            txtComCod.Clear();
            txtNfiscal.Clear();
            txtForCod.Clear();
            txtProCod.Clear();
            lProduto.Text = "Informe o código do produto ou clique em localizar";
            lFornecedor.Text = "Informe o código do produto ou clique em localizar";
            txtQtde.Clear();
            txtValor.Clear();
            txtTotalCompra.Clear();
            DgvItens.Rows.Clear();
            
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            frm.Operacao = "Inserir";
            AlterarBotoes(2);
        }


        private void btLocalizar_Click(object sender, EventArgs e)
        {
            /*
             * Frm_ConsultaCliente consultaCliente = new Frm_ConsultaCliente();
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
             */
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            frm.Operacao = "Alterar";
            AlterarBotoes(1);
            TotalCompra = 0;
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            /*
             * try
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
             */
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            dgvParcelas.Rows.Clear();

            int Parcelas = Convert.ToInt32(cbNParcelas.Text);
            
            double TotalLocal = Convert.ToDouble(txtTotalCompra.Text);

            double Valor = TotalLocal / Parcelas;

            DateTime Dt = new DateTime();
            Dt = dtDataInicial.Value;     //DateTime recebe o valor que esta na data

            lbTotal.Text = TotalCompra.ToString();
            

            for (int i = 1; i < Parcelas; i++)
            {
                string[] k = new string[] { i.ToString(), Valor.ToString(), Dt.Date.ToString() };  //VARIAVEL I , VALOR DE CASA PARCELA E A DATA UNICIAL DE COMPRA)
                dgvParcelas.Rows.Add(k);   //adc linha na Grid

                if (Dt.Month != 12)
                {
                    Dt = new DateTime (Dt.Year, Dt.Month + 1, Dt.Day);
                }
                else
                {
                    Dt = new DateTime (Dt.Year + 1, 1 + 1, Dt.Day);
                }

                pnFinalizaCompra.Visible = true;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoes(1);
            LimpaTela();
            TotalCompra = 0;
        }

        private void btLocalizaFornecedor_Click(object sender, EventArgs e)
        {
            Frm_ConsultaFornecedor consultaFornecedor = new Frm_ConsultaFornecedor();
            consultaFornecedor.ShowDialog();

            if (consultaFornecedor.Codigo != 0)
            {
                txtForCod.Text = consultaFornecedor.Codigo.ToString();
                txtForCod_Leave(sender, e);
            }               
        }

        private void txtForCod_Leave(object sender, EventArgs e)
        {
            try
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLFornecedor bllFornecedor = new BLLFornecedor(dalConexao);

                ModeloFornecedor modelo = bllFornecedor.CarregaModeloFornecedor(Convert.ToInt32(txtForCod.Text)); //CRIA O DLL. carrega o modelo ! Apartir do modelo criado por meio do CarregaModelo, e tem como parametro o CODIGO  que o usuario selecionou.

                lFornecedor.Text = modelo.ForNome;      //recebe o nome
            }
            catch 
            {
                txtComCod.Clear(); 
                lFornecedor.Text = "Informe o código do fornecedor ou clique em localizar";
            }
        }

        private void btLocalizarCodigo_Click(object sender, EventArgs e)
        {
            Frm_ConsultaProduto consultaProduto = new Frm_ConsultaProduto();
            consultaProduto.ShowDialog();

            if (consultaProduto.codigo != 0)
            {
                txtProCod.Text = consultaProduto.codigo.ToString();
                txtProCod_Leave(sender, e);
            }         
        }

        private void txtProCod_Leave(object sender, EventArgs e)
        {
            try
            {
                DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bllProduto = new BLLProduto(dalConexao);

                ModeloProdutos modelo = bllProduto.CarregaModeloProduto(Convert.ToInt32(txtProCod.Text)); //CRIA O DLL. carrega o modelo ! Apartir do modelo criado por meio do CarregaModelo, e tem como parametro o CODIGO  que o usuario selecionou.

                lProduto.Text = modelo.ProNome;      //recebe o nome
                txtQtde.Text = "1";
                txtValor.Text = modelo.ProValorPago.ToString();
            }
            catch
            {
                txtForCod.Clear();
                lProduto.Text = "Informe o código do produto ou clique em localizar";
            }
        }

        private void btAddProd_Click(object sender, EventArgs e)
        {
            if ((txtProCod.Text != "") && (txtQtde.Text != "") && (txtValor.Text != ""))
            {
                double TotalValor = Convert.ToDouble(txtQtde.Text) * Convert.ToDouble(txtValor.Text);
                TotalCompra = TotalCompra + TotalValor;     //atualiza total da compra
                string[] i = new string[] { txtProCod.Text, lProduto.Text, txtQtde.Text, txtValor.Text, TotalCompra.ToString() };
                DgvItens.Rows.Add(i); //ADICIONA LINHA NA GRID

                //LIMPA OS CAMPOS
                txtProCod.Clear();
                lProduto.Text = "Informe o código do produto ou clique em localizar";
                txtQtde.Clear();
                txtValor.Clear();
                    
                txtTotalCompra.Text = TotalCompra.ToString();
            }
        }

        private void Frm_MovimentacaoCompra_Load(object sender, EventArgs e)
        {
            AlterarBotoes(1);
            DALConexao dalConexao = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLTipoPagamento blltipoPagamento = new BLLTipoPagamento(dalConexao);


            cbTipoPagamento.DataSource = blltipoPagamento.Localizar("");
            cbTipoPagamento.DisplayMember = "tpa_nome";
            cbTipoPagamento.ValueMember = "tpa_cod";
        }

        private void DgvItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProCod.Text = DgvItens.Rows[e.RowIndex].Cells[0].Value.ToString();
                lProduto.Text = DgvItens.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtQtde.Text = DgvItens.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtValor.Text = DgvItens.Rows[e.RowIndex].Cells[4].Value.ToString();
                double Valor = Convert.ToDouble(DgvItens.Rows[e.RowIndex].Cells[4].Value);

                TotalCompra = TotalCompra - Valor;

                DgvItens.Rows.RemoveAt(e.RowIndex);                         //REMOVE A LINHA
                txtTotalCompra.Text = TotalCompra.ToString();
            }
            
        }

        private void btCancelarFinal_Click(object sender, EventArgs e)
        {
            pnFinalizaCompra.Visible = false;
        }

        private void btSalvarFinal_Click(object sender, EventArgs e)
        {
            try
            {
                ModeloCompra modeloCompra = new ModeloCompra();

                modeloCompra.ComData = dtDataCompra.Value;
                modeloCompra.ComNfiscal = Convert.ToInt32(txtNfiscal.Text);
                modeloCompra.ComNparcelas = Convert.ToInt16(cbNParcelas.Text);
                modeloCompra.ComStatus = "Ativo";
                modeloCompra.ComTotal = Convert.ToDouble(txtTotalCompra.Text);        //OU totalCompra;
                modeloCompra.ForCod = Convert.ToInt32(txtForCod.Text);
                modeloCompra.TpaCod = Convert.ToInt32(cbTipoPagamento.SelectedValue);


                DALConexao conexao = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCompra bllCompra = new BLLCompra(conexao);


                ModeloItensCompra ItensDaCompra = new ModeloItensCompra();
                BLLitensCompra BllItensCompra = new BLLitensCompra(conexao);

                ModeloParcelasCompra parcelasCompra = new ModeloParcelasCompra();
                BLLparcelasCompra bllparcelasCompra = new BLLparcelasCompra(conexao);

                if (frm.Operacao == "Inserir")
                {
                    bllCompra.Incluir(modeloCompra);

                    for (int i = 0; i < DgvItens.RowCount; i++)       //percorre a grid e joga dentro do modelo, e chama itenscompra
                    {
                        ItensDaCompra.ItcCod = 1 + 1;       //todo codigo começa do valor 1...
                        ItensDaCompra.ComCod = modeloCompra.ComCod;
                        ItensDaCompra.ProCod = Convert.ToInt32(DgvItens.Rows[i].Cells[0].Value);        //acessar grid, linha i, coluna 0, pega valor, e converte
                        ItensDaCompra.ItcQtde = Convert.ToInt32(DgvItens.Rows[i].Cells[2].Value);
                        ItensDaCompra.ItcValor = Convert.ToInt32(DgvItens.Rows[i].Cells[3].Value);

                        BllItensCompra.Incluir(ItensDaCompra);                   

                    }

                    for (int i = 0; i < dgvParcelas.RowCount; i++)       //percorre a grid e joga dentro do modelo, e chama itenscompra
                    {
                        parcelasCompra.ComCod = modeloCompra.ComCod;
                        parcelasCompra.PcoCod = Convert.ToInt32(dgvParcelas.Rows[i].Cells[0].Value);
                        parcelasCompra.PcoValor = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                        parcelasCompra.PcoDataVencimento = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);

                        bllparcelasCompra.Incluir(parcelasCompra);
                    }
                        MessageBox.Show($"Compra efetuada com sucesso.\nCódigo:{modeloCompra.ComCod.ToString()}");
                }
                else
                {
                    bllCompra.Alterar(modeloCompra);
                    MessageBox.Show("Cadastro alterado com sucesso !");
                }

                AlterarBotoes(2);
                pnFinalizaCompra.Visible = false;
                LimpaTela();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
