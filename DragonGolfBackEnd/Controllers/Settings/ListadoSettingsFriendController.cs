﻿using DragonGolfBackEnd.Clases;
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
    [RoutePrefix("api/ListadoSettingsFriend")]
    public class ListadoSettingsFriendController : ApiController
    {
        public class ParametrosSalida
        {
            public int IDSettings { get; set; }
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

        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
            public int IDUsuarioFriend { get; set; }

        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListSettingsPlayer");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuarioFriend", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                comando.Parameters["@IDUsuarioFriend"].Value = Datos.IDUsuarioFriend;


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
                                IDSettings = Convert.ToInt32(row["IDSettings"]),
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                set_idioma = Convert.ToString(row["set_idioma"]),
                                set_how_adv_move = Convert.ToString(row["set_how_adv_move"]),
                                set_strokes_moved_per_round = Convert.ToInt32(row["set_strokes_moved_per_round"]),
                                set_adv_moves_on_9_holes = Convert.ToBoolean(row["set_adv_moves_on_9_holes"]),
                                set_carry_moves_adv = Convert.ToBoolean(row["set_carry_moves_adv"]),
                                set_rabbit_1_6 = Convert.ToInt32(row["set_rabbit_1_6"]),
                                set_rabbit_7_12 = Convert.ToInt32(row["set_rabbit_7_12"]),
                                set_rabbit_13_18 = Convert.ToInt32(row["set_rabbit_13_18"]),
                                set_medal_play_f9 = Convert.ToInt32(row["set_medal_play_f9"]),
                                set_medal_play_b9 = Convert.ToInt32(row["set_medal_play_b9"]),
                                set_medal_play_18 = Convert.ToInt32(row["set_medal_play_18"]),
                                set_skins = Convert.ToInt32(row["set_skins"]),
                                set_skins_carry_over = Convert.ToBoolean(row["set_skins_carry_over"]),
                                set_lower_adv_f9 = Convert.ToBoolean(row["set_lower_adv_f9"]),
                                set_snw_automatic_press = Convert.ToInt32(row["set_snw_automatic_press"]),
                                set_snw_use_factor = Convert.ToBoolean(row["set_snw_use_factor"]),
                                set_snw_front_9 = Convert.ToInt32(row["set_snw_front_9"]),
                                set_snw_back_9 = Convert.ToInt32(row["set_snw_back_9"]),
                                set_snw_match = Convert.ToInt32(row["set_snw_match"]),
                                set_snw_carry = Convert.ToInt32(row["set_snw_carry"]),
                                set_snw_medal = Convert.ToInt32(row["set_snw_medal"]),
                                set_tmw_automatic_press = Convert.ToInt32(row["set_tmw_automatic_press"]),
                                set_tmw_use_factor = Convert.ToBoolean(row["set_tmw_use_factor"]),
                                set_tmw_front_9 = Convert.ToInt32(row["set_tmw_front_9"]),
                                set_tmw_back_9 = Convert.ToInt32(row["set_tmw_back_9"]),
                                set_tmw_match = Convert.ToInt32(row["set_tmw_match"]),
                                set_tmw_carry = Convert.ToInt32(row["set_tmw_carry"]),
                                set_tmw_medal = Convert.ToInt32(row["set_tmw_medal"]),
                                set_tmw_adv_strokes = Convert.ToString(row["set_tmw_adv_strokes"]),
                                set_eb_wager = Convert.ToInt32(row["set_eb_wager"]),
                                set_bbt_wager_f9 = Convert.ToInt32(row["set_bbt_wager_f9"]),
                                set_bbt_wager_b9 = Convert.ToInt32(row["set_bbt_wager_b9"]),
                                set_bbt_wager_18 = Convert.ToInt32(row["set_bbt_wager_18"]),
                                set_stableford_double_eagle = Convert.ToInt32(row["set_stableford_double_eagle"]),
                                set_stableford_eagle = Convert.ToInt32(row["set_stableford_eagle"]),
                                set_stableford_birdie = Convert.ToInt32(row["set_stableford_birdie"]),
                                set_stableford_par = Convert.ToInt32(row["set_stableford_par"]),
                                set_stableford_bogey = Convert.ToInt32(row["set_stableford_bogey"]),
                                set_stableford_double_bogey = Convert.ToInt32(row["set_stableford_double_bogey"]),
                                set_golpesventaja = Convert.ToDecimal(row["set_golpesventaja"]),
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
