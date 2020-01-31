using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Ferramentas;

namespace GUI
{
    public partial class Frm_BackupBancoDeDados : Form
    {
        public Frm_BackupBancoDeDados()
        {
            InitializeComponent();
        }

        private void btBackup_Click(object sender, EventArgs e)
        {

            try
            {

                SaveFileDialog Explore = new SaveFileDialog();      //ABRE EXPLORER PARA ESCOLHAR LOCAL DO ARQUIVO !
                Explore.Filter = "Backup Files |*.bak";     //FILTRO SERA TODOS OS ARQUIVO COM EXTENSAO .BAK !
                Explore.ShowDialog();       //MOSTRA A JANELA PARA USUARIO !

                if (Explore.FileName != "") // SE FOI INFORMADO UM NOME AO ARQUIVO -- != DE VAZIO
                {
                    string NameDB = DadosDaConexao.Banco;      //RECEBE NOME DO BANCO DE DADOS !

                    string LocalBackup = Explore.Filter;

                    string conexao = $"Data Source={DadosDaConexao.Servidor};Initial Catalog=master;User={DadosDaConexao.Usuario};Password={DadosDaConexao.Senha}"; //SE CONECTARA COM STRINGDECONEXAO !

                    SQLServerBackup.BackupDataBase(conexao, NameDB, Explore.FileName);      //CLASS, METODO, PARAMETROS

                    txtCaminho.Text = Explore.InitialDirectory;

                    MessageBox.Show("Backup realizado com sucesso !");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btRestaurar_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog Explore = new OpenFileDialog();      //ABRE EXPLORER PARA ESCOLHAR LOCAL DO ARQUIVO !
                Explore.Filter = "Backup Files |*.bak";     //FILTRO SERA TODOS OS ARQUIVO COM EXTENSAO .BAK !
                Explore.ShowDialog();       //MOSTRA A JANELA PARA USUARIO !

                if (Explore.FileName != "") // SE FOI INFORMADO UM NOME AO ARQUIVO -- != DE VAZIO
                {

                    txtCaminho.Text = Explore.FileName;

                    string NameDB = DadosDaConexao.Banco;      //RECEBE NOME DO BANCO DE DADOS !

                    string LocalBackup = Explore.Filter;

                    string conexao = $"Data Source={DadosDaConexao.Servidor};Initial Catalog=master;User={DadosDaConexao.Usuario};Password={DadosDaConexao.Senha}"; //SE CONECTARA COM STRINGDECONEXAO !

                    SQLServerBackup.RestauraDatabase(conexao, NameDB, Explore.FileName);      //CLASS, METODO, PARAMETROS

                    MessageBox.Show("Backup restaurado com sucesso !");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
