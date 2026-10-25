using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
     class Boleto
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


        public Visitantes cliente 
        {
            get { return cliente; }
            set { cliente = value ??  throw new ArgumentException("El cliente debe estar ingresado"); }
        
        }

        public double CalcularTotal() 
        {
            return precioEntrada;
        
        }



        public void ImprimirComprobante(Parque parque) 
        {
            Console.WriteLine("\n========== BOLETO ==========");
            Console.WriteLine($"Numero de Boleto: { numeroBoleto}");
            Console.WriteLine($"Visitante: {cliente.Nombre}");
            Console.WriteLine($"Parque: {parque}");
            Console.WriteLine($"Fecha: {FechaEmision}");
            Console.WriteLine($"Total: ${CalcularTotal():0.00}");
            Console.WriteLine("============================");
        }
    }

       


    
}
