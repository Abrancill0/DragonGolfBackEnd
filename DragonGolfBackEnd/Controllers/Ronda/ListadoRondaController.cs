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
    [RoutePrefix("api/ListadoRonda")]
    public class ListadoRondaController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
         
        }
        public class ParametrosSalida
        {
            public int IDRounds { get; set; }
            public int IDCourse { get; set; }
            public string Ro_Name  { get; set; }
            public int Ro_HandicapAdjustment { get; set; }
            public int Ro_StartingHole { get; set; }
            public int Ro_SwitchAdventage { get; set; }
            public int IDUsuario { get; set; }
            public string Ro_Date { get; set; }
            public string Cou_Nombre{ get; set; } 
        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListRound");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
             
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
  


                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);

                List<ParametrosSalida> lista = new List<ParametrosSalida>();

                string Mensaje = "";
                int Estatus = 0;
              

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {
                            ParametrosSalida ent = new ParametrosSalida
                            {
                                IDRounds = Convert.ToInt32(row["IDRounds"]),
                                IDCourse = Convert.ToInt32(row["IDCourse"]),
                                Ro_Name = Convert.ToString(row["Ro_Name"]),
                                Ro_HandicapAdjustment = Convert.ToInt32(row["Ro_HandicapAdjustment"]),
                                Ro_StartingHole = Convert.ToInt32(row["Ro_StartingHole"]),
                                Ro_SwitchAdventage = Convert.ToInt32(row["Ro_SwitchAdventage"]),
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                Ro_Date = Convert.ToString(row["Ro_Date"]),
                                Cou_Nombre = Convert.ToString(row["Cou_Nombre"]),
                            };

                            lista.Add(ent);
                        }

                    }

                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,
                        Result = lista
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
