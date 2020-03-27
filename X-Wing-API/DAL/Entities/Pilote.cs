using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Pilote
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public bool Unique { get; set; }
        public int Cout { get; set; }
        public int ValeurPilotage { get; set; }
        public string Commentaires { get; set; }
        public IEnumerable<Vaisseaux> Vaisseaux { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<TypeAmelioration> Type { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
    }
}
