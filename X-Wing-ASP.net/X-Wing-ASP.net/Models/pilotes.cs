using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class pilotes : Elements
    {
        public bool Unique { get; set; }
        public int Cout { get; set; }
        public int ValeurPilotage { get; set; }
        public string Commentaires { get; set; }
        public IEnumerable<Vaisseaux> Vaisseaux { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<TypeAmelioration> Type { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public int camp { get; set; }
        public int vaisseau { get; set; }
        public int XIDType { get; set; }
    }
}