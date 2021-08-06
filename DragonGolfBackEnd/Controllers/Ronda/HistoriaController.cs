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
    [RoutePrefix("api/Historia")]
    public class HistoriaController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDUsuario1 { get; set; }
            public int IDUsuario2 { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
        }
        public class ParametrosSalida
        {
            public double GanadoPerdido { get; set; }
            public int IDRonda { get; set; }
            public DateTime Fecha { get; set; }
            public string Ronda { get; set; }
            public string Campo { get; set; }
            public double Stroke { get; set; }
            public double StrokeSiguiente { get; set; }
        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_History");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario1", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuario2", SqlDbType.Int);
                comando.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
                comando.Parameters.Add("@FechaFin", SqlDbType.DateTime);

                //Asignacion de valores a parametros
                comando.Parameters["@IDUsuario1"].Value = Datos.IDUsuario1;
                comando.Parameters["@IDUsuario2"].Value = Datos.IDUsuario2;
                comando.Parameters["@FechaInicio"].Value = Datos.FechaInicio;
                comando.Parameters["@FechaFin"].Value = Datos.FechaFin;

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
                            GanadoPerdido = Convert.ToDouble(row["GanadoPerdido"]),
                            IDRonda = Convert.ToInt32(row["IDRonda"]),
                            Fecha = Convert.ToDateTime(row["Fecha"]),
                            Ronda = Convert.ToString(row["Ronda"]),
                            Campo = Convert.ToString(row["Campo"]),
                            Stroke = Convert.ToDouble(row["Stroke"]),
                            StrokeSiguiente = Convert.ToDouble(row["StrokeSiguiente"])
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
