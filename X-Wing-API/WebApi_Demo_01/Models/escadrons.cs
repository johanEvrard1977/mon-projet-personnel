using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class escadrons : Elements
    {
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