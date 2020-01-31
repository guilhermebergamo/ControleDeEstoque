using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;


namespace DAL
{
    public class DALparcelasCompra
    {
        public DALConexao conexao;

        public DALparcelasCompra(DALConexao cx)
        {
            conexao = cx;
        }

        private void Incluir(ModeloParcelasCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into parcelascompra (pco_cod, pco_valor, com_cod, pco_datavecto)"
                                   + "values (@pco_cod, @pco_valor, @com_cod, @pco_datavecto);";

                cmd.Parameters.AddWithValue("@pco_cod", modelo.PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pco_valor", modelo.PcoValor);                
                cmd.Parameters.Add("@pco_datavecto", System.Data.SqlDbType.Date);                                            
                cmd.Parameters["@pco_datavecto"].Value = modelo.PcoDataVencimento;
                
                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace + "Detalhes Exception");
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetIncluir(ModeloParcelasCompra modelo)
        {
            Incluir(modelo);
        }



        private void Alterar(ModeloParcelasCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update parcelascompra set pco_valor = @pco_valor, pco_datapagto = @pco_datapagto,"
                                + "pco_datavecto = @pco_datavecto where pco_cod = @pco_cod and com_cod = @com_cod ";

                cmd.Parameters.AddWithValue("@pco_cod", modelo.PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pco_valor", modelo.PcoValor);
                cmd.Parameters.Add("@pco_datapagto", System.Data.SqlDbType.Date);
                cmd.Parameters.Add("@pco_datavecto", System.Data.SqlDbType.Date);

                if (modelo.PcoDataPagamento == null)
                {
                    cmd.Parameters["@pco_datapagto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pco_datapagto"].Value = modelo.PcoDataPagamento;
                }
                cmd.Parameters["@pco_datavecto"].Value = modelo.PcoDataVencimento;

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetAlterar(ModeloParcelasCompra modelo)
        {
            Alterar(modelo);
        }



        private void Excluir(ModeloParcelasCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = " delete from parcelascompra where pco_cod = @pco_cod and com_cod = @com_cod;";

                cmd.Parameters.AddWithValue("@pco_cod", modelo.PcoCod);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetExcluir(ModeloParcelasCompra modelo)
        {
            Excluir(modelo);
        }


        private void ExcluirTodasParcelas(int CodCompra)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"delete from parcelascompra where com_cod = {CodCompra.ToString()};";

                conexao.Conectar();

                cmd.ExecuteNonQuery();                 
            }
            catch (SqlException ex )
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void GetExcluirParcelas(int CodCompra)
        {
            ExcluirTodasParcelas(CodCompra);
        }
        

        private DataTable Localizar(int CodCompra)
        {
            DataTable Tabela = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from parcelascompra where com_cod ={CodCompra.ToString()};", conexao.StringConexao);

            dataAdapter.Fill(Tabela);

            return Tabela;
        }
        public DataTable GetLocalizar(int CodCompra)
        {
            return Localizar(CodCompra);
        }


        private ModeloParcelasCompra CarregaModeloParcelasCompra(int PcoCodigo, int CodCompra)
        {
            try
            {
                ModeloParcelasCompra modelo = new ModeloParcelasCompra();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"select * from parcelascompra where pco_cod = {PcoCodigo.ToString()} and com_cod = {CodCompra.ToString()} ";

                conexao.Conectar();

                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.PcoCod = PcoCodigo;
                    modelo.ComCod = CodCompra;
                    modelo.PcoDataPagamento = Convert.ToDateTime(registro["@pco_datapagto"]);
                    modelo.PcoDataVencimento = Convert.ToDateTime(registro["@pco_datavecto"]);
                    modelo.PcoValor = Convert.ToDouble(registro["@pco_valor"]);

                    return modelo;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            finally
            {
                conexao.Desconectar();
            }              

            return null;
        }
        public ModeloParcelasCompra GetCarregaModeloParcelasCompra(int PcoCodigo, int CodCompra)
        {
            return CarregaModeloParcelasCompra(PcoCodigo, CodCompra);
        }
    }
}
