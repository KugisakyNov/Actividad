using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // subclase cabañas que hereda de atracciones
    public class Cabañas : Atracciones
    {
        // atributos privados con guion bajo
        private int _numeroCabaña;
        private int _numeroHabitaciones;
        private double _precioNoche;
        private EstadoCabaña _estadoHospedaje;

        // constructor
        public Cabañas(string id, string nombre, int capacidadPersona, EstadoAtraccion estadoAtraccion, int numeroCabaña, int numeroHabitaciones, double precioNoche, EstadoCabaña estadoHospedaje)
            : base(id, nombre, capacidadPersona, estadoAtraccion)
        {
            this.NumeroCabaña = numeroCabaña;
            this.NumeroHabitaciones = numeroHabitaciones;
            this.PrecioNoche = precioNoche;
            this.EstadoHospedaje = estadoHospedaje;
        }

        // propiedad numero de cabana con validacion para que el numero sea mayor que cero
        public int NumeroCabaña
        {
            get { return _numeroCabaña; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("el numero de cabana debe ser mayor que cero");
                    _numeroCabaña = 1;
                }
                else
                {
                    _numeroCabaña = value;
                }
            }
        }

        // propiedad numero de habitaciones con un valor por defecto para que no sea menor o igual a cero
        public int NumeroHabitaciones
        {
            get { return _numeroHabitaciones; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("la cabana debe tener al menos una habitacion");
                    _numeroHabitaciones = 1;
                }
                else
                {
                    _numeroHabitaciones = value;
                }
            }
        }

        // propiedad precio por noche sin permitir valores negativos
        public double PrecioNoche
        {
            get { return _precioNoche; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("el precio por noche no puede ser negativo");
                    _precioNoche = 0.0;
                }
                else
                {
                    _precioNoche = value;
                }
            }
        }

        // propiedad para el estado especifico de la cabaña
        public EstadoCabaña EstadoHospedaje
        {
            get { return _estadoHospedaje; }
            set { _estadoHospedaje = value; }
        }

        // metodo para reservar la cabaña si se encuentra libre
        public bool Reservar()
        {
            if (_estadoHospedaje == EstadoCabaña.Disponible)
            {
                _estadoHospedaje = EstadoCabaña.Ocupado;
                Console.WriteLine("La cabaña: " + Nombre + " esta reservada");
                return true;
            }
            Console.WriteLine("La cabaña: " + Nombre + " no se puede reservar su estado es: " + _estadoHospedaje);
            return false;
        }

        // metodo para cancelar la reserva y liberar la cabaña
        public void CancelarReservacion()
        {
            if (_estadoHospedaje == EstadoCabaña.Ocupado)
            {
                _estadoHospedaje = EstadoCabaña.Disponible;
                Console.WriteLine("La reservacion de la " + Nombre + " ya fue actualizada vuelve a estar disponible");
            }
        }

        // metodo para mostrar informacion completa de la cabaña incluyendo el estado de hospedaje
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("Cabaña #" + _numeroCabaña
                + " | Habitaciones: "
                + _numeroHabitaciones + " | Precio por noche: $"
                + _precioNoche.ToString("0.00")
                + " | Hospedaje: " + _estadoHospedaje);
        }

        // metodo para registrar ingreso reservando automaticamente la cabaña si esta disponible
        public override bool RegistrarIngreso(int cantidad)
        {
            if (_estadoHospedaje != EstadoCabaña.Disponible)
            {
                Console.WriteLine("La cabana " + Nombre + " no esta disponible (" + _estadoHospedaje + ")");
                return false;
            }

            bool pudoEntrar = base.RegistrarIngreso(cantidad);
            if (pudoEntrar)
            {
                Reservar();
            }
            return pudoEntrar;
        }

        // metodo para liberar la cabaña al salir
        public override void RegistrarSalida(int cantidad)
        {
            base.RegistrarSalida(cantidad);
            CancelarReservacion();
        }

        // metodo para calcular el costo segun la tarifa
        public override double CalcularCosto(int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("la cantidad de personas debe ser mayor que cero");
                return 0.00;
            }
            return _precioNoche;
        }

        // metodo para sugerir foto en la cabaña
        public override string FotoSugerida()
        {
            return "una foto de la entrada de la cabana #" + _numeroCabaña;
        }
    }
}