using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DAL
{
    public class DALparcelasVendas
    {
        public DALConexao conexao;

        public DALparcelasVendas(DALConexao cx)
        {
            conexao = cx;
        }

        private void Incluir(ModeloParcelasVenda modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into parcelasvenda (pve_cod, ven_cod, pco_datavecto, pve_valor)"
                                   + "values (@pve_cod, @ven_cod, @pco_datavecto, @pve_valor);";

                cmd.Parameters.AddWithValue("@pve_cod", modelo.PveCod);
                cmd.Parameters.AddWithValue("@ven_cod", modelo.VenCod);
                cmd.Parameters.AddWithValue("@pve_valor", modelo.PveValor);                
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.Date);

                if (modelo.PveDataVencimento == null)
                {
                    cmd.Parameters["@pve_datavecto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pve_datavecto"].Value = modelo.PveDataVencimento; 
                }

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
        public void GetIncluir(ModeloParcelasVenda modelo)
        {
            Incluir(modelo);
        }



        private void Alterar(ModeloParcelasVenda modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update parcelasvenda set pve_valor = @pve_valor, pve_datapagto = @pve_datapagto,"
                                + "pve_datavecto = @pve_datavecto where pve_cod = @pve_cod and ven_cod = @ven_cod ";

                cmd.Parameters.AddWithValue("@pve_cod", modelo.PveCod);
                cmd.Parameters.AddWithValue("@ven_cod", modelo.VenCod);
                cmd.Parameters.AddWithValue("@pve_valor", modelo.PveValor);

                cmd.Parameters.Add("@pve_datapagto", System.Data.SqlDbType.Date);
                cmd.Parameters.Add("@pve_datavecto", System.Data.SqlDbType.Date);

                if (modelo.PveDataPagamento == null)
                {
                    cmd.Parameters["@pco_datapagto"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@pco_datapagto"].Value = modelo.PveDataPagamento;
                }
                cmd.Parameters["@pco_datavecto"].Value = modelo.PveDataPagamento;

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
        public void GetAlterar(ModeloParcelasVenda modelo)
        {
            Alterar(modelo);
        }



        private void Excluir(ModeloParcelasVenda modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = " delete from parcelasvenda where pve_cod = @pve_cod and ven_cod = @ven_cod;";

                cmd.Parameters.AddWithValue("@pve_cod", modelo.PveCod);
                cmd.Parameters.AddWithValue("@ven_cod", modelo.VenCod);

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
        public void GetExcluir(ModeloParcelasVenda modelo)
        {
            Excluir(modelo);
        }


        private void ExcluirTodasParcelas(int VenCodigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"delete from parcelascompra where ven_cod = {VenCodigo.ToString()};";

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
        public void GetExcluirTodasParcelas(int VenCodigo)
        {
            ExcluirTodasParcelas(VenCodigo);        
        }


        private DataTable Localizar(int VenCodigo)
        {
            DataTable Tabela = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from parcelasvenda where com_cod ={VenCodigo.ToString()};", conexao.StringConexao);

            dataAdapter.Fill(Tabela);

            return Tabela;
        }
        public DataTable GetLocalizar(int VenCodigo)
        {
            return Localizar(VenCodigo);
        }


        private ModeloParcelasVenda CarregaModeloParcelasVenda(int PveCodigo, int VenCompra)
        {
            try
            {
                ModeloParcelasVenda modelo = new ModeloParcelasVenda();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"select * from parcelasvenda where pve_cod = {PveCodigo.ToString()} and ven_cod = {VenCompra.ToString()} ";

                conexao.Conectar();

                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.PveCod = PveCodigo;
                    modelo.VenCod = VenCompra;
                    modelo.PveDataPagamento = Convert.ToDateTime(registro["@Pve_datapagto"]);
                    modelo.PveDataVencimento = Convert.ToDateTime(registro["Pve_datavecto"]);
                    modelo.PveValor = Convert.ToDouble(registro["@pco_valor"]);

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
        public ModeloParcelasVenda GetCarregaModeloParcelasVendas(int PveCodigo, int VenCompra)
        {
            return CarregaModeloParcelasVenda(PveCodigo, VenCompra);
        }
    }
}
