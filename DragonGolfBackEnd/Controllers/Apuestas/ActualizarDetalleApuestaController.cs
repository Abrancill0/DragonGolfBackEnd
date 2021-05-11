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
    [RoutePrefix("api/ActualizarDetalleApuesta")]
    public class ActualizarDetalleApuestaController : ApiController
    {

        public class ParametrosSalida
        {
            public int IDBet { get; set; }
            public int IDRonda { get; set; }
            public int IDBetDetail { get; set; }
        }


        public class ParametrosEntrada
        {
            public int IDBet { get; set; }
            public int IDBetDetail { get; set; }
            public int IDRonda { get; set; }
            public int BetD_Player1 { get; set; }
            public int BetD_Player2 { get; set; }
            public float BetD_MontoF9 { get; set; }
            public float BetD_MontoB9 { get; set; }
            public int BetD_Match { get; set; }
            public float BetD_Carry { get; set; }
            public float BetD_Medal { get; set; }
            public int BetD_AutoPress { get; set; }
            public int BetD_ManuallyOverrideAdv { get; set; }
            public int BetD_AdvStrokers { get; set; }
        }



        public JObject Post(ParametrosEntrada Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_UpdateDetailBet");
                comando.CommandType = CommandType.StoredProcedure;


                //Declaracion de parametros
                comando.Parameters.Add("@IDBet", SqlDbType.Int);
                comando.Parameters.Add("@IDBetDetail", SqlDbType.Int);
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);
                comando.Parameters.Add("@BetD_Player1", SqlDbType.Int);
                comando.Parameters.Add("@BetD_Player2", SqlDbType.Int);
                comando.Parameters.Add("@BetD_MontoF9", SqlDbType.Float);
                comando.Parameters.Add("@BetD_MontoB9", SqlDbType.Float);
                comando.Parameters.Add("@BetD_Match", SqlDbType.Int);
                comando.Parameters.Add("@BetD_Carry", SqlDbType.Float);
                comando.Parameters.Add("@BetD_Medal", SqlDbType.Float);
                comando.Parameters.Add("@BetD_AutoPress", SqlDbType.Int);
                comando.Parameters.Add("@BetD_ManuallyOverrideAdv", SqlDbType.Int);
                comando.Parameters.Add("@BetD_AdvStrokers", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDBet"].Value = Datos.IDBet;
                comando.Parameters["@IDBetDetail"].Value = Datos.IDBetDetail;
                comando.Parameters["@IDRonda"].Value = Datos.IDRonda;
                comando.Parameters["@BetD_Player1"].Value = Datos.BetD_Player1;
                comando.Parameters["@BetD_Player2"].Value = Datos.BetD_Player2;
                comando.Parameters["@BetD_MontoF9"].Value = Datos.BetD_MontoF9;
                comando.Parameters["@BetD_MontoB9"].Value = Datos.BetD_MontoB9;
                comando.Parameters["@BetD_Match"].Value = Datos.BetD_Match;
                comando.Parameters["@BetD_Carry"].Value = Datos.BetD_Carry;
                comando.Parameters["@BetD_Medal"].Value = Datos.BetD_Medal;
                comando.Parameters["@BetD_AutoPress"].Value = Datos.BetD_AutoPress;
                comando.Parameters["@BetD_ManuallyOverrideAdv"].Value = Datos.BetD_ManuallyOverrideAdv;
                comando.Parameters["@BetD_AdvStrokers"].Value = Datos.BetD_AdvStrokers;


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
