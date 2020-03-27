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
        [DataType(DataType.Text)]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une valeur d'agilité")]
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int ValeurAgilite { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une valeur d'arme principale"), MinLength(3), MaxLength(50)]
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int ValeurArmePrincipale { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une valeur pour le bouclier"), MinLength(3), MaxLength(50)]
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int Bouclier { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une valeur de structure"), MinLength(3), MaxLength(50)]
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int Structure { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une valeur d'énergie"), MinLength(3), MaxLength(50)]
        [Range(0, 20, ErrorMessage = "Veuillez entrer un nombre entre 0 et 20")]
        public int Energie { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une taille"), MinLength(3), MaxLength(50)]
        [DataType(DataType.Text)]
        public string Taille { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une capacité"), MinLength(3), MaxLength(50)]
        [DataType(DataType.Text)]
        public string Capacite { get; set; }
        public IEnumerable<Pilote> Pilote { get; set; }
        public IEnumerable<Actions> Action { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
    }
}
