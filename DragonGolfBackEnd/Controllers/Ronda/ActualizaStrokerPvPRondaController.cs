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
    [RoutePrefix("api/ActualizaStrokerPvPRonda")]
    public class ActualizaStrokerPvPRondaController : ApiController
    {
        public class ParametrosEntradas
        {
           public int IDRound { get; set; }
            public int Player1 { get; set; }
            public int Player2 { get; set; }
            public decimal stroker { get; set; }

        }
        public JObject Post(ParametrosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragoGolf_UpdateStokersPvP");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDRound", SqlDbType.Int);
                comando.Parameters.Add("@Player1", SqlDbType.Int);
                comando.Parameters.Add("@Player2", SqlDbType.Int);
                comando.Parameters.Add("@stroker", SqlDbType.Decimal);

                //Asignacion de valores a parametros
                comando.Parameters["@IDRound"].Value = Datos.IDRound;
                comando.Parameters["@Player1"].Value = Datos.Player1;
                comando.Parameters["@Player2"].Value = Datos.Player2;
                comando.Parameters["@stroker"].Value = Datos.stroker;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);

                string Mensaje = "";
                int Estatus = 0;
              
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
