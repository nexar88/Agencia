using MSCaptcha;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Comun
{
    public static class Funciones
    {

        /// Encripta una cadena
        public static string EncriptarTexto(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptarTexto(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        //public static Image Base64ToImage(string contenido)
        //{
        //    // Convert Base64 String to byte[]
        //    String[] foto1 = contenido.Split(',');
        //    byte[] imageBytes = Convert.FromBase64String(foto1[1]);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}
        public static int CalcularEdad(DateTime FechaNacimiento)
        {
            int year = DateTime.Now.Year - FechaNacimiento.Year;
            int month = DateTime.Now.Month - FechaNacimiento.Month;
            int day = DateTime.Now.Day - FechaNacimiento.Day;
            if (month < 0)
            {
                return year - 1;
            }
            else if (month == 0)
            {
                return day <= 0 ? year : year - 1;
            }
            else
            {
                return year;
            }
        }

        public static string sIdTipoConsultaRapida = "Q";
        public static string sIdTipoConsultaNormal = "N";

        public static Boolean EsFecha(string fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                // Verificar formato dd/mm/yyyy
                if (!(fecha.Length == 10))
                {
                    return false;
                }
                if (!(fecha.Contains("/")))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int ObtenerEdad(DateTime fechaNacimiento)
        {

            DateTime fechaActual = DateTime.Today;
            int edad;
            edad = fechaActual.Year - fechaNacimiento.Year;

            if (edad > 0)
            {

                edad -= Convert.ToInt32(fechaActual.Date < fechaNacimiento.Date.AddYears(edad));

            }
            else
            {

                edad = 0;

            }

            return edad;

        }

        public static bool ValidarEdad(DateTime dFecNacimiento, int nEdad, string sTipo)
        {

            bool validar = false;

            DateTime dFechaActual = DateTime.Today;

            int dAnio = dFechaActual.Year - dFecNacimiento.Year;

            if (sTipo == "<")
            {

                if (dAnio < nEdad)
                {

                    validar = true;

                }
                else if (dAnio == nEdad)
                {

                    int dMes = dFechaActual.Month - dFecNacimiento.Month;

                    if (dMes < 0)
                    {

                        validar = true;

                    }
                    else if (dMes == 0)
                    {

                        int dDia = dFechaActual.Day - dFecNacimiento.Day;

                        if (dDia < 0)
                        {

                            validar = true;

                        }
                        else
                        {

                            validar = false;

                        }

                    }
                    else
                    {

                        validar = false;

                    }

                }
                else
                {

                    validar = false;

                }

            }
            else if (sTipo == ">")
            {

                if (dAnio < nEdad)
                {

                    validar = false;

                }
                else if (dAnio == nEdad)
                {

                    int dMes = dFechaActual.Month - dFecNacimiento.Month;

                    if (dMes < 0)
                    {

                        validar = false;

                    }
                    else if (dMes == 0)
                    {

                        int dDia = dFechaActual.Day - dFecNacimiento.Day;

                        if (dDia < 0)
                        {

                            validar = false;

                        }
                        else
                        {

                            validar = true;

                        }

                    }
                    else
                    {

                        validar = true;

                    }

                }
                else
                {

                    validar = true;

                }

            }

            return validar;

        }


        public static bool EsMenorEdad(DateTime dFechaNacimiento)
        {

            //int edad = ObtenerEdad(fechaNacimiento);
            //bool respuesta = (edad < 18) ? true : false;

            int nEdadMenor = 18;
            string sTipoMenor = "<";

            bool respuesta = ValidarEdad(dFechaNacimiento, nEdadMenor, sTipoMenor);

            return respuesta;

        }

        public static bool ExoneraRecibo(DateTime dFechaNacimiento)
        {

            //int edad = ObtenerEdad(fechaNacimiento);
            //bool respuesta = (edad < 18 || edad > 60) ? true : false;

            int nEdadMenor = 18;
            string sTipoMenor = "<";

            int nEdadMayor = 60;
            string sTipoMayor = ">";

            bool resMenor = ValidarEdad(dFechaNacimiento, nEdadMenor, sTipoMenor);
            bool resMayor = ValidarEdad(dFechaNacimiento, nEdadMayor, sTipoMayor);

            bool respuesta = (resMenor || resMayor) ? true : false;

            return respuesta;

        }

        public static string FormatoFecha(string sFecha, string formato)
        {
            string diaFormato = sFecha;

            string[] aFecha = sFecha.Split('/');
            if (formato.Equals("dd/MM"))
            {
                diaFormato = aFecha[0] + "/" + aFecha[1];
            }
            return diaFormato;
        }

        public static DateTime DevuelvePrimerDiaSemana(DateTime fecha)
        {
            DateTime dFechaUno = fecha.Date;
            DayOfWeek dia = fecha.Date.DayOfWeek;
            int nDia = (int)dia + 1;
            dFechaUno = dFechaUno.AddDays(-nDia);
            return dFechaUno;
        }

        public static string Disponible(int valorHora, string valorData, DateTime fechaHoy, DateTime fechaHorario)
        {

            string valor = valorData;

            double hora_server = DateTime.Now.Hour;

            if (fechaHoy <= fechaHorario)
            {
                if (fechaHorario == fechaHoy)
                {
                    if (valorHora < hora_server)
                    {
                        valor = "3";
                    }
                }
            }
            else
            {
                valor = "3";
            }

            return valor;
        }

        public static List<Dia> Semana()
        {
            List<Dia> semana = new List<Dia>();
            Dia dia;
            dia = new Dia(); dia.abreviaturaDia = "LU"; dia.descripcionDia = "LUNES"; semana.Add(dia);
            dia = new Dia(); dia.abreviaturaDia = "MA"; dia.descripcionDia = "MARTES"; semana.Add(dia);
            dia = new Dia(); dia.abreviaturaDia = "MI"; dia.descripcionDia = "MIERCOLES"; semana.Add(dia);
            dia = new Dia(); dia.abreviaturaDia = "JU"; dia.descripcionDia = "JUEVES"; semana.Add(dia);
            dia = new Dia(); dia.abreviaturaDia = "VI"; dia.descripcionDia = "VIERNES"; semana.Add(dia);
            dia = new Dia(); dia.abreviaturaDia = "SA"; dia.descripcionDia = "SABADO"; semana.Add(dia);
            return semana;
        }

        public static Boolean EnvioCorreoElectronico(string sDirCorElectronico, string sTitulo, string sCuerpo, ref LinkedResource logo)
        {

            string sServidorSMTP = System.Configuration.ConfigurationManager.AppSettings["Em_host"];
            string sPuerto = System.Configuration.ConfigurationManager.AppSettings["Em_puerto"];

            string sUsuarioSMTP = System.Configuration.ConfigurationManager.AppSettings["Em_email"];
            string sClaveSMTP = System.Configuration.ConfigurationManager.AppSettings["Em_pass"];

            string sDirRemitente = System.Configuration.ConfigurationManager.AppSettings["Em_email"];
            string sNomRemitente = System.Configuration.ConfigurationManager.AppSettings["Em_email_name"];

            int nPuerto = Int32.Parse(sPuerto);

            Boolean resEnvioMail = EnviarCorreoElectronico(sServidorSMTP, nPuerto, sUsuarioSMTP, sClaveSMTP, sDirRemitente, sNomRemitente, sDirCorElectronico, sTitulo, sCuerpo, logo, 0);

            return resEnvioMail;

        }

        public static void GenerarMensaje(string sTipoMensaje, string sMensaje, Label lblEtiqueta)
        {

            string strInicioDiv = null;

            string strInicioTxt = "<div class='font-in-h12'><strong>";

            string strFinalTxt = "</strong></div>";

            string strFinalDiv = "</div>";

            StringBuilder strMensajeBuilder = new StringBuilder();

            if (sTipoMensaje.Equals("A"))
            {

                strInicioDiv = "<br /><div class='alert alert-danger'>";

            }
            else if (sTipoMensaje.Equals("E"))
            {

                strInicioDiv = "<br /><div class='alert alert-success'>";

            }

            strMensajeBuilder.Append(strInicioDiv);
            strMensajeBuilder.Append(strInicioTxt);
            strMensajeBuilder.Append(sMensaje);
            strMensajeBuilder.Append(strFinalTxt);
            strMensajeBuilder.Append(strFinalDiv);

            lblEtiqueta.Text = strMensajeBuilder.ToString();
            lblEtiqueta.Visible = true;

        }

        public static bool EsCaptcha(CaptchaControl cc, string valor)
        {

            cc.ValidateCaptcha(valor);

            if (!cc.UserValidated)
            {
                return false;
            }

            return true;

        }

        private static Boolean EnviarCorreoElectronico(string sServidorSMTP, int nPuerto, string sUsuarioSMTP, string sClaveSMTP, string sDirRemitente, string sNomRemitente, string sDirDestinatario, string sTitulo, string sCuerpo, LinkedResource logo, int nIntentos)
        {

            try
            {

                SmtpClient objSmtp;

                objSmtp = new SmtpClient(sServidorSMTP, nPuerto);
                objSmtp.UseDefaultCredentials = false;
                objSmtp.Credentials = new NetworkCredential(sUsuarioSMTP, sClaveSMTP);

                MailMessage objMail = new MailMessage();

                objMail.From = new MailAddress(sDirRemitente, sNomRemitente);
                objMail.To.Add(new MailAddress(sDirDestinatario));

                objMail.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay;

                objMail.Subject = sTitulo;

                objMail.BodyEncoding = System.Text.Encoding.UTF8;

                var vistaHtml = AlternateView.CreateAlternateViewFromString(sCuerpo, Encoding.UTF8, MediaTypeNames.Text.Html);

                vistaHtml.LinkedResources.Add(logo);

                objMail.AlternateViews.Add(vistaHtml);

                objSmtp.Timeout = 10000;
                objSmtp.EnableSsl = false;
                objSmtp.Send(objMail);

                return true;

            }
            catch (Exception)
            {

                //WriteEventLogEntry("Ocurrio el siguiente error: " + ex.Message + " - envio incorrecto: " + str_destinatario);
                //return false;

                if (nIntentos < 3)
                {

                    nIntentos++;
                    return EnviarCorreoElectronico(sServidorSMTP, nPuerto, sUsuarioSMTP, sClaveSMTP, sDirRemitente, sNomRemitente, sDirDestinatario, sTitulo, sCuerpo, logo, nIntentos);

                }
                else
                {

                    return false;

                }

            }

        }

        public static void WriteEventLogEntry(string message)
        {
            // Create an instance of EventLog
            System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

            // Check if the event source exists. If not create it.
            if (!System.Diagnostics.EventLog.SourceExists("Aplicacion Envio Correo - CRM"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Aplicacion Envio Correo - CRM", "Application");
            }

            // Set the source name for writing log entries.
            eventLog.Source = "Aplicacion Envio Correo - CRM";

            // Create an event ID to add to the event log
            int eventID = 8;

            // Write an entry to the event log.
            eventLog.WriteEntry(message, System.Diagnostics.EventLogEntryType.Error, eventID);

            // Close the Event Log
            eventLog.Close();

        }

        public static void writeLog(string title, string valor1, string valor2)
        {
            string filePath = ConfigurationManager.AppSettings["Log"];
            string fic = Path.Combine(filePath, "Log.txt");
            string texto = title + " : Time : " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + ":" + System.DateTime.Now.Millisecond;

            if (!File.Exists(filePath)) Directory.CreateDirectory(filePath);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.Write(texto + "\r\n");
            sw.Write(valor1.Trim() + "X" + "\r\n");
            sw.Write(valor2.Trim() + "X" + "\r\n");
            sw.Close();
        }


    }

    public class Dia : Mes
    {
        public string codigoDia { get; set; }
        public string descripcionDia { get; set; }
        public string abreviaturaDia { get; set; }
    }

    public class Mes : Anio
    {
        public string codigoMes { get; set; }
        public string descMes { get; set; }
    }

    public class Anio
    {
        public string codigoAnio { get; set; }
    }

}
