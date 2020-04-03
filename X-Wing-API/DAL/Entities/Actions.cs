using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Actions
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<ViewVaisseau> Vaisseau { get; set; }
        public int XIDVaisseau { get; set; }
    }
}
