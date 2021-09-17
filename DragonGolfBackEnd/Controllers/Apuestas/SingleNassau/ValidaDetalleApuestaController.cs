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
    [RoutePrefix("api/ValidaDetalleApuesta")]
    public class ValidaDetalleApuestaController : ApiController
    {

       

        public class ParametrosEntrada
        {
            public int IDBet { get; set; }
            public int IDRonda { get; set; }
            public int BetD_Player1 { get; set; }
            public int BetD_Player2 { get; set; }
        }

        public JObject Post(ParametrosEntrada Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ValidateCreateDetailBet");
                comando.CommandType = CommandType.StoredProcedure;


                //Declaracion de parametros
                comando.Parameters.Add("@IDBet", SqlDbType.Int);
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);
                comando.Parameters.Add("@BetD_Player1", SqlDbType.Int);
                comando.Parameters.Add("@BetD_Player2", SqlDbType.Int);
              
                //Asignacion de valores a parametros
                comando.Parameters["@IDBet"].Value = Datos.IDBet;
                comando.Parameters["@IDRonda"].Value = Datos.IDRonda;
                comando.Parameters["@BetD_Player1"].Value = Datos.BetD_Player1;
                comando.Parameters["@BetD_Player2"].Value = Datos.BetD_Player2;


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
