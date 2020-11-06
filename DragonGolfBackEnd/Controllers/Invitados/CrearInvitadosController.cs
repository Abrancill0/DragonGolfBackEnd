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
    [RoutePrefix("api/CrearInvitados")]
    public class CrearInvitadosController : ApiController
    {
        public class ParametrosEntradas
        {

            public string usu_nombre { get; set; }
            public string usu_apellido_paterno { get; set; }
            public string usu_nickname { get; set; }
            public decimal usu_handicapindex { get; set; }
            public string usu_ghinnumber { get; set; }
            public int usu_golpesventaja { get; set; }
            public int usu_diferenciatee { get; set; }
            public int IDUsuarioCrea { get; set; }
        }

      
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_CreateGuest");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_apellido_paterno", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_nickname", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_handicapindex", SqlDbType.Decimal);
                comando.Parameters.Add("@usu_ghinnumber", SqlDbType.VarChar);
                comando.Parameters.Add("@usu_golpesventaja", SqlDbType.Int);
                comando.Parameters.Add("@usu_diferenciatee", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuarioCrea", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando.Parameters["@usu_nombre"].Value = Datos.usu_nombre;
                comando.Parameters["@usu_apellido_paterno"].Value = Datos.usu_apellido_paterno;
                comando.Parameters["@usu_nickname"].Value = Datos.usu_nickname;
                comando.Parameters["@usu_handicapindex"].Value = Datos.usu_handicapindex;
                comando.Parameters["@usu_ghinnumber"].Value = Datos.usu_ghinnumber;
                comando.Parameters["@usu_golpesventaja"].Value = Datos.usu_golpesventaja;
                comando.Parameters["@usu_diferenciatee"].Value = Datos.usu_diferenciatee;
                comando.Parameters["@IDUsuarioCrea"].Value = Datos.IDUsuarioCrea;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);

               
                string Mensaje = "";
                int Estatus = 0;
                int IDUsuario = 0;

                int contador = DT.Rows.Count;

                if (DT.Rows.Count > 0)
                {


                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
                        IDUsuario = Convert.ToInt32(row["IDUsuario"]);
                    }

                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,
                        idusuario= IDUsuario

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
