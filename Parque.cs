using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class Parque
    {
        protected string Nombre;
        protected TipoParque tipoParque;
        protected string Ubicacion;
        protected string HorarioAtencion;
        protected double PrecioEntradaBase;
        private bool abierto = false;
        protected List<Atracciones> listaAtracciones;

        // Variables de control para lo de las ventas
        private int boletosVendidos = 0;
        private double totalRecaudado = 0.0;

        public Parque(string nombre, TipoParque tipoParque, string ubicacion, string horarioAtencion, double precioEntradaBase)
        {
            this.Nombre = nombre;
            this.tipoParque = tipoParque;
            this.Ubicacion = ubicacion;
            this.HorarioAtencion = horarioAtencion;
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

        public string HorarioAtencionParque
        {
            get { return HorarioAtencion; }
            set { HorarioAtencion = value; }
        }

        public double PrecioEntradaBaseParque
        {
            get { return PrecioEntradaBase; }
            set { PrecioEntradaBase = value < 0 ? throw new ArgumentException("Precio no es valido") : value; }
        }

        public bool Abierto
        {
            get { return abierto; }
        }

        public List<Atracciones> ListaAtracciones
        {
            get { return listaAtracciones; }
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre del Parque: {Nombre}");
            Console.WriteLine($"Tipo de Parque: {tipoParque}");
            Console.WriteLine($"Ubicación: {Ubicacion}");
            Console.WriteLine($"Horario de Atención: {HorarioAtencion}");
            Console.WriteLine($"Precio de Entrada Base: {PrecioEntradaBase:C}");
            Console.WriteLine("Lista de Atracciones:");
        }

        public void AbrirParque()
        {
            abierto = true;
            Console.WriteLine(Nombre + " ya abrio sus puertas. Horario: " + HorarioAtencion);
        }

        public void AgregarAtraccion(Atracciones a)
        {
            if (a == null)
            {
                Console.WriteLine("No se puede agregar una atraccion vacia.");
            }
            else
            {
                listaAtracciones.Add(a);
            }
        }

        public int GetCantidadAtracciones()
        {
            return listaAtracciones.Count;
        }

        public Atracciones GetAtraccion(int posicion)
        {
            if (posicion < 0 || posicion >= listaAtracciones.Count)
            {
                return null;
            }
            return listaAtracciones[posicion];
        }

        public void ListarAtracciones()
        {
            Console.WriteLine($"\n--- Atracciones del parque {Nombre} ---");

            if (listaAtracciones.Count == 0)
            {
                Console.WriteLine("No hay atracciones registradas.");
                return;
            }

            foreach (Atracciones atraccion in listaAtracciones)
            {
                Console.WriteLine("-----------------------------");
                atraccion.MostrarInformacion();
            }
        }

        public double CalcularPrecioEntrada(Visitantes v)
        {
            double precio = PrecioEntradaBase * v.VisitantesEnGrupo;
            if (v.EsExtranjero)
            {
                precio = precio * 2;
            }
            return precio;
        }

        public Boleto VenderBoleto(Visitantes v)
        {
            boletosVendidos = boletosVendidos + 1;
            string numero = "B-" + (100 + boletosVendidos);
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//de esta forma captura la fecha y hora exacta en que se vendio el boleto
            Boleto b = new Boleto(numero, CalcularPrecioEntrada(v), fecha, v);
            return b;
        }

        public void ProcesarPago(Visitantes v)
        {
            Boleto b = v.Boleto;
            if (b == null)
            {
                Console.WriteLine("El visitante todavía no tiene boleto.");
            }
            else if (b.pagado)
            {
                Console.WriteLine("Este boleto ya fue pagado.");
            }
            else
            {
                b.ImprimirComprobante(this);
                totalRecaudado = totalRecaudado + b.CalcularTotal();
                b.pagado = true;
                Console.WriteLine("Pago recibido. ¡Gracias, " + v.Nombre + "!");
            }
        }
    }
}
