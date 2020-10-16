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
    [RoutePrefix("api/ListaHole")]
    public class ListaHoleController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDTees { get; set; }
        }


        public class ParametrosSalida
        {

            public int IDHoles { get; set; }
            public string Ho_TeeName { get; set; }
            public int Ho_Hole { get; set; }
            public int Ho_Par { get; set; }
            public int Ho_Advantage { get; set; }
            public int Ho_Yards { get; set; }
            public int IDTees { get; set; }
            public DateTime Ho_FechaCreacion { get; set; }
            public string Te_TeeName { get; set; }
            public string Cou_Nombre { get; set; }
            public string Cou_NombreCorto { get; set; }
            public string Cou_Pais { get; set; }
        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListHole");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDTees", SqlDbType.Int);


                //Asignacion de valores a parametros
                comando.Parameters["@IDTees"].Value = Datos.IDTees;


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


                                IDHoles = Convert.ToInt32(row["IDHoles"]),
                                Ho_TeeName = Convert.ToString(row["Ho_TeeName"]),
                                Ho_Hole = Convert.ToInt32(row["Ho_Hole"]),
                                Ho_Par = Convert.ToInt32(row["Ho_Par"]),
                                Ho_Advantage = Convert.ToInt32(row["Ho_Advantage"]),
                                Ho_Yards = Convert.ToInt32(row["Ho_Yards"]),
                                IDTees = Convert.ToInt32(row["IDTees"]),
                                Ho_FechaCreacion = Convert.ToDateTime(row["Ho_FechaCreacion"]),
                                Te_TeeName = Convert.ToString(row["Te_TeeName"]),
                                Cou_Nombre = Convert.ToString(row["Cou_Nombre"]),
                                Cou_NombreCorto = Convert.ToString(row["Cou_NombreCorto"]),
                                Cou_Pais = Convert.ToString(row["Cou_Pais"]),

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
