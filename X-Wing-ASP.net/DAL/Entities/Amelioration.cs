using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Amelioration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        [Range(0, 20, ErrorMessage = "Please enter correct value")]
        public int Cout { get; set; }
        public bool Unique { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une taille minimum"), MinLength(3), MaxLength(50)]
        public string TailleMin { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une taille maximum"), MinLength(3), MaxLength(50)]
        public string TailleMax { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une description"), MinLength(3), MaxLength(50)]
        public string Description { get; set; }
        public bool UnParVaisseau { get; set; }
        public IEnumerable<TypeAmelioration> Type { get; set; }
        public int XIDType { get; set; }
        public int Quantite { get; set; }
    }
}
