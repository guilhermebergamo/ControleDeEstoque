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
    public class BLLitensCompra
    {
        private DALConexao conexao;
        public BLLitensCompra(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloItensCompra modelo)
        {
            if (modelo.ComCod <= 0)
            {
                MessageBox.Show("O Código da compra é obrigatório !");
            }
            if (modelo.ItcCod <= 0)
            {
                MessageBox.Show("O Código do item da compra é obrigatório !");
            }
            if (modelo.ItcQtde <= 0)
            {
                MessageBox.Show("A Quantidade da compra deve ser maior que 0 !");
            }
            if (modelo.ItcValor <= 0)
            {
                MessageBox.Show("O Valor do item deve ser maior que 0!");
            }
            if (modelo.ProCod <= 0)
            {
                MessageBox.Show("O Código do produto é obrigatório!");
            }

            DALitensCompra itensCompra = new DALitensCompra(conexao);
            itensCompra.GetIncluir(modelo);
        }



        public void Alterar(ModeloItensCompra modelo)
        {
            if (modelo.ComCod <= 0)
            {
                MessageBox.Show("O Código da compra é obrigatório !");
            }
            if (modelo.ItcCod <= 0)
            {
                MessageBox.Show("O Código do item da compra é obrigatório !");
            }
            if (modelo.ItcQtde <= 0)
            {
                MessageBox.Show("A Quantidade da compra deve ser maior que 0 !");
            }
            if (modelo.ItcValor <= 0)
            {
                MessageBox.Show("O Valor do item deve ser maior que 0!");
            }
            if (modelo.ProCod <= 0)
            {
                MessageBox.Show("O Código do produto é obrigatório!");
            }

            DALitensCompra itensCompra = new DALitensCompra(conexao);
            itensCompra.GetAlterar(modelo);
        }


        public void Excluir(ModeloItensCompra modelo)
        {
            if (modelo.ComCod <= 0)
            {
                MessageBox.Show("O Código da compra é obrigatório !");
            }
            if (modelo.ItcCod <= 0)
            {
                MessageBox.Show("O Código do item da compra é obrigatório !");
            }           
            if (modelo.ProCod <= 0)
            {
                MessageBox.Show("O Código do produto é obrigatório!");
            }

            DALitensCompra itensCompra = new DALitensCompra(conexao);
            itensCompra.GetExcluir(modelo);
        }



        public DataTable Localizar(int codigo)
        {
            DALitensCompra itensCompra = new DALitensCompra(conexao);
            return itensCompra.GetLocalizar(codigo);
        }


        public ModeloItensCompra CarregaModeloItensCompra(int ItcCodigo, int ComCodigo, int ProCodigo)
        {
            DALitensCompra itensCompra = new DALitensCompra(conexao);
            return itensCompra.GetCarregaModeloItensCompra(ItcCodigo, ComCodigo, ProCodigo);         
        } 






    }
}
