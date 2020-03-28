using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace Pulsaciones
{
    public class Program
    {
       
        static PersonaService personaService = new PersonaService();
        static Persona persona;
        static Persona personaModificada;  
        static void Main(string[] args)
        {
            MenuPrincipal();  
        }

        public static void MenuPrincipal() {
            int opcion;
            char seguir = 'S';
            while (seguir == 'S')
            {
                Console.Clear();
                Console.WriteLine("-----Programa Pulsaciones-----");
                Console.WriteLine("1.Calcular pulsaciones");
                Console.WriteLine("2.Modificar");
                Console.WriteLine("3.Eliminar");
                Console.WriteLine("4.Consultar");
                Console.WriteLine("5.Salir");
                Console.Write("Digite una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        CalcularPulsaciones();
                        break;
                    case 2:
                        Modificar();
                        break;
                    case 3:
                        Eliminar();
                        break;
                    case 4:
                        Consultar();
                        break;
                    default:
                        seguir = 'N';
                        break;
                }
            }
        }
        

        public static void CalcularPulsaciones() {
            Console.Clear();
            Persona persona = new Persona();
            Console.WriteLine("Ingrese su identificación");
            persona.Identificacion = Console.ReadLine();
            Console.WriteLine("Ingrese su Nombre");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su Edad");
            persona.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese su Sexo");
            persona.Sexo = Console.ReadLine();
            personaService.CalcularPulsacion(persona);
            personaService.Guardar(persona);
            Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{persona.Nombre} Su pulsación es de: {persona.Pulsacion}");
            Console.WriteLine("---------------------------------------------------");
            Console.ReadKey();
        }

        public static void Modificar() {
            Console.Clear();
            persona = new Persona();
            string identificacion;
            Console.WriteLine("Digite numero de identificación");
            identificacion = Console.ReadLine();
            persona = personaService.BuscarPersona(identificacion);
            if (persona != null)
            {
                personaModificada = new Persona();
                personaModificada = persona;
                SegundaParteModificar();
                personaService.Modificar(persona, personaModificada);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No se encontró la identificación");
                Console.ReadKey();
            }
        }

        public static void SegundaParteModificar() {
            char seguir = 'S';
            int opcion;
            while (seguir == 'S')
            {
                opcion = MenuModificar();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nuevo nombre: ");
                        personaModificada.Nombre = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese nuevo sexo: ");
                        personaModificada.Sexo = Console.ReadLine();
                        personaService.CalcularPulsacion(personaModificada);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese la edad: ");
                        personaModificada.Edad = Convert.ToInt32(Console.ReadLine());
                        personaService.CalcularPulsacion(personaModificada);
                        break;
                    default:
                        seguir = 'N';
                        break;
                }
                personaService.Modificar(persona, personaModificada);
            }
        }

        public static int MenuModificar() {
            int opcion;
            Console.WriteLine("¿Que desea modificar?");
            Console.WriteLine("1.Nombre");
            Console.WriteLine("2.Sexo");
            Console.WriteLine("3.Edad");
            Console.WriteLine("4.Salir");
            Console.Write("Digite una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;

        }

        public static void Eliminar() {

            Console.Clear();
            persona = new Persona();
            string identificacion;
            Console.WriteLine("Ingrese el numero de identificacion para eliminar:");
            identificacion = Console.ReadLine();
            persona = personaService.BuscarPersona(identificacion);
            if (persona != null)
            {
                Console.Clear();
                personaService.Eliminar(persona);
                Console.WriteLine($"{persona.Nombre} Fué eliminado de la lista");
                Console.ReadKey();
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("No se encontró la persona que desea eliminar de la lista");
                Console.ReadKey();
            }

        }

        public static void Consultar() {
            Console.Clear();
            List<Persona> personas = personaService.personas;
            foreach (var persona in personas)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Nombre: {persona.Nombre}");
                Console.WriteLine($"Edad: {persona.Edad}");
                Console.WriteLine($"Identificación: {persona.Identificacion}");
                Console.WriteLine($"Sexo: {persona.Sexo}");
                Console.WriteLine($"Pulsación: {persona.Pulsacion}");
                Console.WriteLine("---------------------------------------------------");
            }
            Console.ReadKey();
        }

    }
}
