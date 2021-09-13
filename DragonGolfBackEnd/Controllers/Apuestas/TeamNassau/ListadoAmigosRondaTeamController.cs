using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

using DragonGolfBackEnd.Clases;

using Newtonsoft.Json.Linq;

namespace DragonGolfBackEnd.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/ListadoAmigosRondaTeam")]
    public class ListadoAmigosRondaTeamController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDBetDetail { get; set; }

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
            public string usu_telefono { get; set; }
            public string usu_email { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public string usu_nickname { get; set; }
            public string usu_ghinnumber { get; set; }
            public decimal usu_golpesventaja { get; set; }
            public decimal usu_diferenciatee { get; set; }
            public int handicapAuto { get; set; }
            public string Te_TeeColor { get; set; }
            public int ho_par1 { get; set; }
            public int ho_par2 { get; set; }
            public int ho_par3 { get; set; }
            public int ho_par4 { get; set; }
            public int ho_par5 { get; set; }
            public int ho_par6 { get; set; }
            public int ho_par7 { get; set; }
            public int ho_par8 { get; set; }
            public int ho_par9 { get; set; }
            public int ho_par10 { get; set; }
            public int ho_par11 { get; set; }
            public int ho_par12 { get; set; }
            public int ho_par13 { get; set; }
            public int ho_par14 { get; set; }
            public int ho_par15 { get; set; }
            public int ho_par16 { get; set; }
            public int ho_par17 { get; set; }
            public int ho_par18 { get; set; }
            public int Ho_Advantage1 { get; set; }
            public int Ho_Advantage2 { get; set; }
            public int Ho_Advantage3 { get; set; }
            public int Ho_Advantage4 { get; set; }
            public int Ho_Advantage5 { get; set; }
            public int Ho_Advantage6 { get; set; }
            public int Ho_Advantage7 { get; set; }
            public int Ho_Advantage8 { get; set; }
            public int Ho_Advantage9 { get; set; }
            public int Ho_Advantage10 { get; set; }
            public int Ho_Advantage11 { get; set; }
            public int Ho_Advantage12 { get; set; }
            public int Ho_Advantage13 { get; set; }
            public int Ho_Advantage14 { get; set; }
            public int Ho_Advantage15 { get; set; }
            public int Ho_Advantage16 { get; set; }
            public int Ho_Advantage17 { get; set; }
            public int Ho_Advantage18 { get; set; }
            public double GolpesVentaja1 { get; set; }
            public double GolpesVentaja2 { get; set; }
            public double GolpesVentaja3 { get; set; }
            public double GolpesVentaja4 { get; set; }
            public double GolpesVentaja5 { get; set; }
            public double GolpesVentaja6 { get; set; }
            public double GolpesVentaja7 { get; set; }
            public double GolpesVentaja8 { get; set; }
            public double GolpesVentaja9 { get; set; }
            public double GolpesVentaja10 { get; set; }
            public double GolpesVentaja11 { get; set; }
            public double GolpesVentaja12 { get; set; }
            public double GolpesVentaja13 { get; set; }
            public double GolpesVentaja14 { get; set; }
            public double GolpesVentaja15 { get; set; }
            public double GolpesVentaja16 { get; set; }
            public double GolpesVentaja17 { get; set; }
            public double GolpesVentaja18 { get; set; }
            public decimal usu_handicapindex { get; set; }
            public int ValidaUsuarioCreo { get; set; }
            public int IDUsuarioCreo { get; set; }
            public int ScoreIn { get; set; }
            public int ScoreOut { get; set; }
            public double ScoreInGP { get; set; }
            public double ScoreOutGP { get; set; }
            public double TotalScore { get; set; }
            public double TotalScoreGP { get; set; }
            public string Hoyo1Presion { get; set; }
            public string Hoyo2Presion { get; set; }
            public string Hoyo3Presion { get; set; }
            public string Hoyo4Presion { get; set; }
            public string Hoyo5Presion { get; set; }
            public string Hoyo6Presion { get; set; }
            public string Hoyo7Presion { get; set; }
            public string Hoyo8Presion { get; set; }
            public string Hoyo9Presion { get; set; }
            public string Hoyo10Presion { get; set; }
            public string Hoyo11Presion { get; set; }
            public string Hoyo12Presion { get; set; }
            public string Hoyo13Presion { get; set; }
            public string Hoyo14Presion { get; set; }
            public string Hoyo15Presion { get; set; }
            public string Hoyo16Presion { get; set; }
            public string Hoyo17Presion { get; set; }
            public string Hoyo18Presion { get; set; }
            public double GolpesVentaja1_tee { get; set; }
            public double GolpesVentaja2_tee { get; set; }
            public double GolpesVentaja3_tee { get; set; }
            public double GolpesVentaja4_tee { get; set; }
            public double GolpesVentaja5_tee { get; set; }
            public double GolpesVentaja6_tee { get; set; }
            public double GolpesVentaja7_tee { get; set; }
            public double GolpesVentaja8_tee { get; set; }
            public double GolpesVentaja9_tee { get; set; }
            public double GolpesVentaja10_tee { get; set; }
            public double GolpesVentaja11_tee { get; set; }
            public double GolpesVentaja12_tee { get; set; }
            public double GolpesVentaja13_tee { get; set; }
            public double GolpesVentaja14_tee { get; set; }
            public double GolpesVentaja15_tee { get; set; }
            public double GolpesVentaja16_tee { get; set; }
            public double GolpesVentaja17_tee { get; set; }
            public double GolpesVentaja18_tee { get; set; }
            public int ventaja { get; set; }
            public double SumaGolpesVentaja { get; set; }
            public int initHole { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListFriendRound_Team");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDBet_Detail", SqlDbType.Int);

                comando.Parameters["@IDBet_Detail"].Value = Datos.IDBetDetail;

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

                    int DificultatHoyo1_tee = 0;
                    int DificultatHoyo2_tee = 0;
                    int DificultatHoyo3_tee = 0;
                    int DificultatHoyo4_tee = 0;
                    int DificultatHoyo5_tee = 0;
                    int DificultatHoyo6_tee = 0;
                    int DificultatHoyo7_tee = 0;
                    int DificultatHoyo8_tee = 0;
                    int DificultatHoyo9_tee = 0;
                    int DificultatHoyo10_tee = 0;
                    int DificultatHoyo11_tee = 0;
                    int DificultatHoyo12_tee = 0;
                    int DificultatHoyo13_tee = 0;
                    int DificultatHoyo14_tee = 0;
                    int DificultatHoyo15_tee = 0;
                    int DificultatHoyo16_tee = 0;
                    int DificultatHoyo17_tee = 0;
                    int DificultatHoyo18_tee = 0;

                    double GolpesVentaja1 = 0;
                    double GolpesVentaja2 = 0;
                    double GolpesVentaja3 = 0;
                    double GolpesVentaja4 = 0;
                    double GolpesVentaja5 = 0;
                    double GolpesVentaja6 = 0;
                    double GolpesVentaja7 = 0;
                    double GolpesVentaja8 = 0;
                    double GolpesVentaja9 = 0;
                    double GolpesVentaja10 = 0;
                    double GolpesVentaja11 = 0;
                    double GolpesVentaja12 = 0;
                    double GolpesVentaja13 = 0;
                    double GolpesVentaja14 = 0;
                    double GolpesVentaja15 = 0;
                    double GolpesVentaja16 = 0;
                    double GolpesVentaja17 = 0;
                    double GolpesVentaja18 = 0;

                    //double GolpesVentaja1_1 = 0;
                    //double GolpesVentaja2_1 = 0;
                    //double GolpesVentaja3_1 = 0;
                    //double GolpesVentaja4_1 = 0;
                    //double GolpesVentaja5_1 = 0;
                    //double GolpesVentaja6_1 = 0;
                    //double GolpesVentaja7_1 = 0;
                    //double GolpesVentaja8_1 = 0;
                    //double GolpesVentaja9_1 = 0;
                    //double GolpesVentaja10_1 = 0;
                    //double GolpesVentaja11_1 = 0;
                    //double GolpesVentaja12_1 = 0;
                    //double GolpesVentaja13_1 = 0;
                    //double GolpesVentaja14_1 = 0;
                    //double GolpesVentaja15_1 = 0;
                    //double GolpesVentaja16_1 = 0;
                    //double GolpesVentaja17_1 = 0;
                    //double GolpesVentaja18_1 = 0;
                    double HoyoInicial = 0;

                    decimal Adv1 = 0;
                    double Adv_tee = 0;

                    double HandicapP1 = 0;
                    double HandicapP2 = 0;
                    double HandicapP3 = 0;
                    double HandicapP4 = 0;

                    string TipoGolpesVentaja = "";
                    string Player = "";
                    bool Bet_CambioVentaja;

                    int Ro_Cambio = 0;

                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {
                            Bet_CambioVentaja = Convert.ToBoolean(row["Bet_CambioVentaja"]);
                            Player = Convert.ToString(row["Player"]);
                            HoyoInicial = Convert.ToInt32(row["HoyoInicial"]);

                            Ro_Cambio = Convert.ToInt32(row["Ro_Cambio"]);

                            string numeroFormato = Convert.ToInt32(row["usu_ghinnumber"]).ToString("D7");

                            int PlayerId = Convert.ToInt32(row["PlayerId"]);

                            DificultatHoyo1 = Convert.ToInt32(row["Ho_Advantage1"]);//7
                            DificultatHoyo2 = Convert.ToInt32(row["Ho_Advantage2"]);//1
                            DificultatHoyo3 = Convert.ToInt32(row["Ho_Advantage3"]);//8
                            DificultatHoyo4 = Convert.ToInt32(row["Ho_Advantage4"]);//5
                            DificultatHoyo5 = Convert.ToInt32(row["Ho_Advantage5"]);//2
                            DificultatHoyo6 = Convert.ToInt32(row["Ho_Advantage6"]);//6
                            DificultatHoyo7 = Convert.ToInt32(row["Ho_Advantage7"]);//4
                            DificultatHoyo8 = Convert.ToInt32(row["Ho_Advantage8"]);//3
                            DificultatHoyo9 = Convert.ToInt32(row["Ho_Advantage9"]);//9
                            DificultatHoyo10 = Convert.ToInt32(row["Ho_Advantage10"]);//10
                            DificultatHoyo11 = Convert.ToInt32(row["Ho_Advantage11"]);//11
                            DificultatHoyo12 = Convert.ToInt32(row["Ho_Advantage12"]);//14
                            DificultatHoyo13 = Convert.ToInt32(row["Ho_Advantage13"]);//15
                            DificultatHoyo14 = Convert.ToInt32(row["Ho_Advantage14"]);//13
                            DificultatHoyo15 = Convert.ToInt32(row["Ho_Advantage15"]);//16
                            DificultatHoyo16 = Convert.ToInt32(row["Ho_Advantage16"]);//17
                            DificultatHoyo17 = Convert.ToInt32(row["Ho_Advantage17"]);//18
                            DificultatHoyo18 = Convert.ToInt32(row["Ho_Advantage18"]);//12

                            TipoGolpesVentaja = Convert.ToString(row["TipoGolpesVentaja"]);

                            HandicapP1 = Convert.ToDouble(row["HandicapP1"]);
                            HandicapP2 = Convert.ToDouble(row["HandicapP2"]);
                            HandicapP3 = Convert.ToDouble(row["HandicapP3"]);
                            HandicapP4 = Convert.ToDouble(row["HandicapP4"]);

                                DificultatHoyo1_tee = Convert.ToInt32(row["DificutadHoyo1"]);//7
                                DificultatHoyo2_tee = Convert.ToInt32(row["DificutadHoyo2"]);//1
                                DificultatHoyo3_tee = Convert.ToInt32(row["DificutadHoyo3"]);//8
                                DificultatHoyo4_tee = Convert.ToInt32(row["DificutadHoyo4"]);//5
                                DificultatHoyo5_tee = Convert.ToInt32(row["DificutadHoyo5"]);//2
                                DificultatHoyo6_tee = Convert.ToInt32(row["DificutadHoyo6"]);//6
                                DificultatHoyo7_tee = Convert.ToInt32(row["DificutadHoyo7"]);//4
                                DificultatHoyo8_tee = Convert.ToInt32(row["DificutadHoyo8"]);//3
                                DificultatHoyo9_tee = Convert.ToInt32(row["DificutadHoyo9"]);//9
                                DificultatHoyo10_tee = Convert.ToInt32(row["DificutadHoyo10"]);//10
                                DificultatHoyo11_tee = Convert.ToInt32(row["DificutadHoyo11"]);//11
                                DificultatHoyo12_tee = Convert.ToInt32(row["DificutadHoyo12"]);//14
                                DificultatHoyo13_tee = Convert.ToInt32(row["DificutadHoyo13"]);//15
                                DificultatHoyo14_tee = Convert.ToInt32(row["DificutadHoyo14"]);//13
                                DificultatHoyo15_tee = Convert.ToInt32(row["DificutadHoyo15"]);//16
                                DificultatHoyo16_tee = Convert.ToInt32(row["DificutadHoyo16"]);//17
                                DificultatHoyo17_tee = Convert.ToInt32(row["DificutadHoyo17"]);//18
                                DificultatHoyo18_tee = Convert.ToInt32(row["DificutadHoyo18"]);//12

                            if (Ro_Cambio == 1)
                            {

                                DificultatHoyo1_tee = DificultatHoyo1_tee + 1;
                                DificultatHoyo2_tee = DificultatHoyo2_tee + 1;
                                DificultatHoyo3_tee = DificultatHoyo3_tee + 1;
                                DificultatHoyo4_tee = DificultatHoyo4_tee + 1;
                                DificultatHoyo5_tee = DificultatHoyo5_tee + 1;
                                DificultatHoyo6_tee = DificultatHoyo6_tee + 1;
                                DificultatHoyo7_tee = DificultatHoyo7_tee + 1;
                                DificultatHoyo8_tee = DificultatHoyo8_tee + 1;
                                DificultatHoyo9_tee = DificultatHoyo9_tee + 1;
                                DificultatHoyo10_tee = DificultatHoyo10_tee - 1;
                                DificultatHoyo11_tee = DificultatHoyo11_tee - 1;
                                DificultatHoyo12_tee = DificultatHoyo12_tee - 1;
                                DificultatHoyo13_tee = DificultatHoyo13_tee - 1;
                                DificultatHoyo14_tee = DificultatHoyo14_tee - 1;
                                DificultatHoyo15_tee = DificultatHoyo15_tee - 1;
                                DificultatHoyo16_tee = DificultatHoyo16_tee - 1;
                                DificultatHoyo17_tee = DificultatHoyo17_tee - 1; 
                                DificultatHoyo18_tee = DificultatHoyo18_tee - 1;
                            }
                         

                            GolpesVentaja1 = 0;
                            GolpesVentaja2 = 0;
                            GolpesVentaja3 = 0;
                            GolpesVentaja4 = 0;
                            GolpesVentaja5 = 0;
                            GolpesVentaja6 = 0;
                            GolpesVentaja7 = 0;
                            GolpesVentaja8 = 0;
                            GolpesVentaja9 = 0;
                            GolpesVentaja10 = 0;
                            GolpesVentaja11 = 0;
                            GolpesVentaja12 = 0;
                            GolpesVentaja13 = 0;
                            GolpesVentaja14 = 0;
                            GolpesVentaja15 = 0;
                            GolpesVentaja16 = 0;
                            GolpesVentaja17 = 0;
                            GolpesVentaja18 = 0;

                            //GolpesVentaja1_1 = 0;
                            //GolpesVentaja2_1 = 0;
                            //GolpesVentaja3_1 = 0;
                            //GolpesVentaja4_1 = 0;
                            //GolpesVentaja5_1 = 0;
                            //GolpesVentaja6_1 = 0;
                            //GolpesVentaja7_1 = 0;
                            //GolpesVentaja8_1 = 0;
                            //GolpesVentaja9_1 = 0;
                            //GolpesVentaja10_1 = 0;
                            //GolpesVentaja11_1 = 0;
                            //GolpesVentaja12_1 = 0;
                            //GolpesVentaja13_1 = 0;
                            //GolpesVentaja14_1 = 0;
                            //GolpesVentaja15_1 = 0;
                            //GolpesVentaja16_1 = 0;
                            //GolpesVentaja17_1 = 0;
                            //GolpesVentaja18_1 = 0;


                            double GolpesVentaja1_tee = 0;
                            double GolpesVentaja2_tee = 0;
                            double GolpesVentaja3_tee = 0;
                            double GolpesVentaja4_tee = 0;
                            double GolpesVentaja5_tee = 0;
                            double GolpesVentaja6_tee = 0;
                            double GolpesVentaja7_tee = 0;
                            double GolpesVentaja8_tee = 0;
                            double GolpesVentaja9_tee = 0;
                            double GolpesVentaja10_tee = 0;
                            double GolpesVentaja11_tee = 0;
                            double GolpesVentaja12_tee = 0;
                            double GolpesVentaja13_tee = 0;
                            double GolpesVentaja14_tee = 0;
                            double GolpesVentaja15_tee = 0;
                            double GolpesVentaja16_tee = 0;
                            double GolpesVentaja17_tee = 0;
                            double GolpesVentaja18_tee = 0;

                            double ScoreHole1 = Convert.ToDouble(row["ScoreHole1"]);
                            double ScoreHole2 = Convert.ToDouble(row["ScoreHole2"]);
                            double ScoreHole3 = Convert.ToDouble(row["ScoreHole3"]);
                            double ScoreHole4 = Convert.ToDouble(row["ScoreHole4"]);
                            double ScoreHole5 = Convert.ToDouble(row["ScoreHole5"]);
                            double ScoreHole6 = Convert.ToDouble(row["ScoreHole6"]);
                            double ScoreHole7 = Convert.ToDouble(row["ScoreHole7"]);
                            double ScoreHole8 = Convert.ToDouble(row["ScoreHole8"]);
                            double ScoreHole9 = Convert.ToDouble(row["ScoreHole9"]);
                            double ScoreHole10 = Convert.ToDouble(row["ScoreHole10"]);
                            double ScoreHole11 = Convert.ToDouble(row["ScoreHole11"]);
                            double ScoreHole12 = Convert.ToDouble(row["ScoreHole12"]);
                            double ScoreHole13 = Convert.ToDouble(row["ScoreHole13"]);
                            double ScoreHole14 = Convert.ToDouble(row["ScoreHole14"]);
                            double ScoreHole15 = Convert.ToDouble(row["ScoreHole15"]);
                            double ScoreHole16 = Convert.ToDouble(row["ScoreHole16"]);
                            double ScoreHole17 = Convert.ToDouble(row["ScoreHole17"]);
                            double ScoreHole18 = Convert.ToDouble(row["ScoreHole18"]);
                            Adv_tee = Convert.ToDouble(row["adv"]);

                            int ventaja = 0;// Convert.ToInt32(row["Ventaja"]); ;
                            double SumaGolpesVentaja = 0;

                            //  double AdvInverso = (-1) * (Adv_tee);

                            int AdvInverso = (-1) * (Convert.ToInt32(Adv_tee));
                            int AdvInverso2 = 0; //(-1) * (Adv);

                            if (Adv_tee > 0)
                            {
                                AdvInverso2 = Convert.ToInt32(Math.Ceiling(Adv_tee));
                                AdvInverso = (-1) * Convert.ToInt32(Math.Ceiling(Adv_tee));
                            }
                            else if (Adv_tee < 0)
                            {
                                AdvInverso2 = Convert.ToInt32(Math.Floor(Adv_tee));
                                AdvInverso = (-1) * Convert.ToInt32(Math.Floor(Adv_tee));
                            }



                            //Each
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
                            ////

                            int Contadorcito = 0;
                            double ValCompleto = 0;
                            //Cuando es negativo es ventaja para el player 1
                            if (AdvInverso < 0)
                            {
                                // double AdvPositivo = (-1) * (AdvInverso);

                                int AdvPositivo = (AdvInverso2);

                                if (Adv_tee >= AdvInverso2)
                                {
                                    ValCompleto = 0.5;
                                }

                                double CicloFor = 18;

                                if (AdvPositivo > 18)
                                {
                                    CicloFor = AdvPositivo;
                                }

                                for (int i = 0; i < CicloFor; i++)
                                {
                                    Contadorcito += 1;

                                    if (Contadorcito > 18)
                                    {
                                        Contadorcito = 1;
                                        AdvPositivo = AdvPositivo - 18;
                                    }

                                    if (Contadorcito <= AdvPositivo)
                                    {

                                        if (DificultatHoyo1_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole1 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Adecuacion Cambio Ventaja
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Adecuacion Cambio Ventaja
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo2_tee == Contadorcito)
                                        {
                                            // if (ScoreHole2 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Adecuacion Cambio Ventaja
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo3_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole3 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {
                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }


                                                        }
                                                    }

                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo4_tee == Contadorcito)
                                        {

                                            //  if (ScoreHole4 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }


                                                        }
                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }


                                                        }
                                                    }

                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2")
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo5_tee == Contadorcito)
                                        {
                                            //    if (ScoreHole5 > 0)
                                            //    {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }


                                                        }
                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //    }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo6_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole6 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo7_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole7 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo8_tee == Contadorcito)
                                        {
                                            //if (ScoreHole8 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo9_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole9 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Adecuacion Cambio Ventaja
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }


                                                        }


                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2")
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo10_tee == Contadorcito)
                                        {
                                            //if (ScoreHole10 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo11_tee == Contadorcito)
                                        {
                                            //    if (ScoreHole11 > 0)
                                            //    {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //    }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo12_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole12 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo13_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole13 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo14_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole14 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo15_tee == Contadorcito)
                                        {
                                            //   if (ScoreHole15 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo16_tee == Contadorcito)
                                        {
                                            //   if (ScoreHole16 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //   }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo17_tee == Contadorcito)
                                        {
                                            //    if (ScoreHole17 > 0)
                                            //    {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo18_tee == Contadorcito)
                                        {
                                            //   if (ScoreHole18 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 > HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 1")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP1 < HandicapP3 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 3")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 1")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }


                                                        }

                                                    }

                                                }


                                            }
                                            //   }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
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

                                double AdvPositivo = (-1) * (Adv_tee);
                                int AdvPositivo2 = (-1) * (AdvInverso2);

                                if (AdvPositivo >= AdvPositivo2)
                                {
                                    ValCompleto = 0.5;
                                    AdvPositivo = Convert.ToInt32(Math.Ceiling(AdvPositivo));
                                }
                                else
                                {
                                    AdvPositivo = Convert.ToInt32(Math.Ceiling(AdvPositivo));
                                }


                                double CicloFor = 18;

                                if (AdvInverso > 18)
                                {
                                    CicloFor = AdvInverso;
                                }

                                for (int i = 0; i < CicloFor; i++)
                                {
                                    Contadorcito += 1;

                                    if (Contadorcito > 18)
                                    {
                                        Contadorcito = 1;
                                        AdvInverso = AdvInverso - 18;
                                    }

                                    if (Contadorcito <= AdvInverso)
                                    {

                                        if (DificultatHoyo1_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole1 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }
                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo2_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole2 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }


                                            }
                                            //   }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja2_tee = GolpesVentaja2_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo3_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole3 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {
                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {

                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }


                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                    if (Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja3_tee = GolpesVentaja3_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo4_tee == Contadorcito)
                                        {
                                            //   if (ScoreHole4 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {

                                                    if (Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }

                                                }


                                            }
                                            //    }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja4_tee = GolpesVentaja4_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo5_tee == Contadorcito)
                                        {
                                            //   if (ScoreHole5 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }



                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }


                                            }
                                            //   }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja5_tee = GolpesVentaja5_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo6_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole6 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja6_tee = GolpesVentaja6_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo7_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole7 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }
                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }

                                                }


                                            }
                                            //   }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja7_tee = GolpesVentaja7_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo8_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole8 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {

                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                            {
                                                                if (Player == "Jugador 4")
                                                                {
                                                                    if (Contadorcito == AdvPositivo)
                                                                    {
                                                                        GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                    }
                                                                    else
                                                                    {
                                                                        GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                    }
                                                                }

                                                            }
                                                            else
                                                            {
                                                                if (Player == "Jugador 2")
                                                                {
                                                                    if (Contadorcito == AdvPositivo)
                                                                    {
                                                                        GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                                    }
                                                                    else
                                                                    {
                                                                        GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                                    }
                                                                }

                                                            }

                                                        }
                                                    }

                                                }


                                            }
                                            //   }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja8_tee = GolpesVentaja8_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo9_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole9 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {

                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja9_tee = GolpesVentaja9_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo10_tee == Contadorcito)
                                        {
                                            // if (ScoreHole10 > 0)
                                            // {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }


                                            }
                                            // }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja10_tee = GolpesVentaja10_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo11_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole11 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }

                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja11_tee = GolpesVentaja11_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo12_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole12 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }

                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja12_tee = GolpesVentaja12_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo13_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole13 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }
                                                }


                                            }
                                            //  }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1")
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja13_tee = GolpesVentaja13_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo14_tee == Contadorcito)
                                        {
                                            //   if (ScoreHole14 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }
                                                }


                                            }

                                            //   }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja1_tee = GolpesVentaja1_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja14_tee = GolpesVentaja14_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo15_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole15 > 0)
                                            //   {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                                }
                                                            }

                                                        }
                                                    }
                                                }


                                            }

                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja15_tee = GolpesVentaja15_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo16_tee == Contadorcito)
                                        {
                                            // if (ScoreHole16 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja16_tee = GolpesVentaja16_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }


                                        }

                                        if (DificultatHoyo17_tee == Contadorcito)
                                        {
                                            //  if (ScoreHole17 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }


                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja17_tee = GolpesVentaja17_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                            }

                                        }

                                        if (DificultatHoyo18_tee == Contadorcito)
                                        {
                                            // if (ScoreHole18 > 0)
                                            //  {
                                            if (TipoGolpesVentaja == "Hi Handicap")
                                            {

                                                if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 > HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }
                                                        }
                                                    }

                                                }

                                            }

                                            if (TipoGolpesVentaja == "Low Handicap")
                                            {

                                                if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == false)
                                                {
                                                    if (Player == "Jugador 2")
                                                    {

                                                        if (Contadorcito == AdvPositivo)
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                        }
                                                        else
                                                        {
                                                            GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (HandicapP2 < HandicapP4 && Bet_CambioVentaja == true)
                                                        {
                                                            if (Player == "Jugador 4")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Player == "Jugador 2")
                                                            {
                                                                if (Contadorcito == AdvPositivo)
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                                }
                                                                else
                                                                {
                                                                    GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                                }
                                                            }

                                                        }

                                                    }
                                                }

                                            }
                                            //  }
                                            if (TipoGolpesVentaja == "Each")
                                            {
                                                if (JugadorMejoresEquipo1Valor >= JugadorMejoresEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    //Se le da la ventaja al peor de ese equipo
                                                    if (JugadorMejoresEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //Validafinalizacion
                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorMejoresEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }

                                                    }

                                                }

                                                if (JugadorPeorEquipo1Valor >= JugadorPeorEquipo2Valor && Bet_CambioVentaja == false)
                                                {
                                                    if (JugadorPeorEquipo2 == "Jugador 2" && Bet_CambioVentaja == false)
                                                    {

                                                        if (Player == "Jugador 2")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 4")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //JugadorMejoresEquipo2
                                                    if (JugadorPeorEquipo1 == "Jugador 1" && Bet_CambioVentaja == false)
                                                    {
                                                        if (Player == "Jugador 1")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }


                                                    }
                                                    else
                                                    {
                                                        if (Player == "Jugador 3")
                                                        {
                                                            if (Contadorcito == AdvPositivo)
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - (0.5 + ValCompleto);
                                                            }
                                                            else
                                                            {
                                                                GolpesVentaja18_tee = GolpesVentaja18_tee - 1;
                                                            }
                                                        }
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


                            GolpesVentaja1 = GolpesVentaja1_tee;
                            GolpesVentaja2 = GolpesVentaja2_tee;
                            GolpesVentaja3 = GolpesVentaja3_tee;
                            GolpesVentaja4 = GolpesVentaja4_tee;
                            GolpesVentaja5 = GolpesVentaja5_tee;
                            GolpesVentaja6 = GolpesVentaja6_tee;
                            GolpesVentaja7 = GolpesVentaja7_tee;
                            GolpesVentaja8 = GolpesVentaja8_tee;
                            GolpesVentaja9 = GolpesVentaja9_tee;
                            GolpesVentaja10 = GolpesVentaja10_tee;
                            GolpesVentaja11 = GolpesVentaja11_tee;
                            GolpesVentaja12 = GolpesVentaja12_tee;
                            GolpesVentaja13 = GolpesVentaja13_tee;
                            GolpesVentaja14 = GolpesVentaja14_tee;
                            GolpesVentaja15 = GolpesVentaja15_tee;
                            GolpesVentaja16 = GolpesVentaja16_tee;
                            GolpesVentaja17 = GolpesVentaja17_tee;
                            GolpesVentaja18 = GolpesVentaja18_tee;


                            double TotalGolpesVentajaFront = 0;
                            double TotalGolpesVentajaBack = 0;

                            TotalGolpesVentajaFront = GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9;
                            TotalGolpesVentajaBack = GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18;

                            if (((-1 * TotalGolpesVentajaFront) + (-1 * TotalGolpesVentajaBack)) > 0)
                            {
                                TotalGolpesVentajaFront = 0;
                                TotalGolpesVentajaBack = 0;

                                ventaja = PlayerId;

                                switch (HoyoInicial)
                                {
                                    case 1:
                                        TotalGolpesVentajaFront = GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9;
                                        break;
                                    case 2:
                                        TotalGolpesVentajaFront = GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10;
                                        break;
                                    case 3:
                                        TotalGolpesVentajaFront = GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11;
                                        break;
                                    case 4:
                                        TotalGolpesVentajaFront = GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12;
                                        break;
                                    case 5:
                                        TotalGolpesVentajaFront = GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13;
                                        break;
                                    case 6:
                                        TotalGolpesVentajaFront = GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14;
                                        break;
                                    case 7:
                                        TotalGolpesVentajaFront = GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15;
                                        break;
                                    case 8:
                                        TotalGolpesVentajaFront = GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16;
                                        break;
                                    case 9:
                                        TotalGolpesVentajaFront = GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17;
                                        break;
                                    case 10:
                                        TotalGolpesVentajaFront = GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18;
                                        break;
                                    case 11:
                                        TotalGolpesVentajaFront = GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1;
                                        break;
                                    case 12:
                                        TotalGolpesVentajaFront = GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2;
                                        break;
                                    case 13:
                                        TotalGolpesVentajaFront = GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3;
                                        break;
                                    case 14:
                                        TotalGolpesVentajaFront = GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4;
                                        break;
                                    case 15:
                                        TotalGolpesVentajaFront = GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5;
                                        break;
                                    case 16:
                                        TotalGolpesVentajaFront = GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6;
                                        break;
                                    case 17:
                                        TotalGolpesVentajaFront = GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7;
                                        break;
                                    case 18:
                                        TotalGolpesVentajaFront = GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8;
                                        break;
                                    default:
                                        break;
                                }

                                switch (HoyoInicial)
                                {
                                    case 1:
                                        TotalGolpesVentajaBack = GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18;
                                        break;
                                    case 2:
                                        TotalGolpesVentajaBack = GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1;
                                        break;
                                    case 3:
                                        TotalGolpesVentajaBack = GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2;
                                        break;
                                    case 4:
                                        TotalGolpesVentajaBack = GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3;
                                        break;
                                    case 5:
                                        TotalGolpesVentajaBack = GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4;
                                        break;
                                    case 6:
                                        TotalGolpesVentajaBack = GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5;
                                        break;
                                    case 7:
                                        TotalGolpesVentajaBack = GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6;
                                        break;
                                    case 8:
                                        TotalGolpesVentajaBack = GolpesVentaja17 + GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7;
                                        break;
                                    case 9:
                                        TotalGolpesVentajaBack = GolpesVentaja18 + GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8;
                                        break;
                                    case 10:
                                        TotalGolpesVentajaBack = GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9;
                                        break;
                                    case 11:
                                        TotalGolpesVentajaBack = GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10;
                                        break;
                                    case 12:
                                        TotalGolpesVentajaBack = GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11;
                                        break;
                                    case 13:
                                        TotalGolpesVentajaBack = GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12;
                                        break;
                                    case 14:
                                        TotalGolpesVentajaBack = GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13;
                                        break;
                                    case 15:
                                        TotalGolpesVentajaBack = GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14;
                                        break;
                                    case 16:
                                        TotalGolpesVentajaBack = GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15;
                                        break;
                                    case 17:
                                        TotalGolpesVentajaBack = GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16;
                                        break;
                                    case 18:
                                        TotalGolpesVentajaBack = GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            SumaGolpesVentaja = (-1 * TotalGolpesVentajaFront) + (-1 * TotalGolpesVentajaBack);

                            ParametrosSalida ent = new ParametrosSalida
                            {

                                IDRounds = Convert.ToInt32(row["IDRounds"]),
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                PlayerId = Convert.ToInt32(row["PlayerId"]),
                                RoundHandicap = Convert.ToDecimal(row["RoundHandicap"]),
                                PlayerTee = Convert.ToString(row["PlayerTee"]),
                                usu_telefono = Convert.ToString(row["usu_telefono"]),
                                usu_email = Convert.ToString(row["usu_email"]),
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
                                ho_par1 = Convert.ToInt32(row["ho_par1"]),
                                ho_par2 = Convert.ToInt32(row["ho_par2"]),
                                ho_par3 = Convert.ToInt32(row["ho_par3"]),
                                ho_par4 = Convert.ToInt32(row["ho_par4"]),
                                ho_par5 = Convert.ToInt32(row["ho_par5"]),
                                ho_par6 = Convert.ToInt32(row["ho_par6"]),
                                ho_par7 = Convert.ToInt32(row["ho_par7"]),
                                ho_par8 = Convert.ToInt32(row["ho_par8"]),
                                ho_par9 = Convert.ToInt32(row["ho_par9"]),
                                ho_par10 = Convert.ToInt32(row["ho_par10"]),
                                ho_par11 = Convert.ToInt32(row["ho_par11"]),
                                ho_par12 = Convert.ToInt32(row["ho_par12"]),
                                ho_par13 = Convert.ToInt32(row["ho_par13"]),
                                ho_par14 = Convert.ToInt32(row["ho_par14"]),
                                ho_par15 = Convert.ToInt32(row["ho_par15"]),
                                ho_par16 = Convert.ToInt32(row["ho_par16"]),
                                ho_par17 = Convert.ToInt32(row["ho_par17"]),
                                ho_par18 = Convert.ToInt32(row["ho_par18"]),
                                Ho_Advantage1 = Convert.ToInt32(row["Ho_Advantage1"]),
                                Ho_Advantage2 = Convert.ToInt32(row["Ho_Advantage2"]),
                                Ho_Advantage3 = Convert.ToInt32(row["Ho_Advantage3"]),
                                Ho_Advantage4 = Convert.ToInt32(row["Ho_Advantage4"]),
                                Ho_Advantage5 = Convert.ToInt32(row["Ho_Advantage5"]),
                                Ho_Advantage6 = Convert.ToInt32(row["Ho_Advantage6"]),
                                Ho_Advantage7 = Convert.ToInt32(row["Ho_Advantage7"]),
                                Ho_Advantage8 = Convert.ToInt32(row["Ho_Advantage8"]),
                                Ho_Advantage9 = Convert.ToInt32(row["Ho_Advantage9"]),
                                Ho_Advantage10 = Convert.ToInt32(row["Ho_Advantage10"]),
                                Ho_Advantage11 = Convert.ToInt32(row["Ho_Advantage11"]),
                                Ho_Advantage12 = Convert.ToInt32(row["Ho_Advantage12"]),
                                Ho_Advantage13 = Convert.ToInt32(row["Ho_Advantage13"]),
                                Ho_Advantage14 = Convert.ToInt32(row["Ho_Advantage14"]),
                                Ho_Advantage15 = Convert.ToInt32(row["Ho_Advantage15"]),
                                Ho_Advantage16 = Convert.ToInt32(row["Ho_Advantage16"]),
                                Ho_Advantage17 = Convert.ToInt32(row["Ho_Advantage17"]),
                                Ho_Advantage18 = Convert.ToInt32(row["Ho_Advantage18"]),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_ghinnumber = numeroFormato,
                                usu_golpesventaja = Convert.ToDecimal(row["usu_golpesventaja"]),
                                usu_diferenciatee = Convert.ToDecimal(row["usu_diferenciatee"]),
                                handicapAuto = Convert.ToInt32(row["handicapAuto"]),
                                Te_TeeColor = Convert.ToString(row["Te_TeeColor"]),
                                usu_handicapindex = Convert.ToDecimal(row["usu_handicapindex"]),
                                ValidaUsuarioCreo = Convert.ToInt32(row["ValidaUsuarioCreo"]),
                                IDUsuarioCreo = Convert.ToInt32(row["IDUsuarioCreo"]),
                                ScoreIn = Convert.ToInt32(row["ScoreIn"]),
                                ScoreOut = Convert.ToInt32(row["ScoreOut"]),
                                ScoreInGP = Convert.ToDouble(row["ScoreIn"]) - (-1 * TotalGolpesVentajaFront),
                                ScoreOutGP = Convert.ToDouble(row["ScoreOut"]) - (-1 * TotalGolpesVentajaBack),
                                TotalScoreGP = Convert.ToDouble(row["TotalScore"]) - (-1 * TotalGolpesVentajaFront) - (-1 * TotalGolpesVentajaBack),
                                TotalScore = Convert.ToDouble(row["TotalScore"]),
                                GolpesVentaja1 = GolpesVentaja1_tee,
                                GolpesVentaja2 = GolpesVentaja2_tee,
                                GolpesVentaja3 = GolpesVentaja3_tee,
                                GolpesVentaja4 = GolpesVentaja4_tee,
                                GolpesVentaja5 = GolpesVentaja5_tee,
                                GolpesVentaja6 = GolpesVentaja6_tee,
                                GolpesVentaja7 = GolpesVentaja7_tee,
                                GolpesVentaja8 = GolpesVentaja8_tee,
                                GolpesVentaja9 = GolpesVentaja9_tee,
                                GolpesVentaja10 = GolpesVentaja10_tee,
                                GolpesVentaja11 = GolpesVentaja11_tee,
                                GolpesVentaja12 = GolpesVentaja12_tee,
                                GolpesVentaja13 = GolpesVentaja13_tee,
                                GolpesVentaja14 = GolpesVentaja14_tee,
                                GolpesVentaja15 = GolpesVentaja15_tee,
                                GolpesVentaja16 = GolpesVentaja16_tee,
                                GolpesVentaja17 = GolpesVentaja17_tee,
                                GolpesVentaja18 = GolpesVentaja18_tee,
                                ventaja = ventaja,
                                GolpesVentaja1_tee = (-1 * GolpesVentaja1_tee),
                                GolpesVentaja2_tee = (-1 * GolpesVentaja2_tee),
                                GolpesVentaja3_tee = (-1 * GolpesVentaja3_tee),
                                GolpesVentaja4_tee = (-1 * GolpesVentaja4_tee),
                                GolpesVentaja5_tee = (-1 * GolpesVentaja5_tee),
                                GolpesVentaja6_tee = (-1 * GolpesVentaja6_tee),
                                GolpesVentaja7_tee = (-1 * GolpesVentaja7_tee),
                                GolpesVentaja8_tee = (-1 * GolpesVentaja8_tee),
                                GolpesVentaja9_tee = (-1 * GolpesVentaja9_tee),
                                GolpesVentaja10_tee = (-1 * GolpesVentaja10_tee),
                                GolpesVentaja11_tee = (-1 * GolpesVentaja11_tee),
                                GolpesVentaja12_tee = (-1 * GolpesVentaja12_tee),
                                GolpesVentaja13_tee = (-1 * GolpesVentaja13_tee),
                                GolpesVentaja14_tee = (-1 * GolpesVentaja14_tee),
                                GolpesVentaja15_tee = (-1 * GolpesVentaja15_tee),
                                GolpesVentaja16_tee = (-1 * GolpesVentaja16_tee),
                                GolpesVentaja17_tee = (-1 * GolpesVentaja17_tee),
                                GolpesVentaja18_tee = (-1 * GolpesVentaja18_tee),

                                Hoyo1Presion = Convert.ToString(row["Hoyo1Presion"]),
                                Hoyo2Presion = Convert.ToString(row["Hoyo2Presion"]),
                                Hoyo3Presion = Convert.ToString(row["Hoyo3Presion"]),
                                Hoyo4Presion = Convert.ToString(row["Hoyo4Presion"]),
                                Hoyo5Presion = Convert.ToString(row["Hoyo5Presion"]),
                                Hoyo6Presion = Convert.ToString(row["Hoyo6Presion"]),
                                Hoyo7Presion = Convert.ToString(row["Hoyo7Presion"]),
                                Hoyo8Presion = Convert.ToString(row["Hoyo8Presion"]),
                                Hoyo9Presion = Convert.ToString(row["Hoyo9Presion"]),
                                Hoyo10Presion = Convert.ToString(row["Hoyo10Presion"]),
                                Hoyo11Presion = Convert.ToString(row["Hoyo11Presion"]),
                                Hoyo12Presion = Convert.ToString(row["Hoyo12Presion"]),
                                Hoyo13Presion = Convert.ToString(row["Hoyo13Presion"]),
                                Hoyo14Presion = Convert.ToString(row["Hoyo14Presion"]),
                                Hoyo15Presion = Convert.ToString(row["Hoyo15Presion"]),
                                Hoyo16Presion = Convert.ToString(row["Hoyo16Presion"]),
                                Hoyo17Presion = Convert.ToString(row["Hoyo17Presion"]),
                                Hoyo18Presion = Convert.ToString(row["Hoyo18Presion"]),
                                SumaGolpesVentaja = SumaGolpesVentaja,
                                initHole = Convert.ToInt32(row["initHole"]),

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
