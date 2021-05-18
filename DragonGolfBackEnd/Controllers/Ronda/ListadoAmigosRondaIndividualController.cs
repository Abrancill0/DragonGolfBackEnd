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
    [RoutePrefix("api/ListadoAmigosRondaIndividual")]
    public class ListadoAmigosRondaIndividualController : ApiController
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
            public int GolpesVentaja1 { get; set; }
            public int GolpesVentaja2 { get; set; }
            public int GolpesVentaja3 { get; set; }
            public int GolpesVentaja4 { get; set; }
            public int GolpesVentaja5 { get; set; }
            public int GolpesVentaja6 { get; set; }
            public int GolpesVentaja7 { get; set; }
            public int GolpesVentaja8 { get; set; }
            public int GolpesVentaja9 { get; set; }
            public int GolpesVentaja10 { get; set; }
            public int GolpesVentaja11 { get; set; }
            public int GolpesVentaja12 { get; set; }
            public int GolpesVentaja13 { get; set; }
            public int GolpesVentaja14 { get; set; }
            public int GolpesVentaja15 { get; set; }
            public int GolpesVentaja16 { get; set; }
            public int GolpesVentaja17 { get; set; }
            public int GolpesVentaja18 { get; set; }
            public decimal usu_handicapindex { get; set; }
            public int ValidaUsuarioCreo { get; set; }
            public int IDUsuarioCreo { get; set; }
            public int ScoreIn { get; set; }
            public int ScoreOut { get; set; }
            public int ScoreInGP { get; set; }
            public int ScoreOutGP { get; set; }
            public int TotalScore { get; set; }
            public int TotalScoreGP { get; set; }
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
            public int SumaGolpesVentaja { get; set; }
            public int initHole { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListFriendRound_Individual");
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

                    int GolpesVentaja1 = 0;
                    int GolpesVentaja2 = 0;
                    int GolpesVentaja3 = 0;
                    int GolpesVentaja4 = 0;
                    int GolpesVentaja5 = 0;
                    int GolpesVentaja6 = 0;
                    int GolpesVentaja7 = 0;
                    int GolpesVentaja8 = 0;
                    int GolpesVentaja9 = 0;
                    int GolpesVentaja10 = 0;
                    int GolpesVentaja11 = 0;
                    int GolpesVentaja12 = 0;
                    int GolpesVentaja13 = 0;
                    int GolpesVentaja14 = 0;
                    int GolpesVentaja15 = 0;
                    int GolpesVentaja16 = 0;
                    int GolpesVentaja17 = 0;
                    int GolpesVentaja18 = 0;

                    int GolpesVentaja1_1 = 0;
                    int GolpesVentaja2_1 = 0;
                    int GolpesVentaja3_1 = 0;
                    int GolpesVentaja4_1 = 0;
                    int GolpesVentaja5_1 = 0;
                    int GolpesVentaja6_1 = 0;
                    int GolpesVentaja7_1 = 0;
                    int GolpesVentaja8_1 = 0;
                    int GolpesVentaja9_1 = 0;
                    int GolpesVentaja10_1 = 0;
                    int GolpesVentaja11_1 = 0;
                    int GolpesVentaja12_1 = 0;
                    int GolpesVentaja13_1 = 0;
                    int GolpesVentaja14_1 = 0;
                    int GolpesVentaja15_1 = 0;
                    int GolpesVentaja16_1 = 0;
                    int GolpesVentaja17_1 = 0;
                    int GolpesVentaja18_1 = 0;
                    int HoyoInicial = 0;

                    decimal Adv1 = 0;
                    int Adv_tee = 0;


                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {

                            string numeroFormato = Convert.ToInt32(row["usu_ghinnumber"]).ToString("D7");

                            int PlayerId = Convert.ToInt32(row["PlayerId"]);
                            HoyoInicial = Convert.ToInt32(row["HoyoInicial"]);

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

                            GolpesVentaja1_1 = 0;
                            GolpesVentaja2_1 = 0;
                            GolpesVentaja3_1 = 0;
                            GolpesVentaja4_1 = 0;
                            GolpesVentaja5_1 = 0;
                            GolpesVentaja6_1 = 0;
                            GolpesVentaja7_1 = 0;
                            GolpesVentaja8_1 = 0;
                            GolpesVentaja9_1 = 0;
                            GolpesVentaja10_1 = 0;
                            GolpesVentaja11_1 = 0;
                            GolpesVentaja12_1 = 0;
                            GolpesVentaja13_1 = 0;
                            GolpesVentaja14_1 = 0;
                            GolpesVentaja15_1 = 0;
                            GolpesVentaja16_1 = 0;
                            GolpesVentaja17_1 = 0;
                            GolpesVentaja18_1 = 0;


                            int ScoreHole1 = Convert.ToInt32(row["ScoreHole1"]);
                            int ScoreHole2 = Convert.ToInt32(row["ScoreHole2"]);
                            int ScoreHole3 = Convert.ToInt32(row["ScoreHole3"]);
                            int ScoreHole4 = Convert.ToInt32(row["ScoreHole4"]);
                            int ScoreHole5 = Convert.ToInt32(row["ScoreHole5"]);
                            int ScoreHole6 = Convert.ToInt32(row["ScoreHole6"]);
                            int ScoreHole7 = Convert.ToInt32(row["ScoreHole7"]);
                            int ScoreHole8 = Convert.ToInt32(row["ScoreHole8"]);
                            int ScoreHole9 = Convert.ToInt32(row["ScoreHole9"]);
                            int ScoreHole10 = Convert.ToInt32(row["ScoreHole10"]);
                            int ScoreHole11 = Convert.ToInt32(row["ScoreHole11"]);
                            int ScoreHole12 = Convert.ToInt32(row["ScoreHole12"]);
                            int ScoreHole13 = Convert.ToInt32(row["ScoreHole13"]);
                            int ScoreHole14 = Convert.ToInt32(row["ScoreHole14"]);
                            int ScoreHole15 = Convert.ToInt32(row["ScoreHole15"]);
                            int ScoreHole16 = Convert.ToInt32(row["ScoreHole16"]);
                            int ScoreHole17 = Convert.ToInt32(row["ScoreHole17"]);
                            int ScoreHole18 = Convert.ToInt32(row["ScoreHole18"]);
                            Adv_tee = Convert.ToInt32(row["adv"]);

                           
                            int SumaGolpesVentaja = 0;


                         
                                //Convert.ToDecimal(row["usu_golpesventaja"]),

                            int Contador = 0;

                            int Adv = Convert.ToInt32(Decimal.Round(Adv1));

                            if (Adv < 0)
                            {
                                int AdvPositivo = (-1) * (Adv);

                                int CicloFor = 18;

                                if (AdvPositivo > 18)
                                {
                                    CicloFor = AdvPositivo;
                                }

                                for (int i = 0; i < CicloFor; i++)
                                {
                                    Contador += 1;

                                    if (Contador > 18)
                                    {
                                        Contador = 1;
                                    }

                                    if (Contador <= AdvPositivo)
                                    {

                                        if (DificultatHoyo1 == Contador)
                                        {
                                            if (ScoreHole1 > 0)
                                            {
                                                GolpesVentaja1 = GolpesVentaja1 + 1;
                                            }

                                            GolpesVentaja1_1 = GolpesVentaja1_1 + 1;
                                        }

                                        if (DificultatHoyo2 == Contador)
                                        {
                                            if (ScoreHole2 > 0)
                                            {
                                                GolpesVentaja2 = GolpesVentaja2 + 1;
                                            }

                                            GolpesVentaja2_1 = GolpesVentaja2_1 + 1;

                                        }

                                        if (DificultatHoyo3 == Contador)
                                        {
                                            if (ScoreHole3 > 0)
                                            {
                                                GolpesVentaja3 = GolpesVentaja3 + 1;
                                            }

                                            GolpesVentaja3_1 = GolpesVentaja3_1 + 1;

                                        }

                                        if (DificultatHoyo4 == Contador)
                                        {

                                            if (ScoreHole4 > 0)
                                            {
                                                GolpesVentaja4 = GolpesVentaja4 + 1;
                                            }

                                            GolpesVentaja4_1 = GolpesVentaja4_1 + 1;
                                        }

                                        if (DificultatHoyo5 == Contador)
                                        {
                                            if (ScoreHole5 > 0)
                                            {
                                                GolpesVentaja5 = GolpesVentaja5 + 1;
                                            }

                                            GolpesVentaja5_1 = GolpesVentaja5_1 + 1;
                                        }

                                        if (DificultatHoyo6 == Contador)
                                        {
                                            if (ScoreHole6 > 0)
                                            {
                                                GolpesVentaja6 = GolpesVentaja6 + 1;
                                            }
                                            GolpesVentaja6_1 = GolpesVentaja6_1 + 1;
                                        }

                                        if (DificultatHoyo7 == Contador)
                                        {
                                            if (ScoreHole7 > 0)
                                            {
                                                GolpesVentaja7 = GolpesVentaja7 + 1;
                                            }
                                            GolpesVentaja7_1 = GolpesVentaja7_1 + 1;
                                        }

                                        if (DificultatHoyo8 == Contador)
                                        {
                                            if (ScoreHole8 > 0)
                                            {
                                                GolpesVentaja8 = GolpesVentaja8 + 1;
                                            }
                                            GolpesVentaja8_1 = GolpesVentaja8_1 + 1;
                                        }

                                        if (DificultatHoyo9 == Contador)
                                        {
                                            if (ScoreHole9 > 0)
                                            {
                                                GolpesVentaja9 = GolpesVentaja9 + 1;
                                            }
                                            GolpesVentaja9_1 = GolpesVentaja9_1 + 1;
                                        }

                                        if (DificultatHoyo10 == Contador)
                                        {
                                            if (ScoreHole10 > 0)
                                            {
                                                GolpesVentaja10 = GolpesVentaja10 + 1;
                                            }
                                            GolpesVentaja10_1 = GolpesVentaja10_1 + 1;
                                        }

                                        if (DificultatHoyo11 == Contador)
                                        {
                                            if (ScoreHole11 > 0)
                                            {
                                                GolpesVentaja11 = GolpesVentaja11 + 1;
                                            }
                                            GolpesVentaja11_1 = GolpesVentaja11_1 + 1;
                                        }

                                        if (DificultatHoyo12 == Contador)
                                        {
                                            if (ScoreHole12 > 0)
                                            {
                                                GolpesVentaja12 = GolpesVentaja12 + 1;
                                            }
                                            GolpesVentaja12_1 = GolpesVentaja12_1 + 1;
                                        }

                                        if (DificultatHoyo13 == Contador)
                                        {
                                            if (ScoreHole13 > 0)
                                            {
                                                GolpesVentaja13 = GolpesVentaja13 + 1;
                                            }
                                            GolpesVentaja13_1 = GolpesVentaja13_1 + 1;
                                        }

                                        if (DificultatHoyo14 == Contador)
                                        {
                                            if (ScoreHole14 > 0)
                                            {
                                                GolpesVentaja14 = GolpesVentaja14 + 1;
                                            }
                                            GolpesVentaja14_1 = GolpesVentaja14_1 + 1;
                                        }

                                        if (DificultatHoyo15 == Contador)
                                        {
                                            if (ScoreHole15 > 0)
                                            {
                                                GolpesVentaja15 = GolpesVentaja15 + 1;
                                            }
                                            GolpesVentaja15_1 = GolpesVentaja15_1 + 1;
                                        }

                                        if (DificultatHoyo16 == Contador)
                                        {
                                            if (ScoreHole16 > 0)
                                            {
                                                GolpesVentaja16 = GolpesVentaja16 + 1;
                                            }
                                            GolpesVentaja16_1 = GolpesVentaja16_1 + 1;
                                        }

                                        if (DificultatHoyo17 == Contador)
                                        {
                                            if (ScoreHole17 > 0)
                                            {
                                                GolpesVentaja17 = GolpesVentaja17 + 1;
                                            }
                                            GolpesVentaja17_1 = GolpesVentaja17_1 + 1;
                                        }

                                        if (DificultatHoyo18 == Contador)
                                        {
                                            if (ScoreHole18 > 0)
                                            {
                                                GolpesVentaja18 = GolpesVentaja18 + 1;
                                            }

                                            GolpesVentaja18_1 = GolpesVentaja18_1 + 1;
                                        }

                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                            }
                            else if (Adv > 0)
                            {
                                int CicloFor = 18;

                                if (Adv > 18)
                                {
                                    CicloFor = Adv;
                                }

                                for (int i = 0; i < CicloFor; i++)
                                {
                                    Contador += 1;

                                    if (Contador > 18)
                                    {
                                        Contador = 1;
                                    }

                                    if (Contador <= Adv)
                                    {

                                        if (DificultatHoyo1 == Contador)
                                        {

                                            if (ScoreHole1 > 0)
                                            {
                                                GolpesVentaja1 = GolpesVentaja1 + 1;
                                            }
                                            GolpesVentaja1_1 = GolpesVentaja1_1 + 1;

                                        }

                                        if (DificultatHoyo2 == Contador)
                                        {
                                            if (ScoreHole2 > 0)
                                            {
                                                GolpesVentaja2 = GolpesVentaja2 + 1;
                                            }
                                            GolpesVentaja2_1 = GolpesVentaja2_1 + 1;
                                        }

                                        if (DificultatHoyo3 == Contador)
                                        {
                                            if (ScoreHole3 > 0)
                                            {
                                                GolpesVentaja3 = GolpesVentaja3 + 1;
                                            }
                                            GolpesVentaja3_1 = GolpesVentaja3_1 + 1;
                                        }

                                        if (DificultatHoyo4 == Contador)
                                        {
                                            if (ScoreHole4 > 0)
                                            {
                                                GolpesVentaja4 = GolpesVentaja4 + 1;
                                            }
                                            GolpesVentaja4_1 = GolpesVentaja4_1 + 1;
                                        }

                                        if (DificultatHoyo5 == Contador)
                                        {
                                            if (ScoreHole5 > 0)
                                            {
                                                GolpesVentaja5 = GolpesVentaja5 + 1;
                                            }
                                            GolpesVentaja5_1 = GolpesVentaja5_1 + 1;
                                        }

                                        if (DificultatHoyo6 == Contador)
                                        {
                                            if (ScoreHole6 > 0)
                                            {
                                                GolpesVentaja6 = GolpesVentaja6 + 1;
                                            }
                                            GolpesVentaja6_1 = GolpesVentaja6_1 + 1;
                                        }

                                        if (DificultatHoyo7 == Contador)
                                        {
                                            if (ScoreHole7 > 0)
                                            {
                                                GolpesVentaja7 = GolpesVentaja7 + 1;
                                            }
                                            GolpesVentaja7_1 = GolpesVentaja7_1 + 1;
                                        }

                                        if (DificultatHoyo8 == Contador)
                                        {
                                            if (ScoreHole8 > 0)
                                            {
                                                GolpesVentaja8 = GolpesVentaja8 + 1;
                                            }
                                            GolpesVentaja8_1 = GolpesVentaja8_1 + 1;

                                        }

                                        if (DificultatHoyo9 == Contador)
                                        {
                                            if (ScoreHole9 > 0)
                                            {
                                                GolpesVentaja9 = GolpesVentaja9 + 1;
                                            }

                                            GolpesVentaja9_1 = GolpesVentaja9_1 + 1;
                                        }

                                        if (DificultatHoyo10 == Contador)
                                        {
                                            if (ScoreHole10 > 0)
                                            {
                                                GolpesVentaja10 = GolpesVentaja10 + 1;
                                            }
                                            GolpesVentaja10_1 = GolpesVentaja10_1 + 1;
                                        }

                                        if (DificultatHoyo11 == Contador)
                                        {
                                            if (ScoreHole11 > 0)
                                            {
                                                GolpesVentaja11 = GolpesVentaja11 + 1;
                                            }
                                            GolpesVentaja11_1 = GolpesVentaja11_1 + 1;
                                        }

                                        if (DificultatHoyo12 == Contador)
                                        {
                                            if (ScoreHole12 > 0)
                                            {
                                                GolpesVentaja12 = GolpesVentaja12 + 1;
                                            }

                                            GolpesVentaja12_1 = GolpesVentaja12_1 + 1;
                                        }

                                        if (DificultatHoyo13 == Contador)
                                        {
                                            if (ScoreHole13 > 0)
                                            {
                                                GolpesVentaja13 = GolpesVentaja13 + 1;
                                            }

                                            GolpesVentaja13_1 = GolpesVentaja13_1 + 1;
                                        }

                                        if (DificultatHoyo14 == Contador)
                                        {
                                            if (ScoreHole14 > 0)
                                            {
                                                GolpesVentaja14 = GolpesVentaja14 + 1;
                                            }

                                            GolpesVentaja14_1 = GolpesVentaja14_1 + 1;
                                        }

                                        if (DificultatHoyo15 == Contador)
                                        {
                                            if (ScoreHole15 > 0)
                                            {
                                                GolpesVentaja15 = GolpesVentaja15 + 1;
                                            }

                                            GolpesVentaja15_1 = GolpesVentaja15_1 + 1;
                                        }

                                        if (DificultatHoyo16 == Contador)
                                        {
                                            if (ScoreHole16 > 0)
                                            {
                                                GolpesVentaja16 = GolpesVentaja16 + 1;
                                            }

                                            GolpesVentaja16_1 = GolpesVentaja16_1 + 1;
                                        }

                                        if (DificultatHoyo17 == Contador)
                                        {
                                            if (ScoreHole17 > 0)
                                            {
                                                GolpesVentaja17 = GolpesVentaja17 + 1;
                                            }

                                            GolpesVentaja17_1 = GolpesVentaja17_1 + 1;
                                        }

                                        if (DificultatHoyo18 == Contador)
                                        {
                                            if (ScoreHole18 > 0)
                                            {
                                                GolpesVentaja18 = GolpesVentaja18 + 1;
                                            }

                                            GolpesVentaja18_1 = GolpesVentaja18_1 + 1;
                                        }


                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                            }

                            int TotalGolpesVentajaFront = 0;
                            int TotalGolpesVentajaBack = 0;

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
                                    TotalGolpesVentajaFront = GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14+ GolpesVentaja15;
                                    break;
                                case 8:
                                    TotalGolpesVentajaFront = GolpesVentaja8 + GolpesVentaja9 + GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15+GolpesVentaja16;
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
                                ScoreInGP = Convert.ToInt32(row["ScoreIn"]) - TotalGolpesVentajaFront,
                                ScoreOutGP = Convert.ToInt32(row["ScoreOut"]) - TotalGolpesVentajaBack,
                                TotalScoreGP = Convert.ToInt32(row["TotalScore"]) - TotalGolpesVentajaFront - TotalGolpesVentajaBack,
                                TotalScore = Convert.ToInt32(row["TotalScore"]),
                                GolpesVentaja1 = GolpesVentaja1_1,
                                GolpesVentaja2 = GolpesVentaja2_1,
                                GolpesVentaja3 = GolpesVentaja3_1,
                                GolpesVentaja4 = GolpesVentaja4_1,
                                GolpesVentaja5 = GolpesVentaja5_1,
                                GolpesVentaja6 = GolpesVentaja6_1,
                                GolpesVentaja7 = GolpesVentaja7_1,
                                GolpesVentaja8 = GolpesVentaja8_1,
                                GolpesVentaja9 = GolpesVentaja9_1,
                                GolpesVentaja10 = GolpesVentaja10_1,
                                GolpesVentaja11 = GolpesVentaja11_1,
                                GolpesVentaja12 = GolpesVentaja12_1,
                                GolpesVentaja13 = GolpesVentaja13_1,
                                GolpesVentaja14 = GolpesVentaja14_1,
                                GolpesVentaja15 = GolpesVentaja15_1,
                                GolpesVentaja16 = GolpesVentaja16_1,
                                GolpesVentaja17 = GolpesVentaja17_1,
                                GolpesVentaja18 = GolpesVentaja18_1,


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
