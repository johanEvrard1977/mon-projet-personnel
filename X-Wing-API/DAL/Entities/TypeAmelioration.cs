using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class TypeAmelioration
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<ViewAmelioration> Amelioration { get; set; }
        public int XIDPilote { get; set; }
    }
}
