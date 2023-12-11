using System;
namespace Reparar
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*     Sistema de Gestión de Constructora      *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[Q] Establecer monto del Sindicato.");
            Console.WriteLine("\n[J] Establecer canon matrícula Profesional.");
            Console.WriteLine("\n[P] Informar sueldos");
            Console.WriteLine("\n[W] Registrar obrero o profesional.");
            Console.WriteLine("\n[E] Listar datos empleados.");
            Console.WriteLine("\n[R] Registrar una obra.");
            Console.WriteLine("\n[T] Modificar profesional.");
            Console.WriteLine("\n[Y] Asignar obrero en obra.");
            Console.WriteLine("\n[U] Listar empleados en obra.");
            Console.WriteLine("\n[I] Remover un profesional de empresa.");
            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
       
    }
}