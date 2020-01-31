using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;


namespace DAL
{
    public class DALFornecedor
    {
        private DALConexao conexao;                         //Conexao é uma variavel que representa a conexao 
        public DALFornecedor(DALConexao cx)                  //Construtor que recebe como parametro uma conexao
        {
            conexao = cx;                                   //conexao que recebe o objeto cx
        }
        public void Incluir(ModeloFornecedor modelo)     //Metodo Incluir que recebe como parametro o modelo do tipo modelocategoria
        {

            SqlCommand cmd = new SqlCommand();                      //instância um comando
            cmd.Connection = conexao.ObjetoConexao;                 //usara a conexao dentro de DALconexao
            cmd.CommandText = "insert into Fornecedor(For_nome, For_cnpj, For_ie, For_rsocial,"
                + "For_cep, For_endereco, For_bairro, For_fone, For_cel, For_email, For_endnumero, For_cidade, For_estado)"
                + " values (@For_nome,@For_cnpj,@For_ie,@For_rsocial,@For_cep,@For_endereco,@For_bairro,@For_fone,"
                + "@For_cel, @For_email, @For_endnumero, @For_cidade, @For_estado); select @@IDENTITY;";     //comando que sera utilizado

            cmd.Parameters.AddWithValue("@For_nome", modelo.ForNome);           //parametros do comando informado
            cmd.Parameters.AddWithValue("@For_cnpj", modelo.ForCnpj);
            cmd.Parameters.AddWithValue("@For_ie", modelo.ForIe);
            cmd.Parameters.AddWithValue("@For_rsocial", modelo.ForRsocial);
            cmd.Parameters.AddWithValue("@For_cep", modelo.ForCep);
            cmd.Parameters.AddWithValue("@For_endereco", modelo.ForEndereco);
            cmd.Parameters.AddWithValue("@For_bairro", modelo.ForBairro);
            cmd.Parameters.AddWithValue("@For_fone", modelo.ForFone);
            cmd.Parameters.AddWithValue("@For_cel", modelo.ForCelular);
            cmd.Parameters.AddWithValue("@For_email", modelo.ForEmail);
            cmd.Parameters.AddWithValue("@For_endnumero", modelo.ForEndNumero);
            cmd.Parameters.AddWithValue("@For_cidade", modelo.ForCidade);
            cmd.Parameters.AddWithValue("@For_estado", modelo.ForEstado);
            

            conexao.Conectar();

            modelo.ForCod = Convert.ToInt32(cmd.ExecuteScalar());            ////modelo ForCOD receba o valor retornado pelo Identity, apos executar o comando ExecuteScalar...

            conexao.Desconectar();                              //Desconecta ao BD
        }

        public void Alterar(ModeloFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update Fornecedor set For_nome = @For_nome, For_cnpj = @For_cnpj, For_ie = @For_ie, "
                            + "For_rsocial = @For_rsocial, For_cep = @For_cep, For_endereco = @For_endereco, "
                            + "For_bairro = @For_bairro, For_fone = @For_fone, For_cel = @For_cel, For_email = @For_email, "
                            + "For_endnumero = @For_endnumero, For_cidade = @For_cidade, For_estado = @For_estado where For_cod = @codigo";

            cmd.Parameters.AddWithValue("@For_nome", modelo.ForNome);           //parametros do comando informado
            cmd.Parameters.AddWithValue("@For_cnpj", modelo.ForCnpj);
            cmd.Parameters.AddWithValue("@For_ie", modelo.ForIe);
            cmd.Parameters.AddWithValue("@For_rsocial", modelo.ForRsocial);
            cmd.Parameters.AddWithValue("@For_cep", modelo.ForCep);
            cmd.Parameters.AddWithValue("@For_endereco", modelo.ForEndereco);
            cmd.Parameters.AddWithValue("@For_bairro", modelo.ForBairro);
            cmd.Parameters.AddWithValue("@For_fone", modelo.ForFone);
            cmd.Parameters.AddWithValue("@For_cel", modelo.ForCelular);
            cmd.Parameters.AddWithValue("@For_email", modelo.ForEmail);
            cmd.Parameters.AddWithValue("@For_endnumero", modelo.ForEndNumero);
            cmd.Parameters.AddWithValue("@For_cidade", modelo.ForCidade);
            cmd.Parameters.AddWithValue("@For_estado", modelo.ForEstado);
            cmd.Parameters.AddWithValue("@codigo", modelo.ForCod);
            

            conexao.Conectar();

            cmd.ExecuteNonQuery();  //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.

            conexao.Desconectar();
        }

        public void Excluir(int codigo)                 //executeRead opter varias informacoes, varios registros do BD
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from Fornecedor where For_cod = " + codigo.ToString();
            //cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        private DataTable LocalizarNOME(string valor)               //metodo localizar, vai devolver uma tabela em memoria e recebe um valor como parametro que queremos procurar dentro da tabela
        {
            DataTable tabela = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter da = new SqlDataAdapter("select * from Fornecedor where For_nome like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            da.Fill(tabela);         //ira preencher a tabela com os valores do comando executado...

            return tabela;
        }

        public DataTable LocalizarPorNOME(string valor)
        {
            return LocalizarNOME(valor);
        }

        private DataTable LocalizarCNPJ(string valor)               //metodo localizar, vai devolver uma tabela em memoria e recebe um valor como parametro que queremos procurar dentro da tabela
        {
            DataTable tabela = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter da = new SqlDataAdapter("select * from Fornecedor where For_cnpj like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            da.Fill(tabela);         //ira preencher a tabela com os valores do comando executado...

            return tabela;
        }

        public DataTable LocalizaPorCNPJ(string valor)
        {

            return LocalizarCNPJ(valor);
        }

        //SE QUISER PODE CRIAR OUTRO LOCALIZAR POR RG/IE



        public ModeloFornecedor CarregaModeloFornecedor(int codigo)               //ira receber o codigo da categoria que nós desejamos pegar as informacoes
        {
            ModeloFornecedor modelo = new ModeloFornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from Fornecedor where For_cod = " + codigo.ToString(); //....Onde codigo for igual ao codigo informado pelo usuario
            //cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();       //registro do BD

            if (registro.HasRows)       //verificando se existe alguma linha dentro de objeto registro
            {
                registro.Read();

                modelo.ForCod = ((int)registro["For_cod"]);   //RECEBER A INFORMACAO QUE ESTA DENTRO DA COLUNA "" DO REGISTRO.
                modelo.ForNome = Convert.ToString(registro["For_nome"]);
                modelo.ForCnpj = Convert.ToString(registro["For_cnpj"]);
                modelo.ForIe = Convert.ToString(registro["For_ie"]);
                modelo.ForRsocial = Convert.ToString(registro["For_rsocial"]);
                modelo.ForCep = Convert.ToString(registro["For_cep"]);
                modelo.ForEndereco = Convert.ToString(registro["For_endereco"]);
                modelo.ForEndNumero = Convert.ToString(registro["For_endnumero"]);
                modelo.ForBairro = Convert.ToString(registro["For_bairro"]);
                modelo.ForFone = Convert.ToString(registro["For_fone"]);
                modelo.ForCelular = Convert.ToString(registro["For_cel"]);
                modelo.ForEmail = Convert.ToString(registro["For_email"]);
                modelo.ForCidade = Convert.ToString(registro["For_cidade"]);
                modelo.ForEstado = Convert.ToString(registro["For_estado"]);
              

            }
            conexao.Desconectar();

            return modelo;
        }

        public ModeloFornecedor CarregaModeloFornecedor(string cnpj)               //ira receber o codigo da categoria que nós desejamos pegar as informacoes
        {
            ModeloFornecedor modelo = new ModeloFornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from Fornecedor where For_cnpj = " + cnpj.ToString(); //....Onde codigo for igual ao codigo informado pelo usuario
            //cmd.Parameters.AddWithValue("@cpfcnpj", codigo);

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();       //registro do BD

            if (registro.HasRows)       //verificando se existe alguma linha dentro de objeto registro
            {
                registro.Read();

                modelo.ForCod = Convert.ToInt32(registro["For_cod"]);   //RECEBER A INFORMACAO QUE ESTA DENTRO DA COLUNA "" DO REGISTRO.
                modelo.ForNome = Convert.ToString(registro["For_nome"]);
                modelo.ForCnpj = Convert.ToString(registro["For_cnpj"]);
                modelo.ForIe = Convert.ToString(registro["For_ie"]);
                modelo.ForRsocial = Convert.ToString(registro["For_rsocial"]);
                modelo.ForCep = Convert.ToString(registro["For_cep"]);
                modelo.ForEndereco = Convert.ToString(registro["For_endereco"]);
                modelo.ForBairro = Convert.ToString(registro["For_bairro"]);
                modelo.ForFone = Convert.ToString(registro["For_fone"]);
                modelo.ForCelular = Convert.ToString(registro["For_celular"]);
                modelo.ForEmail = Convert.ToString(registro["For_email"]);
                modelo.ForCidade = Convert.ToString(registro["For_cidade"]);
                modelo.ForEstado = Convert.ToString(registro["For_estado"]);

                
            }

            conexao.Desconectar();

            return modelo;

        }        
    }
}
