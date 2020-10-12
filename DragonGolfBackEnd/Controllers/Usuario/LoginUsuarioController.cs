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
    [RoutePrefix("api/LoginUsuario")]
    public class LoginUsuarioController : ApiController
    {
        public class ParametrosEntradas
        {
            public string Usuario { get; set; }
            public string Pass { get; set; }

        }

        public class ParametrosSalida
        {
            public int IDUsuario { get; set; }
            public string usu_nickname { get; set; }
            public string usu_email { get; set; }
            public string usu_pass { get; set; }
            public string usu_passalterno { get; set; }
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_apellido_materno { get; set; }
            public bool usu_olvido_contrasena { get; set; }

        }




        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_Login");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@Usuario", SqlDbType.VarChar);
                comando.Parameters.Add("@Pass", SqlDbType.VarChar);

                //Asignacion de valores a parametros
                comando.Parameters["@Usuario"].Value = Datos.Usuario;
                comando.Parameters["@Pass"].Value = Datos.Pass;

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
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_pass = Convert.ToString(row["usu_pass"]),
                                usu_passalterno = Convert.ToString(row["usu_passalterno"]),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                usu_olvido_contrasena = Convert.ToBoolean(row["usu_olvido_contrasena"]),
                            };

                            lista.Add(ent);
                        }
                        else if (Estatus == 2)
                        {

                            ParametrosSalida ent = new ParametrosSalida
                            {
                                IDUsuario = Convert.ToInt32(row["IDUsuario"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_pass = Convert.ToString(row["usu_pass"]),
                                usu_passalterno = Convert.ToString(row["usu_passalterno"]),
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_apellido_materno = Convert.ToString(row["usu_apellido_materno"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                usu_olvido_contrasena = Convert.ToBoolean(row["usu_olvido_contrasena"]),
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
                        Result = lista
                    });

                    return Resultado;
                }

            }
            catch (Exception ex)
            {

                List<ParametrosSalida> lista = new List<ParametrosSalida>();

                JObject Resultado = JObject.FromObject(new
                {
                    mensaje = ex.ToString(),
                    estatus = 0,
                    Result = lista
                });

                return Resultado; //JsonConvert.SerializeObject(lista);
            }
        }


    }
}
