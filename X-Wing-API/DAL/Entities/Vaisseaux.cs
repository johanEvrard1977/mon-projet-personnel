using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Vaisseaux
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int ValeurAgilite { get; set; }
        public int ValeurArmePrincipale { get; set; }
        public int Bouclier { get; set; }
        public int Structure { get; set; }
        public int Energie { get; set; }
        public string Taille { get; set; }
        public string Capacite { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Actions> Action { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
    }
}
