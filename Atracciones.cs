using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // clase abstracta base para las atracciones
    public abstract class Atracciones
    {
        // atributos privados con guion bajo
        private string _id;
        private string _nombre;
        private int _capacidadPersona;
        private int _aforoActual;
        private EstadoAtraccion _estadoAtraccion;

        // constructor que inicializa los valores
        protected Atracciones(string id, string nombre, int capacidadPersona, EstadoAtraccion estadoAtraccion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.CapacidadPersona = capacidadPersona;
            this.EstadoAtraccion = estadoAtraccion;
            this._aforoActual = 0;
        }

        // propiedad id con validacion sencilla sin excepciones
        public string Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("error debe ingresar un id valido");
                    _id = "sin id";
                }
                else
                {
                    _id = value;
                }
            }
        }

        // propiedad nombre con validacion sencilla
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("error debe ingresar un nombre valido");
                    _nombre = "sin nombre";
                }
                else
                {
                    _nombre = value;
                }
            }
        }

        // propiedad capacidad con validacion sin lanzar excepciones
        public int CapacidadPersona
        {
            get { return _capacidadPersona; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("error la capacidad no puede ser negativa");
                    _capacidadPersona = 0;
                }
                else
                {
                    _capacidadPersona = value;
                }
            }
        }

        // propiedad aforo actual que controla los limites de capacidad
        public int AforoActual
        {
            get { return _aforoActual; }
            set
            {
                if (value < 0 || value > _capacidadPersona)
                {
                    Console.WriteLine("el aforo no puede ser menor a cero ni superar la capacidad");
                }
                else
                {
                    _aforoActual = value;
                }
            }
        }

        // propiedad estado de la atraccion
        public EstadoAtraccion EstadoAtraccion
        {
            get { return _estadoAtraccion; }
            set { _estadoAtraccion = value; }
        }

        // metodo para mostrar los datos de la atraccion
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("ID: " + _id);
            Console.WriteLine("Nombre: " + _nombre);
            Console.WriteLine("Capacidad de personas: " + _capacidadPersona);
            Console.WriteLine("Aforo actual: " + _aforoActual);
            Console.WriteLine("Estado de la atraccion: " + _estadoAtraccion);
        }

        // metodo abstracto para calcular el costo en las clases hijas
        public abstract double CalcularCosto(int cantidad);

        // metodo para actualizar el estado operativo
        public void ActualizarEstado(EstadoAtraccion nuevoEstado)
        {
            _estadoAtraccion = nuevoEstado;
            Console.WriteLine("El estado de " + _nombre + " se actualizo a " + _estadoAtraccion);
        }

        // metodo para registrar ingreso y comprobar aforo maximo
        public virtual bool RegistrarIngreso(int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad de personas debe ser mayor que cero.");
                return false;
            }

            if (_estadoAtraccion != EstadoAtraccion.Disponible)
            {
                Console.WriteLine(_nombre + " no esta disponible en este momento " + _estadoAtraccion + ".");
                return false;
            }

            if (_aforoActual + cantidad > _capacidadPersona)
            {
                int espacios = _capacidadPersona - _aforoActual;
                Console.WriteLine("AFORO ESTA SIENDO SUPERADO en " + _nombre + ": solo quedan " + espacios + " espacios y se intentan ingresar " + cantidad + ", puede esperar que se retiren algunas personas.");
                return false;
            }

            _aforoActual += cantidad;
            return true;
        }

        // metodo para restar personas al salir
        public virtual void RegistrarSalida(int cantidad)
        {
            _aforoActual -= cantidad;
            if (_aforoActual < 0)
            {
                _aforoActual = 0;
            }
        }

        // metodo virtual para sugerir foto segun la atraccion
        public virtual string FotoSugerida()
        {
            return "una foto del lugar: " + _nombre;
        }
    }
}