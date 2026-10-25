using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
     class Mirador:Atracciones
    {
        private double alturaMetro;
        private string vistaPrincipal;
        private string material;

        public Mirador(string id,string nombre,int capacidad,EstadoActraccion estadoActraccion,double alturaMetro,string VistaPrincipal,string Material ):base(id,nombre,capacidad,estadoActraccion)
        {
            this.alturaMetro = alturaMetro;
            this.vistaPrincipal = VistaPrincipal;
            this.material = Material;
        }

        public double AlturaMetro
        {
            get { return alturaMetro; }
            set { alturaMetro =value < 0 ? throw new ArgumentException("Altura Inavalida. "): value; }
        }
        public string VistaPrincipal 
        {
            get { return vistaPrincipal; }
            set { vistaPrincipal = value; }
        }

        public string Material 
        {
            get { return material; }
            set { material = value; }

        }



        public override void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Ubicación: {Id}");
            Console.WriteLine($"Altura en Metros: {AlturaMetro}");
            Console.WriteLine($"Vista Principal: {vistaPrincipal}");
            Console.WriteLine($"Material del Mirador: {material}");
            Console.WriteLine($"Estado de la Atracción: {EstadoAtraccion}");
            Console.WriteLine($"Capacidad de Personas: {CapacidadPersona}");
        }

        public double CalcularCosto(int cantidad)
        {
           
            double costoBase = 0;
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad de personas debe ser mayor a cero.");
            }
            if (cantidad == 1)
            {
              
                
                costoBase = 1.50;
            }
            else
            {
              
                costoBase = 3.00;


            }
            return costoBase * cantidad;
        }


    }
}