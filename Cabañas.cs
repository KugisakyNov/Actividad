using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Actividad
{
    public class Cabañas : Atracciones
    {
        private int _numeroCabaña;
        private int _numeroHabitaciones;
        private double _precioNoche;
        private EstadoCabaña _estadoHospedaje;

        public Cabañas(string id, string nombre, int capacidadPersona, EstadoAtraccion estadoAtraccion,int numeroCabaña, int numeroHabitaciones, double precioNoche, EstadoCabaña estadoHospedaje)
            : base(id, nombre, capacidadPersona, estadoAtraccion)
        {
            NumeroCabaña = numeroCabaña;
            NumeroHabitaciones = numeroHabitaciones;
            PrecioNoche = precioNoche;
            EstadoHospedaje = estadoHospedaje;
        }

        public int NumeroCabaña
        {
            get { return _numeroCabaña; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("el número de cabaña debe ser mayor que cero.");
                }
                else
                {
                    _numeroCabaña = value;
                }
            }
        }

        public int NumeroHabitaciones
        {
            get { return _numeroHabitaciones; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("la cabaña debe tener al menos una habitacion.");
                }
                else
                {
                    _numeroHabitaciones = value;
                }
            }
        }

        public double PrecioNoche
        {
            get { return _precioNoche; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("el precio por noche no puede ser negativo.");
                }
                else
                {
                    _precioNoche = value;
                }
            }
        }

        public EstadoCabaña EstadoHospedaje
        {
            get { return _estadoHospedaje; }
            set { _estadoHospedaje = value; }
        }

        public bool Reservar()
        {
            if (_estadoHospedaje == EstadoCabaña.Disponible)
            {
                _estadoHospedaje = EstadoCabaña.Ocupado;
                Console.WriteLine("La cabaña: " + Nombre + " esta reservada.");
                return true;
            }
            Console.WriteLine("La cabaña: " + Nombre + " no se puede reservar, su estado es: " + _estadoHospedaje + ".");
            return false;
        }

        public void CancelarReservacion()
        {
            if (_estadoHospedaje == EstadoCabaña.Ocupado)
            {
                _estadoHospedaje = EstadoCabaña.Disponible;
                Console.WriteLine("La reservacion de la " + Nombre + " ya fue actualizada, vuelve a estar disponible.");
            }
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("Cabaña #" + _numeroCabaña
                + " | Habitaciones: "
                + _numeroHabitaciones + " | Precio por noche: $"
                + _precioNoche.ToString("0.00")
                + " | Hospedaje: " + _estadoHospedaje);
        }

        public override bool RegistrarIngreso(int cantidad)
        {
            if (_estadoHospedaje != EstadoCabaña.Disponible)
            {
                Console.WriteLine("La cabaña " + Nombre + " no esta disponible (" + _estadoHospedaje + ").");
                return false;
            }

            bool pudoEntrar = base.RegistrarIngreso(cantidad);
            if (pudoEntrar)
            {
                Reservar();
            }
            return pudoEntrar;
        }

        public override void RegistrarSalida(int cantidad)
        {
            base.RegistrarSalida(cantidad);
            CancelarReservacion();
        }

        public override double CalcularCostos(int cantidad)
        {
            if (cantidad < 0)
            {
                throw new ArgumentException("La cantidad ingresada es correcta.");
            }
            return _precioNoche * (cantidad == 0 ? 1 : cantidad);
        }

        public override string FotoSugerida()
        {
            return "una foto de la entrada de la cabaña #" + _numeroCabaña;
        }
    }
}
