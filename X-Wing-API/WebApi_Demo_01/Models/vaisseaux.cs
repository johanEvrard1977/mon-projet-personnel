using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;
using WebApiXwing.Models;

namespace WebApi_Demo_01.Models
{
    public class vaisseaux : Elements
    {
        public int ValeurAgilite { get; set; }
        public int ValeurArmePrincipale { get; set; }
        public int Bouclier { get; set; }
        public int Structure { get; set; }
        public int Energie { get; set; }
        public string Taille { get; set; }
        public string Capacite { get; set; }
        public IEnumerable<ViewPilote> Pilote { get; set; }
        public IEnumerable<ViewAction> Action { get; set; }
        public IEnumerable<ViewCamp> Camp { get; set; }
        public int XIDAction { get; set; }
        public int Quantite { get; set; }
    }
}