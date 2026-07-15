namespace PortalDePedidosShared.FacturasVM
{
    public partial class FacturasSP
    {
        //public string NRO_FACTURA_LEGAL_COMPLETO { get; set; }
        //public string CENTRO_EMISOR { get; set; }
        //public string NRO_FACTURA_LEGAL { get; set; }
        //public DateTime FECHA_FACTURA { get; set; }
        //public int AÑO_FACTURA { get; set; }
        //public int MES_FACTURA { get; set; }
        //public string NRO_REMITO { get; set; }
        //public int NRO_ORDEN { get; set; }
        //public string TIPO_ORDEN { get; set; }
        //public string CUIT_EMISOR { get; set; }
        //public string NOMBRE_ARCHIVO { get; set; }
        public int? CodCliente { get; set; }
        public string Tipo_doc { get; set; }
        public int Nro_doc { get; set; }
        public DateOnly? Expr1 { get; set; }
        public string NroFactura { get; set; }
        public string? Nombre_archivo { get; set; } = "";
        public decimal Precio_total { get; set; }
        public DateOnly? Fecha_factura { get; set; }
        public DateOnly? Fecha_vto_factura { get; set; }
        public string? Nro_remito { get; set; }
    }
}
