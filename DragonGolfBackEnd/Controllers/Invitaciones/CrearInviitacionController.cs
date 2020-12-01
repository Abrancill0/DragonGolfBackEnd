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
    [RoutePrefix("api/CrearInvitacion")]
    public class CrearInvitacionController : ApiController
    {
        public class ParametrosEntradas
        {

            public int IDUsuarioEmisor { get; set; }
            public int IDUsuarioReceptor { get; set; }
            public int IDRonda { get; set; }
        }

      
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_Createinvitation");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuarioEmisor", SqlDbType.Int);
                comando.Parameters.Add("@IDUsuarioReceptor", SqlDbType.Int);
                comando.Parameters.Add("@IDRonda", SqlDbType.Int);
               
                //Asignacion de valores a parametros
                comando.Parameters["@IDUsuarioEmisor"].Value = Datos.IDUsuarioEmisor;
                comando.Parameters["@IDUsuarioReceptor"].Value = Datos.IDUsuarioReceptor;
                comando.Parameters["@IDRonda"].Value = Datos.IDRonda;

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
