using DAL.Entities;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class collections: Elements
    {
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Vaisseaux> Vaisseau { get; set; }
        public IEnumerable<Escadron> Escadrons { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<int> XIDEscadron { get; set; }
        public int XIDCamp { get; set; }
        public int XIDUser { get; set; }
        public int XIDCollection { get; set; }
        public IEnumerable<int?> XIDVaisseau { get; set; }
        public IEnumerable<int?> XIDAmelioration { get; set; }
        public IEnumerable<int?> XIDPilote { get; set; }
    }
}