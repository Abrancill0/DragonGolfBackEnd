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
    [RoutePrefix("api/ListadoAmigosRonda")]
    public class ListadoAmigosRondaController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
            public int IDRounds { get; set; }

        }
        public class ParametrosSalida
        {

            public int IDRounds { get; set; }
            public int IDUsuario { get; set; }
            public int PlayerId { get; set; }
            public decimal RoundHandicap { get; set; }
            public string PlayerTee { get; set; }
            public int ScoreHole1 { get; set; }
            public int ScoreHole2 { get; set; }
            public int ScoreHole3 { get; set; }
            public int ScoreHole4 { get; set; }
            public int ScoreHole5 { get; set; }
            public int ScoreHole6 { get; set; }
            public int ScoreHole7 { get; set; }
            public int ScoreHole8 { get; set; }
            public int ScoreHole9 { get; set; }
            public int ScoreHole10 { get; set; }
            public int ScoreHole11 { get; set; }
            public int ScoreHole12 { get; set; }
            public int ScoreHole13 { get; set; }
            public int ScoreHole14 { get; set; }
            public int ScoreHole15 { get; set; }
            public int ScoreHole16 { get; set; }
            public int ScoreHole17 { get; set; }
            public int ScoreHole18 { get; set; }
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public string usu_nickname { get; set; }
            public int usu_ghinnumber { get; set; }
        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListFriendRound");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRounds", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);


                comando.Parameters["@IDRounds"].Value = Datos.IDRounds;
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
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                PlayerId = Convert.ToInt32(row["PlayerId"]),
                                RoundHandicap = Convert.ToDecimal(row["RoundHandicap"]),
                                PlayerTee = Convert.ToString(row["PlayerTee"]),
                                ScoreHole1 = Convert.ToInt32(row["ScoreHole1"]),
                                ScoreHole2 = Convert.ToInt32(row["ScoreHole2"]),
                                ScoreHole3 = Convert.ToInt32(row["ScoreHole3"]),
                                ScoreHole4 = Convert.ToInt32(row["ScoreHole4"]),
                                ScoreHole5 = Convert.ToInt32(row["ScoreHole5"]),
                                ScoreHole6 = Convert.ToInt32(row["ScoreHole6"]),
                                ScoreHole7 = Convert.ToInt32(row["ScoreHole7"]),
                                ScoreHole8 = Convert.ToInt32(row["ScoreHole8"]),
                                ScoreHole9 = Convert.ToInt32(row["ScoreHole9"]),
                                ScoreHole10 = Convert.ToInt32(row["ScoreHole10"]),
                                ScoreHole11 = Convert.ToInt32(row["ScoreHole11"]),
                                ScoreHole12 = Convert.ToInt32(row["ScoreHole12"]),
                                ScoreHole13 = Convert.ToInt32(row["ScoreHole13"]),
                                ScoreHole14 = Convert.ToInt32(row["ScoreHole14"]),
                                ScoreHole15 = Convert.ToInt32(row["ScoreHole15"]),
                                ScoreHole16 = Convert.ToInt32(row["ScoreHole16"]),
                                ScoreHole17 = Convert.ToInt32(row["ScoreHole17"]),
                                ScoreHole18 = Convert.ToInt32(row["ScoreHole18"]),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_ghinnumber = Convert.ToInt32(row["usu_ghinnumber"]),
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
