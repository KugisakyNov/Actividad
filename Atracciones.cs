using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public abstract class Atracciones
    {
        protected string id;
        protected string nombre;
        protected int Capacidadpersona;
        protected EstadoActraccion estadoAtraccion;

        protected Atracciones(string id, string Nombre, int capacidadpersona, EstadoActraccion estadoAtraccion)
        {
            this.id = id;
            this.nombre = Nombre;
            this.Capacidadpersona = capacidadpersona;
            this.estadoAtraccion = estadoAtraccion;
        }

        public string Id
        {
            get { return id; }
            set { id = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Tiene que ingresar ID") : value; }

        }
        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Tiene que ingresar Nombre") : value; }
        }

        public int CapacidadPersona
        {
            get { return Capacidadpersona; }
            set { Capacidadpersona = value < 0 ? throw new ArgumentException("Capacidad no Valida") : value; }
        }

        public EstadoActraccion EstadoAtraccion
        {
            get { return estadoAtraccion; }
            set { estadoAtraccion = value; }
        }
        public virtual void MostrarInformacion() 
        {

        
        }
    }

   
}
