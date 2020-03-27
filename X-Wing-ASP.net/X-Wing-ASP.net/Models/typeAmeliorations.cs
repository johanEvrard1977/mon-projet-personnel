using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models
{
    public class typeAmeliorations : Elements
    {
        public IEnumerable<Amelioration> Amelioration { get; set; }
    }
}