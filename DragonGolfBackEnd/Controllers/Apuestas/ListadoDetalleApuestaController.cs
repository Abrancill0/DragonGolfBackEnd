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
    [RoutePrefix("api/ListadoDetalleApuesta")]
    public class ListadoDetalleApuestaController : ApiController
    {

        public class ParametrosEntrada
        {
            public int IDBet { get; set; }
            public int IDRonda { get; set; }
            public int IDBetDetail { get; set; }
        }


        public class ParametrosSalida
        {
            public int IDBet { get; set; }
            public int IDRonda { get; set; }
            public int BetD_Player1 { get; set; }
            public int BetD_Player2 { get; set; }
            public float BetD_MontoF9 { get; set; }
            public float BetD_MontoB9 { get; set; }
            public float BetD_MachMonto { get; set; }
            public int BetD_DiferenciaHoyos { get; set; }
            public float BetD_MontoPerdidoGanado { get; set; }
            public float BetD_MontoApuestaMedal { get; set; }
            public float BetD_Division { get; set; }
            public float BetD_Match { get; set; }
            public float BetD_Carry { get; set; }
            public float BetD_Medal { get; set; }
            public bool BetD_AutoPress { get; set; }
            public int BetD_ManuallyOverrideAdv { get; set; }
            public int BetD_AdvStrokers { get; set; }
            public int BetD_F9_1 { get; set; }
            public int BetD_F9_2 { get; set; }
            public int BetD_F9_3 { get; set; }
            public int BetD_F9_4 { get; set; }
            public int BetD_F9_5 { get; set; }
            public int BetD_F9_6 { get; set; }
            public int BetD_F9_7 { get; set; }
            public int BetD_F9_8 { get; set; }
            public int BetD_F9_9 { get; set; }
            public int BetD_B9_1 { get; set; }
            public int BetD_B9_2 { get; set; }
            public int BetD_B9_3 { get; set; }
            public int BetD_B9_4 { get; set; }
            public int BetD_B9_5 { get; set; }
            public int BetD_B9_6 { get; set; }
            public int BetD_B9_7 { get; set; }
            public int BetD_B9_8 { get; set; }
            public int BetD_B9_9 { get; set; }

        }


        public JObject Post(ParametrosEntrada Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListDetailBet");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@IDBet", SqlDbType.Int);
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);
                comando.Parameters.Add("@IDBetDetail", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDBet"].Value = Datos.IDBet;
                comando.Parameters["@IDRonda"].Value = Datos.IDRonda;
                comando.Parameters["@IDBetDetail"].Value = Datos.IDBetDetail;

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
                                IDBet = Convert.ToInt32(row["IDBet"]),
                                IDRonda = Convert.ToInt32(row["IDRonda"]),
                                BetD_Player1 = Convert.ToInt32(row["BetD_Player1"]),
                                BetD_Player2 = Convert.ToInt32(row["BetD_Player2"]),
                                BetD_MontoF9 = Convert.ToSingle(row["BetD_MontoF9"]),
                                BetD_MontoB9 = Convert.ToSingle(row["BetD_MontoB9"]),
                                BetD_DiferenciaHoyos = Convert.ToInt32(row["BetD_DiferenciaHoyos"]),
                                BetD_MontoPerdidoGanado = Convert.ToSingle(row["BetD_MontoPerdidoGanado"]),
                                BetD_MontoApuestaMedal = Convert.ToSingle(row["BetD_MontoApuestaMedal"]),
                                BetD_Division = Convert.ToSingle(row["BetD_Division"]),
                                BetD_MachMonto = Convert.ToSingle(row["BetD_Division"]),
                                BetD_Match = Convert.ToSingle(row["BetD_Division"]),
                                BetD_Carry = Convert.ToSingle(row["BetD_Division"]),
                                BetD_Medal = Convert.ToSingle(row["BetD_Division"]),
                                BetD_AutoPress = Convert.ToBoolean(row["BetD_Division"]),
                                BetD_ManuallyOverrideAdv = Convert.ToInt32(row["BetD_Division"]),
                                BetD_AdvStrokers = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_1 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_2 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_3 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_4 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_5 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_6 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_7 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_8 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_F9_9 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_1 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_2 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_3 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_4 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_5 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_6 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_7 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_8 = Convert.ToInt32(row["BetD_Division"]),
                                BetD_B9_9 = Convert.ToInt32(row["BetD_Division"]),

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
