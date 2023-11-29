using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Disco
    {
        public int IdDisco { get; set; }
        public string Nombre { get; set; }
        public string Artista { get; set; }
        public DateTime FechaEstreno { get; set; }
        public decimal Costo { get; set; }
        public List<object> Discos { get; set; }
    }
}
