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

        public Mirador(string id,string nombre,int capacidad,EstadoAtraccion estadoAtraccion,double alturaMetro,string VistaPrincipal,string Material ):base(id,nombre,capacidad,estadoAtraccion)
        {
            this.alturaMetro = alturaMetro;
            this.vistaPrincipal = VistaPrincipal;
            this.material = Material;
        }

        public double AlturaMetro
        {
            get { return alturaMetro; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("la altura del mirador debe ser mayor que cero.");
                }
                else
                {
                    this.alturaMetro = value;
                }
            }
        }
        public string VistaPrincipal 
        {
            get { return vistaPrincipal; }
            set
            {
                if (vistaPrincipal == null || vistaPrincipal.Trim() == "")
                {
                    Console.WriteLine("la vista principal no puede estar vacia.");
                }
                else
                {
                    this.vistaPrincipal = value;
                }
            }
        }

        public string Material 
        {
            get { return material; }
            set
            {
                if (material == null || material.Trim() == "")
                {
                    Console.WriteLine("el material no puede estar vacio.");
                }
                else
                {
                    this.material = value;
                }
            }
        }



        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Altura en Metros: {AlturaMetro}");
            Console.WriteLine($"Vista Principal: {vistaPrincipal}");
            Console.WriteLine($"Material del Mirador: {material}");
        }
        //metodo para sugerir una foto desde el mirador
        public override string FotoSugerida()
        {
            return "una foto panoramica con la vista de " + vistaPrincipal;
        }
        
        public override double CalcularCostos(int cantidad)
        {
            return 0.00;
        }
     }
}