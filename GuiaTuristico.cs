using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{

    // clase concreta para modelar al guia turistico del parque
    public class GuiaTuristico
    {
        //miembro estatico para contar el total de recorridos asignados al guia 
        public static int TotalRecorridos = 0;
        // atributos privados 
        private string _carnetGuia;
        private string _nombre;
        private EspecialidadGuia _especialidad;
        private bool _estaDisponible;
        private Sendero _senderoAsignado;
        private int _recorridosAsignados;
        private int _recorridosRealizados;





        // constructor para inicializar los datos del guia
        public GuiaTuristico(string carnetGuia, string nombre, EspecialidadGuia especialidad, bool estaDisponible)
        {
            this.CarnetGuia = carnetGuia;
            this.Nombre = nombre;
            this.Especialidad = especialidad;
            this.EstaDisponible = estaDisponible;
        }

        // propiedad carnet del guia con validacion sencilla
        public string CarnetGuia
        {
            get { return _carnetGuia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el carnet del guia no puede estar vacio");
                    _carnetGuia = "sin carnet";
                }
                else
                {
                    _carnetGuia = value.Trim();
                }
            }
        }

        // propiedad nombre del guia validada
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el nombre del guia no puede estar vacio");
                    _nombre = "sin nombre";
                }
                else
                {
                    _nombre = value.Trim();
                }
            }
        }

        // propiedad especialidad del guia
        public EspecialidadGuia Especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }

        // propiedad para verificar si esta libre
        public bool EstaDisponible
        {
            get { return _estaDisponible; }
            set { _estaDisponible = value; }
        }

        // propiedad de solo lectura para el sendero asignado
        public Sendero SenderoAsignado
        {
            get { return _senderoAsignado; }
        }
        public int RecorridosAsignados
        {
            get { return _recorridosAsignados; }
        }

        public int RecorridosRealizados
        {
            get { return _recorridosRealizados; }
        }

        // metodo para asignar un recorrido al sendero 
        public void AsignarRecorrido(Sendero sendero)
        {
            if (!_estaDisponible)
            {
                Console.WriteLine("El guia " + _nombre + " ya esta ocupado en otro recorrido.");
            }
            else if (sendero == null)
            {
                Console.WriteLine("No hay sendero para asignar.");
            }
            else
            {
                _senderoAsignado = sendero;
                sendero.GuiaAsignado = this;
                _estaDisponible = false;
                TotalRecorridos++;
                Console.WriteLine("El guia " + _nombre + " fue asignado al sendero: " + sendero.Nombre + ".");
            }
        }
        //metodo para mostrar el total de recorridos
        public void MostrarTotalRecorridos()
        {
            Console.WriteLine("Total de recorridos asignados al guia: "+ TotalRecorridos);
        }
        // metodo para terminar el recorrido y liberar al guia
        public void FinalizarRecorrido()
        {
            if (_senderoAsignado != null)
            {
                _senderoAsignado.GuiaAsignado = null;
                _senderoAsignado = null;

                _recorridosRealizados++;
            }
            _estaDisponible = true;
            Console.WriteLine("El guia " + _nombre + " termino su recorrido y ya esta disponible.");
        }
    }
}