using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        //Propiedades
        public string Nombre { get; } = "Leonardo";
        public int Edad { get; set; }
        public double Altura { get; set; }
        protected string[] Pasatiempos { get; set; }
        //Constructores
        public Usuario(int edad)
        {
            Edad = edad;
        }
        public Usuario(int edad, double altura)
        {
            Edad = edad;
            Altura = altura;
        }
        public Usuario(int edad, double altura, string[] pasatiempos)
        {
            Edad = edad;
            Altura = altura;
            Pasatiempos = pasatiempos;
        }
        //Métodos
        protected static void Hola()
        {
            Console.WriteLine($"Hola. Hoy es {DateTime.Now}.");
        }
        protected static void Hola(Usuario usuario)
        {
            Console.WriteLine($"Hola, {usuario.Nombre}. \nHoy es {DateTime.Now}. \nTienes {usuario.Edad} años. \nMides {usuario.Altura} metros.");
            Console.WriteLine("Tus pasatiempos son:");
            if(usuario.Pasatiempos.Length > 0)
            {
                for (int i = 0; i < usuario.Pasatiempos.Length; i++)
                {
                    Console.WriteLine($"* {usuario.Pasatiempos[i]}");
                }
            }
            else
            {
                Console.WriteLine("No tienes pasatiempos.");
            }
        }
        public void Adios()
        {
            Console.WriteLine("Hasta la próxima.\n:)");
        }
        public void Adios(string nombre)
        {
            Console.WriteLine($"Hasta la próxima, {nombre}.\n:)");
        }
        public void Acceder()
        {
            Hola();
        }
        public void Acceder(Usuario usuario)
        {
            Hola(usuario);
        }
    }
}
