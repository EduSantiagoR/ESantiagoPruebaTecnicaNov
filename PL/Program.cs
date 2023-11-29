using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pastiempos = { "Jugar videojuegos", "Estudiar", "" };

            ML.Usuario usuario = new ML.Usuario(25, 1.70,pastiempos);
            usuario.Acceder(usuario);
            Console.ReadKey();

            usuario.Adios(usuario.Nombre);
            Console.ReadKey();
        }
    }
}
