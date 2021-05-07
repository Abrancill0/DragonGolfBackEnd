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
    [RoutePrefix("api/ActualizarRonda")]
    public class ActualizarRondaController : ApiController
    {
        public class ParametrosEntradas
        {

            public int IDCourse { get; set; }
            public string Ro_Name { get; set; }
            public int Ro_HandicapAdjustment { get; set; }
            public int Ro_StartingHole { get; set; }
            public int Ro_SwitchAdventage { get; set; }
            public int IDUsuario { get; set; }
            public int IDRound { get; set; }
            public DateTime Ro_Date { get; set; }
        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_UpdateRound");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDCourse", SqlDbType.Int);
                comando.Parameters.Add("@Ro_Name", SqlDbType.VarChar);
                comando.Parameters.Add("@Ro_HandicapAdjustment", SqlDbType.Int);
                comando.Parameters.Add("@Ro_StartingHole", SqlDbType.Int);
                comando.Parameters.Add("@Ro_SwitchAdventage", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@Ro_Date", SqlDbType.DateTime);
                comando.Parameters.Add("@IDRound", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDCourse"].Value = Datos.IDCourse;
                comando.Parameters["@Ro_Name"].Value = Datos.Ro_Name;
                comando.Parameters["@Ro_HandicapAdjustment"].Value = Datos.Ro_HandicapAdjustment;
                comando.Parameters["@Ro_StartingHole"].Value = Datos.Ro_StartingHole;
                comando.Parameters["@Ro_SwitchAdventage"].Value = Datos.Ro_SwitchAdventage;
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                comando.Parameters["@Ro_Date"].Value = Datos.Ro_Date;
                comando.Parameters["@IDRound"].Value = Datos.IDRound;


                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);



                string Mensaje = "";
                int Estatus = 0;
                int IDRound = 0;

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
                        //IDRound = Convert.ToInt32(row["IDRound"]);

                    }

                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,
                        //idround = IDRound,
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
