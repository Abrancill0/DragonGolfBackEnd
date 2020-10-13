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
    [RoutePrefix("api/AltaCampo")]
    public class AltaCampoController : ApiController
    {
        public class ParametrosEntradas
        {
            public string Cou_Nombre { get; set; }
            public string Cou_NombreCorto { get; set; }
            public string Cou_Ciudad { get; set; }
            public string Cou_Pais { get; set; }
            public int IDUsuario { get; set; }
        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_InsertCourse");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@Cou_Nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@Cou_NombreCorto", SqlDbType.VarChar);
                comando.Parameters.Add("@Cou_Ciudad", SqlDbType.VarChar);
                comando.Parameters.Add("@Cou_Pais", SqlDbType.VarChar);
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@Cou_Nombre"].Value = Datos.Cou_Nombre;
                comando.Parameters["@Cou_NombreCorto"].Value = Datos.Cou_NombreCorto;
                comando.Parameters["@Cou_Ciudad"].Value = Datos.Cou_Ciudad;
                comando.Parameters["@Cou_Pais"].Value = Datos.Cou_Pais;
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);



                string Mensaje = "";
                int Estatus = 0;

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
                    }

                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,

                    });

                    return Resultado;
                }
                else
                {
                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,

                    });

                    return Resultado;
                }

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
