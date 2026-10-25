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
        protected string name;
        protected int Capacidadpersona;
        protected EstadoActraccion estadoAtraccion;

        protected Atracciones(string id, string name, int capacidadpersona, EstadoActraccion estadoAtraccion)
        {
            this.id = id;
            this.name = name;
            this.Capacidadpersona = capacidadpersona;
            this.estadoAtraccion = estadoAtraccion;
        }

        public string Id
        {
            get { return id; }
            set { id = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Ingresar ID") : value; }

        }
    }
    
}
