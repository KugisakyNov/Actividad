using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public enum TipoParque
    {
        Narural,
        Acuatico,
    }
    public enum EstadoCAbañas
    {
        Disponible,
        Ocupado,
        Mantenimiento,
    }
    public enum TipoZonaVerde
    {
        Mirador,
        kiosko,
        AreaColumpios
    }
    public enum EstadoActraccion
    {
        Disponible,
        Ocupado,
        Mantenimiento,
    }

    public enum DificultadSendero
    {
        Facil,
        Media,
        Alta
    }
    public enum EspecialidadGuia
    {
        FlorayFauna,
        Vulganologia,
        HistoriayGeografia,
        senderismo_Avanzado
    }

    public class AforoExcedidoException : Exception
    {
        public AforoExcedidoException(string mensaje)
            : base(mensaje)
        {
        }
    }

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



        class Parque
        {
            protected string Nombre;
            protected TipoParque tipoParque;
            protected string Ubicacion;
            protected string HorarioAtraccion;
            protected double PrecioEntradaBase;
            protected List<Atracciones> listaAtracciones;

            public Parque(string nombre, TipoParque tipoParque, string ubicacion, string horarioAtraccion, double precioEntradaBase)
            {
                this.Nombre = nombre;
                this.tipoParque = tipoParque;
                this.Ubicacion = ubicacion;
                this.HorarioAtraccion = horarioAtraccion;
                this.PrecioEntradaBase = precioEntradaBase;
                this.listaAtracciones = new List<Atracciones>();
            }
            public string NombreParque
            {
                get { return Nombre; }
                set { Nombre = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Ingresar Nombre") : value; }
            }

            public TipoParque TipoParque
            {
                get { return tipoParque; }
                set { tipoParque = value; }
            }

            public string UbicacionParque
            {
                get { return Ubicacion; }
            }
            public string HorarioAtraccionParque
            {
                get { return HorarioAtraccion; }
                set { HorarioAtraccion = value; }
            }
            public double PrecioEntradaBaseParque
            {
                get { return PrecioEntradaBase; }
                set { PrecioEntradaBase = value < 0 ? throw new ArgumentException("Precio no Valido") : value; }
            }

            public List<Atracciones> ListaAtracciones
            {
                get { return listaAtracciones; }
            }

            public void MostrarInformacion()
            {
                Console.WriteLine($"Nombre del Parque: {Nombre}");
                Console.WriteLine($"Tipo de Parque: {tipoParque}");
                Console.WriteLine($"Ubicación: {Ubicacion}");
                Console.WriteLine($"Horario de Atracciones: {HorarioAtraccion}");
                Console.WriteLine($"Precio de Entrada Base: {PrecioEntradaBase:C}");
                Console.WriteLine("Lista de Atracciones:");

            }

            public void AgregarAtraccion(Atracciones atraccion)
            {
                listaAtracciones.Add(atraccion);
            }



        }




        internal class Program
        {
            static void Main(string[] args)
            {
            }
        }
    }
}
