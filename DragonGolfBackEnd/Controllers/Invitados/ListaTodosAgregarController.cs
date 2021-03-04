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
    [RoutePrefix("api/ListaTodosAgregar")]
    public class ListaTodosAgregarController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDUsuario { get; set; }

            public int IDRonda { get; set; }
    }
        public class ParametrosSalida
        {

            public int IDUsuario{ get; set; }
            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_nickname { get; set; }
            public string usu_imagen { get; set; }
            public decimal usu_handicapindex { get; set; }
            public string usu_ghinnumber { get; set; }
            public bool usu_invitado { get; set; }
            public string usu_email { get; set; }
            public string usu_telefono { get; set; }
            public int IDUsuarioCrea { get; set; }
            public decimal usu_golpesventaja { get; set; }
            public decimal usu_diferenciatee { get; set; }
        }


        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_ListAll_Ronda");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@IDUsuario"].Value = Datos.IDUsuario;
                comando.Parameters["@IDRonda"].Value = Datos.IDRonda;

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
                                usu_nombre = Convert.ToString(row["usu_nombre"]),
                                usu_apellido_paterno = Convert.ToString(row["usu_apellido_paterno"]),
                                usu_nickname = Convert.ToString(row["usu_nickname"]),
                                usu_imagen = Convert.ToString(row["usu_imagen"]),
                                usu_handicapindex = Convert.ToDecimal(row["usu_handicapindex"]),
                                usu_ghinnumber = numeroFormato,
                                usu_invitado = Convert.ToBoolean(row["usu_invitado"]),
                                usu_golpesventaja = Convert.ToDecimal(row["usu_golpesventaja"]),
                                usu_diferenciatee = Convert.ToDecimal(row["usu_diferenciatee"]),
                                IDUsuarioCrea = Convert.ToInt32(row["IDUsuarioCrea"]),
                                usu_email = Convert.ToString(row["usu_email"]),
                                usu_telefono = Convert.ToString(row["usu_telefono"]),
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
