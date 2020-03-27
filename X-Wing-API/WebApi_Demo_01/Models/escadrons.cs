using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class escadrons : Elements
    {
        public bool Visible { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public IEnumerable<pilotes> Pilote { get; set; }
        public IEnumerable<vaisseaux> Vaisseau { get; set; }
        public IEnumerable<ameliorations> Amelioration { get; set; }
        public IEnumerable<camps> Camp { get; set; }
    }
}