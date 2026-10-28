using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class GuiaTuristico
    {
        private string _carnetGuia;
        private string _nombreGuia;
        private EspecialidadGuia _especialidad;
        private bool _estaDisponible;
        private Sendero _senderoAsignado;

        public GuiaTuristico(string carnetGuia, string nombreGuia, EspecialidadGuia especialidad, bool estaDisponible)
        {
            CarnetGuia = carnetGuia;
            NombreGuia = nombreGuia;
            Especialidad = especialidad;
            EstaDisponible = estaDisponible;
        }

        // Propiedades con getter y setter publicas asi lo haremos para el resto de clases 
        public string CarnetGuia
        {
            get { return _carnetGuia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el carnet del guia no puede estar vacio.");
                }
                else
                {
                    _carnetGuia = value.Trim();
                }
            }
        }

        public string NombreGuia
        {
            get { return _nombreGuia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el nombre del guia no puede estar vacio.");
                }
                else
                {
                    _nombreGuia = value.Trim();
                }
            }
        }

        public EspecialidadGuia Especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }

        public bool EstaDisponible
        {
            get { return _estaDisponible; }
            set { _estaDisponible = value; }
        }

        public Sendero SenderoAsignado
        {
            get { return _senderoAsignado; }
        }

        //Metodo para asignar un recorrido al guia turistico
        public void AsignarRecorrido(Sendero sendero)
        {
            if (!_estaDisponible)
            {
                Console.WriteLine("El guia " + _nombreGuia + " ya esta ocupado en otro recorrido.");
            }
            else if (sendero == null)
            {
                Console.WriteLine("No hay sendero para asignar.");
            }
            else
            {
                _senderoAsignado = sendero;
                sendero.SetGuia(this);
                _estaDisponible = false;
                Console.WriteLine("El guia " + _nombreGuia + " fue asignado al sendero " + sendero.Nombre + ".");
            }
        }


        //Metoddo para finalizar el recorrido y liberar al guia
        public void FinalizarRecorrido()
        {
            if (_senderoAsignado != null)
            {
                _senderoAsignado.SetGuia(null);
                _senderoAsignado = null;
            }
            _estaDisponible = true;
            Console.WriteLine("El guia " + _nombreGuia + " termino su recorrido y ya esta disponible.");
        }
    }
}
