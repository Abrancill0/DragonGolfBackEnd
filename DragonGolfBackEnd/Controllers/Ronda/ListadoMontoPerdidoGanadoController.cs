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
    [RoutePrefix("api/ListadoMontoPerdidoGanado")]
    public class ListadoMontoPerdidoGanadoController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDRound { get; set; }
        }
        public class ParametrosSalida
        {
           
            public int IDRonda { get; set; }
            public int IDUsuario { get; set; }
            public string usu_email { get; set; }
            public int MontoPerdidoGanado { get; set; }
            public string usu_nickname { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_LostEarnedAmount");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRound", SqlDbType.Int);

                comando.Parameters["@IDRound"].Value = Datos.IDRound;

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

                                IDRonda = Convert.ToInt32(row["IDRonda"]),
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                MontoPerdidoGanado = Convert.ToInt32(row["MontoPerdidoGanado"]),
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
