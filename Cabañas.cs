using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class Cabañas : Atracciones
    {
        private int numeroCabañas;
        private int numeroHabitacion;
        private double precioNoche;
        private EstadoCabaña EstadoHospedaje;


        public Cabañas(string id, string Nombre, int capacidadpersona, EstadoActraccion estadoAtraccion, int NumeroCabañas, int NumeroHabitacion, double PrecioNoche, EstadoCabaña EstadoHospedaje) : base(id, Nombre, capacidadpersona, estadoAtraccion)
        {
            this.numeroCabañas = NumeroCabañas;
            this.numeroHabitacion = NumeroHabitacion;
            this.precioNoche = PrecioNoche;
            this.EstadoHospedaje = EstadoHospedaje;

        
        }
        public int Numerocabaña 
        {
            get {return numeroCabañas;}
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Se debe asignar Numero de Cabaña");
                numeroCabañas=value;
            }
        }

        public int NumeroHabitacion 
        {
            get {return numeroHabitacion;}
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Se debe tener una habiatacion libre");
                numeroHabitacion=value;

            }
        
        }

        public double PrecioNoche 
        {
            get {return precioNoche;}
            set 
            {
                if (value < 0)
                    throw new ArgumentException("El precio no puede ser negativo o invalido");
                precioNoche=value;
            }
        
        }

        public EstadoCabaña estadoHospedaje 
        {
            get { return EstadoHospedaje; }
            set { estadoHospedaje = value; }
        
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine();
        }






    }
}
