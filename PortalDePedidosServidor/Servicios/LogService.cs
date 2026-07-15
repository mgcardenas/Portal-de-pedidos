using static System.Net.Mime.MediaTypeNames;

namespace PortalDePedidosServidor.Servicios
{
    public class LogService
    {
        private string _path = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
        private string _pathPDF = AppDomain.CurrentDomain.BaseDirectory + "LogPDF.txt";
        private string _pathRecaptcha = AppDomain.CurrentDomain.BaseDirectory + "LogRecaptcha.txt";
        private string _pathCasosEspeciales = AppDomain.CurrentDomain.BaseDirectory + "LogCasosEspeciales.txt";
        //private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\\Log.txt");


        public void WriteLogException(Exception ex)
        {
            //ecribe dentro de un archivo
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - "
                    + ex.Message + " - "
                    + ex.InnerException + " - "
                    + ex.Source + " - "
                    + ex.StackTrace);
            }
        }

        public void WriteLogRecaptcha(string text)
        {
            //ecribe dentro de un archivo
            using (StreamWriter writer = new StreamWriter(_pathRecaptcha, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - " + text);
            }
        }

        public void WriteLogPDF(Exception ex)
        {
            //ecribe dentro de un archivo
            using (StreamWriter writer = new StreamWriter(_pathPDF, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - "
                    + ex.Message + " - "
                    + ex.InnerException + " - "
                    + ex.Source + " - "
                    + ex.StackTrace);
            }
        }

        public void WriteLogPDF(string msj)
        {
            using (StreamWriter writer = new StreamWriter(_pathPDF, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - " + msj);
            }
        }
        public void WriteLogCasosEspeciales(string msj)
        {
            using (StreamWriter writer = new StreamWriter(_pathCasosEspeciales, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - " + msj);
            }
        }
    }
}
