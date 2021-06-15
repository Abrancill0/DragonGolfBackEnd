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
    [RoutePrefix("api/CalcularGolpesVentajaTeam")]
    public class CalcularGolpesVentajaTeamController : ApiController
    {

        public class ParametrosEntradas
        {
            public int PlayerId1 { get; set; }
            public int PlayerId2 { get; set; }
            public int PlayerId3 { get; set; }
            public int PlayerId4 { get; set; }
            public int IDRound { get; set; }

        }
     
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_Calculate_GolpesVentaja");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@PlayerId1", SqlDbType.Int);
                comando.Parameters.Add("@PlayerId2", SqlDbType.Int);
                comando.Parameters.Add("@PlayerId3", SqlDbType.Int);
                comando.Parameters.Add("@PlayerId4", SqlDbType.Int);
                comando.Parameters.Add("@IDRound", SqlDbType.Int);

                comando.Parameters["@PlayerId1"].Value = Datos.PlayerId1;
                comando.Parameters["@PlayerId2"].Value = Datos.PlayerId2;
                comando.Parameters["@PlayerId3"].Value = Datos.PlayerId3;
                comando.Parameters["@PlayerId4"].Value = Datos.PlayerId4;
                comando.Parameters["@IDRound"].Value = Datos.IDRound;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);

                string Mensaje = "";
                int Estatus = 0;
                double Golpesventaja = 0;

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {
                   
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {
                            Golpesventaja = Convert.ToDouble(row["Golpesventaja"]);
                        }
                    }

                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,
                        golpesventaja = Golpesventaja
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
