using System;
using System.Collections.Generic;

namespace Datos.Entidades.Models
{
    public class Configuracion
    {
        public string EmpresaId { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string Ubigeo { get; set; }
        public decimal Iva { get; set; }
        public string MonedaId { get; set; }
        public string Sboleta { get; set; }
        public string Nboleta { get; set; }
        public string Sfactura { get; set; }
        public string Nfactura { get; set; }
        public string Scredito { get; set; }
        public string Ncredito { get; set; }
        public string Sdebito { get; set; }
        public string Ndebito { get; set; }
        public string BoletaFormato { get; set; }
        public string FacturaFormato { get; set; }
        public string CreditoFormato { get; set; }
        public string DebitoFormato { get; set; }
        public string BoletaFoto { get; set; }
        public string FacturaFoto { get; set; }
        public string CreditoFoto { get; set; }
        public string DebitoFoto { get; set; }
        public byte Lineas { get; set; }
        public byte Impresion { get; set; }
        public byte? Zeros { get; set; }
        public int? Anio { get; set; }
        public string LogoRuta { get; set; }
        public byte? PlantillaId { get; set; }
        public string Ctadetraccion { get; set; }
        public string Ctacorriente { get; set; }
    }
}
