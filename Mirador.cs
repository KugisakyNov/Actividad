using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // subclase mirador que hereda de atracciones
    public class Mirador : Atracciones
    {
        // atributos privados 
        private double _alturaMetros;
        private string _vistaPrincipal;
        private string _material;

        // constructor 
        public Mirador(string id, string nombre, int capacidad, EstadoAtraccion estadoAtraccion, double alturaMetros, string vistaPrincipal, string material)
            : base(id, nombre, capacidad, estadoAtraccion)
        {
            this.AlturaMetros = alturaMetros;
            this.VistaPrincipal = vistaPrincipal;
            this.Material = material;
        }

        // propiedad altura con validacion para que la altura sea mayor que cero
        public double AlturaMetros
        {
            get { return _alturaMetros; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("la altura del mirador debe ser mayor que cero");
                    _alturaMetros = 1.0;
                }
                else
                {
                    _alturaMetros = value;
                }
            }
        }

        // propiedad vista principal con validacion para qque no sea vacio
        public string VistaPrincipal
        {
            get { return _vistaPrincipal; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("la vista principal no puede estar vacia");
                    _vistaPrincipal = "vista general";
                }
                else
                {
                    _vistaPrincipal = value;
                }
            }
        }

        // propiedad material con validacion para que no sea vacio
        public string Material
        {
            get { return _material; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("el material no puede estar vacio");
                    _material = "madera";
                }
                else
                {
                    _material = value;
                }
            }
        }

        // metodo para mostrar informacion del mirador
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Altura en Metros: {_alturaMetros}");
            Console.WriteLine($"Vista Principal: {_vistaPrincipal}");
            Console.WriteLine($"Material del Mirador: {_material}");
        }

        // metodo para sugerir una foto panoramica en el mirador
        public override string FotoSugerida()
        {
            return "una foto panoramica con la vista de " + _vistaPrincipal;
        }

        // metodo abstracto para calcular el costo del mirador, que en este caso es gratuito
        public override double CalcularCosto(int cantidad)
        {
            return 0.00;
        }
    }
}