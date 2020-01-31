using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALCompra
    {
        public DALConexao conexao;
        public DALCompra(DALConexao cx)
        {
            conexao = cx;
        }

        private void Incluir(ModeloCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into compra (com_data, com_nfiscal, com_total, com_nparcelas, com_status, for_cod, tpa_cod)" +
                    "values (@com_data,@com_nfiscal,@com_total,@com_nparcelas,@com_status,@for_cod,@tpa_cod); select @@IDENTITY; ";

                //QUANDO O VALOR FOR UMA DATA
                cmd.Parameters.Add("@com_data", System.Data.SqlDbType.DateTime);        //ADICIONA PARAMETRO - E INFORMA QUE TIPO ELE VAI ARMAZENAR.
                //DADOS PRIMITIVOS
                cmd.Parameters["@com_data"].Value = modelo.ComData;

                cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNfiscal);
                cmd.Parameters.AddWithValue("@com_total", modelo.ComTotal);
                cmd.Parameters.AddWithValue("@com_nparcelas", modelo.ComNparcelas);
                cmd.Parameters.AddWithValue("@com_status", modelo.ComStatus);
                cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
                cmd.Parameters.AddWithValue("@tpa_cod", modelo.TpaCod);
                
                conexao.Conectar();

                modelo.ComCod = Convert.ToInt32(cmd.ExecuteScalar()); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetIncluir(ModeloCompra modelo)
        {
            Incluir(modelo);
        }

        private void Alterar(ModeloCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update compra set com_data = @com_data, com_nfiscal = @com_nfiscal, "
                                + "com_total = @com_total, com_nparcelas = @com_nparcelas, com_status = @com_status "
                                + "for_cod = @for_cod, tpa_cod = @tpa_cod where com_cod = @codigo ";

                cmd.Parameters.AddWithValue("@codigo", modelo.ComCod);

                cmd.Parameters.Add("@com_data", System.Data.SqlDbType.DateTime);        //ADICIONA PARAMETRO - E INFORMA QUE TIPO ELE VAI ARMAZENAR.
                //DADOS PRIMITIVOS
                cmd.Parameters["@com_data"].Value = modelo.ComData;

                cmd.Parameters.AddWithValue("@com_nfiscal", modelo.ComNfiscal);
                cmd.Parameters.AddWithValue("@com_total", modelo.ComTotal);
                cmd.Parameters.AddWithValue("@com_nparcelas", modelo.ComNparcelas);
                cmd.Parameters.AddWithValue("@com_status", modelo.ComStatus);
                cmd.Parameters.AddWithValue("@for_cod", modelo.ForCod);
                cmd.Parameters.AddWithValue("@tpa_cod", modelo.TpaCod);

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetAlterar(ModeloCompra modelo)
        {
            Alterar(modelo);
        }


        private void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"delete from compra where com_cod = {codigo.ToString()}";
                //cmd.Parameters.AddWithValue("@codigo", codigo);";

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetExcluir(int codigo)
        {
            Excluir(codigo);
        }


        private DataTable Localizar()        //LISTA TODAS AS COMPRAS
        {
            DataTable Table = new DataTable();
            SqlDataAdapter Dapter = new SqlDataAdapter("select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c.for_cod, c.tpa_cod, f.for_nome" +
                                                        " from compra c inner join fornecedor f on c.for_cod = f.for_cod", conexao.StringConexao);
            Dapter.Fill(Table);

            return Table;
        }
        public DataTable GetLocalizar()
        {
            return Localizar();
        }



        private DataTable LocalizarParcelasAbertas()        //LISTA TODAS AS COMPRAS
        {
            DataTable Table = new DataTable();
            SqlDataAdapter Dapter = new SqlDataAdapter("select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, f.for_nome"+
                                                         "c.com_status, c.for_cod, c._tpa_cod, c.com_total"+
                                                         "from compra c inner join fornecedor f on c.for_cod = f.for_cod"+
                                                         "inner join parcelascompra p on c.com_cod = p.com_cod where p.pco_dapagto is NULL", conexao.StringConexao);
            Dapter.Fill(Table); 

            return Table;
        }
        public DataTable GetLocalizarParcelasAbertas()
        {
            return LocalizarParcelasAbertas();
        }


        private DataTable LocalizarNome(string Nome)        //LISTA AS COMPRAS PELO NOME DO FORNECEDOR
        {
            DataTable Table = new DataTable();
            SqlDataAdapter Dapter = new SqlDataAdapter("select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c._for_cod, c.tpa_cod, f.for_nome" +
                                                        " from compra c inner join fornecedor f on c.for_cod = f.for_cod" +
                                                        " where f.for_nome = like'%" + Nome + "%'", conexao.StringConexao);
            Dapter.Fill(Table);

            return Table;
        }
        public DataTable GetLocalizarNome(string Nome)
        {
            return LocalizarNome(Nome);
        }     



        private DataTable LocalizaCodFornecedor(int CodFornecedor)   //LOCALIZAR POR CODIGO DO Fornecedor
        {
            try
            {
                DataTable Table = new DataTable();              
                SqlDataAdapter Dapter = new SqlDataAdapter($"select * from compra where for_cod = {CodFornecedor.ToString()}", conexao.StringConexao);
                Dapter.Fill(Table);

                return Table;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetLocalizaFornecedor(int CodFornecedor)
        {
           return LocalizaCodFornecedor(CodFornecedor);
        }    



        private DataTable LocalizarData(DateTime DataInicial, DateTime DataFinal)   //retorna todas as comprar feita na data inicial e final
        {
            DataTable Table = new DataTable();                                              //TABELA QUE ROTORNARA VALORES
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select c.com_cod, c.com_data, c.com_nfiscal, c.com_nparcelas, c.com_total, c.com_status, c.for_cod, c.tpa_cod, f.for_nome" +
                                              " from compra c inner join fornecedor f on c.for_cod  = f.for_cod " +
                                              " where c.com_data BETWEEN @DataInicio and @DataFinal";

            cmd.Parameters.AddWithValue("@DataInicio", System.Data.SqlDbType.DateTime);                  //INFORMA TIPO(DATETIME)
            cmd.Parameters["@DataInicio"].Value = DataInicial;                                              //INFORMA VALOR

            cmd.Parameters.AddWithValue("@DataFinal", System.Data.SqlDbType.DateTime);
            cmd.Parameters["@DataFinal"].Value = DataFinal;

            SqlDataAdapter Dapter = new SqlDataAdapter(cmd);
            Dapter.Fill(Table);

            return Table;
        }
        public DataTable GetLocalizarData(DateTime DataInicial, DateTime DataFinal)
        {
            return LocalizarData(DataInicial, DataFinal);
        }


        private ModeloCompra CarregaModeloCompra(int Codigo)                                    //
        {            
            ModeloCompra modelo = new ModeloCompra();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from compra where com_cod = " + Codigo.ToString();
            //cmd.Parameters.AddWithValue("@codigo", modelo.ComCod);

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();

                modelo.ComCod = Convert.ToInt32(registro["com_cod"]);
                modelo.ComData = Convert.ToDateTime(registro["com_data"]);
                modelo.ComNfiscal = Convert.ToInt32(registro["com_nfiscal"]);
                modelo.ComNparcelas = Convert.ToInt32(registro["com_nparcelas"]);
                modelo.ComStatus = Convert.ToString(registro["com_status"]);
                modelo.ComTotal = Convert.ToDouble(registro["com_total"]);
                modelo.ForCod = Convert.ToInt32(registro["for_cod"]);
                modelo.TpaCod = Convert.ToInt32(registro["tpa_cod"]);
            }
            conexao.Desconectar();

            return modelo;                      
        }
        public ModeloCompra GetModeloCompra(int Codigo)
        {
            return CarregaModeloCompra(Codigo);
        }
    }
}
