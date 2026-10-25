using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    class ZonaVerde: Atracciones
    {
        private TipoZonaVerde tipoZona;
        private bool requiereTrajeBano;

        public ZonaVerde(
           string id, string nombre, int capacidad,TipoZonaVerde tipoZona): base(id, nombre, capacidad,EstadoActraccion.Disponible)
        {
            this.tipoZona = tipoZona;
            this.requiereTrajeBano = false;
        }

        public TipoZonaVerde TipoZona
        {
            get { return tipoZona; }
            set { tipoZona = value; }
        }

        public bool RequiereTrajeBano
        {
            get { return requiereTrajeBano; }
            set { requiereTrajeBano = value; }
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine(
                $"Zona verde: {Nombre} | Tipo: {TipoZona} | " +
                $"Requiere traje de baño: {RequiereTrajeBano}");
        }

        public override double CalcularCostos(int cantidad)
        {
            if (cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");

            return 0;
        }
    }


}

