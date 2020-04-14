using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Camp
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<ViewPilote> Pilote { get; set; }
        public IEnumerable<ViewVaisseau> Vaisseau { get; set; }
        public IEnumerable<ViewType> Type { get; set; }
        public IEnumerable<ViewAmelioration> Amelioration { get; set; }
    }
}
