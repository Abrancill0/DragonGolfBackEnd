using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragonGolfBackEnd.Clases
{
    public class VariablesGlobales
    {
        public static string CadenaConexion = ConfigurationManager.ConnectionStrings["DGConnectionString"].ConnectionString;
    }
}