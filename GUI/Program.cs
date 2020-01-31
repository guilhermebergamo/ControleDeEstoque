using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

            //BASEADO EM CAMADAS, IREMOS IMPLEMENTAR MODELOS QUE IRA REPRESENTAR AS TABELAS
            //ESSES MODELOS SERAM UTILIZADAS PELA CAMADA --DALL-- QUE REALIZA A CONEXAO AO BANCO
            //--DLL-- QUE FAZ A VALIDAÇÃO DOS DADOS 
            //E CAMADA DE INTERFACE GRAFICA PARA INTERAÇÃO COM O CLIENTE

namespace GUI
{
                            //-----REPRESENTA A MINHA INTERFACE GRAFICA DO MEU SISTEMA-----
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Principal());
        }
    }
}
