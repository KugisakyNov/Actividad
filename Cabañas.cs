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
            Console.WriteLine("Numero de cabañas: "+ numeroCabañas);
            Console.WriteLine("Numero de habitacion: "+numeroHabitacion);
            Console.WriteLine("Estado de Hospedaje: "+estadoHospedaje);
        }

        public override double CalcularCostos(int cantidad) 
        {
            if (cantidad <0)
                throw new ArgumentException("La Cantidad ingresada es Invalida");
            return precioNoche;
        
        }

        public void Reservar() 
        {
            if (EstadoHospedaje != EstadoCabaña.Disponible) throw new InvalidOperationException("La cabaña esta fiera de servicio");

            estadoHospedaje = EstadoCabaña.Ocupado;
            Console.WriteLine("La Cabaña a sido reservada");
        
        }

        public void CarcelarReservacion() 
        {
            if (EstadoHospedaje != EstadoCabaña.Ocupado)
                throw new InvalidOperationException("La cabaña no está ocupada.");

            EstadoHospedaje = EstadoCabaña.Disponible;
            Console.WriteLine("Reservación cancelada.");

        }






    }
}
