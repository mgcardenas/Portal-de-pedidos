
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class CarritoPedidosContainer
    {
        public RetiroEn? retiroEn { get; set; }
        public IngresoPedidoVM IngresoPedidoVM { get; set; }
        public InformacionFinalPedido? InformacionFinalPedido { get; set; }

        public event Action AccionArticulo;

        public bool PedidoEnCurso;

        //para validacion MaxTN
        public bool maxTNValido = true;

        public List<ArticuloIngresoPedidoVM> articulosTodos {  get; set; }
        
        public CarritoPedidosContainer() 
        {
            IngresoPedidoVM = new IngresoPedidoVM();
            PedidoEnCurso = false;
            articulosTodos = new();
        }

        public void ReiniciarCarrito()
        {
            IngresoPedidoVM = new IngresoPedidoVM();
            PedidoEnCurso = false;
            retiroEn = null;
            InformacionFinalPedido = null;
        }

        public void AgregarArticulo(ArticuloIngresoPedidoVM articulo)
        {
            PedidoEnCurso = true;
            IngresoPedidoVM.articulos.Add(articulo);
            ExecuteAction();
            
        }

        public void CamboCantidad()
        {
            ExecuteAction();
        }

        public void BorrarArticulo(ArticuloIngresoPedidoVM articulo)
        {
            IngresoPedidoVM.articulos.Remove(articulo);
            ExecuteAction();
        }

        //validaciones para agregar articulo
        public ValidacionArticuloIngresoVM ValidarArticulo(ArticuloIngresoPedidoVM articulo)
        {
            ValidacionArticuloIngresoVM validacion = new();
            validacion.sePuedeAgregar = true;
            validacion.msj = "El artículo "+ articulo.CodArticulo + " - " + articulo.Descripcion + " se agrego correctamente!";

            //si el carrito esta vacio puedo agregar cualquier articulo
            if (IngresoPedidoVM.articulos.Count() == 0)
            {
                return validacion;
            }

            if (IngresoPedidoVM.articulos.Any(x=> x.CodArticulo == articulo.CodArticulo))
            {
                validacion.sePuedeAgregar = false;
                validacion.msj = "El articulo " + articulo.CodArticulo + " - " + articulo.Descripcion + " ya existe en el pedido! Para aumentar la cantidad de este artículo debe hacerlo desde el carrito de compras.";
                return validacion;
            }

            //si hay un articulo unico no puedo agregar
            ArticuloIngresoPedidoVM? articuloUnico = IngresoPedidoVM.articulos.Where(x=> x.esArticuloUnico == true).FirstOrDefault();
            if (articuloUnico != null)
            {
                validacion.sePuedeAgregar = false;
                validacion.msj = "El artículo " + articuloUnico.CodArticulo + " - " + articuloUnico.Descripcion + " en en el carrito debe ser el único en el pedido!";
                return validacion;
            }

            //si ya hay articulos en el carrito no puedo agregar un articulo unico
            if (articulo.esArticuloUnico && IngresoPedidoVM.articulos.Count() > 0)
            {
                validacion.sePuedeAgregar = false;
                validacion.msj = "El artículo " + articulo.CodArticulo + " - " + articulo.Descripcion + " debe ser el único en el pedido!";
                return validacion;
            }

            //verifico si hay articulos exclusivos de CRD y se quiere agregar un articulo exclusivo PTC o viceversa
            var hayProblema = HayProblemaArticuloCRDyPTC(articulo);
            if (hayProblema)
            {
                validacion.sePuedeAgregar = false;
                validacion.msj = "No pueden existir artículos exclusivos de Comodoro y Pico Truncado en el mismo pedido!";
                return validacion;
            }

            //resto de articulos se agregan
            return validacion;
        }

        //verifico si hay articulos exclusivos de CRD y se quiere agregar un articulo exclusivo PTC o viceversa
        private bool HayProblemaArticuloCRDyPTC(ArticuloIngresoPedidoVM articulo)
        {
            //si el articulo esta disponible en ambas plantas no hay problema
            if(articulo.CodPlanta == 3) 
                return false;
            //si hay art de CRD y se quiere agg un art PTC hay problema
            ArticuloIngresoPedidoVM? articuloCRD = IngresoPedidoVM.articulos.Where(x => x.CodPlanta == AreaDeVentaManager.GetIntAreaDeVenta(AreaDeVenta.ComodoroRivadavia)).FirstOrDefault();
            if(articuloCRD != null && articulo.CodPlanta == AreaDeVentaManager.GetIntAreaDeVenta(AreaDeVenta.PicoTruncado)) 
                return true;
            //si hay art de PTC y se quiere agg un art CRD hay problema
            ArticuloIngresoPedidoVM? articuloPTC = IngresoPedidoVM.articulos.Where(x => x.CodPlanta == AreaDeVentaManager.GetIntAreaDeVenta(AreaDeVenta.PicoTruncado)).FirstOrDefault();
            if (articuloPTC != null && articulo.CodPlanta == AreaDeVentaManager.GetIntAreaDeVenta(AreaDeVenta.ComodoroRivadavia)) 
                return true;
            
            //si no se cumple ninguna condicion no hay problema
            return false;
        }

        public double MaxTN(int minTN, int maxTN)
        {
            var total = IngresoPedidoVM.CalcularTotalTN();
            //valido el total de TN maxima
            maxTNValido = total <= maxTN && total >= minTN;
            return total;
        }

        public bool ContieneArticuloUnico()
        {
            ArticuloIngresoPedidoVM? articuloUnico = IngresoPedidoVM.articulos.Where(x => x.esArticuloUnico == true).FirstOrDefault();
            return articuloUnico != null;
        }


        private void ExecuteAction() => AccionArticulo?.Invoke();
    }
}
