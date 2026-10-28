using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // clase concreta para modelar el boleto de entrada y pago
    public class Boleto
    {
        // atributos privados
        private string _numeroBoleto;
        private double _precioEntrada;
        private string _fechaEmision;
        private Visitantes _cliente;
        private bool _pagado;

        // constructor que inicializa los datos del boleto
        public Boleto(string numeroBoleto, double precioEntrada, string fechaEmision, Visitantes cliente)
        {
            this.NumeroBoleto = numeroBoleto;
            this.PrecioEntrada = precioEntrada;
            this.FechaEmision = fechaEmision;
            this.Cliente = cliente;
            this._pagado = false;
        }

        // propiedad numero de boleto con validacion sencilla
        public string NumeroBoleto
        {
            get { return _numeroBoleto; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el numero de boleto no puede estar vacio");
                    _numeroBoleto = "B-000";
                }
                else
                {
                    _numeroBoleto = value.Trim();
                }
            }
        }

        // propiedad precio de entrada sin permitir valores negativos
        public double PrecioEntrada
        {
            get { return _precioEntrada; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("el precio de la entrada no puede ser negativo");
                    _precioEntrada = 0.0;
                }
                else
                {
                    _precioEntrada = value;
                }
            }
        }

        // propiedad para la fecha y hora de emision
        public string FechaEmision
        {
            get { return _fechaEmision; }
            set { _fechaEmision = value; }
        }

        // propiedad para asociar el cliente visitante
        public Visitantes Cliente
        {
            get { return _cliente; }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("el boleto debe pertenecer a un visitante");
                }
                else
                {
                    _cliente = value;
                }
            }
        }

        // propiedad para el estado de pago del boleto
        public bool Pagado
        {
            get { return _pagado; }
            set { _pagado = value; }
        }

        // metodo para calcular el total sumando entrada y atracciones
        public double CalcularTotal()
        {
            if (_cliente == null)
            {
                return _precioEntrada;
            }
            return _precioEntrada + _cliente.CalcularCostoAtracciones();
        }

        // metodo para imprimir el comprobante detallado
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
                    double costo = at.CalcularCosto(_cliente.VisitantesEnGrupo);
                    Console.WriteLine($"{at.Nombre}: ${costo:0.00}");
                }
            }

            Console.WriteLine($"TOTAL A PAGAR: ${CalcularTotal():0.00}");
            Console.WriteLine("----------------------------------------");
        }
    }
}