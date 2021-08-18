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
    [RoutePrefix("api/HandicapIndex")]
    public class HandicapIndexController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
        }

        public class ParametrosSalida
        {
            public int PlayerId { get; set; }
            public string Cou_Nombre { get; set; }
            public string PlayerTee { get; set; }
            public int Te_Slope { get; set; }
            public double Te_Rating { get; set; }
            public double Score18 { get; set; }
            public double Diferencial { get; set; }
            public int NumeroRonda { get; set; }
            public double Handicap { get; set; }
        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_HandicapAutoCalculate");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);

                //Asignacion de valores a parametros
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

                        ParametrosSalida ent = new ParametrosSalida
                        {
                            PlayerId = Convert.ToInt32(row["PlayerId"]),
                            Cou_Nombre = Convert.ToString(row["Cou_Nombre"]),
                            PlayerTee = Convert.ToString(row["PlayerTee"]),
                            Te_Slope = Convert.ToInt32(row["Te_Slope"]),
                            Te_Rating = Convert.ToDouble(row["Te_Rating"]),
                            Score18 = Convert.ToDouble(row["Score18"]),
                            Diferencial = Convert.ToDouble(row["Diferencial"]),
                            NumeroRonda = Convert.ToInt32(row["NumeroRonda"]),
                            Handicap = Convert.ToDouble(row["Handicap"])
                        };


                        lista.Add(ent);


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
