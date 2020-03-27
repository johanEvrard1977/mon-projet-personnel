using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom"), MinLength(3), MaxLength(50)]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un prénom"), MinLength(3), MaxLength(50)]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un username"), MinLength(3), MaxLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un password"), MinLength(3), MaxLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mail valide"), MinLength(3), MaxLength(50)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email non valide.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un role"), MinLength(3), MaxLength(50)]
        public string Role { get; set; }
        public IEnumerable<Collection> Collection { get; set; }
    }
}
