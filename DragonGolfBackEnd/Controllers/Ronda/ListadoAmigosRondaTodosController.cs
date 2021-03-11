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
    [RoutePrefix("api/ListadoAmigosRondaTodos")]
    public class ListadoAmigosRondaTodosController : ApiController
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


                    decimal Adv1 = 0;


                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {

                            string numeroFormato = Convert.ToInt32(row["usu_ghinnumber"]).ToString("D7");


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
                            Adv1 = Convert.ToDecimal(row["handicapAuto"]);

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

                                for (int i = 1; i < CicloFor; i++)
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

                                            GolpesVentaja1 = GolpesVentaja1 + 1;


                                        }

                                        if (DificultatHoyo2 == Contador)
                                        {
                                            GolpesVentaja2 = GolpesVentaja2 + 1;

                                        }

                                        if (DificultatHoyo3 == Contador)
                                        {
                                            GolpesVentaja3 = GolpesVentaja3 + 1;

                                        }

                                        if (DificultatHoyo4 == Contador)
                                        {
                                            GolpesVentaja4 = GolpesVentaja4 + 1;

                                        }

                                        if (DificultatHoyo5 == Contador)
                                        {
                                            GolpesVentaja5 = GolpesVentaja5 - 1;

                                        }

                                        if (DificultatHoyo6 == Contador)
                                        {
                                            GolpesVentaja6 = GolpesVentaja6 + 1;

                                        }

                                        if (DificultatHoyo7 == Contador)
                                        {
                                            GolpesVentaja7 = GolpesVentaja7 + 1;

                                        }

                                        if (DificultatHoyo8 == Contador)
                                        {
                                            GolpesVentaja8 = GolpesVentaja8 + 1;

                                        }

                                        if (DificultatHoyo9 == Contador)
                                        {
                                            GolpesVentaja9 = GolpesVentaja9 + 1;

                                        }

                                        if (DificultatHoyo10 == Contador)
                                        {
                                            GolpesVentaja10 = GolpesVentaja10 + 1;

                                        }

                                        if (DificultatHoyo11 == Contador)
                                        {
                                            GolpesVentaja11 = GolpesVentaja11 + 1;

                                        }

                                        if (DificultatHoyo12 == Contador)
                                        {
                                            GolpesVentaja12 = GolpesVentaja12 + 1;

                                        }

                                        if (DificultatHoyo13 == Contador)
                                        {
                                            GolpesVentaja13 = GolpesVentaja13 + 1;

                                        }

                                        if (DificultatHoyo14 == Contador)
                                        {
                                            GolpesVentaja14 = GolpesVentaja14 + 1;

                                        }

                                        if (DificultatHoyo15 == Contador)
                                        {
                                            GolpesVentaja15 = GolpesVentaja15 + 1;
                                        }

                                        if (DificultatHoyo16 == Contador)
                                        {
                                            GolpesVentaja16 = GolpesVentaja16 + 1;
                                        }

                                        if (DificultatHoyo17 == Contador)
                                        {
                                            GolpesVentaja17 = GolpesVentaja17 + 1;
                                        }

                                        if (DificultatHoyo18 == Contador)
                                        {
                                            GolpesVentaja18 = GolpesVentaja18 + 1;
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

                                for (int i = 1; i < CicloFor; i++)
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

                                            GolpesVentaja1 = GolpesVentaja1 + 1;


                                        }

                                        if (DificultatHoyo2 == Contador)
                                        {
                                            GolpesVentaja2 = GolpesVentaja2 + 1;

                                        }

                                        if (DificultatHoyo3 == Contador)
                                        {
                                            GolpesVentaja3 = GolpesVentaja3 + 1;

                                        }

                                        if (DificultatHoyo4 == Contador)
                                        {
                                            GolpesVentaja4 = GolpesVentaja3 + 1;

                                        }

                                        if (DificultatHoyo5 == Contador)
                                        {
                                            GolpesVentaja5 = GolpesVentaja5 + 1;

                                        }

                                        if (DificultatHoyo6 == Contador)
                                        {
                                            GolpesVentaja6 = GolpesVentaja6 + 1;

                                        }

                                        if (DificultatHoyo7 == Contador)
                                        {
                                            GolpesVentaja7 = GolpesVentaja7 + 1;

                                        }

                                        if (DificultatHoyo8 == Contador)
                                        {
                                            GolpesVentaja8 = GolpesVentaja8 + 1;

                                        }

                                        if (DificultatHoyo9 == Contador)
                                        {
                                            GolpesVentaja9 = GolpesVentaja9 + 1;

                                        }

                                        if (DificultatHoyo10 == Contador)
                                        {
                                            GolpesVentaja10 = GolpesVentaja10 + 1;

                                        }

                                        if (DificultatHoyo11 == Contador)
                                        {
                                            GolpesVentaja11 = GolpesVentaja11 + 1;

                                        }

                                        if (DificultatHoyo12 == Contador)
                                        {
                                            GolpesVentaja12 = GolpesVentaja12 + 1;
                                        }

                                        if (DificultatHoyo13 == Contador)
                                        {
                                            GolpesVentaja13 = GolpesVentaja13 + 1;

                                        }

                                        if (DificultatHoyo14 == Contador)
                                        {
                                            GolpesVentaja14 = GolpesVentaja14 + 1;

                                        }

                                        if (DificultatHoyo15 == Contador)
                                        {
                                            GolpesVentaja15 = GolpesVentaja15 + 1;

                                        }

                                        if (DificultatHoyo16 == Contador)
                                        {
                                            GolpesVentaja16 = GolpesVentaja16 + 1;

                                        }

                                        if (DificultatHoyo17 == Contador)
                                        {
                                            GolpesVentaja17 = GolpesVentaja17 + 1;

                                        }

                                        if (DificultatHoyo18 == Contador)
                                        {
                                            GolpesVentaja18 = GolpesVentaja18 + 1;

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

                            TotalGolpesVentajaFront = GolpesVentaja1 + GolpesVentaja2 + GolpesVentaja3 + GolpesVentaja4 + GolpesVentaja5 + GolpesVentaja6 + GolpesVentaja7 + GolpesVentaja8 + GolpesVentaja9;
                            TotalGolpesVentajaBack = GolpesVentaja10 + GolpesVentaja11 + GolpesVentaja12 + GolpesVentaja13 + GolpesVentaja14 + GolpesVentaja15 + GolpesVentaja16 + GolpesVentaja17 + GolpesVentaja18;


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
                                GolpesVentaja1 = GolpesVentaja1,
                                GolpesVentaja2 = GolpesVentaja2,
                                GolpesVentaja3 = GolpesVentaja3,
                                GolpesVentaja4 = GolpesVentaja4,
                                GolpesVentaja5 = GolpesVentaja5,
                                GolpesVentaja6 = GolpesVentaja6,
                                GolpesVentaja7 = GolpesVentaja7,
                                GolpesVentaja8 = GolpesVentaja8,
                                GolpesVentaja9 = GolpesVentaja9,
                                GolpesVentaja10 = GolpesVentaja10,
                                GolpesVentaja11 = GolpesVentaja11,
                                GolpesVentaja12 = GolpesVentaja12,
                                GolpesVentaja13 = GolpesVentaja13,
                                GolpesVentaja14 = GolpesVentaja14,
                                GolpesVentaja15 = GolpesVentaja15,
                                GolpesVentaja16 = GolpesVentaja16,
                                GolpesVentaja17 = GolpesVentaja17,
                                GolpesVentaja18 = GolpesVentaja18
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