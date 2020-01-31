using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Ferramentas;
using Modelo;

namespace DLL
{
    public class BLLFornecedor
    {
        private DALConexao conexao;

        public BLLFornecedor(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloFornecedor modelo)
        {

            if (modelo.ForNome.Trim().Length == 0)
            {

                MessageBox.Show("O nome do Fornecedor é obrigatório !");
            }

            if (modelo.ForCnpj.Trim().Length == 0)
            {

                MessageBox.Show("O CNPJ do Fornecedor é obrigatório !");
            }

            if (Validacao.iscnpj(modelo.ForCnpj) == false)
            {

                throw new Exception("O CNPJ é inválido !");
            }           

            if (modelo.ForIe.Trim().Length == 0)
            {

                MessageBox.Show("O campo IE do Fornecedor é obrigatório !");    //IE e incrição estadual
            }

            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[0-9]{1,3]"
                + "\\.[0,9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
                + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";

            Regex re = new Regex(strRegex);

            if (!re.IsMatch(modelo.ForEmail))
            {
                throw new Exception("Digite um E-MAIL válido !");
            }

            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            dalFornecedor.Incluir(modelo);

        }

        public void Alterar(ModeloFornecedor modelo)
        {

            if (modelo.ForNome.Trim().Length == 0)
            {
                MessageBox.Show("O nome do Fornecedor é obrigatório !");
            }

            if (modelo.ForCnpj.Trim().Length == 0)
            {
                MessageBox.Show("O CPF/CNPJ do Fornecedor é obrigatório !");
            }

            if (Validacao.iscnpj(modelo.ForCnpj) == false)
            {

                MessageBox.Show("O CNPJ é inválido !");
            }

            if (modelo.ForIe.Trim().Length == 0)
            {
                MessageBox.Show("O campo RJ/IE do Fornecedor é obrigatório !");    //rg e incrição estadual
            }

            if (modelo.ForFone.Trim().Length == 0)
            {
                MessageBox.Show("O telefone do Fornecedor é obrigatório !");
            }            


            //------------------------------------//VALIDA EMAIL

            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[0-9]{1,3]"
                + "\\.[0,9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
                + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";

            Regex re = new Regex(strRegex);

            if (!re.IsMatch(modelo.ForEmail))
            {
                throw new Exception("Digite um email válido !");
            }


            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            dalFornecedor.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {

            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            dalFornecedor.Excluir(codigo);
        }

        public DataTable LocalizarNOME(string valor)                                            //METODO SUGESTIVO
        {

            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            return dalFornecedor.LocalizarPorNOME(valor);
        }

        public DataTable LocalizarCPFCNPJ(string valor)                                         //LOCALIZA POR CPF/CNPJ
        {

            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            return dalFornecedor.LocalizaPorCNPJ(valor);
        }

        public ModeloFornecedor CarregaModeloFornecedor(int codigo)
        {

            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            return dalFornecedor.CarregaModeloFornecedor(codigo);
        }

        public ModeloFornecedor CarregaModeloFornecedor(string cnpj)       //SOBRECARGA DOS METODOS
        {

            DALFornecedor dalFornecedor = new DALFornecedor(conexao);
            return dalFornecedor.CarregaModeloFornecedor(cnpj);
        }














    }
}
