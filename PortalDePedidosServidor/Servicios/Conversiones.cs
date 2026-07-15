using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Servicios
{
    public static class Conversiones
    {
        public static byte ConvertirBoolAByte(this bool valor)
        {
            return (byte)(valor ? 1 : 0);
        }

        public static ConfiguracionDeFlete ConfigurarFlete(FleteEnviadoPor? fleteEnviadoPor, FleteAbonadoEn? fleteAbonadoEn)
        {
            if (fleteEnviadoPor == FleteEnviadoPor.PCR)
            {
                if (fleteAbonadoEn == FleteAbonadoEn.PCR)
                {
                    return ConfiguracionDeFlete.Flete_PCR__Gestiona_Logistica;
                }
                else
                {
                    return ConfiguracionDeFlete.Flete_Cliente__Gestiona_Logistica;
                }
            }
            else
            {
                if (fleteAbonadoEn == FleteAbonadoEn.PCR)
                {
                    return ConfiguracionDeFlete.Flete_PCR__Gestiona_Cliente;
                }
                else
                {
                    return ConfiguracionDeFlete.Flete_Cliente__Gestiona_Cliente;
                }
            }
        }
        public static string ConfigurarFleteSG(FleteEnviadoPor? fleteEnviadoPor, FleteAbonadoEn? fleteAbonadoEn, string TipoFleteEnSH)
        {
            if (fleteEnviadoPor == FleteEnviadoPor.PCR && fleteAbonadoEn == FleteAbonadoEn.PCR)
            {
                return "4";
            }

            if (fleteEnviadoPor == FleteEnviadoPor.CLIENTE && fleteAbonadoEn == FleteAbonadoEn.LugarDeEntrega)
            {
                return "1";
            }

            return TipoFleteEnSH;
        }

        public static long Date2Julian(DateTime vDate)
        {
            int year = vDate.Year;
            DateTime startOfYear = new DateTime(year, 1, 1);
            int dayOfYear = (vDate - startOfYear).Days + 1;
            string julianDate = $"{year:0000}{dayOfYear:000}";
            return long.Parse(julianDate);
        }

        public static decimal Date2JulianJDEPortalViejo(DateTime vDate)
        {
            long temp = Date2Julian(vDate);
            string str = temp.ToString();

            if (str.StartsWith("19"))
            {
                str = str.Substring(2).PadLeft(6, '0');
                str = "0" + str;
            }
            else
            {
                str = str.Substring(2).PadLeft(6, '0');
                str = "1" + str;
            }

            return decimal.Parse(str.Trim());
        }

        public static decimal Date2JulianJDE(DateTime vDate)
        {
            string fechaJuliano = "";
            int year = vDate.Year;

            if(year >= 2001)
            {
                fechaJuliano = "1";
            }
            else
            {
                fechaJuliano = "0";
            }
            string yearString = year.ToString();
            fechaJuliano += yearString.Substring(yearString.Length - 2);
            fechaJuliano += CompletarDiaFechaJulian(vDate.DayOfYear);

            return decimal.Parse(fechaJuliano);
        }

        public static string CompletarDiaFechaJulian(int nroDia)
        {
            if (nroDia < 10)
                return "00" + nroDia;

            if (nroDia < 100)
                return "0"+nroDia;

            return nroDia.ToString();
        }

        public static string Left(string value, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (value.Length <= length)
            {
                return value;
            }

            return value.Substring(0, length);
        }

    }
}
