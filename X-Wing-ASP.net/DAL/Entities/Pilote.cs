using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    
    public class Pilote
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        public bool Unique { get; set; }
        [Range(0, 20, ErrorMessage = "Please enter correct value")]
        public int Cout { get; set; }
        [Range(0, 20, ErrorMessage = "Please enter correct value")]
        public int ValeurPilotage { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un commentaire"), MinLength(3), MaxLength(500)]
        public string Commentaires { get; set; }
        public IEnumerable<Vaisseaux> Vaisseaux { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<TypeAmelioration> Type { get; set; }
        public int XIDCamp { get; set; }
        public int XIDVaisseau { get; set; }
        public int XIDType { get; set; }
        public int Quantite { get; set; }
    }
}
