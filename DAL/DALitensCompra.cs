using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Modelo;

namespace DAL
{
    public class DALitensCompra
    {
        public DALConexao conexao;

        public DALitensCompra(DALConexao cx)
        {
            conexao = cx;
        }

        private void Incluir(ModeloItensCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into itenscompra (itc_cod, itc_qtde, itc_valor, com_cod, pro_cod)"
                                   + "values (@itc_cod,@itc_qtde,@itc_valor,@com_cod,@pro_cod);";

                cmd.Parameters.AddWithValue("@itc_cod", modelo.ItcCod);
                cmd.Parameters.AddWithValue("@itc_qtde", modelo.ItcQtde);
                cmd.Parameters.AddWithValue("@itc_valor", modelo.ItcValor);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);

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
        public void GetIncluir(ModeloItensCompra modelo)
        {
            Incluir(modelo);
        }



        private void Alterar(ModeloItensCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"update itenscompra set itc_qtde = @itc_qtde, itc_valor = @itc_valor"
                        + " where itc_cod = @itc_cod and com_cod = @com_cod and pro_cod = @pro_cod";                

                cmd.Parameters.AddWithValue("@itc_cod", modelo.ItcCod);
                cmd.Parameters.AddWithValue("@itc_qtde", modelo.ItcQtde);
                cmd.Parameters.AddWithValue("@itc_valor", modelo.ItcValor);
                cmd.Parameters.AddWithValue("@com_cod", modelo.ProCod);
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);               

                conexao.Conectar();


               cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace+ "Detalhes Exception");
            }
            finally
            {
                conexao.Desconectar();
            }                  
        }
        public void GetAlterar(ModeloItensCompra modelo)
        {
            Alterar(modelo);
        }


        private void Excluir(ModeloItensCompra modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = $"delete from itenscompra where itc_cod = @itc_cod and com_cod = @com_cod and pro_cod = @pro_cod";

                cmd.Parameters.AddWithValue("@itc_cod", modelo.ItcCod);                
                cmd.Parameters.AddWithValue("@com_cod", modelo.ComCod);
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);

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
        public void GetExcluir(ModeloItensCompra modelo)
        {
            Excluir(modelo);
        }



        private DataTable Localizar(int codigo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from itenscompra where com_cod = {codigo.ToString()}", conexao.StringConexao);
            dataAdapter.Fill(tabela);

            return tabela;
        }
        public DataTable GetLocalizar(int codigo)
        {
            return Localizar(codigo);
        }


        private ModeloItensCompra CarregaModeloItensCompra(int ItcCodigo, int ComCodigo, int ProCodigo)
        {            
            try
            {                
                ModeloItensCompra modelo = new ModeloItensCompra();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "select * from itenscompra where itc_cod = @itc_cod and com_cod = @com_cod and pro_cod = @pro_cod ";

                cmd.Parameters.AddWithValue("@itc_cod", ItcCodigo);
                cmd.Parameters.AddWithValue("@com_cod", ComCodigo);
                cmd.Parameters.AddWithValue("@pro_cod", ProCodigo);

                conexao.Conectar();

                SqlDataReader Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    Registro.Read();
                    modelo.ItcCod = ItcCodigo;
                    modelo.ComCod = ComCodigo;
                    modelo.ProCod = ProCodigo;
                    modelo.ItcQtde = Convert.ToDouble(Registro["@itc_qtde"]);
                    modelo.ItcValor = Convert.ToDouble(Registro["@itc_valor"]);

                    return modelo;
                }                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace + "Detalhes Exception");
            }
            finally
            {
                conexao.Desconectar();               
            }
            return null;
        }  
        public ModeloItensCompra GetCarregaModeloItensCompra(int ItcCodigo, int ComCodigo, int ProCodigo)
        {
           return CarregaModeloItensCompra(ItcCodigo, ComCodigo, ProCodigo);
        }        

        
    }
}
