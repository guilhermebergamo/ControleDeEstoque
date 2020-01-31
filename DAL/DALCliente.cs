using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;





namespace DAL
{
    public class DALCliente
    {

        private DALConexao conexao;                         //Conexao é uma variavel que representa a conexao 
        public DALCliente(DALConexao cx)                  //Construtor que recebe como parametro uma conexao
        {
            conexao = cx;                                   //conexao que recebe o objeto cx
        }
        public void Incluir(ModeloCliente modelo)     //Metodo Incluir que recebe como parametro o modelo do tipo modelocategoria
        {

            SqlCommand cmd = new SqlCommand();                      //instância um comando
            cmd.Connection = conexao.ObjetoConexao;                 //usara a conexao dentro de DALconexao
            cmd.CommandText = "insert into cliente(cli_nome, cli_cpfcnpj, cli_rgie, cli_rsocial, cli_tipo,"
                + "cli_cep, cli_endereco, cli_bairro, cli_fone, cli_cel, cli_email, cli_endnumero, cli_cidade, cli_estado)"
                + " values (@cli_nome,@cli_cpfcnpj,@cli_rgie,@cli_rsocial,@cli_tipo,@cli_cep,@cli_endereco,@cli_bairro,@cli_fone,"
                + "@cli_cel, @cli_email, @cli_endnumero, @cli_cidade, @cli_estado); select @@IDENTITY;";     //comando que sera utilizado

            cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome);           //parametros do comando informado
            cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj);
            cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe);
            cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRsocial);
            cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo);
            cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep);
            cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco);
            cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro);
            cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone);
            cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCelular);
            cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail);
            cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero);
            cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade);
            cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado);

            conexao.Conectar();

            modelo.CliCod = Convert.ToInt32(cmd.ExecuteScalar());            ////modelo CLICOD receba o valor retornado pelo Identity, apos executar o comando ExecuteScalar...

            conexao.Desconectar();                              //Desconecta ao BD
        }

        public void Alterar(ModeloCliente modelo)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update cliente set cli_nome = @cli_nome, cli_cpfcnpj = @cli_cpfcnpj, cli_rgie = @cli_rgie, "
                            + "cli_rsocial = @cli_rsocial, cli_tipo = @cli_tipo, cli_cep = @cli_cep, cli_endereco = @cli_endereco, "
                            + "cli_bairro = @cli_bairro, cli_fone = @cli_fone, cli_cel = @cli_cel, cli_email = @cli_email, "
                            + "cli_endnumero = @cli_endnumero, cli_cidade = @cli_cidade, cli_estado = @cli_estado where cli_cod = @codigo";

            cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome);           //parametros do comando informado
            cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj);
            cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe);
            cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRsocial);
            cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo);
            cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep);
            cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco);
            cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro);
            cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone);
            cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCelular);
            cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail);
            cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero);
            cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade);
            cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado);
            cmd.Parameters.AddWithValue("@codigo", modelo.CliCod);

            conexao.Conectar();

            cmd.ExecuteNonQuery();  //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.

            conexao.Desconectar();
        }

        public void Excluir(int codigo)                 //executeRead opter varias informacoes, varios registros do BD
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from cliente where cli_cod = " + codigo.ToString();
            //cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        private DataTable Localizar(string valor)               //metodo localizar, vai devolver uma tabela em memoria e recebe um valor como parametro que queremos procurar dentro da tabela
        {
            DataTable tabela = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter da = new SqlDataAdapter("select * from cliente where cli_nome like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            da.Fill(tabela);         //ira preencher a tabela com os valores do comando executado...

            return tabela;
        }

        public DataTable LocalizarPorNOME(string valor)               
        {
            return Localizar(valor); 
        }

        private DataTable LocalizarCPFCNPJ(string valor)               //metodo localizar, vai devolver uma tabela em memoria e recebe um valor como parametro que queremos procurar dentro da tabela
        {
            DataTable tabela = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter da = new SqlDataAdapter("select * from cliente where cli_cpfcnpj like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            da.Fill(tabela);         //ira preencher a tabela com os valores do comando executado...

            return tabela;
        }

        public DataTable LocalizarPorCPFCNPJ(string valor)
        {
            return LocalizarCPFCNPJ(valor);
        }

        //SE QUISER PODE CRIAR OUTRO LOCALIZAR POR RG/IE



        public ModeloCliente CarregaModeloCliente(int codigo)               //ira receber o codigo da categoria que nós desejamos pegar as informacoes
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from cliente where cli_cod = " + codigo.ToString(); //....Onde codigo for igual ao codigo informado pelo usuario
            //cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();       //registro do BD

            if (registro.HasRows)       //verificando se existe alguma linha dentro de objeto registro
            {
                registro.Read();

                modelo.CliCod = ((int)registro["cli_cod"]);   //RECEBER A INFORMACAO QUE ESTA DENTRO DA COLUNA "" DO REGISTRO.
                modelo.CliNome = Convert.ToString(registro["cli_nome"]);
                modelo.CliCpfCnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.CliRgIe = Convert.ToString(registro["cli_rgie"]);
                modelo.CliRsocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.CliTipo = Convert.ToString(registro["cli_tipo"]);
                modelo.CliCep = Convert.ToString(registro["cli_cep"]);
                modelo.CliEndereco = Convert.ToString(registro["cli_endereco"]);
                modelo.CliEndNumero = Convert.ToString(registro["cli_endnumero"]);
                modelo.CliBairro = Convert.ToString(registro["cli_bairro"]);
                modelo.CliFone = Convert.ToString(registro["cli_fone"]);
                modelo.CliCelular = Convert.ToString(registro["cli_cel"]);
                modelo.CliEmail = Convert.ToString(registro["cli_email"]);
                modelo.CliCidade = Convert.ToString(registro["cli_cidade"]);
                modelo.CliEstado = Convert.ToString(registro["cli_estado"]);

            }
            conexao.Desconectar();

            return modelo;
        }

        public ModeloCliente CarregaModeloCliente(string cpfcnpj)               //ira receber o codigo da categoria que nós desejamos pegar as informacoes
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from cliente where cli_cpfcnpj = " + cpfcnpj.ToString(); //....Onde codigo for igual ao codigo informado pelo usuario
            //cmd.Parameters.AddWithValue("@cpfcnpj", codigo);

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();       //registro do BD

            if (registro.HasRows)       //verificando se existe alguma linha dentro de objeto registro
            {
                registro.Read();

                modelo.CliCod = Convert.ToInt32(registro["cli_cod"]);   //RECEBER A INFORMACAO QUE ESTA DENTRO DA COLUNA "" DO REGISTRO.
                modelo.CliNome = Convert.ToString(registro["cli_nome"]);
                modelo.CliCpfCnpj = Convert.ToString(registro["cli_cpfcnpj"]);
                modelo.CliRgIe = Convert.ToString(registro["cli_rgie"]);
                modelo.CliRsocial = Convert.ToString(registro["cli_rsocial"]);
                modelo.CliTipo = Convert.ToString(registro["cli_tipo"]);
                modelo.CliCep = Convert.ToString(registro["cli_cep"]);
                modelo.CliEndereco = Convert.ToString(registro["cli_endereco"]);
                modelo.CliBairro = Convert.ToString(registro["cli_bairro"]);
                modelo.CliFone = Convert.ToString(registro["cli_fone"]);
                modelo.CliCelular = Convert.ToString(registro["cli_celular"]);
                modelo.CliEmail = Convert.ToString(registro["cli_email"]);
                modelo.CliCidade = Convert.ToString(registro["cli_cidade"]);
                modelo.CliEstado = Convert.ToString(registro["cli_estado"]);

            }

            conexao.Desconectar();

            return modelo;



        }
    }
}
