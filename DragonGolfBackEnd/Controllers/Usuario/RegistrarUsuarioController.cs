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
    [RoutePrefix("api/RegistrarUsuario")]
    public class RegistrarUsuarioController : ApiController
    {
        public class ParametrosEntradas
        {
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public string usu_email { get; set; }
            public string usu_nickname { get; set; }
            public string usu_telefono { get; set; }
            public string usu_pass { get; set; }
            public string usu_token { get; set; }

        }

        public class ParametrosSalida
        {
            public int IDUsuario { get; set; }
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public string usu_email { get; set; }
            public string usu_nickname { get; set; }
            public string usu_telefono { get; set; }
            public string usu_imagen { get; set; }

        }

        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_RegisterUser");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_apellido_paterno", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_apellido_materno", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_nickname", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_telefono", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_pass", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_token", SqlDbType.VarChar);

                //Asignacion de valores a parametros
                comando.Parameters["@usu_nombre"].Value = Datos.usu_nombre;
                comando.Parameters["@usu_apellido_paterno"].Value = Datos.usu_apellido_paterno;
                comando.Parameters["@usu_apellido_materno"].Value = Datos.usu_apellido_materno;
                comando.Parameters["@usu_email"].Value = Datos.usu_email;
                comando.Parameters["@usu_nickname"].Value = Datos.usu_nickname;
                comando.Parameters["@usu_telefono"].Value = Datos.usu_telefono;
                comando.Parameters["@usu_pass"].Value = Datos.usu_pass;
                comando.Parameters["@usu_token"].Value = Datos.usu_token;

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

                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_telefono = Convert.ToString(row["usu_telefono"]),
                                usu_imagen = Convert.ToString(row["usu_imagen"]),

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
