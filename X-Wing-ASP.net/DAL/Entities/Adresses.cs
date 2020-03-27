using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Adresses
    {
        public int Id { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int Cp { get; set; }
        public String Ville { get; set; }
        public string Pays { get; set; }
    }
}
