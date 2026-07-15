using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class LogClienteService
    {
        //private string _path = AppDomain.CurrentDomain.BaseDirectory + @"\\Log.txt";
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\\Log.txt");
        private ErrorService _errorService;
        public LogClienteService(ErrorService errorService)
        {
            _errorService = errorService;
        }


        public void WriteLogException(HttpRequestException ex)
        {
            //ecribe dentro de un archivo
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                Console.WriteLine(DateTime.Now.ToString() + " - "
                    + ex.Message + " - "
                    + ex.InnerException + " - "
                    + ex.Source + " - "
                    + ex.StackTrace);
            }
            _errorService.Error(ex.StatusCode.ToString());
        }
        public void WriteLogException(Exception ex)
        {
            //ecribe dentro de un archivo
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                Console.WriteLine(DateTime.Now.ToString() + " - "
                    + ex.Message + " - "
                    + ex.InnerException + " - "
                    + ex.Source + " - "
                    + ex.StackTrace);
            }

            // Verificar si es una excepción HTTP
            if (ex is HttpRequestException httpEx && httpEx.StatusCode.HasValue)
            {
                _errorService.Error(httpEx.StatusCode.ToString());
            }
            else
            {
                _errorService.Error(null);
            }
        }
    }
}
