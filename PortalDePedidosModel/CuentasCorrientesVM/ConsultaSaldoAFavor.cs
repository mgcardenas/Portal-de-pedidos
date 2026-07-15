using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.CuentasCorrientesVM
{
    public class ConsultaSaldoAFavor
    {
        public int IdCliente { get; set; }
        public double SaldoAFavor { get; set; }
        public string Mensaje { get; set; } 

        public ConsultaSaldoAFavor(int idCliente, double saldoAFavor, string mensaje)
        {
            IdCliente = idCliente;
            SaldoAFavor = saldoAFavor;
            Mensaje = mensaje;
        }
    }
}
