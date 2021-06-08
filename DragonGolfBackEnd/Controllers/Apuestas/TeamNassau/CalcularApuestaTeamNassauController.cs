using DragonGolfBackEnd.Clases;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Cors;


namespace DragonGolfBackEnd.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/CalcularApuestaTeamNassau")]
    public class CalcularApuestaTeamNassauController : ApiController
    {

        public class ParametrosEntrada
        {
            public int IDBet { get; set; }
            public int IDRonda { get; set; }
            public int IDBetDetail { get; set; }
        }

        public class ParametrosSalida
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
            public int ScoreHole1_P3 { get; set; }
            public int ScoreHole2_P3 { get; set; }
            public int ScoreHole3_P3 { get; set; }
            public int ScoreHole4_P3 { get; set; }
            public int ScoreHole5_P3 { get; set; }
            public int ScoreHole6_P3 { get; set; }
            public int ScoreHole7_P3 { get; set; }
            public int ScoreHole8_P3 { get; set; }
            public int ScoreHole9_P3 { get; set; }
            public int ScoreHole10_P3 { get; set; }
            public int ScoreHole11_P3 { get; set; }
            public int ScoreHole12_P3 { get; set; }
            public int ScoreHole13_P3 { get; set; }
            public int ScoreHole14_P3 { get; set; }
            public int ScoreHole15_P3 { get; set; }
            public int ScoreHole16_P3 { get; set; }
            public int ScoreHole17_P3 { get; set; }
            public int ScoreHole18_P3 { get; set; }
            public int ScoreHole1_P4 { get; set; }
            public int ScoreHole2_P4 { get; set; }
            public int ScoreHole3_P4 { get; set; }
            public int ScoreHole4_P4 { get; set; }
            public int ScoreHole5_P4 { get; set; }
            public int ScoreHole6_P4 { get; set; }
            public int ScoreHole7_P4 { get; set; }
            public int ScoreHole8_P4 { get; set; }
            public int ScoreHole9_P4 { get; set; }
            public int ScoreHole10_P4 { get; set; }
            public int ScoreHole11_P4 { get; set; }
            public int ScoreHole12_P4 { get; set; }
            public int ScoreHole13_P4 { get; set; }
            public int ScoreHole14_P4 { get; set; }
            public int ScoreHole15_P4 { get; set; }
            public int ScoreHole16_P4 { get; set; }
            public int ScoreHole17_P4 { get; set; }
            public int ScoreHole18_P4 { get; set; }
            public int PlayerID1 { get; set; }
            public int PlayerID2 { get; set; }
            public int PlayerID3 { get; set; }
            public int PlayerID4 { get; set; }
            public int AutoPress { get; set; }
        }

        public JObject Post(ParametrosEntrada Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_CalculateBet_TeamNassau");
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

                string Mensaje = "";
                int Estatus = 0;

                int ScoreHole1_P1 = 0;
                int ScoreHole2_P1 = 0;
                int ScoreHole3_P1 = 0;
                int ScoreHole4_P1 = 0;
                int ScoreHole5_P1 = 0;
                int ScoreHole6_P1 = 0;
                int ScoreHole7_P1 = 0;
                int ScoreHole8_P1 = 0;
                int ScoreHole9_P1 = 0;
                int ScoreHole10_P1 = 0;
                int ScoreHole11_P1 = 0;
                int ScoreHole12_P1 = 0;
                int ScoreHole13_P1 = 0;
                int ScoreHole14_P1 = 0;
                int ScoreHole15_P1 = 0;
                int ScoreHole16_P1 = 0;
                int ScoreHole17_P1 = 0;
                int ScoreHole18_P1 = 0;

                int ScoreHole1_P2 = 0;
                int ScoreHole2_P2 = 0;
                int ScoreHole3_P2 = 0;
                int ScoreHole4_P2 = 0;
                int ScoreHole5_P2 = 0;
                int ScoreHole6_P2 = 0;
                int ScoreHole7_P2 = 0;
                int ScoreHole8_P2 = 0;
                int ScoreHole9_P2 = 0;
                int ScoreHole10_P2 = 0;
                int ScoreHole11_P2 = 0;
                int ScoreHole12_P2 = 0;
                int ScoreHole13_P2 = 0;
                int ScoreHole14_P2 = 0;
                int ScoreHole15_P2 = 0;
                int ScoreHole16_P2 = 0;
                int ScoreHole17_P2 = 0;
                int ScoreHole18_P2 = 0;

                int ScoreHole1_P3 = 0;
                int ScoreHole2_P3 = 0;
                int ScoreHole3_P3 = 0;
                int ScoreHole4_P3 = 0;
                int ScoreHole5_P3 = 0;
                int ScoreHole6_P3 = 0;
                int ScoreHole7_P3 = 0;
                int ScoreHole8_P3 = 0;
                int ScoreHole9_P3 = 0;
                int ScoreHole10_P3 = 0;
                int ScoreHole11_P3 = 0;
                int ScoreHole12_P3 = 0;
                int ScoreHole13_P3 = 0;
                int ScoreHole14_P3 = 0;
                int ScoreHole15_P3 = 0;
                int ScoreHole16_P3 = 0;
                int ScoreHole17_P3 = 0;
                int ScoreHole18_P3 = 0;

                int ScoreHole1_P4 = 0;
                int ScoreHole2_P4 = 0;
                int ScoreHole3_P4 = 0;
                int ScoreHole4_P4 = 0;
                int ScoreHole5_P4 = 0;
                int ScoreHole6_P4 = 0;
                int ScoreHole7_P4 = 0;
                int ScoreHole8_P4 = 0;
                int ScoreHole9_P4 = 0;
                int ScoreHole10_P4 = 0;
                int ScoreHole11_P4 = 0;
                int ScoreHole12_P4 = 0;
                int ScoreHole13_P4 = 0;
                int ScoreHole14_P4 = 0;
                int ScoreHole15_P4 = 0;
                int ScoreHole16_P4 = 0;
                int ScoreHole17_P4 = 0;
                int ScoreHole18_P4 = 0;

                int PlayerID1 = 0;
                int PlayerID2 = 0;
                int PlayerID3 = 0;
                int PlayerID4 = 0;
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

                double HandicapP1 = 0;
                double HandicapP2 = 0;
                double HandicapP3 = 0;
                double HandicapP4 = 0;

                string TipoGolpesVentaja = "";

                double Adv = 0;

                string[] ResultFront = new string[9];
                string[] ResultBack = new string[9];

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
                        HoyoInicial = Convert.ToInt32(row["HoyoInicial"]);

                        bool InicioPartida1 = Convert.ToBoolean(row["InicioPartida1"]);
                        bool InicioPartida2 = Convert.ToBoolean(row["InicioPartida2"]);
                        bool InicioPartida3 = Convert.ToBoolean(row["InicioPartida3"]);
                        bool InicioPartida4 = Convert.ToBoolean(row["InicioPartida4"]);

                        if (InicioPartida1 == false && InicioPartida2 == false && InicioPartida3 == false
                            && InicioPartida4 == false)
                        {

                            JObject Res1 = JObject.FromObject(new
                            {
                                mensaje = "Aun no se inicia la ronda",
                                estatus = 0,

                            });

                            return Res1;
                        }

                        ScoreHole1_P1 = Convert.ToInt32(row["ScoreHole1_P1"]);
                        ScoreHole2_P1 = Convert.ToInt32(row["ScoreHole2_P1"]);
                        ScoreHole3_P1 = Convert.ToInt32(row["ScoreHole3_P1"]);
                        ScoreHole4_P1 = Convert.ToInt32(row["ScoreHole4_P1"]);
                        ScoreHole5_P1 = Convert.ToInt32(row["ScoreHole5_P1"]);
                        ScoreHole6_P1 = Convert.ToInt32(row["ScoreHole6_P1"]);
                        ScoreHole7_P1 = Convert.ToInt32(row["ScoreHole7_P1"]);
                        ScoreHole8_P1 = Convert.ToInt32(row["ScoreHole8_P1"]);
                        ScoreHole9_P1 = Convert.ToInt32(row["ScoreHole9_P1"]);
                        ScoreHole10_P1 = Convert.ToInt32(row["ScoreHole10_P1"]);
                        ScoreHole11_P1 = Convert.ToInt32(row["ScoreHole11_P1"]);
                        ScoreHole12_P1 = Convert.ToInt32(row["ScoreHole12_P1"]);
                        ScoreHole13_P1 = Convert.ToInt32(row["ScoreHole13_P1"]);
                        ScoreHole14_P1 = Convert.ToInt32(row["ScoreHole14_P1"]);
                        ScoreHole15_P1 = Convert.ToInt32(row["ScoreHole15_P1"]);
                        ScoreHole16_P1 = Convert.ToInt32(row["ScoreHole16_P1"]);
                        ScoreHole17_P1 = Convert.ToInt32(row["ScoreHole17_P1"]);
                        ScoreHole18_P1 = Convert.ToInt32(row["ScoreHole18_P1"]);

                        ScoreHole1_P2 = Convert.ToInt32(row["ScoreHole1_P2"]);
                        ScoreHole2_P2 = Convert.ToInt32(row["ScoreHole2_P2"]);
                        ScoreHole3_P2 = Convert.ToInt32(row["ScoreHole3_P2"]);
                        ScoreHole4_P2 = Convert.ToInt32(row["ScoreHole4_P2"]);
                        ScoreHole5_P2 = Convert.ToInt32(row["ScoreHole5_P2"]);
                        ScoreHole6_P2 = Convert.ToInt32(row["ScoreHole6_P2"]);
                        ScoreHole7_P2 = Convert.ToInt32(row["ScoreHole7_P2"]);
                        ScoreHole8_P2 = Convert.ToInt32(row["ScoreHole8_P2"]);
                        ScoreHole9_P2 = Convert.ToInt32(row["ScoreHole9_P2"]);
                        ScoreHole10_P2 = Convert.ToInt32(row["ScoreHole10_P2"]);
                        ScoreHole11_P2 = Convert.ToInt32(row["ScoreHole11_P2"]);
                        ScoreHole12_P2 = Convert.ToInt32(row["ScoreHole12_P2"]);
                        ScoreHole13_P2 = Convert.ToInt32(row["ScoreHole13_P2"]);
                        ScoreHole14_P2 = Convert.ToInt32(row["ScoreHole14_P2"]);
                        ScoreHole15_P2 = Convert.ToInt32(row["ScoreHole15_P2"]);
                        ScoreHole16_P2 = Convert.ToInt32(row["ScoreHole16_P2"]);
                        ScoreHole17_P2 = Convert.ToInt32(row["ScoreHole17_P2"]);
                        ScoreHole18_P2 = Convert.ToInt32(row["ScoreHole18_P2"]);

                        ScoreHole1_P3 = Convert.ToInt32(row["ScoreHole1_P3"]);
                        ScoreHole2_P3 = Convert.ToInt32(row["ScoreHole2_P3"]);
                        ScoreHole3_P3 = Convert.ToInt32(row["ScoreHole3_P3"]);
                        ScoreHole4_P3 = Convert.ToInt32(row["ScoreHole4_P3"]);
                        ScoreHole5_P3 = Convert.ToInt32(row["ScoreHole5_P3"]);
                        ScoreHole6_P3 = Convert.ToInt32(row["ScoreHole6_P3"]);
                        ScoreHole7_P3 = Convert.ToInt32(row["ScoreHole7_P3"]);
                        ScoreHole8_P3 = Convert.ToInt32(row["ScoreHole8_P3"]);
                        ScoreHole9_P3 = Convert.ToInt32(row["ScoreHole9_P3"]);
                        ScoreHole10_P3 = Convert.ToInt32(row["ScoreHole10_P3"]);
                        ScoreHole11_P3 = Convert.ToInt32(row["ScoreHole11_P3"]);
                        ScoreHole12_P3 = Convert.ToInt32(row["ScoreHole12_P3"]);
                        ScoreHole13_P3 = Convert.ToInt32(row["ScoreHole13_P3"]);
                        ScoreHole14_P3 = Convert.ToInt32(row["ScoreHole14_P3"]);
                        ScoreHole15_P3 = Convert.ToInt32(row["ScoreHole15_P3"]);
                        ScoreHole16_P3 = Convert.ToInt32(row["ScoreHole16_P3"]);
                        ScoreHole17_P3 = Convert.ToInt32(row["ScoreHole17_P3"]);
                        ScoreHole18_P3 = Convert.ToInt32(row["ScoreHole18_P3"]);

                        ScoreHole1_P4 = Convert.ToInt32(row["ScoreHole1_P4"]);
                        ScoreHole2_P4 = Convert.ToInt32(row["ScoreHole2_P4"]);
                        ScoreHole3_P4 = Convert.ToInt32(row["ScoreHole3_P4"]);
                        ScoreHole4_P4 = Convert.ToInt32(row["ScoreHole4_P4"]);
                        ScoreHole5_P4 = Convert.ToInt32(row["ScoreHole5_P4"]);
                        ScoreHole6_P4 = Convert.ToInt32(row["ScoreHole6_P4"]);
                        ScoreHole7_P4 = Convert.ToInt32(row["ScoreHole7_P4"]);
                        ScoreHole8_P4 = Convert.ToInt32(row["ScoreHole8_P4"]);
                        ScoreHole9_P4 = Convert.ToInt32(row["ScoreHole9_P4"]);
                        ScoreHole10_P4 = Convert.ToInt32(row["ScoreHole10_P4"]);
                        ScoreHole11_P4 = Convert.ToInt32(row["ScoreHole11_P4"]);
                        ScoreHole12_P4 = Convert.ToInt32(row["ScoreHole12_P4"]);
                        ScoreHole13_P4 = Convert.ToInt32(row["ScoreHole13_P4"]);
                        ScoreHole14_P4 = Convert.ToInt32(row["ScoreHole14_P4"]);
                        ScoreHole15_P4 = Convert.ToInt32(row["ScoreHole15_P4"]);
                        ScoreHole16_P4 = Convert.ToInt32(row["ScoreHole16_P4"]);
                        ScoreHole17_P4 = Convert.ToInt32(row["ScoreHole17_P4"]);
                        ScoreHole18_P4 = Convert.ToInt32(row["ScoreHole18_P4"]);

                        PlayerID1 = Convert.ToInt32(row["PlayerID1"]);
                        PlayerID2 = Convert.ToInt32(row["PlayerID2"]);
                        PlayerID3 = Convert.ToInt32(row["PlayerID3"]);
                        PlayerID4 = Convert.ToInt32(row["PlayerID4"]);
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

                        TipoGolpesVentaja = Convert.ToString(row["TipoGolpesVentaja"]);

                        HandicapP1 = Convert.ToDouble(row["HandicapP1"]);
                        HandicapP2 = Convert.ToDouble(row["HandicapP2"]);
                        HandicapP3 = Convert.ToDouble(row["HandicapP3"]);
                        HandicapP4 = Convert.ToDouble(row["HandicapP4"]);

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

                        if (AdvInverso < 0)
                        {
                            //int AdvPositivo = (-1) * (AdvInverso);
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
                                        if (ScoreHole1_P1 > 0 && ScoreHole1_P2 > 0 && ScoreHole1_P3 > 0 && ScoreHole1_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole1_P1 = ScoreHole1_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole1_P3 = ScoreHole1_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole1_P1 = ScoreHole1_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole1_P3 = ScoreHole1_P3 - 1;
                                                }


                                            }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                              //El peor de los mejores
                                                string JugadorMejoresEquipo1 = "";
                                                string JugadorMejoresEquipo2 = "";

                                                string JugadorPeorEquipo1 = "";
                                                string JugadorPeorEquipo2 = "";

                                                double JugadorMejoresEquipo1Valor = 0;
                                                double JugadorMejoresEquipo2Valor = 0;

                                                double JugadorPeorEquipo1Valor = 0;
                                                double JugadorPeorEquipo2Valor = 0;

                                                if (HandicapP1 <= HandicapP3)
                                                {
                                                    JugadorMejoresEquipo1 = "Jugador 1";
                                                    JugadorMejoresEquipo1Valor = HandicapP1;

                                                    JugadorPeorEquipo1 = "Jugador 3";
                                                    JugadorPeorEquipo1Valor = HandicapP3;
                                                }
                                                else
                                                {
                                                    JugadorMejoresEquipo1 = "Jugador 3";
                                                    JugadorMejoresEquipo1Valor = HandicapP3;

                                                    JugadorPeorEquipo1 = "Jugador 1";
                                                    JugadorPeorEquipo1Valor = HandicapP1;
                                                }

                                                if (HandicapP2 <= HandicapP4)
                                                {
                                                    JugadorMejoresEquipo2 = "Jugador 2";
                                                    JugadorMejoresEquipo2Valor = HandicapP2;

                                                    JugadorPeorEquipo2 = "Jugador 4";
                                                    JugadorPeorEquipo2Valor = HandicapP4;

                                                }
                                                else
                                                {
                                                    JugadorMejoresEquipo2 = "Jugador 4";
                                                    JugadorMejoresEquipo2Valor = HandicapP4;

                                                    JugadorPeorEquipo2 = "Jugador 2";
                                                    JugadorPeorEquipo2Valor = HandicapP2;
                                                }

                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor)
                                                {
                                                    //JugadorMejoresEquipo1
                                                    if (JugadorMejoresEquipo1== "Jugador 1")
                                                    {
                                                        ScoreHole1_P1 = ScoreHole1_P1 - 1;
                                                    }
                                                    else
                                                    {
                                                        ScoreHole1_P3 = ScoreHole1_P3 - 1;

                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo2 == "Jugador 2")
                                                    {
                                                        ScoreHole1_P2 = ScoreHole1_P2 - 1;
                                                    }
                                                    else
                                                    {
                                                        ScoreHole1_P4 = ScoreHole1_P4 - 1;

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor)
                                                {
                                                    if (JugadorPeorEquipo1 == "Jugador 1")
                                                    {
                                                        ScoreHole1_P1 = ScoreHole1_P1 - 1;
                                                    }
                                                    else
                                                    {
                                                        ScoreHole1_P3 = ScoreHole1_P3 - 1;
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 2")
                                                    {
                                                        ScoreHole1_P2 = ScoreHole1_P2 - 1;
                                                    }
                                                    else
                                                    {
                                                        ScoreHole1_P4 = ScoreHole1_P4 - 1;
                                                    }

                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo2 == Contador)
                                    {
                                        if (ScoreHole2_P1 > 0 && ScoreHole2_P2 > 0 && ScoreHole3_P3 > 0 && ScoreHole4_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole2_P1 = ScoreHole2_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole2_P3 = ScoreHole2_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole2_P1 = ScoreHole2_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole2_P3 = ScoreHole2_P3 - 1;
                                                }


                                            }

                                        }

                                    }

                                    if (DificultatHoyo3 == Contador)
                                    {
                                        if (ScoreHole3_P1 > 0 && ScoreHole3_P2 > 0 && ScoreHole3_P3 > 0 && ScoreHole4_P4 > 0)
                                        {
                                            ScoreHole3_P1 = ScoreHole3_P1 - 1;

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole3_P1 = ScoreHole3_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole3_P3 = ScoreHole3_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole3_P1 = ScoreHole3_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole3_P3 = ScoreHole3_P3 - 1;
                                                }


                                            }


                                        }

                                    }

                                    if (DificultatHoyo4 == Contador)
                                    {
                                        if (ScoreHole4_P1 > 0 && ScoreHole4_P2 > 0 && ScoreHole4_P3 > 0 && ScoreHole4_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole4_P1 = ScoreHole4_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole4_P3 = ScoreHole4_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole4_P1 = ScoreHole4_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole4_P3 = ScoreHole4_P3 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo5 == Contador)
                                    {
                                        if (ScoreHole5_P1 > 0 && ScoreHole5_P2 > 0 && ScoreHole5_P3 > 0 && ScoreHole5_P4 > 0)
                                        {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole5_P1 = ScoreHole5_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole5_P3 = ScoreHole5_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole5_P1 = ScoreHole5_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole5_P3 = ScoreHole5_P3 - 1;
                                                }


                                            }

                                        }

                                    }

                                    if (DificultatHoyo6 == Contador)
                                    {
                                        if (ScoreHole6_P1 > 0 && ScoreHole6_P2 > 0 && ScoreHole5_P3 > 0 && ScoreHole5_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole6_P1 = ScoreHole6_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole6_P3 = ScoreHole6_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole6_P1 = ScoreHole6_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole6_P3 = ScoreHole6_P3 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo7 == Contador)
                                    {
                                        if (ScoreHole7_P1 > 0 && ScoreHole7_P2 > 0 && ScoreHole7_P3 > 0 && ScoreHole7_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole7_P1 = ScoreHole7_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole7_P3 = ScoreHole7_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole7_P1 = ScoreHole7_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole7_P3 = ScoreHole7_P3 - 1;
                                                }


                                            }

                                        }

                                    }

                                    if (DificultatHoyo8 == Contador)
                                    {
                                        if (ScoreHole8_P1 > 0 && ScoreHole8_P2 > 0 && ScoreHole8_P3 > 0 && ScoreHole8_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole8_P1 = ScoreHole8_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole8_P3 = ScoreHole8_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole8_P1 = ScoreHole8_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole8_P3 = ScoreHole8_P3 - 1;
                                                }

                                            }


                                        }

                                    }

                                    if (DificultatHoyo9 == Contador)
                                    {
                                        if (ScoreHole9_P1 > 0 && ScoreHole9_P2 > 0 && ScoreHole9_P3 > 0 && ScoreHole9_P4 > 0)
                                        {
                                            // ScoreHole9_P1 = ScoreHole9_P1 - 1;


                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole9_P1 = ScoreHole9_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole9_P3 = ScoreHole9_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole9_P1 = ScoreHole9_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole9_P3 = ScoreHole9_P3 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo10 == Contador)
                                    {
                                        if (ScoreHole10_P1 > 0 && ScoreHole10_P2 > 0 && ScoreHole10_P3 > 0 && ScoreHole10_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole10_P1 = ScoreHole10_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole10_P3 = ScoreHole10_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole10_P1 = ScoreHole10_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole10_P3 = ScoreHole10_P3 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo11 == Contador)
                                    {
                                        if (ScoreHole11_P1 > 0 && ScoreHole11_P2 > 0 && ScoreHole11_P3 > 0 && ScoreHole11_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {
                                                    ScoreHole11_P1 = ScoreHole11_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole11_P3 = ScoreHole11_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole11_P1 = ScoreHole11_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole11_P3 = ScoreHole11_P3 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo12 == Contador)
                                    {
                                        if (ScoreHole12_P1 > 0 && ScoreHole12_P2 > 0 && ScoreHole12_P3 > 0 && ScoreHole12_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole12_P1 = ScoreHole12_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole12_P3 = ScoreHole12_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole12_P1 = ScoreHole12_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole12_P3 = ScoreHole12_P3 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo13 == Contador)
                                    {
                                        if (ScoreHole13_P1 > 0 && ScoreHole13_P2 > 0 && ScoreHole13_P3 > 0 && ScoreHole13_P4 > 0)
                                        {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole13_P1 = ScoreHole13_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole13_P3 = ScoreHole13_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole13_P1 = ScoreHole13_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole13_P3 = ScoreHole13_P3 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo14 == Contador)
                                    {
                                        if (ScoreHole14_P1 > 0 && ScoreHole14_P2 > 0 && ScoreHole14_P3 > 0 && ScoreHole14_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole14_P1 = ScoreHole14_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole14_P3 = ScoreHole14_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole14_P1 = ScoreHole14_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole14_P3 = ScoreHole14_P3 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo15 == Contador)
                                    {
                                        if (ScoreHole15_P1 > 0 && ScoreHole15_P2 > 0 && ScoreHole15_P3 > 0 && ScoreHole15_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole15_P1 = ScoreHole15_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole15_P3 = ScoreHole15_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole15_P1 = ScoreHole15_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole15_P3 = ScoreHole15_P3 - 1;
                                                }

                                            }
                                        }
                                    }

                                    if (DificultatHoyo16 == Contador)
                                    {
                                        if (ScoreHole16_P1 > 0 && ScoreHole16_P2 > 0 && ScoreHole16_P3 > 0 && ScoreHole16_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole16_P1 = ScoreHole16_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole16_P3 = ScoreHole16_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole16_P1 = ScoreHole16_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole16_P3 = ScoreHole16_P3 - 1;
                                                }

                                            }
                                        }
                                    }

                                    if (DificultatHoyo17 == Contador)
                                    {
                                        if (ScoreHole17_P1 > 0 && ScoreHole17_P2 > 0 && ScoreHole17_P3 > 0 && ScoreHole17_P4 > 0)
                                        {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole17_P1 = ScoreHole17_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole17_P3 = ScoreHole17_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole17_P1 = ScoreHole17_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole17_P3 = ScoreHole17_P3 - 1;
                                                }

                                            }
                                        }
                                    }

                                    if (DificultatHoyo18 == Contador)
                                    {
                                        if (ScoreHole18_P1 > 0 && ScoreHole18_P2 > 0 && ScoreHole18_P3 > 0 && ScoreHole18_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3)
                                                {

                                                    ScoreHole18_P1 = ScoreHole18_P1 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole18_P3 = ScoreHole18_P3 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3)
                                                {
                                                    ScoreHole18_P1 = ScoreHole18_P1 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole18_P3 = ScoreHole18_P3 - 1;
                                                }

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
                            int CicloFor = 18;

                            double AdvPositivo = (-1) * (Adv);
                            int AdvPositivo2 = (-1) * (AdvInverso2);

                            if (AdvPositivo >= AdvPositivo2)
                            {
                                ValCompleto = 0.5;
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

                                        if (ScoreHole1_P2 > 0 && ScoreHole1_P1 > 0 && ScoreHole1_P3 > 0 && ScoreHole1_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole1_P2 = ScoreHole1_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole1_P4 = ScoreHole1_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole1_P2 = ScoreHole1_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole1_P4 = ScoreHole1_P4 - 1;
                                                }


                                            }


                                        }


                                    }

                                    if (DificultatHoyo2 == Contador)
                                    {
                                        if (ScoreHole2_P2 > 0 && ScoreHole2_P1 > 0 && ScoreHole2_P3 > 0 && ScoreHole2_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole2_P2 = ScoreHole2_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole2_P4 = ScoreHole2_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole2_P2 = ScoreHole2_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole2_P4 = ScoreHole2_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo3 == Contador)
                                    {
                                        if (ScoreHole3_P2 > 0 && ScoreHole3_P1 > 0 && ScoreHole3_P3 > 0 && ScoreHole3_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole3_P2 = ScoreHole3_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole3_P4 = ScoreHole3_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole3_P2 = ScoreHole3_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole3_P4 = ScoreHole3_P4 - 1;
                                                }

                                            }
                                        }

                                    }

                                    if (DificultatHoyo4 == Contador)
                                    {
                                        if (ScoreHole4_P2 > 0 && ScoreHole4_P1 > 0 && ScoreHole4_P3 > 0 && ScoreHole4_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole4_P2 = ScoreHole4_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole4_P4 = ScoreHole4_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole4_P2 = ScoreHole4_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole4_P4 = ScoreHole4_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo5 == Contador)
                                    {
                                        if (ScoreHole5_P2 > 0 && ScoreHole5_P1 > 0 && ScoreHole5_P3 > 0 && ScoreHole5_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole5_P2 = ScoreHole5_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole5_P4 = ScoreHole5_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole5_P2 = ScoreHole5_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole5_P4 = ScoreHole5_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo6 == Contador)
                                    {
                                        if (ScoreHole6_P2 > 0 && ScoreHole6_P1 > 0 && ScoreHole6_P3 > 0 && ScoreHole6_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole6_P2 = ScoreHole6_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole6_P4 = ScoreHole6_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole6_P2 = ScoreHole6_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole6_P4 = ScoreHole6_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo7 == Contador)
                                    {
                                        if (ScoreHole7_P2 > 0 && ScoreHole7_P1 > 0 && ScoreHole7_P3 > 0 && ScoreHole7_P4 > 0)
                                        {


                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole7_P2 = ScoreHole7_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole7_P4 = ScoreHole7_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole7_P2 = ScoreHole7_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole7_P4 = ScoreHole7_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo8 == Contador)
                                    {
                                        if (ScoreHole8_P2 > 0 && ScoreHole8_P1 > 0 && ScoreHole8_P3 > 0 && ScoreHole8_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole8_P2 = ScoreHole8_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole8_P4 = ScoreHole8_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole8_P2 = ScoreHole8_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole8_P4 = ScoreHole8_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo9 == Contador)
                                    {
                                        if (ScoreHole9_P2 > 0 && ScoreHole9_P1 > 0 && ScoreHole9_P3 > 0 && ScoreHole9_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole9_P2 = ScoreHole9_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole9_P4 = ScoreHole9_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole9_P2 = ScoreHole9_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole9_P4 = ScoreHole9_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo10 == Contador)
                                    {
                                        if (ScoreHole10_P2 > 0 && ScoreHole10_P1 > 0 && ScoreHole10_P3 > 0 && ScoreHole10_P4 > 0)
                                        {
                                            ScoreHole10_P2 = ScoreHole10_P2 - 1;

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole10_P2 = ScoreHole10_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole10_P4 = ScoreHole10_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole10_P2 = ScoreHole10_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole10_P4 = ScoreHole10_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo11 == Contador)
                                    {
                                        if (ScoreHole11_P2 > 0 && ScoreHole11_P1 > 0 && ScoreHole11_P3 > 0 && ScoreHole11_P4 > 0)
                                        {
                                            ScoreHole11_P2 = ScoreHole11_P2 - 1;


                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole11_P2 = ScoreHole11_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole11_P4 = ScoreHole11_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole11_P2 = ScoreHole11_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole11_P4 = ScoreHole11_P4 - 1;
                                                }


                                            }

                                        }

                                    }

                                    if (DificultatHoyo12 == Contador)
                                    {
                                        if (ScoreHole12_P2 > 0 && ScoreHole12_P1 > 0 && ScoreHole12_P3 > 0 && ScoreHole12_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole12_P2 = ScoreHole12_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole12_P4 = ScoreHole12_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole12_P2 = ScoreHole12_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole12_P4 = ScoreHole12_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo13 == Contador)
                                    {
                                        if (ScoreHole13_P2 > 0 && ScoreHole13_P1 > 0 && ScoreHole13_P3 > 0 && ScoreHole13_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole13_P2 = ScoreHole13_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole13_P4 = ScoreHole13_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole13_P2 = ScoreHole13_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole13_P4 = ScoreHole13_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo14 == Contador)
                                    {
                                        if (ScoreHole14_P2 > 0 && ScoreHole14_P1 > 0 && ScoreHole14_P3 > 0 && ScoreHole14_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole14_P2 = ScoreHole14_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole14_P4 = ScoreHole14_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole14_P2 = ScoreHole14_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole14_P4 = ScoreHole14_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo15 == Contador)
                                    {
                                        if (ScoreHole15_P2 > 0 && ScoreHole15_P1 > 0 && ScoreHole15_P3 > 0 && ScoreHole15_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole15_P2 = ScoreHole15_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole15_P4 = ScoreHole15_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole15_P2 = ScoreHole15_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole15_P4 = ScoreHole15_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo16 == Contador)
                                    {
                                        if (ScoreHole16_P2 > 0 && ScoreHole16_P1 > 0 && ScoreHole16_P3 > 0 && ScoreHole16_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole16_P2 = ScoreHole16_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole16_P4 = ScoreHole16_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole16_P2 = ScoreHole16_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole16_P4 = ScoreHole16_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo17 == Contador)
                                    {
                                        if (ScoreHole17_P2 > 0 && ScoreHole17_P1 > 0 && ScoreHole17_P3 > 0 && ScoreHole17_P4 > 0)
                                        {


                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole17_P2 = ScoreHole17_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole17_P4 = ScoreHole17_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole17_P2 = ScoreHole17_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole17_P4 = ScoreHole17_P4 - 1;
                                                }


                                            }
                                        }

                                    }

                                    if (DificultatHoyo18 == Contador)
                                    {
                                        if (ScoreHole18_P2 > 0 && ScoreHole18_P1 > 0 && ScoreHole18_P3 > 0 && ScoreHole18_P4 > 0)
                                        {

                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4)
                                                {

                                                    ScoreHole18_P2 = ScoreHole18_P2 - 1;
                                                }
                                                else
                                                {

                                                    ScoreHole18_P4 = ScoreHole18_P4 - 1;
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4)
                                                {
                                                    ScoreHole18_P2 = ScoreHole18_P2 - 1;
                                                }
                                                else
                                                {
                                                    ScoreHole18_P4 = ScoreHole18_P4 - 1;
                                                }


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
                        int[] CambioHoyos = new int[76];

                        CambioHoyos = HoyoInicialCambio(ScoreHole1_P1, ScoreHole2_P1, ScoreHole3_P1, ScoreHole4_P1, ScoreHole5_P1, ScoreHole6_P1, ScoreHole7_P1, ScoreHole8_P1, ScoreHole9_P1, ScoreHole10_P1, ScoreHole11_P1, ScoreHole12_P1, ScoreHole13_P1, ScoreHole14_P1, ScoreHole15_P1, ScoreHole16_P1, ScoreHole17_P1, ScoreHole18_P1,
                            ScoreHole1_P2, ScoreHole2_P2, ScoreHole3_P2, ScoreHole4_P2, ScoreHole5_P2, ScoreHole6_P2, ScoreHole7_P2, ScoreHole8_P2, ScoreHole9_P2, ScoreHole10_P2, ScoreHole11_P2, ScoreHole12_P2, ScoreHole13_P2, ScoreHole14_P2, ScoreHole15_P2, ScoreHole16_P2, ScoreHole17_P2, ScoreHole18_P2,
                            ScoreHole1_P3, ScoreHole2_P3, ScoreHole3_P3, ScoreHole4_P3, ScoreHole5_P3, ScoreHole6_P3, ScoreHole7_P3, ScoreHole8_P3, ScoreHole9_P3, ScoreHole10_P3, ScoreHole11_P3, ScoreHole12_P3, ScoreHole13_P3, ScoreHole14_P3, ScoreHole15_P3, ScoreHole16_P3, ScoreHole17_P3, ScoreHole18_P3,
                            ScoreHole1_P4, ScoreHole2_P4, ScoreHole3_P4, ScoreHole4_P4, ScoreHole5_P4, ScoreHole6_P4, ScoreHole7_P4, ScoreHole8_P4, ScoreHole9_P4, ScoreHole10_P4, ScoreHole11_P4, ScoreHole12_P4, ScoreHole13_P4, ScoreHole14_P4, ScoreHole15_P4, ScoreHole16_P4, ScoreHole17_P4, ScoreHole18_P4, HoyoInicial);

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

                        ScoreHole1_P3 = CambioHoyos[37];
                        ScoreHole2_P3 = CambioHoyos[38];
                        ScoreHole3_P3 = CambioHoyos[39];
                        ScoreHole4_P3 = CambioHoyos[40];
                        ScoreHole5_P3 = CambioHoyos[41];
                        ScoreHole6_P3 = CambioHoyos[42];
                        ScoreHole7_P3 = CambioHoyos[43];
                        ScoreHole8_P3 = CambioHoyos[44];
                        ScoreHole9_P3 = CambioHoyos[45];
                        ScoreHole10_P3 = CambioHoyos[46];
                        ScoreHole11_P3 = CambioHoyos[47];
                        ScoreHole12_P3 = CambioHoyos[48];
                        ScoreHole13_P3 = CambioHoyos[49];
                        ScoreHole14_P3 = CambioHoyos[50];
                        ScoreHole15_P3 = CambioHoyos[51];
                        ScoreHole16_P3 = CambioHoyos[52];
                        ScoreHole17_P3 = CambioHoyos[53];
                        ScoreHole18_P3 = CambioHoyos[54];

                        ScoreHole1_P4 = CambioHoyos[55];
                        ScoreHole2_P4 = CambioHoyos[56];
                        ScoreHole3_P4 = CambioHoyos[57];
                        ScoreHole4_P4 = CambioHoyos[58];
                        ScoreHole5_P4 = CambioHoyos[59];
                        ScoreHole6_P4 = CambioHoyos[60];
                        ScoreHole7_P4 = CambioHoyos[61];
                        ScoreHole8_P4 = CambioHoyos[62];
                        ScoreHole9_P4 = CambioHoyos[63];
                        ScoreHole10_P4 = CambioHoyos[64];
                        ScoreHole11_P4 = CambioHoyos[65];
                        ScoreHole12_P4 = CambioHoyos[66];
                        ScoreHole13_P4 = CambioHoyos[67];
                        ScoreHole14_P4 = CambioHoyos[68];
                        ScoreHole15_P4 = CambioHoyos[69];
                        ScoreHole16_P4 = CambioHoyos[70];
                        ScoreHole17_P4 = CambioHoyos[71];
                        ScoreHole18_P4 = CambioHoyos[72];
                        //Termina cambio de hoyo

                        int Resultado1_H = 0;
                        int Resultado2_H = 0;
                        int Resultado3_H = 0;
                        int Resultado4_H = 0;
                        int Resultado5_H = 0;
                        int Resultado6_H = 0;
                        int Resultado7_H = 0;
                        int Resultado8_H = 0;
                        int Resultado9_H = 0;

                        int Resultado1_L = 0;
                        int Resultado2_L = 0;
                        int Resultado3_L = 0;
                        int Resultado4_L = 0;
                        int Resultado5_L = 0;
                        int Resultado6_L = 0;
                        int Resultado7_L = 0;
                        int Resultado8_L = 0;
                        int Resultado9_L = 0;

                        int ValidaFront = 0;

                        if (ScoreHole1_P1 > 0 && ScoreHole1_P2 > 0 && ScoreHole1_P3 > 0 && ScoreHole1_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {

                                //Malo vs Malo 
                                if (ScoreHole1_P1 >= ScoreHole1_P3)
                                {
                                    if (ScoreHole1_P2 >= ScoreHole1_P4)
                                    {
                                        Resultado1_L = ScoreHole1_P2 - ScoreHole1_P1;
                                    }
                                    else
                                    {
                                        Resultado1_L = ScoreHole1_P4 - ScoreHole1_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole1_P2 >= ScoreHole1_P4)
                                    {
                                        Resultado1_L = ScoreHole1_P2 - ScoreHole1_P3;
                                    }
                                    else
                                    {
                                        Resultado1_L = ScoreHole1_P4 - ScoreHole1_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole1_P1 >= ScoreHole1_P3)
                                {
                                    if (ScoreHole1_P2 >= ScoreHole1_P4)
                                    {
                                        Resultado1_H = ScoreHole1_P4 - ScoreHole1_P3;
                                    }
                                    else
                                    {
                                        Resultado1_H = ScoreHole1_P2 - ScoreHole1_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole1_P2 >= ScoreHole1_P4)
                                    {
                                        Resultado1_H = ScoreHole1_P4 - ScoreHole1_P1;
                                    }
                                    else
                                    {
                                        Resultado1_H = ScoreHole1_P2 - ScoreHole1_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole2_P1 > 0 && ScoreHole2_P2 > 0 && ScoreHole2_P3 > 0 && ScoreHole2_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                // Resultado2 = ScoreHole2_P2 - ScoreHole2_P1;

                                if (ScoreHole2_P1 > ScoreHole2_P3)
                                {
                                    if (ScoreHole2_P2 >= ScoreHole2_P4)
                                    {
                                        Resultado2_L = ScoreHole2_P2 - ScoreHole2_P1;
                                    }
                                    else
                                    {
                                        Resultado2_L = ScoreHole2_P4 - ScoreHole2_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole2_P2 >= ScoreHole2_P4)
                                    {
                                        Resultado2_L = ScoreHole2_P2 - ScoreHole2_P3;
                                    }
                                    else
                                    {
                                        Resultado2_L = ScoreHole2_P4 - ScoreHole2_P3;
                                    }
                                }


                                //Bueno Vs Bueno
                                if (ScoreHole2_P1 >= ScoreHole2_P3)
                                {
                                    if (ScoreHole2_P2 >= ScoreHole2_P4)
                                    {
                                        Resultado2_H = ScoreHole2_P4 - ScoreHole2_P3;
                                    }
                                    else
                                    {
                                        Resultado2_H = ScoreHole2_P2 - ScoreHole2_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole2_P2 >= ScoreHole2_P4)
                                    {
                                        Resultado2_H = ScoreHole2_P4 - ScoreHole2_P1;
                                    }
                                    else
                                    {
                                        Resultado2_H = ScoreHole2_P2 - ScoreHole2_P1;
                                    }
                                }

                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole3_P1 > 0 && ScoreHole3_P2 > 0 && ScoreHole3_P3 > 0 && ScoreHole3_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                //Resultado3 = ScoreHole3_P2 - ScoreHole3_P1;


                                if (ScoreHole3_P1 >= ScoreHole3_P3)
                                {
                                    if (ScoreHole3_P2 >= ScoreHole3_P4)
                                    {
                                        Resultado3_L = ScoreHole3_P2 - ScoreHole3_P1;
                                    }
                                    else
                                    {
                                        Resultado3_L = ScoreHole3_P4 - ScoreHole3_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole3_P2 >= ScoreHole3_P4)
                                    {
                                        Resultado3_L = ScoreHole3_P2 - ScoreHole3_P3;
                                    }
                                    else
                                    {
                                        Resultado3_L = ScoreHole3_P4 - ScoreHole3_P3;
                                    }
                                }


                                //Bueno Vs Bueno
                                if (ScoreHole3_P1 >= ScoreHole3_P3)
                                {
                                    if (ScoreHole3_P2 >= ScoreHole3_P4)
                                    {
                                        Resultado3_H = ScoreHole3_P4 - ScoreHole3_P3;
                                    }
                                    else
                                    {
                                        Resultado3_H = ScoreHole3_P2 - ScoreHole3_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole3_P2 >= ScoreHole3_P4)
                                    {
                                        Resultado3_H = ScoreHole3_P4 - ScoreHole3_P1;
                                    }
                                    else
                                    {
                                        Resultado3_H = ScoreHole3_P2 - ScoreHole3_P1;
                                    }
                                }

                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole4_P1 > 0 && ScoreHole4_P2 > 0 && ScoreHole4_P3 > 0 && ScoreHole4_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                // Resultado4 = ScoreHole4_P2 - ScoreHole4_P1;

                                if (ScoreHole4_P1 >= ScoreHole4_P3)
                                {
                                    if (ScoreHole4_P2 >= ScoreHole4_P4)
                                    {
                                        Resultado4_L = ScoreHole4_P2 - ScoreHole4_P1;
                                    }
                                    else
                                    {
                                        Resultado4_L = ScoreHole4_P4 - ScoreHole4_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole4_P2 >= ScoreHole4_P4)
                                    {
                                        Resultado4_L = ScoreHole4_P2 - ScoreHole4_P3;
                                    }
                                    else
                                    {
                                        Resultado4_L = ScoreHole4_P4 - ScoreHole4_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole4_P1 >= ScoreHole4_P3)
                                {
                                    if (ScoreHole4_P2 >= ScoreHole4_P4)
                                    {
                                        Resultado4_H = ScoreHole4_P4 - ScoreHole4_P3;
                                    }
                                    else
                                    {
                                        Resultado4_H = ScoreHole4_P2 - ScoreHole4_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole4_P2 >= ScoreHole4_P4)
                                    {
                                        Resultado4_H = ScoreHole4_P4 - ScoreHole4_P1;
                                    }
                                    else
                                    {
                                        Resultado4_H = ScoreHole4_P2 - ScoreHole4_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole5_P1 > 0 && ScoreHole5_P2 > 0 && ScoreHole5_P3 > 0 && ScoreHole5_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                //  Resultado5 = ScoreHole5_P2 - ScoreHole5_P1;


                                if (ScoreHole5_P1 >= ScoreHole5_P3)
                                {
                                    if (ScoreHole5_P2 >= ScoreHole5_P4)
                                    {
                                        Resultado5_L = ScoreHole5_P2 - ScoreHole5_P1;
                                    }
                                    else
                                    {
                                        Resultado5_L = ScoreHole5_P4 - ScoreHole5_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole5_P2 >= ScoreHole5_P4)
                                    {
                                        Resultado5_L = ScoreHole5_P2 - ScoreHole5_P3;
                                    }
                                    else
                                    {
                                        Resultado5_L = ScoreHole5_P4 - ScoreHole5_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole5_P1 >= ScoreHole5_P3)
                                {
                                    if (ScoreHole5_P2 >= ScoreHole5_P4)
                                    {
                                        Resultado5_H = ScoreHole5_P4 - ScoreHole5_P3;
                                    }
                                    else
                                    {
                                        Resultado5_H = ScoreHole5_P2 - ScoreHole5_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole5_P2 >= ScoreHole5_P4)
                                    {
                                        Resultado5_H = ScoreHole5_P4 - ScoreHole5_P1;
                                    }
                                    else
                                    {
                                        Resultado5_H = ScoreHole5_P2 - ScoreHole5_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole6_P1 > 0 && ScoreHole6_P2 > 0 && ScoreHole6_P3 > 0 && ScoreHole6_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                //  Resultado6 = ScoreHole6_P2 - ScoreHole6_P1;

                                if (ScoreHole6_P1 >= ScoreHole6_P3)
                                {
                                    if (ScoreHole6_P2 >= ScoreHole6_P4)
                                    {
                                        Resultado6_L = ScoreHole6_P2 - ScoreHole6_P1;
                                    }
                                    else
                                    {
                                        Resultado6_L = ScoreHole6_P4 - ScoreHole6_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole6_P2 >= ScoreHole6_P4)
                                    {
                                        Resultado6_L = ScoreHole6_P2 - ScoreHole6_P3;
                                    }
                                    else
                                    {
                                        Resultado6_L = ScoreHole6_P4 - ScoreHole6_P3;
                                    }
                                }


                                //Bueno Vs Bueno
                                if (ScoreHole6_P1 >= ScoreHole6_P3)
                                {
                                    if (ScoreHole6_P2 >= ScoreHole6_P4)
                                    {
                                        Resultado6_H = ScoreHole6_P4 - ScoreHole6_P3;
                                    }
                                    else
                                    {
                                        Resultado6_H = ScoreHole6_P2 - ScoreHole6_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole6_P2 >= ScoreHole6_P4)
                                    {
                                        Resultado6_H = ScoreHole6_P4 - ScoreHole6_P1;
                                    }
                                    else
                                    {
                                        Resultado6_H = ScoreHole6_P2 - ScoreHole6_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole7_P1 > 0 && ScoreHole7_P2 > 0 && ScoreHole7_P3 > 0 && ScoreHole7_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                // Resultado7 = ScoreHole7_P2 - ScoreHole7_P1;

                                if (ScoreHole7_P1 >= ScoreHole7_P3)
                                {
                                    if (ScoreHole7_P2 >= ScoreHole7_P4)
                                    {
                                        Resultado7_L = ScoreHole7_P2 - ScoreHole7_P1;
                                    }
                                    else
                                    {
                                        Resultado7_L = ScoreHole7_P4 - ScoreHole7_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole7_P2 >= ScoreHole7_P4)
                                    {
                                        Resultado7_L = ScoreHole7_P2 - ScoreHole7_P3;
                                    }
                                    else
                                    {
                                        Resultado7_L = ScoreHole7_P4 - ScoreHole7_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole7_P1 >= ScoreHole7_P3)
                                {
                                    if (ScoreHole7_P2 >= ScoreHole7_P4)
                                    {
                                        Resultado7_H = ScoreHole7_P4 - ScoreHole7_P3;
                                    }
                                    else
                                    {
                                        Resultado7_H = ScoreHole7_P2 - ScoreHole7_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole7_P2 >= ScoreHole7_P4)
                                    {
                                        Resultado7_H = ScoreHole7_P4 - ScoreHole7_P1;
                                    }
                                    else
                                    {
                                        Resultado7_H = ScoreHole7_P2 - ScoreHole7_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole8_P1 > 0 && ScoreHole8_P2 > 0 && ScoreHole8_P3 > 0 && ScoreHole8_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                // Resultado8 = ScoreHole8_P2 - ScoreHole8_P1;

                                if (ScoreHole8_P1 >= ScoreHole8_P3)
                                {
                                    if (ScoreHole8_P2 >= ScoreHole8_P4)
                                    {
                                        Resultado8_L = ScoreHole8_P2 - ScoreHole8_P1;
                                    }
                                    else
                                    {
                                        Resultado8_L = ScoreHole8_P4 - ScoreHole8_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole8_P2 >= ScoreHole8_P4)
                                    {
                                        Resultado8_L = ScoreHole8_P2 - ScoreHole8_P3;
                                    }
                                    else
                                    {
                                        Resultado8_L = ScoreHole8_P4 - ScoreHole8_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole8_P1 >= ScoreHole8_P3)
                                {
                                    if (ScoreHole8_P2 >= ScoreHole8_P4)
                                    {
                                        Resultado8_H = ScoreHole8_P4 - ScoreHole8_P3;
                                    }
                                    else
                                    {
                                        Resultado8_H = ScoreHole8_P2 - ScoreHole8_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole8_P2 >= ScoreHole8_P4)
                                    {
                                        Resultado8_H = ScoreHole8_P4 - ScoreHole8_P1;
                                    }
                                    else
                                    {
                                        Resultado8_H = ScoreHole8_P2 - ScoreHole8_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaFront = 1;
                        }

                        if (ScoreHole9_P1 > 0 && ScoreHole9_P2 > 0 && ScoreHole9_P3 > 0 && ScoreHole9_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                //  Resultado9 = ScoreHole9_P2 - ScoreHole9_P1;

                                if (ScoreHole9_P1 >= ScoreHole9_P3)
                                {
                                    if (ScoreHole9_P2 >= ScoreHole9_P4)
                                    {
                                        Resultado9_L = ScoreHole9_P2 - ScoreHole9_P1;
                                    }
                                    else
                                    {
                                        Resultado9_L = ScoreHole9_P4 - ScoreHole9_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole9_P2 >= ScoreHole9_P4)
                                    {
                                        Resultado9_L = ScoreHole9_P2 - ScoreHole9_P3;
                                    }
                                    else
                                    {
                                        Resultado9_L = ScoreHole9_P4 - ScoreHole9_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole9_P1 >= ScoreHole9_P3)
                                {
                                    if (ScoreHole9_P2 >= ScoreHole9_P4)
                                    {
                                        Resultado9_H = ScoreHole9_P4 - ScoreHole9_P3;
                                    }
                                    else
                                    {
                                        Resultado9_H = ScoreHole9_P2 - ScoreHole9_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole9_P2 >= ScoreHole9_P4)
                                    {
                                        Resultado9_H = ScoreHole9_P4 - ScoreHole9_P1;
                                    }
                                    else
                                    {
                                        Resultado9_H = ScoreHole9_P2 - ScoreHole9_P1;
                                    }
                                }
                            }

                        }
                        else
                        {
                            ValidaFront = 1;
                        }


                        //Quien Gano, no lo sabemos

                        int ContadorHoyos = 0;
                        //Resultado 1
                        if (Resultado1_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado1_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado1_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado1_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }
                        //Resultado 2
                        if (Resultado2_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado2_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado2_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado2_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 3
                        if (Resultado3_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado3_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado3_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado3_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 4
                        if (Resultado4_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado4_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado4_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado4_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 5
                        if (Resultado5_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado5_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado5_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado5_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 6
                        if (Resultado6_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado6_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado6_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado6_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 7
                        if (Resultado7_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado7_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado7_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado7_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 8
                        if (Resultado8_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado8_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado8_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado8_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 9
                        if (Resultado9_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado9_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado9_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado9_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Calculo Medal front
                        int ResultadoTotaF1 = ScoreHole1_P1 + ScoreHole2_P1 + ScoreHole3_P1 + ScoreHole4_P1 + ScoreHole5_P1 + ScoreHole6_P1 + ScoreHole7_P1 + ScoreHole8_P1 + ScoreHole9_P1 + ScoreHole1_P3 + ScoreHole2_P3 + ScoreHole3_P3 + ScoreHole4_P3 + ScoreHole5_P3 + ScoreHole6_P3 + ScoreHole7_P3 + ScoreHole8_P3 + ScoreHole9_P3;
                        int ResultadoTotaF2 = ScoreHole1_P2 + ScoreHole2_P2 + ScoreHole3_P2 + ScoreHole4_P2 + ScoreHole5_P2 + ScoreHole6_P2 + ScoreHole7_P2 + ScoreHole8_P2 + ScoreHole9_P2 + ScoreHole1_P4 + ScoreHole2_P4 + ScoreHole3_P4 + ScoreHole4_P4 + ScoreHole5_P4 + ScoreHole6_P4 + ScoreHole7_P4 + ScoreHole8_P4 + ScoreHole9_P4;

                        bool ValidaJuegoInicio = false;

                        if ((ResultadoTotaF1 + ResultadoTotaF2) > 0)
                        {
                            ValidaJuegoInicio = false;
                        }
                        else
                        {
                            ValidaJuegoInicio = true;
                        }


                        int Resultado10_H = 0;
                        int Resultado11_H = 0;
                        int Resultado12_H = 0;
                        int Resultado13_H = 0;
                        int Resultado14_H = 0;
                        int Resultado15_H = 0;
                        int Resultado16_H = 0;
                        int Resultado17_H = 0;
                        int Resultado18_H = 0;

                        int Resultado10_L = 0;
                        int Resultado11_L = 0;
                        int Resultado12_L = 0;
                        int Resultado13_L = 0;
                        int Resultado14_L = 0;
                        int Resultado15_L = 0;
                        int Resultado16_L = 0;
                        int Resultado17_L = 0;
                        int Resultado18_L = 0;

                        int ValidaBack = 0;

                        if (ScoreHole10_P1 > 0 && ScoreHole10_P2 > 0 && ScoreHole10_P3 > 0 && ScoreHole10_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                // Resultado10 = ScoreHole10_P2 - ScoreHole10_P1;

                                //Malo vs Malo 
                                if (ScoreHole10_P1 >= ScoreHole10_P3)
                                {
                                    if (ScoreHole10_P2 >= ScoreHole10_P4)
                                    {
                                        Resultado10_L = ScoreHole10_P2 - ScoreHole10_P1;
                                    }
                                    else
                                    {
                                        Resultado10_L = ScoreHole10_P4 - ScoreHole10_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole10_P2 >= ScoreHole10_P4)
                                    {
                                        Resultado10_L = ScoreHole10_P2 - ScoreHole10_P3;
                                    }
                                    else
                                    {
                                        Resultado10_L = ScoreHole10_P4 - ScoreHole10_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole10_P1 >= ScoreHole10_P3)
                                {
                                    if (ScoreHole10_P2 >= ScoreHole10_P4)
                                    {
                                        Resultado10_H = ScoreHole10_P4 - ScoreHole10_P3;
                                    }
                                    else
                                    {
                                        Resultado10_H = ScoreHole10_P2 - ScoreHole10_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole10_P2 >= ScoreHole10_P4)
                                    {
                                        Resultado10_H = ScoreHole10_P4 - ScoreHole10_P1;
                                    }
                                    else
                                    {
                                        Resultado10_H = ScoreHole10_P2 - ScoreHole10_P1;
                                    }
                                }

                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole11_P1 > 0 && ScoreHole11_P2 > 0 && ScoreHole11_P3 > 0 && ScoreHole11_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                //Resultado11 = ScoreHole11_P2 - ScoreHole11_P1;
                                //Malo vs Malo 
                                if (ScoreHole11_P1 >= ScoreHole11_P3)
                                {
                                    if (ScoreHole11_P2 >= ScoreHole11_P4)
                                    {
                                        Resultado11_L = ScoreHole11_P2 - ScoreHole11_P1;
                                    }
                                    else
                                    {
                                        Resultado11_L = ScoreHole11_P4 - ScoreHole11_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole11_P2 >= ScoreHole11_P4)
                                    {
                                        Resultado11_L = ScoreHole11_P2 - ScoreHole11_P3;
                                    }
                                    else
                                    {
                                        Resultado11_L = ScoreHole11_P4 - ScoreHole11_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole11_P1 >= ScoreHole11_P3)
                                {
                                    if (ScoreHole11_P2 >= ScoreHole11_P4)
                                    {
                                        Resultado11_H = ScoreHole11_P4 - ScoreHole11_P3;
                                    }
                                    else
                                    {
                                        Resultado11_H = ScoreHole11_P2 - ScoreHole11_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole11_P2 >= ScoreHole11_P4)
                                    {
                                        Resultado11_H = ScoreHole11_P4 - ScoreHole11_P1;
                                    }
                                    else
                                    {
                                        Resultado11_H = ScoreHole11_P2 - ScoreHole11_P1;
                                    }
                                }

                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole12_P1 > 0 && ScoreHole12_P2 > 0 && ScoreHole12_P3 > 0 && ScoreHole12_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                // Resultado12 = ScoreHole12_P2 - ScoreHole12_P1;

                                //Malo vs Malo 
                                if (ScoreHole12_P1 >= ScoreHole12_P3)
                                {
                                    if (ScoreHole12_P2 >= ScoreHole12_P4)
                                    {
                                        Resultado12_L = ScoreHole12_P2 - ScoreHole12_P1;
                                    }
                                    else
                                    {
                                        Resultado12_L = ScoreHole12_P4 - ScoreHole12_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole12_P2 >= ScoreHole12_P4)
                                    {
                                        Resultado12_L = ScoreHole12_P2 - ScoreHole12_P3;
                                    }
                                    else
                                    {
                                        Resultado12_L = ScoreHole12_P4 - ScoreHole12_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole12_P1 >= ScoreHole12_P3)
                                {
                                    if (ScoreHole12_P2 >= ScoreHole12_P4)
                                    {
                                        Resultado12_H = ScoreHole12_P4 - ScoreHole12_P3;
                                    }
                                    else
                                    {
                                        Resultado12_H = ScoreHole12_P2 - ScoreHole12_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole12_P2 >= ScoreHole12_P4)
                                    {
                                        Resultado12_H = ScoreHole12_P4 - ScoreHole12_P1;
                                    }
                                    else
                                    {
                                        Resultado12_H = ScoreHole12_P2 - ScoreHole12_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole13_P1 > 0 && ScoreHole13_P2 > 0 && ScoreHole13_P3 > 0 && ScoreHole13_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                // Resultado13 = ScoreHole13_P2 - ScoreHole13_P1;

                                //Malo vs Malo 
                                if (ScoreHole13_P1 >= ScoreHole13_P3)
                                {
                                    if (ScoreHole13_P2 >= ScoreHole13_P4)
                                    {
                                        Resultado13_L = ScoreHole13_P2 - ScoreHole13_P1;
                                    }
                                    else
                                    {
                                        Resultado13_L = ScoreHole13_P4 - ScoreHole13_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole13_P2 >= ScoreHole13_P4)
                                    {
                                        Resultado13_L = ScoreHole13_P2 - ScoreHole13_P3;
                                    }
                                    else
                                    {
                                        Resultado13_L = ScoreHole13_P4 - ScoreHole13_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole13_P1 >= ScoreHole13_P3)
                                {
                                    if (ScoreHole13_P2 >= ScoreHole13_P4)
                                    {
                                        Resultado13_H = ScoreHole13_P4 - ScoreHole13_P3;
                                    }
                                    else
                                    {
                                        Resultado13_H = ScoreHole13_P2 - ScoreHole13_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole13_P2 >= ScoreHole13_P4)
                                    {
                                        Resultado13_H = ScoreHole13_P4 - ScoreHole13_P1;
                                    }
                                    else
                                    {
                                        Resultado13_H = ScoreHole13_P2 - ScoreHole13_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole14_P1 > 0 && ScoreHole14_P2 > 0 && ScoreHole14_P3 > 0 && ScoreHole14_P4 > 0)
                        {
                            if (ValidaFront == 0)
                            {
                                // Resultado14 = ScoreHole14_P2 - ScoreHole14_P1;

                                //Malo vs Malo 
                                if (ScoreHole14_P1 >= ScoreHole14_P3)
                                {
                                    if (ScoreHole14_P2 >= ScoreHole14_P4)
                                    {
                                        Resultado14_L = ScoreHole14_P2 - ScoreHole14_P1;
                                    }
                                    else
                                    {
                                        Resultado14_L = ScoreHole14_P4 - ScoreHole14_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole14_P2 >= ScoreHole14_P4)
                                    {
                                        Resultado14_L = ScoreHole14_P2 - ScoreHole14_P3;
                                    }
                                    else
                                    {
                                        Resultado14_L = ScoreHole14_P4 - ScoreHole14_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole14_P1 >= ScoreHole14_P3)
                                {
                                    if (ScoreHole14_P2 >= ScoreHole14_P4)
                                    {
                                        Resultado14_H = ScoreHole14_P4 - ScoreHole14_P3;
                                    }
                                    else
                                    {
                                        Resultado14_H = ScoreHole14_P2 - ScoreHole14_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole14_P2 >= ScoreHole14_P4)
                                    {
                                        Resultado14_H = ScoreHole14_P4 - ScoreHole14_P1;
                                    }
                                    else
                                    {
                                        Resultado14_H = ScoreHole14_P2 - ScoreHole14_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole15_P1 > 0 && ScoreHole15_P2 > 0 && ScoreHole15_P3 > 0 && ScoreHole15_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                // Resultado15 = ScoreHole15_P2 - ScoreHole15_P1;

                                //Malo vs Malo 
                                if (ScoreHole15_P1 >= ScoreHole15_P3)
                                {
                                    if (ScoreHole15_P2 >= ScoreHole15_P4)
                                    {
                                        Resultado15_L = ScoreHole15_P2 - ScoreHole15_P1;
                                    }
                                    else
                                    {
                                        Resultado15_L = ScoreHole15_P4 - ScoreHole15_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole15_P2 >= ScoreHole15_P4)
                                    {
                                        Resultado15_L = ScoreHole15_P2 - ScoreHole15_P3;
                                    }
                                    else
                                    {
                                        Resultado15_L = ScoreHole15_P4 - ScoreHole15_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole15_P1 >= ScoreHole15_P3)
                                {
                                    if (ScoreHole15_P2 >= ScoreHole15_P4)
                                    {
                                        Resultado15_H = ScoreHole15_P4 - ScoreHole15_P3;
                                    }
                                    else
                                    {
                                        Resultado15_H = ScoreHole15_P2 - ScoreHole15_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole15_P2 >= ScoreHole15_P4)
                                    {
                                        Resultado15_H = ScoreHole15_P4 - ScoreHole15_P1;
                                    }
                                    else
                                    {
                                        Resultado15_H = ScoreHole15_P2 - ScoreHole15_P1;
                                    }
                                }
                            }

                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole16_P1 > 0 && ScoreHole16_P2 > 0 && ScoreHole16_P3 > 0 && ScoreHole16_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                // Resultado16 = ScoreHole16_P2 - ScoreHole16_P1;

                                //Malo vs Malo 
                                if (ScoreHole16_P1 >= ScoreHole16_P3)
                                {
                                    if (ScoreHole16_P2 >= ScoreHole16_P4)
                                    {
                                        Resultado16_L = ScoreHole16_P2 - ScoreHole16_P1;
                                    }
                                    else
                                    {
                                        Resultado16_L = ScoreHole16_P4 - ScoreHole16_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole16_P2 >= ScoreHole16_P4)
                                    {
                                        Resultado16_L = ScoreHole16_P2 - ScoreHole16_P3;
                                    }
                                    else
                                    {
                                        Resultado16_L = ScoreHole16_P4 - ScoreHole16_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole16_P1 >= ScoreHole16_P3)
                                {
                                    if (ScoreHole16_P2 >= ScoreHole16_P4)
                                    {
                                        Resultado16_H = ScoreHole16_P4 - ScoreHole16_P3;
                                    }
                                    else
                                    {
                                        Resultado16_H = ScoreHole16_P2 - ScoreHole16_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole16_P2 >= ScoreHole16_P4)
                                    {
                                        Resultado16_H = ScoreHole16_P4 - ScoreHole16_P1;
                                    }
                                    else
                                    {
                                        Resultado16_H = ScoreHole16_P2 - ScoreHole16_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole17_P1 > 0 && ScoreHole17_P2 > 0 && ScoreHole17_P3 > 0 && ScoreHole17_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                // Resultado17 = ScoreHole17_P2 - ScoreHole17_P1;

                                //Malo vs Malo 
                                if (ScoreHole17_P1 >= ScoreHole17_P3)
                                {
                                    if (ScoreHole17_P2 >= ScoreHole17_P4)
                                    {
                                        Resultado17_L = ScoreHole17_P2 - ScoreHole17_P1;
                                    }
                                    else
                                    {
                                        Resultado17_L = ScoreHole17_P4 - ScoreHole17_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole17_P2 >= ScoreHole17_P4)
                                    {
                                        Resultado17_L = ScoreHole17_P2 - ScoreHole17_P3;
                                    }
                                    else
                                    {
                                        Resultado17_L = ScoreHole17_P4 - ScoreHole17_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole17_P1 >= ScoreHole17_P3)
                                {
                                    if (ScoreHole17_P2 >= ScoreHole17_P4)
                                    {
                                        Resultado17_H = ScoreHole17_P4 - ScoreHole17_P3;
                                    }
                                    else
                                    {
                                        Resultado17_H = ScoreHole17_P2 - ScoreHole17_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole17_P2 >= ScoreHole16_P4)
                                    {
                                        Resultado17_H = ScoreHole17_P4 - ScoreHole17_P1;
                                    }
                                    else
                                    {
                                        Resultado17_H = ScoreHole17_P2 - ScoreHole17_P1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        if (ScoreHole18_P1 > 0 && ScoreHole18_P2 > 0 && ScoreHole18_P3 > 0 && ScoreHole18_P4 > 0)
                        {
                            if (ValidaBack == 0)
                            {
                                //Resultado18 = ScoreHole18_P2 - ScoreHole18_P1;

                                //Malo vs Malo 
                                if (ScoreHole18_P1 >= ScoreHole18_P3)
                                {
                                    if (ScoreHole18_P2 >= ScoreHole18_P4)
                                    {
                                        Resultado18_L = ScoreHole18_P2 - ScoreHole18_P1;
                                    }
                                    else
                                    {
                                        Resultado18_L = ScoreHole18_P4 - ScoreHole18_P1;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole18_P2 >= ScoreHole18_P4)
                                    {
                                        Resultado18_L = ScoreHole18_P2 - ScoreHole18_P3;
                                    }
                                    else
                                    {
                                        Resultado18_L = ScoreHole18_P4 - ScoreHole18_P3;
                                    }
                                }

                                //Bueno Vs Bueno
                                if (ScoreHole18_P1 >= ScoreHole18_P3)
                                {
                                    if (ScoreHole18_P2 >= ScoreHole18_P4)
                                    {
                                        Resultado18_H = ScoreHole18_P4 - ScoreHole18_P3;
                                    }
                                    else
                                    {
                                        Resultado18_H = ScoreHole18_P2 - ScoreHole18_P3;
                                    }
                                }
                                else
                                {
                                    if (ScoreHole18_P2 >= ScoreHole16_P4)
                                    {
                                        Resultado18_H = ScoreHole18_P4 - ScoreHole18_P1;
                                    }
                                    else
                                    {
                                        Resultado18_H = ScoreHole18_P2 - ScoreHole18_P1;
                                    }
                                }
                            }

                        }
                        else
                        {
                            ValidaBack = 1;
                        }

                        //Resultado 10
                        if (Resultado10_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado10_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado10_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado10_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 11
                        if (Resultado11_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado11_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado11_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado11_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 12
                        if (Resultado12_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado12_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado12_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado12_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 13
                        if (Resultado13_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado13_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado13_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado13_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 14
                        if (Resultado14_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado14_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado14_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado14_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 15
                        if (Resultado15_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado15_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado15_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado15_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 16
                        if (Resultado16_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado16_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado16_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado16_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 17
                        if (Resultado17_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado17_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado17_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado17_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Resultado 18
                        if (Resultado18_H > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado18_H < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        if (Resultado18_L > 0)
                        {
                            ContadorHoyos = ContadorHoyos + 1;
                        }
                        else if (Resultado18_L < 0)
                        {
                            ContadorHoyos = ContadorHoyos - 1;
                        }

                        //Calculo Medal front
                        int ResultadoTotaB1 = ScoreHole10_P1 + ScoreHole11_P1 + ScoreHole12_P1 + ScoreHole13_P1 + ScoreHole14_P1 + ScoreHole15_P1 + ScoreHole16_P1 + ScoreHole17_P1 + ScoreHole18_P1 + ScoreHole10_P3 + ScoreHole11_P3 + ScoreHole12_P3 + ScoreHole13_P3 + ScoreHole14_P3 + ScoreHole15_P3 + ScoreHole16_P3 + ScoreHole17_P3 + ScoreHole18_P3;
                        int ResultadoTotaB2 = ScoreHole10_P2 + ScoreHole11_P2 + ScoreHole12_P2 + ScoreHole13_P2 + ScoreHole14_P2 + ScoreHole15_P2 + ScoreHole16_P2 + ScoreHole17_P2 + ScoreHole18_P2 + ScoreHole10_P4 + ScoreHole11_P4 + ScoreHole12_P4 + ScoreHole13_P4 + ScoreHole14_P4 + ScoreHole15_P4 + ScoreHole16_P4 + ScoreHole17_P4 + ScoreHole18_P4;

                        //Valida Medal

                        int ResultadoFinalMedal = 0;

                        int GolpesTotalesJugador1 = ResultadoTotaF1 + ResultadoTotaB1;
                        int GolpesTotalesJugador2 = ResultadoTotaF2 + ResultadoTotaB2;

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

                        if (AutoPress == 2)
                        {
                            ResultFront = CalcularApuestaPresionFront2(Resultado1_H, Resultado2_H, Resultado3_H, Resultado4_H, Resultado5_H, Resultado6_H, Resultado7_H, Resultado8_H, Resultado9_H,
                                Resultado1_L, Resultado2_L, Resultado3_L, Resultado4_L, Resultado5_L, Resultado6_L, Resultado7_L, Resultado8_L, Resultado9_L, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack2(Resultado10_H, Resultado11_H, Resultado12_H, Resultado13_H, Resultado14_H, Resultado15_H, Resultado16_H, Resultado17_H, Resultado18_H,
                                Resultado10_L, Resultado11_L, Resultado12_L, Resultado13_L, Resultado14_L, Resultado15_L, Resultado16_L, Resultado17_L, Resultado18_L, ValidaJuegoInicio);

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


                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                              BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                              ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 2, ValidaJuegoInicio);

                        }
                        else if (AutoPress == 3)
                        {
                            ResultFront = CalcularApuestaPresionFront3(Resultado1_H, Resultado2_H, Resultado3_H, Resultado4_H, Resultado5_H, Resultado6_H, Resultado7_H, Resultado8_H, Resultado9_H,
                                Resultado1_L, Resultado2_L, Resultado3_L, Resultado4_L, Resultado5_L, Resultado6_L, Resultado7_L, Resultado8_L, Resultado9_L, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack3(Resultado10_H, Resultado11_H, Resultado12_H, Resultado13_H, Resultado14_H, Resultado15_H, Resultado16_H, Resultado17_H, Resultado18_H,
                                Resultado10_L, Resultado11_L, Resultado12_L, Resultado13_L, Resultado14_L, Resultado15_L, Resultado16_L, Resultado17_L, Resultado18_L, ValidaJuegoInicio);

                            string[] FrontValores = ResultFront[0].Split(',');
                            string[] BackValores = ResultBack[0].Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);
                            BetD_F9_5 = Convert.ToString(FrontValores[4]);
                            BetD_F9_6 = Convert.ToString(FrontValores[5]);

                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);
                            BetD_F9_5 = Convert.ToString(FrontValores[4]);
                            BetD_F9_6 = Convert.ToString(FrontValores[5]);

                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                             BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                           ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 3, ValidaJuegoInicio);

                        }
                        else if (AutoPress == 4)
                        {
                            ResultFront = CalcularApuestaPresionFront4(Resultado1_H, Resultado2_H, Resultado3_H, Resultado4_H, Resultado5_H, Resultado6_H, Resultado7_H, Resultado8_H, Resultado9_H,
                                Resultado1_L, Resultado2_L, Resultado3_L, Resultado4_L, Resultado5_L, Resultado6_L, Resultado7_L, Resultado8_L, Resultado9_L, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack4(Resultado10_H, Resultado11_H, Resultado12_H, Resultado13_H, Resultado14_H, Resultado15_H, Resultado16_H, Resultado17_H, Resultado18_H,
                                Resultado10_L, Resultado11_L, Resultado12_L, Resultado13_L, Resultado14_L, Resultado15_L, Resultado16_L, Resultado17_L, Resultado18_L, ValidaJuegoInicio);

                            string[] FrontValores = ResultFront[0].Split(',');
                            string[] BackValores = ResultBack[0].Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);


                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);


                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                             BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                           ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 3, ValidaJuegoInicio);

                        }

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


        private string[] CalcularApuestaPresionFront2(int Resultado1_H, int Resultado2_H, int Resultado3_H, int Resultado4_H, int Resultado5_H, int Resultado6_H, int Resultado7_H, int Resultado8_H, int Resultado9_H,
            int Resultado1_L, int Resultado2_L, int Resultado3_L, int Resultado4_L, int Resultado5_L, int Resultado6_L, int Resultado7_L, int Resultado8_L, int Resultado9_L, bool ValidaJuegoInicio)
        {

            int[] ResultadoPresionFront_T = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1_H > 0)
            {
                Resultado1_H = 1;
            }
            else if (Resultado1_H < 0)
            {
                Resultado1_H = -1;
            }
            else
            {
                Resultado1_H = 0;
            }

            if (Resultado1_L > 0)
            {
                Resultado1_L = 1;
            }
            else if (Resultado1_L < 0)
            {
                Resultado1_L = -1;
            }
            else
            {
                Resultado1_L = 0;
            }

            if (Resultado2_H > 0)
            {
                Resultado2_H = 1;
            }
            else if (Resultado2_H < 0)
            {
                Resultado2_H = -1;
            }
            else
            {
                Resultado2_H = 0;
            }

            if (Resultado2_L > 0)
            {
                Resultado2_L = 1;
            }
            else if (Resultado2_L < 0)
            {
                Resultado2_L = -1;
            }
            else
            {
                Resultado2_L = 0;
            }

            if (Resultado3_H > 0)
            {
                Resultado3_H = 1;
            }
            else if (Resultado3_H < 0)
            {
                Resultado3_H = -1;
            }
            else
            {
                Resultado3_H = 0;
            }

            if (Resultado3_L > 0)
            {
                Resultado3_L = 1;
            }
            else if (Resultado3_L < 0)
            {
                Resultado3_L = -1;
            }
            else
            {
                Resultado3_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado5_H > 0)
            {
                Resultado5_H = 1;
            }
            else if (Resultado5_H < 0)
            {
                Resultado5_H = -1;
            }
            else
            {
                Resultado5_H = 0;
            }

            if (Resultado5_L > 0)
            {
                Resultado5_L = 1;
            }
            else if (Resultado5_L < 0)
            {
                Resultado5_L = -1;
            }
            else
            {
                Resultado5_L = 0;
            }

            if (Resultado6_H > 0)
            {
                Resultado6_H = 1;
            }
            else if (Resultado6_H < 0)
            {
                Resultado6_H = -1;
            }
            else
            {
                Resultado6_H = 0;
            }

            if (Resultado6_L > 0)
            {
                Resultado6_L = 1;
            }
            else if (Resultado6_L < 0)
            {
                Resultado6_L = -1;
            }
            else
            {
                Resultado6_L = 0;
            }

            if (Resultado7_H > 0)
            {
                Resultado7_H = 1;
            }
            else if (Resultado7_H < 0)
            {
                Resultado7_H = -1;
            }
            else
            {
                Resultado7_H = 0;
            }

            if (Resultado7_L > 0)
            {
                Resultado7_L = 1;
            }
            else if (Resultado7_L < 0)
            {
                Resultado7_L = -1;
            }
            else
            {
                Resultado7_L = 0;
            }

            if (Resultado8_H > 0)
            {
                Resultado8_H = 1;
            }
            else if (Resultado8_H < 0)
            {
                Resultado8_H = -1;
            }
            else
            {
                Resultado8_H = 0;
            }

            if (Resultado8_L > 0)
            {
                Resultado8_L = 1;
            }
            else if (Resultado8_L < 0)
            {
                Resultado8_L = -1;
            }
            else
            {
                Resultado8_L = 0;
            }

            if (Resultado9_H > 0)
            {
                Resultado9_H = 1;
            }
            else if (Resultado9_H < 0)
            {
                Resultado9_H = -1;
            }
            else
            {
                Resultado9_H = 0;
            }

            if (Resultado9_L > 0)
            {
                Resultado9_L = 1;
            }
            else if (Resultado9_L < 0)
            {
                Resultado9_L = -1;
            }
            else
            {
                Resultado9_L = 0;
            }

            int Hoyo1 = Resultado1_H + Resultado1_L;
            int Hoyo2 = Resultado2_H + Resultado2_L;
            int Hoyo3 = Resultado3_H + Resultado3_L;
            int Hoyo4 = Resultado4_H + Resultado4_L;
            int Hoyo5 = Resultado5_H + Resultado5_L;
            int Hoyo6 = Resultado6_H + Resultado6_L;
            int Hoyo7 = Resultado7_H + Resultado7_L;
            int Hoyo8 = Resultado8_H + Resultado8_L;
            int Hoyo9 = Resultado9_H + Resultado9_L;

            if (Hoyo1 == 0)
            {
                ResultadoPresionFront_T[1] = 0;
            }
            else if (Hoyo1 > 0)
            {
                ResultadoPresionFront_T[1] = 1;
            }
            else if (Hoyo1 < 0)
            {
                ResultadoPresionFront_T[1] = -1;
            }

            if (Hoyo2 == 0)
            {
                ResultadoPresionFront_T[2] = 0;
            }
            else if (Hoyo2 > 0)
            {
                ResultadoPresionFront_T[2] = 1;
            }
            else if (Hoyo2 < 0)
            {
                ResultadoPresionFront_T[2] = -1;
            }

            if (Hoyo3 == 0)
            {
                ResultadoPresionFront_T[3] = 0;
            }
            else if (Hoyo3 > 0)
            {
                ResultadoPresionFront_T[3] = 1;
            }
            else if (Hoyo3 < 0)
            {
                ResultadoPresionFront_T[3] = -1;
            }

            if (Hoyo4 == 0)
            {
                ResultadoPresionFront_T[4] = 0;
            }
            else if (Hoyo4 > 0)
            {
                ResultadoPresionFront_T[4] = 1;
            }
            else if (Hoyo4 < 0)
            {
                ResultadoPresionFront_T[4] = -1;
            }

            if (Hoyo5 == 0)
            {
                ResultadoPresionFront_T[5] = 0;
            }
            else if (Hoyo5 > 0)
            {
                ResultadoPresionFront_T[5] = 1;
            }
            else if (Hoyo5 < 0)
            {
                ResultadoPresionFront_T[5] = -1;
            }

            if (Hoyo6 == 0)
            {
                ResultadoPresionFront_T[6] = 0;
            }
            else if (Hoyo6 > 0)
            {
                ResultadoPresionFront_T[6] = 1;
            }
            else if (Hoyo6 < 0)
            {
                ResultadoPresionFront_T[6] = -1;
            }

            if (Hoyo7 == 0)
            {
                ResultadoPresionFront_T[7] = 0;
            }
            else if (Hoyo7 > 0)
            {
                ResultadoPresionFront_T[7] = 1;
            }
            else if (Hoyo7 < 0)
            {
                ResultadoPresionFront_T[7] = -1;
            }

            if (Hoyo8 == 0)
            {
                ResultadoPresionFront_T[8] = 0;
            }
            else if (Hoyo8 > 0)
            {
                ResultadoPresionFront_T[8] = 1;
            }
            else if (Hoyo8 < 0)
            {
                ResultadoPresionFront_T[8] = -1;
            }

            if (Hoyo9 == 0)
            {
                ResultadoPresionFront_T[9] = 0;
            }
            else if (Hoyo9 > 0)
            {
                ResultadoPresionFront_T[9] = 1;
            }
            else if (Hoyo9 < 0)
            {
                ResultadoPresionFront_T[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";
            string PresionValor6 = "";
            string PresionValor7 = "";
            string PresionValor8 = "";
            string PresionValor9 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront_T[i] == 1)
                {

                    int ValorHoyo = 0;

                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt + Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo > 1)
                    {
                        //Presion1 += ValorHoyo;
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 += 1;
                    }


                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 >= 2)
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
                                // Presion += 1;

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }



                    }

                }
                else if (ResultadoPresionFront_T[i] == -1)
                {

                    //if (Presion1 > 0)
                    //{
                    //    Presion1 = 0;
                    //}
                    int ValorHoyo = 0;
                    //ResultadoInt -= 1;
                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt - Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo < 1)
                    {
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 -= 1;
                    }

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 <= -2)
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }


                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion - Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion - Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion - Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion - Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion - Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion - Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion - Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion - Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion - Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

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


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5 + ", " + PresionValor6 + ", " + PresionValor7 + ", " + PresionValor8 + ", " + PresionValor9;

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

        private string[] CalcularApuestaPresionBack2(int Resultado1_H, int Resultado2_H, int Resultado3_H, int Resultado4_H, int Resultado5_H, int Resultado6_H, int Resultado7_H, int Resultado8_H, int Resultado9_H,
            int Resultado1_L, int Resultado2_L, int Resultado3_L, int Resultado4_L, int Resultado5_L, int Resultado6_L, int Resultado7_L, int Resultado8_L, int Resultado9_L, bool ValidaJuegoInicio)
        {

            int[] ResultadoPresionFront_T = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1_H > 0)
            {
                Resultado1_H = 1;
            }
            else if (Resultado1_H < 0)
            {
                Resultado1_H = -1;
            }
            else
            {
                Resultado1_H = 0;
            }

            if (Resultado1_L > 0)
            {
                Resultado1_L = 1;
            }
            else if (Resultado1_L < 0)
            {
                Resultado1_L = -1;
            }
            else
            {
                Resultado1_L = 0;
            }

            if (Resultado2_H > 0)
            {
                Resultado2_H = 1;
            }
            else if (Resultado2_H < 0)
            {
                Resultado2_H = -1;
            }
            else
            {
                Resultado2_H = 0;
            }

            if (Resultado2_L > 0)
            {
                Resultado2_L = 1;
            }
            else if (Resultado2_L < 0)
            {
                Resultado2_L = -1;
            }
            else
            {
                Resultado2_L = 0;
            }

            if (Resultado3_H > 0)
            {
                Resultado3_H = 1;
            }
            else if (Resultado3_H < 0)
            {
                Resultado3_H = -1;
            }
            else
            {
                Resultado3_H = 0;
            }

            if (Resultado3_L > 0)
            {
                Resultado3_L = 1;
            }
            else if (Resultado3_L < 0)
            {
                Resultado3_L = -1;
            }
            else
            {
                Resultado3_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado5_H > 0)
            {
                Resultado5_H = 1;
            }
            else if (Resultado5_H < 0)
            {
                Resultado5_H = -1;
            }
            else
            {
                Resultado5_H = 0;
            }

            if (Resultado5_L > 0)
            {
                Resultado5_L = 1;
            }
            else if (Resultado5_L < 0)
            {
                Resultado5_L = -1;
            }
            else
            {
                Resultado5_L = 0;
            }

            if (Resultado6_H > 0)
            {
                Resultado6_H = 1;
            }
            else if (Resultado6_H < 0)
            {
                Resultado6_H = -1;
            }
            else
            {
                Resultado6_H = 0;
            }

            if (Resultado6_L > 0)
            {
                Resultado6_L = 1;
            }
            else if (Resultado6_L < 0)
            {
                Resultado6_L = -1;
            }
            else
            {
                Resultado6_L = 0;
            }

            if (Resultado7_H > 0)
            {
                Resultado7_H = 1;
            }
            else if (Resultado7_H < 0)
            {
                Resultado7_H = -1;
            }
            else
            {
                Resultado7_H = 0;
            }

            if (Resultado7_L > 0)
            {
                Resultado7_L = 1;
            }
            else if (Resultado7_L < 0)
            {
                Resultado7_L = -1;
            }
            else
            {
                Resultado7_L = 0;
            }

            if (Resultado8_H > 0)
            {
                Resultado8_H = 1;
            }
            else if (Resultado8_H < 0)
            {
                Resultado8_H = -1;
            }
            else
            {
                Resultado8_H = 0;
            }

            if (Resultado8_L > 0)
            {
                Resultado8_L = 1;
            }
            else if (Resultado8_L < 0)
            {
                Resultado8_L = -1;
            }
            else
            {
                Resultado8_L = 0;
            }

            if (Resultado9_H > 0)
            {
                Resultado9_H = 1;
            }
            else if (Resultado9_H < 0)
            {
                Resultado9_H = -1;
            }
            else
            {
                Resultado9_H = 0;
            }

            if (Resultado9_L > 0)
            {
                Resultado9_L = 1;
            }
            else if (Resultado9_L < 0)
            {
                Resultado9_L = -1;
            }
            else
            {
                Resultado9_L = 0;
            }

            int Hoyo1 = Resultado1_H + Resultado1_L;
            int Hoyo2 = Resultado2_H + Resultado2_L;
            int Hoyo3 = Resultado3_H + Resultado3_L;
            int Hoyo4 = Resultado4_H + Resultado4_L;
            int Hoyo5 = Resultado5_H + Resultado5_L;
            int Hoyo6 = Resultado6_H + Resultado6_L;
            int Hoyo7 = Resultado7_H + Resultado7_L;
            int Hoyo8 = Resultado8_H + Resultado8_L;
            int Hoyo9 = Resultado9_H + Resultado9_L;

            if (Hoyo1 == 0)
            {
                ResultadoPresionFront_T[1] = 0;
            }
            else if (Hoyo1 > 0)
            {
                ResultadoPresionFront_T[1] = 1;
            }
            else if (Hoyo1 < 0)
            {
                ResultadoPresionFront_T[1] = -1;
            }

            if (Hoyo2 == 0)
            {
                ResultadoPresionFront_T[2] = 0;
            }
            else if (Hoyo2 > 0)
            {
                ResultadoPresionFront_T[2] = 1;
            }
            else if (Hoyo2 < 0)
            {
                ResultadoPresionFront_T[2] = -1;
            }

            if (Hoyo3 == 0)
            {
                ResultadoPresionFront_T[3] = 0;
            }
            else if (Hoyo3 > 0)
            {
                ResultadoPresionFront_T[3] = 1;
            }
            else if (Hoyo3 < 0)
            {
                ResultadoPresionFront_T[3] = -1;
            }

            if (Hoyo4 == 0)
            {
                ResultadoPresionFront_T[4] = 0;
            }
            else if (Hoyo4 > 0)
            {
                ResultadoPresionFront_T[4] = 1;
            }
            else if (Hoyo4 < 0)
            {
                ResultadoPresionFront_T[4] = -1;
            }

            if (Hoyo5 == 0)
            {
                ResultadoPresionFront_T[5] = 0;
            }
            else if (Hoyo5 > 0)
            {
                ResultadoPresionFront_T[5] = 1;
            }
            else if (Hoyo5 < 0)
            {
                ResultadoPresionFront_T[5] = -1;
            }

            if (Hoyo6 == 0)
            {
                ResultadoPresionFront_T[6] = 0;
            }
            else if (Hoyo6 > 0)
            {
                ResultadoPresionFront_T[6] = 1;
            }
            else if (Hoyo6 < 0)
            {
                ResultadoPresionFront_T[6] = -1;
            }

            if (Hoyo7 == 0)
            {
                ResultadoPresionFront_T[7] = 0;
            }
            else if (Hoyo7 > 0)
            {
                ResultadoPresionFront_T[7] = 1;
            }
            else if (Hoyo7 < 0)
            {
                ResultadoPresionFront_T[7] = -1;
            }

            if (Hoyo8 == 0)
            {
                ResultadoPresionFront_T[8] = 0;
            }
            else if (Hoyo8 > 0)
            {
                ResultadoPresionFront_T[8] = 1;
            }
            else if (Hoyo8 < 0)
            {
                ResultadoPresionFront_T[8] = -1;
            }

            if (Hoyo9 == 0)
            {
                ResultadoPresionFront_T[9] = 0;
            }
            else if (Hoyo9 > 0)
            {
                ResultadoPresionFront_T[9] = 1;
            }
            else if (Hoyo9 < 0)
            {
                ResultadoPresionFront_T[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";
            string PresionValor6 = "";
            string PresionValor7 = "";
            string PresionValor8 = "";
            string PresionValor9 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront_T[i] == 1)
                {

                    int ValorHoyo = 0;

                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt + Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo > 1)
                    {
                        //Presion1 += ValorHoyo;
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 += 1;
                    }


                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 >= 2)
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
                                // Presion += 1;

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }



                    }

                }
                else if (ResultadoPresionFront_T[i] == -1)
                {

                    //if (Presion1 > 0)
                    //{
                    //    Presion1 = 0;
                    //}
                    int ValorHoyo = 0;
                    //ResultadoInt -= 1;
                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt - Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo < 1)
                    {
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 -= 1;
                    }

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 <= -2)
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }


                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion - Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion - Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion - Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion - Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion - Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion - Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion - Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion - Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion - Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

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


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5 + ", " + PresionValor6 + ", " + PresionValor7 + ", " + PresionValor8 + ", " + PresionValor9;

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

        private string[] CalcularApuestaPresionFront3(int Resultado1_H, int Resultado2_H, int Resultado3_H, int Resultado4_H, int Resultado5_H, int Resultado6_H, int Resultado7_H, int Resultado8_H, int Resultado9_H,
            int Resultado1_L, int Resultado2_L, int Resultado3_L, int Resultado4_L, int Resultado5_L, int Resultado6_L, int Resultado7_L, int Resultado8_L, int Resultado9_L, bool ValidaJuegoInicio)
        {

            int[] ResultadoPresionFront_T = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1_H > 0)
            {
                Resultado1_H = 1;
            }
            else if (Resultado1_H < 0)
            {
                Resultado1_H = -1;
            }
            else
            {
                Resultado1_H = 0;
            }

            if (Resultado1_L > 0)
            {
                Resultado1_L = 1;
            }
            else if (Resultado1_L < 0)
            {
                Resultado1_L = -1;
            }
            else
            {
                Resultado1_L = 0;
            }

            if (Resultado2_H > 0)
            {
                Resultado2_H = 1;
            }
            else if (Resultado2_H < 0)
            {
                Resultado2_H = -1;
            }
            else
            {
                Resultado2_H = 0;
            }

            if (Resultado2_L > 0)
            {
                Resultado2_L = 1;
            }
            else if (Resultado2_L < 0)
            {
                Resultado2_L = -1;
            }
            else
            {
                Resultado2_L = 0;
            }

            if (Resultado3_H > 0)
            {
                Resultado3_H = 1;
            }
            else if (Resultado3_H < 0)
            {
                Resultado3_H = -1;
            }
            else
            {
                Resultado3_H = 0;
            }

            if (Resultado3_L > 0)
            {
                Resultado3_L = 1;
            }
            else if (Resultado3_L < 0)
            {
                Resultado3_L = -1;
            }
            else
            {
                Resultado3_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado5_H > 0)
            {
                Resultado5_H = 1;
            }
            else if (Resultado5_H < 0)
            {
                Resultado5_H = -1;
            }
            else
            {
                Resultado5_H = 0;
            }

            if (Resultado5_L > 0)
            {
                Resultado5_L = 1;
            }
            else if (Resultado5_L < 0)
            {
                Resultado5_L = -1;
            }
            else
            {
                Resultado5_L = 0;
            }

            if (Resultado6_H > 0)
            {
                Resultado6_H = 1;
            }
            else if (Resultado6_H < 0)
            {
                Resultado6_H = -1;
            }
            else
            {
                Resultado6_H = 0;
            }

            if (Resultado6_L > 0)
            {
                Resultado6_L = 1;
            }
            else if (Resultado6_L < 0)
            {
                Resultado6_L = -1;
            }
            else
            {
                Resultado6_L = 0;
            }

            if (Resultado7_H > 0)
            {
                Resultado7_H = 1;
            }
            else if (Resultado7_H < 0)
            {
                Resultado7_H = -1;
            }
            else
            {
                Resultado7_H = 0;
            }

            if (Resultado7_L > 0)
            {
                Resultado7_L = 1;
            }
            else if (Resultado7_L < 0)
            {
                Resultado7_L = -1;
            }
            else
            {
                Resultado7_L = 0;
            }

            if (Resultado8_H > 0)
            {
                Resultado8_H = 1;
            }
            else if (Resultado8_H < 0)
            {
                Resultado8_H = -1;
            }
            else
            {
                Resultado8_H = 0;
            }

            if (Resultado8_L > 0)
            {
                Resultado8_L = 1;
            }
            else if (Resultado8_L < 0)
            {
                Resultado8_L = -1;
            }
            else
            {
                Resultado8_L = 0;
            }

            if (Resultado9_H > 0)
            {
                Resultado9_H = 1;
            }
            else if (Resultado9_H < 0)
            {
                Resultado9_H = -1;
            }
            else
            {
                Resultado9_H = 0;
            }

            if (Resultado9_L > 0)
            {
                Resultado9_L = 1;
            }
            else if (Resultado9_L < 0)
            {
                Resultado9_L = -1;
            }
            else
            {
                Resultado9_L = 0;
            }

            int Hoyo1 = Resultado1_H + Resultado1_L;
            int Hoyo2 = Resultado2_H + Resultado2_L;
            int Hoyo3 = Resultado3_H + Resultado3_L;
            int Hoyo4 = Resultado4_H + Resultado4_L;
            int Hoyo5 = Resultado5_H + Resultado5_L;
            int Hoyo6 = Resultado6_H + Resultado6_L;
            int Hoyo7 = Resultado7_H + Resultado7_L;
            int Hoyo8 = Resultado8_H + Resultado8_L;
            int Hoyo9 = Resultado9_H + Resultado9_L;

            if (Hoyo1 == 0)
            {
                ResultadoPresionFront_T[1] = 0;
            }
            else if (Hoyo1 > 0)
            {
                ResultadoPresionFront_T[1] = 1;
            }
            else if (Hoyo1 < 0)
            {
                ResultadoPresionFront_T[1] = -1;
            }

            if (Hoyo2 == 0)
            {
                ResultadoPresionFront_T[2] = 0;
            }
            else if (Hoyo2 > 0)
            {
                ResultadoPresionFront_T[2] = 1;
            }
            else if (Hoyo2 < 0)
            {
                ResultadoPresionFront_T[2] = -1;
            }

            if (Hoyo3 == 0)
            {
                ResultadoPresionFront_T[3] = 0;
            }
            else if (Hoyo3 > 0)
            {
                ResultadoPresionFront_T[3] = 1;
            }
            else if (Hoyo3 < 0)
            {
                ResultadoPresionFront_T[3] = -1;
            }

            if (Hoyo4 == 0)
            {
                ResultadoPresionFront_T[4] = 0;
            }
            else if (Hoyo4 > 0)
            {
                ResultadoPresionFront_T[4] = 1;
            }
            else if (Hoyo4 < 0)
            {
                ResultadoPresionFront_T[4] = -1;
            }

            if (Hoyo5 == 0)
            {
                ResultadoPresionFront_T[5] = 0;
            }
            else if (Hoyo5 > 0)
            {
                ResultadoPresionFront_T[5] = 1;
            }
            else if (Hoyo5 < 0)
            {
                ResultadoPresionFront_T[5] = -1;
            }

            if (Hoyo6 == 0)
            {
                ResultadoPresionFront_T[6] = 0;
            }
            else if (Hoyo6 > 0)
            {
                ResultadoPresionFront_T[6] = 1;
            }
            else if (Hoyo6 < 0)
            {
                ResultadoPresionFront_T[6] = -1;
            }

            if (Hoyo7 == 0)
            {
                ResultadoPresionFront_T[7] = 0;
            }
            else if (Hoyo7 > 0)
            {
                ResultadoPresionFront_T[7] = 1;
            }
            else if (Hoyo7 < 0)
            {
                ResultadoPresionFront_T[7] = -1;
            }

            if (Hoyo8 == 0)
            {
                ResultadoPresionFront_T[8] = 0;
            }
            else if (Hoyo8 > 0)
            {
                ResultadoPresionFront_T[8] = 1;
            }
            else if (Hoyo8 < 0)
            {
                ResultadoPresionFront_T[8] = -1;
            }

            if (Hoyo9 == 0)
            {
                ResultadoPresionFront_T[9] = 0;
            }
            else if (Hoyo9 > 0)
            {
                ResultadoPresionFront_T[9] = 1;
            }
            else if (Hoyo9 < 0)
            {
                ResultadoPresionFront_T[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";
            string PresionValor6 = "";
            string PresionValor7 = "";
            string PresionValor8 = "";
            string PresionValor9 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront_T[i] == 1)
                {

                    int ValorHoyo = 0;

                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt + Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo > 1)
                    {
                        //Presion1 += ValorHoyo;
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 += 1;
                    }


                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 >= 3)
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
                                // Presion += 1;

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }



                    }

                }
                else if (ResultadoPresionFront_T[i] == -1)
                {

                    //if (Presion1 > 0)
                    //{
                    //    Presion1 = 0;
                    //}
                    int ValorHoyo = 0;
                    //ResultadoInt -= 1;
                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt - Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo < 1)
                    {
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 -= 1;
                    }

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 <= -3)
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }


                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion - Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion - Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion - Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion - Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion - Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion - Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion - Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion - Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion - Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

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


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5 + ", " + PresionValor6 + ", " + PresionValor7 + ", " + PresionValor8 + ", " + PresionValor9;

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

        private string[] CalcularApuestaPresionBack3(int Resultado1_H, int Resultado2_H, int Resultado3_H, int Resultado4_H, int Resultado5_H, int Resultado6_H, int Resultado7_H, int Resultado8_H, int Resultado9_H,
            int Resultado1_L, int Resultado2_L, int Resultado3_L, int Resultado4_L, int Resultado5_L, int Resultado6_L, int Resultado7_L, int Resultado8_L, int Resultado9_L, bool ValidaJuegoInicio)
        {

            int[] ResultadoPresionFront_T = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1_H > 0)
            {
                Resultado1_H = 1;
            }
            else if (Resultado1_H < 0)
            {
                Resultado1_H = -1;
            }
            else
            {
                Resultado1_H = 0;
            }

            if (Resultado1_L > 0)
            {
                Resultado1_L = 1;
            }
            else if (Resultado1_L < 0)
            {
                Resultado1_L = -1;
            }
            else
            {
                Resultado1_L = 0;
            }

            if (Resultado2_H > 0)
            {
                Resultado2_H = 1;
            }
            else if (Resultado2_H < 0)
            {
                Resultado2_H = -1;
            }
            else
            {
                Resultado2_H = 0;
            }

            if (Resultado2_L > 0)
            {
                Resultado2_L = 1;
            }
            else if (Resultado2_L < 0)
            {
                Resultado2_L = -1;
            }
            else
            {
                Resultado2_L = 0;
            }

            if (Resultado3_H > 0)
            {
                Resultado3_H = 1;
            }
            else if (Resultado3_H < 0)
            {
                Resultado3_H = -1;
            }
            else
            {
                Resultado3_H = 0;
            }

            if (Resultado3_L > 0)
            {
                Resultado3_L = 1;
            }
            else if (Resultado3_L < 0)
            {
                Resultado3_L = -1;
            }
            else
            {
                Resultado3_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado5_H > 0)
            {
                Resultado5_H = 1;
            }
            else if (Resultado5_H < 0)
            {
                Resultado5_H = -1;
            }
            else
            {
                Resultado5_H = 0;
            }

            if (Resultado5_L > 0)
            {
                Resultado5_L = 1;
            }
            else if (Resultado5_L < 0)
            {
                Resultado5_L = -1;
            }
            else
            {
                Resultado5_L = 0;
            }

            if (Resultado6_H > 0)
            {
                Resultado6_H = 1;
            }
            else if (Resultado6_H < 0)
            {
                Resultado6_H = -1;
            }
            else
            {
                Resultado6_H = 0;
            }

            if (Resultado6_L > 0)
            {
                Resultado6_L = 1;
            }
            else if (Resultado6_L < 0)
            {
                Resultado6_L = -1;
            }
            else
            {
                Resultado6_L = 0;
            }

            if (Resultado7_H > 0)
            {
                Resultado7_H = 1;
            }
            else if (Resultado7_H < 0)
            {
                Resultado7_H = -1;
            }
            else
            {
                Resultado7_H = 0;
            }

            if (Resultado7_L > 0)
            {
                Resultado7_L = 1;
            }
            else if (Resultado7_L < 0)
            {
                Resultado7_L = -1;
            }
            else
            {
                Resultado7_L = 0;
            }

            if (Resultado8_H > 0)
            {
                Resultado8_H = 1;
            }
            else if (Resultado8_H < 0)
            {
                Resultado8_H = -1;
            }
            else
            {
                Resultado8_H = 0;
            }

            if (Resultado8_L > 0)
            {
                Resultado8_L = 1;
            }
            else if (Resultado8_L < 0)
            {
                Resultado8_L = -1;
            }
            else
            {
                Resultado8_L = 0;
            }

            if (Resultado9_H > 0)
            {
                Resultado9_H = 1;
            }
            else if (Resultado9_H < 0)
            {
                Resultado9_H = -1;
            }
            else
            {
                Resultado9_H = 0;
            }

            if (Resultado9_L > 0)
            {
                Resultado9_L = 1;
            }
            else if (Resultado9_L < 0)
            {
                Resultado9_L = -1;
            }
            else
            {
                Resultado9_L = 0;
            }


            int Hoyo1 = Resultado1_H + Resultado1_L;
            int Hoyo2 = Resultado2_H + Resultado2_L;
            int Hoyo3 = Resultado3_H + Resultado3_L;
            int Hoyo4 = Resultado4_H + Resultado4_L;
            int Hoyo5 = Resultado5_H + Resultado5_L;
            int Hoyo6 = Resultado6_H + Resultado6_L;
            int Hoyo7 = Resultado7_H + Resultado7_L;
            int Hoyo8 = Resultado8_H + Resultado8_L;
            int Hoyo9 = Resultado9_H + Resultado9_L;

            if (Hoyo1 == 0)
            {
                ResultadoPresionFront_T[1] = 0;
            }
            else if (Hoyo1 > 0)
            {
                ResultadoPresionFront_T[1] = 1;
            }
            else if (Hoyo1 < 0)
            {
                ResultadoPresionFront_T[1] = -1;
            }

            if (Hoyo2 == 0)
            {
                ResultadoPresionFront_T[2] = 0;
            }
            else if (Hoyo2 > 0)
            {
                ResultadoPresionFront_T[2] = 1;
            }
            else if (Hoyo2 < 0)
            {
                ResultadoPresionFront_T[2] = -1;
            }

            if (Hoyo3 == 0)
            {
                ResultadoPresionFront_T[3] = 0;
            }
            else if (Hoyo3 > 0)
            {
                ResultadoPresionFront_T[3] = 1;
            }
            else if (Hoyo3 < 0)
            {
                ResultadoPresionFront_T[3] = -1;
            }

            if (Hoyo4 == 0)
            {
                ResultadoPresionFront_T[4] = 0;
            }
            else if (Hoyo4 > 0)
            {
                ResultadoPresionFront_T[4] = 1;
            }
            else if (Hoyo4 < 0)
            {
                ResultadoPresionFront_T[4] = -1;
            }

            if (Hoyo5 == 0)
            {
                ResultadoPresionFront_T[5] = 0;
            }
            else if (Hoyo5 > 0)
            {
                ResultadoPresionFront_T[5] = 1;
            }
            else if (Hoyo5 < 0)
            {
                ResultadoPresionFront_T[5] = -1;
            }

            if (Hoyo6 == 0)
            {
                ResultadoPresionFront_T[6] = 0;
            }
            else if (Hoyo6 > 0)
            {
                ResultadoPresionFront_T[6] = 1;
            }
            else if (Hoyo6 < 0)
            {
                ResultadoPresionFront_T[6] = -1;
            }

            if (Hoyo7 == 0)
            {
                ResultadoPresionFront_T[7] = 0;
            }
            else if (Hoyo7 > 0)
            {
                ResultadoPresionFront_T[7] = 1;
            }
            else if (Hoyo7 < 0)
            {
                ResultadoPresionFront_T[7] = -1;
            }

            if (Hoyo8 == 0)
            {
                ResultadoPresionFront_T[8] = 0;
            }
            else if (Hoyo8 > 0)
            {
                ResultadoPresionFront_T[8] = 1;
            }
            else if (Hoyo8 < 0)
            {
                ResultadoPresionFront_T[8] = -1;
            }

            if (Hoyo9 == 0)
            {
                ResultadoPresionFront_T[9] = 0;
            }
            else if (Hoyo9 > 0)
            {
                ResultadoPresionFront_T[9] = 1;
            }
            else if (Hoyo9 < 0)
            {
                ResultadoPresionFront_T[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";
            string PresionValor6 = "";
            string PresionValor7 = "";
            string PresionValor8 = "";
            string PresionValor9 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront_T[i] == 1)
                {

                    int ValorHoyo = 0;

                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt + Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo > 1)
                    {
                        //Presion1 += ValorHoyo;
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 += 1;
                    }


                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 >= 3)
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
                                // Presion += 1;

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }



                    }

                }

                else if (ResultadoPresionFront_T[i] == -1)
                {

                    //if (Presion1 > 0)
                    //{
                    //    Presion1 = 0;
                    //}
                    int ValorHoyo = 0;
                    //ResultadoInt -= 1;
                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt - Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo < 1)
                    {
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 -= 1;
                    }

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 <= -3)
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }


                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion - Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion - Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion - Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion - Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion - Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion - Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion - Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion - Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion - Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

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


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5 + ", " + PresionValor6 + ", " + PresionValor7 + ", " + PresionValor8 + ", " + PresionValor9;

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

        private string[] CalcularApuestaPresionFront4(int Resultado1_H, int Resultado2_H, int Resultado3_H, int Resultado4_H, int Resultado5_H, int Resultado6_H, int Resultado7_H, int Resultado8_H, int Resultado9_H,
           int Resultado1_L, int Resultado2_L, int Resultado3_L, int Resultado4_L, int Resultado5_L, int Resultado6_L, int Resultado7_L, int Resultado8_L, int Resultado9_L, bool ValidaJuegoInicio)
        {
            int[] ResultadoPresionFront_T = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1_H > 0)
            {
                Resultado1_H = 1;
            }
            else if (Resultado1_H < 0)
            {
                Resultado1_H = -1;
            }
            else
            {
                Resultado1_H = 0;
            }

            if (Resultado1_L > 0)
            {
                Resultado1_L = 1;
            }
            else if (Resultado1_L < 0)
            {
                Resultado1_L = -1;
            }
            else
            {
                Resultado1_L = 0;
            }

            if (Resultado2_H > 0)
            {
                Resultado2_H = 1;
            }
            else if (Resultado2_H < 0)
            {
                Resultado2_H = -1;
            }
            else
            {
                Resultado2_H = 0;
            }

            if (Resultado2_L > 0)
            {
                Resultado2_L = 1;
            }
            else if (Resultado2_L < 0)
            {
                Resultado2_L = -1;
            }
            else
            {
                Resultado2_L = 0;
            }

            if (Resultado3_H > 0)
            {
                Resultado3_H = 1;
            }
            else if (Resultado3_H < 0)
            {
                Resultado3_H = -1;
            }
            else
            {
                Resultado3_H = 0;
            }

            if (Resultado3_L > 0)
            {
                Resultado3_L = 1;
            }
            else if (Resultado3_L < 0)
            {
                Resultado3_L = -1;
            }
            else
            {
                Resultado3_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado5_H > 0)
            {
                Resultado5_H = 1;
            }
            else if (Resultado5_H < 0)
            {
                Resultado5_H = -1;
            }
            else
            {
                Resultado5_H = 0;
            }

            if (Resultado5_L > 0)
            {
                Resultado5_L = 1;
            }
            else if (Resultado5_L < 0)
            {
                Resultado5_L = -1;
            }
            else
            {
                Resultado5_L = 0;
            }

            if (Resultado6_H > 0)
            {
                Resultado6_H = 1;
            }
            else if (Resultado6_H < 0)
            {
                Resultado6_H = -1;
            }
            else
            {
                Resultado6_H = 0;
            }

            if (Resultado6_L > 0)
            {
                Resultado6_L = 1;
            }
            else if (Resultado6_L < 0)
            {
                Resultado6_L = -1;
            }
            else
            {
                Resultado6_L = 0;
            }

            if (Resultado7_H > 0)
            {
                Resultado7_H = 1;
            }
            else if (Resultado7_H < 0)
            {
                Resultado7_H = -1;
            }
            else
            {
                Resultado7_H = 0;
            }

            if (Resultado7_L > 0)
            {
                Resultado7_L = 1;
            }
            else if (Resultado7_L < 0)
            {
                Resultado7_L = -1;
            }
            else
            {
                Resultado7_L = 0;
            }

            if (Resultado8_H > 0)
            {
                Resultado8_H = 1;
            }
            else if (Resultado8_H < 0)
            {
                Resultado8_H = -1;
            }
            else
            {
                Resultado8_H = 0;
            }

            if (Resultado8_L > 0)
            {
                Resultado8_L = 1;
            }
            else if (Resultado8_L < 0)
            {
                Resultado8_L = -1;
            }
            else
            {
                Resultado8_L = 0;
            }

            if (Resultado9_H > 0)
            {
                Resultado9_H = 1;
            }
            else if (Resultado9_H < 0)
            {
                Resultado9_H = -1;
            }
            else
            {
                Resultado9_H = 0;
            }

            if (Resultado9_L > 0)
            {
                Resultado9_L = 1;
            }
            else if (Resultado9_L < 0)
            {
                Resultado9_L = -1;
            }
            else
            {
                Resultado9_L = 0;
            }


            int Hoyo1 = Resultado1_H + Resultado1_L;
            int Hoyo2 = Resultado2_H + Resultado2_L;
            int Hoyo3 = Resultado3_H + Resultado3_L;
            int Hoyo4 = Resultado4_H + Resultado4_L;
            int Hoyo5 = Resultado5_H + Resultado5_L;
            int Hoyo6 = Resultado6_H + Resultado6_L;
            int Hoyo7 = Resultado7_H + Resultado7_L;
            int Hoyo8 = Resultado8_H + Resultado8_L;
            int Hoyo9 = Resultado9_H + Resultado9_L;



            if (Hoyo1 == 0)
            {
                ResultadoPresionFront_T[1] = 0;
            }
            else if (Hoyo1 > 0)
            {
                ResultadoPresionFront_T[1] = 1;
            }
            else if (Hoyo1 < 0)
            {
                ResultadoPresionFront_T[1] = -1;
            }

            if (Hoyo2 == 0)
            {
                ResultadoPresionFront_T[2] = 0;
            }
            else if (Hoyo2 > 0)
            {
                ResultadoPresionFront_T[2] = 1;
            }
            else if (Hoyo2 < 0)
            {
                ResultadoPresionFront_T[2] = -1;
            }

            if (Hoyo3 == 0)
            {
                ResultadoPresionFront_T[3] = 0;
            }
            else if (Hoyo3 > 0)
            {
                ResultadoPresionFront_T[3] = 1;
            }
            else if (Hoyo3 < 0)
            {
                ResultadoPresionFront_T[3] = -1;
            }

            if (Hoyo4 == 0)
            {
                ResultadoPresionFront_T[4] = 0;
            }
            else if (Hoyo4 > 0)
            {
                ResultadoPresionFront_T[4] = 1;
            }
            else if (Hoyo4 < 0)
            {
                ResultadoPresionFront_T[4] = -1;
            }

            if (Hoyo5 == 0)
            {
                ResultadoPresionFront_T[5] = 0;
            }
            else if (Hoyo5 > 0)
            {
                ResultadoPresionFront_T[5] = 1;
            }
            else if (Hoyo5 < 0)
            {
                ResultadoPresionFront_T[5] = -1;
            }

            if (Hoyo6 == 0)
            {
                ResultadoPresionFront_T[6] = 0;
            }
            else if (Hoyo6 > 0)
            {
                ResultadoPresionFront_T[6] = 1;
            }
            else if (Hoyo6 < 0)
            {
                ResultadoPresionFront_T[6] = -1;
            }

            if (Hoyo7 == 0)
            {
                ResultadoPresionFront_T[7] = 0;
            }
            else if (Hoyo7 > 0)
            {
                ResultadoPresionFront_T[7] = 1;
            }
            else if (Hoyo7 < 0)
            {
                ResultadoPresionFront_T[7] = -1;
            }

            if (Hoyo8 == 0)
            {
                ResultadoPresionFront_T[8] = 0;
            }
            else if (Hoyo8 > 0)
            {
                ResultadoPresionFront_T[8] = 1;
            }
            else if (Hoyo8 < 0)
            {
                ResultadoPresionFront_T[8] = -1;
            }

            if (Hoyo9 == 0)
            {
                ResultadoPresionFront_T[9] = 0;
            }
            else if (Hoyo9 > 0)
            {
                ResultadoPresionFront_T[9] = 1;
            }
            else if (Hoyo9 < 0)
            {
                ResultadoPresionFront_T[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";
            string PresionValor6 = "";
            string PresionValor7 = "";
            string PresionValor8 = "";
            string PresionValor9 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront_T[i] == 1)
                {

                    int ValorHoyo = 0;

                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt + Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo > 1)
                    {
                        //Presion1 += ValorHoyo;
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 += 1;
                    }


                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 >= 4)
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
                                // Presion += 1;

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }



                    }

                }
                else if (ResultadoPresionFront_T[i] == -1)
                {

                    //if (Presion1 > 0)
                    //{
                    //    Presion1 = 0;
                    //}
                    int ValorHoyo = 0;
                    //ResultadoInt -= 1;
                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt - Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo < 1)
                    {
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 -= 1;
                    }

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 <= -4)
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }


                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion - Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion - Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion - Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion - Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion - Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion - Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion - Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion - Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion - Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

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


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5 + ", " + PresionValor6 + ", " + PresionValor7 + ", " + PresionValor8 + ", " + PresionValor9;

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

        private string[] CalcularApuestaPresionBack4(int Resultado1_H, int Resultado2_H, int Resultado3_H, int Resultado4_H, int Resultado5_H, int Resultado6_H, int Resultado7_H, int Resultado8_H, int Resultado9_H,
            int Resultado1_L, int Resultado2_L, int Resultado3_L, int Resultado4_L, int Resultado5_L, int Resultado6_L, int Resultado7_L, int Resultado8_L, int Resultado9_L, bool ValidaJuegoInicio)
        {
            int[] ResultadoPresionFront_T = new int[10];

            string[] ResultadoPresionFrontString = new string[10];

            if (Resultado1_H > 0)
            {
                Resultado1_H = 1;
            }
            else if (Resultado1_H < 0)
            {
                Resultado1_H = -1;
            }
            else
            {
                Resultado1_H = 0;
            }

            if (Resultado1_L > 0)
            {
                Resultado1_L = 1;
            }
            else if (Resultado1_L < 0)
            {
                Resultado1_L = -1;
            }
            else
            {
                Resultado1_L = 0;
            }

            if (Resultado2_H > 0)
            {
                Resultado2_H = 1;
            }
            else if (Resultado2_H < 0)
            {
                Resultado2_H = -1;
            }
            else
            {
                Resultado2_H = 0;
            }

            if (Resultado2_L > 0)
            {
                Resultado2_L = 1;
            }
            else if (Resultado2_L < 0)
            {
                Resultado2_L = -1;
            }
            else
            {
                Resultado2_L = 0;
            }

            if (Resultado3_H > 0)
            {
                Resultado3_H = 1;
            }
            else if (Resultado3_H < 0)
            {
                Resultado3_H = -1;
            }
            else
            {
                Resultado3_H = 0;
            }

            if (Resultado3_L > 0)
            {
                Resultado3_L = 1;
            }
            else if (Resultado3_L < 0)
            {
                Resultado3_L = -1;
            }
            else
            {
                Resultado3_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado4_H > 0)
            {
                Resultado4_H = 1;
            }
            else if (Resultado4_H < 0)
            {
                Resultado4_H = -1;
            }
            else
            {
                Resultado4_H = 0;
            }

            if (Resultado4_L > 0)
            {
                Resultado4_L = 1;
            }
            else if (Resultado4_L < 0)
            {
                Resultado4_L = -1;
            }
            else
            {
                Resultado4_L = 0;
            }

            if (Resultado5_H > 0)
            {
                Resultado5_H = 1;
            }
            else if (Resultado5_H < 0)
            {
                Resultado5_H = -1;
            }
            else
            {
                Resultado5_H = 0;
            }

            if (Resultado5_L > 0)
            {
                Resultado5_L = 1;
            }
            else if (Resultado5_L < 0)
            {
                Resultado5_L = -1;
            }
            else
            {
                Resultado5_L = 0;
            }

            if (Resultado6_H > 0)
            {
                Resultado6_H = 1;
            }
            else if (Resultado6_H < 0)
            {
                Resultado6_H = -1;
            }
            else
            {
                Resultado6_H = 0;
            }

            if (Resultado6_L > 0)
            {
                Resultado6_L = 1;
            }
            else if (Resultado6_L < 0)
            {
                Resultado6_L = -1;
            }
            else
            {
                Resultado6_L = 0;
            }

            if (Resultado7_H > 0)
            {
                Resultado7_H = 1;
            }
            else if (Resultado7_H < 0)
            {
                Resultado7_H = -1;
            }
            else
            {
                Resultado7_H = 0;
            }

            if (Resultado7_L > 0)
            {
                Resultado7_L = 1;
            }
            else if (Resultado7_L < 0)
            {
                Resultado7_L = -1;
            }
            else
            {
                Resultado7_L = 0;
            }

            if (Resultado8_H > 0)
            {
                Resultado8_H = 1;
            }
            else if (Resultado8_H < 0)
            {
                Resultado8_H = -1;
            }
            else
            {
                Resultado8_H = 0;
            }

            if (Resultado8_L > 0)
            {
                Resultado8_L = 1;
            }
            else if (Resultado8_L < 0)
            {
                Resultado8_L = -1;
            }
            else
            {
                Resultado8_L = 0;
            }

            if (Resultado9_H > 0)
            {
                Resultado9_H = 1;
            }
            else if (Resultado9_H < 0)
            {
                Resultado9_H = -1;
            }
            else
            {
                Resultado9_H = 0;
            }

            if (Resultado9_L > 0)
            {
                Resultado9_L = 1;
            }
            else if (Resultado9_L < 0)
            {
                Resultado9_L = -1;
            }
            else
            {
                Resultado9_L = 0;
            }

            int Hoyo1 = Resultado1_H + Resultado1_L;
            int Hoyo2 = Resultado2_H + Resultado2_L;
            int Hoyo3 = Resultado3_H + Resultado3_L;
            int Hoyo4 = Resultado4_H + Resultado4_L;
            int Hoyo5 = Resultado5_H + Resultado5_L;
            int Hoyo6 = Resultado6_H + Resultado6_L;
            int Hoyo7 = Resultado7_H + Resultado7_L;
            int Hoyo8 = Resultado8_H + Resultado8_L;
            int Hoyo9 = Resultado9_H + Resultado9_L;

            if (Hoyo1 == 0)
            {
                ResultadoPresionFront_T[1] = 0;
            }
            else if (Hoyo1 > 0)
            {
                ResultadoPresionFront_T[1] = 1;
            }
            else if (Hoyo1 < 0)
            {
                ResultadoPresionFront_T[1] = -1;
            }

            if (Hoyo2 == 0)
            {
                ResultadoPresionFront_T[2] = 0;
            }
            else if (Hoyo2 > 0)
            {
                ResultadoPresionFront_T[2] = 1;
            }
            else if (Hoyo2 < 0)
            {
                ResultadoPresionFront_T[2] = -1;
            }

            if (Hoyo3 == 0)
            {
                ResultadoPresionFront_T[3] = 0;
            }
            else if (Hoyo3 > 0)
            {
                ResultadoPresionFront_T[3] = 1;
            }
            else if (Hoyo3 < 0)
            {
                ResultadoPresionFront_T[3] = -1;
            }

            if (Hoyo4 == 0)
            {
                ResultadoPresionFront_T[4] = 0;
            }
            else if (Hoyo4 > 0)
            {
                ResultadoPresionFront_T[4] = 1;
            }
            else if (Hoyo4 < 0)
            {
                ResultadoPresionFront_T[4] = -1;
            }

            if (Hoyo5 == 0)
            {
                ResultadoPresionFront_T[5] = 0;
            }
            else if (Hoyo5 > 0)
            {
                ResultadoPresionFront_T[5] = 1;
            }
            else if (Hoyo5 < 0)
            {
                ResultadoPresionFront_T[5] = -1;
            }

            if (Hoyo6 == 0)
            {
                ResultadoPresionFront_T[6] = 0;
            }
            else if (Hoyo6 > 0)
            {
                ResultadoPresionFront_T[6] = 1;
            }
            else if (Hoyo6 < 0)
            {
                ResultadoPresionFront_T[6] = -1;
            }

            if (Hoyo7 == 0)
            {
                ResultadoPresionFront_T[7] = 0;
            }
            else if (Hoyo7 > 0)
            {
                ResultadoPresionFront_T[7] = 1;
            }
            else if (Hoyo7 < 0)
            {
                ResultadoPresionFront_T[7] = -1;
            }

            if (Hoyo8 == 0)
            {
                ResultadoPresionFront_T[8] = 0;
            }
            else if (Hoyo8 > 0)
            {
                ResultadoPresionFront_T[8] = 1;
            }
            else if (Hoyo8 < 0)
            {
                ResultadoPresionFront_T[8] = -1;
            }

            if (Hoyo9 == 0)
            {
                ResultadoPresionFront_T[9] = 0;
            }
            else if (Hoyo9 > 0)
            {
                ResultadoPresionFront_T[9] = 1;
            }
            else if (Hoyo9 < 0)
            {
                ResultadoPresionFront_T[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";
            string PresionValor5 = "";
            string PresionValor6 = "";
            string PresionValor7 = "";
            string PresionValor8 = "";
            string PresionValor9 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront_T[i] == 1)
                {

                    int ValorHoyo = 0;

                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt + Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo > 1)
                    {
                        //Presion1 += ValorHoyo;
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 += 1;
                    }


                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 >= 4)
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
                                // Presion += 1;

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor5 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5;
                        }



                    }

                }
                else if (ResultadoPresionFront_T[i] == -1)
                {

                    //if (Presion1 > 0)
                    //{
                    //    Presion1 = 0;
                    //}
                    int ValorHoyo = 0;
                    //ResultadoInt -= 1;
                    switch (i)
                    {
                        case 1:
                            ResultadoInt = ResultadoInt + Hoyo1;
                            ValorHoyo = Hoyo1;
                            break;
                        case 2:
                            ResultadoInt = ResultadoInt + Hoyo2;
                            ValorHoyo = Hoyo2;
                            break;
                        case 3:
                            ResultadoInt = ResultadoInt + Hoyo3;
                            ValorHoyo = Hoyo3;
                            break;
                        case 4:
                            ResultadoInt = ResultadoInt + Hoyo4;
                            ValorHoyo = Hoyo4;
                            break;
                        case 5:
                            ResultadoInt = ResultadoInt + Hoyo5;
                            ValorHoyo = Hoyo5;
                            break;
                        case 6:
                            ResultadoInt = ResultadoInt + Hoyo6;
                            ValorHoyo = Hoyo6;
                            break;
                        case 7:
                            ResultadoInt = ResultadoInt + Hoyo7;
                            ValorHoyo = Hoyo7;
                            break;
                        case 8:
                            ResultadoInt = ResultadoInt - Hoyo8;
                            ValorHoyo = Hoyo8;
                            break;
                        case 9:
                            ResultadoInt = ResultadoInt + Hoyo9;
                            ValorHoyo = Hoyo9;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    if (ValorHoyo < 1)
                    {
                        Presion1 = Presion1 + ValorHoyo;
                    }
                    else
                    {
                        Presion1 -= 1;
                    }

                    ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt);

                    if (Presion1 <= -4)
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion + Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion + Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion + Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion + Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion + Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion + Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion + Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion + Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion + Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
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

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor1 = Convert.ToString(Presion);
                            }

                            if (PresionValor2 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor2);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor2 = Convert.ToString(Presion);
                            }

                            if (PresionValor3 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor3);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

                                PresionValor3 = Convert.ToString(Presion);
                            }

                            if (PresionValor4 != "")
                            {
                                int Presion = Convert.ToInt32(PresionValor4);

                                switch (i)
                                {
                                    case 1:
                                        Presion = Presion - Hoyo1;
                                        break;
                                    case 2:
                                        Presion = Presion - Hoyo2;
                                        break;
                                    case 3:
                                        Presion = Presion - Hoyo3;
                                        break;
                                    case 4:
                                        Presion = Presion - Hoyo4;
                                        break;
                                    case 5:
                                        Presion = Presion - Hoyo5;
                                        break;
                                    case 6:
                                        Presion = Presion - Hoyo6;
                                        break;
                                    case 7:
                                        Presion = Presion - Hoyo7;
                                        break;
                                    case 8:
                                        Presion = Presion - Hoyo8;
                                        break;
                                    case 9:
                                        Presion = Presion - Hoyo9;
                                        break;
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }

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

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }


                            PresionValor1 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1;
                        }

                        if (PresionValor2 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor2);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                            PresionValor2 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2;
                        }

                        if (PresionValor3 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor3);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor3 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;
                        }

                        if (PresionValor4 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor4);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion + Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion + Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion + Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion + Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion + Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion + Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion + Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion + Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion + Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

                            PresionValor4 = Convert.ToString(Presion);

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;
                        }

                        if (PresionValor5 != "")
                        {
                            int Presion = Convert.ToInt32(PresionValor5);

                            switch (i)
                            {
                                case 1:
                                    Presion = Presion - Hoyo1;
                                    break;
                                case 2:
                                    Presion = Presion - Hoyo2;
                                    break;
                                case 3:
                                    Presion = Presion - Hoyo3;
                                    break;
                                case 4:
                                    Presion = Presion - Hoyo4;
                                    break;
                                case 5:
                                    Presion = Presion - Hoyo5;
                                    break;
                                case 6:
                                    Presion = Presion - Hoyo6;
                                    break;
                                case 7:
                                    Presion = Presion - Hoyo7;
                                    break;
                                case 8:
                                    Presion = Presion - Hoyo8;
                                    break;
                                case 9:
                                    Presion = Presion - Hoyo9;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }

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


            ResultadoString = ResultadointFinal + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4 + ", " + PresionValor5 + ", " + PresionValor6 + ", " + PresionValor7 + ", " + PresionValor8 + ", " + PresionValor9;

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


        private int ActualizarAPuesta(int IDBetDetail, int IDBet, int IDRonda, int BetD_Player1, int BetD_Player2, string BetD_F9_1, string BetD_F9_2, string BetD_F9_3, string BetD_F9_4, string BetD_F9_5, string BetD_F9_6, string BetD_F9_7, string BetD_F9_8, string BetD_F9_9,
                                      string BetD_B9_1, string BetD_B9_2, string BetD_B9_3, string BetD_B9_4, string BetD_B9_5, string BetD_B9_6, string BetD_B9_7, string BetD_B9_8, string BetD_B9_9, int ResultadoFinalMedal, int Match,
                                      string Hoyo_1, string Hoyo_2, string Hoyo_3, string Hoyo_4, string Hoyo_5, string Hoyo_6, string Hoyo_7, string Hoyo_8, string Hoyo_9,
                                      string Hoyo_10, string Hoyo_11, string Hoyo_12, string Hoyo_13, string Hoyo_14, string Hoyo_15, string Hoyo_16, string Hoyo_17, string Hoyo_18
                                      , int Presion, bool ValidaJuegoInicio)
        {


            SqlCommand comando = new SqlCommand("DragoGolf_UpdateDetailBetTeam");
            comando.CommandType = CommandType.StoredProcedure;

            //Declaracion de parametros
            comando.Parameters.Add("@IDBet", SqlDbType.Int);
            comando.Parameters.Add("@IDBetDetail", SqlDbType.Int);
            comando.Parameters.Add("@IDRonda", SqlDbType.Int);
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


            //Asignacion de valores a parametros
            comando.Parameters["@IDBet"].Value = IDBet;
            comando.Parameters["@IDBetDetail"].Value = IDBetDetail;
            comando.Parameters["@IDRonda"].Value = IDRonda;
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


            comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
            comando.CommandTimeout = 0;
            comando.Connection.Open();

            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            comando.Connection.Close();
            DA.Fill(DT);


            return 0;
        }


        private int[] HoyoInicialCambio(int hole1_P1, int hole2_P1, int hole3_P1, int hole4_P1, int hole5_P1, int hole6_P1, int hole7_P1, int hole8_P1, int hole9_P1, int hole10_P1, int hole11_P1, int hole12_P1, int hole13_P1, int hole14_P1, int hole15_P1, int hole16_P1, int hole17_P1, int hole18_P1,
            int hole1_P2, int hole2_P2, int hole3_P2, int hole4_P2, int hole5_P2, int hole6_P2, int hole7_P2, int hole8_P2, int hole9_P2, int hole10_P2, int hole11_P2, int hole12_P2, int hole13_P2, int hole14_P2, int hole15_P2, int hole16_P2, int hole17_P2, int hole18_P2,
            int hole1_P3, int hole2_P3, int hole3_P3, int hole4_P3, int hole5_P3, int hole6_P3, int hole7_P3, int hole8_P3, int hole9_P3, int hole10_P3, int hole11_P3, int hole12_P3, int hole13_P3, int hole14_P3, int hole15_P3, int hole16_P3, int hole17_P3, int hole18_P3,
            int hole1_P4, int hole2_P4, int hole3_P4, int hole4_P4, int hole5_P4, int hole6_P4, int hole7_P4, int hole8_P4, int hole9_P4, int hole10_P4, int hole11_P4, int hole12_P4, int hole13_P4, int hole14_P4, int hole15_P4, int hole16_P4, int hole17_P4, int hole18_P4, int HoyoInicial)
        {

            int[] SwitchHoles_P1 = new int[19];
            int[] SwitchHoles_P2 = new int[19];
            int[] SwitchHoles_P3 = new int[19];
            int[] SwitchHoles_P4 = new int[19];

            int[] SwitchHoles = new int[76];


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

                    SwitchHoles_P3[1] = hole1_P3;
                    SwitchHoles_P3[2] = hole2_P3;
                    SwitchHoles_P3[3] = hole3_P3;
                    SwitchHoles_P3[4] = hole4_P3;
                    SwitchHoles_P3[5] = hole5_P3;
                    SwitchHoles_P3[6] = hole6_P3;
                    SwitchHoles_P3[7] = hole7_P3;
                    SwitchHoles_P3[8] = hole8_P3;
                    SwitchHoles_P3[9] = hole9_P3;
                    SwitchHoles_P3[10] = hole10_P3;
                    SwitchHoles_P3[11] = hole11_P3;
                    SwitchHoles_P3[12] = hole12_P3;
                    SwitchHoles_P3[13] = hole13_P3;
                    SwitchHoles_P3[14] = hole14_P3;
                    SwitchHoles_P3[15] = hole15_P3;
                    SwitchHoles_P3[16] = hole16_P3;
                    SwitchHoles_P3[17] = hole17_P3;
                    SwitchHoles_P3[18] = hole18_P3;

                    SwitchHoles_P4[1] = hole1_P4;
                    SwitchHoles_P4[2] = hole2_P4;
                    SwitchHoles_P4[3] = hole3_P4;
                    SwitchHoles_P4[4] = hole4_P4;
                    SwitchHoles_P4[5] = hole5_P4;
                    SwitchHoles_P4[6] = hole6_P4;
                    SwitchHoles_P4[7] = hole7_P4;
                    SwitchHoles_P4[8] = hole8_P4;
                    SwitchHoles_P4[9] = hole9_P4;
                    SwitchHoles_P4[10] = hole10_P4;
                    SwitchHoles_P4[11] = hole11_P4;
                    SwitchHoles_P4[12] = hole12_P4;
                    SwitchHoles_P4[13] = hole13_P4;
                    SwitchHoles_P4[14] = hole14_P4;
                    SwitchHoles_P4[15] = hole15_P4;
                    SwitchHoles_P4[16] = hole16_P4;
                    SwitchHoles_P4[17] = hole17_P4;
                    SwitchHoles_P4[18] = hole18_P4;


                    break;
                case 2:
                    //OK
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

                    SwitchHoles_P3[1] = hole18_P3;
                    SwitchHoles_P3[2] = hole1_P3;
                    SwitchHoles_P3[3] = hole2_P3;
                    SwitchHoles_P3[4] = hole3_P3;
                    SwitchHoles_P3[5] = hole4_P3;
                    SwitchHoles_P3[6] = hole5_P3;
                    SwitchHoles_P3[7] = hole6_P3;
                    SwitchHoles_P3[8] = hole7_P3;
                    SwitchHoles_P3[9] = hole8_P3;
                    SwitchHoles_P3[10] = hole9_P3;
                    SwitchHoles_P3[11] = hole10_P3;
                    SwitchHoles_P3[12] = hole11_P3;
                    SwitchHoles_P3[13] = hole12_P3;
                    SwitchHoles_P3[14] = hole13_P3;
                    SwitchHoles_P3[15] = hole14_P3;
                    SwitchHoles_P3[16] = hole15_P3;
                    SwitchHoles_P3[17] = hole16_P3;
                    SwitchHoles_P3[18] = hole17_P3;

                    SwitchHoles_P4[1] = hole18_P4;
                    SwitchHoles_P4[2] = hole1_P4;
                    SwitchHoles_P4[3] = hole2_P4;
                    SwitchHoles_P4[4] = hole3_P4;
                    SwitchHoles_P4[5] = hole4_P4;
                    SwitchHoles_P4[6] = hole5_P4;
                    SwitchHoles_P4[7] = hole6_P4;
                    SwitchHoles_P4[8] = hole7_P4;
                    SwitchHoles_P4[9] = hole8_P4;
                    SwitchHoles_P4[10] = hole9_P4;
                    SwitchHoles_P4[11] = hole10_P4;
                    SwitchHoles_P4[12] = hole11_P4;
                    SwitchHoles_P4[13] = hole12_P4;
                    SwitchHoles_P4[14] = hole13_P4;
                    SwitchHoles_P4[15] = hole14_P4;
                    SwitchHoles_P4[16] = hole15_P4;
                    SwitchHoles_P4[17] = hole16_P4;
                    SwitchHoles_P4[18] = hole17_P4;

                    break;
                case 3:
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

                    SwitchHoles_P3[1] = hole17_P3;
                    SwitchHoles_P3[2] = hole18_P3;
                    SwitchHoles_P3[3] = hole1_P3;
                    SwitchHoles_P3[4] = hole2_P3;
                    SwitchHoles_P3[5] = hole3_P3;
                    SwitchHoles_P3[6] = hole4_P3;
                    SwitchHoles_P3[7] = hole5_P3;
                    SwitchHoles_P3[8] = hole6_P3;
                    SwitchHoles_P3[9] = hole7_P3;
                    SwitchHoles_P3[10] = hole8_P3;
                    SwitchHoles_P3[11] = hole9_P3;
                    SwitchHoles_P3[12] = hole10_P3;
                    SwitchHoles_P3[13] = hole11_P3;
                    SwitchHoles_P3[14] = hole12_P3;
                    SwitchHoles_P3[15] = hole13_P3;
                    SwitchHoles_P3[16] = hole14_P3;
                    SwitchHoles_P3[17] = hole15_P3;
                    SwitchHoles_P3[18] = hole16_P3;

                    SwitchHoles_P4[1] = hole17_P4;
                    SwitchHoles_P4[2] = hole18_P4;
                    SwitchHoles_P4[3] = hole1_P4;
                    SwitchHoles_P4[4] = hole2_P4;
                    SwitchHoles_P4[5] = hole3_P4;
                    SwitchHoles_P4[6] = hole4_P4;
                    SwitchHoles_P4[7] = hole5_P4;
                    SwitchHoles_P4[8] = hole6_P4;
                    SwitchHoles_P4[9] = hole7_P4;
                    SwitchHoles_P4[10] = hole8_P4;
                    SwitchHoles_P4[11] = hole9_P4;
                    SwitchHoles_P4[12] = hole10_P4;
                    SwitchHoles_P4[13] = hole11_P4;
                    SwitchHoles_P4[14] = hole12_P4;
                    SwitchHoles_P4[15] = hole13_P4;
                    SwitchHoles_P4[16] = hole14_P4;
                    SwitchHoles_P4[17] = hole15_P4;
                    SwitchHoles_P4[18] = hole16_P4;

                    break;
                case 4:
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

                    SwitchHoles_P3[1] = hole16_P3;
                    SwitchHoles_P3[2] = hole17_P3;
                    SwitchHoles_P3[3] = hole18_P3;
                    SwitchHoles_P3[4] = hole1_P3;
                    SwitchHoles_P3[5] = hole2_P3;
                    SwitchHoles_P3[6] = hole3_P3;
                    SwitchHoles_P3[7] = hole4_P3;
                    SwitchHoles_P3[8] = hole5_P3;
                    SwitchHoles_P3[9] = hole6_P3;
                    SwitchHoles_P3[10] = hole7_P3;
                    SwitchHoles_P3[11] = hole8_P3;
                    SwitchHoles_P3[12] = hole9_P3;
                    SwitchHoles_P3[13] = hole10_P3;
                    SwitchHoles_P3[14] = hole11_P3;
                    SwitchHoles_P3[15] = hole12_P3;
                    SwitchHoles_P3[16] = hole13_P3;
                    SwitchHoles_P3[17] = hole14_P3;
                    SwitchHoles_P3[18] = hole15_P3;

                    SwitchHoles_P4[1] = hole16_P4;
                    SwitchHoles_P4[2] = hole17_P4;
                    SwitchHoles_P4[3] = hole18_P4;
                    SwitchHoles_P4[4] = hole1_P4;
                    SwitchHoles_P4[5] = hole2_P4;
                    SwitchHoles_P4[6] = hole3_P4;
                    SwitchHoles_P4[7] = hole4_P4;
                    SwitchHoles_P4[8] = hole5_P4;
                    SwitchHoles_P4[9] = hole6_P4;
                    SwitchHoles_P4[10] = hole7_P4;
                    SwitchHoles_P4[11] = hole8_P4;
                    SwitchHoles_P4[12] = hole9_P4;
                    SwitchHoles_P4[13] = hole10_P4;
                    SwitchHoles_P4[14] = hole11_P4;
                    SwitchHoles_P4[15] = hole12_P4;
                    SwitchHoles_P4[16] = hole13_P4;
                    SwitchHoles_P4[17] = hole14_P4;
                    SwitchHoles_P4[18] = hole15_P4;

                    break;
                case 5:
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

                    SwitchHoles_P3[1] = hole15_P3;
                    SwitchHoles_P3[2] = hole16_P3;
                    SwitchHoles_P3[3] = hole17_P3;
                    SwitchHoles_P3[4] = hole18_P3;
                    SwitchHoles_P3[5] = hole1_P3;
                    SwitchHoles_P3[6] = hole2_P3;
                    SwitchHoles_P3[7] = hole3_P3;
                    SwitchHoles_P3[8] = hole4_P3;
                    SwitchHoles_P3[9] = hole5_P3;
                    SwitchHoles_P3[10] = hole6_P3;
                    SwitchHoles_P3[11] = hole7_P3;
                    SwitchHoles_P3[12] = hole8_P3;
                    SwitchHoles_P3[13] = hole9_P3;
                    SwitchHoles_P3[14] = hole10_P3;
                    SwitchHoles_P3[15] = hole11_P3;
                    SwitchHoles_P3[16] = hole12_P3;
                    SwitchHoles_P3[17] = hole13_P3;
                    SwitchHoles_P3[18] = hole14_P3;

                    SwitchHoles_P4[1] = hole15_P4;
                    SwitchHoles_P4[2] = hole16_P4;
                    SwitchHoles_P4[3] = hole17_P4;
                    SwitchHoles_P4[4] = hole18_P4;
                    SwitchHoles_P4[5] = hole1_P4;
                    SwitchHoles_P4[6] = hole2_P4;
                    SwitchHoles_P4[7] = hole3_P4;
                    SwitchHoles_P4[8] = hole4_P4;
                    SwitchHoles_P4[9] = hole5_P4;
                    SwitchHoles_P4[10] = hole6_P4;
                    SwitchHoles_P4[11] = hole7_P4;
                    SwitchHoles_P4[12] = hole8_P4;
                    SwitchHoles_P4[13] = hole9_P4;
                    SwitchHoles_P4[14] = hole10_P4;
                    SwitchHoles_P4[15] = hole11_P4;
                    SwitchHoles_P4[16] = hole12_P4;
                    SwitchHoles_P4[17] = hole13_P4;
                    SwitchHoles_P4[18] = hole14_P4;

                    break;
                case 6:
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

                    SwitchHoles_P3[1] = hole14_P3;
                    SwitchHoles_P3[2] = hole15_P3;
                    SwitchHoles_P3[3] = hole16_P3;
                    SwitchHoles_P3[4] = hole17_P3;
                    SwitchHoles_P3[5] = hole18_P3;
                    SwitchHoles_P3[6] = hole1_P3;
                    SwitchHoles_P3[7] = hole2_P3;
                    SwitchHoles_P3[8] = hole3_P3;
                    SwitchHoles_P3[9] = hole4_P3;
                    SwitchHoles_P3[10] = hole5_P3;
                    SwitchHoles_P3[11] = hole6_P3;
                    SwitchHoles_P3[12] = hole7_P3;
                    SwitchHoles_P3[13] = hole8_P3;
                    SwitchHoles_P3[14] = hole9_P3;
                    SwitchHoles_P3[15] = hole10_P3;
                    SwitchHoles_P3[16] = hole11_P3;
                    SwitchHoles_P3[17] = hole12_P3;
                    SwitchHoles_P3[18] = hole13_P3;

                    SwitchHoles_P4[1] = hole14_P4;
                    SwitchHoles_P4[2] = hole15_P4;
                    SwitchHoles_P4[3] = hole16_P4;
                    SwitchHoles_P4[4] = hole17_P4;
                    SwitchHoles_P4[5] = hole18_P4;
                    SwitchHoles_P4[6] = hole1_P4;
                    SwitchHoles_P4[7] = hole2_P4;
                    SwitchHoles_P4[8] = hole3_P4;
                    SwitchHoles_P4[9] = hole4_P4;
                    SwitchHoles_P4[10] = hole5_P4;
                    SwitchHoles_P4[11] = hole6_P4;
                    SwitchHoles_P4[12] = hole7_P4;
                    SwitchHoles_P4[13] = hole8_P4;
                    SwitchHoles_P4[14] = hole9_P4;
                    SwitchHoles_P4[15] = hole10_P4;
                    SwitchHoles_P4[16] = hole11_P4;
                    SwitchHoles_P4[17] = hole12_P4;
                    SwitchHoles_P4[18] = hole13_P4;

                    break;
                case 7:
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

                    SwitchHoles_P2[1] = hole13_P2;
                    SwitchHoles_P2[2] = hole14_P2;
                    SwitchHoles_P2[3] = hole15_P2;
                    SwitchHoles_P2[4] = hole16_P2;
                    SwitchHoles_P2[5] = hole17_P2;
                    SwitchHoles_P2[6] = hole18_P2;
                    SwitchHoles_P2[7] = hole1_P2;
                    SwitchHoles_P2[8] = hole2_P2;
                    SwitchHoles_P2[9] = hole3_P2;
                    SwitchHoles_P2[10] = hole4_P2;
                    SwitchHoles_P2[11] = hole5_P2;
                    SwitchHoles_P2[12] = hole6_P2;
                    SwitchHoles_P2[13] = hole7_P2;
                    SwitchHoles_P2[14] = hole8_P2;
                    SwitchHoles_P2[15] = hole9_P2;
                    SwitchHoles_P2[16] = hole10_P2;
                    SwitchHoles_P2[17] = hole11_P2;
                    SwitchHoles_P2[18] = hole12_P2;

                    SwitchHoles_P3[1] = hole13_P3;
                    SwitchHoles_P3[2] = hole14_P3;
                    SwitchHoles_P3[3] = hole15_P3;
                    SwitchHoles_P3[4] = hole16_P3;
                    SwitchHoles_P3[5] = hole17_P3;
                    SwitchHoles_P3[6] = hole18_P3;
                    SwitchHoles_P3[7] = hole1_P3;
                    SwitchHoles_P3[8] = hole2_P3;
                    SwitchHoles_P3[9] = hole3_P3;
                    SwitchHoles_P3[10] = hole4_P3;
                    SwitchHoles_P3[11] = hole5_P3;
                    SwitchHoles_P3[12] = hole6_P3;
                    SwitchHoles_P3[13] = hole7_P3;
                    SwitchHoles_P3[14] = hole8_P3;
                    SwitchHoles_P3[15] = hole9_P3;
                    SwitchHoles_P3[16] = hole10_P3;
                    SwitchHoles_P3[17] = hole11_P3;
                    SwitchHoles_P3[18] = hole12_P3;

                    SwitchHoles_P4[1] = hole13_P4;
                    SwitchHoles_P4[2] = hole14_P4;
                    SwitchHoles_P4[3] = hole15_P4;
                    SwitchHoles_P4[4] = hole16_P4;
                    SwitchHoles_P4[5] = hole17_P4;
                    SwitchHoles_P4[6] = hole18_P4;
                    SwitchHoles_P4[7] = hole1_P4;
                    SwitchHoles_P4[8] = hole2_P4;
                    SwitchHoles_P4[9] = hole3_P4;
                    SwitchHoles_P4[10] = hole4_P4;
                    SwitchHoles_P4[11] = hole5_P4;
                    SwitchHoles_P4[12] = hole6_P4;
                    SwitchHoles_P4[13] = hole7_P4;
                    SwitchHoles_P4[14] = hole8_P4;
                    SwitchHoles_P4[15] = hole9_P4;
                    SwitchHoles_P4[16] = hole10_P4;
                    SwitchHoles_P4[17] = hole11_P4;
                    SwitchHoles_P4[18] = hole12_P4;

                    break;
                case 8:

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

                    SwitchHoles_P3[1] = hole12_P3;
                    SwitchHoles_P3[2] = hole13_P3;
                    SwitchHoles_P3[3] = hole14_P3;
                    SwitchHoles_P3[4] = hole15_P3;
                    SwitchHoles_P3[5] = hole16_P3;
                    SwitchHoles_P3[6] = hole17_P3;
                    SwitchHoles_P3[7] = hole18_P3;
                    SwitchHoles_P3[8] = hole1_P3;
                    SwitchHoles_P3[9] = hole2_P3;
                    SwitchHoles_P3[10] = hole3_P3;
                    SwitchHoles_P3[11] = hole4_P3;
                    SwitchHoles_P3[12] = hole5_P3;
                    SwitchHoles_P3[13] = hole6_P3;
                    SwitchHoles_P3[14] = hole7_P3;
                    SwitchHoles_P3[15] = hole8_P3;
                    SwitchHoles_P3[16] = hole9_P3;
                    SwitchHoles_P3[17] = hole10_P3;
                    SwitchHoles_P3[18] = hole11_P3;

                    SwitchHoles_P4[1] = hole12_P4;
                    SwitchHoles_P4[2] = hole13_P4;
                    SwitchHoles_P4[3] = hole14_P4;
                    SwitchHoles_P4[4] = hole15_P4;
                    SwitchHoles_P4[5] = hole16_P4;
                    SwitchHoles_P4[6] = hole17_P4;
                    SwitchHoles_P4[7] = hole18_P4;
                    SwitchHoles_P4[8] = hole1_P4;
                    SwitchHoles_P4[9] = hole2_P4;
                    SwitchHoles_P4[10] = hole3_P4;
                    SwitchHoles_P4[11] = hole4_P4;
                    SwitchHoles_P4[12] = hole5_P4;
                    SwitchHoles_P4[13] = hole6_P4;
                    SwitchHoles_P4[14] = hole7_P4;
                    SwitchHoles_P4[15] = hole8_P4;
                    SwitchHoles_P4[16] = hole9_P4;
                    SwitchHoles_P4[17] = hole10_P4;
                    SwitchHoles_P4[18] = hole11_P4;

                    break;
                case 9:
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

                    SwitchHoles_P3[1] = hole11_P3;
                    SwitchHoles_P3[2] = hole12_P3;
                    SwitchHoles_P3[3] = hole13_P3;
                    SwitchHoles_P3[4] = hole14_P3;
                    SwitchHoles_P3[5] = hole15_P3;
                    SwitchHoles_P3[6] = hole16_P3;
                    SwitchHoles_P3[7] = hole17_P3;
                    SwitchHoles_P3[8] = hole18_P3;
                    SwitchHoles_P3[9] = hole1_P3;
                    SwitchHoles_P3[10] = hole2_P3;
                    SwitchHoles_P3[11] = hole3_P3;
                    SwitchHoles_P3[12] = hole4_P3;
                    SwitchHoles_P3[13] = hole5_P3;
                    SwitchHoles_P3[14] = hole6_P3;
                    SwitchHoles_P3[15] = hole7_P3;
                    SwitchHoles_P3[16] = hole8_P3;
                    SwitchHoles_P3[17] = hole9_P3;
                    SwitchHoles_P3[18] = hole10_P3;

                    SwitchHoles_P4[1] = hole11_P4;
                    SwitchHoles_P4[2] = hole12_P4;
                    SwitchHoles_P4[3] = hole13_P4;
                    SwitchHoles_P4[4] = hole14_P4;
                    SwitchHoles_P4[5] = hole15_P4;
                    SwitchHoles_P4[6] = hole16_P4;
                    SwitchHoles_P4[7] = hole17_P4;
                    SwitchHoles_P4[8] = hole18_P4;
                    SwitchHoles_P4[9] = hole1_P4;
                    SwitchHoles_P4[10] = hole2_P4;
                    SwitchHoles_P4[11] = hole3_P4;
                    SwitchHoles_P4[12] = hole4_P4;
                    SwitchHoles_P4[13] = hole5_P4;
                    SwitchHoles_P4[14] = hole6_P4;
                    SwitchHoles_P4[15] = hole7_P4;
                    SwitchHoles_P4[16] = hole8_P4;
                    SwitchHoles_P4[17] = hole9_P4;
                    SwitchHoles_P4[18] = hole10_P4;

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

                    SwitchHoles_P3[1] = hole11_P3;
                    SwitchHoles_P3[2] = hole12_P3;
                    SwitchHoles_P3[3] = hole13_P3;
                    SwitchHoles_P3[4] = hole14_P3;
                    SwitchHoles_P3[5] = hole15_P3;
                    SwitchHoles_P3[6] = hole16_P3;
                    SwitchHoles_P3[7] = hole17_P3;
                    SwitchHoles_P3[8] = hole18_P3;
                    SwitchHoles_P3[9] = hole1_P3;
                    SwitchHoles_P3[10] = hole2_P3;
                    SwitchHoles_P3[11] = hole3_P3;
                    SwitchHoles_P3[12] = hole4_P3;
                    SwitchHoles_P3[13] = hole5_P3;
                    SwitchHoles_P3[14] = hole6_P3;
                    SwitchHoles_P3[15] = hole7_P3;
                    SwitchHoles_P3[16] = hole8_P3;
                    SwitchHoles_P3[17] = hole9_P3;
                    SwitchHoles_P3[18] = hole10_P3;

                    SwitchHoles_P4[1] = hole11_P4;
                    SwitchHoles_P4[2] = hole12_P4;
                    SwitchHoles_P4[3] = hole13_P4;
                    SwitchHoles_P4[4] = hole14_P4;
                    SwitchHoles_P4[5] = hole15_P4;
                    SwitchHoles_P4[6] = hole16_P4;
                    SwitchHoles_P4[7] = hole17_P4;
                    SwitchHoles_P4[8] = hole18_P4;
                    SwitchHoles_P4[9] = hole1_P4;
                    SwitchHoles_P4[10] = hole2_P4;
                    SwitchHoles_P4[11] = hole3_P4;
                    SwitchHoles_P4[12] = hole4_P4;
                    SwitchHoles_P4[13] = hole5_P4;
                    SwitchHoles_P4[14] = hole6_P4;
                    SwitchHoles_P4[15] = hole7_P4;
                    SwitchHoles_P4[16] = hole8_P4;
                    SwitchHoles_P4[17] = hole9_P4;
                    SwitchHoles_P4[18] = hole10_P4;

                    break;
                case 11:

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
                case 12:

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

                    SwitchHoles_P2[1] = hole8_P3;
                    SwitchHoles_P2[2] = hole9_P3;
                    SwitchHoles_P2[3] = hole10_P3;
                    SwitchHoles_P2[4] = hole11_P3;
                    SwitchHoles_P2[5] = hole12_P3;
                    SwitchHoles_P2[6] = hole13_P3;
                    SwitchHoles_P2[7] = hole14_P3;
                    SwitchHoles_P2[8] = hole15_P3;
                    SwitchHoles_P2[9] = hole16_P3;
                    SwitchHoles_P2[10] = hole17_P3;
                    SwitchHoles_P2[11] = hole18_P3;
                    SwitchHoles_P2[12] = hole1_P3;
                    SwitchHoles_P2[13] = hole2_P3;
                    SwitchHoles_P2[14] = hole3_P3;
                    SwitchHoles_P2[15] = hole4_P3;
                    SwitchHoles_P2[16] = hole5_P3;
                    SwitchHoles_P2[17] = hole6_P3;
                    SwitchHoles_P2[18] = hole7_P3;

                    SwitchHoles_P4[1] = hole8_P4;
                    SwitchHoles_P4[2] = hole9_P4;
                    SwitchHoles_P4[3] = hole10_P4;
                    SwitchHoles_P4[4] = hole11_P4;
                    SwitchHoles_P4[5] = hole12_P4;
                    SwitchHoles_P4[6] = hole13_P4;
                    SwitchHoles_P4[7] = hole14_P4;
                    SwitchHoles_P4[8] = hole15_P4;
                    SwitchHoles_P4[9] = hole16_P4;
                    SwitchHoles_P4[10] = hole17_P4;
                    SwitchHoles_P4[11] = hole18_P4;
                    SwitchHoles_P4[12] = hole1_P4;
                    SwitchHoles_P4[13] = hole2_P4;
                    SwitchHoles_P4[14] = hole3_P4;
                    SwitchHoles_P4[15] = hole4_P4;
                    SwitchHoles_P4[16] = hole5_P4;
                    SwitchHoles_P4[17] = hole6_P4;
                    SwitchHoles_P4[18] = hole7_P4;

                    break;
                case 13:

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

                    SwitchHoles_P3[1] = hole7_P3;
                    SwitchHoles_P3[2] = hole8_P3;
                    SwitchHoles_P3[3] = hole9_P3;
                    SwitchHoles_P3[4] = hole10_P3;
                    SwitchHoles_P3[5] = hole11_P3;
                    SwitchHoles_P3[6] = hole12_P3;
                    SwitchHoles_P3[7] = hole13_P3;
                    SwitchHoles_P3[8] = hole14_P3;
                    SwitchHoles_P3[9] = hole15_P3;
                    SwitchHoles_P3[10] = hole16_P3;
                    SwitchHoles_P3[11] = hole17_P3;
                    SwitchHoles_P3[12] = hole18_P3;
                    SwitchHoles_P3[13] = hole1_P3;
                    SwitchHoles_P3[14] = hole2_P3;
                    SwitchHoles_P3[15] = hole3_P3;
                    SwitchHoles_P3[16] = hole4_P3;
                    SwitchHoles_P3[17] = hole5_P3;
                    SwitchHoles_P3[18] = hole6_P3;

                    SwitchHoles_P4[1] = hole7_P4;
                    SwitchHoles_P4[2] = hole8_P4;
                    SwitchHoles_P4[3] = hole9_P4;
                    SwitchHoles_P4[4] = hole10_P4;
                    SwitchHoles_P4[5] = hole11_P4;
                    SwitchHoles_P4[6] = hole12_P4;
                    SwitchHoles_P4[7] = hole13_P4;
                    SwitchHoles_P4[8] = hole14_P4;
                    SwitchHoles_P4[9] = hole15_P4;
                    SwitchHoles_P4[10] = hole16_P4;
                    SwitchHoles_P4[11] = hole17_P4;
                    SwitchHoles_P4[12] = hole18_P4;
                    SwitchHoles_P4[13] = hole1_P4;
                    SwitchHoles_P4[14] = hole2_P4;
                    SwitchHoles_P4[15] = hole3_P4;
                    SwitchHoles_P4[16] = hole4_P4;
                    SwitchHoles_P4[17] = hole5_P4;
                    SwitchHoles_P4[18] = hole6_P4;

                    break;
                case 14:

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

                    SwitchHoles_P3[1] = hole6_P3;
                    SwitchHoles_P3[2] = hole7_P3;
                    SwitchHoles_P3[3] = hole8_P3;
                    SwitchHoles_P3[4] = hole9_P3;
                    SwitchHoles_P3[5] = hole10_P3;
                    SwitchHoles_P3[6] = hole11_P3;
                    SwitchHoles_P3[7] = hole12_P3;
                    SwitchHoles_P3[8] = hole13_P3;
                    SwitchHoles_P3[9] = hole14_P3;
                    SwitchHoles_P3[10] = hole15_P3;
                    SwitchHoles_P3[11] = hole16_P3;
                    SwitchHoles_P3[12] = hole17_P3;
                    SwitchHoles_P3[13] = hole18_P3;
                    SwitchHoles_P3[14] = hole1_P3;
                    SwitchHoles_P3[15] = hole2_P3;
                    SwitchHoles_P3[16] = hole3_P3;
                    SwitchHoles_P3[17] = hole4_P3;
                    SwitchHoles_P3[18] = hole5_P3;

                    SwitchHoles_P4[1] = hole6_P4;
                    SwitchHoles_P4[2] = hole7_P4;
                    SwitchHoles_P4[3] = hole8_P4;
                    SwitchHoles_P4[4] = hole9_P4;
                    SwitchHoles_P4[5] = hole10_P4;
                    SwitchHoles_P4[6] = hole11_P4;
                    SwitchHoles_P4[7] = hole12_P4;
                    SwitchHoles_P4[8] = hole13_P4;
                    SwitchHoles_P4[9] = hole14_P4;
                    SwitchHoles_P4[10] = hole15_P4;
                    SwitchHoles_P4[11] = hole16_P4;
                    SwitchHoles_P4[12] = hole17_P4;
                    SwitchHoles_P4[13] = hole18_P4;
                    SwitchHoles_P4[14] = hole1_P4;
                    SwitchHoles_P4[15] = hole2_P4;
                    SwitchHoles_P4[16] = hole3_P4;
                    SwitchHoles_P4[17] = hole4_P4;
                    SwitchHoles_P4[18] = hole5_P4;

                    break;
                case 15:

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

                    SwitchHoles_P3[1] = hole5_P3;
                    SwitchHoles_P3[2] = hole6_P3;
                    SwitchHoles_P3[3] = hole7_P3;
                    SwitchHoles_P3[4] = hole8_P3;
                    SwitchHoles_P3[5] = hole9_P3;
                    SwitchHoles_P3[6] = hole10_P3;
                    SwitchHoles_P3[7] = hole11_P3;
                    SwitchHoles_P3[8] = hole12_P3;
                    SwitchHoles_P3[9] = hole13_P3;
                    SwitchHoles_P3[10] = hole14_P3;
                    SwitchHoles_P3[11] = hole15_P3;
                    SwitchHoles_P3[12] = hole16_P3;
                    SwitchHoles_P3[13] = hole17_P3;
                    SwitchHoles_P3[14] = hole18_P3;
                    SwitchHoles_P3[15] = hole1_P3;
                    SwitchHoles_P3[16] = hole2_P3;
                    SwitchHoles_P3[17] = hole3_P3;
                    SwitchHoles_P3[18] = hole4_P3;

                    SwitchHoles_P4[1] = hole5_P4;
                    SwitchHoles_P4[2] = hole6_P4;
                    SwitchHoles_P4[3] = hole7_P4;
                    SwitchHoles_P4[4] = hole8_P4;
                    SwitchHoles_P4[5] = hole9_P4;
                    SwitchHoles_P4[6] = hole10_P4;
                    SwitchHoles_P4[7] = hole11_P4;
                    SwitchHoles_P4[8] = hole12_P4;
                    SwitchHoles_P4[9] = hole13_P4;
                    SwitchHoles_P4[10] = hole14_P4;
                    SwitchHoles_P4[11] = hole15_P4;
                    SwitchHoles_P4[12] = hole16_P4;
                    SwitchHoles_P4[13] = hole17_P4;
                    SwitchHoles_P4[14] = hole18_P4;
                    SwitchHoles_P4[15] = hole1_P4;
                    SwitchHoles_P4[16] = hole2_P4;
                    SwitchHoles_P4[17] = hole3_P4;
                    SwitchHoles_P4[18] = hole4_P4;

                    break;
                case 16:

                    SwitchHoles_P1[1] = hole4_P1;
                    SwitchHoles_P1[2] = hole5_P1;
                    SwitchHoles_P1[3] = hole6_P1;
                    SwitchHoles_P1[4] = hole7_P1;
                    SwitchHoles_P1[5] = hole8_P1;
                    SwitchHoles_P1[6] = hole9_P1;
                    SwitchHoles_P1[7] = hole10_P1;
                    SwitchHoles_P1[8] = hole11_P1;
                    SwitchHoles_P1[9] = hole12_P1;
                    SwitchHoles_P1[10] = hole13_P1;
                    SwitchHoles_P1[11] = hole14_P1;
                    SwitchHoles_P1[12] = hole15_P1;
                    SwitchHoles_P1[13] = hole16_P1;
                    SwitchHoles_P1[14] = hole17_P1;
                    SwitchHoles_P1[15] = hole18_P1;
                    SwitchHoles_P1[16] = hole1_P1;
                    SwitchHoles_P1[17] = hole2_P1;
                    SwitchHoles_P1[18] = hole3_P1;

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

                    SwitchHoles_P3[1] = hole4_P3;
                    SwitchHoles_P3[2] = hole5_P3;
                    SwitchHoles_P3[3] = hole6_P3;
                    SwitchHoles_P3[4] = hole7_P3;
                    SwitchHoles_P3[5] = hole8_P3;
                    SwitchHoles_P3[6] = hole9_P3;
                    SwitchHoles_P3[7] = hole10_P3;
                    SwitchHoles_P3[8] = hole11_P3;
                    SwitchHoles_P3[9] = hole12_P3;
                    SwitchHoles_P3[10] = hole13_P3;
                    SwitchHoles_P3[11] = hole14_P3;
                    SwitchHoles_P3[12] = hole15_P3;
                    SwitchHoles_P3[13] = hole16_P3;
                    SwitchHoles_P3[14] = hole17_P3;
                    SwitchHoles_P3[15] = hole18_P3;
                    SwitchHoles_P3[16] = hole1_P3;
                    SwitchHoles_P3[17] = hole2_P3;
                    SwitchHoles_P3[18] = hole3_P3;

                    SwitchHoles_P4[1] = hole4_P4;
                    SwitchHoles_P4[2] = hole5_P4;
                    SwitchHoles_P4[3] = hole6_P4;
                    SwitchHoles_P4[4] = hole7_P4;
                    SwitchHoles_P4[5] = hole8_P4;
                    SwitchHoles_P4[6] = hole9_P4;
                    SwitchHoles_P4[7] = hole10_P4;
                    SwitchHoles_P4[8] = hole11_P4;
                    SwitchHoles_P4[9] = hole12_P4;
                    SwitchHoles_P4[10] = hole13_P4;
                    SwitchHoles_P4[11] = hole14_P4;
                    SwitchHoles_P4[12] = hole15_P4;
                    SwitchHoles_P4[13] = hole16_P4;
                    SwitchHoles_P4[14] = hole17_P4;
                    SwitchHoles_P4[15] = hole18_P4;
                    SwitchHoles_P4[16] = hole1_P4;
                    SwitchHoles_P4[17] = hole2_P4;
                    SwitchHoles_P4[18] = hole3_P4;

                    break;
                case 17:

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

                    SwitchHoles_P3[1] = hole3_P3;
                    SwitchHoles_P3[2] = hole4_P3;
                    SwitchHoles_P3[3] = hole5_P3;
                    SwitchHoles_P3[4] = hole6_P3;
                    SwitchHoles_P3[5] = hole7_P3;
                    SwitchHoles_P3[6] = hole8_P3;
                    SwitchHoles_P3[7] = hole9_P3;
                    SwitchHoles_P3[8] = hole10_P3;
                    SwitchHoles_P3[9] = hole11_P3;
                    SwitchHoles_P3[10] = hole12_P3;
                    SwitchHoles_P3[11] = hole13_P3;
                    SwitchHoles_P3[12] = hole14_P3;
                    SwitchHoles_P3[13] = hole15_P3;
                    SwitchHoles_P3[14] = hole16_P3;
                    SwitchHoles_P3[15] = hole17_P3;
                    SwitchHoles_P3[16] = hole18_P3;
                    SwitchHoles_P3[17] = hole1_P3;
                    SwitchHoles_P3[18] = hole2_P3;

                    SwitchHoles_P4[1] = hole3_P4;
                    SwitchHoles_P4[2] = hole4_P4;
                    SwitchHoles_P4[3] = hole5_P4;
                    SwitchHoles_P4[4] = hole6_P4;
                    SwitchHoles_P4[5] = hole7_P4;
                    SwitchHoles_P4[6] = hole8_P4;
                    SwitchHoles_P4[7] = hole9_P4;
                    SwitchHoles_P4[8] = hole10_P4;
                    SwitchHoles_P4[9] = hole11_P4;
                    SwitchHoles_P4[10] = hole12_P4;
                    SwitchHoles_P4[11] = hole13_P4;
                    SwitchHoles_P4[12] = hole14_P4;
                    SwitchHoles_P4[13] = hole15_P4;
                    SwitchHoles_P4[14] = hole16_P4;
                    SwitchHoles_P4[15] = hole17_P4;
                    SwitchHoles_P4[16] = hole18_P4;
                    SwitchHoles_P4[17] = hole1_P4;
                    SwitchHoles_P4[18] = hole2_P4;

                    break;
                case 18:

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

                    SwitchHoles_P3[1] = hole2_P3;
                    SwitchHoles_P3[2] = hole3_P3;
                    SwitchHoles_P3[3] = hole4_P3;
                    SwitchHoles_P3[4] = hole5_P3;
                    SwitchHoles_P3[5] = hole6_P3;
                    SwitchHoles_P3[6] = hole7_P3;
                    SwitchHoles_P3[7] = hole8_P3;
                    SwitchHoles_P3[8] = hole9_P3;
                    SwitchHoles_P3[9] = hole10_P3;
                    SwitchHoles_P3[10] = hole11_P3;
                    SwitchHoles_P3[11] = hole12_P3;
                    SwitchHoles_P3[12] = hole13_P3;
                    SwitchHoles_P3[13] = hole14_P3;
                    SwitchHoles_P3[14] = hole15_P3;
                    SwitchHoles_P3[15] = hole16_P3;
                    SwitchHoles_P3[16] = hole17_P3;
                    SwitchHoles_P3[17] = hole18_P3;
                    SwitchHoles_P3[18] = hole1_P3;

                    SwitchHoles_P4[1] = hole2_P4;
                    SwitchHoles_P4[2] = hole3_P4;
                    SwitchHoles_P4[3] = hole4_P4;
                    SwitchHoles_P4[4] = hole5_P4;
                    SwitchHoles_P4[5] = hole6_P4;
                    SwitchHoles_P4[6] = hole7_P4;
                    SwitchHoles_P4[7] = hole8_P4;
                    SwitchHoles_P4[8] = hole9_P4;
                    SwitchHoles_P4[9] = hole10_P4;
                    SwitchHoles_P4[10] = hole11_P4;
                    SwitchHoles_P4[11] = hole12_P4;
                    SwitchHoles_P4[12] = hole13_P4;
                    SwitchHoles_P4[13] = hole14_P4;
                    SwitchHoles_P4[14] = hole15_P4;
                    SwitchHoles_P4[15] = hole16_P4;
                    SwitchHoles_P4[16] = hole17_P4;
                    SwitchHoles_P4[17] = hole18_P4;
                    SwitchHoles_P4[18] = hole1_P4;

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

            SwitchHoles[37] = SwitchHoles_P3[1];
            SwitchHoles[38] = SwitchHoles_P3[2];
            SwitchHoles[39] = SwitchHoles_P3[3];
            SwitchHoles[40] = SwitchHoles_P3[4];
            SwitchHoles[41] = SwitchHoles_P3[5];
            SwitchHoles[42] = SwitchHoles_P3[6];
            SwitchHoles[43] = SwitchHoles_P3[7];
            SwitchHoles[44] = SwitchHoles_P3[8];
            SwitchHoles[45] = SwitchHoles_P3[9];
            SwitchHoles[46] = SwitchHoles_P3[10];
            SwitchHoles[47] = SwitchHoles_P3[11];
            SwitchHoles[48] = SwitchHoles_P3[12];
            SwitchHoles[49] = SwitchHoles_P3[13];
            SwitchHoles[50] = SwitchHoles_P3[14];
            SwitchHoles[51] = SwitchHoles_P3[15];
            SwitchHoles[52] = SwitchHoles_P3[16];
            SwitchHoles[53] = SwitchHoles_P3[17];
            SwitchHoles[54] = SwitchHoles_P3[18];

            SwitchHoles[55] = SwitchHoles_P4[1];
            SwitchHoles[56] = SwitchHoles_P4[2];
            SwitchHoles[57] = SwitchHoles_P4[3];
            SwitchHoles[58] = SwitchHoles_P4[4];
            SwitchHoles[59] = SwitchHoles_P4[5];
            SwitchHoles[60] = SwitchHoles_P4[6];
            SwitchHoles[61] = SwitchHoles_P4[7];
            SwitchHoles[62] = SwitchHoles_P4[8];
            SwitchHoles[63] = SwitchHoles_P4[9];
            SwitchHoles[64] = SwitchHoles_P4[10];
            SwitchHoles[65] = SwitchHoles_P4[11];
            SwitchHoles[66] = SwitchHoles_P4[12];
            SwitchHoles[67] = SwitchHoles_P4[13];
            SwitchHoles[68] = SwitchHoles_P4[14];
            SwitchHoles[69] = SwitchHoles_P4[15];
            SwitchHoles[70] = SwitchHoles_P4[16];
            SwitchHoles[71] = SwitchHoles_P4[17];
            SwitchHoles[72] = SwitchHoles_P4[18];

            return SwitchHoles;
        }


    }

}
