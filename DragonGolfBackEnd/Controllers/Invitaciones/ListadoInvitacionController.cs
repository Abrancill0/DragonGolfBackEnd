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
    [RoutePrefix("api/ListadoInvitacion")]
    public class ListadoInvitacionController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }
        }
        public class ParametrosSalida
        {
            public int IDUsuario{ get; set; }
            public int IDInvitacion { get; set; }
            public int IDUsuarioEmisor { get; set; }
            public int IDUsuarioReceptor { get; set; }
            public int IDRonda { get; set; }
            public DateTime FechaCreacion { get; set; }
            public bool Estatus { get; set; }
            public string Ro_Name { get; set; }
            public string Nombre { get; set; }

        }


        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_Listinvitation");
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

                        if (Estatus == 1)
                        {

                            string numeroFormato = Convert.ToInt32(row["usu_ghinnumber"]).ToString("D7");

                            ParametrosSalida ent = new ParametrosSalida
                            {
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                IDInvitacion = Convert.ToInt32(row["IDInvitacion"]),
                                IDUsuarioEmisor = Convert.ToInt32(row["IDUsuarioEmisor"]),
                                IDUsuarioReceptor = Convert.ToInt32(row["IDUsuarioReceptor"]),
                                IDRonda = Convert.ToInt32(row["IDRonda"]),
                                FechaCreacion = Convert.ToDateTime(row["FechaCreacion"]),
                                Estatus = Convert.ToBoolean(row["Estatus"]),
                                Ro_Name = Convert.ToString(row["Ro_Name"]),
                                Nombre = Convert.ToString(row["Nombre"]),
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
