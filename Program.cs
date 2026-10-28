using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    public enum TipoParque
    {
        Narural,
        Acuatico
    }
    public enum EstadoCabaña
    {
        Disponible,
        Ocupado,
        Mantenimiento
    }
    public enum TipoZonaVerde
    {
        Mirador,
        kiosko,
        AreaColumpios
    }
    public enum EstadoAtraccion
    {
        Disponible,
        Cerrado,
        Mantenimiento
    }

    public enum DificultadSendero
    {
        Facil,
        Media,
        Alta
    }
    public enum EspecialidadGuia
    {
        FlorayFauna,
        HistoriayGeografia,
        senderismo
    }

    internal class Program
    {
        // Variables que se necesitan para que el programa funcione correctamente
        static Parque parqueCerroVerde;
        static Parque parqueSihuatehuacan;
        static Visitantes visitanteActual = null;
        static Parque parqueSeleccionado = null;

        static void Main(string[] args)
        {
            // 1. Parque Natural Cerro Verde
            parqueCerroVerde = new Parque("Parque Natural Cerro Verde", TipoParque.Narural, "Santa Ana", "8:00 AM - 5:00 PM", 1.50);
            parqueCerroVerde.AbrirParque();

            Mirador miradorVolcanes = new Mirador("M-01", "Mirador Los Volcanes", 40, EstadoAtraccion.Disponible, 2030.0, "Volcan Izalco", "Madera y estructura de hierro");
            Sendero senderoFlores = new Sendero("S-01", "Sendero Las Flores", 25, EstadoAtraccion.Disponible, 2.5, DificultadSendero.Media, true);
            Cabañas cabanaCipres = new Cabañas("C-01", "Cabaña El Ciprés", 6, EstadoAtraccion.Disponible, 1, 2, 45.00, EstadoCabaña.Disponible);

            parqueCerroVerde.AgregarAtraccion(miradorVolcanes);
            parqueCerroVerde.AgregarAtraccion(senderoFlores);
            parqueCerroVerde.AgregarAtraccion(cabanaCipres);

            GuiaTuristico guiaCerro = new GuiaTuristico("G-101", "Marlon Osorio", EspecialidadGuia.senderismo, true);
            guiaCerro.AsignarRecorrido(senderoFlores);

            // 2. Parque Recreativo Sihuatehuacan
            parqueSihuatehuacan = new Parque( "Parque Recreativo Sihuatehuacan", TipoParque.Acuatico,"Santa Ana", "7:00 AM - 4:00 PM",1.50 );
            parqueSihuatehuacan.AbrirParque();

            Piscinas piscinaFamiliar = new Piscinas("P-01", "Piscina Grande Familiar", 50, EstadoAtraccion.Disponible, 1.6, true);
            Mirador juegosNinos = new Mirador("M-02", "zona recreativa de juegos en el area verde", 30, EstadoAtraccion.Disponible, 0.0, "Cancha y parque", "Hierro y plastico");

            parqueSihuatehuacan.AgregarAtraccion(piscinaFamiliar);
            parqueSihuatehuacan.AgregarAtraccion(juegosNinos);

            Console.WriteLine("\nPresiona cualquier tecla para ir al Menu...");
            Console.ReadKey();

            
            int opcion;
            do
            {
                MostrarMenu();
                Console.Write("seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        RegistrarVisitante();
                        break;
                    case 2:
                        EntrarAlParque();
                        break;
                    case 3:
                        VerAtracciones();
                        break;
                    case 4:
                        VisitarAtraccion();
                        break;
                    case 5:
                        TomarFoto();
                        break;
                    case 6:
                        Pagar();
                        break;
                    case 7:
                        SalirDelParque();
                        break;
                    case 8:
                        SimulacionAutomatica();
                        break;
                    case 0:
                        Console.WriteLine("Terminando el programa. ¡Gracias por visitar los parques!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------- PARQUES CERRO VERDE Y SIHUATEHUACÁN -------------------");
            Console.WriteLine("1. Registrar la llegada de un visitante");
            Console.WriteLine("2. Entrar a un parque (comprar boleto)");
            Console.WriteLine("3. Ver las atracciones del parque");
            Console.WriteLine("4. Visitar una atracción");
            Console.WriteLine("5. Tomar una foto (reto extra)");
            Console.WriteLine("6. Pagar");
            Console.WriteLine("7. Salir del parque");
            Console.WriteLine("8. Ver una simulación automática completa");
            Console.WriteLine("0. Terminar el programa");
        }

        static void RegistrarVisitante()
        {
            Console.WriteLine("--- Registrar Nuevo Visitante ---");

            string nombre;

            do
            {
                Console.Write("Nombre completo: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre) ||
                    !nombre.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Error: El nombre solo debe contener letras.");
                    nombre = "";
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            Console.Write("DUI o Pasaporte: ");
            string dui = Console.ReadLine();

            // Validar edad
            int edad;

            Console.Write("Edad: ");

            while (!int.TryParse(Console.ReadLine(), out edad) || edad < 0 || edad > 120)
            {
                Console.Write("Edad inválida. Ingrese una edad entre 0 y 120: ");
            }

            int grupo;
            Console.Write("Cantidad de personas en el grupo: ");
            while (!int.TryParse(Console.ReadLine(), out grupo) || grupo <= 0)
            {
                Console.Write("Debe ingresar un número mayor que 0: ");
            }

            int opcion;
            Console.Write("¿Es extranjero? 1 = Sí, 2 = No: ");

            while (!int.TryParse(Console.ReadLine(), out opcion) ||
                   (opcion != 1 && opcion != 2))
            {
                Console.Write("Opción inválida. Digite 1 o 2: ");
            }

            bool esExtranjero = opcion == 1;

            visitanteActual = new Visitantes(
                dui,
                nombre,
                edad,
                grupo,
                esExtranjero
            );

            visitanteActual.RegistrarLlegada();
        }

        static void EntrarAlParque()
        {
            if (visitanteActual == null)
            {
                Console.WriteLine("Primero debes registrar un visitante en la Opción 1.");
                return;
            }

            Console.WriteLine("Selecciona el parque:");
            Console.WriteLine("1. " + parqueCerroVerde.NombreParque);
            Console.WriteLine("2. " + parqueSihuatehuacan.NombreParque);
            Console.Write("Opción: ");
            int opc = int.Parse(Console.ReadLine());

            parqueSeleccionado = (opc == 1) ? parqueCerroVerde : parqueSihuatehuacan;
            visitanteActual.EntrarAlParque(parqueSeleccionado);
        }

        static void VerAtracciones()
        {
            if (parqueSeleccionado == null)
            {
                Console.WriteLine("Debes ingresar a un parque primero en la Opción 2.");
                return;
            }

            parqueSeleccionado.ListarAtracciones();
        }

        static void VisitarAtraccion()
        {
            if (visitanteActual == null || parqueSeleccionado == null)
            {
                Console.WriteLine("Debes registrar al visitante y entrar al parque primero.");
                return;
            }

            Console.WriteLine("Selecciona la atraccion que va a visitar:");
            List<Atracciones> lista = parqueSeleccionado.ListaAtracciones;
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + lista[i].Nombre);
            }

            Console.Write("Selecciona numero: ");
            int seleccion = int.Parse(Console.ReadLine()) - 1;

            if (seleccion >= 0 && seleccion < lista.Count)
            {
                visitanteActual.VisitarAtraccion(lista[seleccion]);
            }
            else
            {
                Console.WriteLine("numero incorrecto.");
            }
        }

        static void TomarFoto()
        {
            if (visitanteActual == null || parqueSeleccionado == null)
            {
                Console.WriteLine("Debes registrar al visitante y entrar a un parque.");
                return;
            }

            Console.WriteLine("Selecciona la atracción para la foto:");
            List<Atracciones> lista = parqueSeleccionado.ListaAtracciones;
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + lista[i].Nombre);
            }

            Console.Write("Selecciona numero: ");
            int seleccion = int.Parse(Console.ReadLine()) - 1;

            if (seleccion >= 0 && seleccion < lista.Count)
            {
                visitanteActual.TomarFoto(lista[seleccion]);
            }
            else
            {
                Console.WriteLine("numero incorrecto.");
            }
        }

        static void Pagar()
        {
            if (visitanteActual == null || parqueSeleccionado == null)
            {
                Console.WriteLine("No hay visitas activas para pagar.");
                return;
            }

            parqueSeleccionado.ProcesarPago(visitanteActual);
        }

        static void SalirDelParque()
        {
            if (visitanteActual == null)
            {
                Console.WriteLine("No hay visitante registrado.");
                return;
            }

            visitanteActual.SalirDelParque();
            parqueSeleccionado = null;
        }

        static void SimulacionAutomatica()
        {
            Console.WriteLine("----------------- INICIANDO SIMULACIÓN AUTOMÁTICA -----------------\n");

            // Recorrido 1: Samuel de Luque en Sihuatehuacán
            Visitantes samuel = new Visitantes("05891234-8", "Samuel de Luque", 26, 1, false);
            samuel.EntrarAlParque(parqueSihuatehuacan);

            Atracciones piscina = parqueSihuatehuacan.GetAtraccion(0);
            Atracciones juegos = parqueSihuatehuacan.GetAtraccion(1);

            samuel.VisitarAtraccion(piscina);
            if (piscina is Piscinas p)
            {
                Console.WriteLine("Te metes a la " + piscina.Nombre + ". ¡Esta en la piscina que tiene " + p.ProfundidadMetros + " m de profundidad!");
            }

            samuel.VisitarAtraccion(juegos);
            Console.WriteLine("Disfrutas de " + juegos.Nombre + ".");

            samuel.TomarFoto(piscina);

            Console.WriteLine();
            parqueSihuatehuacan.ProcesarPago(samuel);
            samuel.SalirDelParque();

            // Recorrido 2: Grupo escolar donde se supera el aforo
            Console.WriteLine("\n--- Recorrido 2: un grupo escolar (se supera el aforo) ---");
            Visitantes grupoEscolar = new Visitantes("01234567-9", "Maria Rosa", 35, 45, false);
            grupoEscolar.RegistrarLlegada();
            grupoEscolar.EntrarAlParque(parqueSihuatehuacan);

            grupoEscolar.VisitarAtraccion(piscina);

            grupoEscolar.VisitarAtraccion(juegos);
            Console.WriteLine("Disfrutas de " + juegos.Nombre + ".");

            Console.WriteLine();
            parqueSihuatehuacan.ProcesarPago(grupoEscolar);
            grupoEscolar.SalirDelParque();

            Console.WriteLine("\n----------------- FIN DE LA SIMULACIÓN -----------------");
        }
    }
}
