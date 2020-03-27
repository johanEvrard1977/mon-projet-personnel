using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Escadron
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        public bool Visible { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une valeur pour les points")]
        [Range(0, 100, ErrorMessage = "Please enter correct value")]
        public int Points { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une description"), MinLength(3), MaxLength(50)]
        public string Description { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Vaisseaux> Vaisseau { get; set; }
        public IEnumerable<Amelioration> Amelioration { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
    }
}
