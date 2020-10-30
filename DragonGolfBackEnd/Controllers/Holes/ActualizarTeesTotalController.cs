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

namespace DragonGolfBackEnd.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/ActualizarTeesTotal")]
    public class ActualizarTeesTotalController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDTees { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {

            try
            {


                    SqlCommand comando = new SqlCommand("DragoGolf_AupdateTeesTotal");
                    comando.CommandType = CommandType.StoredProcedure;

                    //Declaracion de parametros
                  
                    comando.Parameters.Add("@IDTees", SqlDbType.Int);

                    //Asignacion de valores a parametros
                    comando.Parameters["@IDTees"].Value = Datos.IDTees;

                    comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                    comando.CommandTimeout = 0;
                    comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);





                JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = "OK",
                        estatus = 1,
                      
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

                return Resultado; //JsonConvert.SerializeObject(lista);
            }
        }


    }
}
