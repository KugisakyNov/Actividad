using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    class Piscinas : Atracciones
    {
        private double profundidadMetros;
        private bool requiereTrajeBaño;
        private int aforoActual;

        public Piscinas(
            string id,
            string Nombre,
            int capacidadpersona,
            EstadoActraccion estadoActraccion,
            double profundidadMetros,
            bool requiereTrajeBaño,
            int aforoActual)
            : base(id, Nombre, capacidadpersona, estadoActraccion)
        {
            this.profundidadMetros = profundidadMetros;
            this.requiereTrajeBaño = requiereTrajeBaño;
            this.aforoActual = 0;
        }

        public double ProfundidadMetros
        {
            get { return profundidadMetros; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Profundidad inválida.");

                profundidadMetros = value;
            }
        }

        public bool RequiereTrajeBaño
        {
            get { return requiereTrajeBaño; }
            set { requiereTrajeBaño = value; }
        }

        public int AforoActual
        {
            get { return aforoActual; }
            set
            {
                if (value < 0 || value > CapacidadPersona)
                    throw new ArgumentException("Aforo inválido.");

                aforoActual = value;
            }
        }

        public override double CalcularCostos(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException(
                    "Cantidad de personas inválida.");

            if (aforoActual + cantidad > CapacidadPersona)
            {
                throw new ArgumentException(
                    "No se puede ingresar: capacidad de aforo alcanzada.");
            }

            aforoActual += cantidad;

            return 0.00;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Profundidad: {ProfundidadMetros} metros");
            Console.WriteLine($"Requiere traje de baño: {RequiereTrajeBaño}");
            Console.WriteLine($"Aforo actual: {AforoActual}");
            Console.WriteLine($"Capacidad máxima: {CapacidadPersona}");
            Console.WriteLine($"Estado: {EstadoAtraccion}");
        }


        public void RegistrarIngreso(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException(
                    "La cantidad de personas debe ser mayor que cero.");
            }

            if (aforoActual + cantidad > CapacidadPersona)
            {
                throw new ArgumentException(
                    "No se puede ingresar. El aforo máximo de la piscina se superaría.");
            }

            aforoActual += cantidad;

            Console.WriteLine("Ingreso registrado correctamente.");
            Console.WriteLine($"Personas que ingresaron: {cantidad}");
            Console.WriteLine($"Aforo actual: {aforoActual}");
            Console.WriteLine($"Capacidad máxima: {CapacidadPersona}");
        }



    }

}
