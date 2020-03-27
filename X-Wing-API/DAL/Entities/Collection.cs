using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Vaisseaux> Vaisseau { get; set; }
        public IEnumerable<Escadron> Escadron { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
