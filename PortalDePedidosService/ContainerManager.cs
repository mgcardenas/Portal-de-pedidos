using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalDePedidosShared.EstadisticasVM;
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;

namespace PortalDePedidosService
{
    public class ContainerManager
    {
        private CarritoPedidosContainer _carritoPedidosContainer;
        private FacturasContainer _facturasContainer;
        private RemitosContainer _remitosContainer;
        private ReciboContainer _reciboContainer;
        private SeguimientoPedidosContainer _seguimientoPedidosContainer;
        private CuentasCorrientesContainer _cuentasCorrientesContainer;
        private EstadisticaContainer _estadisticaContainer;
        private ComprasAnticipadasPendientesContainer _comprasAnticipadasContainer;

        public ContainerManager(CarritoPedidosContainer carritoPedidosContainer, FacturasContainer facturasContainer, RemitosContainer remitosContainer, ReciboContainer reciboContainer, SeguimientoPedidosContainer seguimientoPedidosContainer,CuentasCorrientesContainer cuentasCorrientesContainer, EstadisticaContainer estadisticaContainer, ComprasAnticipadasPendientesContainer comprasAnticipadasPendientesContainer)
        {
            _carritoPedidosContainer = carritoPedidosContainer;
            _facturasContainer = facturasContainer;
            _remitosContainer = remitosContainer;
            _reciboContainer = reciboContainer;
            _seguimientoPedidosContainer = seguimientoPedidosContainer;
            _cuentasCorrientesContainer = cuentasCorrientesContainer;
            _estadisticaContainer = estadisticaContainer;
            _comprasAnticipadasContainer = comprasAnticipadasPendientesContainer;
        }

        public void AsignarCliente(UsuarioVM usuario)
        {
            _carritoPedidosContainer.IngresoPedidoVM.cliente = usuario;
            _facturasContainer.cliente = usuario;
            _remitosContainer.cliente = usuario;
            _reciboContainer.cliente = usuario;
            _seguimientoPedidosContainer.cliente = usuario;
            _cuentasCorrientesContainer.cliente = usuario;
            _estadisticaContainer.cliente = usuario;
            _comprasAnticipadasContainer.cliente = usuario;
        }

        public void ReiniciarContainers()
        {
            _carritoPedidosContainer.ReiniciarCarrito();
            _facturasContainer.ReiniciarFacturas(); 
            _remitosContainer.ReiniciarRemitosContainer();
            _reciboContainer.ReiniciarReciboContainer();
            _seguimientoPedidosContainer.ReinicarSeguimiento();
            _cuentasCorrientesContainer.ReiniciarCuentasCorrientes();
            _estadisticaContainer.ReiniciarEstadisticaContainer();
            _comprasAnticipadasContainer.ReiniciarContainer();
        }
    }
}
