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
            public int IDUsuario { get; set; }

        }

        public class ParametrosSalida
        {
            public int IDBet { get; set; }
            public int IDBetDetail { get; set; }
            public int IDRonda { get; set; }
            public string Player1 { get; set; }
            public string Player2 { get; set; }
            public int BetD_Player1 { get; set; }
            public int BetD_Player2 { get; set; }
            public float BetD_MontoF9 { get; set; }
            public float BetD_MontoB9 { get; set; }
            public float BetD_MontoCalculoF9 { get; set; }
            public float BetD_MontoCalculoB9 { get; set; }
             public float BetD_MachMonto { get; set; }
            public int BetD_DiferenciaHoyos { get; set; }
            public float BetD_MontoPerdidoGanado { get; set; }
            public float BetD_MontoApuestaMedal { get; set; }
            public float BetD_Division { get; set; }
            public float BetD_Match { get; set; }
            public float BetD_Carry { get; set; }
            public float BetD_CarryCalculado { get; set; }
            public float BetD_Medal { get; set; }
            public int BetD_AutoPress { get; set; }
            public int BetD_ManuallyOverrideAdv { get; set; }
            public double BetD_AdvStrokers { get; set; }
            public string BetD_F9_1 { get; set; }
            public string BetD_F9_2 { get; set; }
            public string BetD_F9_3 { get; set; }
            public string BetD_F9_4 { get; set; }
            public string BetD_F9_5 { get; set; }
            public string BetD_F9_6 { get; set; }
            public string BetD_F9_7 { get; set; }
            public string BetD_F9_8 { get; set; }
            public string BetD_F9_9 { get; set; }
            public string BetD_B9_1 { get; set; }
            public string BetD_B9_2 { get; set; }
            public string BetD_B9_3 { get; set; }
            public string BetD_B9_4 { get; set; }
            public string BetD_B9_5 { get; set; }
            public string BetD_B9_6 { get; set; }
            public string BetD_B9_7 { get; set; }
            public string BetD_B9_8 { get; set; }
            public string BetD_B9_9 { get; set; }
            public double BetD_MedalInt { get; set; }
            public int BetD_MachInt { get; set; }
            public int ConsecutivosApuesta { get; set; }

        }


        public JObject Post(ParametrosEntrada Datos)
        {
            try
            {
                //DragoGolf_ListDetailBet_Lite
                SqlCommand comandoLite = new SqlCommand("DragoGolf_ListDetailBet_Lite");
                comandoLite.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comandoLite.Parameters.Add("@IDBet", SqlDbType.Int);
                comandoLite.Parameters.Add("@IDRonda", SqlDbType.Int);
                comandoLite.Parameters.Add("@IDUsuario", SqlDbType.Int);

                //Asignacion de valores a parametros
                comandoLite.Parameters["@IDBet"].Value = Datos.IDBet;
                comandoLite.Parameters["@IDRonda"].Value = Datos.IDRonda;
                comandoLite.Parameters["@IDUsuario"].Value = Datos.IDUsuario;

                comandoLite.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comandoLite.CommandTimeout = 0;
                comandoLite.Connection.Open();

                DataTable DT1 = new DataTable();
                SqlDataAdapter DA1 = new SqlDataAdapter(comandoLite);
                comandoLite.Connection.Close();
                DA1.Fill(DT1);

                string MensajeL = "";
                int EstatusL = 0;

                if (DT1.Rows.Count > 0)
                {
                    foreach (DataRow row in DT1.Rows)
                    {
                        MensajeL = Convert.ToString(row["mensaje"]);
                        EstatusL = Convert.ToInt32(row["Estatus"]);

                        if (EstatusL == 1)
                        {

                            Calculo(Convert.ToInt32(row["IDBet"]), Convert.ToInt32(row["IDRonda"]), Convert.ToInt32(row["IDBetDetail"]));

                                                  }
                    }

                    SqlCommand comando = new SqlCommand("DragoGolf_ListDetailBet");
                    comando.CommandType = CommandType.StoredProcedure;
                    //Declaracion de parametros
                    comando.Parameters.Add("@IDBet", SqlDbType.Int);
                    comando.Parameters.Add("@IDRonda", SqlDbType.Int);
                    comando.Parameters.Add("@IDUsuario", SqlDbType.Int);


                    //Asignacion de valores a parametros
                    comando.Parameters["@IDBet"].Value = Datos.IDBet;
                    comando.Parameters["@IDRonda"].Value = Datos.IDRonda;
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

                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {
                         
                                ParametrosSalida ent = new ParametrosSalida
                                {
                                    IDBet = Convert.ToInt32(row["IDBet"]),
                                    IDBetDetail = Convert.ToInt32(row["IDBetDetail"]),
                                    IDRonda = Convert.ToInt32(row["IDRonda"]),
                                    Player1 = Convert.ToString(row["Player1"]),
                                    Player2 = Convert.ToString(row["Player2"]),
                                    BetD_Player1 = Convert.ToInt32(row["BetD_Player1"]),
                                    BetD_Player2 = Convert.ToInt32(row["BetD_Player2"]),
                                    BetD_MontoF9 = Convert.ToSingle(row["BetD_MontoF9"]),
                                    BetD_MontoB9 = Convert.ToSingle(row["BetD_MontoB9"]),
                                    BetD_MontoCalculoF9 = Convert.ToSingle(row["BetD_MontoCalculoF9"]),
                                    BetD_MontoCalculoB9 = Convert.ToSingle(row["BetD_MontoCalculoB9"]),
                                    BetD_DiferenciaHoyos = Convert.ToInt32(row["BetD_DiferenciaHoyos"]),
                                    BetD_MontoPerdidoGanado = Convert.ToSingle(row["BetD_MontoPerdidoGanado"]),
                                    BetD_MontoApuestaMedal = Convert.ToSingle(row["BetD_MontoApuestaMedal"]),
                                    BetD_Division = Convert.ToSingle(row["BetD_Division"]),
                                    BetD_MachMonto = Convert.ToSingle(row["BetD_MachMonto"]),
                                    BetD_Match = Convert.ToSingle(row["BetD_Match"]),
                                    BetD_Carry = Convert.ToSingle(row["BetD_Carry"]),
                                    BetD_CarryCalculado = Convert.ToSingle(row["BetD_CarryCalculado"]),
                                    BetD_Medal = Convert.ToSingle(row["BetD_Medal"]),
                                    BetD_AutoPress = Convert.ToInt32(row["BetD_AutoPress"]),
                                    BetD_ManuallyOverrideAdv = Convert.ToInt32(row["BetD_ManuallyOverrideAdv"]),
                                    BetD_AdvStrokers = Convert.ToDouble(row["BetD_AdvStrokers"]),
                                    BetD_F9_1 = Convert.ToString(row["BetD_F9_1"]),
                                    BetD_F9_2 = Convert.ToString(row["BetD_F9_2"]),
                                    BetD_F9_3 = Convert.ToString(row["BetD_F9_3"]),
                                    BetD_F9_4 = Convert.ToString(row["BetD_F9_4"]),
                                    BetD_F9_5 = Convert.ToString(row["BetD_F9_5"]),
                                    BetD_F9_6 = Convert.ToString(row["BetD_F9_6"]),
                                    BetD_F9_7 = Convert.ToString(row["BetD_F9_7"]),
                                    BetD_F9_8 = Convert.ToString(row["BetD_F9_8"]),
                                    BetD_F9_9 = Convert.ToString(row["BetD_F9_9"]),
                                    BetD_B9_1 = Convert.ToString(row["BetD_B9_1"]),
                                    BetD_B9_2 = Convert.ToString(row["BetD_B9_2"]),
                                    BetD_B9_3 = Convert.ToString(row["BetD_B9_3"]),
                                    BetD_B9_4 = Convert.ToString(row["BetD_B9_4"]),
                                    BetD_B9_5 = Convert.ToString(row["BetD_B9_5"]),
                                    BetD_B9_6 = Convert.ToString(row["BetD_B9_6"]),
                                    BetD_B9_7 = Convert.ToString(row["BetD_B9_7"]),
                                    BetD_B9_8 = Convert.ToString(row["BetD_B9_8"]),
                                    BetD_B9_9 = Convert.ToString(row["BetD_B9_9"]),
                                    BetD_MedalInt = Convert.ToDouble(row["BetD_MedalInt"]),
                                    BetD_MachInt = Convert.ToInt32(row["BetD_MachInt"]),
                                    ConsecutivosApuesta = Convert.ToInt32(row["ConsecutivosApuesta"]),
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
                        mensaje = "",
                        estatus = 0,
                    });

                    return Resultado;
                }

            }
            catch (Exception ex)
            {

                JObject Resultado1 = JObject.FromObject(new
                {
                    mensaje = ex.ToString(),
                    estatus = 0,

                });

                return Resultado1; //JsonConvert.SerializeObject(lista);
            }
        }


        #region
        public class ParametrosEntradaF
        {
            public int IDBet { get; set; }
            public int IDRonda { get; set; }
            public int IDBetDetail { get; set; }
        }

        public class ParametrosSalidaF
        {
            public int ScoreHole1_P1 { get; set; }
            public int ScoreHole2_P1 { get; set; }
            public int ScoreHole3_P1 { get; set; }
            public int ScoreHole4_P1 { get; set; }
            public int ScoreHole5_P1 { get; set; }
            public int ScoreHole6_P1 { get; set; }
            public int ScoreHole7_P1 { get; set; }
            public int ScoreHole8_P1 { get; set; }
            public int ScoreHole9_P1 { get; set; }
            public int ScoreHole10_P1 { get; set; }
            public int ScoreHole11_P1 { get; set; }
            public int ScoreHole12_P1 { get; set; }
            public int ScoreHole13_P1 { get; set; }
            public int ScoreHole14_P1 { get; set; }
            public int ScoreHole15_P1 { get; set; }
            public int ScoreHole16_P1 { get; set; }
            public int ScoreHole17_P1 { get; set; }
            public int ScoreHole18_P1 { get; set; }
            public int ScoreHole1_P2 { get; set; }
            public int ScoreHole2_P2 { get; set; }
            public int ScoreHole3_P2 { get; set; }
            public int ScoreHole4_P2 { get; set; }
            public int ScoreHole5_P2 { get; set; }
            public int ScoreHole6_P2 { get; set; }
            public int ScoreHole7_P2 { get; set; }
            public int ScoreHole8_P2 { get; set; }
            public int ScoreHole9_P2 { get; set; }
            public int ScoreHole10_P2 { get; set; }
            public int ScoreHole11_P2 { get; set; }
            public int ScoreHole12_P2 { get; set; }
            public int ScoreHole13_P2 { get; set; }
            public int ScoreHole14_P2 { get; set; }
            public int ScoreHole15_P2 { get; set; }
            public int ScoreHole16_P2 { get; set; }
            public int ScoreHole17_P2 { get; set; }
            public int ScoreHole18_P2 { get; set; }
            public int PlayerID1 { get; set; }
            public int PlayerID2 { get; set; }
            public int AutoPress { get; set; }
        }

        public int Calculo(int IDBet, int IDRonda, int IDBetDetail)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_CalculateBet");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDBet", SqlDbType.Int);
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);
                comando.Parameters.Add("@IDBetDetail", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDBet"].Value = IDBet;
                comando.Parameters["@IDRonda"].Value = IDRonda;
                comando.Parameters["@IDBetDetail"].Value = IDBetDetail;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);

                string Mensaje = "";
                int Estatus = 0;

                double ScoreHole1_P1 = 0;
                double ScoreHole2_P1 = 0;
                double ScoreHole3_P1 = 0;
                double ScoreHole4_P1 = 0;
                double ScoreHole5_P1 = 0;
                double ScoreHole6_P1 = 0;
                double ScoreHole7_P1 = 0;
                double ScoreHole8_P1 = 0;
                double ScoreHole9_P1 = 0;
                double ScoreHole10_P1 = 0;
                double ScoreHole11_P1 = 0;
                double ScoreHole12_P1 = 0;
                double ScoreHole13_P1 = 0;
                double ScoreHole14_P1 = 0;
                double ScoreHole15_P1 = 0;
                double ScoreHole16_P1 = 0;
                double ScoreHole17_P1 = 0;
                double ScoreHole18_P1 = 0;
                double ScoreHole1_P2 = 0;
                double ScoreHole2_P2 = 0;
                double ScoreHole3_P2 = 0;
                double ScoreHole4_P2 = 0;
                double ScoreHole5_P2 = 0;
                double ScoreHole6_P2 = 0;
                double ScoreHole7_P2 = 0;
                double ScoreHole8_P2 = 0;
                double ScoreHole9_P2 = 0;
                double ScoreHole10_P2 = 0;
                double ScoreHole11_P2 = 0;
                double ScoreHole12_P2 = 0;
                double ScoreHole13_P2 = 0;
                double ScoreHole14_P2 = 0;
                double ScoreHole15_P2 = 0;
                double ScoreHole16_P2 = 0;
                double ScoreHole17_P2 = 0;
                double ScoreHole18_P2 = 0;
                int PlayerID1 = 0;
                int PlayerID2 = 0;
                int AutoPress = 0;
                int DificultatHoyo1 = 0;
                int DificultatHoyo2 = 0;
                int DificultatHoyo3 = 0;
                int DificultatHoyo4 = 0;
                int DificultatHoyo5 = 0;
                int DificultatHoyo6 = 0;
                int DificultatHoyo7 = 0;
                int DificultatHoyo8 = 0;
                int DificultatHoyo9 = 0;
                int DificultatHoyo10 = 0;
                int DificultatHoyo11 = 0;
                int DificultatHoyo12 = 0;
                int DificultatHoyo13 = 0;
                int DificultatHoyo14 = 0;
                int DificultatHoyo15 = 0;
                int DificultatHoyo16 = 0;
                int DificultatHoyo17 = 0;
                int DificultatHoyo18 = 0;
                int HoyoInicial = 0;
                double Adv = 0;

                string[] ResultFront = new string[9];
                string[] ResultBack = new string[9];

                int contador = DT.Rows.Count;

                int Ro_Cambio = 0;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
                        HoyoInicial = Convert.ToInt32(row["HoyoInicial"]);

                        bool InicioPartida1 = Convert.ToBoolean(row["InicioPartida1"]);
                        bool InicioPartida2 = Convert.ToBoolean(row["InicioPartida2"]);

                        Ro_Cambio = Convert.ToInt32(row["Ro_Cambio"]);

                        if (InicioPartida1 == false && InicioPartida2 == false)
                        {

                            return 0;
                        }

                        ScoreHole1_P1 = Convert.ToDouble(row["ScoreHole1_P1"]);
                        ScoreHole2_P1 = Convert.ToDouble(row["ScoreHole2_P1"]);
                        ScoreHole3_P1 = Convert.ToDouble(row["ScoreHole3_P1"]);
                        ScoreHole4_P1 = Convert.ToDouble(row["ScoreHole4_P1"]);
                        ScoreHole5_P1 = Convert.ToDouble(row["ScoreHole5_P1"]);
                        ScoreHole6_P1 = Convert.ToDouble(row["ScoreHole6_P1"]);
                        ScoreHole7_P1 = Convert.ToDouble(row["ScoreHole7_P1"]);
                        ScoreHole8_P1 = Convert.ToDouble(row["ScoreHole8_P1"]);
                        ScoreHole9_P1 = Convert.ToDouble(row["ScoreHole9_P1"]);
                        ScoreHole10_P1 = Convert.ToDouble(row["ScoreHole10_P1"]);
                        ScoreHole11_P1 = Convert.ToDouble(row["ScoreHole11_P1"]);
                        ScoreHole12_P1 = Convert.ToDouble(row["ScoreHole12_P1"]);
                        ScoreHole13_P1 = Convert.ToDouble(row["ScoreHole13_P1"]);
                        ScoreHole14_P1 = Convert.ToDouble(row["ScoreHole14_P1"]);
                        ScoreHole15_P1 = Convert.ToDouble(row["ScoreHole15_P1"]);
                        ScoreHole16_P1 = Convert.ToDouble(row["ScoreHole16_P1"]);
                        ScoreHole17_P1 = Convert.ToDouble(row["ScoreHole17_P1"]);
                        ScoreHole18_P1 = Convert.ToDouble(row["ScoreHole18_P1"]);
                        ScoreHole1_P2 = Convert.ToDouble(row["ScoreHole1_P2"]);
                        ScoreHole2_P2 = Convert.ToDouble(row["ScoreHole2_P2"]);
                        ScoreHole3_P2 = Convert.ToDouble(row["ScoreHole3_P2"]);
                        ScoreHole4_P2 = Convert.ToDouble(row["ScoreHole4_P2"]);
                        ScoreHole5_P2 = Convert.ToDouble(row["ScoreHole5_P2"]);
                        ScoreHole6_P2 = Convert.ToDouble(row["ScoreHole6_P2"]);
                        ScoreHole7_P2 = Convert.ToDouble(row["ScoreHole7_P2"]);
                        ScoreHole8_P2 = Convert.ToDouble(row["ScoreHole8_P2"]);
                        ScoreHole9_P2 = Convert.ToDouble(row["ScoreHole9_P2"]);
                        ScoreHole10_P2 = Convert.ToDouble(row["ScoreHole10_P2"]);
                        ScoreHole11_P2 = Convert.ToDouble(row["ScoreHole11_P2"]);
                        ScoreHole12_P2 = Convert.ToDouble(row["ScoreHole12_P2"]);
                        ScoreHole13_P2 = Convert.ToDouble(row["ScoreHole13_P2"]);
                        ScoreHole14_P2 = Convert.ToDouble(row["ScoreHole14_P2"]);
                        ScoreHole15_P2 = Convert.ToDouble(row["ScoreHole15_P2"]);
                        ScoreHole16_P2 = Convert.ToDouble(row["ScoreHole16_P2"]);
                        ScoreHole17_P2 = Convert.ToDouble(row["ScoreHole17_P2"]);
                        ScoreHole18_P2 = Convert.ToDouble(row["ScoreHole18_P2"]);

                        PlayerID1 = Convert.ToInt32(row["PlayerID1"]);
                        PlayerID2 = Convert.ToInt32(row["PlayerID2"]);
                        AutoPress = Convert.ToInt32(row["AutoPress"]);
                        Adv = Convert.ToDouble(row["Adv"]);

                            DificultatHoyo1 = Convert.ToInt32(row["DificultatHoyo1"]);//7
                            DificultatHoyo2 = Convert.ToInt32(row["DificultatHoyo2"]);//1
                            DificultatHoyo3 = Convert.ToInt32(row["DificultatHoyo3"]);//8
                            DificultatHoyo4 = Convert.ToInt32(row["DificultatHoyo4"]);//5
                            DificultatHoyo5 = Convert.ToInt32(row["DificultatHoyo5"]);//2
                            DificultatHoyo6 = Convert.ToInt32(row["DificultatHoyo6"]);//6
                            DificultatHoyo7 = Convert.ToInt32(row["DificultatHoyo7"]);//4
                            DificultatHoyo8 = Convert.ToInt32(row["DificultatHoyo8"]);//3
                            DificultatHoyo9 = Convert.ToInt32(row["DificultatHoyo9"]);//9
                            DificultatHoyo10 = Convert.ToInt32(row["DificultatHoyo10"]);//10
                            DificultatHoyo11 = Convert.ToInt32(row["DificultatHoyo11"]);//11
                            DificultatHoyo12 = Convert.ToInt32(row["DificultatHoyo12"]);//14
                            DificultatHoyo13 = Convert.ToInt32(row["DificultatHoyo13"]);//15
                            DificultatHoyo14 = Convert.ToInt32(row["DificultatHoyo14"]);//13
                            DificultatHoyo15 = Convert.ToInt32(row["DificultatHoyo15"]);//16
                            DificultatHoyo16 = Convert.ToInt32(row["DificultatHoyo16"]);//17
                            DificultatHoyo17 = Convert.ToInt32(row["DificultatHoyo17"]);//18
                            DificultatHoyo18 = Convert.ToInt32(row["DificultatHoyo18"]);//12


                        if (Ro_Cambio == 1 && HoyoInicial > 1)
                        {
                            DificultatHoyo1 =  DificultatHoyo1 + 1;
                            DificultatHoyo2 = DificultatHoyo2 + 1;
                            DificultatHoyo3 = DificultatHoyo3 + 1;
                            DificultatHoyo4 = DificultatHoyo4 + 1;
                            DificultatHoyo5 = DificultatHoyo5 + 1;
                            DificultatHoyo6 = DificultatHoyo6 + 1;
                            DificultatHoyo7 = DificultatHoyo7 + 1;
                            DificultatHoyo8 = DificultatHoyo8 + 1;
                            DificultatHoyo9 = DificultatHoyo9 + 1;
                            DificultatHoyo10 = DificultatHoyo10 - 1;
                            DificultatHoyo11 = DificultatHoyo11 - 1;
                            DificultatHoyo12 = DificultatHoyo12 - 1;
                            DificultatHoyo13 = DificultatHoyo13 - 1;
                            DificultatHoyo14 = DificultatHoyo14 - 1;
                            DificultatHoyo15 = DificultatHoyo15 - 1;
                            DificultatHoyo16 = DificultatHoyo16 - 1;
                            DificultatHoyo17 = DificultatHoyo17 - 1;
                            DificultatHoyo18 = DificultatHoyo18 - 1;
                        }
                       

                        int Contador = 0;

                        int AdvInverso = (-1) * (Convert.ToInt32(Adv));
                        int AdvInverso2 = 0; //(-1) * (Adv);

                        if (Adv > 0)
                        {
                            AdvInverso2 = Convert.ToInt32(Math.Ceiling(Adv));
                            AdvInverso = (-1) * Convert.ToInt32(Math.Ceiling(Adv));
                        }
                        else if (Adv < 0)
                        {
                            AdvInverso2 = Convert.ToInt32(Math.Floor(Adv));
                            AdvInverso = (-1) * Convert.ToInt32(Math.Floor(Adv));
                        }

                        double ValCompleto = 0;

                        //if (Adv == 0.5)
                        //{
                        //    AdvInverso = 1;
                        //}
                        //else if (Adv == -0.5)
                        //{
                        //    AdvInverso = -1;
                        //}

                        if (AdvInverso < 0)
                        {

                            // double AdvPositivo2 = (-1) * (AdvInverso);
                            int AdvPositivo = (AdvInverso2);

                            if (Adv >= AdvInverso2)
                            {
                                ValCompleto = 0.5;
                            }

                            int CicloFor = 18;

                            if (AdvInverso2 > 18)
                            {
                                CicloFor = AdvInverso2;
                            }

                            for (int i = 0; i < CicloFor; i++)
                            {
                                Contador += 1;

                                if (Contador > 18)
                                {
                                    Contador = 1;
                                    AdvPositivo = AdvPositivo - 18;
                                }

                                if (Contador <= AdvPositivo)
                                {

                                    if (DificultatHoyo1 == Contador)
                                    {
                                        if (ScoreHole1_P1 > 0 && ScoreHole1_P2 > 0)
                                        {
                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole1_P1 = ScoreHole1_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole1_P1 = ScoreHole1_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo2 == Contador)
                                    {
                                        if (ScoreHole2_P1 > 0 && ScoreHole2_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole2_P1 = ScoreHole2_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole2_P1 = ScoreHole2_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo3 == Contador)
                                    {
                                        if (ScoreHole3_P1 > 0 && ScoreHole3_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole3_P1 = ScoreHole3_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole3_P1 = ScoreHole3_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo4 == Contador)
                                    {
                                        if (ScoreHole4_P1 > 0 && ScoreHole4_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole4_P1 = ScoreHole4_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole4_P1 = ScoreHole4_P1 - 1;

                                            }
                                        }

                                    }

                                    if (DificultatHoyo5 == Contador)
                                    {
                                        if (ScoreHole5_P1 > 0 && ScoreHole5_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole5_P1 = ScoreHole5_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole5_P1 = ScoreHole5_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo6 == Contador)
                                    {
                                        if (ScoreHole6_P1 > 0 && ScoreHole6_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole6_P1 = ScoreHole6_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole6_P1 = ScoreHole6_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo7 == Contador)
                                    {
                                        if (ScoreHole7_P1 > 0 && ScoreHole7_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole7_P1 = ScoreHole7_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole7_P1 = ScoreHole7_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo8 == Contador)
                                    {
                                        if (ScoreHole8_P1 > 0 && ScoreHole8_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole8_P1 = ScoreHole8_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole8_P1 = ScoreHole8_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo9 == Contador)
                                    {
                                        if (ScoreHole9_P1 > 0 && ScoreHole9_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole9_P1 = ScoreHole9_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole9_P1 = ScoreHole9_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo10 == Contador)
                                    {
                                        if (ScoreHole10_P1 > 0 && ScoreHole10_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole10_P1 = ScoreHole10_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole10_P1 = ScoreHole10_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo11 == Contador)
                                    {
                                        if (ScoreHole11_P1 > 0 && ScoreHole11_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole11_P1 = ScoreHole11_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole11_P1 = ScoreHole11_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo12 == Contador)
                                    {
                                        if (ScoreHole12_P1 > 0 && ScoreHole12_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole12_P1 = ScoreHole12_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {

                                                ScoreHole12_P1 = ScoreHole12_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo13 == Contador)
                                    {
                                        if (ScoreHole13_P1 > 0 && ScoreHole13_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole13_P1 = ScoreHole13_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole13_P1 = ScoreHole13_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo14 == Contador)
                                    {
                                        if (ScoreHole14_P1 > 0 && ScoreHole14_P2 > 0)
                                        {


                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole14_P1 = ScoreHole14_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole14_P1 = ScoreHole14_P1 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo15 == Contador)
                                    {
                                        if (ScoreHole15_P1 > 0 && ScoreHole15_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole15_P1 = ScoreHole15_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole15_P1 = ScoreHole15_P1 - 1;
                                            }
                                        }
                                    }

                                    if (DificultatHoyo16 == Contador)
                                    {
                                        if (ScoreHole16_P1 > 0 && ScoreHole16_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole16_P1 = ScoreHole16_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole16_P1 = ScoreHole16_P1 - 1;
                                            }
                                        }
                                    }

                                    if (DificultatHoyo17 == Contador)
                                    {
                                        if (ScoreHole17_P1 > 0 && ScoreHole17_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole17_P1 = ScoreHole17_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole17_P1 = ScoreHole17_P1 - 1;
                                            }
                                        }
                                    }

                                    if (DificultatHoyo18 == Contador)
                                    {
                                        if (ScoreHole18_P1 > 0 && ScoreHole18_P2 > 0)
                                        {

                                            if (Contador == AdvPositivo)
                                            {
                                                ScoreHole18_P1 = ScoreHole18_P1 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole18_P1 = ScoreHole18_P1 - 1;
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    break;
                                }

                            }

                        }
                        else if (AdvInverso > 0)
                        {
                            double AdvPositivo = (-1) * (Adv);
                            int AdvPositivo2 = (-1) * (AdvInverso2);

                            if (AdvPositivo >= AdvPositivo2)
                            {
                                ValCompleto = 0.5;
                            }

                            int CicloFor = 18;

                            if (AdvInverso > 18)
                            {
                                CicloFor = AdvInverso;
                            }

                            for (int i = 0; i < CicloFor; i++)
                            {
                                Contador += 1;

                                if (Contador > 18)
                                {
                                    Contador = 1;
                                    AdvInverso = AdvInverso - 18;
                                }

                                if (Contador <= AdvInverso)
                                {

                                    if (DificultatHoyo1 == Contador)
                                    {

                                        if (ScoreHole1_P2 > 0 && ScoreHole1_P1 > 0)
                                        {

                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole1_P2 = ScoreHole1_P2 - ((0.5 + ValCompleto));
                                            }
                                            else
                                            {
                                                ScoreHole1_P2 = ScoreHole1_P2 - 1;
                                            }
                                        }


                                    }

                                    if (DificultatHoyo2 == Contador)
                                    {
                                        if (ScoreHole2_P2 > 0 && ScoreHole2_P1 > 0)
                                        {

                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole2_P2 = ScoreHole2_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole2_P2 = ScoreHole2_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo3 == Contador)
                                    {
                                        if (ScoreHole3_P2 > 0 && ScoreHole3_P1 > 0)
                                        {

                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole3_P2 = ScoreHole3_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole3_P2 = ScoreHole3_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo4 == Contador)
                                    {
                                        if (ScoreHole4_P2 > 0 && ScoreHole4_P1 > 0)
                                        {

                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole4_P2 = ScoreHole4_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole4_P2 = ScoreHole4_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo5 == Contador)
                                    {
                                        if (ScoreHole5_P2 > 0 && ScoreHole5_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole5_P2 = ScoreHole5_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole5_P2 = ScoreHole5_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo6 == Contador)
                                    {
                                        if (ScoreHole6_P2 > 0 && ScoreHole6_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole6_P2 = ScoreHole6_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole6_P2 = ScoreHole6_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo7 == Contador)
                                    {
                                        if (ScoreHole7_P2 > 0 && ScoreHole7_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole7_P2 = ScoreHole7_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole7_P2 = ScoreHole7_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo8 == Contador)
                                    {
                                        if (ScoreHole8_P2 > 0 && ScoreHole8_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole8_P2 = ScoreHole8_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole8_P2 = ScoreHole8_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo9 == Contador)
                                    {
                                        if (ScoreHole9_P2 > 0 && ScoreHole9_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole9_P2 = ScoreHole9_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole9_P2 = ScoreHole9_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo10 == Contador)
                                    {
                                        if (ScoreHole10_P2 > 0 && ScoreHole10_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole10_P2 = ScoreHole10_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole10_P2 = ScoreHole10_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo11 == Contador)
                                    {
                                        if (ScoreHole11_P2 > 0 && ScoreHole11_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole11_P2 = ScoreHole11_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole11_P2 = ScoreHole11_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo12 == Contador)
                                    {
                                        if (ScoreHole12_P2 > 0 && ScoreHole12_P1 > 0)
                                        {

                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole12_P2 = ScoreHole12_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {

                                                ScoreHole12_P2 = ScoreHole12_P2 - 1;

                                            }
                                        }

                                    }

                                    if (DificultatHoyo13 == Contador)
                                    {
                                        if (ScoreHole13_P2 > 0 && ScoreHole13_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole13_P2 = ScoreHole13_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole13_P2 = ScoreHole13_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo14 == Contador)
                                    {
                                        if (ScoreHole14_P2 > 0 && ScoreHole14_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole14_P2 = ScoreHole14_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole14_P2 = ScoreHole14_P2 - 1;

                                            }
                                        }

                                    }

                                    if (DificultatHoyo15 == Contador)
                                    {
                                        if (ScoreHole15_P2 > 0 && ScoreHole15_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole15_P2 = ScoreHole15_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole15_P2 = ScoreHole15_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo16 == Contador)
                                    {
                                        if (ScoreHole16_P2 > 0 && ScoreHole16_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole16_P2 = ScoreHole16_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole16_P2 = ScoreHole16_P2 - 1;
                                            }
                                        }

                                    }

                                    if (DificultatHoyo17 == Contador)
                                    {
                                        if (ScoreHole17_P2 > 0 && ScoreHole17_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole17_P2 = ScoreHole17_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole17_P2 = ScoreHole17_P2 - 1;

                                            }
                                        }

                                    }

                                    if (DificultatHoyo18 == Contador)
                                    {
                                        if (ScoreHole18_P2 > 0 && ScoreHole18_P1 > 0)
                                        {


                                            if (Contador == AdvInverso)
                                            {
                                                ScoreHole18_P2 = ScoreHole18_P2 - (0.5 + ValCompleto);
                                            }
                                            else
                                            {
                                                ScoreHole18_P2 = ScoreHole18_P2 - 1;
                                            }
                                        }

                                    }

                                }
                                else
                                {
                                    break;
                                }

                            }

                        }

                        //Cambio de hoyo
                        double[] CambioHoyos = new double[38];

                        CambioHoyos = HoyoInicialCambioF(ScoreHole1_P1, ScoreHole2_P1, ScoreHole3_P1, ScoreHole4_P1, ScoreHole5_P1, ScoreHole6_P1, ScoreHole7_P1, ScoreHole8_P1, ScoreHole9_P1, ScoreHole10_P1, ScoreHole11_P1, ScoreHole12_P1, ScoreHole13_P1, ScoreHole14_P1, ScoreHole15_P1, ScoreHole16_P1, ScoreHole17_P1, ScoreHole18_P1,
                            ScoreHole1_P2, ScoreHole2_P2, ScoreHole3_P2, ScoreHole4_P2, ScoreHole5_P2, ScoreHole6_P2, ScoreHole7_P2, ScoreHole8_P2, ScoreHole9_P2, ScoreHole10_P2, ScoreHole11_P2, ScoreHole12_P2, ScoreHole13_P2, ScoreHole14_P2, ScoreHole15_P2, ScoreHole16_P2, ScoreHole17_P2, ScoreHole18_P2, HoyoInicial);

                        ScoreHole1_P1 = CambioHoyos[1];
                        ScoreHole2_P1 = CambioHoyos[2];
                        ScoreHole3_P1 = CambioHoyos[3];
                        ScoreHole4_P1 = CambioHoyos[4];
                        ScoreHole5_P1 = CambioHoyos[5];
                        ScoreHole6_P1 = CambioHoyos[6];
                        ScoreHole7_P1 = CambioHoyos[7];
                        ScoreHole8_P1 = CambioHoyos[8];
                        ScoreHole9_P1 = CambioHoyos[9];
                        ScoreHole10_P1 = CambioHoyos[10];
                        ScoreHole11_P1 = CambioHoyos[11];
                        ScoreHole12_P1 = CambioHoyos[12];
                        ScoreHole13_P1 = CambioHoyos[13];
                        ScoreHole14_P1 = CambioHoyos[14];
                        ScoreHole15_P1 = CambioHoyos[15];
                        ScoreHole16_P1 = CambioHoyos[16];
                        ScoreHole17_P1 = CambioHoyos[17];
                        ScoreHole18_P1 = CambioHoyos[18];

                        ScoreHole1_P2 = CambioHoyos[19];
                        ScoreHole2_P2 = CambioHoyos[20];
                        ScoreHole3_P2 = CambioHoyos[21];
                        ScoreHole4_P2 = CambioHoyos[22];
                        ScoreHole5_P2 = CambioHoyos[23];
                        ScoreHole6_P2 = CambioHoyos[24];
                        ScoreHole7_P2 = CambioHoyos[25];
                        ScoreHole8_P2 = CambioHoyos[26];
                        ScoreHole9_P2 = CambioHoyos[27];
                        ScoreHole10_P2 = CambioHoyos[28];
                        ScoreHole11_P2 = CambioHoyos[29];
                        ScoreHole12_P2 = CambioHoyos[30];
                        ScoreHole13_P2 = CambioHoyos[31];
                        ScoreHole14_P2 = CambioHoyos[32];
                        ScoreHole15_P2 = CambioHoyos[33];
                        ScoreHole16_P2 = CambioHoyos[34];
                        ScoreHole17_P2 = CambioHoyos[35];
                        ScoreHole18_P2 = CambioHoyos[36];
                        //Termina cambio de hoyo

                        double Resultado1 = 0;
                        double Resultado2 = 0;
                        double Resultado3 = 0;
                        double Resultado4 = 0;
                        double Resultado5 = 0;
                        double Resultado6 = 0;
                        double Resultado7 = 0;
                        double Resultado8 = 0;
                        double Resultado9 = 0;

                        int ValidaFront = 0;

                        if (ScoreHole1_P1 > 0 && ScoreHole1_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado1 = ScoreHole1_P2 - ScoreHole1_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole2_P1 > 0 && ScoreHole2_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado2 = ScoreHole2_P2 - ScoreHole2_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole3_P1 > 0 && ScoreHole3_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado3 = ScoreHole3_P2 - ScoreHole3_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole4_P1 > 0 && ScoreHole4_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado4 = ScoreHole4_P2 - ScoreHole4_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole5_P1 > 0 && ScoreHole5_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado5 = ScoreHole5_P2 - ScoreHole5_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole6_P1 > 0 && ScoreHole6_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado6 = ScoreHole6_P2 - ScoreHole6_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole7_P1 > 0 && ScoreHole7_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado7 = ScoreHole7_P2 - ScoreHole7_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole8_P1 > 0 && ScoreHole8_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado8 = ScoreHole8_P2 - ScoreHole8_P1;
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole9_P1 > 0 && ScoreHole9_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado9 = ScoreHole9_P2 - ScoreHole9_P1;
                            }

                        }


                        //Quien Gano, no lo sabemos

                        int ContadorHoyos = 0;

                        if (Resultado1 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado1 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado2 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado2 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado3 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado3 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado4 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado4 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado5 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado5 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado6 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado6 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado7 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado7 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado8 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado8 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado9 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado9 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Calculo Medal front
                        double ResultadoTotaF1 = ScoreHole1_P1 + ScoreHole2_P1 + ScoreHole3_P1 + ScoreHole4_P1 + ScoreHole5_P1 + ScoreHole6_P1 + ScoreHole7_P1 + ScoreHole8_P1 + ScoreHole9_P1;
                        double ResultadoTotaF2 = ScoreHole1_P2 + ScoreHole2_P2 + ScoreHole3_P2 + ScoreHole4_P2 + ScoreHole5_P2 + ScoreHole6_P2 + ScoreHole7_P2 + ScoreHole8_P2 + ScoreHole9_P2;



                        bool ValidaJuegoInicio = false;

                        if ((ResultadoTotaF1 + ResultadoTotaF2) > 0)
                        {
                            ValidaJuegoInicio = false;
                        }
                        else
                        {
                            ValidaJuegoInicio = true;
                        }


                        double Resultado10 = 0;
                        double Resultado11 = 0;
                        double Resultado12 = 0;
                        double Resultado13 = 0;
                        double Resultado14 = 0;
                        double Resultado15 = 0;
                        double Resultado16 = 0;
                        double Resultado17 = 0;
                        double Resultado18 = 0;


                        int ValidaBack = 0;

                        if (ScoreHole10_P1 > 0 && ScoreHole10_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado10 = ScoreHole10_P2 - ScoreHole10_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole11_P1 > 0 && ScoreHole11_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado11 = ScoreHole11_P2 - ScoreHole11_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole12_P1 > 0 && ScoreHole12_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado12 = ScoreHole12_P2 - ScoreHole12_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole13_P1 > 0 && ScoreHole13_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado13 = ScoreHole13_P2 - ScoreHole13_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole14_P1 > 0 && ScoreHole14_P2 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                Resultado14 = ScoreHole14_P2 - ScoreHole14_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole15_P1 > 0 && ScoreHole15_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado15 = ScoreHole15_P2 - ScoreHole15_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole16_P1 > 0 && ScoreHole16_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado16 = ScoreHole16_P2 - ScoreHole16_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole17_P1 > 0 && ScoreHole17_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado17 = ScoreHole17_P2 - ScoreHole17_P1;
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole18_P1 > 0 && ScoreHole18_P2 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                Resultado18 = ScoreHole18_P2 - ScoreHole18_P1;
                            }

                        }


                        if (Resultado10 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado10 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado11 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado11 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado12 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado12 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado13 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado13 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado14 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado14 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado15 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado15 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado16 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado16 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado17 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado17 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado18 > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado18 < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }


                        //Calculo Medal front
                        double ResultadoTotaB1 = ScoreHole10_P1 + ScoreHole11_P1 + ScoreHole12_P1 + ScoreHole13_P1 + ScoreHole14_P1 + ScoreHole15_P1 + ScoreHole16_P1 + ScoreHole17_P1 + ScoreHole18_P1;
                        double ResultadoTotaB2 = ScoreHole10_P2 + ScoreHole11_P2 + ScoreHole12_P2 + ScoreHole13_P2 + ScoreHole14_P2 + ScoreHole15_P2 + ScoreHole16_P2 + ScoreHole17_P2 + ScoreHole18_P2;

                        //Valida Medal

                        int ResultadoFinalMedal = 0;

                        double GolpesTotalesJugador1 = ResultadoTotaF1 + ResultadoTotaB1;
                        double GolpesTotalesJugador2 = ResultadoTotaF2 + ResultadoTotaB2;

                        double TotalMeldal = GolpesTotalesJugador1 - GolpesTotalesJugador2;

                        if (GolpesTotalesJugador1 < GolpesTotalesJugador2)
                        {
                            ResultadoFinalMedal = 1;
                        }
                        else if (GolpesTotalesJugador1 > GolpesTotalesJugador2)
                        {
                            ResultadoFinalMedal = -1;
                        }
                        else
                        {
                            ResultadoFinalMedal = 0;
                        }

                        string BetD_F9_1 = "";
                        string BetD_F9_2 = "";
                        string BetD_F9_3 = "";
                        string BetD_F9_4 = "";
                        string BetD_F9_5 = "";
                        string BetD_F9_6 = "";
                        string BetD_F9_7 = "";
                        string BetD_F9_8 = "";
                        string BetD_F9_9 = "";
                        string BetD_B9_1 = "";
                        string BetD_B9_2 = "";
                        string BetD_B9_3 = "";
                        string BetD_B9_4 = "";
                        string BetD_B9_5 = "";
                        string BetD_B9_6 = "";
                        string BetD_B9_7 = "";
                        string BetD_B9_8 = "";
                        string BetD_B9_9 = "";


                        if (AutoPress == 1)
                        {
                            ResultFront = CalcularApuestaPresionFront1F(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                              Resultado6, Resultado7, Resultado8, Resultado9, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack1F(Resultado10, Resultado11, Resultado12, Resultado13,
                              Resultado14, Resultado15, Resultado16, Resultado17, Resultado18, ValidaJuegoInicio);

                            string[] FrontValores = ResultFront[0].Split(',');
                            string[] BackValores = ResultBack[0].Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);
                            BetD_F9_5 = Convert.ToString(FrontValores[4]);
                            BetD_F9_6 = Convert.ToString(FrontValores[5]);
                            BetD_F9_7 = Convert.ToString(FrontValores[6]);
                            BetD_F9_8 = Convert.ToString(FrontValores[7]);
                            BetD_F9_9 = Convert.ToString(FrontValores[8]);
                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_B9_3 = Convert.ToString(BackValores[2]);
                            BetD_B9_4 = Convert.ToString(BackValores[3]);
                            BetD_B9_5 = Convert.ToString(BackValores[4]);
                            BetD_B9_6 = Convert.ToString(BackValores[5]);
                            BetD_B9_7 = Convert.ToString(BackValores[6]);
                            BetD_B9_8 = Convert.ToString(BackValores[7]);
                            BetD_B9_9 = Convert.ToString(BackValores[8]);

                            ActualizarAPuestaF(IDBetDetail, IDBet, IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                            BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                            ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 1, ValidaJuegoInicio, TotalMeldal);

                        }
                        else if (AutoPress == 2)
                        {
                            ResultFront = CalcularApuestaPresionFront2F(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                                Resultado6, Resultado7, Resultado8, Resultado9, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack2F(Resultado10, Resultado11, Resultado12, Resultado13,
                                Resultado14, Resultado15, Resultado16, Resultado17, Resultado18, ValidaJuegoInicio);

                            string[] FrontValores = ResultFront[0].Split(',');
                            string[] BackValores = ResultBack[0].Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);
                            BetD_F9_5 = Convert.ToString(FrontValores[4]);
                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_B9_3 = Convert.ToString(BackValores[2]);
                            BetD_B9_4 = Convert.ToString(BackValores[3]);
                            BetD_B9_5 = Convert.ToString(BackValores[4]);

                            ActualizarAPuestaF(IDBetDetail, IDBet, IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                              BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                              ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 2, ValidaJuegoInicio, TotalMeldal);

                        }
                        else if (AutoPress == 3)
                        {
                            ResultFront = CalcularApuestaPresionFront3F(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                                Resultado6, Resultado7, Resultado8, Resultado9, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack3F(Resultado10, Resultado11, Resultado12, Resultado13,
                                Resultado14, Resultado15, Resultado16, Resultado17, Resultado18, ValidaJuegoInicio);

                            string[] FrontValores = ResultFront[0].Split(',');
                            string[] BackValores = ResultBack[0].Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);

                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_B9_3 = Convert.ToString(BackValores[2]);

                            ActualizarAPuestaF(IDBetDetail, IDBet, IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                             BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                           ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            (ResultBack[1]), ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 3, ValidaJuegoInicio, TotalMeldal);

                        }
                        else
                        {

                            ActualizarAPuestaF(IDBetDetail, IDBet, IDRonda, PlayerID1, PlayerID2, Convert.ToString(Resultado1), Convert.ToString(Resultado2), Convert.ToString(Resultado3), Convert.ToString(Resultado4), Convert.ToString(Resultado5), Convert.ToString(Resultado6),
                                            Convert.ToString(Resultado7), Convert.ToString(Resultado8), Convert.ToString(Resultado9), Convert.ToString(Resultado10), Convert.ToString(Resultado11), Convert.ToString(Resultado12), Convert.ToString(Resultado13), Convert.ToString(Resultado14), Convert.ToString(Resultado15), Convert.ToString(Resultado16), Convert.ToString(Resultado17), Convert.ToString(Resultado18), ResultadoFinalMedal, ContadorHoyos,
                                           ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 1, ValidaJuegoInicio, TotalMeldal);

                        }

                    }


                    return Estatus;
                }
                else
                {


                    return Estatus;
                }

            }
            catch (Exception ex)
            {
                return 0; //JsonConvert.SerializeObject(lista);
            }
        }

        private string[] CalcularApuestaPresionFront1F(double Resultado1, double Resultado2, double Resultado3, double Resultado4, double Resultado5, double Resultado6, double Resultado7, double Resultado8, double Resultado9, bool ValidaJuegoInicio)
        {

            int[] ResultadoPresionFront = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado1 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado1 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado2 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado2 > 0)
            {
                ResultadoPresionFront[2] = 1;
            }
            else if (Resultado2 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado3 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado3 > 0)
            {
                ResultadoPresionFront[3] = 1;
            }
            else if (Resultado3 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado4 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado4 > 0)
            {
                ResultadoPresionFront[4] = 1;
            }
            else if (Resultado4 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado5 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado5 > 0)
            {
                ResultadoPresionFront[5] = 1;
            }
            else if (Resultado5 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado6 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado6 > 0)
            {
                ResultadoPresionFront[6] = 1;
            }
            else if (Resultado6 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado7 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado7 > 0)
            {
                ResultadoPresionFront[7] = 1;
            }
            else if (Resultado7 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado8 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado8 > 0)
            {
                ResultadoPresionFront[8] = 1;
            }
            else if (Resultado8 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado9 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionFront[9] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionFront[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;
            int ResultadoInt1 = 0;
            int ResultadoInt2 = 0;
            int ResultadoInt3 = 0;
            int ResultadoInt4 = 0;
            int ResultadoInt5 = 0;
            int ResultadoInt6 = 0;
            int ResultadoInt7 = 0;
            int ResultadoInt8 = 0;


            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;

                    switch (i)
                    {
                        case 1:

                            ResultadoString = Convert.ToString(ResultadoInt) + ", 0";

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 += 1;
                            ResultadoInt2 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + ", 0";

                            break;
                        case 3:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + ", 0";

                            break;
                        case 4:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + ", 0";


                            break;
                        case 7:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 += 1;
                            ResultadoInt7 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + ", 0";



                            break;
                        case 8:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 += 1;
                            ResultadoInt7 += 1;
                            ResultadoInt8 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + ", 0";


                            break;
                        case 9:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 += 1;
                            ResultadoInt7 += 1;
                            ResultadoInt8 += 1;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8) + ", 0";


                            break;
                        default:



                            break;
                    }

                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;

                    switch (i)
                    {
                        case 1:

                            ResultadoString = Convert.ToString(ResultadoInt) + ", 0";

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + ", 0";

                            break;
                        case 3:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + ", 0";

                            break;
                        case 4:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + ", 0";


                            break;
                        case 7:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 -= 1;
                            ResultadoInt7 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + ", 0";



                            break;
                        case 8:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 -= 1;
                            ResultadoInt7 -= 1;
                            ResultadoInt8 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + ", 0";


                            break;
                        case 9:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 -= 1;
                            ResultadoInt7 -= 1;
                            ResultadoInt8 -= 1;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8) + ", 0";


                            break;
                        default:



                            break;
                    }


                }
                else
                {

                    ResultadoInt += 0;

                    switch (i)
                    {
                        case 1:

                            ResultadoString = Convert.ToString(ResultadoInt) + ", 0";

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 2:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 3:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 4:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 5:


                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 6:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 7:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 8:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 9:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);


                            break;
                        default:



                            break;
                    }


                }

            }


            string[] ResultadoFinal = new string[9];

            ResultadoFinal[0] = ResultadoString;

            ResultadoFinal[1] = ResultadoPresionFrontString[1];
            ResultadoFinal[2] = ResultadoPresionFrontString[2];
            ResultadoFinal[3] = ResultadoPresionFrontString[3];
            ResultadoFinal[4] = ResultadoPresionFrontString[4];
            ResultadoFinal[5] = ResultadoPresionFrontString[5];
            ResultadoFinal[6] = ResultadoPresionFrontString[6];
            ResultadoFinal[7] = ResultadoPresionFrontString[7];
            ResultadoFinal[8] = ResultadoPresionFrontString[8];
            ResultadoFinal[9] = ResultadoPresionFrontString[9];

            return ResultadoFinal;
        }

        private string[] CalcularApuestaPresionBack1F(double Resultado1, double Resultado2, double Resultado3, double Resultado4, double Resultado5, double Resultado6, double Resultado7, double Resultado8, double Resultado9, bool ValidaJuegoInicio)
        {
            int[] ResultadoPresionFront = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado1 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado1 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado2 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado2 > 0)
            {
                ResultadoPresionFront[2] = 1;
            }
            else if (Resultado2 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado3 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado3 > 0)
            {
                ResultadoPresionFront[3] = 1;
            }
            else if (Resultado3 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado4 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado4 > 0)
            {
                ResultadoPresionFront[4] = 1;
            }
            else if (Resultado4 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado5 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado5 > 0)
            {
                ResultadoPresionFront[5] = 1;
            }
            else if (Resultado5 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado6 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado6 > 0)
            {
                ResultadoPresionFront[6] = 1;
            }
            else if (Resultado6 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado7 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado7 > 0)
            {
                ResultadoPresionFront[7] = 1;
            }
            else if (Resultado7 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado8 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado8 > 0)
            {
                ResultadoPresionFront[8] = 1;
            }
            else if (Resultado8 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado9 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionFront[9] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionFront[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;
            int ResultadoInt1 = 0;
            int ResultadoInt2 = 0;
            int ResultadoInt3 = 0;
            int ResultadoInt4 = 0;
            int ResultadoInt5 = 0;
            int ResultadoInt6 = 0;
            int ResultadoInt7 = 0;
            int ResultadoInt8 = 0;

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;

                    switch (i)
                    {
                        case 1:

                            ResultadoString = Convert.ToString(ResultadoInt) + ", 0";

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 += 1;
                            ResultadoInt2 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + ", 0";

                            break;
                        case 3:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + ", 0";

                            break;
                        case 4:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + ", 0";


                            break;
                        case 7:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 += 1;
                            ResultadoInt7 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + ", 0";



                            break;
                        case 8:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 += 1;
                            ResultadoInt7 += 1;
                            ResultadoInt8 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + ", 0";


                            break;
                        case 9:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 += 1;
                            ResultadoInt7 += 1;
                            ResultadoInt8 += 1;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8) + ", 0";


                            break;
                        default:



                            break;
                    }

                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;

                    switch (i)
                    {
                        case 1:

                            ResultadoString = Convert.ToString(ResultadoInt) + ", 0";

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + ", 0";

                            break;
                        case 3:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + ", 0";

                            break;
                        case 4:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + ", 0";


                            break;
                        case 7:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 -= 1;
                            ResultadoInt7 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + ", 0";



                            break;
                        case 8:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 -= 1;
                            ResultadoInt7 -= 1;
                            ResultadoInt8 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + ", 0";


                            break;
                        case 9:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 -= 1;
                            ResultadoInt7 -= 1;
                            ResultadoInt8 -= 1;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8) + ", 0";


                            break;
                        default:



                            break;
                    }


                }
                else
                {

                    ResultadoInt += 0;

                    switch (i)
                    {
                        case 1:

                            ResultadoString = Convert.ToString(ResultadoInt) + ", 0";

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 2:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 3:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 4:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 5:


                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 6:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 7:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 8:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            break;
                        case 9:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);


                            break;
                        default:



                            break;
                    }


                }

            }

            string[] ResultadoFinal = new string[10];

            ResultadoFinal[0] = ResultadoString;

            ResultadoFinal[1] = ResultadoPresionFrontString[1];
            ResultadoFinal[2] = ResultadoPresionFrontString[2];
            ResultadoFinal[3] = ResultadoPresionFrontString[3];
            ResultadoFinal[4] = ResultadoPresionFrontString[4];
            ResultadoFinal[5] = ResultadoPresionFrontString[5];
            ResultadoFinal[6] = ResultadoPresionFrontString[6];
            ResultadoFinal[7] = ResultadoPresionFrontString[7];
            ResultadoFinal[8] = ResultadoPresionFrontString[8];
            ResultadoFinal[9] = ResultadoPresionFrontString[9];

            return ResultadoFinal;

        }

        private string[] CalcularApuestaPresionFront2F(double Resultado1, double Resultado2, double Resultado3, double Resultado4, double Resultado5, double Resultado6, double Resultado7, double Resultado8, double Resultado9, bool ValidaJuegoInicio)
        {
            int[] ResultadoPresionFront = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado1 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado1 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado2 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado2 > 0)
            {
                ResultadoPresionFront[2] = 1;
            }
            else if (Resultado2 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado3 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado3 > 0)
            {
                ResultadoPresionFront[3] = 1;
            }
            else if (Resultado3 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado4 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado4 > 0)
            {
                ResultadoPresionFront[4] = 1;
            }
            else if (Resultado4 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado5 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado5 > 0)
            {
                ResultadoPresionFront[5] = 1;
            }
            else if (Resultado5 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado6 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado6 > 0)
            {
                ResultadoPresionFront[6] = 1;
            }
            else if (Resultado6 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado7 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado7 > 0)
            {
                ResultadoPresionFront[7] = 1;
            }
            else if (Resultado7 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado8 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado8 > 0)
            {
                ResultadoPresionFront[8] = 1;
            }
            else if (Resultado8 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado9 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionFront[9] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionFront[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == 2)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;


                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;


                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            //  ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

                            continue;
                        }

                        if (PresionValor4 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion += 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;

                            continue;
                        }

                        if (PresionValor5 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "" && PresionValor4 != "")
                        {
                            PresionValor5 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion += 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);
                                Presion += 1;
                                PresionValor4 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;

                            continue;
                        }

                    }
                    else
                    {
                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion += 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion += 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion += 1;
                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);
                            Presion += 1;
                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);
                            Presion += 1;
                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }
                    }

                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == -2)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1; ;

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;

                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;


                            continue;
                        }

                        if (PresionValor4 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion -= 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;


                            continue;
                        }

                        if (PresionValor5 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "" && PresionValor4 != "")
                        {
                            PresionValor5 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion -= 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);
                                Presion -= 1;
                                PresionValor4 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;


                            continue;
                        }
                    }
                    else
                    {

                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion -= 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion -= 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion -= 1;
                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);
                            Presion -= 1;
                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);
                            Presion -= 1;
                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }

                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                    if (i > 1)
                    {
                        ResultadoPresionFrontString[i] = Convert.ToString(ResultadoPresionFrontString[i - 1]);
                    }
                    else
                    {
                        ResultadoPresionFrontString[i] = "0";
                    }


                }

            }


            string ResultadointFinal = "";

            if (ValidaJuegoInicio == true)
            {
                ResultadointFinal = "";
            }
            else
            {
                ResultadointFinal = Convert.ToString(ResultadoInt);
            }


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;

            string[] ResultadoFinal = new string[10];

            ResultadoFinal[0] = ResultadoString;

            ResultadoFinal[1] = ResultadoPresionFrontString[1];
            ResultadoFinal[2] = ResultadoPresionFrontString[2];
            ResultadoFinal[3] = ResultadoPresionFrontString[3];
            ResultadoFinal[4] = ResultadoPresionFrontString[4];
            ResultadoFinal[5] = ResultadoPresionFrontString[5];
            ResultadoFinal[6] = ResultadoPresionFrontString[6];
            ResultadoFinal[7] = ResultadoPresionFrontString[7];
            ResultadoFinal[8] = ResultadoPresionFrontString[8];
            ResultadoFinal[9] = ResultadoPresionFrontString[9];

            return ResultadoFinal;

        }

        private string[] CalcularApuestaPresionBack2F(double Resultado1, double Resultado2, double Resultado3, double Resultado4, double Resultado5, double Resultado6, double Resultado7, double Resultado8, double Resultado9, bool ValidaJuegoInicio)
        {
            int[] ResultadoPresionFront = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado1 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado1 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado2 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado2 > 0)
            {
                ResultadoPresionFront[2] = 1;
            }
            else if (Resultado2 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado3 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado3 > 0)
            {
                ResultadoPresionFront[3] = 1;
            }
            else if (Resultado3 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado4 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado4 > 0)
            {
                ResultadoPresionFront[4] = 1;
            }
            else if (Resultado4 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado5 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado5 > 0)
            {
                ResultadoPresionFront[5] = 1;
            }
            else if (Resultado5 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado6 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado6 > 0)
            {
                ResultadoPresionFront[6] = 1;
            }
            else if (Resultado6 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado7 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado7 > 0)
            {
                ResultadoPresionFront[7] = 1;
            }
            else if (Resultado7 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado8 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado8 > 0)
            {
                ResultadoPresionFront[8] = 1;
            }
            else if (Resultado8 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado9 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionFront[9] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionFront[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == 2)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;


                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;


                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            //  ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

                            continue;
                        }

                        if (PresionValor4 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion += 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;

                            continue;
                        }

                        if (PresionValor5 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "" && PresionValor4 != "")
                        {
                            PresionValor5 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion += 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);
                                Presion += 1;
                                PresionValor4 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;

                            continue;
                        }

                    }
                    else
                    {
                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion += 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion += 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion += 1;
                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);
                            Presion += 1;
                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);
                            Presion += 1;
                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }
                    }

                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == -2)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1; ;

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;

                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;


                            continue;
                        }

                        if (PresionValor4 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion -= 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;


                            continue;
                        }

                        if (PresionValor5 == "" && PresionValor1 != "" && PresionValor2 != "" && PresionValor3 != "" && PresionValor4 != "")
                        {
                            PresionValor5 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);
                                Presion -= 1;
                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);
                                Presion -= 1;
                                PresionValor4 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;


                            continue;
                        }
                    }
                    else
                    {

                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion -= 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion -= 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion -= 1;
                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);
                            Presion -= 1;
                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);
                            Presion -= 1;
                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }

                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                    if (i > 1)
                    {
                        ResultadoPresionFrontString[i] = Convert.ToString(ResultadoPresionFrontString[i - 1]);
                    }
                    else
                    {
                        ResultadoPresionFrontString[i] = "0";
                    }


                }

            }

            string ResultadointFinal = "";

            if (ValidaJuegoInicio == true)
            {
                ResultadointFinal = "";
            }
            else
            {
                ResultadointFinal = Convert.ToString(ResultadoInt);
            }


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;

            string[] ResultadoFinal = new string[10];

            ResultadoFinal[0] = ResultadoString;

            ResultadoFinal[1] = ResultadoPresionFrontString[1];
            ResultadoFinal[2] = ResultadoPresionFrontString[2];
            ResultadoFinal[3] = ResultadoPresionFrontString[3];
            ResultadoFinal[4] = ResultadoPresionFrontString[4];
            ResultadoFinal[5] = ResultadoPresionFrontString[5];
            ResultadoFinal[6] = ResultadoPresionFrontString[6];
            ResultadoFinal[7] = ResultadoPresionFrontString[7];
            ResultadoFinal[8] = ResultadoPresionFrontString[8];
            ResultadoFinal[9] = ResultadoPresionFrontString[9];

            return ResultadoFinal;

        }

        private string[] CalcularApuestaPresionFront3F(double Resultado1, double Resultado2, double Resultado3, double Resultado4, double Resultado5, double Resultado6, double Resultado7, double Resultado8, double Resultado9, bool ValidaJuegoInicio)
        {

            int[] ResultadoPresionFront = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado1 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado1 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado2 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado2 > 0)
            {
                ResultadoPresionFront[2] = 1;
            }
            else if (Resultado2 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado3 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado3 > 0)
            {
                ResultadoPresionFront[3] = 1;
            }
            else if (Resultado3 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado4 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado4 > 0)
            {
                ResultadoPresionFront[4] = 1;
            }
            else if (Resultado4 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado5 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado5 > 0)
            {
                ResultadoPresionFront[5] = 1;
            }
            else if (Resultado5 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado6 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado6 > 0)
            {
                ResultadoPresionFront[6] = 1;
            }
            else if (Resultado6 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado7 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado7 > 0)
            {
                ResultadoPresionFront[7] = 1;
            }
            else if (Resultado7 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado8 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado8 > 0)
            {
                ResultadoPresionFront[8] = 1;
            }
            else if (Resultado8 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado9 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionFront[9] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionFront[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {
                    if (Presion1 < 0)
                    {
                        Presion1 = 0;
                    }

                    ResultadoInt += 1;
                    Presion1 += 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == 3)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;

                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

                            continue;
                        }

                    }
                    else
                    {

                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion += 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion += 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion += 1;
                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }


                    }

                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    if (Presion1 > 0)
                    {
                        Presion1 = 0;
                    }

                    ResultadoInt -= 1;
                    Presion1 -= 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == -3)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }


                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;

                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;

                            continue;
                        }

                    }
                    else
                    {
                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion -= 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion -= 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion -= 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                    if (i > 1)
                    {
                        ResultadoPresionFrontString[i] = Convert.ToString(ResultadoPresionFrontString[i - 1]);
                    }
                    else
                    {
                        ResultadoPresionFrontString[i] = "0";
                    }

                }

            }


            string ResultadointFinal = "";

            if (ValidaJuegoInicio == true)
            {
                ResultadointFinal = "";
            }
            else
            {
                ResultadointFinal = Convert.ToString(ResultadoInt);
            }


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

            string[] ResultadoFinal = new string[10];

            ResultadoFinal[0] = ResultadoString;

            ResultadoFinal[1] = ResultadoPresionFrontString[1];
            ResultadoFinal[2] = ResultadoPresionFrontString[2];
            ResultadoFinal[3] = ResultadoPresionFrontString[3];
            ResultadoFinal[4] = ResultadoPresionFrontString[4];
            ResultadoFinal[5] = ResultadoPresionFrontString[5];
            ResultadoFinal[6] = ResultadoPresionFrontString[6];
            ResultadoFinal[7] = ResultadoPresionFrontString[7];
            ResultadoFinal[8] = ResultadoPresionFrontString[8];
            ResultadoFinal[9] = ResultadoPresionFrontString[9];

            return ResultadoFinal;
        }

        private string[] CalcularApuestaPresionBack3F(double Resultado1, double Resultado2, double Resultado3, double Resultado4, double Resultado5, double Resultado6, double Resultado7, double Resultado8, double Resultado9, bool ValidaJuegoInicio)
        {
            int[] ResultadoPresionFront = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado1 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado1 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado2 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado2 > 0)
            {
                ResultadoPresionFront[2] = 1;
            }
            else if (Resultado2 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado3 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado3 > 0)
            {
                ResultadoPresionFront[3] = 1;
            }
            else if (Resultado3 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado4 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado4 > 0)
            {
                ResultadoPresionFront[4] = 1;
            }
            else if (Resultado4 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado5 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado5 > 0)
            {
                ResultadoPresionFront[5] = 1;
            }
            else if (Resultado5 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado6 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado6 > 0)
            {
                ResultadoPresionFront[6] = 1;
            }
            else if (Resultado6 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado7 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado7 > 0)
            {
                ResultadoPresionFront[7] = 1;
            }
            else if (Resultado7 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado8 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado8 > 0)
            {
                ResultadoPresionFront[8] = 1;
            }
            else if (Resultado8 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado9 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionFront[9] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionFront[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == 3)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;

                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion += 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion += 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

                            continue;
                        }

                    }
                    else
                    {

                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion += 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion += 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion += 1;
                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }


                    }

                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 == -3)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                            continue;
                        }

                        if (PresionValor2 == "" && PresionValor1 != "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }


                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;

                            continue;
                        }

                        if (PresionValor3 == "" && PresionValor1 != "" && PresionValor2 != "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;

                            if (PresionValor1 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor1);
                                Presion -= 1;
                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);
                                Presion -= 1;
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;

                            continue;
                        }

                    }
                    else
                    {
                        if (PresionValor1 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor1);
                            Presion -= 1;
                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);
                            Presion -= 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);
                            Presion -= 1;
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                    if (i > 1)
                    {
                        ResultadoPresionFrontString[i] = Convert.ToString(ResultadoPresionFrontString[i - 1]);
                    }
                    else
                    {
                        ResultadoPresionFrontString[i] = "0";
                    }

                }

            }


            string ResultadointFinal = "";

            if (ValidaJuegoInicio == true)
            {
                ResultadointFinal = "";
            }
            else
            {
                ResultadointFinal = Convert.ToString(ResultadoInt);
            }


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

            string[] ResultadoFinal = new string[10];

            ResultadoFinal[0] = ResultadoString;

            ResultadoFinal[1] = ResultadoPresionFrontString[1];
            ResultadoFinal[2] = ResultadoPresionFrontString[2];
            ResultadoFinal[3] = ResultadoPresionFrontString[3];
            ResultadoFinal[4] = ResultadoPresionFrontString[4];
            ResultadoFinal[5] = ResultadoPresionFrontString[5];
            ResultadoFinal[6] = ResultadoPresionFrontString[6];
            ResultadoFinal[7] = ResultadoPresionFrontString[7];
            ResultadoFinal[8] = ResultadoPresionFrontString[8];
            ResultadoFinal[9] = ResultadoPresionFrontString[9];

            return ResultadoFinal;
        }

        private int ActualizarAPuestaF(int IDBetDetail, int IDBet, int IDRonda, int BetD_Player1, int BetD_Player2, string BetD_F9_1, string BetD_F9_2, string BetD_F9_3, string BetD_F9_4, string BetD_F9_5, string BetD_F9_6, string BetD_F9_7, string BetD_F9_8, string BetD_F9_9,
                                      string BetD_B9_1, string BetD_B9_2, string BetD_B9_3, string BetD_B9_4, string BetD_B9_5, string BetD_B9_6, string BetD_B9_7, string BetD_B9_8, string BetD_B9_9, int ResultadoFinalMedal, int Match,
                                      string Hoyo_1, string Hoyo_2, string Hoyo_3, string Hoyo_4, string Hoyo_5, string Hoyo_6, string Hoyo_7, string Hoyo_8, string Hoyo_9,
                                      string Hoyo_10, string Hoyo_11, string Hoyo_12, string Hoyo_13, string Hoyo_14, string Hoyo_15, string Hoyo_16, string Hoyo_17, string Hoyo_18
                                      , int Presion, bool ValidaJuegoInicio, double TotalMeldal)
        {


            SqlCommand comando = new SqlCommand("DragoGolf_UpdateDetailBet");
            comando.CommandType = CommandType.StoredProcedure;

            //Declaracion de parametros
            comando.Parameters.Add("@IDBet", SqlDbType.Int);
            comando.Parameters.Add("@IDBetDetail", SqlDbType.Int);
            comando.Parameters.Add("@IDRonda", SqlDbType.Int);
            comando.Parameters.Add("@BetD_Player1", SqlDbType.Int);
            comando.Parameters.Add("@BetD_Player2", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_1", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_2", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_3", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_4", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_5", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_6", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_7", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_8", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_F9_9", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_1", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_2", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_3", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_4", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_5", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_6", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_7", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_8", SqlDbType.VarChar);
            comando.Parameters.Add("@BetD_B9_9", SqlDbType.VarChar);

            comando.Parameters.Add("@Hoyo1", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo2", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo3", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo4", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo5", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo6", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo7", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo8", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo9", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo10", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo11", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo12", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo13", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo14", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo15", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo16", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo17", SqlDbType.VarChar);
            comando.Parameters.Add("@Hoyo18", SqlDbType.VarChar);
            comando.Parameters.Add("@Presion", SqlDbType.Int);

            comando.Parameters.Add("@Medal", SqlDbType.Int);
            comando.Parameters.Add("@Match", SqlDbType.Int);
            comando.Parameters.Add("@ValidaJuegoInicio", SqlDbType.Bit);
            comando.Parameters.Add("@TotalMeldal", SqlDbType.Float);


            //Asignacion de valores a parametros
            comando.Parameters["@IDBet"].Value = IDBet;
            comando.Parameters["@IDBetDetail"].Value = IDBetDetail;
            comando.Parameters["@IDRonda"].Value = IDRonda;
            comando.Parameters["@BetD_Player1"].Value = BetD_Player1;
            comando.Parameters["@BetD_Player2"].Value = BetD_Player2;
            comando.Parameters["@BetD_F9_1"].Value = BetD_F9_1;
            comando.Parameters["@BetD_F9_2"].Value = BetD_F9_2;
            comando.Parameters["@BetD_F9_3"].Value = BetD_F9_3;
            comando.Parameters["@BetD_F9_4"].Value = BetD_F9_4;
            comando.Parameters["@BetD_F9_5"].Value = BetD_F9_5;
            comando.Parameters["@BetD_F9_6"].Value = BetD_F9_6;
            comando.Parameters["@BetD_F9_7"].Value = BetD_F9_7;
            comando.Parameters["@BetD_F9_8"].Value = BetD_F9_8;
            comando.Parameters["@BetD_F9_9"].Value = BetD_F9_9;
            comando.Parameters["@BetD_B9_1"].Value = BetD_B9_1;
            comando.Parameters["@BetD_B9_2"].Value = BetD_B9_2;
            comando.Parameters["@BetD_B9_3"].Value = BetD_B9_3;
            comando.Parameters["@BetD_B9_4"].Value = BetD_B9_4;
            comando.Parameters["@BetD_B9_5"].Value = BetD_B9_5;
            comando.Parameters["@BetD_B9_6"].Value = BetD_B9_6;
            comando.Parameters["@BetD_B9_7"].Value = BetD_B9_7;
            comando.Parameters["@BetD_B9_8"].Value = BetD_B9_8;
            comando.Parameters["@BetD_B9_9"].Value = BetD_B9_9;

            comando.Parameters["@Hoyo1"].Value = Hoyo_1;
            comando.Parameters["@Hoyo2"].Value = Hoyo_2;
            comando.Parameters["@Hoyo3"].Value = Hoyo_3;
            comando.Parameters["@Hoyo4"].Value = Hoyo_4;
            comando.Parameters["@Hoyo5"].Value = Hoyo_5;
            comando.Parameters["@Hoyo6"].Value = Hoyo_6;
            comando.Parameters["@Hoyo7"].Value = Hoyo_7;
            comando.Parameters["@Hoyo8"].Value = Hoyo_8;
            comando.Parameters["@Hoyo9"].Value = Hoyo_9;
            comando.Parameters["@Hoyo10"].Value = Hoyo_10;
            comando.Parameters["@Hoyo11"].Value = Hoyo_11;
            comando.Parameters["@Hoyo12"].Value = Hoyo_12;
            comando.Parameters["@Hoyo13"].Value = Hoyo_13;
            comando.Parameters["@Hoyo14"].Value = Hoyo_14;
            comando.Parameters["@Hoyo15"].Value = Hoyo_15;
            comando.Parameters["@Hoyo16"].Value = Hoyo_16;
            comando.Parameters["@Hoyo17"].Value = Hoyo_17;
            comando.Parameters["@Hoyo18"].Value = Hoyo_18;
            comando.Parameters["@Presion"].Value = Presion;

            comando.Parameters["@Medal"].Value = ResultadoFinalMedal;
            comando.Parameters["@Match"].Value = Match;
            comando.Parameters["@ValidaJuegoInicio"].Value = ValidaJuegoInicio;
            comando.Parameters["@TotalMeldal"].Value = TotalMeldal;


            comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
            comando.CommandTimeout = 0;
            comando.Connection.Open();

            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            comando.Connection.Close();
            DA.Fill(DT);


            return 0;
        }


        private double[] HoyoInicialCambioF(double hole1_P1, double hole2_P1, double hole3_P1, double hole4_P1, double hole5_P1, double hole6_P1, double hole7_P1, double hole8_P1, double hole9_P1, double hole10_P1, double hole11_P1, double hole12_P1, double hole13_P1, double hole14_P1, double hole15_P1, double hole16_P1, double hole17_P1, double hole18_P1,
            double hole1_P2, double hole2_P2, double hole3_P2, double hole4_P2, double hole5_P2, double hole6_P2, double hole7_P2, double hole8_P2, double hole9_P2, double hole10_P2, double hole11_P2, double hole12_P2, double hole13_P2, double hole14_P2, double hole15_P2, double hole16_P2, double hole17_P2, double hole18_P2, int HoyoInicial)
        {

            double[] SwitchHoles_P1 = new double[19];
            double[] SwitchHoles_P2 = new double[19];

            double[] SwitchHoles = new double[38];


            switch (HoyoInicial)
            {
                case 1:
                    //OK
                    SwitchHoles_P1[1] = hole1_P1;
                    SwitchHoles_P1[2] = hole2_P1;
                    SwitchHoles_P1[3] = hole3_P1;
                    SwitchHoles_P1[4] = hole4_P1;
                    SwitchHoles_P1[5] = hole5_P1;
                    SwitchHoles_P1[6] = hole6_P1;
                    SwitchHoles_P1[7] = hole7_P1;
                    SwitchHoles_P1[8] = hole8_P1;
                    SwitchHoles_P1[9] = hole9_P1;
                    SwitchHoles_P1[10] = hole10_P1;
                    SwitchHoles_P1[11] = hole11_P1;
                    SwitchHoles_P1[12] = hole12_P1;
                    SwitchHoles_P1[13] = hole13_P1;
                    SwitchHoles_P1[14] = hole14_P1;
                    SwitchHoles_P1[15] = hole15_P1;
                    SwitchHoles_P1[16] = hole16_P1;
                    SwitchHoles_P1[17] = hole17_P1;
                    SwitchHoles_P1[18] = hole18_P1;

                    SwitchHoles_P2[1] = hole1_P2;
                    SwitchHoles_P2[2] = hole2_P2;
                    SwitchHoles_P2[3] = hole3_P2;
                    SwitchHoles_P2[4] = hole4_P2;
                    SwitchHoles_P2[5] = hole5_P2;
                    SwitchHoles_P2[6] = hole6_P2;
                    SwitchHoles_P2[7] = hole7_P2;
                    SwitchHoles_P2[8] = hole8_P2;
                    SwitchHoles_P2[9] = hole9_P2;
                    SwitchHoles_P2[10] = hole10_P2;
                    SwitchHoles_P2[11] = hole11_P2;
                    SwitchHoles_P2[12] = hole12_P2;
                    SwitchHoles_P2[13] = hole13_P2;
                    SwitchHoles_P2[14] = hole14_P2;
                    SwitchHoles_P2[15] = hole15_P2;
                    SwitchHoles_P2[16] = hole16_P2;
                    SwitchHoles_P2[17] = hole17_P2;
                    SwitchHoles_P2[18] = hole18_P2;

                   

                    break;
                case 2:
                    //OK
                    SwitchHoles_P1[1] = hole2_P1;
                    SwitchHoles_P1[2] = hole3_P1;
                    SwitchHoles_P1[3] = hole4_P1;
                    SwitchHoles_P1[4] = hole5_P1;
                    SwitchHoles_P1[5] = hole6_P1;
                    SwitchHoles_P1[6] = hole7_P1;
                    SwitchHoles_P1[7] = hole8_P1;
                    SwitchHoles_P1[8] = hole9_P1;
                    SwitchHoles_P1[9] = hole10_P1;
                    SwitchHoles_P1[10] = hole11_P1;
                    SwitchHoles_P1[11] = hole12_P1;
                    SwitchHoles_P1[12] = hole13_P1;
                    SwitchHoles_P1[13] = hole14_P1;
                    SwitchHoles_P1[14] = hole15_P1;
                    SwitchHoles_P1[15] = hole16_P1;
                    SwitchHoles_P1[16] = hole17_P1;
                    SwitchHoles_P1[17] = hole18_P1;
                    SwitchHoles_P1[18] = hole1_P1;

                    SwitchHoles_P2[1] = hole2_P2;
                    SwitchHoles_P2[2] = hole3_P2;
                    SwitchHoles_P2[3] = hole4_P2;
                    SwitchHoles_P2[4] = hole5_P2;
                    SwitchHoles_P2[5] = hole6_P2;
                    SwitchHoles_P2[6] = hole7_P2;
                    SwitchHoles_P2[7] = hole8_P2;
                    SwitchHoles_P2[8] = hole9_P2;
                    SwitchHoles_P2[9] = hole10_P2;
                    SwitchHoles_P2[10] = hole11_P2;
                    SwitchHoles_P2[11] = hole12_P2;
                    SwitchHoles_P2[12] = hole13_P2;
                    SwitchHoles_P2[13] = hole14_P2;
                    SwitchHoles_P2[14] = hole15_P2;
                    SwitchHoles_P2[15] = hole16_P2;
                    SwitchHoles_P2[16] = hole17_P2;
                    SwitchHoles_P2[17] = hole18_P2;
                    SwitchHoles_P2[18] = hole1_P2;

                    
                    break;
                case 3:
                    SwitchHoles_P1[1] = hole3_P1;
                    SwitchHoles_P1[2] = hole4_P1;
                    SwitchHoles_P1[3] = hole5_P1;
                    SwitchHoles_P1[4] = hole6_P1;
                    SwitchHoles_P1[5] = hole7_P1;
                    SwitchHoles_P1[6] = hole8_P1;
                    SwitchHoles_P1[7] = hole9_P1;
                    SwitchHoles_P1[8] = hole10_P1;
                    SwitchHoles_P1[9] = hole11_P1;
                    SwitchHoles_P1[10] = hole12_P1;
                    SwitchHoles_P1[11] = hole13_P1;
                    SwitchHoles_P1[12] = hole14_P1;
                    SwitchHoles_P1[13] = hole15_P1;
                    SwitchHoles_P1[14] = hole16_P1;
                    SwitchHoles_P1[15] = hole17_P1;
                    SwitchHoles_P1[16] = hole18_P1;
                    SwitchHoles_P1[17] = hole1_P1;
                    SwitchHoles_P1[18] = hole2_P1;

                    SwitchHoles_P2[1] = hole3_P2;
                    SwitchHoles_P2[2] = hole4_P2;
                    SwitchHoles_P2[3] = hole5_P2;
                    SwitchHoles_P2[4] = hole6_P2;
                    SwitchHoles_P2[5] = hole7_P2;
                    SwitchHoles_P2[6] = hole8_P2;
                    SwitchHoles_P2[7] = hole9_P2;
                    SwitchHoles_P2[8] = hole10_P2;
                    SwitchHoles_P2[9] = hole11_P2;
                    SwitchHoles_P2[10] = hole12_P2;
                    SwitchHoles_P2[11] = hole13_P2;
                    SwitchHoles_P2[12] = hole14_P2;
                    SwitchHoles_P2[13] = hole15_P2;
                    SwitchHoles_P2[14] = hole16_P2;
                    SwitchHoles_P2[15] = hole17_P2;
                    SwitchHoles_P2[16] = hole18_P2;
                    SwitchHoles_P2[17] = hole1_P2;
                    SwitchHoles_P2[18] = hole2_P2;

                    
                    break;
                case 4:
                    SwitchHoles_P1[1] = hole4_P1;
                    SwitchHoles_P1[2] = hole5_P1;
                    SwitchHoles_P1[3] = hole6_P1;
                    SwitchHoles_P1[4] = hole7_P1;
                    SwitchHoles_P1[5] = hole8_P1;
                    SwitchHoles_P1[6] = hole9_P1;
                    SwitchHoles_P1[7] = hole10_P1;
                    SwitchHoles_P1[8] = hole11_P1;
                    SwitchHoles_P1[9] = hole12_P1;
                    SwitchHoles_P1[10] = hole7_P1;
                    SwitchHoles_P1[11] = hole8_P1;
                    SwitchHoles_P1[12] = hole9_P1;
                    SwitchHoles_P1[13] = hole10_P1;
                    SwitchHoles_P1[14] = hole11_P1;
                    SwitchHoles_P1[15] = hole12_P1;
                    SwitchHoles_P1[16] = hole13_P1;
                    SwitchHoles_P1[17] = hole14_P1;
                    SwitchHoles_P1[18] = hole15_P1;

                    SwitchHoles_P2[1] = hole4_P2;
                    SwitchHoles_P2[2] = hole5_P2;
                    SwitchHoles_P2[3] = hole6_P2;
                    SwitchHoles_P2[4] = hole7_P2;
                    SwitchHoles_P2[5] = hole8_P2;
                    SwitchHoles_P2[6] = hole9_P2;
                    SwitchHoles_P2[7] = hole10_P2;
                    SwitchHoles_P2[8] = hole11_P2;
                    SwitchHoles_P2[9] = hole12_P2;
                    SwitchHoles_P2[10] = hole13_P2;
                    SwitchHoles_P2[11] = hole14_P2;
                    SwitchHoles_P2[12] = hole15_P2;
                    SwitchHoles_P2[13] = hole16_P2;
                    SwitchHoles_P2[14] = hole17_P2;
                    SwitchHoles_P2[15] = hole18_P2;
                    SwitchHoles_P2[16] = hole1_P2;
                    SwitchHoles_P2[17] = hole2_P2;
                    SwitchHoles_P2[18] = hole3_P2;

                    
                    break;
                case 5:
                    SwitchHoles_P1[1] = hole5_P1;
                    SwitchHoles_P1[2] = hole6_P1;
                    SwitchHoles_P1[3] = hole7_P1;
                    SwitchHoles_P1[4] = hole8_P1;
                    SwitchHoles_P1[5] = hole9_P1;
                    SwitchHoles_P1[6] = hole10_P1;
                    SwitchHoles_P1[7] = hole11_P1;
                    SwitchHoles_P1[8] = hole12_P1;
                    SwitchHoles_P1[9] = hole13_P1;
                    SwitchHoles_P1[10] = hole14_P1;
                    SwitchHoles_P1[11] = hole15_P1;
                    SwitchHoles_P1[12] = hole16_P1;
                    SwitchHoles_P1[13] = hole17_P1;
                    SwitchHoles_P1[14] = hole18_P1;
                    SwitchHoles_P1[15] = hole1_P1;
                    SwitchHoles_P1[16] = hole2_P1;
                    SwitchHoles_P1[17] = hole3_P1;
                    SwitchHoles_P1[18] = hole4_P1;

                    SwitchHoles_P2[1] = hole5_P2;
                    SwitchHoles_P2[2] = hole6_P2;
                    SwitchHoles_P2[3] = hole7_P2;
                    SwitchHoles_P2[4] = hole8_P2;
                    SwitchHoles_P2[5] = hole9_P2;
                    SwitchHoles_P2[6] = hole10_P2;
                    SwitchHoles_P2[7] = hole11_P2;
                    SwitchHoles_P2[8] = hole12_P2;
                    SwitchHoles_P2[9] = hole13_P2;
                    SwitchHoles_P2[10] = hole14_P2;
                    SwitchHoles_P2[11] = hole15_P2;
                    SwitchHoles_P2[12] = hole16_P2;
                    SwitchHoles_P2[13] = hole17_P2;
                    SwitchHoles_P2[14] = hole18_P2;
                    SwitchHoles_P2[15] = hole1_P2;
                    SwitchHoles_P2[16] = hole2_P2;
                    SwitchHoles_P2[17] = hole3_P2;
                    SwitchHoles_P2[18] = hole4_P2;

                    
                    break;
                case 6:
                    SwitchHoles_P1[1] = hole6_P1;
                    SwitchHoles_P1[2] = hole7_P1;
                    SwitchHoles_P1[3] = hole8_P1;
                    SwitchHoles_P1[4] = hole9_P1;
                    SwitchHoles_P1[5] = hole10_P1;
                    SwitchHoles_P1[6] = hole11_P1;
                    SwitchHoles_P1[7] = hole12_P1;
                    SwitchHoles_P1[8] = hole13_P1;
                    SwitchHoles_P1[9] = hole14_P1;
                    SwitchHoles_P1[10] = hole15_P1;
                    SwitchHoles_P1[11] = hole16_P1;
                    SwitchHoles_P1[12] = hole17_P1;
                    SwitchHoles_P1[13] = hole18_P1;
                    SwitchHoles_P1[14] = hole1_P1;
                    SwitchHoles_P1[15] = hole2_P1;
                    SwitchHoles_P1[16] = hole3_P1;
                    SwitchHoles_P1[17] = hole4_P1;
                    SwitchHoles_P1[18] = hole5_P1;

                    SwitchHoles_P2[1] = hole6_P2;
                    SwitchHoles_P2[2] = hole7_P2;
                    SwitchHoles_P2[3] = hole8_P2;
                    SwitchHoles_P2[4] = hole9_P2;
                    SwitchHoles_P2[5] = hole10_P2;
                    SwitchHoles_P2[6] = hole11_P2;
                    SwitchHoles_P2[7] = hole12_P2;
                    SwitchHoles_P2[8] = hole13_P2;
                    SwitchHoles_P2[9] = hole14_P2;
                    SwitchHoles_P2[10] = hole15_P2;
                    SwitchHoles_P2[11] = hole16_P2;
                    SwitchHoles_P2[12] = hole17_P2;
                    SwitchHoles_P2[13] = hole18_P2;
                    SwitchHoles_P2[14] = hole1_P2;
                    SwitchHoles_P2[15] = hole2_P2;
                    SwitchHoles_P2[16] = hole3_P2;
                    SwitchHoles_P2[17] = hole4_P2;
                    SwitchHoles_P2[18] = hole5_P2;

                    break;
                case 7:
                    SwitchHoles_P1[1] = hole7_P1;
                    SwitchHoles_P1[2] = hole8_P1;
                    SwitchHoles_P1[3] = hole9_P1;
                    SwitchHoles_P1[4] = hole10_P1;
                    SwitchHoles_P1[5] = hole11_P1;
                    SwitchHoles_P1[6] = hole12_P1;
                    SwitchHoles_P1[7] = hole13_P1;
                    SwitchHoles_P1[8] = hole14_P1;
                    SwitchHoles_P1[9] = hole15_P1;
                    SwitchHoles_P1[10] = hole16_P1;
                    SwitchHoles_P1[11] = hole17_P1;
                    SwitchHoles_P1[12] = hole18_P1;
                    SwitchHoles_P1[13] = hole1_P1;
                    SwitchHoles_P1[14] = hole2_P1;
                    SwitchHoles_P1[15] = hole3_P1;
                    SwitchHoles_P1[16] = hole4_P1;
                    SwitchHoles_P1[17] = hole5_P1;
                    SwitchHoles_P1[18] = hole6_P1;

                    SwitchHoles_P2[1] = hole7_P2;
                    SwitchHoles_P2[2] = hole8_P2;
                    SwitchHoles_P2[3] = hole9_P2;
                    SwitchHoles_P2[4] = hole10_P2;
                    SwitchHoles_P2[5] = hole11_P2;
                    SwitchHoles_P2[6] = hole12_P2;
                    SwitchHoles_P2[7] = hole13_P2;
                    SwitchHoles_P2[8] = hole14_P2;
                    SwitchHoles_P2[9] = hole15_P2;
                    SwitchHoles_P2[10] = hole16_P2;
                    SwitchHoles_P2[11] = hole17_P2;
                    SwitchHoles_P2[12] = hole18_P2;
                    SwitchHoles_P2[13] = hole1_P2;
                    SwitchHoles_P2[14] = hole2_P2;
                    SwitchHoles_P2[15] = hole3_P2;
                    SwitchHoles_P2[16] = hole4_P2;
                    SwitchHoles_P2[17] = hole5_P2;
                    SwitchHoles_P2[18] = hole6_P2;

                    break;
                case 8:

                    SwitchHoles_P1[1] = hole8_P1;
                    SwitchHoles_P1[2] = hole9_P1;
                    SwitchHoles_P1[3] = hole10_P1;
                    SwitchHoles_P1[4] = hole11_P1;
                    SwitchHoles_P1[5] = hole12_P1;
                    SwitchHoles_P1[6] = hole13_P1;
                    SwitchHoles_P1[7] = hole14_P1;
                    SwitchHoles_P1[8] = hole15_P1;
                    SwitchHoles_P1[9] = hole16_P1;
                    SwitchHoles_P1[10] = hole17_P1;
                    SwitchHoles_P1[11] = hole18_P1;
                    SwitchHoles_P1[12] = hole1_P1;
                    SwitchHoles_P1[13] = hole2_P1;
                    SwitchHoles_P1[14] = hole3_P1;
                    SwitchHoles_P1[15] = hole4_P1;
                    SwitchHoles_P1[16] = hole5_P1;
                    SwitchHoles_P1[17] = hole6_P1;
                    SwitchHoles_P1[18] = hole7_P1;

                    SwitchHoles_P2[1] = hole8_P2;
                    SwitchHoles_P2[2] = hole9_P2;
                    SwitchHoles_P2[3] = hole10_P2;
                    SwitchHoles_P2[4] = hole11_P2;
                    SwitchHoles_P2[5] = hole12_P2;
                    SwitchHoles_P2[6] = hole13_P2;
                    SwitchHoles_P2[7] = hole14_P2;
                    SwitchHoles_P2[8] = hole15_P2;
                    SwitchHoles_P2[9] = hole16_P2;
                    SwitchHoles_P2[10] = hole17_P2;
                    SwitchHoles_P2[11] = hole18_P2;
                    SwitchHoles_P2[12] = hole1_P2;
                    SwitchHoles_P2[13] = hole2_P2;
                    SwitchHoles_P2[14] = hole3_P2;
                    SwitchHoles_P2[15] = hole4_P2;
                    SwitchHoles_P2[16] = hole5_P2;
                    SwitchHoles_P2[17] = hole6_P2;
                    SwitchHoles_P2[18] = hole7_P2;

                    break;
                case 9:
                    SwitchHoles_P1[1] = hole9_P1;
                    SwitchHoles_P1[2] = hole10_P1;
                    SwitchHoles_P1[3] = hole11_P1;
                    SwitchHoles_P1[4] = hole12_P1;
                    SwitchHoles_P1[5] = hole13_P1;
                    SwitchHoles_P1[6] = hole14_P1;
                    SwitchHoles_P1[7] = hole15_P1;
                    SwitchHoles_P1[8] = hole16_P1;
                    SwitchHoles_P1[9] = hole17_P1;
                    SwitchHoles_P1[10] = hole18_P1;
                    SwitchHoles_P1[11] = hole1_P1;
                    SwitchHoles_P1[12] = hole2_P1;
                    SwitchHoles_P1[13] = hole3_P1;
                    SwitchHoles_P1[14] = hole4_P1;
                    SwitchHoles_P1[15] = hole5_P1;
                    SwitchHoles_P1[16] = hole6_P1;
                    SwitchHoles_P1[17] = hole7_P1;
                    SwitchHoles_P1[18] = hole8_P1;

                    SwitchHoles_P2[1] = hole9_P2;
                    SwitchHoles_P2[2] = hole10_P2;
                    SwitchHoles_P2[3] = hole11_P2;
                    SwitchHoles_P2[4] = hole12_P2;
                    SwitchHoles_P2[5] = hole13_P2;
                    SwitchHoles_P2[6] = hole14_P2;
                    SwitchHoles_P2[7] = hole15_P2;
                    SwitchHoles_P2[8] = hole16_P2;
                    SwitchHoles_P2[9] = hole17_P2;
                    SwitchHoles_P2[10] = hole18_P2;
                    SwitchHoles_P2[11] = hole1_P2;
                    SwitchHoles_P2[12] = hole2_P2;
                    SwitchHoles_P2[13] = hole3_P2;
                    SwitchHoles_P2[14] = hole4_P2;
                    SwitchHoles_P2[15] = hole5_P2;
                    SwitchHoles_P2[16] = hole6_P2;
                    SwitchHoles_P2[17] = hole7_P2;
                    SwitchHoles_P2[18] = hole8_P2;

                    break;
                case 10:

                    SwitchHoles_P1[1] = hole10_P1;
                    SwitchHoles_P1[2] = hole11_P1;
                    SwitchHoles_P1[3] = hole12_P1;
                    SwitchHoles_P1[4] = hole13_P1;
                    SwitchHoles_P1[5] = hole14_P1;
                    SwitchHoles_P1[6] = hole15_P1;
                    SwitchHoles_P1[7] = hole16_P1;
                    SwitchHoles_P1[8] = hole17_P1;
                    SwitchHoles_P1[9] = hole18_P1;
                    SwitchHoles_P1[10] = hole1_P1;
                    SwitchHoles_P1[11] = hole2_P1;
                    SwitchHoles_P1[12] = hole3_P1;
                    SwitchHoles_P1[13] = hole4_P1;
                    SwitchHoles_P1[14] = hole5_P1;
                    SwitchHoles_P1[15] = hole6_P1;
                    SwitchHoles_P1[16] = hole7_P1;
                    SwitchHoles_P1[17] = hole8_P1;
                    SwitchHoles_P1[18] = hole9_P1;

                    SwitchHoles_P2[1] = hole10_P2;
                    SwitchHoles_P2[2] = hole11_P2;
                    SwitchHoles_P2[3] = hole12_P2;
                    SwitchHoles_P2[4] = hole13_P2;
                    SwitchHoles_P2[5] = hole14_P2;
                    SwitchHoles_P2[6] = hole15_P2;
                    SwitchHoles_P2[7] = hole16_P2;
                    SwitchHoles_P2[8] = hole17_P2;
                    SwitchHoles_P2[9] = hole18_P2;
                    SwitchHoles_P2[10] = hole1_P2;
                    SwitchHoles_P2[11] = hole2_P2;
                    SwitchHoles_P2[12] = hole3_P2;
                    SwitchHoles_P2[13] = hole4_P2;
                    SwitchHoles_P2[14] = hole5_P2;
                    SwitchHoles_P2[15] = hole6_P2;
                    SwitchHoles_P2[16] = hole7_P2;
                    SwitchHoles_P2[17] = hole8_P2;
                    SwitchHoles_P2[18] = hole9_P2;

                    break;
                case 11:

                    SwitchHoles_P1[1] = hole11_P1;
                    SwitchHoles_P1[2] = hole12_P1;
                    SwitchHoles_P1[3] = hole13_P1;
                    SwitchHoles_P1[4] = hole14_P1;
                    SwitchHoles_P1[5] = hole15_P1;
                    SwitchHoles_P1[6] = hole16_P1;
                    SwitchHoles_P1[7] = hole17_P1;
                    SwitchHoles_P1[8] = hole18_P1;
                    SwitchHoles_P1[9] = hole1_P1;
                    SwitchHoles_P1[10] = hole2_P1;
                    SwitchHoles_P1[11] = hole3_P1;
                    SwitchHoles_P1[12] = hole4_P1;
                    SwitchHoles_P1[13] = hole5_P1;
                    SwitchHoles_P1[14] = hole6_P1;
                    SwitchHoles_P1[15] = hole7_P1;
                    SwitchHoles_P1[16] = hole8_P1;
                    SwitchHoles_P1[17] = hole9_P1;
                    SwitchHoles_P1[18] = hole10_P1;

                    SwitchHoles_P2[1] = hole11_P2;
                    SwitchHoles_P2[2] = hole12_P2;
                    SwitchHoles_P2[3] = hole13_P2;
                    SwitchHoles_P2[4] = hole14_P2;
                    SwitchHoles_P2[5] = hole15_P2;
                    SwitchHoles_P2[6] = hole16_P2;
                    SwitchHoles_P2[7] = hole17_P2;
                    SwitchHoles_P2[8] = hole18_P2;
                    SwitchHoles_P2[9] = hole1_P2;
                    SwitchHoles_P2[10] = hole2_P2;
                    SwitchHoles_P2[11] = hole3_P2;
                    SwitchHoles_P2[12] = hole4_P2;
                    SwitchHoles_P2[13] = hole5_P2;
                    SwitchHoles_P2[14] = hole6_P2;
                    SwitchHoles_P2[15] = hole7_P2;
                    SwitchHoles_P2[16] = hole8_P2;
                    SwitchHoles_P2[17] = hole9_P2;
                    SwitchHoles_P2[18] = hole10_P2;

                    break;
                case 12:

                    SwitchHoles_P1[1] = hole12_P1;
                    SwitchHoles_P1[2] = hole13_P1;
                    SwitchHoles_P1[3] = hole14_P1;
                    SwitchHoles_P1[4] = hole15_P1;
                    SwitchHoles_P1[5] = hole16_P1;
                    SwitchHoles_P1[6] = hole17_P1;
                    SwitchHoles_P1[7] = hole18_P1;
                    SwitchHoles_P1[8] = hole1_P1;
                    SwitchHoles_P1[9] = hole2_P1;
                    SwitchHoles_P1[10] = hole3_P1;
                    SwitchHoles_P1[11] = hole4_P1;
                    SwitchHoles_P1[12] = hole5_P1;
                    SwitchHoles_P1[13] = hole6_P1;
                    SwitchHoles_P1[14] = hole7_P1;
                    SwitchHoles_P1[15] = hole8_P1;
                    SwitchHoles_P1[16] = hole9_P1;
                    SwitchHoles_P1[17] = hole10_P1;
                    SwitchHoles_P1[18] = hole11_P1;

                    SwitchHoles_P2[1] = hole12_P2;
                    SwitchHoles_P2[2] = hole13_P2;
                    SwitchHoles_P2[3] = hole14_P2;
                    SwitchHoles_P2[4] = hole15_P2;
                    SwitchHoles_P2[5] = hole16_P2;
                    SwitchHoles_P2[6] = hole17_P2;
                    SwitchHoles_P2[7] = hole18_P2;
                    SwitchHoles_P2[8] = hole1_P2;
                    SwitchHoles_P2[9] = hole2_P2;
                    SwitchHoles_P2[10] = hole3_P2;
                    SwitchHoles_P2[11] = hole4_P2;
                    SwitchHoles_P2[12] = hole5_P2;
                    SwitchHoles_P2[13] = hole6_P2;
                    SwitchHoles_P2[14] = hole7_P2;
                    SwitchHoles_P2[15] = hole8_P2;
                    SwitchHoles_P2[16] = hole9_P2;
                    SwitchHoles_P2[17] = hole10_P2;
                    SwitchHoles_P2[18] = hole11_P2;
                    break;
                case 13:

                    SwitchHoles_P1[1] = hole13_P1;
                    SwitchHoles_P1[2] = hole14_P1;
                    SwitchHoles_P1[3] = hole15_P1;
                    SwitchHoles_P1[4] = hole16_P1;
                    SwitchHoles_P1[5] = hole17_P1;
                    SwitchHoles_P1[6] = hole18_P1;
                    SwitchHoles_P1[7] = hole1_P1;
                    SwitchHoles_P1[8] = hole2_P1;
                    SwitchHoles_P1[9] = hole3_P1;
                    SwitchHoles_P1[10] = hole4_P1;
                    SwitchHoles_P1[11] = hole5_P1;
                    SwitchHoles_P1[12] = hole6_P1;
                    SwitchHoles_P1[13] = hole7_P1;
                    SwitchHoles_P1[14] = hole8_P1;
                    SwitchHoles_P1[15] = hole9_P1;
                    SwitchHoles_P1[16] = hole10_P1;
                    SwitchHoles_P1[17] = hole11_P1;
                    SwitchHoles_P1[18] = hole12_P1;

                    
                    break;
                case 14:

                    SwitchHoles_P1[1] = hole14_P1;
                    SwitchHoles_P1[2] = hole15_P1;
                    SwitchHoles_P1[3] = hole16_P1;
                    SwitchHoles_P1[4] = hole17_P1;
                    SwitchHoles_P1[5] = hole18_P1;
                    SwitchHoles_P1[6] = hole1_P1;
                    SwitchHoles_P1[7] = hole2_P1;
                    SwitchHoles_P1[8] = hole3_P1;
                    SwitchHoles_P1[9] = hole4_P1;
                    SwitchHoles_P1[10] = hole5_P1;
                    SwitchHoles_P1[11] = hole6_P1;
                    SwitchHoles_P1[12] = hole7_P1;
                    SwitchHoles_P1[13] = hole8_P1;
                    SwitchHoles_P1[14] = hole9_P1;
                    SwitchHoles_P1[15] = hole10_P1;
                    SwitchHoles_P1[16] = hole11_P1;
                    SwitchHoles_P1[17] = hole12_P1;
                    SwitchHoles_P1[18] = hole13_P1;

                    SwitchHoles_P2[1] = hole14_P2;
                    SwitchHoles_P2[2] = hole15_P2;
                    SwitchHoles_P2[3] = hole16_P2;
                    SwitchHoles_P2[4] = hole17_P2;
                    SwitchHoles_P2[5] = hole18_P2;
                    SwitchHoles_P2[6] = hole1_P2;
                    SwitchHoles_P2[7] = hole2_P2;
                    SwitchHoles_P2[8] = hole3_P2;
                    SwitchHoles_P2[9] = hole4_P2;
                    SwitchHoles_P2[10] = hole5_P2;
                    SwitchHoles_P2[11] = hole6_P2;
                    SwitchHoles_P2[12] = hole7_P2;
                    SwitchHoles_P2[13] = hole8_P2;
                    SwitchHoles_P2[14] = hole9_P2;
                    SwitchHoles_P2[15] = hole10_P2;
                    SwitchHoles_P2[16] = hole11_P2;
                    SwitchHoles_P2[17] = hole12_P2;
                    SwitchHoles_P2[18] = hole13_P2;

                    break;
                case 15:

                    SwitchHoles_P1[1] = hole15_P1;
                    SwitchHoles_P1[2] = hole16_P1;
                    SwitchHoles_P1[3] = hole17_P1;
                    SwitchHoles_P1[4] = hole18_P1;
                    SwitchHoles_P1[5] = hole1_P1;
                    SwitchHoles_P1[6] = hole2_P1;
                    SwitchHoles_P1[7] = hole3_P1;
                    SwitchHoles_P1[8] = hole4_P1;
                    SwitchHoles_P1[9] = hole5_P1;
                    SwitchHoles_P1[10] = hole6_P1;
                    SwitchHoles_P1[11] = hole7_P1;
                    SwitchHoles_P1[12] = hole8_P1;
                    SwitchHoles_P1[13] = hole9_P1;
                    SwitchHoles_P1[14] = hole10_P1;
                    SwitchHoles_P1[15] = hole11_P1;
                    SwitchHoles_P1[16] = hole12_P1;
                    SwitchHoles_P1[17] = hole13_P1;
                    SwitchHoles_P1[18] = hole14_P1;

                    SwitchHoles_P2[1] = hole15_P2;
                    SwitchHoles_P2[2] = hole16_P2;
                    SwitchHoles_P2[3] = hole17_P2;
                    SwitchHoles_P2[4] = hole18_P2;
                    SwitchHoles_P2[5] = hole1_P2;
                    SwitchHoles_P2[6] = hole2_P2;
                    SwitchHoles_P2[7] = hole3_P2;
                    SwitchHoles_P2[8] = hole4_P2;
                    SwitchHoles_P2[9] = hole5_P2;
                    SwitchHoles_P2[10] = hole6_P2;
                    SwitchHoles_P2[11] = hole7_P2;
                    SwitchHoles_P2[12] = hole8_P2;
                    SwitchHoles_P2[13] = hole9_P2;
                    SwitchHoles_P2[14] = hole10_P2;
                    SwitchHoles_P2[15] = hole11_P2;
                    SwitchHoles_P2[16] = hole12_P2;
                    SwitchHoles_P2[17] = hole13_P2;
                    SwitchHoles_P2[18] = hole14_P2;

                    break;
                case 16:

                    SwitchHoles_P1[1] = hole16_P1;
                    SwitchHoles_P1[2] = hole17_P1;
                    SwitchHoles_P1[3] = hole18_P1;
                    SwitchHoles_P1[4] = hole1_P1;
                    SwitchHoles_P1[5] = hole2_P1;
                    SwitchHoles_P1[6] = hole3_P1;
                    SwitchHoles_P1[7] = hole4_P1;
                    SwitchHoles_P1[8] = hole5_P1;
                    SwitchHoles_P1[9] = hole6_P1;
                    SwitchHoles_P1[10] = hole7_P1;
                    SwitchHoles_P1[11] = hole8_P1;
                    SwitchHoles_P1[12] = hole9_P1;
                    SwitchHoles_P1[13] = hole10_P1;
                    SwitchHoles_P1[14] = hole11_P1;
                    SwitchHoles_P1[15] = hole12_P1;
                    SwitchHoles_P1[16] = hole13_P1;
                    SwitchHoles_P1[17] = hole14_P1;
                    SwitchHoles_P1[18] = hole15_P1;

                    SwitchHoles_P2[1] = hole16_P2;
                    SwitchHoles_P2[2] = hole17_P2;
                    SwitchHoles_P2[3] = hole18_P2;
                    SwitchHoles_P2[4] = hole1_P2;
                    SwitchHoles_P2[5] = hole2_P2;
                    SwitchHoles_P2[6] = hole3_P2;
                    SwitchHoles_P2[7] = hole4_P2;
                    SwitchHoles_P2[8] = hole5_P2;
                    SwitchHoles_P2[9] = hole6_P2;
                    SwitchHoles_P2[10] = hole7_P2;
                    SwitchHoles_P2[11] = hole8_P2;
                    SwitchHoles_P2[12] = hole9_P2;
                    SwitchHoles_P2[13] = hole10_P2;
                    SwitchHoles_P2[14] = hole11_P2;
                    SwitchHoles_P2[15] = hole12_P2;
                    SwitchHoles_P2[16] = hole13_P2;
                    SwitchHoles_P2[17] = hole14_P2;
                    SwitchHoles_P2[18] = hole15_P2;

                   
                    break;
                case 17:

                    SwitchHoles_P1[1] = hole17_P1;
                    SwitchHoles_P1[2] = hole18_P1;
                    SwitchHoles_P1[3] = hole1_P1;
                    SwitchHoles_P1[4] = hole2_P1;
                    SwitchHoles_P1[5] = hole3_P1;
                    SwitchHoles_P1[6] = hole4_P1;
                    SwitchHoles_P1[7] = hole5_P1;
                    SwitchHoles_P1[8] = hole6_P1;
                    SwitchHoles_P1[9] = hole7_P1;
                    SwitchHoles_P1[10] = hole8_P1;
                    SwitchHoles_P1[11] = hole9_P1;
                    SwitchHoles_P1[12] = hole10_P1;
                    SwitchHoles_P1[13] = hole11_P1;
                    SwitchHoles_P1[14] = hole12_P1;
                    SwitchHoles_P1[15] = hole13_P1;
                    SwitchHoles_P1[16] = hole14_P1;
                    SwitchHoles_P1[17] = hole15_P1;
                    SwitchHoles_P1[18] = hole16_P1;

                    SwitchHoles_P2[1] = hole17_P2;
                    SwitchHoles_P2[2] = hole18_P2;
                    SwitchHoles_P2[3] = hole1_P2;
                    SwitchHoles_P2[4] = hole2_P2;
                    SwitchHoles_P2[5] = hole3_P2;
                    SwitchHoles_P2[6] = hole4_P2;
                    SwitchHoles_P2[7] = hole5_P2;
                    SwitchHoles_P2[8] = hole6_P2;
                    SwitchHoles_P2[9] = hole7_P2;
                    SwitchHoles_P2[10] = hole8_P2;
                    SwitchHoles_P2[11] = hole9_P2;
                    SwitchHoles_P2[12] = hole10_P2;
                    SwitchHoles_P2[13] = hole11_P2;
                    SwitchHoles_P2[14] = hole12_P2;
                    SwitchHoles_P2[15] = hole13_P2;
                    SwitchHoles_P2[16] = hole14_P2;
                    SwitchHoles_P2[17] = hole15_P2;
                    SwitchHoles_P2[18] = hole16_P2;


                    break;
                case 18:

                    SwitchHoles_P1[1] = hole18_P1;
                    SwitchHoles_P1[2] = hole1_P1;
                    SwitchHoles_P1[3] = hole2_P1;
                    SwitchHoles_P1[4] = hole3_P1;
                    SwitchHoles_P1[5] = hole4_P1;
                    SwitchHoles_P1[6] = hole5_P1;
                    SwitchHoles_P1[7] = hole6_P1;
                    SwitchHoles_P1[8] = hole7_P1;
                    SwitchHoles_P1[9] = hole8_P1;
                    SwitchHoles_P1[10] = hole9_P1;
                    SwitchHoles_P1[11] = hole10_P1;
                    SwitchHoles_P1[12] = hole11_P1;
                    SwitchHoles_P1[13] = hole12_P1;
                    SwitchHoles_P1[14] = hole13_P1;
                    SwitchHoles_P1[15] = hole14_P1;
                    SwitchHoles_P1[16] = hole15_P1;
                    SwitchHoles_P1[17] = hole16_P1;
                    SwitchHoles_P1[18] = hole17_P1;

                    SwitchHoles_P2[1] = hole18_P2;
                    SwitchHoles_P2[2] = hole1_P2;
                    SwitchHoles_P2[3] = hole2_P2;
                    SwitchHoles_P2[4] = hole3_P2;
                    SwitchHoles_P2[5] = hole4_P2;
                    SwitchHoles_P2[6] = hole5_P2;
                    SwitchHoles_P2[7] = hole6_P2;
                    SwitchHoles_P2[8] = hole7_P2;
                    SwitchHoles_P2[9] = hole8_P2;
                    SwitchHoles_P2[10] = hole9_P2;
                    SwitchHoles_P2[11] = hole10_P2;
                    SwitchHoles_P2[12] = hole11_P2;
                    SwitchHoles_P2[13] = hole12_P2;
                    SwitchHoles_P2[14] = hole13_P2;
                    SwitchHoles_P2[15] = hole14_P2;
                    SwitchHoles_P2[16] = hole15_P2;
                    SwitchHoles_P2[17] = hole16_P2;
                    SwitchHoles_P2[18] = hole17_P2;


                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            SwitchHoles[1] = SwitchHoles_P1[1];
            SwitchHoles[2] = SwitchHoles_P1[2];
            SwitchHoles[3] = SwitchHoles_P1[3];
            SwitchHoles[4] = SwitchHoles_P1[4];
            SwitchHoles[5] = SwitchHoles_P1[5];
            SwitchHoles[6] = SwitchHoles_P1[6];
            SwitchHoles[7] = SwitchHoles_P1[7];
            SwitchHoles[8] = SwitchHoles_P1[8];
            SwitchHoles[9] = SwitchHoles_P1[9];
            SwitchHoles[10] = SwitchHoles_P1[10];
            SwitchHoles[11] = SwitchHoles_P1[11];
            SwitchHoles[12] = SwitchHoles_P1[12];
            SwitchHoles[13] = SwitchHoles_P1[13];
            SwitchHoles[14] = SwitchHoles_P1[14];
            SwitchHoles[15] = SwitchHoles_P1[15];
            SwitchHoles[16] = SwitchHoles_P1[16];
            SwitchHoles[17] = SwitchHoles_P1[17];
            SwitchHoles[18] = SwitchHoles_P1[18];

            SwitchHoles[19] = SwitchHoles_P2[1];
            SwitchHoles[20] = SwitchHoles_P2[2];
            SwitchHoles[21] = SwitchHoles_P2[3];
            SwitchHoles[22] = SwitchHoles_P2[4];
            SwitchHoles[23] = SwitchHoles_P2[5];
            SwitchHoles[24] = SwitchHoles_P2[6];
            SwitchHoles[25] = SwitchHoles_P2[7];
            SwitchHoles[26] = SwitchHoles_P2[8];
            SwitchHoles[27] = SwitchHoles_P2[9];
            SwitchHoles[28] = SwitchHoles_P2[10];
            SwitchHoles[29] = SwitchHoles_P2[11];
            SwitchHoles[30] = SwitchHoles_P2[12];
            SwitchHoles[31] = SwitchHoles_P2[13];
            SwitchHoles[32] = SwitchHoles_P2[14];
            SwitchHoles[33] = SwitchHoles_P2[15];
            SwitchHoles[34] = SwitchHoles_P2[16];
            SwitchHoles[35] = SwitchHoles_P2[17];
            SwitchHoles[36] = SwitchHoles_P2[18];

            return SwitchHoles;
        }

        #endregion

    }
}
