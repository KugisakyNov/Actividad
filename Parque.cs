using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // clase concreta para modelar los parques
    public class Parque

    {
        // miebro estatico 
        public static int ContadorDeBoletos = 0;

        // atributos privados 
        private string _nombre;
        private TipoParque _tipoParque;
        private string _ubicacion;
        private string _horarioAtencion;
        private double _precioEntradaBase;
        private bool _abierto;
        private List<Atracciones> _listaAtracciones;
        private int _boletosVendidos;
        private double _totalRecaudado;

        // constructor que inicializa los datos del parque y la lista
        public Parque(string nombre, TipoParque tipoParque, string ubicacion, string horarioAtencion, double precioEntradaBase)
        {
            this.NombreParque = nombre;
            this.TipoParque = tipoParque;
            this.UbicacionParque = ubicacion;
            this.HorarioAtencionParque = horarioAtencion;
            this.PrecioEntradaBaseParque = precioEntradaBase;
            this._abierto = false;
            this._listaAtracciones = new List<Atracciones>();
            this._boletosVendidos = 0;
            this._totalRecaudado = 0.0;
        }

        // propiedad nombre del parque con validacion sencilla
        public string NombreParque
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el nombre del parque no puede estar vacio");
                    _nombre = "sin nombre";
                }
                else
                {
                    _nombre = value.Trim();
                }
            }
        }

        // propiedad para el tipo de parque
        public TipoParque TipoParque
        {
            get { return _tipoParque; }
            set { _tipoParque = value; }
        }

        // propiedad para la ubicacion del parque
        public string UbicacionParque
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }

        // propiedad para el horario de atencion
        public string HorarioAtencionParque
        {
            get { return _horarioAtencion; }
            set { _horarioAtencion = value; }
        }

        // propiedad para el precio base validado
        public double PrecioEntradaBaseParque
        {
            get { return _precioEntradaBase; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("el precio de entrada base no puede ser negativo");
                    _precioEntradaBase = 1.50;
                }
                else
                {
                    _precioEntradaBase = value;
                }
            }
        }

        // propiedad para comprobar si el parque esta abierto
        public bool Abierto
        {
            get { return _abierto; }
        }

        // propiedad para acceder a la coleccion de atracciones
        public List<Atracciones> ListaAtracciones
        {
            get { return _listaAtracciones; }
        }

        // metodo para mostrar los datos generales del parque
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre del Parque: {_nombre}");
            Console.WriteLine($"Tipo de Parque: {_tipoParque}");
            Console.WriteLine($"Ubicacion: {_ubicacion}");
            Console.WriteLine($"Horario de Atencion: {_horarioAtencion}");
            Console.WriteLine($"Precio de Entrada Base: ${_precioEntradaBase:0.00}");
            Console.WriteLine("Lista de Atracciones:");
        }

        // metodo para abrir las puertas del parque
        public void AbrirParque()
        {
            _abierto = true;
            Console.WriteLine(_nombre + " ya abrio sus puertas. Horario: " + _horarioAtencion);
        }

        // metodo para agregar atracciones a la coleccion del parque
        public void AgregarAtraccion(Atracciones a)
        {
            if (a == null)
            {
                Console.WriteLine("No se puede agregar una atraccion vacia.");
            }
            else
            {
                _listaAtracciones.Add(a);
            }
        }

        // metodo para obtener el total de atracciones registradas
        public int GetCantidadAtracciones()
        {
            return _listaAtracciones.Count;
        }

        // metodo para obtener una atraccion por su indice
        public Atracciones GetAtraccion(int posicion)
        {
            if (posicion < 0 || posicion >= _listaAtracciones.Count)
            {
                return null;
            }
            return _listaAtracciones[posicion];
        }

        // metodo para listar atracciones registradas
        public void ListarAtracciones()
        {
            Console.WriteLine($"\n--- Atracciones del parque {_nombre} ---");

            if (_listaAtracciones.Count == 0)
            {
                Console.WriteLine("No hay atracciones registradas.");
                return;
            }

            foreach (Atracciones atraccion in _listaAtracciones)
            {
                Console.WriteLine("-----------------------------");
                atraccion.MostrarInformacion();
            }
        }

        // metodo para calcular el precio segun categoria de visitante
        public double CalcularPrecioEntrada(Visitantes v)
        {
            int totalGrupo = v.VisitantesEnGrupo;
            int extranjeros = v.CantidadExtranjeros;
            int nacionales = totalGrupo - extranjeros;

            // tarifa normal para nacionales y doble para extranjeros
            double totalNacionales = nacionales * _precioEntradaBase;
            double totalExtranjeros = extranjeros * (_precioEntradaBase * 2.0);

            return totalNacionales + totalExtranjeros;
        }

        // metodo para vender el boleto cobrando la entrada inmediatamente
        public Boleto VenderBoleto(Visitantes v)
        {
            _boletosVendidos = _boletosVendidos + 1;

            ContadorDeBoletos += v.VisitantesEnGrupo;


            string numero = "B-" + (100 + _boletosVendidos);
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            double costoEntrada = CalcularPrecioEntrada(v);
            Boleto b = new Boleto(numero, costoEntrada, fecha, v);

            // se marca pagada la entrada 
            b.Pagado = true;
            _totalRecaudado = _totalRecaudado + costoEntrada;

            return b;
        }

        // metodo para procesar pagos pendientes de servicios extra como cabañas
        public void ProcesarPago(Visitantes v)
        {
            Boleto b = v.Boleto;
            if (b == null)
            {
                Console.WriteLine("El visitante todavia no tiene boleto.");
                return;
            }

            double costoExtras = v.CalcularCostoAtracciones();

            if (costoExtras == 0)
            {
                Console.WriteLine("No tienes pagos pendientes. Todas las atracciones visitadas estan cubiertas con tu entrada general.");
                return;
            }

            // comprobante solo por los costos adicionales
            Console.WriteLine("----------- PAGO DE SERVICIOS ADICIONALES -----------");
            Console.WriteLine("Boleto: " + b.NumeroBoleto);
            Console.WriteLine("Visitante: " + v.Nombre);
            for (int i = 0; i < v.AtraccionesVisitadas.Count; i++)
            {
                Atracciones at = v.AtraccionesVisitadas[i];
                double costo = at.CalcularCosto(v.VisitantesEnGrupo);
                if (costo > 0)
                {
                    Console.WriteLine("  " + at.Nombre + ": $" + costo.ToString("0.00"));
                }
            }
            Console.WriteLine("TOTAL EXTRA A PAGAR: $" + costoExtras.ToString("0.00"));
            Console.WriteLine("-----------------------------------------------------");

            _totalRecaudado = _totalRecaudado + costoExtras;
            v.MarcarExtrasPagados();
            Console.WriteLine("Pago adicional recibido con exito. Gracias por tu pago, " + v.Nombre + "!");
        }
    }
}