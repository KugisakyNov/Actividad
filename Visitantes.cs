using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    class Visitantes
    {
        private string duiOPasaporte;
        private string nombre;
        private int edad;
        private bool esExtrajero;



        public Visitantes(string duiOPasaporte, string nombre, int edad, bool esExtrajero)
        {
            this.duiOPasaporte=duiOPasaporte;
            this.nombre=nombre;
            this.Edad = edad;
            this.esExtrajero=esExtrajero;
        }

        public string DuiOPasaporte 
        {
            get { return duiOPasaporte; }
            set { duiOPasaporte = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Debe Ingresar Dui ó Pasaporte") : value;}
        
        }

        public string Nombre 
        {
            get { return nombre; }
            set { nombre = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Debe Completar el Nombre") : value; }
        }

        public int Edad 
        {
            get { return Edad; }
            set { Edad = value < 0 ? throw new ArgumentException("Edad Invalida") : value; }

        }

        public bool EsExtrajero 
        {
            get { return esExtrajero; }
            set { esExtrajero = value; }
        
        }

        public void VisitarAtraccion(Atracciones atracciones) 
        {
            if (atracciones == null)
                throw new ArgumentNullException("Seleccione una atraccion");

            if (atracciones.EstadoAtraccion != EstadoActraccion.Disponible) 
            {
                Console.WriteLine($"{atracciones.Nombre} No esta dibponible en estos momentos. ");
                return;
            
            }
            Console.WriteLine($"Estas en: {atracciones.Nombre}");
               
        }

        
    }
}
