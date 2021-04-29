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
                int Adv = 0;

                string[] ResultFront = new string[9];
                string[] ResultBack = new string[9];

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        bool InicioPartida1 = Convert.ToBoolean(row["InicioPartida1"]);
                        bool InicioPartida2 = Convert.ToBoolean(row["InicioPartida2"]);


                        if (InicioPartida1 == false && InicioPartida2 == false)
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
                        PlayerID1 = Convert.ToInt32(row["PlayerID1"]);
                        PlayerID2 = Convert.ToInt32(row["PlayerID2"]);
                        AutoPress = Convert.ToInt32(row["AutoPress"]);
                        Adv = Convert.ToInt32(row["Adv"]);


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

                        int Contador = 0;

                        int AdvInverso = (-1) * (Adv);

                        if (AdvInverso < 0)
                        {
                            int AdvPositivo = (-1) * (AdvInverso);

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
                                        if (ScoreHole1_P1 > 0 && ScoreHole1_P2 > 0)
                                        {
                                            ScoreHole1_P1 = ScoreHole1_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo2 == Contador)
                                    {
                                        if (ScoreHole2_P1 > 0 && ScoreHole2_P2 > 0)
                                        {
                                            ScoreHole2_P1 = ScoreHole2_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo3 == Contador)
                                    {
                                        if (ScoreHole3_P1 > 0 && ScoreHole3_P2 > 0)
                                        {
                                            ScoreHole3_P1 = ScoreHole3_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo4 == Contador)
                                    {
                                        if (ScoreHole4_P1 > 0 && ScoreHole4_P2 > 0)
                                        {
                                            ScoreHole4_P1 = ScoreHole4_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo5 == Contador)
                                    {
                                        if (ScoreHole5_P1 > 0 && ScoreHole5_P2 > 0)
                                        {
                                            ScoreHole5_P1 = ScoreHole5_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo6 == Contador)
                                    {
                                        if (ScoreHole6_P1 > 0 && ScoreHole6_P2 > 0)
                                        {
                                            ScoreHole6_P1 = ScoreHole6_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo7 == Contador)
                                    {
                                        if (ScoreHole7_P1 > 0 && ScoreHole7_P2 > 0)
                                        {
                                            ScoreHole7_P1 = ScoreHole7_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo8 == Contador)
                                    {
                                        if (ScoreHole8_P1 > 0 && ScoreHole8_P2 > 0)
                                        {
                                            ScoreHole8_P1 = ScoreHole8_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo9 == Contador)
                                    {
                                        if (ScoreHole9_P1 > 0 && ScoreHole9_P2 > 0)
                                        {
                                            ScoreHole9_P1 = ScoreHole9_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo10 == Contador)
                                    {
                                        if (ScoreHole10_P1 > 0 && ScoreHole10_P2 > 0)
                                        {
                                            ScoreHole10_P1 = ScoreHole10_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo11 == Contador)
                                    {
                                        if (ScoreHole11_P1 > 0 && ScoreHole11_P2 > 0)
                                        {
                                            ScoreHole11_P1 = ScoreHole11_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo12 == Contador)
                                    {
                                        if (ScoreHole12_P1 > 0 && ScoreHole12_P2 > 0)
                                        {
                                            ScoreHole12_P1 = ScoreHole12_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo13 == Contador)
                                    {
                                        if (ScoreHole13_P1 > 0 && ScoreHole13_P2 > 0)
                                        {
                                            ScoreHole13_P1 = ScoreHole13_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo14 == Contador)
                                    {
                                        if (ScoreHole14_P1 > 0 && ScoreHole14_P2 > 0)
                                        {
                                            ScoreHole14_P1 = ScoreHole14_P1 - 1;
                                        }

                                    }

                                    if (DificultatHoyo15 == Contador)
                                    {
                                        if (ScoreHole15_P1 > 0 && ScoreHole15_P2 > 0)
                                        {
                                            ScoreHole15_P1 = ScoreHole15_P1 - 1;
                                        }
                                    }

                                    if (DificultatHoyo16 == Contador)
                                    {
                                        if (ScoreHole16_P1 > 0 && ScoreHole16_P2 > 0)
                                        {
                                            ScoreHole16_P1 = ScoreHole16_P1 - 1;
                                        }
                                    }

                                    if (DificultatHoyo17 == Contador)
                                    {
                                        if (ScoreHole17_P1 > 0 && ScoreHole17_P2 > 0)
                                        {
                                            ScoreHole17_P1 = ScoreHole17_P1 - 1;
                                        }
                                    }

                                    if (DificultatHoyo18 == Contador)
                                    {
                                        if (ScoreHole18_P1 > 0 && ScoreHole18_P2 > 0)
                                        {
                                            ScoreHole18_P1 = ScoreHole18_P1 - 1;
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
                                }

                                if (Contador <= AdvInverso)
                                {

                                    if (DificultatHoyo1 == Contador)
                                    {

                                        if (ScoreHole1_P2 > 0 && ScoreHole1_P1 > 0)
                                        {
                                            ScoreHole1_P2 = ScoreHole1_P2 - 1;
                                        }


                                    }

                                    if (DificultatHoyo2 == Contador)
                                    {
                                        if (ScoreHole2_P2 > 0 && ScoreHole2_P1 > 0)
                                        {
                                            ScoreHole2_P2 = ScoreHole2_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo3 == Contador)
                                    {
                                        if (ScoreHole3_P2 > 0 && ScoreHole3_P1 > 0)
                                        {
                                            ScoreHole3_P2 = ScoreHole3_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo4 == Contador)
                                    {
                                        if (ScoreHole4_P2 > 0 && ScoreHole4_P1 > 0)
                                        {
                                            ScoreHole4_P2 = ScoreHole4_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo5 == Contador)
                                    {
                                        if (ScoreHole5_P2 > 0 && ScoreHole5_P1 > 0)
                                        {
                                            ScoreHole5_P2 = ScoreHole5_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo6 == Contador)
                                    {
                                        if (ScoreHole6_P2 > 0 && ScoreHole6_P1 > 0)
                                        {
                                            ScoreHole6_P2 = ScoreHole6_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo7 == Contador)
                                    {
                                        if (ScoreHole7_P2 > 0 && ScoreHole7_P1 > 0)
                                        {
                                            ScoreHole7_P2 = ScoreHole7_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo8 == Contador)
                                    {
                                        if (ScoreHole8_P2 > 0 && ScoreHole8_P1 > 0)
                                        {
                                            ScoreHole8_P2 = ScoreHole8_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo9 == Contador)
                                    {
                                        if (ScoreHole9_P2 > 0 && ScoreHole9_P1 > 0)
                                        {
                                            ScoreHole9_P2 = ScoreHole9_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo10 == Contador)
                                    {
                                        if (ScoreHole10_P2 > 0 && ScoreHole10_P1 > 0)
                                        {
                                            ScoreHole10_P2 = ScoreHole10_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo11 == Contador)
                                    {
                                        if (ScoreHole11_P2 > 0 && ScoreHole11_P1 > 0)
                                        {
                                            ScoreHole11_P2 = ScoreHole11_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo12 == Contador)
                                    {
                                        if (ScoreHole12_P2 > 0 && ScoreHole12_P1 > 0)
                                        {
                                            ScoreHole12_P2 = ScoreHole12_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo13 == Contador)
                                    {
                                        if (ScoreHole13_P2 > 0 && ScoreHole13_P1 > 0)
                                        {
                                            ScoreHole13_P2 = ScoreHole13_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo14 == Contador)
                                    {
                                        if (ScoreHole14_P2 > 0 && ScoreHole14_P1 > 0)
                                        {
                                            ScoreHole14_P2 = ScoreHole14_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo15 == Contador)
                                    {
                                        if (ScoreHole15_P2 > 0 && ScoreHole15_P1 > 0)
                                        {
                                            ScoreHole15_P2 = ScoreHole15_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo16 == Contador)
                                    {
                                        if (ScoreHole16_P2 > 0 && ScoreHole16_P1 > 0)
                                        {
                                            ScoreHole16_P2 = ScoreHole16_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo17 == Contador)
                                    {
                                        if (ScoreHole17_P2 > 0 && ScoreHole17_P1 > 0)
                                        {
                                            ScoreHole17_P2 = ScoreHole17_P2 - 1;
                                        }

                                    }

                                    if (DificultatHoyo18 == Contador)
                                    {
                                        if (ScoreHole18_P2 > 0 && ScoreHole18_P1 > 0)
                                        {
                                            ScoreHole18_P2 = ScoreHole18_P2 - 1;
                                        }

                                    }


                                }
                                else
                                {
                                    break;
                                }

                            }

                        }


                        int Resultado1 = 0;
                        int Resultado2 = 0;
                        int Resultado3 = 0;
                        int Resultado4 = 0;
                        int Resultado5 = 0;
                        int Resultado6 = 0;
                        int Resultado7 = 0;
                        int Resultado8 = 0;
                        int Resultado9 = 0;

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
                            if (ValidaFront==0)
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
                        int ResultadoTotaF1 = ScoreHole1_P1 + ScoreHole2_P1 + ScoreHole3_P1 + ScoreHole4_P1 + ScoreHole5_P1 + ScoreHole6_P1 + ScoreHole7_P1 + ScoreHole8_P1 + ScoreHole9_P1;
                        int ResultadoTotaF2 = ScoreHole1_P2 + ScoreHole2_P2 + ScoreHole3_P2 + ScoreHole4_P2 + ScoreHole5_P2 + ScoreHole6_P2 + ScoreHole7_P2 + ScoreHole8_P2 + ScoreHole9_P2;

                        bool ValidaJuegoInicio = false;

                        if ((ResultadoTotaF1 + ResultadoTotaF2) > 0)
                        {
                            ValidaJuegoInicio = false;
                        }
                        else
                        {
                            ValidaJuegoInicio = true;
                        }


                        int Resultado10 = 0;
                        int Resultado11 = 0;
                        int Resultado12 = 0;
                        int Resultado13 = 0;
                        int Resultado14 = 0;
                        int Resultado15 = 0;
                        int Resultado16 = 0;
                        int Resultado17 = 0;
                        int Resultado18 = 0;


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
                        int ResultadoTotaB1 = ScoreHole10_P1 + ScoreHole11_P1 + ScoreHole12_P1 + ScoreHole13_P1 + ScoreHole14_P1 + ScoreHole15_P1 + ScoreHole16_P1 + ScoreHole17_P1 + ScoreHole18_P1;
                        int ResultadoTotaB2 = ScoreHole10_P2 + ScoreHole11_P2 + ScoreHole12_P2 + ScoreHole13_P2 + ScoreHole14_P2 + ScoreHole15_P2 + ScoreHole16_P2 + ScoreHole17_P2 + ScoreHole18_P2;

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


                        if (AutoPress == 1)
                        {
                            ResultFront = CalcularApuestaPresionFront1(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                              Resultado6, Resultado7, Resultado8, Resultado9, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack1(Resultado10, Resultado11, Resultado12, Resultado13,
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

                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                            BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                            ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 1, ValidaJuegoInicio);

                        }
                        else if (AutoPress == 2)
                        {
                            ResultFront = CalcularApuestaPresionFront2(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                                Resultado6, Resultado7, Resultado8, Resultado9, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack2(Resultado10, Resultado11, Resultado12, Resultado13,
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

                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                              BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                              ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 2, ValidaJuegoInicio);

                        }
                        else if (AutoPress == 3)
                        {
                            ResultFront = CalcularApuestaPresionFront3(Resultado1, Resultado2, Resultado3, Resultado4, Resultado5,
                                Resultado6, Resultado7, Resultado8, Resultado9, ValidaJuegoInicio);

                            ResultBack = CalcularApuestaPresionBack3(Resultado10, Resultado11, Resultado12, Resultado13,
                                Resultado14, Resultado15, Resultado16, Resultado17, Resultado18, ValidaJuegoInicio);

                            string[] FrontValores = ResultFront[0].Split(',');
                            string[] BackValores = ResultBack[0].Split(',');

                            BetD_F9_1 = Convert.ToString(FrontValores[0]);
                            BetD_F9_2 = Convert.ToString(FrontValores[1]);
                            BetD_F9_3 = Convert.ToString(FrontValores[2]);

                            BetD_B9_1 = Convert.ToString(BackValores[0]);
                            BetD_B9_2 = Convert.ToString(BackValores[1]);
                            BetD_B9_3 = Convert.ToString(BackValores[2]);

                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, BetD_F9_1, BetD_F9_2, BetD_F9_3, BetD_F9_4, BetD_F9_5, BetD_F9_6,
                                             BetD_F9_7, BetD_F9_8, BetD_F9_9, BetD_B9_1, BetD_B9_2, BetD_B9_3, BetD_B9_4, BetD_B9_5, BetD_B9_6, BetD_B9_7, BetD_B9_8, BetD_B9_9, ResultadoFinalMedal, ContadorHoyos,
                                           ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 3, ValidaJuegoInicio);

                        }
                        else
                        {

                            ActualizarAPuesta(Datos.IDBetDetail, Datos.IDBet, Datos.IDRonda, PlayerID1, PlayerID2, Convert.ToString(Resultado1), Convert.ToString(Resultado2), Convert.ToString(Resultado3), Convert.ToString(Resultado4), Convert.ToString(Resultado5), Convert.ToString(Resultado6),
                                            Convert.ToString(Resultado7), Convert.ToString(Resultado8), Convert.ToString(Resultado9), Convert.ToString(Resultado10), Convert.ToString(Resultado11), Convert.ToString(Resultado12), Convert.ToString(Resultado13), Convert.ToString(Resultado14), Convert.ToString(Resultado15), Convert.ToString(Resultado16), Convert.ToString(Resultado17), Convert.ToString(Resultado18), ResultadoFinalMedal, ContadorHoyos,
                                           ResultFront[1], ResultFront[2], ResultFront[3], ResultFront[4], ResultFront[5], ResultFront[6], ResultFront[7], ResultFront[8], ResultFront[9],
                                            ResultBack[1], ResultBack[2], ResultBack[3], ResultBack[4], ResultBack[5], ResultBack[6], ResultBack[7], ResultBack[8], ResultBack[9], 1, ValidaJuegoInicio);

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

        private string[] CalcularApuestaPresionFront1(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9, bool ValidaJuegoInicio)
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

        private string[] CalcularApuestaPresionBack1(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9, bool ValidaJuegoInicio)
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

        private string[] CalcularApuestaPresionFront2(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9, bool ValidaJuegoInicio)
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

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;


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

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;


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

        private string[] CalcularApuestaPresionBack2(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9, bool ValidaJuegoInicio)
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

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3;


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

                            ResultadoPresionFrontString[i] = Convert.ToString(ResultadoInt) + ", " + PresionValor1 + ", " + PresionValor2 + ", " + PresionValor3 + ", " + PresionValor4;


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

        private string[] CalcularApuestaPresionFront3(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9, bool ValidaJuegoInicio)
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

        private string[] CalcularApuestaPresionBack3(int Resultado1, int Resultado2, int Resultado3, int Resultado4, int Resultado5, int Resultado6, int Resultado7, int Resultado8, int Resultado9, bool ValidaJuegoInicio)
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

        private int ActualizarAPuesta(int IDBetDetail, int IDBet, int IDRonda, int BetD_Player1, int BetD_Player2, string BetD_F9_1, string BetD_F9_2, string BetD_F9_3, string BetD_F9_4, string BetD_F9_5, string BetD_F9_6, string BetD_F9_7, string BetD_F9_8, string BetD_F9_9,
                                      string BetD_B9_1, string BetD_B9_2, string BetD_B9_3, string BetD_B9_4, string BetD_B9_5, string BetD_B9_6, string BetD_B9_7, string BetD_B9_8, string BetD_B9_9, int ResultadoFinalMedal, int Match,
                                      string Hoyo_1, string Hoyo_2, string Hoyo_3, string Hoyo_4, string Hoyo_5, string Hoyo_6, string Hoyo_7, string Hoyo_8, string Hoyo_9,
                                      string Hoyo_10, string Hoyo_11, string Hoyo_12, string Hoyo_13, string Hoyo_14, string Hoyo_15, string Hoyo_16, string Hoyo_17, string Hoyo_18
                                      , int Presion, bool ValidaJuegoInicio)
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
