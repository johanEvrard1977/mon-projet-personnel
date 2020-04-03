using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXwing.Models
{
    public class Vaisseaux
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int ValeurAgilite { get; set; }
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int ValeurArmePrincipale { get; set; }
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int Bouclier { get; set; }
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int Structure { get; set; }
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int Energie { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une taille"), MinLength(3), MaxLength(50)]
        public string Taille { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une capacité"), MinLength(3), MaxLength(50)]
        public string Capacite { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Actions> Action { get; set; }
        public IEnumerable<Camp> camps { get; set; }
        public int XIDAction { get; set; }
    }
}
