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
    [RoutePrefix("api/AltaTees")]
    public class AltaTeesController : ApiController
    {
        public class ParametrosEntradas
        {

            public string Te_TeeName { get; set; }
            public int Te_Slope { get; set; }
            public decimal Te_Rating { get; set; }
            public string Te_TeeColor { get; set; }
            public int Te_In { get; set; }
            public int Te_Out { get; set; }
            public int Te_Total { get; set; }
            public int IDCourse { get; set; }
        }
            public JObject Post(ParametrosEntradas Datos)
            {
                try
                {
                    SqlCommand comando = new SqlCommand("DragoGolf_InsertTees");
                    comando.CommandType = CommandType.StoredProcedure;

                    //Declaracion de parametros
                    comando.Parameters.Add("@Te_TeeName", SqlDbType.VarChar);
                    comando.Parameters.Add("@Te_Slope", SqlDbType.Int);
                    comando.Parameters.Add("@Te_Rating", SqlDbType.Decimal);
                    comando.Parameters.Add("@Te_TeeColor", SqlDbType.VarChar);
                    comando.Parameters.Add("@Te_In", SqlDbType.Int);
                    comando.Parameters.Add("@Te_Out", SqlDbType.Int);
                    comando.Parameters.Add("@Te_Total", SqlDbType.Int);
                    comando.Parameters.Add("@IDCourse", SqlDbType.Int);

                    //Asignacion de valores a parametros
                    comando.Parameters["@Te_TeeName"].Value = Datos.Te_TeeName;
                    comando.Parameters["@Te_Slope"].Value = Datos.Te_Slope;
                    comando.Parameters["@Te_Rating"].Value = Datos.Te_Rating;
                    comando.Parameters["@Te_TeeColor"].Value = Datos.Te_TeeColor;
                    comando.Parameters["@Te_In"].Value = Datos.Te_In;
                    comando.Parameters["@Te_Out"].Value = Datos.Te_Out;
                    comando.Parameters["@Te_Total"].Value = Datos.Te_Total;
                    comando.Parameters["@IDCourse"].Value = Datos.IDCourse;


                    comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                    comando.CommandTimeout = 0;
                    comando.Connection.Open();

                    DataTable DT = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(comando);
                    comando.Connection.Close();
                    DA.Fill(DT);



                    string Mensaje = "";
                    int Estatus = 0;
                    int IDTees = 0;

                    int contador = DT.Rows.Count;

                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow row in DT.Rows)
                        {
                            Mensaje = Convert.ToString(row["mensaje"]);
                            Estatus = Convert.ToInt32(row["Estatus"]);
                        IDTees = Convert.ToInt32(row["IDTees"]);
                    }

                        JObject Resultado = JObject.FromObject(new
                        {
                            mensaje = Mensaje,
                            estatus = Estatus,
                            idtees = IDTees
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
