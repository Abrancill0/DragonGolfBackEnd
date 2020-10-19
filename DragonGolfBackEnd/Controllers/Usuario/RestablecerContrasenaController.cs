using DragonGolfBackEnd.Clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
namespace DragonGolfBackEnd.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/RestablecerContrasena")]
    public class RestableceContrasenaController : ApiController
    {

        public class DatosEntradas
        {
            public string Usuario { get; set; }
            public string Pass { get; set; }
        }

        public JObject Post(DatosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DargonGolf_RestablecerContrasena");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@Usuario", SqlDbType.VarChar);
                comando.Parameters.Add("@password", SqlDbType.VarChar);


                //Asignacion de valores a parametros
                comando.Parameters["@Usuario"].Value = Datos.Usuario;
                comando.Parameters["@password"].Value = Datos.Pass;


                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);


                string Mensaje = "";
                int Estatus = 0;


                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                    }

                }

                JObject Resultado = JObject.FromObject(new
                {
                    mensaje = Mensaje,
                    estatus = Estatus,

                });

                return Resultado;


            }
            catch (Exception ex)
            {


                JObject Resultado = JObject.FromObject(new
                {
                    mensaje = ex.ToString(),
                    estatus = 0,

                });

                return Resultado;
            }


        }


    }

}
