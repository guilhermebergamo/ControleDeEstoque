using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasCompra
    {
        public ModeloParcelasCompra()
        {
            PcoCod = 0;
            PcoValor = 0;
            ComCod = 0;
            //PcoDataPagamento = DateTime.Now;
            PcoDataVencimento = DateTime.Now;
        }

        private int pco_cod;
        public int PcoCod
        {
            get
            {
                return pco_cod;
            }
            set
            {
                pco_cod = value;
            }
        }

        private int com_cod;
        public int ComCod
        {
            get
            {
                return com_cod;
            }
            set
            {
                com_cod = value;
            }
        }


        private double pco_valor;
        public double PcoValor
        {
            get
            {
                return pco_valor;
            }
            set
            {
                pco_valor = value;
            }
        }

        private DateTime pco_datapgto;
        public DateTime PcoDataPagamento
        {
            get
            {
                return pco_datapgto;
            }
            set
            {
                pco_datapgto = value;
            }
        }

        private DateTime pco_datavecto;
        public DateTime PcoDataVencimento
        {
            get
            {
                return pco_datavecto;
            }
            set
            {
                pco_datavecto = value;
            }
        }
    }
}
