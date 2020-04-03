using DAL.Entities;
using DAL.ViewModels;
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
        public IEnumerable<ViewPilote> Pilote { get; set; }
        public IEnumerable<ViewVaisseau> Vaisseau { get; set; }
        public IEnumerable<ViewEscadron> Escadron { get; set; }
        public IEnumerable<ViewAmelioration> Amelioration { get; set; }
        public IEnumerable<ViewUser> Users { get; set; }
        public int XIDUser { get; set; }
    }
}