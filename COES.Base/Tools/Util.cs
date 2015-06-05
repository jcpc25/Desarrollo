using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Base.Tools
{
    public class Util
    {
        /// <summary>
        /// Permite obtener el nombre del mes en base al número
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ObtenerNombreMesAbrev(int index)
        {
            string resultado = string.Empty;

            switch (index)
            {
                case 1:
                    resultado = "Ene";
                    break;
                case 2:
                    resultado = "Feb";
                    break;
                case 3:
                    resultado = "Mar";
                    break;
                case 4:
                    resultado = "Abr";
                    break;
                case 5:
                    resultado = "May";
                    break;
                case 6:
                    resultado = "Jun";
                    break;
                case 7:
                    resultado = "Jul";
                    break;
                case 8:
                    resultado = "Ago";
                    break;
                case 9:
                    resultado = "Set";
                    break;
                case 10:
                    resultado = "Oct";
                    break;
                case 11:
                    resultado = "Nov";
                    break;
                case 12:
                    resultado = "Dic";
                    break;
                default:
                    resultado = string.Empty;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Permite obtener el nombre del mes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ObtenerNombreMes(int index)
        {
            string resultado = string.Empty;

            switch (index)
            {
                case 1:
                    resultado = "ENERO";
                    break;
                case 2:
                    resultado = "FEBRERO";
                    break;
                case 3:
                    resultado = "MARZO";
                    break;
                case 4:
                    resultado = "ABRIL";
                    break;
                case 5:
                    resultado = "MAYO";
                    break;
                case 6:
                    resultado = "JUNIO";
                    break;
                case 7:
                    resultado = "JULIO";
                    break;
                case 8:
                    resultado = "AGOSTO";
                    break;
                case 9:
                    resultado = "SETIEMBRE";
                    break;
                case 10:
                    resultado = "OCTUBRE";
                    break;
                case 11:
                    resultado = "NOVIEMBRE";
                    break;
                case 12:
                    resultado = "DICIEMBRE";
                    break;
                default:
                    resultado = string.Empty;
                    break;
            }

            return resultado;
        }

        public static string ObtenerImagenExtension(string extension)
        {
            string image = string.Empty;
            switch (extension)
            {
                case "XLS":
                case "XLSX":
                    image = "excel.png";
                    break;
                case "DOC":
                case "DOCX":
                    image = "doc.png";
                    break;
                case "JPG":
                    image = "jpg.png";
                    break;
                case "PDF":
                    image = "pdf.png";
                    break;
            }
            return image;
        }

        public static int ObtenerNroSemanasxAnho(DateTime fecha)
        {
            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            
            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            //DateTime LastDay = new System.DateTime(anho, 12, 31);
            DateTime LastDay = fecha;
            int nroSemanas = myCal.GetWeekOfYear(LastDay, myCWR, myFirstDOW);
            
            //DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            //DateTime date1 = new DateTime(anho, 1, 31);
            //Calendar cal = dfi.Calendar;
            //int nroSemanas = cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            return nroSemanas;
        }

        public static string ObtenerMesAnho(DateTime medifecha)
        {
            string resultado = string.Empty;
            var f = medifecha;
            var anho = f.Year.ToString();
            var mes = f.Month;
            resultado = ObtenerNombreMes(mes) + " " + anho;

            return resultado;
        }

        //funcion que devuelve la fecha del primer dia de la fecha recibida  en formaro MM-YYYY
        public static DateTime FormatFecha(String fechaInicial)
        {
            DateTime dfecha = DateTime.MinValue;
            int mes = Int32.Parse(fechaInicial.Substring(0, 2));
            int anho = Int32.Parse(fechaInicial.Substring(3, 4));
            dfecha = new DateTime(anho, mes, 1);

            //if (fechaInicial != null)
            //{
            //    dfecha = DateTime.ParseExact(fechaInicial, Constantes.FormatoFecha, CultureInfo.InvariantCulture);
            //}           
            return dfecha;
        }

        //funcion que devuelve la fecha del primer dia de la semana ingresado como parametro y año respectivamente
        public static DateTime GenerarFecha(int year, int weekOfYear)
        {            
            DateTime jan1 = new DateTime(year, 1, 1); 
            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset); 
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstMonday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday); 
            var weekNum = weekOfYear; if (firstWeek <= 1) { weekNum -= 1; }
            var result = firstMonday.AddDays(weekNum * 7); 
            return result.AddDays(0);           
        }

        public static int GenerarNroSemana(DateTime fecha)
        {
            return ObtenerNroSemanasxAnho(fecha)-1;
        }
    }
}
