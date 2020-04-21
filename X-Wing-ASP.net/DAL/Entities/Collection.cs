using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Collection
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Vaisseaux> Vaisseau { get; set; }
        public IEnumerable<Escadron> Escadrons { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<int> XIDEscadron { get; set; }
        public int XIDCamp { get; set; }
        public int XIDUser { get; set; }
        public int XIDCollection { get; set; }
        public IEnumerable<int?> XIDVaisseau { get; set; }
        public IEnumerable<int?> XIDAmelioration { get; set; }
        public IEnumerable<int?> XIDPilote { get; set; }
    }
}
