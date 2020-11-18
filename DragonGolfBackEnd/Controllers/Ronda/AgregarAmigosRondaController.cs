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
    [RoutePrefix("api/AgregarAmigosRonda")]
    public class AgregarAmigosRondaController : ApiController
    {
        public class ParametrosEntradas
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
    }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_AddFriendRound");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRounds", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@PlayerId", SqlDbType.Int);
                comando.Parameters.Add("@RoundHandicap", SqlDbType.Decimal);
                comando.Parameters.Add("@PlayerTee", SqlDbType.VarChar);
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

                comando.Parameters["@IDRounds"].Value = Datos.IDRounds;
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                comando.Parameters["@PlayerId"].Value = Datos.PlayerId;
                comando.Parameters["@RoundHandicap"].Value = Datos.RoundHandicap;
                comando.Parameters["@PlayerTee"].Value = Datos.PlayerTee;
                comando.Parameters["@ScoreHole1"].Value = Datos.ScoreHole1;
                comando.Parameters["@ScoreHole2"].Value = Datos.ScoreHole2;
                comando.Parameters["@ScoreHole3"].Value = Datos.ScoreHole3;
                comando.Parameters["@ScoreHole4"].Value = Datos.ScoreHole4;
                comando.Parameters["@ScoreHole5"].Value = Datos.ScoreHole5;
                comando.Parameters["@ScoreHole6"].Value = Datos.ScoreHole6;
                comando.Parameters["@ScoreHole7"].Value = Datos.ScoreHole7;
                comando.Parameters["@ScoreHole8"].Value = Datos.ScoreHole8;
                comando.Parameters["@ScoreHole9"].Value = Datos.ScoreHole9;
                comando.Parameters["@ScoreHole10"].Value = Datos.ScoreHole10;
                comando.Parameters["@ScoreHole11"].Value = Datos.ScoreHole11;
                comando.Parameters["@ScoreHole12"].Value = Datos.ScoreHole12;
                comando.Parameters["@ScoreHole13"].Value = Datos.ScoreHole13;
                comando.Parameters["@ScoreHole14"].Value = Datos.ScoreHole14;
                comando.Parameters["@ScoreHole15"].Value = Datos.ScoreHole15;
                comando.Parameters["@ScoreHole16"].Value = Datos.ScoreHole16;
                comando.Parameters["@ScoreHole17"].Value = Datos.ScoreHole17;
                comando.Parameters["@ScoreHole18"].Value = Datos.ScoreHole18;


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
