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
    [RoutePrefix("api/ListaTees")]
    public class ListaTeesController : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDCourse { get; set; }
        }


        public class ParametrosSalida
        {

            public int IDHoles { get; set; }
            public int IDTees { get; set; }
            public string Te_TeeName { get; set; }
            public int Te_Slope { get; set; }
            public int Te_Rating { get; set; }
            public string Te_TeeColor { get; set; }
            public int Te_In { get; set; }
            public int Te_Out { get; set; }
            public int Te_Total { get; set; }
            public int IDCourse { get; set; }
            public DateTime Te_FechaCreacion { get; set; }
            public string Cou_Nombre { get; set; }
            public string Cou_NombreCorto { get; set; }
            public string Cou_Pais { get; set; }
        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListTees");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDCourse", SqlDbType.Int);


                //Asignacion de valores a parametros
                comando.Parameters["@IDCourse"].Value = Datos.IDCourse;


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
                                
                                IDTees = Convert.ToInt32(row["IDTees"]),
                                Te_TeeName = Convert.ToString(row["Te_TeeName"]),
                                Te_Slope = Convert.ToInt32(row["Te_Slope"]),
                                Te_Rating = Convert.ToInt32(row["Te_Rating"]),
                                Te_TeeColor = Convert.ToString(row["Te_TeeColor"]),
                                Te_In = Convert.ToInt32(row["Te_In"]),
                                Te_Out = Convert.ToInt32(row["Te_Out"]),
                                Te_Total = Convert.ToInt32(row["Te_Total"]),
                                IDCourse = Convert.ToInt32(row["IDCourse"]),
                                Te_FechaCreacion = Convert.ToDateTime(row["Te_FechaCreacion"]),
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
