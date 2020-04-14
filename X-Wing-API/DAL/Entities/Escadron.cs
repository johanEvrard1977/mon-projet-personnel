using DAL.ViewModels;
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
        public IEnumerable<ViewPilote> Pilote { get; set; }
        public IEnumerable<ViewVaisseau> Vaisseau { get; set; }
        public IEnumerable<ViewAmelioration> Amelioration { get; set; }
        public IEnumerable<ViewCamp> Camp { get; set; }
        public IEnumerable<ViewCollection> Collection { get; set; }
        public int XIDCamp { get; set; }
        public IEnumerable<int?> XIDVaisseau { get; set; }
        public IEnumerable<int?> XIDAmelioration { get; set; }
        public IEnumerable<int?> XIDPilote { get; set; }
        public int XIDColllection { get; set; }
        public int Quantite { get; set; }
    }
}
