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
    [RoutePrefix("api/CalcularApuesta")]
    public class CalcularApuestaController : ApiController
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
            public int PlayerID1 { get; set; }
            public int PlayerID2 { get; set; }
            public int AutoPress { get; set; }
        }

        public JObject Post(ParametrosEntrada Datos)
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
                int PlayerID1 = 0;
                int PlayerID2 = 0;
                int AutoPress = 0;

                string ResultFront = "";
                string ResultBack = "";

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

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
                        PlayerID1 = Convert.ToInt32(row["PlayerID1"]);
                        PlayerID2 = Convert.ToInt32(row["PlayerID2"]);
                        AutoPress = Convert.ToInt32(row["AutoPress"]);

                        int Resultado1 = ScoreHole1_P1 - ScoreHole1_P2;
                        int Resultado2 = ScoreHole2_P1 - ScoreHole2_P2;
                        int Resultado3 = ScoreHole3_P1 - ScoreHole3_P2;
                        int Resultado4 = ScoreHole4_P1 - ScoreHole4_P2;
                        int Resultado5 = ScoreHole5_P1 - ScoreHole5_P2;
                        int Resultado6 = ScoreHole6_P1 - ScoreHole6_P2;
                        int Resultado7 = ScoreHole7_P1 - ScoreHole7_P2;
                        int Resultado8 = ScoreHole8_P1 - ScoreHole8_P2;
                        int Resultado9 = ScoreHole9_P1 - ScoreHole9_P2;
                        int Resultado10 = ScoreHole10_P1 - ScoreHole10_P2;
                        int Resultado11 = ScoreHole11_P1 - ScoreHole11_P2;
                        int Resultado12 = ScoreHole12_P1 - ScoreHole12_P2;
                        int Resultado13 = ScoreHole13_P1 - ScoreHole13_P2;
                        int Resultado14 = ScoreHole14_P1 - ScoreHole14_P2;
                        int Resultado15 = ScoreHole15_P1 - ScoreHole15_P2;
                        int Resultado16 = ScoreHole16_P1 - ScoreHole16_P2;
                        int Resultado17 = ScoreHole17_P1 - ScoreHole17_P2;
                        int Resultado18 = ScoreHole18_P1 - ScoreHole18_P2;

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
                            ResultFront = CalcularApuestaPresionFront1(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                              Resultado6, Resultado7, Resultado8, Resultado9);

                            ResultBack = CalcularApuestaPresionBack1(Resultado10, Resultado11, Resultado12, Resultado13,
                              Resultado14, Resultado15, Resultado16, Resultado17, Resultado18);

                            string[] FrontValores = ResultFront.Split(',');
                            string[] BackValores = ResultBack.Split(',');

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

                            ActualizarAPuesta(Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                            BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9);

                        }
                        else if (AutoPress == 2)
                        {
                            ResultFront = CalcularApuestaPresionFront2(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                                Resultado6, Resultado7, Resultado8, Resultado9);

                            ResultBack = CalcularApuestaPresionBack2(Resultado10, Resultado11, Resultado12, Resultado13,
                                Resultado14, Resultado15, Resultado16, Resultado17, Resultado18);

                            string[] FrontValores = ResultFront.Split(',');
                            string[] BackValores = ResultBack.Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                            BetD_F9_4 = Convert.ToString(FrontValores[3]);
                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_B9_3 = Convert.ToString(BackValores[2]);
                            BetD_B9_4 = Convert.ToString(BackValores[3]);

                            ActualizarAPuesta(Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                              BetD_F9_7, BetD_F9_8,BetD_F9_9,BetD_B9_1,BetD_B9_2,BetD_B9_3, BetD_B9_4, BetD_B9_5,BetD_B9_6,BetD_B9_7,BetD_B9_8,BetD_B9_9);

                        }
                        else if (AutoPress == 3)
                        {
                            ResultFront = CalcularApuestaPresionFront3(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                                Resultado6, Resultado7, Resultado8, Resultado9);

                            ResultBack = CalcularApuestaPresionBack3(Resultado10, Resultado11, Resultado12, Resultado13,
                                Resultado14, Resultado15, Resultado16, Resultado17, Resultado18);

                            string[] FrontValores = ResultFront.Split(',');
                            string[] BackValores = ResultBack.Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);
                         
                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_B9_3 = Convert.ToString(BackValores[2]);

                            ActualizarAPuesta(Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                             BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9);
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

        private string CalcularApuestaPresionFront1(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9)
        {

            int[] ResultadoPresionFront = new int[10];

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
                ResultadoPresionFront[2] = 0;
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
                ResultadoPresionFront[3] = 0;
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
                ResultadoPresionFront[4] = 0;
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
                ResultadoPresionFront[5] = 0;
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
                ResultadoPresionFront[6] = 0;
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
                ResultadoPresionFront[7] = 0;
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
                ResultadoPresionFront[8] = 0;
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
                ResultadoPresionFront[9] = 0;
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

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 += 1;
                            ResultadoInt2 = 0;

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

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 = 0;

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

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 = 0;

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

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 = 0;

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


                            break;
                        case 2:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1);

                            break;
                        case 3:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2);

                            break;
                        case 4:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3);

                            break;
                        case 5:


                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4);


                            break;
                        case 6:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5);


                            break;
                        case 7:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6);



                            break;
                        case 8:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7);


                            break;
                        case 9:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8);


                            break;
                        default:



                            break;
                    }


                }

            }


            return ResultadoString;
        }

        private string CalcularApuestaPresionBack1(int Resultado10, int Resultado11, int Resultado12, int Resultado13, int Resultado14, int Resultado15, int Resultado16, int Resultado17, int Resultado18)
        {

            int[] ResultadoPresionFront = new int[10];

            if (Resultado10 == 0)
            {
                ResultadoPresionFront[1] = 0;
            }
            else if (Resultado10 > 0)
            {
                ResultadoPresionFront[1] = 1;
            }
            else if (Resultado10 < 0)
            {
                ResultadoPresionFront[1] = -1;
            }

            if (Resultado11 == 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado11 > 0)
            {
                ResultadoPresionFront[2] = 0;
            }
            else if (Resultado11 < 0)
            {
                ResultadoPresionFront[2] = -1;
            }

            if (Resultado12 == 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado12 > 0)
            {
                ResultadoPresionFront[3] = 0;
            }
            else if (Resultado12 < 0)
            {
                ResultadoPresionFront[3] = -1;
            }

            if (Resultado13 == 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado13 > 0)
            {
                ResultadoPresionFront[4] = 0;
            }
            else if (Resultado13 < 0)
            {
                ResultadoPresionFront[4] = -1;
            }

            if (Resultado14 == 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado14 > 0)
            {
                ResultadoPresionFront[5] = 0;
            }
            else if (Resultado14 < 0)
            {
                ResultadoPresionFront[5] = -1;
            }

            if (Resultado15 == 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado15 > 0)
            {
                ResultadoPresionFront[6] = 0;
            }
            else if (Resultado15 < 0)
            {
                ResultadoPresionFront[6] = -1;
            }

            if (Resultado16 == 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado16 > 0)
            {
                ResultadoPresionFront[7] = 0;
            }
            else if (Resultado16 < 0)
            {
                ResultadoPresionFront[7] = -1;
            }

            if (Resultado17 == 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado17 > 0)
            {
                ResultadoPresionFront[8] = 0;
            }
            else if (Resultado17 < 0)
            {
                ResultadoPresionFront[8] = -1;
            }

            if (Resultado18 == 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado18 > 0)
            {
                ResultadoPresionFront[9] = 0;
            }
            else if (Resultado18 < 0)
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

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 += 1;
                            ResultadoInt2 = 0;

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

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 += 1;
                            ResultadoInt2 += 1;
                            ResultadoInt3 += 1;
                            ResultadoInt4 += 1;
                            ResultadoInt5 += 1;
                            ResultadoInt6 = 0;

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

                            ResultadoInt1 = 0;
                            break;
                        case 2:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 = 0;

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

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + ", 0";

                            break;
                        case 5:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 = 0;

                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + ", 0";


                            break;
                        case 6:

                            ResultadoInt1 -= 1;
                            ResultadoInt2 -= 1;
                            ResultadoInt3 -= 1;
                            ResultadoInt4 -= 1;
                            ResultadoInt5 -= 1;
                            ResultadoInt6 = 0;

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


                            break;
                        case 2:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1);

                            break;
                        case 3:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2);

                            break;
                        case 4:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3);

                            break;
                        case 5:


                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4);


                            break;
                        case 6:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5);


                            break;
                        case 7:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6);



                            break;
                        case 8:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7);


                            break;
                        case 9:



                            ResultadoString = Convert.ToString(ResultadoInt) + "," + Convert.ToString(ResultadoInt1) + "," + Convert.ToString(ResultadoInt2) + "," + Convert.ToString(ResultadoInt3) + "," + Convert.ToString(ResultadoInt4) + "," + Convert.ToString(ResultadoInt5) + "," + Convert.ToString(ResultadoInt6) + "," + Convert.ToString(ResultadoInt7) + "," + Convert.ToString(ResultadoInt8);


                            break;
                        default:



                            break;
                    }


                }

            }


            return ResultadoString;
        }

        private string CalcularApuestaPresionFront2(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9)
        {

            int[] ResultadoPresionFront = new int[10];

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
                ResultadoPresionFront[2] = 0;
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
                ResultadoPresionFront[3] = 0;
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
                ResultadoPresionFront[4] = 0;
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
                ResultadoPresionFront[5] = 0;
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
                ResultadoPresionFront[6] = 0;
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
                ResultadoPresionFront[7] = 0;
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
                ResultadoPresionFront[8] = 0;
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
                ResultadoPresionFront[9] = 0;
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

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (Presion1 == 2)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }

                    }



                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }


                    if (Presion1 == -2)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }
                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                }

            }

            ResultadoString = Convert.ToString(ResultadoInt) + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;

            return ResultadoString;
        }

        private string CalcularApuestaPresionBack2(int Resultado9, int Resultado10, int Resultado12, int Resultado13, int Resultado14, int Resultado15, int Resultado16, int Resultado17, int Resultado18)
        {

            int[] ResultadoPresionBack = new int[10];

            if (Resultado9 == 0)
            {
                ResultadoPresionBack[1] = 0;
            }
            else if (Resultado9 > 0)
            {
                ResultadoPresionBack[1] = 1;
            }
            else if (Resultado9 < 0)
            {
                ResultadoPresionBack[1] = -1;
            }

            if (Resultado10 == 0)
            {
                ResultadoPresionBack[2] = 0;
            }
            else if (Resultado10 > 0)
            {
                ResultadoPresionBack[2] = 0;
            }
            else if (Resultado10 < 0)
            {
                ResultadoPresionBack[2] = -1;
            }

            if (Resultado12 == 0)
            {
                ResultadoPresionBack[3] = 0;
            }
            else if (Resultado12 > 0)
            {
                ResultadoPresionBack[3] = 0;
            }
            else if (Resultado12 < 0)
            {
                ResultadoPresionBack[3] = -1;
            }

            if (Resultado13 == 0)
            {
                ResultadoPresionBack[4] = 0;
            }
            else if (Resultado13 > 0)
            {
                ResultadoPresionBack[4] = 0;
            }
            else if (Resultado13 < 0)
            {
                ResultadoPresionBack[4] = -1;
            }

            if (Resultado14 == 0)
            {
                ResultadoPresionBack[5] = 0;
            }
            else if (Resultado14 > 0)
            {
                ResultadoPresionBack[5] = 0;
            }
            else if (Resultado14 < 0)
            {
                ResultadoPresionBack[5] = -1;
            }

            if (Resultado15 == 0)
            {
                ResultadoPresionBack[6] = 0;
            }
            else if (Resultado15 > 0)
            {
                ResultadoPresionBack[6] = 0;
            }
            else if (Resultado15 < 0)
            {
                ResultadoPresionBack[6] = -1;
            }

            if (Resultado16 == 0)
            {
                ResultadoPresionBack[7] = 0;
            }
            else if (Resultado16 > 0)
            {
                ResultadoPresionBack[7] = 0;
            }
            else if (Resultado16 < 0)
            {
                ResultadoPresionBack[7] = -1;
            }

            if (Resultado17 == 0)
            {
                ResultadoPresionBack[8] = 0;
            }
            else if (Resultado17 > 0)
            {
                ResultadoPresionBack[8] = 0;
            }
            else if (Resultado17 < 0)
            {
                ResultadoPresionBack[8] = -1;
            }

            if (Resultado18 == 0)
            {
                ResultadoPresionBack[9] = 0;
            }
            else if (Resultado18 > 0)
            {
                ResultadoPresionBack[9] = 0;
            }
            else if (Resultado18 < 0)
            {
                ResultadoPresionBack[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionBack[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (Presion1 == 2)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }

                    }



                }
                else if (ResultadoPresionBack[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }


                    if (Presion1 == -2)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }
                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                }

            }

            ResultadoString = Convert.ToString(ResultadoInt) + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;

            return ResultadoString;
        }

        private string CalcularApuestaPresionFront3(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9)
        {

            int[] ResultadoPresionFront = new int[10];

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
                ResultadoPresionFront[2] = 0;
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
                ResultadoPresionFront[3] = 0;
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
                ResultadoPresionFront[4] = 0;
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
                ResultadoPresionFront[5] = 0;
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
                ResultadoPresionFront[6] = 0;
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
                ResultadoPresionFront[7] = 0;
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
                ResultadoPresionFront[8] = 0;
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
                ResultadoPresionFront[9] = 0;
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

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionFront[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (Presion1 == 3)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }

                    }



                }
                else if (ResultadoPresionFront[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }


                    if (Presion1 == -3)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }
                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                }

            }


            ResultadoString = Convert.ToString(ResultadoInt) + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

            return ResultadoString;
        }

        private string CalcularApuestaPresionBack3(int Resultado10, int Resultado11, int Resultado12, int Resultado13, int Resultado14, int Resultado15, int Resultado16, int Resultado17, int Resultado18)
        {

            int[] ResultadoPresionBack = new int[10];

            if (Resultado10 == 0)
            {
                ResultadoPresionBack[1] = 0;
            }
            else if (Resultado10 > 0)
            {
                ResultadoPresionBack[1] = 1;
            }
            else if (Resultado10 < 0)
            {
                ResultadoPresionBack[1] = -1;
            }

            if (Resultado11 == 0)
            {
                ResultadoPresionBack[2] = 0;
            }
            else if (Resultado11 > 0)
            {
                ResultadoPresionBack[2] = 0;
            }
            else if (Resultado11 < 0)
            {
                ResultadoPresionBack[2] = -1;
            }

            if (Resultado12 == 0)
            {
                ResultadoPresionBack[3] = 0;
            }
            else if (Resultado12 > 0)
            {
                ResultadoPresionBack[3] = 0;
            }
            else if (Resultado12 < 0)
            {
                ResultadoPresionBack[3] = -1;
            }

            if (Resultado13 == 0)
            {
                ResultadoPresionBack[4] = 0;
            }
            else if (Resultado13 > 0)
            {
                ResultadoPresionBack[4] = 0;
            }
            else if (Resultado13 < 0)
            {
                ResultadoPresionBack[4] = -1;
            }

            if (Resultado14 == 0)
            {
                ResultadoPresionBack[5] = 0;
            }
            else if (Resultado14 > 0)
            {
                ResultadoPresionBack[5] = 0;
            }
            else if (Resultado14 < 0)
            {
                ResultadoPresionBack[5] = -1;
            }

            if (Resultado15 == 0)
            {
                ResultadoPresionBack[6] = 0;
            }
            else if (Resultado15 > 0)
            {
                ResultadoPresionBack[6] = 0;
            }
            else if (Resultado15 < 0)
            {
                ResultadoPresionBack[6] = -1;
            }

            if (Resultado16 == 0)
            {
                ResultadoPresionBack[7] = 0;
            }
            else if (Resultado16 > 0)
            {
                ResultadoPresionBack[7] = 0;
            }
            else if (Resultado16 < 0)
            {
                ResultadoPresionBack[7] = -1;
            }

            if (Resultado17 == 0)
            {
                ResultadoPresionBack[8] = 0;
            }
            else if (Resultado17 > 0)
            {
                ResultadoPresionBack[8] = 0;
            }
            else if (Resultado17 < 0)
            {
                ResultadoPresionBack[8] = -1;
            }

            if (Resultado18 == 0)
            {
                ResultadoPresionBack[9] = 0;
            }
            else if (Resultado18 > 0)
            {
                ResultadoPresionBack[9] = 0;
            }
            else if (Resultado18 < 0)
            {
                ResultadoPresionBack[9] = -1;
            }

            string ResultadoString = "";
            int ResultadoInt = 0;

            int Presion1 = 0;

            string PresionValor1 = "";
            string PresionValor2 = "";
            string PresionValor3 = "";
            string PresionValor4 = "";

            for (int i = 1; i < 10; i++)
            {

                if (ResultadoPresionBack[i] == 1)
                {

                    ResultadoInt += 1;
                    Presion1 += 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion += 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (Presion1 == 3)
                    {

                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }

                    }



                }
                else if (ResultadoPresionBack[i] == -1)
                {
                    ResultadoInt -= 1;
                    Presion1 -= 1;

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
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor3 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor3);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }

                    if (PresionValor4 != "")
                    {
                        int Presion = Convert.ToInt32(PresionValor4);
                        Presion -= 1;
                        PresionValor1 = Convert.ToString(Presion);
                    }


                    if (Presion1 == -3)
                    {
                        if (PresionValor1 == "")
                        {
                            PresionValor1 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor2 == "")
                        {
                            PresionValor2 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor3 == "")
                        {
                            PresionValor3 = "0";
                            Presion1 = 0;
                        }

                        if (PresionValor4 == "")
                        {
                            PresionValor4 = "0";
                            Presion1 = 0;
                        }
                    }
                }
                else
                {

                    ResultadoInt += 0;
                    Presion1 += 0;

                }

            }


            ResultadoString = Convert.ToString(ResultadoInt) + "," + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;

            return ResultadoString;
        }

        private int ActualizarAPuesta(int IDBet, int IDRonda, int BetD_Player1, int BetD_Player2, string BetD_F9_1, string BetD_F9_2, string BetD_F9_3, string BetD_F9_4, string BetD_F9_5, string BetD_F9_6, string BetD_F9_7, string BetD_F9_8, string BetD_F9_9,
                                      string @BetD_B9_1, string BetD_B9_2, string BetD_B9_3 , string BetD_B9_4 , string BetD_B9_5  , string BetD_B9_6 , string BetD_B9_7 , string BetD_B9_8 , string BetD_B9_9 )
        {
            SqlCommand comando = new SqlCommand("DragoGolf_UpdateDetailBet");
            comando.CommandType = CommandType.StoredProcedure;

            //Declaracion de parametros
            comando.Parameters.Add("@IDBet", SqlDbType.Int);
            comando.Parameters.Add("@IDRonda", SqlDbType.Int);
            comando.Parameters.Add("@BetD_Player1", SqlDbType.Int);
            comando.Parameters.Add("@BetD_Player2", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_1", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_2", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_3", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_4", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_5", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_6", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_7", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_8", SqlDbType.Int);
            comando.Parameters.Add("@BetD_F9_9", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_1", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_2", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_3", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_4", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_5", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_6", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_7", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_8", SqlDbType.Int);
            comando.Parameters.Add("@BetD_B9_9", SqlDbType.Int);

            //Asignacion de valores a parametros
            comando.Parameters["@IDBet"].Value = IDBet;
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
           
            comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
            comando.CommandTimeout = 0;
            comando.Connection.Open();

            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            comando.Connection.Close();
            DA.Fill(DT);

            return 0;
        }

    }
}
