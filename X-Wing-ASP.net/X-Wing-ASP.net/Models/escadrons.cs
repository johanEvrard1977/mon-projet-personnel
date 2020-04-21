using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class escadrons : Elements
    {
        public bool Visible { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Vaisseaux> Vaisseau { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<Collection> Collection { get; set; }
        public int XIDCamp { get; set; }
        public int XIDEscadron { get; set; }
        public IEnumerable<int?> XIDVaisseau { get; set; }
        public IEnumerable<int?> XIDAmelioration { get; set; }
        public IEnumerable<int?> XIDPilote { get; set; }
        public int XIDCollection { get; set; }
        public int Quantite { get; set; }
    }
}