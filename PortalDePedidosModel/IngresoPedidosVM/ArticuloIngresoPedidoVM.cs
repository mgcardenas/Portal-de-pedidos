using PortalDePedidosShared.ArticulosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class ArticuloIngresoPedidoVM
    {
        public string CodArticulo { get; set; }
        public int CodCortoArticulo { get; set; }
        public string CodTipoArticulo { get; set; } = "";
        public string CodTipoEnvase { get; set; } = "";
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; } = "";
        public string? Imagen { get; set; } 
        public string UnidadDeMedida { get; set; }
        public int Cantidad { get; set; } = 0;
        public double PesoKG{ get; set; } = 0;
        public double PesoTotalKG{ get; set; } = 0;
        public double PesoTN{ get; set; } = 0;
        public double PesoTotalTN { get; set; } = 0;
        public double BolsasPorPallet { get; set; } = 0;
        public double BolsasTotales { get; set; } = 0;
        public double UnidadesPorPallet { get; set; } = 0;
        public double unidadesTotales { get; set; } = 0;
        public int? CodPlanta { get; set; }
        public List<UnidadMedidaVM> unidades { get; set; }
        public bool esVigueta {  get; set; }
        public bool esArticuloUnico {  get; set; }
        public bool VisibleSoloComercial {  get; set; }
        public bool GeneraPalletRetornable {  get; set; }
        public List<RubrosExclusivosVM> RubrosExclusivos { get; set; } = new();

        public double CalcularTN()
        {
            CalcularUNTotal();
            //si la unidad es Bolson
            if (UnidadDeMedida == "Bolson")
            {
                UnidadMedidaVM tnBS = unidades.Where(x => x.Umorigen == "BS" && x.Umdestino == "TN").FirstOrDefault();
                if (tnBS != null)
                {
                    PesoTN = (double)tnBS.FactorConversion;
                    PesoTotalTN = PesoTN * unidadesTotales;
                    return PesoTotalTN;
                }
            }
            //si la unidad es tonaelada muestro la cantidad
            if (UnidadDeMedida == "TN")
            {
                PesoTotalTN = Cantidad;
                unidadesTotales = Cantidad;
                return PesoTotalTN;
            }
            //busco el peso en tonelada si es que lo tiene
            UnidadMedidaVM tn = unidades.Where(x=> (x.Umorigen == "UN" || x.Umorigen == "BL") && x.Umdestino == "TN").FirstOrDefault();
            if (tn != null)
            {
                PesoTN = (double) tn.FactorConversion;
                PesoTotalTN = PesoTN * unidadesTotales;
            }
            else
            {//sino deberia tener el peso en Kg
                PesoTotalTN = CalcularKG() / 1000;
            }
            return PesoTotalTN;
        }

        public double CalcularKG()
        {
            UnidadMedidaVM kg = unidades.Where(x => x.Umorigen == "UN" && x.Umdestino == "KG").FirstOrDefault();
            if (kg != null)
            {
                PesoKG = (double)kg.FactorConversion;
                PesoTotalKG = (double) kg.FactorConversion * unidadesTotales;
            }
            return PesoTotalKG;
        }

        //public double CalcularBL()
        //{
        //    UnidadMedidaVM bl = unidades.Where(x => x.Umorigen == "PL" && x.Umdestino == "BL").FirstOrDefault();
        //    if (bl != null)
        //    {
        //        BolsasPorPallet = (double)bl.FactorConversion;
        //        BolsasTotales = (double)bl.FactorConversion * Cantidad;
        //    }
        //    return Math.Round(BolsasTotales, 2);
        //}
         
        //public double CalcularUNTotales()
        //{
        //    UnidadMedidaVM un = unidades.Where(x => x.Umorigen == "PL" && (x.Umdestino == "UN" || x.Umdestino == "BL")).FirstOrDefault();
        //    if (un != null)
        //    {
        //        UnidadesPorPallet = (double)un.FactorConversion;
        //        unidadesTotales = UnidadesPorPallet * Cantidad;
        //    }
        //    return Math.Round(unidadesTotales, 2);
        //}

        public double CalcularUNTotal()
        {
            if(esVigueta)
            {
                return CalcularUNTotalVigueta();
            }

            if (UnidadDeMedida == "Bolson")
            {
                unidadesTotales = Cantidad;
            }

            UnidadMedidaVM un = unidades.Where(x => x.Umorigen == "PL" && (x.Umdestino == "UN" || x.Umdestino == "BL")).FirstOrDefault();
            if (un != null)
            {
                UnidadesPorPallet = (double)un.FactorConversion;
                unidadesTotales = UnidadesPorPallet * Cantidad;
                return unidadesTotales;
            }
            else
            {
                return Cantidad;
                //return 0;
            }
        }

        private double CalcularUNTotalVigueta()
        {
            UnidadMedidaVM unVG = unidades.Where(x => x.Umdestino == "UN").FirstOrDefault();
            if (unVG != null)
            {
                //En este caso seria unidades por Paquete
                UnidadesPorPallet = (double)unVG.FactorConversion;
                unidadesTotales = UnidadesPorPallet * Cantidad;
                return unidadesTotales;
            }
            else
            {
                return 0;
            }
        }
    }
}
