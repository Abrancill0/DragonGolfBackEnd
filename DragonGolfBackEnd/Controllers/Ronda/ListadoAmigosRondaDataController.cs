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
    [RoutePrefix("api/ListadoAmigosRondaData")]
    public class ListadoAmigosRondaDataController : ApiController
    {

        public class ParametrosEntradas
        {
            public int Player1 { get; set; }
            public int Player2 { get; set; }

}
        public class ParametrosSalida
        {
            public int IDUsuario { get; set; }
            public int set_skins_carry_over { get; set; }
            public int set_snw_use_factor { get; set; }
            public int set_lower_adv_f9 { get; set; }
            public int set_snw_automatic_press { get; set; }
            public int set_snw_front_9 { get; set; }
            public int set_snw_back_9 { get; set; }
            public int set_snw_match { get; set; }
            public int set_snw_carry { get; set; }
            public int set_snw_medal { get; set; }
            public int set_tmw_automatic_press { get; set; }
            public int set_tmw_use_factor { get; set; }
            public int set_tmw_front_9 { get; set; }
            public int set_tmw_back_9 { get; set; }
            public int set_tmw_match { get; set; }
            public int set_tmw_carry { get; set; }
            public int set_tmw_medal { get; set; }
            public int set_tmw_adv_strokes { get; set; }
            public int set_eb_wager { get; set; }
            public int set_bbt_wager_f9 { get; set; }
            public int set_golpesventaja { get; set; }
            public int set_diferenciatee { get; set; }


        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListFriendRound_Data");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@Player1", SqlDbType.Int);
                comando.Parameters.Add("@Player2", SqlDbType.Int);


                comando.Parameters["@Player1"].Value = Datos.Player1;
                comando.Parameters["@Player2"].Value = Datos.Player2;

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


                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                set_skins_carry_over = Convert.ToInt32(row["set_skins_carry_over"]),
                                set_lower_adv_f9 = Convert.ToInt32(row["set_lower_adv_f9"]),
                                set_snw_automatic_press = Convert.ToInt32(row["set_snw_automatic_press"]),
                                set_snw_use_factor = Convert.ToInt32(row["set_snw_use_factor"]),
                                set_snw_front_9 = Convert.ToInt32(row["set_snw_front_9"]),
                                set_snw_back_9 = Convert.ToInt32(row["set_snw_back_9"]),
                                set_snw_match = Convert.ToInt32(row["set_snw_match"]),
                                set_snw_carry = Convert.ToInt32(row["set_snw_carry"]),
                                set_snw_medal = Convert.ToInt32(row["set_snw_medal"]),
                                set_tmw_automatic_press = Convert.ToInt32(row["set_tmw_automatic_press"]),
                                set_tmw_use_factor = Convert.ToInt32(row["set_tmw_use_factor"]),
                                set_tmw_front_9 = Convert.ToInt32(row["set_tmw_front_9"]),
                                set_tmw_back_9 = Convert.ToInt32(row["set_tmw_back_9"]),
                                set_tmw_match = Convert.ToInt32(row["set_tmw_match"]),
                                set_tmw_carry = Convert.ToInt32(row["set_tmw_carry"]),
                                set_tmw_medal = Convert.ToInt32(row["set_tmw_medal"]),
                                set_tmw_adv_strokes = Convert.ToInt32(row["set_tmw_adv_strokes"]),
                                set_eb_wager = Convert.ToInt32(row["set_eb_wager"]),
                                set_bbt_wager_f9 = Convert.ToInt32(row["set_bbt_wager_f9"]),
                                set_golpesventaja = Convert.ToInt32(row["set_golpesventaja"]),
                                set_diferenciatee = Convert.ToInt32(row["set_diferenciatee"]),
                             
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
