using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCompra
    {

        public ModeloCompra()
        {
            ComCod = 0;
            ComData = Convert.ToDateTime(DateTime.Now);             //PEGA DATA ATUAL DO SISTEMA
            ComNfiscal = 0;
            ComTotal = 0;
            ComNparcelas = 0;
            ComStatus = "";
            ForCod = 0;
            TpaCod = 0;
        }

        public ModeloCompra(int comCod, DateTime data, int nfiscar, int total, 
                            int nParcelas, string status, int forCod, int tpaCod)
        {
            ComCod = comCod;
            ComData = data;
            ComNfiscal = nfiscar;
            ComTotal = total;
            ComNparcelas = nParcelas;
            ComStatus = status;
            ForCod = forCod;
            TpaCod = tpaCod;
        }


        private int _com_cod;
        public int ComCod
        {
            get
            {
                return _com_cod;
            }
            set
            {
                _com_cod = value;
            }
        }

        private DateTime _com_data;
        public DateTime ComData
        {
            get
            {
                return _com_data;
            }
            set
            {
                _com_data = value;
            }
        }

        private int _com_Nfiscal;
        public int ComNfiscal
        {
            get
            {
                return _com_Nfiscal;
            }
            set
            {
                _com_Nfiscal = value;
            }
        }

        private double _com_total;
        public double ComTotal
        {
            get
            {
                return _com_total;
            }
            set
            {
                _com_total = value;
            }
        }

        private int _com_nparcelas;
        public int ComNparcelas
        {
            get
            {
                return _com_nparcelas;
            }
            set
            {
                _com_nparcelas = value;
            }
        }

        private string _com_status;
        public string ComStatus
        {
            get
            {
                return _com_status;
            }
            set
            {
                _com_status = value;
            }
        }

        private int _for_cod;
        public int ForCod
        {
            get
            {
                return _for_cod;
            }
            set
            {
                _for_cod = value;
            }
        }

        private int _tpa_cod;
        public int TpaCod
        {
            get
            {
                return _tpa_cod;
            }
            set
            {
                _tpa_cod = value;
            }
        }

        











    }
}










        












  