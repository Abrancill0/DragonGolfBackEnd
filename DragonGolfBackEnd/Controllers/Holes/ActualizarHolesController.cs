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
    [RoutePrefix("api/ActualizarHoles")]
    public class ActualizarHolesController : ApiController
    {
      

        public class ParametrosEntradas
        {
           //public int IDHoles { get; set; } 
            //public string Ho_TeeName { get; set; }
           // public int Ho_Hole { get; set; }
            //public int Ho_Par { get; set; }
            //public int Ho_Advantage { get; set; }
            //public int Ho_Yards { get; set; }
            public int IDTees { get; set; }
            public string[] Arreglo { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {

            try
            {

              
                string Arreglo1 = Datos.Arreglo[0].Replace("\"", "");
                string Arreglo2 = Arreglo1.Replace("[", "");
                string Arreglo3 = Arreglo2.Replace("]", "");

                string[] ArregloFinal = Arreglo3.Split('{');

                for (int i = 1; i < 19; i++)
                {
                    string ArregloSimple = ArregloFinal[i];

                    string EliminaParte1 = ArregloSimple.Replace("{", "");
                    string EliminaParte2 = EliminaParte1.Replace("},", "");

                    string[] Valores = EliminaParte2.Split(',');

                    int ID = Convert.ToInt32(Valores[0]);
                    int Par = Convert.ToInt32(Valores[2]);
                    int Adv = Convert.ToInt32(Valores[3]);
                    int yrds = Convert.ToInt32(Valores[4]);

                    SqlCommand comando = new SqlCommand("DragoGolf_UpdatetHoles");
                    comando.CommandType = CommandType.StoredProcedure;

                    //Declaracion de parametros
                    comando.Parameters.Add("@IDHoles", SqlDbType.Int);
                    //comando.Parameters.Add("@Ho_TeeName", SqlDbType.VarChar);
                    //comando.Parameters.Add("@Ho_Hole", SqlDbType.Int);
                    comando.Parameters.Add("@Ho_Par", SqlDbType.Int);
                    comando.Parameters.Add("@Ho_Advantage", SqlDbType.Int);
                    comando.Parameters.Add("@Ho_Yards", SqlDbType.Int);
                    comando.Parameters.Add("@IDTees", SqlDbType.Int);

                    //Asignacion de valores a parametros
                    comando.Parameters["@IDHoles"].Value = ID;// Datos.IDHoles;
                    //comando.Parameters["@Ho_TeeName"].Value = Datos.Ho_TeeName;
                    //comando.Parameters["@Ho_Hole"].Value = Datos.Ho_Hole;
                    comando.Parameters["@Ho_Par"].Value = Par;// Datos.Ho_Par;
                    comando.Parameters["@Ho_Advantage"].Value = Adv;// Datos.Ho_Advantage;
                    comando.Parameters["@Ho_Yards"].Value = yrds;// Datos.Ho_Yards;
                    comando.Parameters["@IDTees"].Value = Datos.IDTees;

                    comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                    comando.CommandTimeout = 0;
                    comando.Connection.Open();

                    DataTable DT = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(comando);
                    comando.Connection.Close();
                    DA.Fill(DT);

                }

                SqlCommand comando2 = new SqlCommand("DragoGolf_AupdateTeesTotal");
                comando2.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando2.Parameters.Add("@IDTees", SqlDbType.Int);

                //Asignacion de valores a parametros
                comando2.Parameters["@IDTees"].Value = Datos.IDTees;

                comando2.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando2.CommandTimeout = 0;
                comando2.Connection.Open();

                DataTable DT2 = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(comando2);
                comando2.Connection.Close();

                JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = "OK",
                        estatus = 1,
                      
                    });

                    return Resultado;
               
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
