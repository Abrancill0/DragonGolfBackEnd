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
    [RoutePrefix("api/AltaSettingsFriend")]
    public class AltaSettingsFriendController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
            public int IDUsuarioFriend { get; set; }
            public string set_idioma { get; set; }
            public string set_how_adv_move { get; set; }
            public decimal set_strokes_moved_per_round { get; set; }
            public bool set_adv_moves_on_9_holes { get; set; }
            public bool set_carry_moves_adv { get; set; }
            public int set_rabbit_1_6 { get; set; }
            public int set_rabbit_7_12 { get; set; }
            public int set_rabbit_13_18 { get; set; }
            public int set_medal_play_f9 { get; set; }
            public int set_medal_play_b9 { get; set; }
            public int set_medal_play_18 { get; set; }
            public int set_skins { get; set; }
            public bool set_skins_carry_over { get; set; }
            public bool set_lower_adv_f9 { get; set; }
            public int set_snw_automatic_press { get; set; }
            public bool set_snw_use_factor { get; set; }
            public int set_snw_front_9 { get; set; }
            public int set_snw_back_9 { get; set; }
            public int set_snw_match { get; set; }
            public int set_snw_carry { get; set; }
            public int set_snw_medal { get; set; }
            public int set_tmw_automatic_press { get; set; }
            public bool set_tmw_use_factor { get; set; }
            public int set_tmw_front_9 { get; set; }
            public int set_tmw_back_9 { get; set; }
            public int set_tmw_match { get; set; }
            public int set_tmw_carry { get; set; }
            public int set_tmw_medal { get; set; }
            public string set_tmw_adv_strokes { get; set; }
            public int set_eb_wager { get; set; }
            public int set_bbt_wager_f9 { get; set; }
            public int set_bbt_wager_b9 { get; set; }
            public int set_bbt_wager_18 { get; set; }
            public int set_stableford_double_eagle { get; set; }
            public int set_stableford_eagle { get; set; }
            public int set_stableford_birdie { get; set; }
            public int set_stableford_par { get; set; }
            public int set_stableford_bogey { get; set; }
            public int set_stableford_double_bogey { get; set; }
            public decimal set_golpesventaja { get; set; }
            public decimal set_diferenciatee { get; set; }
}

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_InsertSettingsPlayer");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuarioFriend", SqlDbType.Int);
                comando.Parameters.Add("@set_idioma", SqlDbType.VarChar);
                comando.Parameters.Add("@set_how_adv_move", SqlDbType.Int);
                comando.Parameters.Add("@set_strokes_moved_per_round", SqlDbType.Decimal);
                comando.Parameters.Add("@set_adv_moves_on_9_holes", SqlDbType.Bit);
                comando.Parameters.Add("@set_carry_moves_adv", SqlDbType.Bit);
                comando.Parameters.Add("@set_rabbit_1_6", SqlDbType.Int);
                comando.Parameters.Add("@set_rabbit_7_12", SqlDbType.Int);
                comando.Parameters.Add("@set_rabbit_13_18", SqlDbType.Int);
                comando.Parameters.Add("@set_medal_play_f9", SqlDbType.Int);
                comando.Parameters.Add("@set_medal_play_b9", SqlDbType.Int);
                comando.Parameters.Add("@set_medal_play_18", SqlDbType.Int);
                comando.Parameters.Add("@set_skins", SqlDbType.Int);
                comando.Parameters.Add("@set_skins_carry_over", SqlDbType.Bit);
                comando.Parameters.Add("@set_lower_adv_f9", SqlDbType.Bit);
                comando.Parameters.Add("@set_snw_automatic_press", SqlDbType.Int);
                comando.Parameters.Add("@set_snw_use_factor", SqlDbType.Bit);
                comando.Parameters.Add("@set_snw_front_9", SqlDbType.Int);
                comando.Parameters.Add("@set_snw_back_9", SqlDbType.Int);
                comando.Parameters.Add("@set_snw_match", SqlDbType.Int);
                comando.Parameters.Add("@set_snw_carry", SqlDbType.Int);
                comando.Parameters.Add("@set_snw_medal", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_automatic_press", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_use_factor", SqlDbType.Bit);
                comando.Parameters.Add("@set_tmw_front_9", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_back_9", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_match", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_carry", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_medal", SqlDbType.Int);
                comando.Parameters.Add("@set_tmw_adv_strokes", SqlDbType.VarChar);
                comando.Parameters.Add("@set_eb_wager", SqlDbType.Int);
                comando.Parameters.Add("@set_bbt_wager_f9", SqlDbType.Int);
                comando.Parameters.Add("@set_bbt_wager_b9", SqlDbType.Int);
                comando.Parameters.Add("@set_bbt_wager_18", SqlDbType.Int);
                comando.Parameters.Add("@set_stableford_double_eagle", SqlDbType.Int);
                comando.Parameters.Add("@set_stableford_eagle", SqlDbType.Int);
                comando.Parameters.Add("@set_stableford_birdie", SqlDbType.Int);
                comando.Parameters.Add("@set_stableford_par", SqlDbType.Int);
                comando.Parameters.Add("@set_stableford_bogey", SqlDbType.Int);
                comando.Parameters.Add("@set_stableford_double_bogey", SqlDbType.Int);
                comando.Parameters.Add("@set_golpesventaja", SqlDbType.Int);
                comando.Parameters.Add("@set_diferenciatee", SqlDbType.Int);


                //Asignacion de valores a parametros
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                comando.Parameters["@IDUsuarioFriend"].Value = Datos.IDUsuarioFriend;
                comando.Parameters["@set_idioma"].Value = Datos.set_idioma;
                comando.Parameters["@set_how_adv_move"].Value = Datos.set_how_adv_move;
                comando.Parameters["@set_strokes_moved_per_round"].Value = Datos.set_strokes_moved_per_round;
                comando.Parameters["@set_adv_moves_on_9_holes"].Value = Datos.set_adv_moves_on_9_holes;
                comando.Parameters["@set_carry_moves_adv"].Value = Datos.set_carry_moves_adv;
                comando.Parameters["@set_rabbit_1_6"].Value = Datos.set_rabbit_1_6;
                comando.Parameters["@set_rabbit_7_12"].Value = Datos.set_rabbit_7_12;
                comando.Parameters["@set_rabbit_13_18"].Value = Datos.set_rabbit_13_18;
                comando.Parameters["@set_medal_play_f9"].Value = Datos.set_medal_play_f9;
                comando.Parameters["@set_medal_play_b9"].Value = Datos.set_medal_play_b9;
                comando.Parameters["@set_medal_play_18"].Value = Datos.set_medal_play_18;
                comando.Parameters["@set_skins"].Value = Datos.set_skins;
                comando.Parameters["@set_skins_carry_over"].Value = Datos.set_skins_carry_over;
                comando.Parameters["@set_lower_adv_f9"].Value = Datos.set_lower_adv_f9;
                comando.Parameters["@set_snw_automatic_press"].Value = Datos.set_snw_automatic_press;
                comando.Parameters["@set_snw_use_factor"].Value = Datos.set_snw_use_factor;
                comando.Parameters["@set_snw_front_9"].Value = Datos.set_snw_front_9;
                comando.Parameters["@set_snw_back_9"].Value = Datos.set_snw_back_9;
                comando.Parameters["@set_snw_match"].Value = Datos.set_snw_match;
                comando.Parameters["@set_snw_carry"].Value = Datos.set_snw_carry;
                comando.Parameters["@set_snw_medal"].Value = Datos.set_snw_medal;
                comando.Parameters["@set_tmw_automatic_press"].Value = Datos.set_tmw_automatic_press;
                comando.Parameters["@set_tmw_use_factor"].Value = Datos.set_tmw_use_factor;
                comando.Parameters["@set_tmw_front_9"].Value = Datos.set_tmw_front_9;
                comando.Parameters["@set_tmw_back_9"].Value = Datos.set_tmw_back_9;
                comando.Parameters["@set_tmw_match"].Value = Datos.set_tmw_match;
                comando.Parameters["@set_tmw_carry"].Value = Datos.set_tmw_carry;
                comando.Parameters["@set_tmw_medal"].Value = Datos.set_tmw_medal;
                comando.Parameters["@set_tmw_adv_strokes"].Value = Datos.set_tmw_adv_strokes;
                comando.Parameters["@set_eb_wager"].Value = Datos.set_eb_wager;
                comando.Parameters["@set_bbt_wager_f9"].Value = Datos.set_bbt_wager_f9;
                comando.Parameters["@set_bbt_wager_b9"].Value = Datos.set_bbt_wager_b9;
                comando.Parameters["@set_bbt_wager_18"].Value = Datos.set_bbt_wager_18;
                comando.Parameters["@set_stableford_double_eagle"].Value = Datos.set_stableford_double_eagle;
                comando.Parameters["@set_stableford_eagle"].Value = Datos.set_stableford_eagle;
                comando.Parameters["@set_stableford_birdie"].Value = Datos.set_stableford_birdie;
                comando.Parameters["@set_stableford_par"].Value = Datos.set_stableford_par;
                comando.Parameters["@set_stableford_bogey"].Value = Datos.set_stableford_bogey;
                comando.Parameters["@set_stableford_double_bogey"].Value = Datos.set_stableford_double_bogey;
                comando.Parameters["@set_golpesventaja"].Value = Datos.set_golpesventaja;
                comando.Parameters["@set_diferenciatee"].Value = Datos.set_diferenciatee;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);



                string Mensaje = "";
                int Estatus = 0;

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
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


    }
}
