using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class Boleto
    {
        private string _numeroBoleto;
        private double _precioEntrada;
        private string _fechaEmision;
        private Visitantes _cliente;
        private bool _pagado = false;

        public Boleto(string numeroBoleto, double precioEntrada, string fechaEmision, Visitantes cliente)
        {
            this.numeroBoleto = numeroBoleto;
            this.precioEntrada = precioEntrada;
            this.fechaEmision = fechaEmision;
            this.cliente = cliente;
        }

        public string numeroBoleto
        {
            get { return _numeroBoleto; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el numero de boleto no puede estar vacio.");
                }
                else
                {
                    _numeroBoleto = value.Trim();
                }
            }
        }

        public double precioEntrada
        {
            get { return _precioEntrada; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("el precio de la entrada no puede ser negativo");
                }
                else
                {
                    _precioEntrada = value;
                }
            }
        }

        public string fechaEmision
        {
            get { return _fechaEmision; }
            set { _fechaEmision = value; }
        }

        public Visitantes cliente
        {
            get { return _cliente; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("el boleto debe pertenecer a un visitante.");
                }
                else
                {
                    _cliente = value;
                }
            }
        }

        public bool pagado
        {
            get { return _pagado; }
            set { _pagado = value; }
        }

        //Metodo para calcular el total a pagar por el boleto incluyendo las atracciones visitadas por el cliente.
        public double CalcularTotal()
        {
            if (_cliente == null)
            {
                return _precioEntrada;
            }
            return _precioEntrada + _cliente.CalcularCostoAtracciones();
        }

        //Metodo para imprimir el comprobante del boleto incluyendo el precio de entrada y el total a pagar.
        public void ImprimirComprobante(Parque parque)
        {
            Console.WriteLine("----------- COMPROBANTE -----------");
            Console.WriteLine($"Boleto: {_numeroBoleto}  Fecha: {_fechaEmision}");
            Console.WriteLine($"Visitante: {_cliente?.Nombre} (grupo de {_cliente?.VisitantesEnGrupo})");
            Console.WriteLine($"Entrada al parque: ${_precioEntrada:0.00}");

            if (_cliente != null)
            {
                for (int i = 0; i < _cliente.AtraccionesVisitadas.Count; i++)
                {
                    Atracciones at = _cliente.AtraccionesVisitadas[i];
                    double costo = at.CalcularCostos(_cliente.VisitantesEnGrupo);
                    Console.WriteLine($"  {at.Nombre}: ${costo:0.00}");
                }
            }

            Console.WriteLine($"TOTAL A PAGAR: ${CalcularTotal():0.00}");
            Console.WriteLine("----------------------------------------");
        }
    }
}