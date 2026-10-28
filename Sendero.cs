using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public class Sendero: Atracciones
    {
        private double DistanciaKM { get; set; }
        private DificultadSendero Dificultad;
        private bool RequiereGuia = false;
        private GuiaTuristico guiaAsignado; 

        public Sendero(string id, string nombre, int capacidadpersona, EstadoAtraccion estadoAtraccion, double distanciaKM, DificultadSendero dificultad, bool requiereGuia)
            : base(id, nombre, capacidadpersona, estadoAtraccion)
        {
            DistanciaKM = distanciaKM;
            Dificultad = dificultad;
            RequiereGuia = requiereGuia;
        }
        public double GetDistanciaKm()
        {
            return DistanciaKM;
        }

        public void SetDistanciaKm(double distanciaKM)
        {
            if (distanciaKM <= 0)
            {
                Console.WriteLine("la distancia del sendero debe ser mayor que cero.");
            }
            else
            {
                this.DistanciaKM = distanciaKM;
            }
        }

        public DificultadSendero GetDificultad()
        {
            return Dificultad;
        }

        public void SetDificultad(DificultadSendero dificultad)
        {
            this.Dificultad = dificultad;
        }

        public bool GetRequiereGuia()
        {
            return RequiereGuia;
        }

        public void SetRequiereGuia(bool requiereGuia)
        {
            this.RequiereGuia = requiereGuia;
        }

        public GuiaTuristico GetGuia()
        {
            return guiaAsignado;
        }

        public void SetGuia(GuiaTuristico guia)
        {
            this.guiaAsignado = guia;
        }
        //Metodo para mostrar la informacion del sendero
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            string textoGuia = "no";
            if (RequiereGuia == true)
            {
                textoGuia = "si";
            }
            Console.WriteLine("Sendero de " + DistanciaKM + " km | Dificultad: " + Dificultad + " | Requiere guia: " + textoGuia);
        }

        public void IniciarRecorrido()
        {
            if (RequiereGuia == true && guiaAsignado == null)
            {
                Console.WriteLine("No se puede iniciar: este sendero necesita guia y aun no tiene uno asignado.");
            }
            else if (guiaAsignado != null)
            {
                Console.WriteLine("El guia " + guiaAsignado.NombreGuia + " (" + guiaAsignado.Especialidad + ") explica el sendero " + Nombre + ": " + DistanciaKM + " km, dificultad " + Dificultad + ".");
            }
            else
            {
                Console.WriteLine("Recorres el sendero " + Nombre + " por tu cuenta (" + DistanciaKM + " km).");
            }
        }
        public override string FotoSugerida()
        {
            return "una foto del camino entre los arboles del sendero " + Nombre;
        }
        public override double CalcularCostos(int cantidad)
        {
            return 0.00;
        }

    }
}
