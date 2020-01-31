using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramentas
{
    public class BuscaEndereco
    {
        static public String Cep = "";
        static public String Cidade = "";
        static public String Estado = "";
        static public String Endereco = "";
        static public String Bairro = "";

        public static Boolean verificaCEP(String CEP)
        {
            bool flag = false;

            try
            {
                DataSet ds = new DataSet();        //REPRESETA UM QUANTIDADE DE DADOS NA MEMORIA !
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);//ACESSANDO O WEBSERVICE PASSANDO O CEP E ARMAZENANDO EM ARQUIVO TEXTO(XML)
                ds.ReadXml(xml);        //DATASET FAZ A LEITURA DO XML

                Endereco = ds.Tables[0].Rows[0]["logradouro"].ToString();   //CADA LINHA DA TABELA POSSUI AS COLUNAS...
                Bairro = ds.Tables[0].Rows[0]["bairro"].ToString();
                Cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                Estado = ds.Tables[0].Rows[0]["uf"].ToString();
                Cep = CEP;

                flag = true;
            }
            catch (Exception)
            {
                Endereco = "";
                Bairro = "";
                Cidade = "";
                Estado = "";
                Cep = "";
            }

            return flag;
        }
    }
}
