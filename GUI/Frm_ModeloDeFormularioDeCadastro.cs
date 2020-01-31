using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_ModeloDeFormularioDeCadastro : Form
    {
        public string Operacao = "";    
        
        public Frm_ModeloDeFormularioDeCadastro()
        {

            InitializeComponent();            
        }
        private void Frm_ModeloDeFormularioDeCadastro_Load(object sender, EventArgs e)
        {

            this.AlterarBotoes(1);
        }

        public void AlterarBotoes(int op)
        {

            PnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;

            if (op == 1)
            {

                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }
            if (op == 2)
            {

                PnDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;                
            }
            if (op == 3)
            {

                btAlterar.Enabled = true;
                btExcluir.Enabled = true; 
                btCancelar.Enabled = true;
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
        }

        private void Frm_ModeloDeFormularioDeCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            //Alterar a propriedade KeyPreview do Formulário para ” true”

            //Preencha o evento KeyDown do Formulário com o seguinte código:            
            if (e.KeyCode == Keys.Enter)
            {

                SelectNextControl(ActiveControl, e.Shift, true, true, true);
            }        

            //Keys == Um valor Keys que é o código de tecla do evento.

            //O código ” !e.Shift” indica que é para mudar para o próximo campo 
            //se pressionado ENTER, e ir para o campo anterior se pressionados SHIFT e ENTER simultaneamente 
            //(o mesmo funcionamento do SHIFT + TAB).
        }

        private void PnDados_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }
    }
}
