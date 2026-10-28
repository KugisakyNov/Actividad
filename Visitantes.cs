using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class Visitantes
    {
        private string _duiOPasaporte;
        private string _nombre;
        private int _edad;
        private int _enGrupo;
        private bool _esExtranjero;
        private Boleto _boleto;
        private Parque _parqueVisitado;
        private List<Atracciones> _atraccionesVisitadas;
        private int _fotosTomadas;

        public Visitantes(string duiOPasaporte, string nombre, int edad, int enGrupo, bool esExtranjero)
        {
            DuiOPasaporte = duiOPasaporte;
            Nombre = nombre;
            Edad = edad;
            VisitantesEnGrupo = enGrupo;
            EsExtranjero = esExtranjero;
            _atraccionesVisitadas = new List<Atracciones>();
            _fotosTomadas = 0;
        }

        public string DuiOPasaporte
        {
            get { return _duiOPasaporte; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Del DUI o pasaporte no puede estar vacio.");
                }
                else
                {
                    _duiOPasaporte = value.Trim();
                }
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el nombre no puede estar vacio.");
                }
                else
                {
                    _nombre = value.Trim();
                }
            }
        }

        public int Edad
        {
            get { return _edad; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("la edad debe estar entre 0 y 100");
                }
                else
                {
                    _edad = value;
                }
            }
        }

        public int VisitantesEnGrupo
        {
            get { return _enGrupo; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("el grupo debe tener al menos una persona.");
                    _enGrupo = 1;
                }
                else
                {
                    _enGrupo = value;
                }
            }
        }

        public bool EsExtranjero
        {
            get { return _esExtranjero; }
            set { _esExtranjero = value; }
        }

        public Boleto Boleto
        {
            get { return _boleto; }
            set { _boleto = value; }
        }

        public Parque ParqueVisitado
        {
            get { return _parqueVisitado; }
            set { _parqueVisitado = value; }
        }

        public List<Atracciones> AtraccionesVisitadas
        {
            get { return _atraccionesVisitadas; }
        }

        public int FotosTomadas
        {
            get { return _fotosTomadas; }
            set { _fotosTomadas = value; }
        }


        // Metodo para registrar la llegada del visitante al parque
        public void RegistrarLlegada()
        {
            Console.WriteLine($"{_nombre} a llegado a la entrada con un grupo de {_enGrupo} personas");
        }
        //Metodo para registrar la entrada del visitante al parque
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
                Console.WriteLine($"{_nombre} ha comprado el boleto {_boleto.numeroBoleto} por {_boleto.precioEntrada:C} y a entrado a {parque.NombreParque}.");
            }
        }

        // Metodo para registrar la visita del visitante a una atraccion
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

            //se valida que la atracción pertenezca a la lista del parque
            if (!_parqueVisitado.ListaAtracciones.Contains(atraccion))
            {
                Console.WriteLine($"{atraccion.Nombre} no esta en el {_parqueVisitado.NombreParque}.");
                return;
            }

            if (_atraccionesVisitadas.Contains(atraccion))
            {
                Console.WriteLine($"Ya visitaste {atraccion.Nombre}.");
                return;
            }

            bool pudoEntrar = atraccion.RegistrarIngreso(_enGrupo);
            if (pudoEntrar)
            {
                _atraccionesVisitadas.Add(atraccion);
                Console.WriteLine($"{_nombre} entra a {atraccion.Nombre}.");
            }
        }

        //Metodo para tomar una foto de la atraccion visitada
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
        //Metodo para calcular el costo total de las atracciones visitadas
        public double CalcularCostoAtracciones()
        {
            double total = 0.0;
            for (int i = 0; i < _atraccionesVisitadas.Count; i++)
            {
                total += _atraccionesVisitadas[i].CalcularCostos(_enGrupo);
            }
            return total;
        }
        //Metodo para salir del parque
        public void SalirDelParque()
        {
            if (_parqueVisitado == null)
            {
                Console.WriteLine($"{_nombre} no esta dentro de ningun parque.");
                return;
            }

            if (_boleto == null || !_boleto.pagado)
            {
                Console.WriteLine("Antes de salir debes pagar.");
                return;
            }

            for (int i = 0; i < _atraccionesVisitadas.Count; i++)
            {
                _atraccionesVisitadas[i].RegistrarSalida(_enGrupo);
            }
            _atraccionesVisitadas.Clear();

            Console.WriteLine($"{_nombre} a salido de {_parqueVisitado.NombreParque}.");
            _parqueVisitado = null;
            _boleto = null;
        }
    }
}
