using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCliente
    {

        public ModeloCliente()      
        {
            CliCod = 0;
            CliNome = "";
            CliCpfCnpj = "";
            CliRgIe ="";
            CliRsocial = "";
            CliTipo = "Física";            //CLIENTE TIPO 0 -> Fisico CLIENTE TIPO 1-> Juridico
            CliCep = "";
            CliEndereco = "";
            CliBairro = "";
            CliFone = "";
            CliCelular = "";
            CliEmail = "";
            CliEndNumero = "";
            CliCidade = "";
            CliEstado = "";
        }

        public ModeloCliente(int cod, string nome, string cpfcnpj, string rgie, string rsocial, string tipo, 
                             string cep, string endereco, string bairro, string fone, string celular, string email,
                             string endnumero, string cidade, string estado)
        {
            CliCod = cod;
            CliNome = nome;
            CliCpfCnpj = cpfcnpj;
            CliRgIe = rgie;
            CliRsocial = rsocial;
            CliTipo = tipo;
            CliCep = cep;
            CliEndereco = endereco;
            CliBairro = bairro;
            CliFone = fone;
            CliCelular = celular;
            CliEmail = email;
            CliEndNumero = endnumero;
            CliCidade = cidade;
            CliEstado = estado;
        }

        private int cli_cod;
        public int CliCod
        {
            get
            {
                return this.cli_cod;                    //RETURNA
            }
            set
            {
                this.cli_cod = value;                   //PEGUE VALOR DIGITADO E GUARDE NO DADO PRIVADO
            }
        }

        private string cli_nome;
        public string CliNome
        {
            get
            {
                return this.cli_nome;
            }
            set
            {
                this.cli_nome = value;
            }
        }

        private string cli_cpfcnpj;
        public string CliCpfCnpj
        {
            get
            {
                return this.cli_cpfcnpj;
            }
            set
            {
                this.cli_cpfcnpj = value;
            }
        }

        private string cli_rgie;
        public string CliRgIe
        {
            get
            {
                return this.cli_rgie;
            }
            set
            {
                this.cli_rgie = value;
            }
        }

        private string cli_rsocial;
        public string CliRsocial
        {
            get
            {
                return this.cli_rsocial;
            }
            set
            {
                this.cli_rsocial = value;
            }
        }

        private string cli_tipo;
        public string CliTipo
        {
            get
            {
                return this.cli_tipo;
            }
            set
            {
                this.cli_tipo = value;
            }
        }

        private string cli_cep;
        public string CliCep
        {
            get
            {
                return this.cli_cep;
            }
            set
            {
                this.cli_cep = value;
            }
        }

        private string cli_endereco;
        public string CliEndereco 
        {
            get
            {
                return this.cli_endereco;
            }
            set
            {
                this.cli_endereco = value;
            }
        }

        private string cli_bairro;
        public string CliBairro
        {
            get
            {
                return this.cli_bairro;
            }
            set
            {
                this.cli_bairro = value;
            }
        }

        private string cli_fone;
        public string CliFone
        {
            get
            {
                return this.cli_fone;
            }
            set
            {
                this.cli_fone = value;
            }
        }

        private string cli_cel;
        public string CliCelular
        {
            get
            {
                return this.cli_cel;
            }
            set
            {
                this.cli_cel = value;
            }
        }

        private string cli_email;
        public string CliEmail
        {
            get
            {
                return this.cli_email;
            }
            set
            {
                this.cli_email = value;
            }
        }

        private string cli_endnumero;
        public string CliEndNumero
        {
            get
            {
                return this.cli_endnumero;
            }
            set
            {
                this.cli_endnumero = value;
            }
        }

        private string cli_cidade;
        public string CliCidade
        {
            get
            {
                return this.cli_cidade;
            }
            set
            {
                this.cli_cidade = value;
            }
        }

        private string cli_estado;
        public string CliEstado
        {
            get
            {
                return this.cli_estado;
            }
            set
            {
                this.cli_estado = value;
            }
        }
    }
}
