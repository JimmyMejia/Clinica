using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Entidad
{
    public class Utileria
    {
        public static string Conexion()
        {
            string cnx = "Data Source= JIMMY-PC; database=Clinica; uid=sa; pwd=11294mpjr; connection lifetime=20; connection timeout=50";
            return cnx;
        }

        public class SendMail
        {
            string emisor;
            public string Emisor
            {
                get
                {
                    return emisor;
                }
                set
                {
                    emisor = value;
                }
            }
            string pwd;
            public string Pwd
            {
                get
                {
                    return pwd;
                }
                set
                {
                    pwd = value;
                }
            }
            //Constructor
            public SendMail(string de, string pass)
            {
                emisor = de;
                pwd = pass;
            }


            ///<summary>
            ///Se envía un correo electronico con texto simple
            ///</summary>
            ///<param name="destinatario">Quien escribe el correo</param>
            ///<param name="asunto">Asunto del correo</param>
            ///<param name="correo">Cuerpo del correo (contenido)</param>

            public string sendMail(string destinatario, string asunto, string cuerpo)
            {
                string resp = ""; //VARIABLE DE RETORNO
                try
                {
                    MailMessage msg = new MailMessage();
                    //Quien escribe al correo
                    msg.From = new MailAddress(emisor);
                    //A quien va dirigido
                    msg.To.Add(new MailAddress(destinatario));
                    //Asunto
                    msg.Subject = asunto;
                    //Contenido del correo
                    msg.Body = cuerpo;
                    //Servidor smtp de hotmail
                    SmtpClient clienteSmtp = new SmtpClient();
                    clienteSmtp.Host = "smtp.live.com";
                    clienteSmtp.Port = 25;//465; //25
                    clienteSmtp.EnableSsl = false;
                    clienteSmtp.UseDefaultCredentials = false;
                    //Se envia el correo
                    clienteSmtp.Credentials = new NetworkCredential(emisor, pwd);
                    clienteSmtp.EnableSsl = true;
                
                    clienteSmtp.Send(msg);
                    msg.Dispose(); //Liberamos memoria usada por el mensaje
                    resp = "Enviado";
                }
                catch (Exception err)
                {
                    resp = "Error al enviar el correo, " + err.Message;
                }
                return resp;
            }
        }


    }
  }
