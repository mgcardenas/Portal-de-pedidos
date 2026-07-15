using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Servicios
{
    public class IngresoPedidoService
    {
        public PortalTestContext _context;
        private JDEService _jdeService;
        private DataWareHouseService _dataWareHouseService;

        public int? idPedido { get; set; }

        public IngresoPedidoService(PortalTestContext context,JDEService jDEService, DataWareHouseService dataWareHouseService)
        {
            _context = context;
            _jdeService = jDEService;
            _dataWareHouseService = dataWareHouseService;
        }


        public async Task<InformacionFinalPedido> GuardarPedido(IngresoPedidoVM ingresoPedidoVM)
        {
            //var infoCLiente = await _dataWareHouseService.GetInfoCliente(ingresoPedidoVM.cliente.nroUsuarioJDE);

            //informacion para pantalla final del pedido
            InformacionFinalPedido info = new();
            info.pesoTotal = ingresoPedidoVM.pesoTotalPedido;
            info.cliente = ingresoPedidoVM.cliente;
            info.articulos = ingresoPedidoVM.articulos;
            //info.pedidos = ingresoPedidoVM.datosDePedidos;

            //Verificacion de Pallet Retornable
            int cantidadPalletsParaAgregar = CantidadDePalletsRetornables(ingresoPedidoVM);
            info.cantidadPalletRetornables = cantidadPalletsParaAgregar;

            if (cantidadPalletsParaAgregar > 0)
            {
                ArticuloIngresoPedidoVM? palletRetornable = await _dataWareHouseService.GetPalletRetornable();
                palletRetornable.Cantidad = cantidadPalletsParaAgregar;
                palletRetornable.unidadesTotales = cantidadPalletsParaAgregar;
                ingresoPedidoVM.articulos.Add(palletRetornable);
            }

            ingresoPedidoVM.compraEnDolares = CompraEnDolares(ingresoPedidoVM.cliente.nroUsuarioJDE);

            //Seteo datos comunes en ambas bd
            
            ingresoPedidoVM.Dct = "SP";
            ingresoPedidoVM.Dst = "850";
            ingresoPedidoVM.An8 = ingresoPedidoVM.cliente.nroUsuarioJDE;
            ingresoPedidoVM.Mcu = "           1";
            ingresoPedidoVM.Cars = "11108";
            

            //CHEQUEO SI EN LA ORDEN HAY ALGUN PRODUCTO EXCLUSIVO DE UNA PLANTA
            //Si lo hay, seteo el almacen y comáñia a esa planta. Si el pedido se compone sólo de productos
            //que se encuentran en ambas plantas, el almacen queda vacío para permitir a logística poder cambiarlo.
            //seteo por defecto ambas
            ingresoPedidoVM.Kco = "00001";
            ingresoPedidoVM.Lob = "";

            foreach (var art in ingresoPedidoVM.articulos)
            {
                RetiroEn? retiro = RetiroManager.GetRetiro((int)art.CodPlanta);
                switch (retiro)
                {
                    case RetiroEn.Comodoro:
                        ingresoPedidoVM.Kco = "00001";
                        ingresoPedidoVM.Lob = "COM";

                        break;
                    case RetiroEn.PicoTruncado:
                        ingresoPedidoVM.Kco = "00024";
                        ingresoPedidoVM.Lob = "TRU";
                        break;
                }
            }

            foreach (var item in ingresoPedidoVM.datosDePedidos)
            {
                ingresoPedidoVM.datosPedido = item;

                await GuardarPedidoEnBDLocal(ingresoPedidoVM);
                //Seteo el dato de ID de Pedido
                ingresoPedidoVM.Orby = idPedido.ToString();
                ingresoPedidoVM.Doc = idPedido.ToString();
                await GuardarPedidoHijoBDLocal(ingresoPedidoVM);

                //guardo en JDE
                if (ingresoPedidoVM.EsCompraAnticipada)
                {
                    await _jdeService.GuardarPedidoSGEnJDE(ingresoPedidoVM);
                    await _jdeService.GuardarPedidoHijoSGEnJDE(ingresoPedidoVM);
                }
                else
                {

                    await _jdeService.GuardarPedidoEnJDE(ingresoPedidoVM);
                    await _jdeService.GuardarPedidoHijoEnJDE(ingresoPedidoVM);
                }
                await _jdeService.GuardarComentarioJDE(ingresoPedidoVM);
                item.IdPedido = (int)idPedido;
                info.pedidos.Add(item);
            }
            
            //info.idPedido = (int)idPedido;
            return info;
        }



        private bool CompraEnDolares(string nroJDE)
        {
            //SI EL USUARIO ES TRADING O HALLIBURTON BOLIVIA HAGO LA COMPRA EN DOLARES
            return (nroJDE == "12601052" || nroJDE == "12601063" || nroJDE == "12601080");
        }

        private int CantidadDePalletsRetornables(IngresoPedidoVM ingresoPedidoVM)//, InfoClienteVM infoCliente)
        {
            var cantidadPalletsParaAgregar = 0;

            var articulosZonaConPalletRetornable = _context.ArticulosZonasConPalletRetornables.ToList();

            //cantidadPalletsParaAgregar += ingresoPedidoVM.articulos
            //    .Where(x => articulosZonaConPalletRetornable.Any(a => a.CodArticulo == x.CodArticulo && a.Zona == "ZZZ"))
            //    .Sum(x => x.Cantidad);

            cantidadPalletsParaAgregar += ingresoPedidoVM.articulos
                .Where(x=> articulosZonaConPalletRetornable.Any(a=> a.CodArticulo == x.CodArticulo && (a.Zona == ingresoPedidoVM.zonaDestino || a.Zona == "ZZZ")))
                .Sum(x => x.Cantidad);

            return cantidadPalletsParaAgregar;
        }

        private async Task GuardarPedidoEnBDLocal(IngresoPedidoVM ingresoPedidoVM)
        {
            Pedido pedido = new Pedido();
            pedido.IdPedido = _context.Pedidos.Max(x => x.IdPedido) + 1;
            pedido.RegistroAnulado = 0;
            pedido.FechaPedido = DateTime.Now;
            pedido.TonPlt = (int)ingresoPedidoVM.subTotalPallets;
            pedido.TonBol = (int)ingresoPedidoVM.subTotalPaquetes;
            pedido.TonGra = (int)ingresoPedidoVM.subTotalGranel;
            pedido.ObservacionPedido = ingresoPedidoVM.datosPedido.observaciones;
            pedido.InfoOrigen = ingresoPedidoVM.InfoOrigen;
            pedido.CodZona = ingresoPedidoVM.zonaDestino;
            pedido.ModoTransporte = (int)Conversiones.ConfigurarFlete(ingresoPedidoVM.fleteEnviadoPor, ingresoPedidoVM.fleteAbonadoEn);
            pedido.FechaEnvio = ingresoPedidoVM.datosPedido.fechaDeEntrega;
            pedido.IdUsuario = ingresoPedidoVM.idUsuario;

            pedido.Dct = ingresoPedidoVM.Dct;
            pedido.Dst = ingresoPedidoVM.Dst;
            pedido.An8 = ingresoPedidoVM.An8;
            pedido.Mcu = ingresoPedidoVM.Mcu;
            pedido.Cars = ingresoPedidoVM.Cars;
            pedido.Kco = ingresoPedidoVM.Kco;
            pedido.Lob = ingresoPedidoVM.Lob;

            _context.Entry(pedido).State = EntityState.Added;
            await _context.SaveChangesAsync();

            idPedido = pedido.IdPedido;
            pedido.Doc = idPedido.ToString();
            pedido.Orby = idPedido.ToString();

            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task GuardarPedidoHijoBDLocal(IngresoPedidoVM ingreso)
        {
            foreach(var articulo in ingreso.articulos) 
            {
                PedidoHijo pedido = new PedidoHijo();
                pedido.RegistroAnulado = 0;
                pedido.CodArticulo = articulo.CodArticulo;
                pedido.Cantidad = articulo.Cantidad;
                pedido.IdPedido =(int) idPedido;
                _context.Entry(pedido).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }

        }


    }
}
