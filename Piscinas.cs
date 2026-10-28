using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class Piscinas : Atracciones
    {
        private double _profundidadMetros;
        private bool _requiereTrajeBano;

        public Piscinas(
            string id,
            string nombre,
            int capacidadPersona,
            EstadoAtraccion estadoAtraccion,
            double profundidadMetros,
            bool requiereTrajeBano)
            : base(id, nombre, capacidadPersona, estadoAtraccion)
        {
            this.ProfundidadMetros = profundidadMetros;
            this.RequiereTrajeBano = requiereTrajeBano;
        }

        public double ProfundidadMetros
        {
            get { return _profundidadMetros; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("la profundidad debe ser mayor que cero.");
                }
                _profundidadMetros = value;
            }
        }

        public bool RequiereTrajeBano
        {
            get { return _requiereTrajeBano; }
            set { _requiereTrajeBano = value; }
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            string textoTraje = _requiereTrajeBano ? "si" : "no";
            Console.WriteLine($"   Piscina de {_profundidadMetros} m de profundidad | Requiere traje de baño: {textoTraje}");
        }

        public override bool RegistrarIngreso(int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad de personas debe ser mayor que cero.");
                return false;
            }

            if (EstadoAtraccion != EstadoAtraccion.Disponible)
            {
                Console.WriteLine($"{Nombre} no esta disponible en este momento ({EstadoAtraccion}).");
                return false;
            }

            if (AforoActual + cantidad > CapacidadPersona)
            {
                Console.WriteLine($"No se puede ingresar a {Nombre}. porque la capacidad maxima es de: {CapacidadPersona}");
                return false;
            }

            AforoActual += cantidad;

            Console.WriteLine("Ingreso registrado correctamente.");
            Console.WriteLine($"Personas que ingresaron: {cantidad}");
            Console.WriteLine($"Aforo actual: {AforoActual}");
            Console.WriteLine($"Capacidad maxima: {CapacidadPersona}");
            return true;
        }

        public override string FotoSugerida()
        {
            return "una foto de la piscina mas grande con toboganes y con el agua cristalina";
        }

        public override double CalcularCostos(int cantidad)
        {
            return 0.00;
        }
    }
}
