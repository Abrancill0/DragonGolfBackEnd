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
    [RoutePrefix("api/ListadoStableFordStrokes")]
    public class ListadoStableFordStrokesController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDRonda { get; set; }
        }

        public class ParametrosSalida
        {
            public int IDRounds { get; set; }
            public string Ro_Name { get; set; }
            public DateTime Ro_Date { get; set; }
            public int Playerid { get; set; }
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public string usu_nickname { get; set; }
            public string usu_email { get; set; }
            public int IDTees { get; set; }
            public string PlayerTee { get; set; }
            public int stableford_double_eagle { get; set; }
            public int stableford_eagle { get; set; }
            public int stableford_birdie { get; set; }
            public int stableford_par { get; set; }
            public int stableford_bogey { get; set; }
            public int stableford_double_bogey { get; set; }
            public int PuntosHoyos1 { get; set; }
            public int PuntosHoyos2 { get; set; }
            public int PuntosHoyos3 { get; set; }
            public int PuntosHoyos4 { get; set; }
            public int PuntosHoyos5 { get; set; }
            public int PuntosHoyos6 { get; set; }
            public int PuntosHoyos7 { get; set; }
            public int PuntosHoyos8 { get; set; }
            public int PuntosHoyos9 { get; set; }
            public int PuntosHoyos10 { get; set; }
            public int PuntosHoyos11 { get; set; }
            public int PuntosHoyos12 { get; set; }
            public int PuntosHoyos13 { get; set; }
            public int PuntosHoyos14 { get; set; }
            public int PuntosHoyos15 { get; set; }
            public int PuntosHoyos17 { get; set; }
            public int PuntosHoyos18 { get; set; }
            public int TotalPuntosStableFord { get; set; }
            public int ScoreNeto1 { get; set; }
            public int ScoreNeto2 { get; set; }
            public int ScoreNeto3 { get; set; }
            public int ScoreNeto4 { get; set; }
            public int ScoreNeto5 { get; set; }
            public int ScoreNeto6 { get; set; }
            public int ScoreNeto7 { get; set; }
            public int ScoreNeto8 { get; set; }
            public int ScoreNeto9 { get; set; }
            public int ScoreNeto10 { get; set; }
            public int ScoreNeto11 { get; set; }
            public int ScoreNeto12 { get; set; }
            public int ScoreNeto13 { get; set; }
            public int ScoreNeto14 { get; set; }
            public int ScoreNeto15 { get; set; }
            public int ScoreNeto16 { get; set; }
            public int ScoreNeto17 { get; set; }
            public int ScoreNeto18 { get; set; }
            public int TotalScoreNeto { get; set; }
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
            public int TotalScore { get; set; }
            public int PuntosVentaja1 { get; set; }
            public int PuntosVentaja2 { get; set; }
            public int PuntosVentaja3 { get; set; }
            public int PuntosVentaja4 { get; set; }
            public int PuntosVentaja5 { get; set; }
            public int PuntosVentaja6 { get; set; }
            public int PuntosVentaja7 { get; set; }
            public int PuntosVentaja8 { get; set; }
            public int PuntosVentaja9 { get; set; }
            public int PuntosVentaja10 { get; set; }
            public int PuntosVentaja11 { get; set; }
            public int PuntosVentaja12 { get; set; }
            public int PuntosVentaja13 { get; set; }
            public int PuntosVentaja14 { get; set; }
            public int PuntosVentaja15 { get; set; }
            public int PuntosVentaja16 { get; set; }
            public int PuntosVentaja17 { get; set; }
            public int PuntosVentaja18 { get; set; }
            public int Strokes { get; set; }
            public int ParHoyo1 { get; set; }
            public int ParHoyo2 { get; set; }
            public int ParHoyo3 { get; set; }
            public int ParHoyo4 { get; set; }
            public int ParHoyo5 { get; set; }
            public int ParHoyo6 { get; set; }
            public int ParHoyo8 { get; set; }
            public int ParHoyo9 { get; set; }
            public int ParHoyo10 { get; set; }
            public int ParHoyo11 { get; set; }
            public int ParHoyo12 { get; set; }
            public int ParHoyo13 { get; set; }
            public int ParHoyo14 { get; set; }
            public int ParHoyo15 { get; set; }
            public int ParHoyo16 { get; set; }
            public int ParHoyo17 { get; set; }
            public int ParHoyo18 { get; set; }
            public int VentajaHoyo1 { get; set; }
            public int VentajaHoyo2 { get; set; }
            public int VentajaHoyo3 { get; set; }
            public int VentajaHoyo4 { get; set; }
            public int VentajaHoyo5 { get; set; }
            public int VentajaHoyo6 { get; set; }
            public int VentajaHoyo7 { get; set; }
            public int VentajaHoyo8 { get; set; }
            public int VentajaHoyo9 { get; set; }
            public int VentajaHoyo10 { get; set; }
            public int VentajaHoyo11 { get; set; }
            public int VentajaHoyo12 { get; set; }
            public int VentajaHoyo13 { get; set; }
            public int VentajaHoyo14 { get; set; }
            public int VentajaHoyo15 { get; set; }
            public int VentajaHoyo16 { get; set; }
            public int VentajaHoyo17 { get; set; }
            public int VentajaHoyo18 { get; set; }
        }



        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListStableFord");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDRonda"].Value = Datos.IDRonda;

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
                                Ro_Name = Convert.ToString(row["Ro_Name"]),
                                Ro_Date = Convert.ToDateTime(row["Ro_Date"]),
                                Playerid = Convert.ToInt32(row["Playerid"]),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                IDTees = Convert.ToInt32(row["IDTees"]),
                                PlayerTee = Convert.ToString(row["PlayerTee"]),

                                stableford_double_eagle = Convert.ToInt32(row["stableford_double_eagle"]),
                                stableford_eagle = Convert.ToInt32(row["stableford_eagle"]),
                                stableford_birdie = Convert.ToInt32(row["stableford_birdie"]),
                                stableford_par = Convert.ToInt32(row["stableford_par"]),
                                stableford_bogey = Convert.ToInt32(row["stableford_bogey"]),
                                stableford_double_bogey = Convert.ToInt32(row["stableford_double_bogey"]),
                                
                                PuntosHoyos1 = Convert.ToInt32(row["PuntosHoyos1"]),
                                PuntosHoyos2 = Convert.ToInt32(row["PuntosHoyos2"]),
                                PuntosHoyos3 = Convert.ToInt32(row["PuntosHoyos3"]),
                                PuntosHoyos4 = Convert.ToInt32(row["PuntosHoyos4"]),
                                PuntosHoyos5 = Convert.ToInt32(row["PuntosHoyos5"]),
                                PuntosHoyos6 = Convert.ToInt32(row["PuntosHoyos6"]),
                                PuntosHoyos7 = Convert.ToInt32(row["PuntosHoyos7"]),
                                PuntosHoyos8 = Convert.ToInt32(row["PuntosHoyos8"]),
                                PuntosHoyos9 = Convert.ToInt32(row["PuntosHoyos9"]),
                                PuntosHoyos10 = Convert.ToInt32(row["PuntosHoyos10"]),
                                PuntosHoyos11 = Convert.ToInt32(row["PuntosHoyos11"]),
                                PuntosHoyos12 = Convert.ToInt32(row["PuntosHoyos12"]),
                                PuntosHoyos13 = Convert.ToInt32(row["PuntosHoyos13"]),
                                PuntosHoyos14 = Convert.ToInt32(row["PuntosHoyos14"]),
                                PuntosHoyos15 = Convert.ToInt32(row["PuntosHoyos15"]),
                                PuntosHoyos17 = Convert.ToInt32(row["PuntosHoyos17"]),
                                PuntosHoyos18 = Convert.ToInt32(row["PuntosHoyos18"]),
                               
                                TotalPuntosStableFord = Convert.ToInt32(row["TotalPuntosStableFord"]),
                                
                                ScoreNeto1 = Convert.ToInt32(row["ScoreNeto1"]),
                                ScoreNeto2 = Convert.ToInt32(row["ScoreNeto2"]),
                                ScoreNeto3 = Convert.ToInt32(row["ScoreNeto3"]),
                                ScoreNeto4 = Convert.ToInt32(row["ScoreNeto4"]),
                                ScoreNeto5 = Convert.ToInt32(row["ScoreNeto5"]),
                                ScoreNeto6 = Convert.ToInt32(row["ScoreNeto6"]),
                                ScoreNeto7 = Convert.ToInt32(row["ScoreNeto7"]),
                                ScoreNeto8 = Convert.ToInt32(row["ScoreNeto8"]),
                                ScoreNeto9 = Convert.ToInt32(row["ScoreNeto9"]),
                                ScoreNeto10 = Convert.ToInt32(row["ScoreNeto10"]),
                                ScoreNeto11 = Convert.ToInt32(row["ScoreNeto11"]),
                                ScoreNeto12 = Convert.ToInt32(row["ScoreNeto12"]),
                                ScoreNeto13 = Convert.ToInt32(row["ScoreNeto13"]),
                                ScoreNeto14 = Convert.ToInt32(row["ScoreNeto14"]),
                                ScoreNeto15 = Convert.ToInt32(row["ScoreNeto15"]),
                                ScoreNeto16 = Convert.ToInt32(row["ScoreNeto16"]),
                                ScoreNeto17 = Convert.ToInt32(row["ScoreNeto17"]),
                                ScoreNeto18 = Convert.ToInt32(row["ScoreNeto18"]),

                                TotalScoreNeto = Convert.ToInt32(row["TotalScoreNeto"]),
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

                                TotalScore = Convert.ToInt32(row["TotalScore"]),


                                PuntosVentaja1 = Convert.ToInt32(row["PuntosVentaja1"]),
                                PuntosVentaja2 = Convert.ToInt32(row["PuntosVentaja2"]),
                                PuntosVentaja3 = Convert.ToInt32(row["PuntosVentaja3"]),
                                PuntosVentaja4 = Convert.ToInt32(row["PuntosVentaja4"]),
                                PuntosVentaja5 = Convert.ToInt32(row["PuntosVentaja5"]),
                                PuntosVentaja6 = Convert.ToInt32(row["PuntosVentaja6"]),
                                PuntosVentaja7 = Convert.ToInt32(row["PuntosVentaja7"]),
                                PuntosVentaja8 = Convert.ToInt32(row["PuntosVentaja8"]),
                                PuntosVentaja9 = Convert.ToInt32(row["PuntosVentaja9"]),
                                PuntosVentaja10 = Convert.ToInt32(row["PuntosVentaja10"]),
                                PuntosVentaja11 = Convert.ToInt32(row["PuntosVentaja11"]),
                                PuntosVentaja12 = Convert.ToInt32(row["PuntosVentaja12"]),
                                PuntosVentaja13 = Convert.ToInt32(row["PuntosVentaja13"]),
                                PuntosVentaja14 = Convert.ToInt32(row["PuntosVentaja14"]),
                                PuntosVentaja15 = Convert.ToInt32(row["PuntosVentaja15"]),
                                PuntosVentaja16 = Convert.ToInt32(row["PuntosVentaja16"]),
                                PuntosVentaja17 = Convert.ToInt32(row["PuntosVentaja17"]),
                                PuntosVentaja18 = Convert.ToInt32(row["PuntosVentaja18"]),

                                Strokes = Convert.ToInt32(row["Strokes"]),

                                ParHoyo1 = Convert.ToInt32(row["ParHoyo1"]),
                                ParHoyo2 = Convert.ToInt32(row["ParHoyo2"]),
                                ParHoyo3 = Convert.ToInt32(row["ParHoyo3"]),
                                ParHoyo4 = Convert.ToInt32(row["ParHoyo4"]),
                                ParHoyo5 = Convert.ToInt32(row["ParHoyo5"]),
                                ParHoyo6 = Convert.ToInt32(row["ParHoyo6"]),

                                ParHoyo8 = Convert.ToInt32(row["ParHoyo8"]),
                                ParHoyo9 = Convert.ToInt32(row["ParHoyo9"]),
                                ParHoyo10 = Convert.ToInt32(row["ParHoyo10"]),
                                ParHoyo11 = Convert.ToInt32(row["ParHoyo11"]),
                                ParHoyo12 = Convert.ToInt32(row["ParHoyo12"]),
                                ParHoyo13 = Convert.ToInt32(row["ParHoyo13"]),
                                ParHoyo14 = Convert.ToInt32(row["ParHoyo14"]),
                                ParHoyo15 = Convert.ToInt32(row["ParHoyo15"]),
                                ParHoyo16 = Convert.ToInt32(row["ParHoyo16"]),
                                ParHoyo17 = Convert.ToInt32(row["ParHoyo17"]),
                                ParHoyo18 = Convert.ToInt32(row["ParHoyo18"]),

                                VentajaHoyo1 = Convert.ToInt32(row["VentajaHoyo1"]),
                                VentajaHoyo2 = Convert.ToInt32(row["VentajaHoyo2"]),
                                VentajaHoyo3 = Convert.ToInt32(row["VentajaHoyo3"]),
                                VentajaHoyo4 = Convert.ToInt32(row["VentajaHoyo4"]),
                                VentajaHoyo5 = Convert.ToInt32(row["VentajaHoyo5"]),
                                VentajaHoyo6 = Convert.ToInt32(row["VentajaHoyo6"]),
                                VentajaHoyo7 = Convert.ToInt32(row["VentajaHoyo7"]),
                                VentajaHoyo8 = Convert.ToInt32(row["VentajaHoyo8"]),
                                VentajaHoyo9 = Convert.ToInt32(row["VentajaHoyo9"]),
                                VentajaHoyo10 = Convert.ToInt32(row["VentajaHoyo10"]),
                                VentajaHoyo11 = Convert.ToInt32(row["VentajaHoyo11"]),
                                VentajaHoyo12 = Convert.ToInt32(row["VentajaHoyo12"]),
                                VentajaHoyo13 = Convert.ToInt32(row["VentajaHoyo13"]),
                                VentajaHoyo14 = Convert.ToInt32(row["VentajaHoyo14"]),
                                VentajaHoyo15 = Convert.ToInt32(row["VentajaHoyo15"]),
                                VentajaHoyo16 = Convert.ToInt32(row["VentajaHoyo16"]),
                                VentajaHoyo17 = Convert.ToInt32(row["VentajaHoyo17"]),
                                VentajaHoyo18 = Convert.ToInt32(row["VentajaHoyo18"]),
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
