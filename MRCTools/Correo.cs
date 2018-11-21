using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using MRCTools;

namespace MRCTools
{
    public class Correo
    {
        string host = "smtp.1and1.mx";
        //string host = "smtp.gmail.com";        
        int port = 587; //Es el mismo para gmail y el que se usa aquí.
        NetworkCredential NW = new NetworkCredential("gestionvehicular@mrc.mx", "MrcGeVe2018");        

        public string EnviarCorreo(string destinatario, string mensaje, string asunto)
        {
            try
            {
                SmtpClient cliente = new SmtpClient();
                cliente.Host = host;
                cliente.Port = port;
                cliente.EnableSsl = true;
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = NW;
                MailAddress from = new MailAddress("gestionvehicular@mrc.mx", "Gestión Vehícular");
                MailAddress to = new MailAddress(destinatario);
                MailMessage mess = new MailMessage(from, to);                                
                mess.Body = mensaje;                                         
                mess.IsBodyHtml = true;
                mess.Subject = asunto;                

                cliente.Send(mess);
                mess.Dispose();
                return "OK";
            }
            catch (Exception e)
            {
                CapturaError CE = new CapturaError();
                CE.Log(e.Message + "Enviar Correo");
                return "Error";
            }
        }
    }
}
