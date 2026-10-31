using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    // enums del programa
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
        AreaColumpios,
        AreaDescanso
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
        // variables estaticas para guardar parques y visitantes
        static Parque parqueCerroVerde;
        static Parque parqueSihuatehuacan;
        static Visitantes visitanteActual = null;
        static Parque parqueSeleccionado = null;

        static void Main(string[] args)
        {
            // creacion del parque cerro verde
            Console.WriteLine(@"        P A R Q U E   N A T U R A L    ");
            parqueCerroVerde = new Parque("--> Parque Natural Cerro Verde", TipoParque.Narural, "Santa Ana", "8:00 AM - 5:00 PM", 1.50);
            parqueCerroVerde.AbrirParque();

            // creacion de atracciones para cerro verde
            Mirador miradorVolcanes = new Mirador("M-01", "Mirador Los Volcanes", 40, EstadoAtraccion.Disponible, 20.0, "Volcan Izalco", "Madera y estructura de hierro");
            Sendero senderoFlores = new Sendero("S-01", "Sendero Las Flores", 25, EstadoAtraccion.Disponible, 2.5, DificultadSendero.Media, true);
            Cabañas cabanaCipres = new Cabañas("C-01", "Cabaña El Ciprés", 6, EstadoAtraccion.Disponible, 1, 2, 45.00, EstadoCabaña.Disponible);

            // agregar atracciones al cerro verde
            parqueCerroVerde.AgregarAtraccion(miradorVolcanes);
            parqueCerroVerde.AgregarAtraccion(senderoFlores);
            parqueCerroVerde.AgregarAtraccion(cabanaCipres);
            Console.WriteLine("***************************************************************");

            // creacion y asignacion del guia
            Console.WriteLine("\n**** Datos del Guia *****");
            GuiaTuristico guiaCerro = new GuiaTuristico("G-101", "Marlon Osorio", EspecialidadGuia.senderismo, true);
            guiaCerro.AsignarRecorrido(senderoFlores);


            // creacion del parque sihuatehuacan
            Console.WriteLine("************************************************************************");
            Console.WriteLine(@"        P A R Q U E   A G U A T I C O ");
            parqueSihuatehuacan = new Parque("--> Parque Recreativo Sihuatehuacan", TipoParque.Acuatico, "Santa Ana", "7:00 AM - 4:00 PM", 1.50);

            parqueSihuatehuacan.AbrirParque();

            // creacion de atracciones para sihuatehuacan

            Piscinas piscinaFamiliar = new Piscinas("P-01", "Piscina Grande Familiar", 50, EstadoAtraccion.Disponible, 1.6, true);
            ZonaVerde juegosNinos = new ZonaVerde("M-02", "zona recreativa de juegos en el area verde", 30, TipoZonaVerde.AreaColumpios);

            // agregar atracciones a sihuatehuacan
            parqueSihuatehuacan.AgregarAtraccion(piscinaFamiliar);
            parqueSihuatehuacan.AgregarAtraccion(juegosNinos);
            guiaCerro.MostrarTotalRecorridos();
            Console.WriteLine("\nPresiona cualquier tecla para ir al Menu...");
            Console.ReadKey();

            // ciclo para mostrar el menu hasta salir
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
                        Console.WriteLine("Terminando el programa... " +
                            "Gracias por visitar los parques!");
                        break;
                    default:
                        Console.WriteLine("Opción no valida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        // metodo para imprimir el menu
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------- PARQUES CERRO VERDE Y SIHUATEHUACÁN -------------------");
            Console.WriteLine("1. Registrar la llegada de un visitante");
            Console.WriteLine("2. Entrar a un parque");
            Console.WriteLine("3. Ver las atracciones del parque");
            Console.WriteLine("4. Visitar una atraccion");
            Console.WriteLine("5. Tomar una foto");
            Console.WriteLine("6. Pagar");
            Console.WriteLine("7. Salir del parque");
            Console.WriteLine("8. Ver una simulacion automatica completa");
            Console.WriteLine("0. Terminar el programa");
        }

        //metodo para validar el nombre que no lleve numeros 
        static bool EsNombreValido(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        // metodo para pedir datos y registrar visitante
        static void RegistrarVisitante()
        {
            Console.WriteLine("--- Registrar Nuevo Visitante ---");

            string nombre;

            do
            {
                Console.Write("Nombre completo: ");
                nombre = Console.ReadLine();

                if (!EsNombreValido(nombre))
                {
                    Console.WriteLine("El nombre solo debe contener letras.");
                    nombre = "";
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            Console.Write("DUI o Pasaporte: ");
            string dui = Console.ReadLine();

            int edad;
            Console.Write("Edad: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad < 0 || edad > 100)
            {
                Console.Write("Ingrese una edad entre 0 y 100: ");
            }

            int grupo;
            Console.Write("Cantidad de personas en el grupo: ");
            while (!int.TryParse(Console.ReadLine(), out grupo) || grupo <= 0)
            {
                Console.Write("Debe ingresar un número mayor que 0: ");
            }

           

            int cantidadExtranjeros = 0;

            if (grupo == 1)
            {
                int opcion;
                Console.Write("¿Es extranjero? 1 = Si, 2 = No: ");
                while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2))
                {
                    Console.Write("Seleccione 1 o 2: ");
                }

                if (opcion == 1)
                {
                    cantidadExtranjeros = 1;
                }
            }
            else
            {
                Console.Write("¿Cuantas personas del grupo de " + grupo + " son extranjeros? (0 a " + grupo + "): ");
                while (!int.TryParse(Console.ReadLine(), out cantidadExtranjeros) || cantidadExtranjeros < 0 || cantidadExtranjeros > grupo)
                {
                    Console.Write("Ingrese un numero valido entre 0 y " + grupo + ": ");
                }
            }

            visitanteActual = new Visitantes(
                dui,
                nombre,
                edad,
                grupo,
                cantidadExtranjeros
            );

            visitanteActual.RegistrarLlegada();
        }

        // metodo para elegir parque y comprar boleto
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
            Console.WriteLine("************************************");
            Console.WriteLine("Total de Boletos vendidos: "
                + Parque.ContadorDeBoletos);
           

        }

        // metodo para listar atracciones
        static void VerAtracciones()
        {
            if (parqueSeleccionado == null)
            {
                Console.WriteLine("Debes ingresar a un parque primero en la Opción 2.");
                return;
            }

            parqueSeleccionado.ListarAtracciones();
        }

        // metodo para visitar una atraccion
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

        // metodo para tomar foto a una atraccion
        static void TomarFoto()
        {
            if (visitanteActual == null || parqueSeleccionado == null)
            {
                Console.WriteLine("Debes registrar al visitante y entrar a un parque.");
                return;
            }

            Console.WriteLine("Seleccione la atraccion para la foto:");
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

        // metodo para procesar el pago del visitante
        static void Pagar()
        {
            if (visitanteActual == null || parqueSeleccionado == null)
            {
                Console.WriteLine("No hay visitas activas para pagar.");
                return;
            }

            parqueSeleccionado.ProcesarPago(visitanteActual);
        }

        // metodo para salir del parque
        static void SalirDelParque()
        {
            if (visitanteActual == null || parqueSeleccionado == null)
            {
                Console.WriteLine("No hay visitante dentro de ningun parque.");
                return;
            }
            visitanteActual.MostrarResumen();


            // solo si pudo salir limpiamos el parque seleccionado
            bool pudoSalir = visitanteActual.SalirDelParque();
            if (pudoSalir)
            {
                parqueSeleccionado = null;
            }
        }

        // simulacion automatica de recorridos
        static void SimulacionAutomatica()
        {
            Console.WriteLine("----------------- INICIANDO SIMULACIÓN AUTOMÁTICA -----------------\n");

            // recorrido uno vanessa lara en cerro verde
            Console.WriteLine("--- RECORRIDO 1 CERRO VERDE ---");
            Visitantes vanessa = new Visitantes("05123456-7", "Vanessa Lara", 24, 2, 0);
            vanessa.RegistrarLlegada();
            vanessa.EntrarAlParque(parqueCerroVerde);
            Console.WriteLine("Boletos vendidos: " + Parque.ContadorDeBoletos);

            // obtener atracciones de cerro verde

            Atracciones mirador = parqueCerroVerde.GetAtraccion(0);
            Atracciones sendero = parqueCerroVerde.GetAtraccion(1);
            Atracciones cabana = parqueCerroVerde.GetAtraccion(2);

            // vanessa visita el mirador
            vanessa.VisitarAtraccion(mirador);
            Console.WriteLine("Disfruta de la vista hacia el volcan desde " + mirador.Nombre);

            // vanessa visita el sendero
            vanessa.VisitarAtraccion(sendero);
            Console.WriteLine("Camina por el " + sendero.Nombre);


            // vanessa visita y reserva cabana
            vanessa.VisitarAtraccion(cabana);
            Console.WriteLine("Se hospeda en la " + cabana.Nombre);

            // vanessa toma foto 
            vanessa.TomarFoto(mirador);
            vanessa.TomarFoto(sendero);
            vanessa.TomarFoto(cabana);

            // pago y salida de vanessa
            Console.WriteLine();
            parqueCerroVerde.ProcesarPago(vanessa);
            vanessa.SalirDelParque();
            vanessa.MostrarTotalFotosTomadas();
            Console.WriteLine("\n-------------------------------------------------------------------\n");

            // recorrido dos samuel de luque en el parque sihuatehuacan
            Console.WriteLine("--- RECORRIDO 2 SIHUATEHUACAN ---");
            Visitantes samuel = new Visitantes("P98765432", "Samuel de Luque", 35, 1, 1);
            samuel.RegistrarLlegada();
            samuel.EntrarAlParque(parqueSihuatehuacan);
            Console.WriteLine("Boletos vendidos: " + Parque.ContadorDeBoletos);

            // obtener atracciones de sihuatehuacan

            Atracciones piscina = parqueSihuatehuacan.GetAtraccion(0);
            Atracciones juegos = parqueSihuatehuacan.GetAtraccion(1);

            // samuel visita la piscina
            samuel.VisitarAtraccion(piscina);
            if (piscina is Piscinas p)
            {
                Console.WriteLine("se metes a la " + piscina.Nombre + " que tiene " + p.ProfundidadMetros + " m de profundidad");
            }

            // samuel visita area de juegos
            samuel.VisitarAtraccion(juegos);
            Console.WriteLine("Disfruta de " + juegos.Nombre);

            // samuel toma foto de la piscina
            samuel.TomarFoto(piscina);

            // pago y salida de samuel
            Console.WriteLine();
            parqueSihuatehuacan.ProcesarPago(samuel);
            samuel.SalirDelParque();
            samuel.MostrarTotalFotosTomadas();
            Console.WriteLine("\n----------------- FIN DE LA SIMULACIÓN -----------------");
        }
    }
}