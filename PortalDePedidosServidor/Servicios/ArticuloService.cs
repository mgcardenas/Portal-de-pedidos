using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Servicios
{
    public class ArticuloService
    {
        private PortalTestContext _context;
        private DataWareHouseService _dataWhereHouseService;
        public ArticuloService(PortalTestContext context, DataWareHouseService dataWhereHouseService)
        {
            _context = context;
            _dataWhereHouseService = dataWhereHouseService;
        }

        public async Task<string> GetUltimoId()
        {
            var ultimoId = _context.Pedidos.Max(x => x.IdPedido);
            return "Ultimo id de Pedido: " + ultimoId;
        }

        public async Task<ArticuloEditarVM> GetArticuloEditar(string codigo)
        {
            //ArticuloEditarVM articuloVM = new();
            //var articuloDb = await _context.ItemsPreordens.Where(x=> x.CodItem == codigo).FirstOrDefaultAsync();
            //if (articuloDb != null)
            //{
            //    articuloVM.IdItemPreorden = articuloDb.IdItemPreorden;
            //    articuloVM.CodItem = articuloDb.CodItem;
            //    articuloVM.IdSubcategoriaItem = articuloDb.IdSubcategoriaItem;
            //    articuloVM.NombreItem = articuloDb.NombreItem;
            //    articuloVM.UrlImagen = articuloDb.UrlImagen;
            //    articuloVM.IdUnidadItem = articuloDb.IdUnidadItem;
            //    articuloVM.MinimoUnidades = articuloDb.MinimoUnidades;
            //    articuloVM.CantPorUnidad = articuloDb.CantPorUnidad;
            //    articuloVM.PesoUnidad = articuloDb.PesoUnidad;
            //    articuloVM.Habilitado = (articuloDb.RegistroAnulado == 0);
            //    articuloVM.ArticuloEnBaseDeDatos = true;
            //    //articuloVM.LocacionItem = articuloDb.LocacionItem;
            //    //articuloVM.AlmacenItem = articuloDb.AlmacenItem;
            //    return articuloVM;
            //}
            //else
            //{
                return await _dataWhereHouseService.GetArticuloEditar(codigo);
            //}
        }

        
    }
}
