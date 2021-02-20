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
    [RoutePrefix("api/ListadoAmigosRonda")]
    public class ListadoAmigosRondaController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
            public int IDRounds { get; set; }

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
            public decimal usu_handicapindex { get; set; }
          public int ValidaUsuarioCreo { get; set; }
            public int IDUsuarioCreo { get; set; }



    }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListFriendRound");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRounds", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);


                comando.Parameters["@IDRounds"].Value = Datos.IDRounds;
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

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {

                            string numeroFormato = Convert.ToInt32(row["usu_ghinnumber"]).ToString("D7");

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
