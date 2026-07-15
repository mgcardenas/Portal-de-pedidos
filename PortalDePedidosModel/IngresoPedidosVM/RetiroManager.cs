using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class RetiroManager
    {
        public static string GetDescripcion(RetiroEn? retiro)
        {
            switch (retiro)
            {
                case RetiroEn.Comodoro: return "Comodoro Rivadavia";
                case RetiroEn.PicoTruncado: return "Pico Truncado";
                default: return "";
            }
        }
        public static RetiroEn? GetRetiro(int cod)
        {
            switch (cod)
            {
                case 1: return RetiroEn.Comodoro;
                case 2: return RetiroEn.PicoTruncado;
                case 3: return RetiroEn.Ambas;
                default: return null;
            }
        }

        public static int? GetCod(RetiroEn retiro)
        {
            switch (retiro)
            {
                case RetiroEn.Comodoro: return 1;
                case RetiroEn.PicoTruncado: return 2;
                case RetiroEn.Ambas: return 3;
                default: return null;
            }
        }
    }

    public enum RetiroEn
    {
        //Se corresponden con CodPlanta en vista de articulos DWH
        Comodoro = 1,
        PicoTruncado = 2,
        Ambas = 3
    }
}
