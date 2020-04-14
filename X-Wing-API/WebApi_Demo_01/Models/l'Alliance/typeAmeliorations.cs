using DAL.ViewModels;
using DalXwing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models.commons;

namespace WebApi_Demo_01.Models.l_Alliance
{
    public class typeAmeliorations : Elements
    {
        public IEnumerable<ViewAmelioration> Amelioration { get; set; }
        public int XIDPilote { get; set; }
    }
}