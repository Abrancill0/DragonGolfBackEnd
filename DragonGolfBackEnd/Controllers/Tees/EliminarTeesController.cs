﻿using DragonGolfBackEnd.Clases;
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
    [RoutePrefix("api/EliminarTees")]
    public class EliminarTeesController : ApiController
    {
        public class ParametrosEntradas
        {
            public int IDTees { get; set; }
        
            public int IDCourse { get; set; }
        }
            public JObject Post(ParametrosEntradas Datos)
            {
                try
                {
                    SqlCommand comando = new SqlCommand("DragoGolf_DeleteTees");
                    comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                    comando.Parameters.Add("@IDTees", SqlDbType.Int);
                    comando.Parameters.Add("@IDCourse", SqlDbType.Int);

                //Asignacion de valores a parametros
                    comando.Parameters["@IDTees"].Value = Datos.IDTees;
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
