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
    [RoutePrefix("api/CrearDetalleApuestaMasivo")]
    public class CrearDetalleApuestaMasivoController : ApiController
    {

        public class ParametrosEntrada
        {
            public string Arreglo { get; set; }
        }

        public JObject Post(ParametrosEntrada Datos)
        {
            try
            {

                string Arreglover = Datos.Arreglo;

                string[] ArregloFinal = Arreglover.Split('{');

                for (int i = 1; i < ArregloFinal.Length; i++)
                {
                    string ArregloSimple = ArregloFinal[i];

                    string EliminaParte1 = ArregloSimple.Replace("{", "");
                    string EliminaParte2 = EliminaParte1.Replace("},", "");
                    string EliminaParte3 = EliminaParte2.Replace("}", "");

                    string[] Valores = EliminaParte3.Split(',');

                    int IDBet = Convert.ToInt32(Valores[0]);
                    int IDRonda = Convert.ToInt32(Valores[1]);
                    int BetD_Player1 = Convert.ToInt32(Valores[2]);
                    int BetD_Player2 = Convert.ToInt32(Valores[3]);
                    float BetD_MontoF9 = Convert.ToSingle(Valores[4]);
                    float BetD_MontoB9 = Convert.ToSingle(Valores[5]);
                    int BetD_Match = Convert.ToInt32(Valores[6]);
                    int BetD_Carry = Convert.ToInt32(Valores[7]);
                    int BetD_Medal = Convert.ToInt32(Valores[8]);
                    int BetD_AutoPress = Convert.ToInt32(Valores[9]);
                    int BetD_ManuallyOverrideAdv = Convert.ToInt32(Valores[10]);
                    float BetD_AdvStrokers = Convert.ToSingle(Valores[11]);

                    SqlCommand comando = new SqlCommand("DragoGolf_CreateDetailBet");
                    comando.CommandType = CommandType.StoredProcedure;

                    //Declaracion de parametros
                    comando.Parameters.Add("@IDBet", SqlDbType.Int);
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
                    comando.Parameters.Add("@BetD_AdvStrokers", SqlDbType.Float);

                    //Asignacion de valores a parametros
                    comando.Parameters["@IDBet"].Value = IDBet;
                    comando.Parameters["@IDRonda"].Value = IDRonda;
                    comando.Parameters["@BetD_Player1"].Value = BetD_Player1;
                    comando.Parameters["@BetD_Player2"].Value = BetD_Player2;
                    comando.Parameters["@BetD_MontoF9"].Value = BetD_MontoF9;
                    comando.Parameters["@BetD_MontoB9"].Value = BetD_MontoB9;
                    comando.Parameters["@BetD_Match"].Value = BetD_Match;
                    comando.Parameters["@BetD_Carry"].Value = BetD_Carry;
                    comando.Parameters["@BetD_Medal"].Value = BetD_Medal;
                    comando.Parameters["@BetD_AutoPress"].Value = BetD_AutoPress;
                    comando.Parameters["@BetD_ManuallyOverrideAdv"].Value = BetD_ManuallyOverrideAdv;
                    comando.Parameters["@BetD_AdvStrokers"].Value = BetD_AdvStrokers;


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
                    estatus = 1
                });

                return Resultado;
          

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
