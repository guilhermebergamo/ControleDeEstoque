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
    public class BLLparcelasCompra
    {
        private DALConexao conexao;

        public BLLparcelasCompra(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloParcelasCompra modelo)
        {
            DateTime Data = DateTime.Now;

            if (modelo.PcoCod <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            if (modelo.ComCod <= 0)
            {
                MessageBox.Show("O código da compra é obrigatório !");
            }
            if (modelo.PcoValor < 0)
            {
                MessageBox.Show("O valor da parcela é obrigatório !");
            }
            if (modelo.PcoDataVencimento.Year < Data.Year)
            {
                MessageBox.Show("Ano de vencimento inferior ao ano atual !");
            }

            DALparcelasCompra parcelasCompra = new DALparcelasCompra(conexao);
            parcelasCompra.GetIncluir(modelo);            
        }


        public void Alterar(ModeloParcelasCompra modelo)
        {
            DateTime Data = DateTime.Now;

            if (modelo.PcoCod <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            if (modelo.PcoValor < 0)
            {
                MessageBox.Show("O valor da parcela é obrigatório !");
            }
            if (modelo.PcoDataVencimento.Year < Data.Year)
            {
                MessageBox.Show("Ano de vencimento inferior ao ano atual !");
            }

            DALparcelasCompra parcelasCompra = new DALparcelasCompra(conexao);
            parcelasCompra.GetAlterar(modelo);
        }


        public void Excluir(ModeloParcelasCompra modelo)
        {
            if (modelo.PcoCod <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            if (modelo.ComCod <= 0)
            {
                MessageBox.Show("O código da compra é obrigatório !");
            }

            DALparcelasCompra parcelasCompra = new DALparcelasCompra(conexao);
            parcelasCompra.GetExcluir(modelo);
        }
        

        public void ExcluirTodasParcela(int ComCodigo)
        {
            if (ComCodigo <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }
            DALparcelasCompra parcelasCompra = new DALparcelasCompra(conexao);
            parcelasCompra.GetExcluirParcelas(ComCodigo);
        }



        public DataTable Localizar(int ComCodigo)
        {
            if (ComCodigo <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }

            DALparcelasCompra parcelasCompra = new DALparcelasCompra(conexao);
            return parcelasCompra.GetLocalizar(ComCodigo);
        }



        public ModeloParcelasCompra CarregaModeloParcelasCompra(int PcoCodigo, int CodCompra)
        {
            if (PcoCodigo <= 0)
            {
                MessageBox.Show("O código da parcelas é obrigatório !");
            }

            if (CodCompra <= 0)
            {
                MessageBox.Show("O código da compra é obrigatório !");
            }
            DALparcelasCompra parcelasCompra = new DALparcelasCompra(conexao);
            return parcelasCompra.GetCarregaModeloParcelasCompra(PcoCodigo, CodCompra);
        }
    }
}
