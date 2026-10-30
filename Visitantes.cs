using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // clase concreta para modelar a los visitantes de los parques
    public class Visitantes
    {
        // atributos privados 
        private string _duiOPasaporte;
        private string _nombre;
        private int _edad;
        private int _personasEnGrupo;
        private bool _esExtranjero;
        private Boleto _boleto;
        private Parque _parqueVisitado;
        private List<Atracciones> _atraccionesVisitadas;
        private int _fotosTomadas;

        // constructor
        public Visitantes(string duiOPasaporte, string nombre, int edad, int personasEnGrupo, bool esExtranjero)
        {
            this.DuiOPasaporte = duiOPasaporte;
            this.Nombre = nombre;
            this.Edad = edad;
            this.VisitantesEnGrupo = personasEnGrupo;
            this.EsExtranjero = esExtranjero;
            this._atraccionesVisitadas = new List<Atracciones>();
            this._fotosTomadas = 0;
            this._parqueVisitado = null;
            this._boleto = null;
        }

        // propiedad dui o pasaporte no puede estar vacio, si lo esta se asigna: sin documento
        public string DuiOPasaporte
        {
            get { return _duiOPasaporte; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el DUI o pasaporte no puede estar vacio");
                    _duiOPasaporte = "sin documento";
                }
                else
                {
                    _duiOPasaporte = value.Trim();
                }
            }
        }

        // propiedad nombre con validacion de texto
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el nombre no puede estar vacio");
                    _nombre = "sin nombre";
                }
                else
                {
                    _nombre = value.Trim();
                }
            }
        }

        // propiedad edad con rango permitido de 0 a 100
        public int Edad
        {
            get { return _edad; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("la edad debe estar entre 0 y 100");
                    _edad = 18;
                }
                else
                {
                    _edad = value;
                }
            }
        }

        // propiedad para la cantidad de personas en el grupo
        public int VisitantesEnGrupo
        {
            get { return _personasEnGrupo; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("el grupo debe tener al menos una persona");
                    _personasEnGrupo = 1;
                }
                else
                {
                    _personasEnGrupo = value;
                }
            }
        }

        // propiedad para indicar si es visitante extranjero
        public bool EsExtranjero
        {
            get { return _esExtranjero; }
            set { _esExtranjero = value; }
        }

        // atributo booleano para controlar si ya liquido el costo de la cabaña
        private bool _extrasPagados = false;

        // propiedad para el boleto adquirido
        public Boleto Boleto
        {
            get { return _boleto; }
            set { _boleto = value; }
        }

        // propiedad para el parque donde se encuentra actualmente
        public Parque ParqueVisitado
        {
            get { return _parqueVisitado; }
            set { _parqueVisitado = value; }
        }

        // propiedad de solo lectura para la lista de atracciones visitadas
        public List<Atracciones> AtraccionesVisitadas
        {
            get { return _atraccionesVisitadas; }
        }

        // propiedad para el contador de fotografias
        public int FotosTomadas
        {
            get { return _fotosTomadas; }
            set { _fotosTomadas = value; }
        }
        public void MostrarTotalFotosTomadas()
        {
            Console.WriteLine(Nombre + " tomo: " + _fotosTomadas + " fotos en tolal");
        }
        // metodo para registrar la llegada a la taquilla
        public void RegistrarLlegada()
        {
            Console.WriteLine($"{_nombre} ha llegado a la entrada con un grupo de {_personasEnGrupo} personas.");
        }

        // metodo para entrar al parque y adquirir boleto
        public void EntrarAlParque(Parque parque)
        {
            if (parque == null)
            {
                Console.WriteLine("El parque elegido no es valido.");
                return;
            }

            if (_parqueVisitado != null)
            {
                Console.WriteLine($"{_nombre} ya esta en el {_parqueVisitado.NombreParque}.");
            }
            else if (!parque.Abierto)
            {
                Console.WriteLine($"{parque.NombreParque} cerrado en este momento.");
            }
            else
            {
                _boleto = parque.VenderBoleto(this);
                _parqueVisitado = parque;
                Console.WriteLine($"{_nombre} ha comprado el boleto {_boleto.NumeroBoleto} por ${_boleto.PrecioEntrada.ToString("0.00")} y ha entrado a {parque.NombreParque}.");
            }
        }

        // en VisitarAtraccion si entra a una atraccion en nuestro caso solo la cabaña con costo extra se activa la deuda
        public void VisitarAtraccion(Atracciones atraccion)
        {
            if (atraccion == null)
            {
                Console.WriteLine("Esa atraccion que selecciono no existe.");
                return;
            }

            if (_parqueVisitado == null)
            {
                Console.WriteLine("Primero debe entrar a un parque.");
                return;
            }

            if (!_parqueVisitado.ListaAtracciones.Contains(atraccion))
            {
                Console.WriteLine(atraccion.Nombre + " no esta en el " + _parqueVisitado.NombreParque + ".");
                return;
            }

            if (_atraccionesVisitadas.Contains(atraccion))
            {
                Console.WriteLine("Ya visitaste " + atraccion.Nombre + ".");
                return;
            }

            bool pudoEntrar = atraccion.RegistrarIngreso(_personasEnGrupo);
            if (pudoEntrar)
            {
                _atraccionesVisitadas.Add(atraccion);
                Console.WriteLine(_nombre + " entra a " + atraccion.Nombre + ".");

                // si la atraccion tiene costo mayor a cero queda pendiente el pago de extras
                if (atraccion.CalcularCosto(_personasEnGrupo) > 0)
                {
                    _extrasPagados = false;
                }
            }
        }

        // metodo para salir del parque
        // metodo para salir del parque retornando si pudo salir o no
        public bool SalirDelParque()
        {
            if (_parqueVisitado == null)
            {
                Console.WriteLine(_nombre + " no esta dentro de ningun parque.");
                return false;
            }

            // solo exige pasar por caja si debe servicios adicionales
            if (CalcularCostoAtracciones() > 0 && !_extrasPagados)
            {
                Console.WriteLine("Tienes pendiente el pago de tu cabana o servicio extra. Pasa por la Opcion 6 antes de salir.");
                return false;
            }

            for (int i = 0; i < _atraccionesVisitadas.Count; i++)
            {
                _atraccionesVisitadas[i].RegistrarSalida(_personasEnGrupo);
            }
            _atraccionesVisitadas.Clear();

            Console.WriteLine(_nombre + " ha salido de " + _parqueVisitado.NombreParque + ".");
            _parqueVisitado = null;
            _boleto = null;
            _extrasPagados = false;
            return true;
        }

        //metodo para marcar servicios extras del visitante como pagados, para poder salir del parque
        public void MarcarExtrasPagados()
        {
            _extrasPagados = true;
        }
        // metodo para tomar foto segun la atraccion, primero tiene que visitar la atraccion sino no puede tomar la foto
        public void TomarFoto(Atracciones atraccion)
        {
            if (atraccion == null)
            {
                Console.WriteLine("No hay atraccion para fotografiar.");
            }
            else if (!_atraccionesVisitadas.Contains(atraccion))
            {
                Console.WriteLine($"Primero debes visitar {atraccion.Nombre} para tomarle una foto.");
            }
            else
            {
                _fotosTomadas++;
                Console.WriteLine($"{_nombre} toma la foto #{_fotosTomadas}: {atraccion.FotoSugerida()}.");
            }
        }

        // metodo para calcular el costo total
        public double CalcularCostoAtracciones()
        {
            double total = 0.0;
            for (int i = 0; i < _atraccionesVisitadas.Count; i++)
            {
                total += _atraccionesVisitadas[i].CalcularCosto(_personasEnGrupo);
            }
            return total;
        }
        
    }
}
