using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Escadron
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public bool Visible { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Vaisseaux> Vaisseau { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
    }
}
