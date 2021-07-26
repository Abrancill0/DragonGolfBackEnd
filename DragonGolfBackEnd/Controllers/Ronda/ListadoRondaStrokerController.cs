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
    [RoutePrefix("api/ListadoRondaStroker")]
    public class ListadoRondaStrokerController : ApiController
    {

        public class ParametrosEntradas
        {
          
            public int IDRound { get; set; }
            public int Player1 { get; set; }
           

        }
        public class ParametrosSalida
        {
            public int RoundPvPId { get; set; }
            public int RoundId { get; set; }
            public int Player1Id { get; set; }
            public int Player2Id { get; set; }
            public decimal P1vsP2Strokes { get; set; }
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public string usu_email { get; set; }
            public string usu_nickname { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListStokers");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRound", SqlDbType.Int);
                comando.Parameters.Add("@Player1", SqlDbType.Int);

                comando.Parameters["@IDRound"].Value = Datos.IDRound;
                comando.Parameters["@Player1"].Value = Datos.Player1;

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
                            double Golpesventaja = 0;
                            int golpes = Convert.ToInt32(row["P1vsP2Strokes"]);
                            double golpes2 = Convert.ToDouble(row["P1vsP2Strokes"]);

                            double Restante = golpes - golpes2;

                            if (Restante == 0.5)
                            {
                                Golpesventaja = Convert.ToDouble(row["P1vsP2Strokes"]);
                            }
                            else if (Restante > 0.5)
                            {

                                Golpesventaja = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(row["P1vsP2Strokes"])));

                            }
                            else if (Restante == -0.5)
                            {
                                Golpesventaja = Convert.ToDouble(row["P1vsP2Strokes"]);
                            }
                            else if (Restante > -0.5)
                            {
                                Golpesventaja = Convert.ToInt32(Math.Floor(Convert.ToDouble(row["P1vsP2Strokes"])));
                            }
                            else
                            {
                                Golpesventaja = Convert.ToDouble(row["P1vsP2Strokes"]);
                            }

                            ParametrosSalida ent = new ParametrosSalida
                            {

                                RoundPvPId = Convert.ToInt32(row["RoundPvPId"]),
                                RoundId = Convert.ToInt32(row["RoundId"]),
                                Player2Id = Convert.ToInt32(row["Player2Id"]),
                                Player1Id= Convert.ToInt32(row["Player1Id"]),
                                P1vsP2Strokes = Convert.ToDecimal(Golpesventaja),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
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
