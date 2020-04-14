using DAL.Entities;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<ViewPilote> Pilote { get; set; }
        public IEnumerable<ViewVaisseau> Vaisseau { get; set; }
        public IEnumerable<ViewAmelioration> Amelioration { get; set; }
        public IEnumerable<ViewUser> Users { get; set; }
        public IEnumerable<ViewCamp> Camp { get; set; }
        public IEnumerable<ViewEscadron> Escdrons { get; set; }
        public int XIDEscadron { get; set; }
        public int XIDCamp { get; set; }
        public int XIDUser { get; set; }
        public IEnumerable<int?> XIDVaisseau { get; set; }
        public IEnumerable<int?> XIDAmelioration { get; set; }
        public IEnumerable<int?> XIDPilote { get; set; }
    }
}
