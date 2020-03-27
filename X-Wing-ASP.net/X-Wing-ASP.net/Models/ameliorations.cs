using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class ameliorations : Elements
    {
        public int Cout { get; set; }
        public bool Unique { get; set; }
        public int TailleMin { get; set; }
        public int TailleMax { get; set; }
        public string Description { get; set; }
        public bool UnParVaisseau { get; set; }
        public IEnumerable<TypeAmelioration> Type { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
    }
}