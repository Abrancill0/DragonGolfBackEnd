using DragonGolfBackEnd.Clases;
using System.Web.Http;
using DragonGolfBackEnd.Extensions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.Web;
using System;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DragonGolfBackEnd.Controllers
{
    public class SubirImagenUsuarioController : ApiController
    {
        [HttpPost]
        public async Task<JObject> UploadFile2(HttpRequestMessage request)
        {
            try
            {
                if (!request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var httpRequest = HttpContext.Current.Request;
                var httpRequestserver = HttpContext.Current.Server;

                var data = await Request.Content.ParseMultipartAsync();

                string Mensaje = "";
                int Estatus = 0;

                string IDUsuario = data.Fields["IDUsuario"].Value;


                if (data.Files.ContainsKey("file"))
                {
                    Dictionary<string, object> dict = new Dictionary<string, object>();

                    foreach (string file in httpRequest.Files)
                    {
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                        var postedFile = httpRequest.Files[file];
                        if (postedFile != null && postedFile.ContentLength > 0)
                        {

                            int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB  

                            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".jpeg" };
                            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                            var extension = ext.ToLower();
                            if (!AllowedFileExtensions.Contains(extension))
                            {

                                var message = string.Format("Por favor subir imagen de tipo .jpg,.gif,.png.,jpeg");

                            }
                            else if (postedFile.ContentLength > MaxContentLength)
                            {

                                var message = string.Format("Solo se adminen imagenes iguales o menores a 5 mb.");

                                //  dict.Add("error", message);
                                //  return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                            }
                            else
                            {
                                string Ruta = "";
                                string pathToCreate = "~/images/";
                                if (Directory.Exists(httpRequestserver.MapPath(pathToCreate)))
                                {
                                    Ruta = "~/images/" + IDUsuario + extension;

                                    var filePath = httpRequestserver.MapPath("~/images/" + IDUsuario + extension);

                                    postedFile.SaveAs(filePath);

                                    Mensaje = "OK";
                                    Estatus = 1;

                                    ActualizaRuta(IDUsuario, extension);

                                }
                                else
                                {
                                    Directory.CreateDirectory(httpRequestserver.MapPath(pathToCreate));

                                    // Ruta = "imagesbaja/" + ClaveBien + "/" + ClaveBien + "_" + ConsecutivoBien + extension;
                                    var filePath = httpRequestserver.MapPath("~/images/" + IDUsuario + extension);

                                    postedFile.SaveAs(filePath);

                                    Mensaje = "OK";
                                    Estatus = 1;

                                    ActualizaRuta(IDUsuario, extension);
                                }
                            }
                        }
                    }

                }

                JObject Resultado = JObject.FromObject(new
                {
                    mensaje = Mensaje,
                    estatus = Estatus,

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

                return Resultado;
            }
        }

        private string ActualizaRuta(string IDUsuario, string extension)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragonGolf_Subir_Imagen_Usuario");
                comando.CommandType = CommandType.StoredProcedure;

                //Declaracion de parametros
                comando.Parameters.Add("@IDUsuario", SqlDbType.Int);
                comando.Parameters.Add("@extension", SqlDbType.VarChar);

             
                comando.Parameters["@IDUsuario"].Value = IDUsuario;
                comando.Parameters["@extension"].Value = extension;

                comando.Connection = new SqlConnection(VariablesGlobales.CadenaConexion);
                comando.CommandTimeout = 0;
                comando.Connection.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(comando);
                comando.Connection.Close();
                DA.Fill(DT);

                string Mensaje = "";
                string RutaImagen = "";
                int Estatus = 0;

                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        Mensaje = Convert.ToString(row["mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);
                        RutaImagen = Convert.ToString(row["RutaImagen"]);
                    }

                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,

                    });

                    return "OK";
                }
                else
                {
                    JObject Resultado = JObject.FromObject(new
                    {
                        mensaje = Mensaje,
                        estatus = Estatus,

                    });

                    return "Error";
                }

            }
            catch (Exception ex)
            {

                JObject Resultado = JObject.FromObject(new
                {
                    mensaje = ex.ToString(),
                    estatus = 0,

                });

                return "Error";
            }
        }

    }
}

