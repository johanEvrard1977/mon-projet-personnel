using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models.l_Alliance
{
    public class pilotes : Elements
    {
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
        public int Quantite { get; set; }
    }
}