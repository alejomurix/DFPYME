namespace Utilities
{
    /// <summary>
    /// Representa una clase para el tratamiento de atributos de fecha.
    /// </summary>
    public class UseDate
    {
        /// <summary>
        /// Obtiene un System.DateTime con la hora establecida 12 am.
        /// </summary>
        /// <param name="fecha">Fecha a la cual se estandariza.</param>
        /// <returns></returns>
        public static System.DateTime FechaSinHora(System.DateTime fecha)
        {
            return new 
                System.DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 0, 0);
        }

        /// <summary>
        /// Obtiene un System.DateTime con la fecha y hora explicita.
        /// </summary>
        /// <param name="fecha">Fecha que compone la instancia.</param>
        /// <param name="hora">Hora que compone la instancia.</param>
        /// <returns></returns>
        public static System.DateTime UnionFechaYHora(System.DateTime fecha, System.DateTime hora)
        {
            return new
                System.DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);
        }

        public static string DateToStringYMD(System.DateTime date)
        {
            string dateString = date.Year.ToString();
            //int month = date.Month;
            //int day = date.Day;
            if (date.Month < 10)
            {
                dateString += "-0" + date.Month;
            }
            else
            {
                dateString += "-" + date.Month;
            }

            if (date.Day < 10)
            {
                dateString += "-0" + date.Day;
            }
            else
            {
                dateString += "-" + date.Day;
            }

            return dateString;
        }

        public static string TimeToString00(System.DateTime date)
        {
            string dateString = "";
            if (date.Hour < 10)
            {
                dateString += "0" + date.Hour;
            }
            else
            {
                dateString += "" + date.Hour;
            }

            if (date.Minute < 10)
            {
                dateString += ":0" + date.Minute;
            }
            else
            {
                dateString += ":" + date.Minute;
            }

            if (date.Second < 10)
            {
                dateString += ":0" + date.Second;
            }
            else
            {
                dateString += ":" + date.Second;
            }

            return dateString;
        }

        /// <summary>
        /// Obtiene el valor del mes en una cadena strig con el nombre corto del mes.
        /// </summary>
        /// <param name="mes">Número del mes a convertir.</param>
        /// <returns></returns>
        public static string MesCorto(int mes)
        {
            var stringMes = "";
            switch(mes)
            {
                case 1:
                    {
                        stringMes = "Ene";
                        break;
                    }
                case 2:
                    {
                        stringMes = "Feb";
                        break;
                    }
                case 3:
                    {
                        stringMes = "Mar";
                        break;
                    }
                case 4:
                    {
                        stringMes = "Abr";
                        break;
                    }
                case 5:
                    {
                        stringMes = "May";
                        break;
                    }
                case 6:
                    {
                        stringMes = "Jun";
                        break;
                    }
                case 7:
                    {
                        stringMes = "Jul";
                        break;
                    }
                case 8:
                    {
                        stringMes = "Ago";
                        break;
                    }
                case 9:
                    {
                        stringMes = "Sep";
                        break;
                    }
                case 10:
                    {
                        stringMes = "Oct";
                        break;
                    }
                case 11:
                    {
                        stringMes = "Nov";
                        break;
                    }
                case 12:
                    {
                        stringMes = "Dic";
                        break;
                    }
            }
            return stringMes;
        }

        /// <summary>
        /// Obtiene el valor del mes en una cadena strig con el nombre largo del mes.
        /// </summary>
        /// <param name="mes">Número del mes a convertir.</param>
        /// <returns></returns>
        public static string MesLargo(int mes)
        {
            var stringMes = "";
            switch (mes)
            {
                case 1:
                    {
                        stringMes = "Enero";
                        break;
                    }
                case 2:
                    {
                        stringMes = "Febero";
                        break;
                    }
            }
            return stringMes;
        }
    }
}