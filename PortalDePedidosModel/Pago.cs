using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosModel
{
    public class Pago
    {
        public int Id { get; set; }
        public int NroRecibo { get; set; }
        public int NroCheque { get; set; }
        public DateOnly FechaCobranza { get; set; }
        public DateOnly FechaLiquidacion {  get; set; }
        public int Importe { get; set; }
        public string EstadoValor { get; set; }

        public Pago(int id, int nroRecibo, int nroCheque, DateOnly fechaCobranza, DateOnly fechaLiquidacion, int importe, string estadoValor)
        {
            Id = id;
            NroRecibo = nroRecibo;
            NroCheque = nroCheque;
            FechaCobranza = fechaCobranza;
            FechaLiquidacion = fechaLiquidacion;
            Importe = importe;
            EstadoValor = estadoValor;
        }
    }
}