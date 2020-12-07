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
using System.Threading.Tasks;
using Firebase.NET.Messages;
using Firebase.NET.Notifications;
using Firebase.NET;

namespace DragonGolfBackEnd.Controllers
{
    public class EnvioNotificacionController : ApiController
    {
        public class datos
        {
            public string usuario { get; set; }
            public string TokenID { get; set; }
            public string Titulo { get; set; }
            public string Mensaje { get; set; }

        }

        public async Task<string> Post(datos Datos)
        {
            try
            {
               
                int Pendientes = 0;

             

                if (Datos.TokenID != "")
                {
                    try
                    {
                        string[] ids = { Datos.TokenID };

                        var requestMessage = new RequestMessage
                        {
                            Body =
                { RegistrationIds = ids,
                  Notification = new CrossPlatformNotification
                { Title = Datos.Titulo,
                  Body = Datos.Mensaje,
                  Badge = Convert.ToString(Pendientes),
                  Sound = "true",
                 }
                }
                        };

                        var pushService = new PushNotificationService("AAAA9dcJEqs:APA91bFVWBmoaoUsbs9WX4sK5j9TXeg1VfXWo86YZ4xiT83HCjPso3VkcllOM4c2R6T_IUI3UgKeshqD5dAEuux0vDc2QvB19s57HOqFNHjZCcObO6Y6fOJe-hfBG6xqbdwFKWmUYN9F");
                         var responseMessage = await pushService.PushMessage(requestMessage);

                        return "Notificacion Enviada Exitosamente";

                    }
                    catch (Exception ex)
                    {

                        return ex.ToString();
                    }
                }
                else
                {
                    return "Usuario no cuenta con token asignado";
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }



        }


    }
}
