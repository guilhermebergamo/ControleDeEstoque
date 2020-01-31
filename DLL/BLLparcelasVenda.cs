using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Modelo;


namespace DLL
{
    public class BLLparcelasVenda
    {
        private DALConexao conexao;

        public BLLparcelasVenda(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloParcelasVenda modelo)
        {
            DateTime Data = DateTime.Now;

            if (modelo.PveCod <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            if (modelo.VenCod <= 0)
            {
                MessageBox.Show("O código da compra é obrigatório !");
            }
            if (modelo.PveValor < 0)
            {
                MessageBox.Show("O valor da parcela é obrigatório !");
            }
            if (modelo.PveDataVencimento.Year < Data.Year)
            {
                MessageBox.Show("Ano de vencimento inferior ao ano atual !");
            }

            DALparcelasVendas parcelasVendas = new DALparcelasVendas(conexao);
            parcelasVendas.GetIncluir(modelo);
        }


        public void Alterar(ModeloParcelasVenda modelo)
        {
            DateTime Data = DateTime.Now;

            if (modelo.PveCod <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            if (modelo.VenCod <= 0)
            {
                MessageBox.Show("O código da venda é obrigatório !");
            }
            if (modelo.PveValor < 0)
            {
                MessageBox.Show("O valor da parcela é obrigatório !");
            }
            if (modelo.PveDataVencimento.Year < Data.Year)
            {
                MessageBox.Show("Ano de vencimento inferior ao ano atual !");
            }

            DALparcelasVendas parcelasVendas = new DALparcelasVendas(conexao);
            parcelasVendas.GetAlterar(modelo);
        }


        public void Excluir(ModeloParcelasVenda modelo)
        {
            if (modelo.PveCod <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            if (modelo.VenCod <= 0)
            {
                MessageBox.Show("O código da venda é obrigatório !");
            }

            DALparcelasVendas parcelasVendas = new DALparcelasVendas(conexao);
            parcelasVendas.GetExcluir(modelo);
        }


        public void ExcluirTodasParcela(int ComCodigo)
        {
            if (ComCodigo <= 0)
            {
                MessageBox.Show("O código da parcela é obrigatório !");
            }
            DALparcelasVendas parcelasVendas = new DALparcelasVendas(conexao);
            parcelasVendas.GetExcluirTodasParcelas(ComCodigo);
        }



        public DataTable Localizar(int ComCodigo)
        {
            if (ComCodigo <= 0)
            {
                MessageBox.Show("O código da parcela é obrigatório !");
            }

            DALparcelasVendas parcelasvendas = new DALparcelasVendas(conexao);
            return parcelasvendas.GetLocalizar(ComCodigo);
        }



        public ModeloParcelasVenda CarregaModeloParcelasVenda(int PveCodigo, int VenCodigo)
        {
            if (PveCodigo <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }

            if (VenCodigo <= 0)
            {
                MessageBox.Show("O código da venda é obrigatório !");
            }
            DALparcelasVendas parcelasVendas = new DALparcelasVendas(conexao);
            return parcelasVendas.GetCarregaModeloParcelasVendas(PveCodigo, VenCodigo);
        }





    }
}
