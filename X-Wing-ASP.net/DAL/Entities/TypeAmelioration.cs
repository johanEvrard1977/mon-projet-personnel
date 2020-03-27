using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class TypeAmelioration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
    }
}
