using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    internal class Boleto
    {
        private string NumeroBoleto;
        private double PrecioEntrada;
        private string FechaEmision;
        private Visitantes Cliente;

        public Boleto(string numeroBoleto, double precioEntrada, string fechaEmision, Visitantes cliente)
        {
            NumeroBoleto = numeroBoleto;
            PrecioEntrada = precioEntrada;
            FechaEmision = fechaEmision;
            Cliente = cliente;
        }

        public string numeroBoleto
        {
            get { return NumeroBoleto; }
            set { NumeroBoleto = value; }

        }

        public double precioEntrada
        {
            get { return precioEntrada; }
            set { precioEntrada = value < 0 ? throw new ArgumentException("El precio no es valido."): value; }
        
        }

        public string fechaEmision 
        {
            get { return FechaEmision; }
            set { FechaEmision = value; }
        }


    }
}
