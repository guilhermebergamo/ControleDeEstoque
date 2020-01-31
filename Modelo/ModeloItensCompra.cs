using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloItensCompra
    {

        private int itc_cod;
        public int ItcCod
        {
            get
            {
                return itc_cod;
            }
            set
            {
                itc_cod = value;
            }
        }



        private double itc_qtde;
        public double ItcQtde
        {
            get
            {
                return itc_qtde;
            }
            set
            {
                itc_qtde = value;
            }
        }



        private double itc_valor;
        public double ItcValor
        {
            get
            {
                return itc_valor;
            }
            set
            {
                itc_valor = value;
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



        private int pro_cod;
        public int ProCod
        {
            get
            {
                return pro_cod;
            }
            set
            {
                pro_cod = value;
            }
        }
    }
}
