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
    public class BLLCompra
    {
        private DALConexao conexao;

        public BLLCompra(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloCompra modelo)
        {
            if (modelo.ComData.Date != DateTime.Now.Date)     //diferente da data atual do sistema
            {
                MessageBox.Show("A data da compra não corresponde a data atual !");
            }

            if (modelo.ComNparcelas <= 0)
            {
                MessageBox.Show("O numero de parcela deve ser maior que zero !");
            }

            if (modelo.ForCod <= 0)
            {
                MessageBox.Show("O código do fornecedor deve ser informado !");
            }

            if (modelo.ComTotal <= 0)
            {
                MessageBox.Show("O valor da compra deve ser informado !");
            }

            DALCompra dalCompra = new DALCompra(conexao);
            dalCompra.GetIncluir(modelo);
        }


        public void Alterar(ModeloCompra modelo)
        {
            if (modelo.ComData != DateTime.Now)     //diferente da data atual do sistema
            {
                MessageBox.Show("A data da compra não corresponde a data atual !");
            }

            if (modelo.ComNparcelas <= 0)
            {
                MessageBox.Show("O numero de parcela deve ser maior que zero !");
            }

            if (modelo.ForCod <= 0)
            {
                MessageBox.Show("O código do fornecedor deve ser informado !");
            }

            if (modelo.ComTotal <= 0)
            {
                MessageBox.Show("O valor da compra deve ser informado !");
            }
            DALCompra dalCompra = new DALCompra(conexao);
            dalCompra.GetAlterar(modelo);
        }

        public void Excluir(int Codigo)
        {
            DALCompra dalCompra = new DALCompra(conexao);
            dalCompra.GetExcluir(Codigo);
        }


        public DataTable Localizar()
        {
            DALCompra dalCompra = new DALCompra(conexao);
            return dalCompra.GetLocalizar();
        }

        public DataTable LocalizarParcelasAbertas()
        {
            DALCompra dalCompra = new DALCompra(conexao);
            return dalCompra.GetLocalizarParcelasAbertas();
        }



        public DataTable LocalizarNome(string Nome)
        {
            DALCompra dalCompra = new DALCompra(conexao);
            return dalCompra.GetLocalizarNome(Nome);
        }



        public DataTable LocalizaCodFornecedor(int CodFornecedor)
        {
            DALCompra dalCompra = new DALCompra(conexao);
            return dalCompra.GetLocalizaFornecedor(CodFornecedor);
        }

       

        public DataTable LocalizarData(DateTime DataInicial, DateTime DataFinal)
        {
            DALCompra dalCompra = new DALCompra(conexao);
            return dalCompra.GetLocalizarData(DataInicial, DataFinal);
        }


        public ModeloCompra CarregaModeloCompra(int Codigo)
        {
            DALCompra dalCompra = new DALCompra(conexao);
            return dalCompra.GetModeloCompra(Codigo);
        }
    }
}
