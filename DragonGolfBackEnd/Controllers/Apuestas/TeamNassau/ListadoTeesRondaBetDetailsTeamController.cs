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
    [RoutePrefix("api/ListadoTeesRondaBetDetailsTeam")]
    public class ListadoTeesRondaBetDetailsTeamController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDBet_Detail { get; set; }
        }
        public class ParametrosSalida
        {
            public int IDCourse { get; set; }
            public string Ro_Name { get; set; }
            public int IDTees { get; set; }
            public string PlayerTee { get; set; }
            public int Par_Hole1 { get; set; }
            public int Par_Hole2 { get; set; }
            public int Par_Hole3 { get; set; }
            public int Par_Hole4 { get; set; }
            public int Par_Hole5 { get; set; }
            public int Par_Hole6 { get; set; }
            public int Par_Hole7 { get; set; }
            public int Par_Hole8 { get; set; }
            public int Par_Hole9 { get; set; }
            public int Par_Hole10 { get; set; }
            public int Par_Hole11 { get; set; }
            public int Par_Hole12 { get; set; }
            public int Par_Hole13 { get; set; }
            public int Par_Hole14 { get; set; }
            public int Par_Hole15 { get; set; }
            public int Par_Hole16 { get; set; }
            public int Par_Hole17 { get; set; }
            public int Par_Hole18 { get; set; }
            public string Te_TeeColor { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListTeesRounds_BetDetail_Team");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDBet_Detail", SqlDbType.Int);

                comando.Parameters["@IDBet_Detail"].Value = Datos.IDBet_Detail;

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

                                IDCourse = Convert.ToInt32(row["IDCourse"]),
                                Ro_Name = Convert.ToString(row["Ro_Name"]),
                                IDTees = Convert.ToInt32(row["IDTees"]),
                                PlayerTee = Convert.ToString(row["PlayerTee"]),
                                Par_Hole1 = Convert.ToInt32(row["Par_Hole1"]),
                                Par_Hole2 = Convert.ToInt32(row["Par_Hole2"]),
                                Par_Hole3 = Convert.ToInt32(row["Par_Hole3"]),
                                Par_Hole4 = Convert.ToInt32(row["Par_Hole4"]),
                                Par_Hole5 = Convert.ToInt32(row["Par_Hole5"]),
                                Par_Hole6 = Convert.ToInt32(row["Par_Hole6"]),
                                Par_Hole7 = Convert.ToInt32(row["Par_Hole7"]),
                                Par_Hole8 = Convert.ToInt32(row["Par_Hole8"]),
                                Par_Hole9 = Convert.ToInt32(row["Par_Hole9"]),
                                Par_Hole10 = Convert.ToInt32(row["Par_Hole10"]),
                                Par_Hole11 = Convert.ToInt32(row["Par_Hole11"]),
                                Par_Hole12 = Convert.ToInt32(row["Par_Hole12"]),
                                Par_Hole13 = Convert.ToInt32(row["Par_Hole13"]),
                                Par_Hole14 = Convert.ToInt32(row["Par_Hole14"]),
                                Par_Hole15 = Convert.ToInt32(row["Par_Hole15"]),
                                Par_Hole16 = Convert.ToInt32(row["Par_Hole16"]),
                                Par_Hole17 = Convert.ToInt32(row["Par_Hole17"]),
                                Par_Hole18 = Convert.ToInt32(row["Par_Hole18"]),
                                Te_TeeColor = Convert.ToString(row["Te_TeeColor"]),

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
