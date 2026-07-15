using PortalDePedidosShared.ComprasAnticipadasPendientesVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class IngresoPedidoVM
    {
        public DateTime fechaEnvio { get; set; }
        public int idUsuario { get; set; }
        public UsuarioVM? cliente { get; set; }
        public double subTotalPallets { get; set; }
        //no hay productos con unidades de bolsones para subTotalBolsones asi que se va a usar subTotalPaquetes para las viguetas
        public double subTotalPaquetes { get; set; }
        public double subTotalGranel { get; set; }
        public double pesoTotalPedido { get; set; }
        public string? InfoOrigen { get; set; }
        public int cantidadPorPagina { get; set; } = 20;
        [Required(ErrorMessage = "Seleccione opciones de Flete.")]
        [FleteValido(ErrorMessage = "Seleccione opciones de Flete.")]
        public FleteEnviadoPor? fleteEnviadoPor { get; set; } 
        [Required(ErrorMessage = "Seleccione opciones de Flete.")]
        [FleteValido(ErrorMessage = "Seleccione opciones de Flete.")]
        public FleteAbonadoEn? fleteAbonadoEn { get; set; }
        [Required(ErrorMessage = "Seleccione una zona de destino.")]
        public string? zonaDestino { get; set; }
        public string? ordenDeCompra { get; set; }
        //[Required(ErrorMessage = "Ingrese un numero de pedidos")]
        [NroValido(ErrorMessage = "El numero de pedido debe ser entre 1 y 10")]
        public int nroDePedidos { get; set; } = 1;
        public List<DatosPedidoVM> datosDePedidos { get; set; }
        public DatosPedidoVM? datosPedido { get; set; }
        public List<ArticuloIngresoPedidoVM> articulos { get; set; }
        public bool compraEnDolares { get; set; } = false;
        //Datos comunes en ambas bd
        public string? Doc { get; set; }

        public string? Dct { get; set; }

        public string? Kco { get; set; }

        public string? Dst { get; set; }

        public string? An8 { get; set; }

        public string? Mcu { get; set; }

        public string? Cars { get; set; }

        public string? Orby { get; set; }

        public string? Lob { get; set; }

        //para validacion Nro Pedidos
        public bool nroPedidoValido = true;
        //Para Orden SG
        public List<ComprasAnticipadasVM>? seleccionadosSG { get; set; }
        public bool EsCompraAnticipada { get; set; } = false;

        public IngresoPedidoVM() 
        {
            subTotalPallets = 0;
            subTotalPaquetes = 0;
            subTotalGranel = 0;
            pesoTotalPedido = 0;
            articulos = new();
            datosDePedidos = new();
            //fleteAbonadoEn = FleteAbonadoEn.Nulo;
            //fleteEnviadoPor = FleteEnviadoPor.Nulo;
            nroDePedidos = 1;
            ActualizarDatosPedido(1);
            seleccionadosSG = new();
            EsCompraAnticipada = false;
        }

        public void ActualizarDatosPedido(int nro)
        {
            nroDePedidos = nro;
            //Valido nro de pedido
            nroPedidoValido = nroDePedidos > 0 && nroDePedidos <= 10;
            if(nroPedidoValido)
            {
                datosDePedidos.Clear();
                for (int i = 1; i <= nroDePedidos; i++)
                {
                    datosDePedidos.Add(new DatosPedidoVM()
                    {
                        fechaDeEntrega= DateTime.Now.AddDays(i-1),
                        nroPedido= i
                    });
                }
            }
        }

        public double CalcularTotalTN()
        {
            pesoTotalPedido = 0;
            foreach(var item in articulos)
            {
                pesoTotalPedido += item.PesoTotalTN;
            }
            return pesoTotalPedido;
        }

        public double CalcularSubTotaPallet()
        {//calculo todos pero muestro el de pallet y   partir de ahi solo muestro los otros subtotales
            subTotalPallets = 0;
            subTotalGranel = 0;
            subTotalPaquetes = 0;
            foreach (var item in articulos)
            {
                switch (item.UnidadDeMedida)
                {
                    case "TN":
                        subTotalGranel += item.PesoTotalTN;
                        break;
                    case "Paquete":
                        subTotalPaquetes += item.PesoTotalTN;
                        break;
                    case "Pallet":
                        subTotalPallets += item.PesoTotalTN;
                        break;
                }

            }
            return subTotalPallets;
        }
    }

    public class NroValido : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && (intValue <= 0 || intValue > 10))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    public class FleteValido : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((FleteEnviadoPor)value) == FleteEnviadoPor.Nulo)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
