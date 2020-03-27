using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Amelioration
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Cout { get; set; }
        public bool Unique { get; set; }
        public int TailleMin { get; set; }
        public int TailleMax { get; set; }
        public string Description { get; set; }
        public bool UnParVaisseau { get; set; }
        public IEnumerable<TypeAmelioration> Type { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
    }
}
