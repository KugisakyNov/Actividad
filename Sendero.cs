using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // subclase sendero que hereda de atracciones
    public class Sendero : Atracciones
    {
        // atributos privados con guion bajo
        private double _distanciaKm;
        private DificultadSendero _dificultad;
        private bool _requiereGuia;
        private GuiaTuristico _guiaAsignado;

        // constructor que envia datos base y asigna los atributos propios
        public Sendero(string id, string nombre, int capacidadPersona, EstadoAtraccion estadoAtraccion, double distanciaKm, DificultadSendero dificultad, bool requiereGuia)
            : base(id, nombre, capacidadPersona, estadoAtraccion)
        {
            this.DistanciaKm = distanciaKm;
            this.Dificultad = dificultad;
            this.RequiereGuia = requiereGuia;
            this._guiaAsignado = null;
        }

        // propiedad distancia en kilometros con validacion sencilla
        public double DistanciaKm
        {
            get { return _distanciaKm; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("la distancia del sendero debe ser mayor que cero");
                    _distanciaKm = 1.0;
                }
                else
                {
                    _distanciaKm = value;
                }
            }
        }

        // propiedad para la dificultad del sendero
        public DificultadSendero Dificultad
        {
            get { return _dificultad; }
            set { _dificultad = value; }
        }

        // propiedad para saber si requiere guia
        public bool RequiereGuia
        {
            get { return _requiereGuia; }
            set { _requiereGuia = value; }
        }

        // propiedad para el guia turistico asignado
        public GuiaTuristico GuiaAsignado
        {
            get { return _guiaAsignado; }
            set { _guiaAsignado = value; }
        }

        // metodo sobrescrito para mostrar datos del sendero
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            string textoGuia = _requiereGuia ? "si" : "no";
            Console.WriteLine("Sendero de " + _distanciaKm + " km | Dificultad: " + _dificultad + " | Requiere guia: " + textoGuia);
        }

        // metodo para iniciar el recorrido guiado o individual
        public void IniciarRecorrido()
        {
            if (_requiereGuia && _guiaAsignado == null)
            {
                Console.WriteLine("No se puede iniciar: este sendero necesita guia y aun no tiene uno asignado.");
            }
            else if (_guiaAsignado != null)
            {
                Console.WriteLine("El guia " + _guiaAsignado.Nombre + " explica el sendero " + Nombre + ": " + _distanciaKm + " km, dificultad " + _dificultad + ".");
            }
            else
            {
                Console.WriteLine("Recorres el sendero " + Nombre + " por tu cuenta (" + _distanciaKm + " km).");
            }
        }

        // metodo para sugerir fotografia en el sendero
        public override string FotoSugerida()
        {
            return "una foto del camino entre los arboles del sendero " + Nombre;
        }

        // metodo abstracto para calcular costo, en este caso es gratuito
        public override double CalcularCosto(int cantidad)
        {
            return 0.00;
        }
    }
}
