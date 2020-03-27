using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models;
using WebApi_Demo_01.Models.commons;

namespace WebApiXwing.Models
{
    public class actions : Elements
    {
        public  IEnumerable<Vaisseaux> vaisseau { get; set; }
    }
}