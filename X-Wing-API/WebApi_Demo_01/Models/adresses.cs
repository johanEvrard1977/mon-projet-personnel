using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Demo_01.Models
{
    public class adresses
    {
        public int Id { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int Cp { get; set; }
        public String Ville { get; set; }
        public string Pays { get; set; }
    }
}