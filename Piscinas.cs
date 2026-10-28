using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // subclase piscinas que hereda de atracciones
    public class Piscinas : Atracciones
    {
        // atributos privados con guion bajo
        private double _profundidadMetros;
        private bool _requiereTrajeBano;

        // constructor que pasa los datos base a la clase padre
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

        // propiedad profundidad con validacion
        public double ProfundidadMetros
        {
            get { return _profundidadMetros; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("error la profundidad debe ser mayor que cero");
                    _profundidadMetros = 1.0;
                }
                else
                {
                    _profundidadMetros = value;
                }
            }
        }

        // propiedad requiere traje de bano
        public bool RequiereTrajeBano
        {
            get { return _requiereTrajeBano; }
            set { _requiereTrajeBano = value; }
        }

        // metodo para mostrar informacion de la piscina
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            string textoTraje = _requiereTrajeBano ? "si" : "no";
            Console.WriteLine($"Piscina de {_profundidadMetros} m de profundidad | Requiere traje de baño: {textoTraje}");
        }

        // metodo para registrar ingreso validando capacidad
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

        // metodo para sugerir foto de la piscina
        public override string FotoSugerida()
        {
            return "una foto de la piscina mas grande con toboganes y con el agua cristalina";
        }

        // metodo abstracto para calcular el costo de la piscina, que en este caso es gratuito
        public override double CalcularCosto(int cantidad)
        {
            return 0.00;
        }
    }
}