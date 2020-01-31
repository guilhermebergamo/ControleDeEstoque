using System;
using DAL;
using Modelo;
using System.Data;
using Ferramentas;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DLL
{
    public class BLLCliente
    {
        private DALConexao conexao;

        public BLLCliente(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloCliente modelo)
        {

            if (modelo.CliNome.Trim().Length == 0)
            {

                MessageBox.Show("O nome do cliente é obrigatório !");
            }

            if (modelo.CliCpfCnpj.Trim().Length == 0)
            {

                MessageBox.Show("O CPF/CNPJ do cliente é obrigatório !");
            }

            if (modelo.CliTipo == "Física")
            {

                if (Validacao.iscpf(modelo.CliCpfCnpj)== false)
                {
                    MessageBox.Show("O CPF é inválido !");
                }
            }
            else
            {

                if (Validacao.iscnpj(modelo.CliCpfCnpj) == false)
                {
                    MessageBox.Show("O CNPJ é inválido !");
                }
            }           
            

            if (modelo.CliRgIe.Trim().Length == 0)
            {

                MessageBox.Show("O campo RG/IE do cliente é obrigatório !");    //rg e incrição estadual
            }

            if (modelo.CliFone.Trim().Length == 0)
            {

                MessageBox.Show("O telefone do cliente é obrigatório !");
            }

            if (modelo.CliTipo == "Pessoa Física" || modelo.CliTipo == "Pessoa Jurídica")
            {

                MessageBox.Show("Favor informar:\nNº 1 = Pessoa Fisica.\nNº 2 Pessoa Juridica.");
            }

            ////---------------------------------------------------------------------------VALIDA EMAIL

            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}"
                + "\\.[0,9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
                + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";

            Regex re = new Regex(strRegex);
            if (!re.IsMatch(modelo.CliEmail))
            {
                MessageBox.Show("Digite um email válido !");
            }

            //if (Validacao.ValidaCep(modelo.CliCep) == false)
            //{
            //    MessageBox.Show("O CEP è inváligo!");
            //}

            DALCliente dalCliente = new DALCliente(conexao);
            dalCliente.Incluir(modelo);
            
        }

        public void Alterar(ModeloCliente modelo)
        {

            if (modelo.CliNome.Trim().Length == 0)
            {
                MessageBox.Show("O nome do cliente é obrigatório !");
            }

            if (modelo.CliCpfCnpj.Trim().Length == 0)
            {
                MessageBox.Show("O CPF/CNPJ do cliente é obrigatório !");
            }

           

            if (modelo.CliRgIe.Trim().Length == 0)
            {
                MessageBox.Show("O campo RJ/IE do cliente é obrigatório !");    //rg e incrição estadual
            }

            if (modelo.CliFone.Trim().Length == 0)
            {
                MessageBox.Show("O telefone do cliente é obrigatório !");
            }

            if (modelo.CliTipo == "Pessoa Física" || modelo.CliTipo == "Pessoa Jurídica")
            {
                MessageBox.Show("Favor informar:\nNº 1 = Pessoa Fisica.\nNº 2 Pessoa Juridica.");
            }


            //------------------------------------//VALIDA EMAIL

            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[0-9]{1,3]"
                + "\\.[0,9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
                + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";

            Regex re = new Regex(strRegex);

            if (!re.IsMatch(modelo.CliEmail))
            {
                throw new Exception("Digite um email válido !");
            }


            DALCliente dalCliente = new DALCliente(conexao);
            dalCliente.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {

            DALCliente dalCliente = new DALCliente(conexao);
            dalCliente.Excluir(codigo);
        }

        public DataTable LocalizarNOME(string valor)                                            //METODO SUGESTIVO
        {

            DALCliente dalCliente = new DALCliente(conexao);
            return dalCliente.LocalizarPorNOME(valor);
        }

        public DataTable LocalizarCPFCNPJ(string valor)                                         //LOCALIZA POR CPF/CNPJ
        {

            DALCliente dalCliente = new DALCliente(conexao);
            return dalCliente.LocalizarPorCPFCNPJ(valor);
        }

        public ModeloCliente CarregaModeloCliente(int codigo)
        {

            DALCliente dalCliente = new DALCliente(conexao);
            return dalCliente.CarregaModeloCliente(codigo);
        }

        public ModeloCliente CarregaModeloCliente(string cpfcnpj)       //SOBRECARGA DOS METODOS
        {

            DALCliente dalCliente = new DALCliente(conexao);
            return dalCliente.CarregaModeloCliente(cpfcnpj);
        }

        














    }
}
