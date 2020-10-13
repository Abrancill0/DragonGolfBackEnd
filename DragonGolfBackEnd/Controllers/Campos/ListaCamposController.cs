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
    [RoutePrefix("api/ListaCampos")]
    public class ListaCamposontroller : ApiController
    {

        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
        }


        public class ParametrosSalida
        {
            public int IDCourse { get; set; }
            public string Cou_Nombre { get; set; }
            public string Cou_NombreCorto { get; set; }
            public string Cou_Ciudad { get; set; }
            public string Cou_Pais { get; set; }
            public int IDUsuario { get; set; }
            public DateTime FechaCreacion { get; set; }
        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_InsertCourse");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.VarChar);


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

                        if (Estatus == 1)
                        {
                            ParametrosSalida ent = new ParametrosSalida
                            {
                                IDCourse = Convert.ToInt32(row["IDCourse"]),
                                Cou_Nombre = Convert.ToString(row["Cou_Nombre"]),
                                Cou_NombreCorto = Convert.ToString(row["Cou_NombreCorto"]),
                                Cou_Ciudad = Convert.ToString(row["Cou_Ciudad"]),
                                Cou_Pais = Convert.ToString(row["Cou_Pais"]),
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                FechaCreacion = Convert.ToDateTime(row["FechaCreacion"]),

                            };

                            lista.Add(ent);
                        }
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
