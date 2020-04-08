using DAL.ViewModels;
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
        public IEnumerable<ViewVaisseau> Vaisseaux { get; set; }
        public IEnumerable<ViewCamp> Camp { get; set; }
        public IEnumerable<ViewType> Type { get; set; }
        public int XIDCamp { get; set; }
        public int XIDVaisseau { get; set; }
        public int XIDType { get; set; }
    }
}
