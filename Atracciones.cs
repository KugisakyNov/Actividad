using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public abstract class Atracciones
    {
        // Campos de respaldo privados/protegidos con guion bajo
        protected string _id;
        protected string _nombre;
        protected int _capacidadPersona;
        protected int _aforoActual;
        protected EstadoAtraccion _estadoAtraccion;

        // Constructor
        protected Atracciones(string id, string nombre, int capacidadPersona, EstadoAtraccion estadoAtraccion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.CapacidadPersona = capacidadPersona;
            this.EstadoAtraccion = estadoAtraccion;
            this._aforoActual = 0;
        }

        // Propiedades públicas con validación
        public string Id
        {
            get { return _id; }
            set { _id = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Tiene que ingresar ID") : value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Tiene que ingresar Nombre") : value; }
        }

        public int CapacidadPersona
        {
            get { return _capacidadPersona; }
            set { _capacidadPersona = value < 0 ? throw new ArgumentException("Capacidad no valida") : value; }
        }

        public int AforoActual
        {
            get { return _aforoActual; }
            set
            {
                if (value < 0 || value > _capacidadPersona)
                {
                    Console.WriteLine($"el aforo debe estar entre 0 y {_capacidadPersona}.");
                }
                else
                {
                    _aforoActual = value;
                }
            }
        }

        public EstadoAtraccion EstadoAtraccion
        {
            get { return _estadoAtraccion; }
            set { _estadoAtraccion = value; }
        }

        // Metodo para mostrar informacion de la atraccion
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Capacidad de personas: {CapacidadPersona}");
            Console.WriteLine($"Aforo actual: {AforoActual}");
            Console.WriteLine($"Estado de la atraccion: {EstadoAtraccion}");
        }

        public abstract double CalcularCostos(int cantidad);

        public void ActualizarEstado(EstadoAtraccion nuevoEstado)
        {
            EstadoAtraccion = nuevoEstado;
            Console.WriteLine($"El estado de {Nombre} se actualizo a {EstadoAtraccion}.");
        }

        // metodo para registrar ingreso de personas a la atraccion
        public virtual bool RegistrarIngreso(int cantidad)
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

            if (_aforoActual + cantidad > _capacidadPersona)
            {
                int espacios = _capacidadPersona - _aforoActual;
                Console.WriteLine($"AFORO SUPERADO en {Nombre}: solo quedan {espacios} espacios y se intentan ingresar {cantidad}, puede esperar que se retiren algunas personas.");
                return false;
            }

            _aforoActual += cantidad;
            return true;
        }

        public virtual void RegistrarSalida(int cantidad)
        {
            _aforoActual -= cantidad;
            if (_aforoActual < 0)
            {
                _aforoActual = 0;
            }
        }

        public virtual string FotoSugerida()
        {
            return "una foto del lugar: " + Nombre;
        }
    }
}