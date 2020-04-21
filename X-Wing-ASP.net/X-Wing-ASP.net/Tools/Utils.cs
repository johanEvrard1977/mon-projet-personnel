using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_Demo_01.Models;

namespace X_Wing_ASP.net.Tools
{
    public class Utils
    {
        public static Users LoginUtilisateur
        {
            get { return (Users)HttpContext.Current.Session["LoginUtilisateur"]; }
            set { HttpContext.Current.Session["LoginUtilisateur"] = value; }
        }
    }
}