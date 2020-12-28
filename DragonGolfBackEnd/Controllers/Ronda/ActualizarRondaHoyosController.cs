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
    [RoutePrefix("api/ActualizarRondaHoyos")]
    public class ActualizarRondaHoyosController : ApiController
    {
      

        public class ParametrosEntradas
        {
           public int IDRound { get; set; }
            public int IDUsuario { get; set; }
            public int NumeroArreglo { get; set; }
            public string Arreglo { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            string Arreglover = Datos.Arreglo;
            try
            {

              
                string Arreglo1 = Datos.Arreglo.Replace("\"", "");

                int len = Arreglo1.Length;

                string Arreglo1_1 = Arreglo1.Substring(1, len - 2);

                string Arreglo2 = Arreglo1_1.Replace("[", "{");
                string Arreglo3 = Arreglo2.Replace("]", "}");

                string[] ArregloFinal = Arreglo3.Split('{');

              

                for (int i = 1; i < Datos.NumeroArreglo+1; i++)
                {
                    string ArregloSimple = ArregloFinal[i];

                    string EliminaParte1 = ArregloSimple.Replace("{", "");
                    string EliminaParte2 = EliminaParte1.Replace("},", "");
                    string EliminaParte3 = EliminaParte2.Replace("}", "");

                    string[] Valores = EliminaParte3.Split(',');

                    int PlayerId = Convert.ToInt32(Valores[0]);
                    int ScoreHole1 = Convert.ToInt32(Valores[1]);
                    int ScoreHole2 = Convert.ToInt32(Valores[2]);
                    int ScoreHole3 = Convert.ToInt32(Valores[3]);
                    int ScoreHole4 = Convert.ToInt32(Valores[4]);
                    int ScoreHole5 = Convert.ToInt32(Valores[5]);
                    int ScoreHole6 = Convert.ToInt32(Valores[6]);
                    int ScoreHole7 = Convert.ToInt32(Valores[7]);
                    int ScoreHole8 = Convert.ToInt32(Valores[8]);
                    int ScoreHole9 = Convert.ToInt32(Valores[9]);
                    int ScoreHole10 = Convert.ToInt32(Valores[10]);
                    int ScoreHole11 = Convert.ToInt32(Valores[11]);
                    int ScoreHole12 = Convert.ToInt32(Valores[12]);
                    int ScoreHole13 = Convert.ToInt32(Valores[13]);
                    int ScoreHole14 = Convert.ToInt32(Valores[14]);
                    int ScoreHole15 = Convert.ToInt32(Valores[15]);
                    int ScoreHole16 = Convert.ToInt32(Valores[16]);
                    int ScoreHole17 = Convert.ToInt32(Valores[17]);
                    int ScoreHole18 = Convert.ToInt32(Valores[18]);

                    SqlCommand comando = new SqlCommand("DragoGolf_UpdatePlayerRoundHoles");
                    comando.CommandType = CommandType.StoredProcedure;

                    //Declaracion de parametros
                    comando.Parameters.Add("@IDRounds", SqlDbType.Int);
                    comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                    comando.Parameters.Add("@PlayerId", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole1", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole2", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole3", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole4", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole5", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole6", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole7", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole8", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole9", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole10", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole11", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole12", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole13", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole14", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole15", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole16", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole17", SqlDbType.Int);
                    comando.Parameters.Add("@ScoreHole18", SqlDbType.Int);

                    //Asignacion de valores a parametros
                    comando.Parameters["@IDRounds"].Value = Datos.IDRound;
                    comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                    comando.Parameters["@PlayerId"].Value = PlayerId;
                    comando.Parameters["@ScoreHole1"].Value = ScoreHole1;
                    comando.Parameters["@ScoreHole2"].Value = ScoreHole2;
                    comando.Parameters["@ScoreHole3"].Value = ScoreHole3;
                    comando.Parameters["@ScoreHole4"].Value = ScoreHole4;
                    comando.Parameters["@ScoreHole5"].Value = ScoreHole5;
                    comando.Parameters["@ScoreHole6"].Value = ScoreHole6;
                    comando.Parameters["@ScoreHole7"].Value = ScoreHole7;
                    comando.Parameters["@ScoreHole8"].Value = ScoreHole8;
                    comando.Parameters["@ScoreHole9"].Value = ScoreHole9;
                    comando.Parameters["@ScoreHole10"].Value = ScoreHole10;
                    comando.Parameters["@ScoreHole11"].Value = ScoreHole11;
                    comando.Parameters["@ScoreHole12"].Value = ScoreHole12;
                    comando.Parameters["@ScoreHole13"].Value = ScoreHole13;
                    comando.Parameters["@ScoreHole14"].Value = ScoreHole14;
                    comando.Parameters["@ScoreHole15"].Value = ScoreHole15;
                    comando.Parameters["@ScoreHole16"].Value = ScoreHole16;
                    comando.Parameters["@ScoreHole17"].Value = ScoreHole17;
                    comando.Parameters["@ScoreHole18"].Value = ScoreHole18;
                  
                    comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                    comando.CommandTimeout = 0;
                    comando.Connection.Open();

                    DataTable DT = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(comando);
                    comando.Connection.Close();
                    DA.Fill(DT);

                }

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
                    Arreglover = Arreglover

                }); ;

                return Resultado; //JsonConvert.SerializeObject(lista);
            }
        }


    }
}
