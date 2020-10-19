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
    [RoutePrefix("api/AltaHoles")]
    public class AltaHolesController : ApiController
    {
        public class ParametrosEntradas
        {
            public string Ho_TeeName { get; set; }
            public int Ho_Hole { get; set; }
            public int Ho_Par { get; set; }
            public int Ho_Advantage { get; set; }
            public int Ho_Yards { get; set; }
            public int IDTees { get; set; }
        }
            public JObject Post(ParametrosEntradas Datos)
            {
                try
                {
                    SqlCommand comando = new SqlCommand("DragoGolf_InsertHoles");
                    comando.CommandType = CommandType.StoredProcedure;

                    //Declaracion de parametros
                    comando.Parameters.Add("@Ho_TeeName", SqlDbType.VarChar);
                    comando.Parameters.Add("@Ho_Hole", SqlDbType.Int);
                    comando.Parameters.Add("@Ho_Par", SqlDbType.Decimal);
                    comando.Parameters.Add("@Ho_Advantage", SqlDbType.VarChar);
                    comando.Parameters.Add("@Ho_Yards", SqlDbType.Int);
                    comando.Parameters.Add("@IDTees", SqlDbType.Int);

                    //Asignacion de valores a parametros
                    comando.Parameters["@Ho_TeeName"].Value = Datos.Ho_TeeName;
                    comando.Parameters["@Ho_Hole"].Value = Datos.Ho_Hole;
                    comando.Parameters["@Ho_Par"].Value = Datos.Ho_Par;
                    comando.Parameters["@Ho_Advantage"].Value = Datos.Ho_Advantage;
                    comando.Parameters["@Ho_Yards"].Value = Datos.Ho_Yards;
                    comando.Parameters["@IDTees"].Value = Datos.IDTees;


                    comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                    comando.CommandTimeout = 0;
                    comando.Connection.Open();

                    DataTable DT = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(comando);
                    comando.Connection.Close();
                    DA.Fill(DT);



                    string Mensaje = "";
                    int Estatus = 0;
                    int IDCourse = 0;

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
                            idcourse = IDCourse

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
