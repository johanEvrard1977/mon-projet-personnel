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
        public IEnumerable<Escadron> Escadron { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string Collection { get; set; }
    }
}