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
using System.Net.Mail;
namespace DragonGolfBackEnd.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/OlvideContrasena")]
    public class OlvideContrasenaController : ApiController
    {
        public class ParametrosSalida
        {
            public string Pass { get; set; }
        }

        public class DatosEntradas
        {
            public string usuario { get; set; }

        }

        public class ParametrosSalidaHTML
        {
            public bool status { get; set; }
            public string mensaje { get; set; }
        }

        public JObject Post(DatosEntradas Datos)
        {
            try
            {
                SqlCommand comando = new SqlCommand("DragonGolf_OlvideContrasena");
                comando.CommandType = CommandType.StoredProcedure;
                //Declaracion de parametros
                comando.Parameters.Add("@Usuario", SqlDbType.VarChar);

                //Asignacion de valores a parametros
                comando.Parameters["@Usuario"].Value = Datos.usuario;

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
                        Mensaje = Convert.ToString(row["Mensaje"]);
                        Estatus = Convert.ToInt32(row["Estatus"]);

                        if (Estatus == 1)
                        {
                            ParametrosSalida ent = new ParametrosSalida
                            {
                                Pass = Convert.ToString(row["Pass"]),
                            };

                            lista.Add(ent);

                            Enviar_correo_html(Datos.usuario, "Cambio de Contraseña", "La contraseña se restableció correctamente, su nueva contraseña es: " + Convert.ToString(row["Pass"]));
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

        public static List<ParametrosSalidaHTML> Enviar_correo_html(string CorreoCliente, string Asunto, string Contenido)
        {
            try
            {
                string htmlBody = Template_html(0);

                htmlBody = htmlBody.Replace("saludo_nombre", "");
                htmlBody = htmlBody.Replace("texto_contenido", Contenido);

                var fromAddress = new MailAddress("abrx23@gmail.com", "Dragon Golf");
                var toAddress = new MailAddress(CorreoCliente, "To Name");
                const string fromPassword = "elmasmejor123a";
                string subject = Asunto;
                const string body = "Body";

                // AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 50000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = htmlBody
                })
                {
                    smtp.Send(message);


                    List<ParametrosSalidaHTML> lista = new List<ParametrosSalidaHTML>();

                    ParametrosSalidaHTML ent = new ParametrosSalidaHTML
                    {
                        status = true,
                        mensaje = "OK"
                    };

                    lista.Add(ent);

                    return lista;

                }
            }
            catch (Exception ex)
            {
                List<ParametrosSalidaHTML> lista = new List<ParametrosSalidaHTML>();

                ParametrosSalidaHTML ent = new ParametrosSalidaHTML
                {
                    status = false,
                    mensaje = ex.ToString()
                };

                lista.Add(ent);

                return lista;
            }

        }


        public static string Template_html(int esRespaldo)
        {
            /*
             adminerp-notificaciones@elpotosi.com.mx
             Ham61041
             outlook.office365.com
             rConPuertoSMTP: 587
             */
            string htmlBody = "<!DOCTYPE html>" +
    "<html lang='en' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'>" +
    "<head><meta http-equiv='Content-Type' content='text/html; charset=gb18030'>" +
    "<meta http-equiv='x-ua-compatible' content='ie=edge'>" +
    "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
    "<meta name='x-apple-disable-message-reformatting'>" +
    "<title>Notificaciones</title>" +
    "<!--[if mso]>" +
    "<xml>" +
    "<o:OfficeDocumentSettings>" +
    "<o:AllowPNG/>" +
    "<o:PixelsPerInch>96</o:PixelsPerInch>" +
    "</o:OfficeDocumentSettings>" +
    "</xml>" +
    "<style>" +
    "table {border-collapse: collapse;}" +
    ".spacer,.divider {mso-line-height-rule:exactly;}" +
    "td,th,div,p,a {font-size: 13px; line-height: 22px;}" +
    "td,th,div,p,a,h1,h2,h3,h4,h5,h6 {font-family:'Segoe" +
    "UI',Helvetica,Arial,sans-serif;}" +
    "</style>" +
    "<![endif]-->" +
    "" +
    "<style type='text/css'>" +
    "" +
    "@import url('https://fonts.googleapis.com/css?family=Lato:300,400,700|Open+Sans');" +
    "@media only screen {" +
    ".col, td, th, div, p {font-family: 'Open Sans',-apple-system,system-ui,BlinkMacSystemFont,'Segoe" +
    "UI','Roboto','Helvetica Neue',Arial,sans-serif;}" +
    ".webfont {font-family: 'Lato',-apple-system,system-ui,BlinkMacSystemFont,'Segoe UI','Roboto','Helvetica Neue',Arial,sans-serif;}" +
    "}" +
    "" +
    "img {border: 0; line-height: 100%; vertical-align: middle;}" +
    "#outlook a, .links-inherit-color a {padding: 0; color: inherit;}" +
    ".col {font-size: 13px; line-height: 22px; vertical-align: top;}" +
    "" +
    ".hover-scale:hover {transform: scale(1.2);}" +
    ".star:hover a, .star:hover ~ .star a {color: #FFCF0F!important;}" +
    "" +
    "@media only screen and (max-width: 600px) {" +
    "u ~ div .wrapper {min-width: 100vw;}" +
    ".wrapper img {height: auto!important;}" +
    ".container {width: 100%!important; -webkit-text-size-adjust: 100%;}" +
    "}" +
    "" +
    "@media only screen and (max-width: 480px) {" +
    ".col {" +
    "box-sizing: border-box;" +
    "display: inline-block!important;" +
    "line-height: 20px;" +
    "width: 100%!important;" +
    "}" +
    ".col-sm-1 {max-width: 25%;}" +
    ".col-sm-2 {max-width: 50%;}" +
    ".col-sm-3 {max-width: 75%;}" +
    ".col-sm-third {max-width: 33.33333%;}" +
    ".col-sm-auto {width: auto!important;}" +
    ".col-sm-push-1 {margin-left: 25%;}" +
    ".col-sm-push-2 {margin-left: 50%;}" +
    ".col-sm-push-3 {margin-left: 75%;}" +
    ".col-sm-push-third {margin-left: 33.33333%;}" +
    "" +
    ".full-width-sm {display: table!important; width: 100%!important;}" +
    ".stack-sm-first {display: table-header-group!important;}" +
    ".stack-sm-last {display: table-footer-group!important;}" +
    ".stack-sm-top {display: table-caption!important; max-width: 100%;" +
    "padding-left: 0!important;}" +
    "" +
    ".toggle-content {" +
    "max-height: 0;" +
    "overflow: auto;" +
    "transition: max-height .4s linear;" +
    "-webkit-transition: max-height .4s linear;" +
    "}" +
    ".toggle-trigger:hover + .toggle-content," +
    ".toggle-content:hover {max-height: 999px!important;}" +
    "" +
    ".show-sm {" +
    "display: inherit!important;" +
    "font-size: inherit!important;" +
    "line-height: inherit!important;" +
    "max-height: none!important;" +
    "}" +
    ".hide-sm {display: none!important;}" +
    "" +
    ".align-sm-center {" +
    "display: table!important;" +
    "float: none;" +
    "margin-left: auto!important;" +
    "margin-right: auto!important;" +
    "}" +
    ".align-sm-left {float: left;}" +
    ".align-sm-right {float: right;}" +
    "" +
    ".text-sm-center {text-align: center!important;}" +
    ".text-sm-left {text-align: left!important;}" +
    ".text-sm-right {text-align: right!important;}" +
    "" +
    ".nav-sm-vertical .nav-item {display: block!important;}" +
    ".nav-sm-vertical .nav-item a {display: inline-block; padding: 5px 0!important;}" +
    "" +
    ".h1 {font-size: 32px !important;}" +
    ".h2 {font-size: 24px !important;}" +
    ".h3 {font-size: 16px !important;}" +
    "" +
    ".borderless-sm {border: none!important;}" +
    ".height-sm-auto {height: auto!important;}" +
    ".line-height-sm-0 {line-height: 0!important;}" +
    ".overlay-sm-bg {background: #232323; background: rgba(0,0,0,0.4);}" +
    "" +
    ".p-sm-0 {padding: 0!important;}" +
    ".p-sm-8 {padding: 8px!important;}" +
    ".p-sm-16 {padding: 16px!important;}" +
    ".p-sm-24 {padding: 24px!important;}" +
    ".pt-sm-0 {padding-top: 0!important;}" +
    ".pt-sm-8 {padding-top: 8px!important;}" +
    ".pt-sm-16 {padding-top: 16px!important;}" +
    ".pt-sm-24 {padding-top: 24px!important;}" +
    ".pr-sm-0 {padding-right: 0!important;}" +
    ".pr-sm-8 {padding-right: 8px!important;}" +
    ".pr-sm-16 {padding-right: 16px!important;}" +
    ".pr-sm-24 {padding-right: 24px!important;}" +
    ".pb-sm-0 {padding-bottom: 0!important;}" +
    ".pb-sm-8 {padding-bottom: 8px!important;}" +
    ".pb-sm-16 {padding-bottom: 16px!important;}" +
    ".pb-sm-24 {padding-bottom: 24px!important;}" +
    ".pl-sm-0 {padding-left: 0!important;}" +
    ".pl-sm-8 {padding-left: 8px!important;}" +
    ".pl-sm-16 {padding-left: 16px!important;}" +
    ".pl-sm-24 {padding-left: 24px!important;}" +
    ".px-sm-0 {padding-right: 0!important; padding-left: 0!important;}" +
    ".px-sm-8 {padding-right: 8px!important; padding-left: 8px!important;}" +
    ".px-sm-16 {padding-right: 16px!important; padding-left: 16px!important;}" +
    ".px-sm-24 {padding-right: 24px!important; padding-left: 24px!important;}" +
    ".py-sm-0 {padding-top: 0!important; padding-bottom: 0!important;}" +
    ".py-sm-8 {padding-top: 8px!important; padding-bottom: 8px!important;}" +
    ".py-sm-16 {padding-top: 16px!important; padding-bottom: 16px!important;}" +
    ".py-sm-24 {padding-top: 24px!important; padding-bottom: 24px!important;}" +
    "}" +
    "</style>" +
    "</head>" +
    "<body style='box-sizing:border-box;margin:0;padding:0;width:100%;word-break:break-word;-webkit-font-smoothing:antialiased;'>" +
    "" +
    "<div style='display:none;font-size:0;line-height:0;'><!-- Add your inbox preview text here --></div>" +
    "" +
    "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td class='px-sm-16' align='center' bgcolor='#EEEEEE'>" +
    "<table class='container' cellpadding='0' cellspacing='0' role='presentation' width='600'>" +
    "<tr>" +
    "<td class='px-sm-8' align='left' bgcolor='#EEEEEE'>" +
    "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
    "<table cellpadding='0' cellspacing='0' role='presentation' style='margin: 0 auto;'>" +
    "<tr>" +
    "<td class='col' align='center'>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "" +
    "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td align='center' bgcolor='#EEEEEE' class='px-sm-16'>" +
    "<table class='container' cellpadding='0' cellspacing='0' role='presentation' width='600'>" +
    "<tr>" +
    "<td bgcolor='#f2f2f2' style='background: linear-gradient(to right, #f2f2f2, #f2f2f2);'>" +
    "<!--[if gte mso 9]>" +
    "<v:rect xmlns:v='urn:schemas-microsoft-com:vml' fill='true'" +
    "stroke='false' style='width:600px;'>" +
    "<v:fill type='gradient' color='#f2f2f2' color2='#f2f2f2' angle='90' />" +
    "<v:textbox style='mso-fit-shape-to-text:true' inset='0,0,0,0'>" +
    "<div><![endif]-->" +
    "<div class='spacer line-height-sm-0 py-sm-16' style='line-height: 32px;'>&zwnj;</div>" +
    "<table cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td align='center' class='px-sm-16' style='padding: 0 96px;'>" +
    "<h1 class='webfont h1' style='color: #FFFFFF; font-size: 36px;" +
    "font-weight: 300; line-height: 100%; margin: 0;'>" +
    "<a href='link_webpage'>" +
            "<img src='http://drive.google.com/uc?export=view&id=1mFEeISOkXsm6hfVFIS4nrK6NBxZV95qI' alt='Gobierno Municipal' width='170px' height='70px' style='width:170px; height: 70px;'>" +
    "</a>" +
    "</h1>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "<div class='spacer line-height-sm-0 py-sm-16' style='line-height: 40px;'>&zwnj;</div>" +
    "<!--[if gte mso 9]></div></v:textbox></v:rect><![endif]-->" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "" +
    "<table class='wrapper' cellpadding='0' cellspacing='0'" +
    "role='presentation' width='100%'>" +
    "<tr>" +
    "<td class='px-sm-16' align='center' bgcolor='#EEEEEE'>" +
    "<table class='container' cellpadding='0' cellspacing='0'" +
    "role='presentation' width='600'>" +
    "<tr>" +
    "<td class='px-sm-8' align='left' bgcolor='#FFFFFF' style='padding: 0 24px;'>" +
    "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
    "<table cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td class='col px-sm-16' align='center' width='100%' style='padding: 0 64px;'>" +
    "<h2 style='color: #000; font-size: 20px; font-weight: 300; line-height: 28px; margin: 0 0 24px;'>" +
    "saludo_nombre" +
    "</h2>" +
    "<p style='color: #888888; font-size: 18px; line-height: 24px; margin: 0;'>" +
    "texto_contenido" +
    "</p>" +
    "<div class='spacer' style='line-height: 32px;'>&zwnj;</div>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "" +
    "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td class='px-sm-16' align='center' bgcolor='#EEEEEE'>" +
    "<table class='container' cellpadding='0' cellspacing='0' role='presentation' width='600'>" +
    "<tr>" +
    "<td class='divider py-sm-16 px-sm-16' bgcolor='#FFFFFF' style='padding: 24px 32px;'>" +
    "<div style='background: #EEEEEE; height: 1px; line-height: 1px;'>&zwnj;</div>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "" +
    "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td class='px-sm-16' align='center' bgcolor='#EEEEEE'>" +
    "<table class='container' cellpadding='0' cellspacing='0' role='presentation' width='600'>" +
    "<tr>" +
    "<td class='px-sm-8' bgcolor='#FFFFFF' style='padding: 0 24px;'>" +
    "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
    "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "" +
    "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
    "<tr>" +
    "<td class='px-sm-16' align='center' bgcolor='#EEEEEE'>" +
    "<table class='container' cellpadding='0' cellspacing='0' role='presentation' width='600'>" +
    "<tr>" +
    "<td class='spacer height-sm-auto py-sm-8' bgcolor='#EEEEEE' height='24'></td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>";
            if (esRespaldo == 1)
            {
                htmlBody += "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
            "<tr>" +
            "<td class='px-sm-8' bgcolor='#EEEEEE' style='padding: 0 24px;'>" +
            "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
            "<table cellpadding = '0' cellspacing='0' role='presentation' width='100%'>" +
            "<tr>" +
            "<td class='col' align='center' width='100%' style='padding: 0 8px;'>" +
            "<p style = 'color: #888888; margin: 0; font-weight: bold;' > " +
            "Correo de respaldo." +
            "</p>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
            "</td>" +
            "</tr>" +
            "</table>";
            }

            htmlBody += "<table class='wrapper' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
                "<tr>" +
                "<td class='px-sm-8' bgcolor='#EEEEEE' style='padding: 0 24px;'>" +
                "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
                "<table cellpadding = '0' cellspacing='0' role='presentation' width='100%'>" +
                "<tr>" +
                "<td class='col' align='center' width='100%' style='padding: 0 8px;'>" +
                "<p style = 'color: #888888; margin: 0; font-weight: bold;' > " +
                "No responder este e-mail, es un envío automático" +
                "</p>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "<div class='spacer line-height-sm-0 py-sm-8' style='line-height: 24px;'>&zwnj;</div>" +
                "</td>" +
                "</tr>" +
                "</table>";


            htmlBody += "</body>" +
    "</html>";

            return htmlBody;


        }
    }
}
