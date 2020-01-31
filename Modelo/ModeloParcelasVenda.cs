using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasVenda
    {
        public ModeloParcelasVenda()
        {
            PveCod = 0;
            PveValor = 0;
            VenCod = 0;
            PveDataPagamento = DateTime.Now;
            PveDataVencimento = DateTime.Now;
        }
            

        private int Pve_cod;
        public int PveCod
        {
            get
            {
                return PveCod;
            }
            set
            {
                PveCod = value;
            }
        }

        private int ven_cod;
        public int VenCod
        {
            get
            {
                return ven_cod;
            }
            set
            {
                ven_cod = value;
            }
        }


        private double Pve_valor;
        public double PveValor
        {
            get
            {
                return PveValor;
            }
            set
            {
                PveValor = value;
            }
        }

        private DateTime Pve_datapgto;
        public DateTime PveDataPagamento
        {
            get
            {
                return Pve_datapgto;
            }
            set
            {
                Pve_datapgto = value;
            }
        }

        private DateTime Pve_datavecto;
        public DateTime PveDataVencimento
        {
            get
            {
                return Pve_datavecto;
            }
            set
            {
                Pve_datavecto = value;
            }
        }
    }
}



