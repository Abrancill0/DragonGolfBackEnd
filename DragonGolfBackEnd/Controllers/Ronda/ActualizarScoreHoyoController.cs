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
    [RoutePrefix("api/ActualizarScoreHoyo")]
    public class ActualizarScoreHoyoController : ApiController
    {
        public class ParametrosEntradas
        {

            public int IDRounds { get; set; }
            public int IDUsuario { get; set; }
            public int PlayerId { get; set; }
            public int Score { get; set; }
            public int hole { get; set; }
          
        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_Update_Hole_Stoker");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRounds", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@PlayerId", SqlDbType.Int);
                comando.Parameters.Add("@Score", SqlDbType.Int);
                comando.Parameters.Add("@hole", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDRounds"].Value = Datos.IDRounds;
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                comando.Parameters["@PlayerId"].Value = Datos.PlayerId;
                comando.Parameters["@Score"].Value = Datos.Score;
                comando.Parameters["@hole"].Value = Datos.hole;

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
