using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // subclase zona verde que hereda de atracciones
    public class ZonaVerde : Atracciones
    {
        // atributos privados con guion bajo
        private TipoZonaVerde _tipoZona;
        private bool _requiereTrajeBano;

        // constructor que envia datos base a la clase padre
        public ZonaVerde(string id, string nombre, int capacidad, TipoZonaVerde tipoZona)
            : base(id, nombre, capacidad, EstadoAtraccion.Disponible)
        {
            this.TipoZona = tipoZona;
            this.RequiereTrajeBano = false;
        }

        // propiedad para el tipo de zona verde
        public TipoZonaVerde TipoZona
        {
            get { return _tipoZona; }
            set { _tipoZona = value; }
        }

        // propiedad para verificar si requiere traje de bano
        public bool RequiereTrajeBano
        {
            get { return _requiereTrajeBano; }
            set { _requiereTrajeBano = value; }
        }

        // metodo para mostrar datos de la zona verde
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            string textoTraje = _requiereTrajeBano ? "si" : "no";
            Console.WriteLine($"   Zona verde: {Nombre} | Tipo: {_tipoZona} | Requiere traje de baño: {textoTraje}");
        }

        // metodo para sugerir foto familiar en el lugar
        public override string FotoSugerida()
        {
            return "una foto familiar en las areas verdes y juegos al aire libre";
        }

        // metodo abstracto para calcular el costo de la zona verde, que en este caso es gratuito
        public override double CalcularCosto(int cantidad)
        {
            return 0.00;
        }
    }
}