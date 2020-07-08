//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//     //
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace ServiceReference2
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Extras", Namespace="http://www.dbnet.cl")]
    public partial class Extras : object
    {
        
        private ServiceReference2.EnvioPdf[] EnvioPdfField;
        
        private ServiceReference2.Adjuntos[] AdjuntosField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ServiceReference2.EnvioPdf[] EnvioPdf
        {
            get
            {
                return this.EnvioPdfField;
            }
            set
            {
                this.EnvioPdfField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public ServiceReference2.Adjuntos[] Adjuntos
        {
            get
            {
                return this.AdjuntosField;
            }
            set
            {
                this.AdjuntosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EnvioPdf", Namespace="http://www.dbnet.cl")]
    public partial class EnvioPdf : object
    {
        
        private ServiceReference2.CamposEnvioPdf CamposEnvioPdfField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ServiceReference2.CamposEnvioPdf CamposEnvioPdf
        {
            get
            {
                return this.CamposEnvioPdfField;
            }
            set
            {
                this.CamposEnvioPdfField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Adjuntos", Namespace="http://www.dbnet.cl")]
    public partial class Adjuntos : object
    {
        
        private ServiceReference2.CamposAdjuntos CamposAdjuntosField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ServiceReference2.CamposAdjuntos CamposAdjuntos
        {
            get
            {
                return this.CamposAdjuntosField;
            }
            set
            {
                this.CamposAdjuntosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CamposEnvioPdf", Namespace="http://www.dbnet.cl")]
    public partial class CamposEnvioPdf : object
    {
        
        private int NroLinMailField;
        
        private string MailEnviField;
        
        private string MailCCField;
        
        private string MailCCOField;
        
        private string mailEnvioField;
        
        private string mailCopiaField;
        
        private string mailCopiaOcultaField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int NroLinMail
        {
            get
            {
                return this.NroLinMailField;
            }
            set
            {
                this.NroLinMailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string MailEnvi
        {
            get
            {
                return this.MailEnviField;
            }
            set
            {
                this.MailEnviField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string MailCC
        {
            get
            {
                return this.MailCCField;
            }
            set
            {
                this.MailCCField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string MailCCO
        {
            get
            {
                return this.MailCCOField;
            }
            set
            {
                this.MailCCOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string mailEnvio
        {
            get
            {
                return this.mailEnvioField;
            }
            set
            {
                this.mailEnvioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string mailCopia
        {
            get
            {
                return this.mailCopiaField;
            }
            set
            {
                this.mailCopiaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string mailCopiaOculta
        {
            get
            {
                return this.mailCopiaOcultaField;
            }
            set
            {
                this.mailCopiaOcultaField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CamposAdjuntos", Namespace="http://www.dbnet.cl")]
    public partial class CamposAdjuntos : object
    {
        
        private int NroLinAdjuntoField;
        
        private string NombreAdjuntoField;
        
        private string DescripcionAdjuntoField;
        
        private string TipoField;
        
        private string nombreAdjunto1Field;
        
        private string descripcionAdjunto1Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int NroLinAdjunto
        {
            get
            {
                return this.NroLinAdjuntoField;
            }
            set
            {
                this.NroLinAdjuntoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string NombreAdjunto
        {
            get
            {
                return this.NombreAdjuntoField;
            }
            set
            {
                this.NombreAdjuntoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string DescripcionAdjunto
        {
            get
            {
                return this.DescripcionAdjuntoField;
            }
            set
            {
                this.DescripcionAdjuntoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Tipo
        {
            get
            {
                return this.TipoField;
            }
            set
            {
                this.TipoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="nombreAdjunto", EmitDefaultValue=false, Order=4)]
        public string nombreAdjunto1
        {
            get
            {
                return this.nombreAdjunto1Field;
            }
            set
            {
                this.nombreAdjunto1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="descripcionAdjunto", EmitDefaultValue=false, Order=5)]
        public string descripcionAdjunto1
        {
            get
            {
                return this.descripcionAdjunto1Field;
            }
            set
            {
                this.descripcionAdjunto1Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Encabezado", Namespace="http://www.dbnet.cl")]
    public partial class Encabezado : object
    {
        
        private ServiceReference2.CamposHead camposEncabezadoField;
        
        private ServiceReference2.ImptoReten[] ImptoRetenField;
        
        private ServiceReference2.DetaDetraccion[] DetaDetraccionField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ServiceReference2.CamposHead camposEncabezado
        {
            get
            {
                return this.camposEncabezadoField;
            }
            set
            {
                this.camposEncabezadoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public ServiceReference2.ImptoReten[] ImptoReten
        {
            get
            {
                return this.ImptoRetenField;
            }
            set
            {
                this.ImptoRetenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public ServiceReference2.DetaDetraccion[] DetaDetraccion
        {
            get
            {
                return this.DetaDetraccionField;
            }
            set
            {
                this.DetaDetraccionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CamposHead", Namespace="http://www.dbnet.cl")]
    public partial class CamposHead : object
    {
        
        private string TipoDTEField;
        
        private string SerieField;
        
        private string CorrelativoField;
        
        private string FchEmisField;
        
        private string TipoMonedaField;
        
        private string RUTEmisField;
        
        private string TipoRucEmisField;
        
        private string RznSocEmisField;
        
        private string NomComerField;
        
        private string DirEmisField;
        
        private string ComuEmisField;
        
        private string UrbanizaEmisField;
        
        private string ProviEmisField;
        
        private string DeparEmisField;
        
        private string DistriEmisField;
        
        private string PaisEmisField;
        
        private string RUTRecepField;
        
        private string TipoRutReceptorField;
        
        private string RznSocRecepField;
        
        private string DirRecepUbiGeoField;
        
        private string DirRecepField;
        
        private string DirRecepUrbanizaField;
        
        private string DirRecepProvinciaField;
        
        private string DirRecepDepartamentoField;
        
        private string DirRecepDistritoField;
        
        private string DirRecepCodPaisField;
        
        private string CodigoAutorizacionField;
        
        private string SustentoField;
        
        private string TipoNotaCreditoField;
        
        private string MntNetoField;
        
        private string MntExeField;
        
        private string MntExoField;
        
        private string MntTotGratField;
        
        private string MntTotBoniField;
        
        private string MntTotAnticipoField;
        
        private string MntTotalField;
        
        private string TotDscNAField;
        
        private string TotCrgNAField;
        
        private string MntRedondeoField;
        
        private string IndAgenciaViajeField;
        
        private string IndicadorTransfSelvaField;
        
        private string IndicadorServiciosSelvaField;
        
        private string IndicadorContratosSelvaField;
        
        private string IndVentaEmisItineranteField;
        
        private string CodRetencionField;
        
        private string MntImpRetencionField;
        
        private string ObsRetencionField;
        
        private string MntRetencionField;
        
        private string MntTotalMenosRetencionField;
        
        private string CodPercepcionField;
        
        private string MntImpPercepcionField;
        
        private string ObsPercepcionField;
        
        private string MntPercepcionField;
        
        private string MntTotalMasPercepcionField;
        
        private string TipoOperacionField;
        
        private string FechVencFactField;
        
        private string DirEntregaField;
        
        private string DirEntregaUbiGeoField;
        
        private string DirEntregaUrbanizaField;
        
        private string DirEntregaProvinciaField;
        
        private string DirEntregaDepartamentoField;
        
        private string DirEntregaDistritoField;
        
        private string DirEntregaCodPaisField;
        
        private string DirParUbiGeoField;
        
        private string DirParDireccionField;
        
        private string DirParUrbanizaField;
        
        private string DirParProvinciaField;
        
        private string DirParDepartField;
        
        private string DirParDistritoField;
        
        private string DirParCodPaisField;
        
        private string DirLlegUbiGeoField;
        
        private string DirLlegDireccionField;
        
        private string DirLlegUrbanizaField;
        
        private string DirLlegProvinciaField;
        
        private string DirLlegDepartField;
        
        private string DirLlegDistritoField;
        
        private string DirllegCodPaisField;
        
        private string PlacaVehiculoField;
        
        private string CertVehiculoField;
        
        private string MarcavehiculoField;
        
        private string LicenciaField;
        
        private string RUCTransporField;
        
        private string TipoRucTransField;
        
        private string RazoTransField;
        
        private string ModalidadTransporteField;
        
        private string TotalPesoBrutoField;
        
        private string CodigoLocalAnexoField;
        
        private string NumPlacaVehiField;
        
        private string ImprDestField;
        
        private string NombSucursalField;
        
        private string COLA_IMPRESIONField;
        
        private string CantidadItemField;
        
        private string HoraEmisionField;
        
        private string CodigoLeyendaField;
        
        private string CODI_EMPRField;
        
        private string EstadoField;
        
        private string MensajeField;
        
        private string TpoMonedaField;
        
        private string RUTEmisorField;
        
        private string CodiComuField;
        
        private string TipoRUTRecepField;
        
        private string DirRecepDptoField;
        
        private string MntTotalAnticipoField;
        
        private string DirlleUbiGeoField;
        
        private string TipoOperField;
        
        private string CodiSucuField;
        
        private string ColaImpresionField;
        
        private string DirRecepUbigeo1Field;
        
        private string DirEntregaUbigeo1Field;
        
        private string DirllegUrbaniza1Field;
        
        private string DirllegDireccion1Field;
        
        private string DirllegProvincia1Field;
        
        private string DirllegDepart1Field;
        
        private string DirllegDistrito1Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TipoDTE
        {
            get
            {
                return this.TipoDTEField;
            }
            set
            {
                this.TipoDTEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Serie
        {
            get
            {
                return this.SerieField;
            }
            set
            {
                this.SerieField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Correlativo
        {
            get
            {
                return this.CorrelativoField;
            }
            set
            {
                this.CorrelativoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string FchEmis
        {
            get
            {
                return this.FchEmisField;
            }
            set
            {
                this.FchEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string TipoMoneda
        {
            get
            {
                return this.TipoMonedaField;
            }
            set
            {
                this.TipoMonedaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RUTEmis
        {
            get
            {
                return this.RUTEmisField;
            }
            set
            {
                this.RUTEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string TipoRucEmis
        {
            get
            {
                return this.TipoRucEmisField;
            }
            set
            {
                this.TipoRucEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string RznSocEmis
        {
            get
            {
                return this.RznSocEmisField;
            }
            set
            {
                this.RznSocEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string NomComer
        {
            get
            {
                return this.NomComerField;
            }
            set
            {
                this.NomComerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string DirEmis
        {
            get
            {
                return this.DirEmisField;
            }
            set
            {
                this.DirEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string ComuEmis
        {
            get
            {
                return this.ComuEmisField;
            }
            set
            {
                this.ComuEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string UrbanizaEmis
        {
            get
            {
                return this.UrbanizaEmisField;
            }
            set
            {
                this.UrbanizaEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string ProviEmis
        {
            get
            {
                return this.ProviEmisField;
            }
            set
            {
                this.ProviEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string DeparEmis
        {
            get
            {
                return this.DeparEmisField;
            }
            set
            {
                this.DeparEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string DistriEmis
        {
            get
            {
                return this.DistriEmisField;
            }
            set
            {
                this.DistriEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string PaisEmis
        {
            get
            {
                return this.PaisEmisField;
            }
            set
            {
                this.PaisEmisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string RUTRecep
        {
            get
            {
                return this.RUTRecepField;
            }
            set
            {
                this.RUTRecepField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string TipoRutReceptor
        {
            get
            {
                return this.TipoRutReceptorField;
            }
            set
            {
                this.TipoRutReceptorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string RznSocRecep
        {
            get
            {
                return this.RznSocRecepField;
            }
            set
            {
                this.RznSocRecepField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string DirRecepUbiGeo
        {
            get
            {
                return this.DirRecepUbiGeoField;
            }
            set
            {
                this.DirRecepUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string DirRecep
        {
            get
            {
                return this.DirRecepField;
            }
            set
            {
                this.DirRecepField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string DirRecepUrbaniza
        {
            get
            {
                return this.DirRecepUrbanizaField;
            }
            set
            {
                this.DirRecepUrbanizaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string DirRecepProvincia
        {
            get
            {
                return this.DirRecepProvinciaField;
            }
            set
            {
                this.DirRecepProvinciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string DirRecepDepartamento
        {
            get
            {
                return this.DirRecepDepartamentoField;
            }
            set
            {
                this.DirRecepDepartamentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string DirRecepDistrito
        {
            get
            {
                return this.DirRecepDistritoField;
            }
            set
            {
                this.DirRecepDistritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string DirRecepCodPais
        {
            get
            {
                return this.DirRecepCodPaisField;
            }
            set
            {
                this.DirRecepCodPaisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=26)]
        public string CodigoAutorizacion
        {
            get
            {
                return this.CodigoAutorizacionField;
            }
            set
            {
                this.CodigoAutorizacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=27)]
        public string Sustento
        {
            get
            {
                return this.SustentoField;
            }
            set
            {
                this.SustentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=28)]
        public string TipoNotaCredito
        {
            get
            {
                return this.TipoNotaCreditoField;
            }
            set
            {
                this.TipoNotaCreditoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=29)]
        public string MntNeto
        {
            get
            {
                return this.MntNetoField;
            }
            set
            {
                this.MntNetoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=30)]
        public string MntExe
        {
            get
            {
                return this.MntExeField;
            }
            set
            {
                this.MntExeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=31)]
        public string MntExo
        {
            get
            {
                return this.MntExoField;
            }
            set
            {
                this.MntExoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=32)]
        public string MntTotGrat
        {
            get
            {
                return this.MntTotGratField;
            }
            set
            {
                this.MntTotGratField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=33)]
        public string MntTotBoni
        {
            get
            {
                return this.MntTotBoniField;
            }
            set
            {
                this.MntTotBoniField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=34)]
        public string MntTotAnticipo
        {
            get
            {
                return this.MntTotAnticipoField;
            }
            set
            {
                this.MntTotAnticipoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=35)]
        public string MntTotal
        {
            get
            {
                return this.MntTotalField;
            }
            set
            {
                this.MntTotalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=36)]
        public string TotDscNA
        {
            get
            {
                return this.TotDscNAField;
            }
            set
            {
                this.TotDscNAField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=37)]
        public string TotCrgNA
        {
            get
            {
                return this.TotCrgNAField;
            }
            set
            {
                this.TotCrgNAField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=38)]
        public string MntRedondeo
        {
            get
            {
                return this.MntRedondeoField;
            }
            set
            {
                this.MntRedondeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=39)]
        public string IndAgenciaViaje
        {
            get
            {
                return this.IndAgenciaViajeField;
            }
            set
            {
                this.IndAgenciaViajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=40)]
        public string IndicadorTransfSelva
        {
            get
            {
                return this.IndicadorTransfSelvaField;
            }
            set
            {
                this.IndicadorTransfSelvaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=41)]
        public string IndicadorServiciosSelva
        {
            get
            {
                return this.IndicadorServiciosSelvaField;
            }
            set
            {
                this.IndicadorServiciosSelvaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=42)]
        public string IndicadorContratosSelva
        {
            get
            {
                return this.IndicadorContratosSelvaField;
            }
            set
            {
                this.IndicadorContratosSelvaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=43)]
        public string IndVentaEmisItinerante
        {
            get
            {
                return this.IndVentaEmisItineranteField;
            }
            set
            {
                this.IndVentaEmisItineranteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=44)]
        public string CodRetencion
        {
            get
            {
                return this.CodRetencionField;
            }
            set
            {
                this.CodRetencionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=45)]
        public string MntImpRetencion
        {
            get
            {
                return this.MntImpRetencionField;
            }
            set
            {
                this.MntImpRetencionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=46)]
        public string ObsRetencion
        {
            get
            {
                return this.ObsRetencionField;
            }
            set
            {
                this.ObsRetencionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=47)]
        public string MntRetencion
        {
            get
            {
                return this.MntRetencionField;
            }
            set
            {
                this.MntRetencionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=48)]
        public string MntTotalMenosRetencion
        {
            get
            {
                return this.MntTotalMenosRetencionField;
            }
            set
            {
                this.MntTotalMenosRetencionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=49)]
        public string CodPercepcion
        {
            get
            {
                return this.CodPercepcionField;
            }
            set
            {
                this.CodPercepcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=50)]
        public string MntImpPercepcion
        {
            get
            {
                return this.MntImpPercepcionField;
            }
            set
            {
                this.MntImpPercepcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=51)]
        public string ObsPercepcion
        {
            get
            {
                return this.ObsPercepcionField;
            }
            set
            {
                this.ObsPercepcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=52)]
        public string MntPercepcion
        {
            get
            {
                return this.MntPercepcionField;
            }
            set
            {
                this.MntPercepcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=53)]
        public string MntTotalMasPercepcion
        {
            get
            {
                return this.MntTotalMasPercepcionField;
            }
            set
            {
                this.MntTotalMasPercepcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=54)]
        public string TipoOperacion
        {
            get
            {
                return this.TipoOperacionField;
            }
            set
            {
                this.TipoOperacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=55)]
        public string FechVencFact
        {
            get
            {
                return this.FechVencFactField;
            }
            set
            {
                this.FechVencFactField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=56)]
        public string DirEntrega
        {
            get
            {
                return this.DirEntregaField;
            }
            set
            {
                this.DirEntregaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=57)]
        public string DirEntregaUbiGeo
        {
            get
            {
                return this.DirEntregaUbiGeoField;
            }
            set
            {
                this.DirEntregaUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=58)]
        public string DirEntregaUrbaniza
        {
            get
            {
                return this.DirEntregaUrbanizaField;
            }
            set
            {
                this.DirEntregaUrbanizaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=59)]
        public string DirEntregaProvincia
        {
            get
            {
                return this.DirEntregaProvinciaField;
            }
            set
            {
                this.DirEntregaProvinciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=60)]
        public string DirEntregaDepartamento
        {
            get
            {
                return this.DirEntregaDepartamentoField;
            }
            set
            {
                this.DirEntregaDepartamentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=61)]
        public string DirEntregaDistrito
        {
            get
            {
                return this.DirEntregaDistritoField;
            }
            set
            {
                this.DirEntregaDistritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=62)]
        public string DirEntregaCodPais
        {
            get
            {
                return this.DirEntregaCodPaisField;
            }
            set
            {
                this.DirEntregaCodPaisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=63)]
        public string DirParUbiGeo
        {
            get
            {
                return this.DirParUbiGeoField;
            }
            set
            {
                this.DirParUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=64)]
        public string DirParDireccion
        {
            get
            {
                return this.DirParDireccionField;
            }
            set
            {
                this.DirParDireccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=65)]
        public string DirParUrbaniza
        {
            get
            {
                return this.DirParUrbanizaField;
            }
            set
            {
                this.DirParUrbanizaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=66)]
        public string DirParProvincia
        {
            get
            {
                return this.DirParProvinciaField;
            }
            set
            {
                this.DirParProvinciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=67)]
        public string DirParDepart
        {
            get
            {
                return this.DirParDepartField;
            }
            set
            {
                this.DirParDepartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=68)]
        public string DirParDistrito
        {
            get
            {
                return this.DirParDistritoField;
            }
            set
            {
                this.DirParDistritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=69)]
        public string DirParCodPais
        {
            get
            {
                return this.DirParCodPaisField;
            }
            set
            {
                this.DirParCodPaisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=70)]
        public string DirLlegUbiGeo
        {
            get
            {
                return this.DirLlegUbiGeoField;
            }
            set
            {
                this.DirLlegUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=71)]
        public string DirLlegDireccion
        {
            get
            {
                return this.DirLlegDireccionField;
            }
            set
            {
                this.DirLlegDireccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=72)]
        public string DirLlegUrbaniza
        {
            get
            {
                return this.DirLlegUrbanizaField;
            }
            set
            {
                this.DirLlegUrbanizaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=73)]
        public string DirLlegProvincia
        {
            get
            {
                return this.DirLlegProvinciaField;
            }
            set
            {
                this.DirLlegProvinciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=74)]
        public string DirLlegDepart
        {
            get
            {
                return this.DirLlegDepartField;
            }
            set
            {
                this.DirLlegDepartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=75)]
        public string DirLlegDistrito
        {
            get
            {
                return this.DirLlegDistritoField;
            }
            set
            {
                this.DirLlegDistritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=76)]
        public string DirllegCodPais
        {
            get
            {
                return this.DirllegCodPaisField;
            }
            set
            {
                this.DirllegCodPaisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=77)]
        public string PlacaVehiculo
        {
            get
            {
                return this.PlacaVehiculoField;
            }
            set
            {
                this.PlacaVehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=78)]
        public string CertVehiculo
        {
            get
            {
                return this.CertVehiculoField;
            }
            set
            {
                this.CertVehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=79)]
        public string Marcavehiculo
        {
            get
            {
                return this.MarcavehiculoField;
            }
            set
            {
                this.MarcavehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=80)]
        public string Licencia
        {
            get
            {
                return this.LicenciaField;
            }
            set
            {
                this.LicenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=81)]
        public string RUCTranspor
        {
            get
            {
                return this.RUCTransporField;
            }
            set
            {
                this.RUCTransporField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=82)]
        public string TipoRucTrans
        {
            get
            {
                return this.TipoRucTransField;
            }
            set
            {
                this.TipoRucTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=83)]
        public string RazoTrans
        {
            get
            {
                return this.RazoTransField;
            }
            set
            {
                this.RazoTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=84)]
        public string ModalidadTransporte
        {
            get
            {
                return this.ModalidadTransporteField;
            }
            set
            {
                this.ModalidadTransporteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=85)]
        public string TotalPesoBruto
        {
            get
            {
                return this.TotalPesoBrutoField;
            }
            set
            {
                this.TotalPesoBrutoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=86)]
        public string CodigoLocalAnexo
        {
            get
            {
                return this.CodigoLocalAnexoField;
            }
            set
            {
                this.CodigoLocalAnexoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=87)]
        public string NumPlacaVehi
        {
            get
            {
                return this.NumPlacaVehiField;
            }
            set
            {
                this.NumPlacaVehiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=88)]
        public string ImprDest
        {
            get
            {
                return this.ImprDestField;
            }
            set
            {
                this.ImprDestField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=89)]
        public string NombSucursal
        {
            get
            {
                return this.NombSucursalField;
            }
            set
            {
                this.NombSucursalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=90)]
        public string COLA_IMPRESION
        {
            get
            {
                return this.COLA_IMPRESIONField;
            }
            set
            {
                this.COLA_IMPRESIONField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=91)]
        public string CantidadItem
        {
            get
            {
                return this.CantidadItemField;
            }
            set
            {
                this.CantidadItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=92)]
        public string HoraEmision
        {
            get
            {
                return this.HoraEmisionField;
            }
            set
            {
                this.HoraEmisionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=93)]
        public string CodigoLeyenda
        {
            get
            {
                return this.CodigoLeyendaField;
            }
            set
            {
                this.CodigoLeyendaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=94)]
        public string CODI_EMPR
        {
            get
            {
                return this.CODI_EMPRField;
            }
            set
            {
                this.CODI_EMPRField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=95)]
        public string Estado
        {
            get
            {
                return this.EstadoField;
            }
            set
            {
                this.EstadoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=96)]
        public string Mensaje
        {
            get
            {
                return this.MensajeField;
            }
            set
            {
                this.MensajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=97)]
        public string TpoMoneda
        {
            get
            {
                return this.TpoMonedaField;
            }
            set
            {
                this.TpoMonedaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=98)]
        public string RUTEmisor
        {
            get
            {
                return this.RUTEmisorField;
            }
            set
            {
                this.RUTEmisorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=99)]
        public string CodiComu
        {
            get
            {
                return this.CodiComuField;
            }
            set
            {
                this.CodiComuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=100)]
        public string TipoRUTRecep
        {
            get
            {
                return this.TipoRUTRecepField;
            }
            set
            {
                this.TipoRUTRecepField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=101)]
        public string DirRecepDpto
        {
            get
            {
                return this.DirRecepDptoField;
            }
            set
            {
                this.DirRecepDptoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=102)]
        public string MntTotalAnticipo
        {
            get
            {
                return this.MntTotalAnticipoField;
            }
            set
            {
                this.MntTotalAnticipoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=103)]
        public string DirlleUbiGeo
        {
            get
            {
                return this.DirlleUbiGeoField;
            }
            set
            {
                this.DirlleUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=104)]
        public string TipoOper
        {
            get
            {
                return this.TipoOperField;
            }
            set
            {
                this.TipoOperField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=105)]
        public string CodiSucu
        {
            get
            {
                return this.CodiSucuField;
            }
            set
            {
                this.CodiSucuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=106)]
        public string ColaImpresion
        {
            get
            {
                return this.ColaImpresionField;
            }
            set
            {
                this.ColaImpresionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirRecepUbigeo", EmitDefaultValue=false, Order=107)]
        public string DirRecepUbigeo1
        {
            get
            {
                return this.DirRecepUbigeo1Field;
            }
            set
            {
                this.DirRecepUbigeo1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirEntregaUbigeo", EmitDefaultValue=false, Order=108)]
        public string DirEntregaUbigeo1
        {
            get
            {
                return this.DirEntregaUbigeo1Field;
            }
            set
            {
                this.DirEntregaUbigeo1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirllegUrbaniza", EmitDefaultValue=false, Order=109)]
        public string DirllegUrbaniza1
        {
            get
            {
                return this.DirllegUrbaniza1Field;
            }
            set
            {
                this.DirllegUrbaniza1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirllegDireccion", EmitDefaultValue=false, Order=110)]
        public string DirllegDireccion1
        {
            get
            {
                return this.DirllegDireccion1Field;
            }
            set
            {
                this.DirllegDireccion1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirllegProvincia", EmitDefaultValue=false, Order=111)]
        public string DirllegProvincia1
        {
            get
            {
                return this.DirllegProvincia1Field;
            }
            set
            {
                this.DirllegProvincia1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirllegDepart", EmitDefaultValue=false, Order=112)]
        public string DirllegDepart1
        {
            get
            {
                return this.DirllegDepart1Field;
            }
            set
            {
                this.DirllegDepart1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="DirllegDistrito", EmitDefaultValue=false, Order=113)]
        public string DirllegDistrito1
        {
            get
            {
                return this.DirllegDistrito1Field;
            }
            set
            {
                this.DirllegDistrito1Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImptoReten", Namespace="http://www.dbnet.cl")]
    public partial class ImptoReten : object
    {
        
        private string CodigoImpuestoField;
        
        private string TasaImpuestoField;
        
        private string MontoImpuestoField;
        
        private string MontoImpuestoBaseField;
        
        private string MontoImpField;
        
        private string TasaImpField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string CodigoImpuesto
        {
            get
            {
                return this.CodigoImpuestoField;
            }
            set
            {
                this.CodigoImpuestoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TasaImpuesto
        {
            get
            {
                return this.TasaImpuestoField;
            }
            set
            {
                this.TasaImpuestoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string MontoImpuesto
        {
            get
            {
                return this.MontoImpuestoField;
            }
            set
            {
                this.MontoImpuestoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string MontoImpuestoBase
        {
            get
            {
                return this.MontoImpuestoBaseField;
            }
            set
            {
                this.MontoImpuestoBaseField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string MontoImp
        {
            get
            {
                return this.MontoImpField;
            }
            set
            {
                this.MontoImpField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string TasaImp
        {
            get
            {
                return this.TasaImpField;
            }
            set
            {
                this.TasaImpField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DetaDetraccion", Namespace="http://www.dbnet.cl")]
    public partial class DetaDetraccion : object
    {
        
        private string codiDetraccionField;
        
        private string ValorDetraccionField;
        
        private string MntDetraccionField;
        
        private string PorcentajeDetraccionField;
        
        private string MatriculaHidroField;
        
        private string NomEmbaHidroField;
        
        private string DescEspecieHidroField;
        
        private string LugarDescHidroField;
        
        private string FechaDescHidroField;
        
        private string NumPlacaMTCField;
        
        private string ValorReferPreliminarField;
        
        private string MontoReferencialField;
        
        private string MontoReferPreViajeField;
        
        private string FactorRetornoField;
        
        private string PuntoOrigenField;
        
        private string PuntoDestinoField;
        
        private string CargaEfectivaField;
        
        private string MontoReferVehiculoField;
        
        private string ConfigVehicularField;
        
        private string CargaUtilField;
        
        private string MontoReferTMViajeField;
        
        private string CodiDetraField;
        
        private string ValorDetrField;
        
        private string MntDetraField;
        
        private string PorcentajeDetraField;
        
        private string NomEmbHidroField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string codiDetraccion
        {
            get
            {
                return this.codiDetraccionField;
            }
            set
            {
                this.codiDetraccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ValorDetraccion
        {
            get
            {
                return this.ValorDetraccionField;
            }
            set
            {
                this.ValorDetraccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string MntDetraccion
        {
            get
            {
                return this.MntDetraccionField;
            }
            set
            {
                this.MntDetraccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string PorcentajeDetraccion
        {
            get
            {
                return this.PorcentajeDetraccionField;
            }
            set
            {
                this.PorcentajeDetraccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string MatriculaHidro
        {
            get
            {
                return this.MatriculaHidroField;
            }
            set
            {
                this.MatriculaHidroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string NomEmbaHidro
        {
            get
            {
                return this.NomEmbaHidroField;
            }
            set
            {
                this.NomEmbaHidroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string DescEspecieHidro
        {
            get
            {
                return this.DescEspecieHidroField;
            }
            set
            {
                this.DescEspecieHidroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string LugarDescHidro
        {
            get
            {
                return this.LugarDescHidroField;
            }
            set
            {
                this.LugarDescHidroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string FechaDescHidro
        {
            get
            {
                return this.FechaDescHidroField;
            }
            set
            {
                this.FechaDescHidroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string NumPlacaMTC
        {
            get
            {
                return this.NumPlacaMTCField;
            }
            set
            {
                this.NumPlacaMTCField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string ValorReferPreliminar
        {
            get
            {
                return this.ValorReferPreliminarField;
            }
            set
            {
                this.ValorReferPreliminarField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string MontoReferencial
        {
            get
            {
                return this.MontoReferencialField;
            }
            set
            {
                this.MontoReferencialField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string MontoReferPreViaje
        {
            get
            {
                return this.MontoReferPreViajeField;
            }
            set
            {
                this.MontoReferPreViajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string FactorRetorno
        {
            get
            {
                return this.FactorRetornoField;
            }
            set
            {
                this.FactorRetornoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string PuntoOrigen
        {
            get
            {
                return this.PuntoOrigenField;
            }
            set
            {
                this.PuntoOrigenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string PuntoDestino
        {
            get
            {
                return this.PuntoDestinoField;
            }
            set
            {
                this.PuntoDestinoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string CargaEfectiva
        {
            get
            {
                return this.CargaEfectivaField;
            }
            set
            {
                this.CargaEfectivaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string MontoReferVehiculo
        {
            get
            {
                return this.MontoReferVehiculoField;
            }
            set
            {
                this.MontoReferVehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string ConfigVehicular
        {
            get
            {
                return this.ConfigVehicularField;
            }
            set
            {
                this.ConfigVehicularField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string CargaUtil
        {
            get
            {
                return this.CargaUtilField;
            }
            set
            {
                this.CargaUtilField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string MontoReferTMViaje
        {
            get
            {
                return this.MontoReferTMViajeField;
            }
            set
            {
                this.MontoReferTMViajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string CodiDetra
        {
            get
            {
                return this.CodiDetraField;
            }
            set
            {
                this.CodiDetraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string ValorDetr
        {
            get
            {
                return this.ValorDetrField;
            }
            set
            {
                this.ValorDetrField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string MntDetra
        {
            get
            {
                return this.MntDetraField;
            }
            set
            {
                this.MntDetraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string PorcentajeDetra
        {
            get
            {
                return this.PorcentajeDetraField;
            }
            set
            {
                this.PorcentajeDetraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string NomEmbHidro
        {
            get
            {
                return this.NomEmbHidroField;
            }
            set
            {
                this.NomEmbHidroField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Detalle", Namespace="http://www.dbnet.cl")]
    public partial class Detalle : object
    {
        
        private ServiceReference2.CamposDetalle DetallesField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ServiceReference2.CamposDetalle Detalles
        {
            get
            {
                return this.DetallesField;
            }
            set
            {
                this.DetallesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CamposDetalle", Namespace="http://www.dbnet.cl")]
    public partial class CamposDetalle : object
    {
        
        private int NroLineaField;
        
        private string NroLinDetField;
        
        private string QtyItemField;
        
        private string UnmdItemField;
        
        private string VlrCodigoField;
        
        private string NmbItemField;
        
        private string PrcItemField;
        
        private string PrcItemSinIgvField;
        
        private string MontoItemField;
        
        private string DescuentoMontoField;
        
        private string IndExeField;
        
        private string CodigoTipoIgvField;
        
        private string TasaIgvField;
        
        private string ImpuestoIgvField;
        
        private string CodigoIscField;
        
        private string CodigoTipoIscField;
        
        private string MontoIscField;
        
        private string TasaIscField;
        
        private string CodigoProductoSunatField;
        
        private string CodigoProductoGS1Field;
        
        private string GS1TipoGTINField;
        
        private string DetIndCargoDescuentoField;
        
        private string DetFactorCargoDescuentoField;
        
        private string DetCodigoCargoDescuentoField;
        
        private string DetMontoCargoDescuentoField;
        
        private string DetMBaseCargoDescuentoField;
        
        private string MontoBaseImpField;
        
        private string MontoBaseIscField;
        
        private string CodigoOtrosTributosField;
        
        private string CodigoTipoOtrosTributosField;
        
        private string MontoOtrosTributosField;
        
        private string MontoBaseOtrosTributosField;
        
        private string TasaOtrosTributosField;
        
        private string CodigoTributoBolsaPlasticaField;
        
        private string MontoTributoBolsaPlasticaField;
        
        private string MontoUnitarioBolsaPlasticaField;
        
        private string CantidadBolsaPlasticaField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int NroLinea
        {
            get
            {
                return this.NroLineaField;
            }
            set
            {
                this.NroLineaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string NroLinDet
        {
            get
            {
                return this.NroLinDetField;
            }
            set
            {
                this.NroLinDetField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string QtyItem
        {
            get
            {
                return this.QtyItemField;
            }
            set
            {
                this.QtyItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string UnmdItem
        {
            get
            {
                return this.UnmdItemField;
            }
            set
            {
                this.UnmdItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string VlrCodigo
        {
            get
            {
                return this.VlrCodigoField;
            }
            set
            {
                this.VlrCodigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string NmbItem
        {
            get
            {
                return this.NmbItemField;
            }
            set
            {
                this.NmbItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string PrcItem
        {
            get
            {
                return this.PrcItemField;
            }
            set
            {
                this.PrcItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string PrcItemSinIgv
        {
            get
            {
                return this.PrcItemSinIgvField;
            }
            set
            {
                this.PrcItemSinIgvField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string MontoItem
        {
            get
            {
                return this.MontoItemField;
            }
            set
            {
                this.MontoItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string DescuentoMonto
        {
            get
            {
                return this.DescuentoMontoField;
            }
            set
            {
                this.DescuentoMontoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string IndExe
        {
            get
            {
                return this.IndExeField;
            }
            set
            {
                this.IndExeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string CodigoTipoIgv
        {
            get
            {
                return this.CodigoTipoIgvField;
            }
            set
            {
                this.CodigoTipoIgvField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string TasaIgv
        {
            get
            {
                return this.TasaIgvField;
            }
            set
            {
                this.TasaIgvField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string ImpuestoIgv
        {
            get
            {
                return this.ImpuestoIgvField;
            }
            set
            {
                this.ImpuestoIgvField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string CodigoIsc
        {
            get
            {
                return this.CodigoIscField;
            }
            set
            {
                this.CodigoIscField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string CodigoTipoIsc
        {
            get
            {
                return this.CodigoTipoIscField;
            }
            set
            {
                this.CodigoTipoIscField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string MontoIsc
        {
            get
            {
                return this.MontoIscField;
            }
            set
            {
                this.MontoIscField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string TasaIsc
        {
            get
            {
                return this.TasaIscField;
            }
            set
            {
                this.TasaIscField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string CodigoProductoSunat
        {
            get
            {
                return this.CodigoProductoSunatField;
            }
            set
            {
                this.CodigoProductoSunatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string CodigoProductoGS1
        {
            get
            {
                return this.CodigoProductoGS1Field;
            }
            set
            {
                this.CodigoProductoGS1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string GS1TipoGTIN
        {
            get
            {
                return this.GS1TipoGTINField;
            }
            set
            {
                this.GS1TipoGTINField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string DetIndCargoDescuento
        {
            get
            {
                return this.DetIndCargoDescuentoField;
            }
            set
            {
                this.DetIndCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string DetFactorCargoDescuento
        {
            get
            {
                return this.DetFactorCargoDescuentoField;
            }
            set
            {
                this.DetFactorCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string DetCodigoCargoDescuento
        {
            get
            {
                return this.DetCodigoCargoDescuentoField;
            }
            set
            {
                this.DetCodigoCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string DetMontoCargoDescuento
        {
            get
            {
                return this.DetMontoCargoDescuentoField;
            }
            set
            {
                this.DetMontoCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string DetMBaseCargoDescuento
        {
            get
            {
                return this.DetMBaseCargoDescuentoField;
            }
            set
            {
                this.DetMBaseCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=26)]
        public string MontoBaseImp
        {
            get
            {
                return this.MontoBaseImpField;
            }
            set
            {
                this.MontoBaseImpField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=27)]
        public string MontoBaseIsc
        {
            get
            {
                return this.MontoBaseIscField;
            }
            set
            {
                this.MontoBaseIscField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=28)]
        public string CodigoOtrosTributos
        {
            get
            {
                return this.CodigoOtrosTributosField;
            }
            set
            {
                this.CodigoOtrosTributosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=29)]
        public string CodigoTipoOtrosTributos
        {
            get
            {
                return this.CodigoTipoOtrosTributosField;
            }
            set
            {
                this.CodigoTipoOtrosTributosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=30)]
        public string MontoOtrosTributos
        {
            get
            {
                return this.MontoOtrosTributosField;
            }
            set
            {
                this.MontoOtrosTributosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=31)]
        public string MontoBaseOtrosTributos
        {
            get
            {
                return this.MontoBaseOtrosTributosField;
            }
            set
            {
                this.MontoBaseOtrosTributosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=32)]
        public string TasaOtrosTributos
        {
            get
            {
                return this.TasaOtrosTributosField;
            }
            set
            {
                this.TasaOtrosTributosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=33)]
        public string CodigoTributoBolsaPlastica
        {
            get
            {
                return this.CodigoTributoBolsaPlasticaField;
            }
            set
            {
                this.CodigoTributoBolsaPlasticaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=34)]
        public string MontoTributoBolsaPlastica
        {
            get
            {
                return this.MontoTributoBolsaPlasticaField;
            }
            set
            {
                this.MontoTributoBolsaPlasticaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=35)]
        public string MontoUnitarioBolsaPlastica
        {
            get
            {
                return this.MontoUnitarioBolsaPlasticaField;
            }
            set
            {
                this.MontoUnitarioBolsaPlasticaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=36)]
        public string CantidadBolsaPlastica
        {
            get
            {
                return this.CantidadBolsaPlasticaField;
            }
            set
            {
                this.CantidadBolsaPlasticaField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DescuentosRecargosyOtros", Namespace="http://www.dbnet.cl")]
    public partial class DescuentosRecargosyOtros : object
    {
        
        private ServiceReference2.Descuentos[] DescuentosField;
        
        private ServiceReference2.Descuentos[] CargosDescuentosLineaField;
        
        private ServiceReference2.DatosAdicionales[] DatosAdicionalesField;
        
        private ServiceReference2.Referencias[] ReferenciasField;
        
        private ServiceReference2.Anticipos[] AnticiposField;
        
        private ServiceReference2.DatosGuia[] DatosGuiaField;
        
        private ServiceReference2.Tramo[] TramoField;
        
        private ServiceReference2.Conductor[] ConductorField;
        
        private ServiceReference2.PuertoAeropuerto[] PuertoAeropuertoField;
        
        private ServiceReference2.Transporte[] TransportesField;
        
        private ServiceReference2.PropiedadAdicional[] PropiedadesAdicionalesField;
        
        private ServiceReference2.TransporteCarga[] TransportesCargaField;
        
        private ServiceReference2.TramoCarga[] TramosCargaField;
        
        private ServiceReference2.Vehiculo[] VehiculosField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ServiceReference2.Descuentos[] Descuentos
        {
            get
            {
                return this.DescuentosField;
            }
            set
            {
                this.DescuentosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public ServiceReference2.Descuentos[] CargosDescuentosLinea
        {
            get
            {
                return this.CargosDescuentosLineaField;
            }
            set
            {
                this.CargosDescuentosLineaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public ServiceReference2.DatosAdicionales[] DatosAdicionales
        {
            get
            {
                return this.DatosAdicionalesField;
            }
            set
            {
                this.DatosAdicionalesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public ServiceReference2.Referencias[] Referencias
        {
            get
            {
                return this.ReferenciasField;
            }
            set
            {
                this.ReferenciasField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public ServiceReference2.Anticipos[] Anticipos
        {
            get
            {
                return this.AnticiposField;
            }
            set
            {
                this.AnticiposField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public ServiceReference2.DatosGuia[] DatosGuia
        {
            get
            {
                return this.DatosGuiaField;
            }
            set
            {
                this.DatosGuiaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public ServiceReference2.Tramo[] Tramo
        {
            get
            {
                return this.TramoField;
            }
            set
            {
                this.TramoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public ServiceReference2.Conductor[] Conductor
        {
            get
            {
                return this.ConductorField;
            }
            set
            {
                this.ConductorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public ServiceReference2.PuertoAeropuerto[] PuertoAeropuerto
        {
            get
            {
                return this.PuertoAeropuertoField;
            }
            set
            {
                this.PuertoAeropuertoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public ServiceReference2.Transporte[] Transportes
        {
            get
            {
                return this.TransportesField;
            }
            set
            {
                this.TransportesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public ServiceReference2.PropiedadAdicional[] PropiedadesAdicionales
        {
            get
            {
                return this.PropiedadesAdicionalesField;
            }
            set
            {
                this.PropiedadesAdicionalesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public ServiceReference2.TransporteCarga[] TransportesCarga
        {
            get
            {
                return this.TransportesCargaField;
            }
            set
            {
                this.TransportesCargaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public ServiceReference2.TramoCarga[] TramosCarga
        {
            get
            {
                return this.TramosCargaField;
            }
            set
            {
                this.TramosCargaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public ServiceReference2.Vehiculo[] Vehiculos
        {
            get
            {
                return this.VehiculosField;
            }
            set
            {
                this.VehiculosField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Descuentos", Namespace="http://www.dbnet.cl")]
    public partial class Descuentos : object
    {
        
        private string NroLinDRField;
        
        private string TpoMovField;
        
        private string ValorDRField;
        
        private string IndCargoDescuentoField;
        
        private string MBaseCargoDescuentoField;
        
        private string CodigoCargoDescuentoField;
        
        private string FactorCargoDescuentoField;
        
        private string MontoCargoDescuentoField;
        
        private string NroLinDetField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinDR
        {
            get
            {
                return this.NroLinDRField;
            }
            set
            {
                this.NroLinDRField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TpoMov
        {
            get
            {
                return this.TpoMovField;
            }
            set
            {
                this.TpoMovField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ValorDR
        {
            get
            {
                return this.ValorDRField;
            }
            set
            {
                this.ValorDRField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string IndCargoDescuento
        {
            get
            {
                return this.IndCargoDescuentoField;
            }
            set
            {
                this.IndCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string MBaseCargoDescuento
        {
            get
            {
                return this.MBaseCargoDescuentoField;
            }
            set
            {
                this.MBaseCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string CodigoCargoDescuento
        {
            get
            {
                return this.CodigoCargoDescuentoField;
            }
            set
            {
                this.CodigoCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string FactorCargoDescuento
        {
            get
            {
                return this.FactorCargoDescuentoField;
            }
            set
            {
                this.FactorCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string MontoCargoDescuento
        {
            get
            {
                return this.MontoCargoDescuentoField;
            }
            set
            {
                this.MontoCargoDescuentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string NroLinDet
        {
            get
            {
                return this.NroLinDetField;
            }
            set
            {
                this.NroLinDetField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DatosAdicionales", Namespace="http://www.dbnet.cl")]
    public partial class DatosAdicionales : object
    {
        
        private string TipoAdicSunatField;
        
        private string NmrLineasDetalleField;
        
        private string NmrLineasAdicSunatField;
        
        private string DescripcionAdicsunatField;
        
        private string ImprDestField;
        
        private string val1Field;
        
        private string val2Field;
        
        private string val3Field;
        
        private string val4Field;
        
        private string val5Field;
        
        private string val6Field;
        
        private string val7Field;
        
        private string val8Field;
        
        private string val9Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TipoAdicSunat
        {
            get
            {
                return this.TipoAdicSunatField;
            }
            set
            {
                this.TipoAdicSunatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string NmrLineasDetalle
        {
            get
            {
                return this.NmrLineasDetalleField;
            }
            set
            {
                this.NmrLineasDetalleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string NmrLineasAdicSunat
        {
            get
            {
                return this.NmrLineasAdicSunatField;
            }
            set
            {
                this.NmrLineasAdicSunatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string DescripcionAdicsunat
        {
            get
            {
                return this.DescripcionAdicsunatField;
            }
            set
            {
                this.DescripcionAdicsunatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string ImprDest
        {
            get
            {
                return this.ImprDestField;
            }
            set
            {
                this.ImprDestField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string val1
        {
            get
            {
                return this.val1Field;
            }
            set
            {
                this.val1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string val2
        {
            get
            {
                return this.val2Field;
            }
            set
            {
                this.val2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string val3
        {
            get
            {
                return this.val3Field;
            }
            set
            {
                this.val3Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string val4
        {
            get
            {
                return this.val4Field;
            }
            set
            {
                this.val4Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string val5
        {
            get
            {
                return this.val5Field;
            }
            set
            {
                this.val5Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string val6
        {
            get
            {
                return this.val6Field;
            }
            set
            {
                this.val6Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string val7
        {
            get
            {
                return this.val7Field;
            }
            set
            {
                this.val7Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string val8
        {
            get
            {
                return this.val8Field;
            }
            set
            {
                this.val8Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string val9
        {
            get
            {
                return this.val9Field;
            }
            set
            {
                this.val9Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Referencias", Namespace="http://www.dbnet.cl")]
    public partial class Referencias : object
    {
        
        private string NroLinRefField;
        
        private string TpoDocRefField;
        
        private string SerieRefField;
        
        private string FolioRefField;
        
        private string TipoRefField;
        
        private string RucRefField;
        
        private string FechEmisDocRefField;
        
        private string MntTotalDocRefField;
        
        private string MonedaDocRefField;
        
        private string FechOperacionField;
        
        private string NroOperacionField;
        
        private string ImporteOperacionField;
        
        private string MonedaOperacionField;
        
        private string ImporteMovimientoField;
        
        private string MonedaMovimientoField;
        
        private string FechaMovimientoField;
        
        private string TotalMovimientoField;
        
        private string MonedaField;
        
        private string MonedaReferenciaField;
        
        private string MonedaObjetivoField;
        
        private string TipoCambioField;
        
        private string FechTipoCambioField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinRef
        {
            get
            {
                return this.NroLinRefField;
            }
            set
            {
                this.NroLinRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TpoDocRef
        {
            get
            {
                return this.TpoDocRefField;
            }
            set
            {
                this.TpoDocRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string SerieRef
        {
            get
            {
                return this.SerieRefField;
            }
            set
            {
                this.SerieRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string FolioRef
        {
            get
            {
                return this.FolioRefField;
            }
            set
            {
                this.FolioRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string TipoRef
        {
            get
            {
                return this.TipoRefField;
            }
            set
            {
                this.TipoRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RucRef
        {
            get
            {
                return this.RucRefField;
            }
            set
            {
                this.RucRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string FechEmisDocRef
        {
            get
            {
                return this.FechEmisDocRefField;
            }
            set
            {
                this.FechEmisDocRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string MntTotalDocRef
        {
            get
            {
                return this.MntTotalDocRefField;
            }
            set
            {
                this.MntTotalDocRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string MonedaDocRef
        {
            get
            {
                return this.MonedaDocRefField;
            }
            set
            {
                this.MonedaDocRefField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string FechOperacion
        {
            get
            {
                return this.FechOperacionField;
            }
            set
            {
                this.FechOperacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string NroOperacion
        {
            get
            {
                return this.NroOperacionField;
            }
            set
            {
                this.NroOperacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string ImporteOperacion
        {
            get
            {
                return this.ImporteOperacionField;
            }
            set
            {
                this.ImporteOperacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string MonedaOperacion
        {
            get
            {
                return this.MonedaOperacionField;
            }
            set
            {
                this.MonedaOperacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string ImporteMovimiento
        {
            get
            {
                return this.ImporteMovimientoField;
            }
            set
            {
                this.ImporteMovimientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string MonedaMovimiento
        {
            get
            {
                return this.MonedaMovimientoField;
            }
            set
            {
                this.MonedaMovimientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string FechaMovimiento
        {
            get
            {
                return this.FechaMovimientoField;
            }
            set
            {
                this.FechaMovimientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string TotalMovimiento
        {
            get
            {
                return this.TotalMovimientoField;
            }
            set
            {
                this.TotalMovimientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string Moneda
        {
            get
            {
                return this.MonedaField;
            }
            set
            {
                this.MonedaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string MonedaReferencia
        {
            get
            {
                return this.MonedaReferenciaField;
            }
            set
            {
                this.MonedaReferenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string MonedaObjetivo
        {
            get
            {
                return this.MonedaObjetivoField;
            }
            set
            {
                this.MonedaObjetivoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string TipoCambio
        {
            get
            {
                return this.TipoCambioField;
            }
            set
            {
                this.TipoCambioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string FechTipoCambio
        {
            get
            {
                return this.FechTipoCambioField;
            }
            set
            {
                this.FechTipoCambioField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Anticipos", Namespace="http://www.dbnet.cl")]
    public partial class Anticipos : object
    {
        
        private string NroLinAntiField;
        
        private string MontoAntiField;
        
        private string TipoDocAntiField;
        
        private string SerieAntiField;
        
        private string FolioAntiField;
        
        private string RucAnticipoField;
        
        private string FechPagoAntiField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinAnti
        {
            get
            {
                return this.NroLinAntiField;
            }
            set
            {
                this.NroLinAntiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string MontoAnti
        {
            get
            {
                return this.MontoAntiField;
            }
            set
            {
                this.MontoAntiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string TipoDocAnti
        {
            get
            {
                return this.TipoDocAntiField;
            }
            set
            {
                this.TipoDocAntiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string SerieAnti
        {
            get
            {
                return this.SerieAntiField;
            }
            set
            {
                this.SerieAntiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string FolioAnti
        {
            get
            {
                return this.FolioAntiField;
            }
            set
            {
                this.FolioAntiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RucAnticipo
        {
            get
            {
                return this.RucAnticipoField;
            }
            set
            {
                this.RucAnticipoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string FechPagoAnti
        {
            get
            {
                return this.FechPagoAntiField;
            }
            set
            {
                this.FechPagoAntiField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DatosGuia", Namespace="http://www.dbnet.cl")]
    public partial class DatosGuia : object
    {
        
        private string ObservacionesField;
        
        private string MotivoTrasladoField;
        
        private string DescTrasladoField;
        
        private string IndTrasbordoField;
        
        private string TotalPesoTrasladoField;
        
        private string NroBultosField;
        
        private string IdContenedorField;
        
        private string RucTerceroField;
        
        private string TipoRucTerceroField;
        
        private string RazonTerceroField;
        
        private string DirParUbiGeoField;
        
        private string DirParDireccionField;
        
        private string DirLlegUbiGeoField;
        
        private string DirLlegDireccionField;
        
        private string DirParUrbanizaField;
        
        private string DirllegUrbanizaField;
        
        private string DirParDepartField;
        
        private string DirParDistritoField;
        
        private string DirParCodPaisField;
        
        private string DirParProvinciaField;
        
        private string DirLlegProvinciaField;
        
        private string DirLlegDepartField;
        
        private string DirLlegDistritoField;
        
        private string DirLlegCodPaisField;
        
        private string PlacaVehiculoField;
        
        private string CertVehiculoField;
        
        private string MarcavehiculoField;
        
        private string LicenciaField;
        
        private string TotalPesoBrutoField;
        
        private string TipoRucTransField;
        
        private string RazoTransField;
        
        private string ModalidadTransporteField;
        
        private string RUCTransporField;
        
        private string UnidadMedidaField;
        
        private string NumeroRegistroMTCField;
        
        private string MontoReferencialField;
        
        private string MontoReferencialMonedaField;
        
        private string IndSubcontratacionField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Observaciones
        {
            get
            {
                return this.ObservacionesField;
            }
            set
            {
                this.ObservacionesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string MotivoTraslado
        {
            get
            {
                return this.MotivoTrasladoField;
            }
            set
            {
                this.MotivoTrasladoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string DescTraslado
        {
            get
            {
                return this.DescTrasladoField;
            }
            set
            {
                this.DescTrasladoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string IndTrasbordo
        {
            get
            {
                return this.IndTrasbordoField;
            }
            set
            {
                this.IndTrasbordoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string TotalPesoTraslado
        {
            get
            {
                return this.TotalPesoTrasladoField;
            }
            set
            {
                this.TotalPesoTrasladoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string NroBultos
        {
            get
            {
                return this.NroBultosField;
            }
            set
            {
                this.NroBultosField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string IdContenedor
        {
            get
            {
                return this.IdContenedorField;
            }
            set
            {
                this.IdContenedorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string RucTercero
        {
            get
            {
                return this.RucTerceroField;
            }
            set
            {
                this.RucTerceroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string TipoRucTercero
        {
            get
            {
                return this.TipoRucTerceroField;
            }
            set
            {
                this.TipoRucTerceroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string RazonTercero
        {
            get
            {
                return this.RazonTerceroField;
            }
            set
            {
                this.RazonTerceroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string DirParUbiGeo
        {
            get
            {
                return this.DirParUbiGeoField;
            }
            set
            {
                this.DirParUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string DirParDireccion
        {
            get
            {
                return this.DirParDireccionField;
            }
            set
            {
                this.DirParDireccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string DirLlegUbiGeo
        {
            get
            {
                return this.DirLlegUbiGeoField;
            }
            set
            {
                this.DirLlegUbiGeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string DirLlegDireccion
        {
            get
            {
                return this.DirLlegDireccionField;
            }
            set
            {
                this.DirLlegDireccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string DirParUrbaniza
        {
            get
            {
                return this.DirParUrbanizaField;
            }
            set
            {
                this.DirParUrbanizaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string DirllegUrbaniza
        {
            get
            {
                return this.DirllegUrbanizaField;
            }
            set
            {
                this.DirllegUrbanizaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string DirParDepart
        {
            get
            {
                return this.DirParDepartField;
            }
            set
            {
                this.DirParDepartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string DirParDistrito
        {
            get
            {
                return this.DirParDistritoField;
            }
            set
            {
                this.DirParDistritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string DirParCodPais
        {
            get
            {
                return this.DirParCodPaisField;
            }
            set
            {
                this.DirParCodPaisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string DirParProvincia
        {
            get
            {
                return this.DirParProvinciaField;
            }
            set
            {
                this.DirParProvinciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string DirLlegProvincia
        {
            get
            {
                return this.DirLlegProvinciaField;
            }
            set
            {
                this.DirLlegProvinciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string DirLlegDepart
        {
            get
            {
                return this.DirLlegDepartField;
            }
            set
            {
                this.DirLlegDepartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string DirLlegDistrito
        {
            get
            {
                return this.DirLlegDistritoField;
            }
            set
            {
                this.DirLlegDistritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string DirLlegCodPais
        {
            get
            {
                return this.DirLlegCodPaisField;
            }
            set
            {
                this.DirLlegCodPaisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string PlacaVehiculo
        {
            get
            {
                return this.PlacaVehiculoField;
            }
            set
            {
                this.PlacaVehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string CertVehiculo
        {
            get
            {
                return this.CertVehiculoField;
            }
            set
            {
                this.CertVehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=26)]
        public string Marcavehiculo
        {
            get
            {
                return this.MarcavehiculoField;
            }
            set
            {
                this.MarcavehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=27)]
        public string Licencia
        {
            get
            {
                return this.LicenciaField;
            }
            set
            {
                this.LicenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=28)]
        public string TotalPesoBruto
        {
            get
            {
                return this.TotalPesoBrutoField;
            }
            set
            {
                this.TotalPesoBrutoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=29)]
        public string TipoRucTrans
        {
            get
            {
                return this.TipoRucTransField;
            }
            set
            {
                this.TipoRucTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=30)]
        public string RazoTrans
        {
            get
            {
                return this.RazoTransField;
            }
            set
            {
                this.RazoTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=31)]
        public string ModalidadTransporte
        {
            get
            {
                return this.ModalidadTransporteField;
            }
            set
            {
                this.ModalidadTransporteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=32)]
        public string RUCTranspor
        {
            get
            {
                return this.RUCTransporField;
            }
            set
            {
                this.RUCTransporField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=33)]
        public string UnidadMedida
        {
            get
            {
                return this.UnidadMedidaField;
            }
            set
            {
                this.UnidadMedidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=34)]
        public string NumeroRegistroMTC
        {
            get
            {
                return this.NumeroRegistroMTCField;
            }
            set
            {
                this.NumeroRegistroMTCField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=35)]
        public string MontoReferencial
        {
            get
            {
                return this.MontoReferencialField;
            }
            set
            {
                this.MontoReferencialField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=36)]
        public string MontoReferencialMoneda
        {
            get
            {
                return this.MontoReferencialMonedaField;
            }
            set
            {
                this.MontoReferencialMonedaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=37)]
        public string IndSubcontratacion
        {
            get
            {
                return this.IndSubcontratacionField;
            }
            set
            {
                this.IndSubcontratacionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tramo", Namespace="http://www.dbnet.cl")]
    public partial class Tramo : object
    {
        
        private string NroLinTramoField;
        
        private string ModalidadTrasladoField;
        
        private string FechInicioTrasladoField;
        
        private string RUCTransporField;
        
        private string TipoRucTransField;
        
        private string RazoTransField;
        
        private string CertVehiculoField;
        
        private string PlacaVehiculoField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinTramo
        {
            get
            {
                return this.NroLinTramoField;
            }
            set
            {
                this.NroLinTramoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ModalidadTraslado
        {
            get
            {
                return this.ModalidadTrasladoField;
            }
            set
            {
                this.ModalidadTrasladoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string FechInicioTraslado
        {
            get
            {
                return this.FechInicioTrasladoField;
            }
            set
            {
                this.FechInicioTrasladoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string RUCTranspor
        {
            get
            {
                return this.RUCTransporField;
            }
            set
            {
                this.RUCTransporField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string TipoRucTrans
        {
            get
            {
                return this.TipoRucTransField;
            }
            set
            {
                this.TipoRucTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RazoTrans
        {
            get
            {
                return this.RazoTransField;
            }
            set
            {
                this.RazoTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string CertVehiculo
        {
            get
            {
                return this.CertVehiculoField;
            }
            set
            {
                this.CertVehiculoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string PlacaVehiculo
        {
            get
            {
                return this.PlacaVehiculoField;
            }
            set
            {
                this.PlacaVehiculoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Conductor", Namespace="http://www.dbnet.cl")]
    public partial class Conductor : object
    {
        
        private string NroLinConductorField;
        
        private string ConductorNroDocIdField;
        
        private string ConductorTipoDocIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinConductor
        {
            get
            {
                return this.NroLinConductorField;
            }
            set
            {
                this.NroLinConductorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string ConductorNroDocId
        {
            get
            {
                return this.ConductorNroDocIdField;
            }
            set
            {
                this.ConductorNroDocIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ConductorTipoDocId
        {
            get
            {
                return this.ConductorTipoDocIdField;
            }
            set
            {
                this.ConductorTipoDocIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PuertoAeropuerto", Namespace="http://www.dbnet.cl")]
    public partial class PuertoAeropuerto : object
    {
        
        private string NroLinPuertoAeropField;
        
        private string IdPuertoAeropField;
        
        private string NmbPuertoAeropField;
        
        private string TipoPuertoAeropField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinPuertoAerop
        {
            get
            {
                return this.NroLinPuertoAeropField;
            }
            set
            {
                this.NroLinPuertoAeropField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string IdPuertoAerop
        {
            get
            {
                return this.IdPuertoAeropField;
            }
            set
            {
                this.IdPuertoAeropField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string NmbPuertoAerop
        {
            get
            {
                return this.NmbPuertoAeropField;
            }
            set
            {
                this.NmbPuertoAeropField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string TipoPuertoAerop
        {
            get
            {
                return this.TipoPuertoAeropField;
            }
            set
            {
                this.TipoPuertoAeropField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Transporte", Namespace="http://www.dbnet.cl")]
    public partial class Transporte : object
    {
        
        private string NroDetalleField;
        
        private string DestinoPasajeroField;
        
        private string FechaSalidaField;
        
        private string HoraSalidaField;
        
        private string ManifiestoPasajeroField;
        
        private string NombPasajeroField;
        
        private string NumAsientoField;
        
        private string NumDocPasajeroField;
        
        private string OrigenPasajeroField;
        
        private string TipoDocPasajeroField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroDetalle
        {
            get
            {
                return this.NroDetalleField;
            }
            set
            {
                this.NroDetalleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string DestinoPasajero
        {
            get
            {
                return this.DestinoPasajeroField;
            }
            set
            {
                this.DestinoPasajeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string FechaSalida
        {
            get
            {
                return this.FechaSalidaField;
            }
            set
            {
                this.FechaSalidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string HoraSalida
        {
            get
            {
                return this.HoraSalidaField;
            }
            set
            {
                this.HoraSalidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string ManifiestoPasajero
        {
            get
            {
                return this.ManifiestoPasajeroField;
            }
            set
            {
                this.ManifiestoPasajeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string NombPasajero
        {
            get
            {
                return this.NombPasajeroField;
            }
            set
            {
                this.NombPasajeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string NumAsiento
        {
            get
            {
                return this.NumAsientoField;
            }
            set
            {
                this.NumAsientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string NumDocPasajero
        {
            get
            {
                return this.NumDocPasajeroField;
            }
            set
            {
                this.NumDocPasajeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string OrigenPasajero
        {
            get
            {
                return this.OrigenPasajeroField;
            }
            set
            {
                this.OrigenPasajeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string TipoDocPasajero
        {
            get
            {
                return this.TipoDocPasajeroField;
            }
            set
            {
                this.TipoDocPasajeroField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PropiedadAdicional", Namespace="http://www.dbnet.cl")]
    public partial class PropiedadAdicional : object
    {
        
        private string NroLinDetField;
        
        private string CodConTribField;
        
        private string ValConTribField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NroLinDet
        {
            get
            {
                return this.NroLinDetField;
            }
            set
            {
                this.NroLinDetField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string CodConTrib
        {
            get
            {
                return this.CodConTribField;
            }
            set
            {
                this.CodConTribField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ValConTrib
        {
            get
            {
                return this.ValConTribField;
            }
            set
            {
                this.ValConTribField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransporteCarga", Namespace="http://www.dbnet.cl")]
    public partial class TransporteCarga : object
    {
        
        private string TransPuntoOrigenUbigeoField;
        
        private string TransPuntoOrigenDireccionField;
        
        private string TransPuntoDestinoUbigeoField;
        
        private string TransPuntoDestinoDireccionField;
        
        private string TransDetalleViajeField;
        
        private string TransValorRefServicioField;
        
        private string TransValorRefCargaEfectivaField;
        
        private string TransValorRefCargaUtilField;
        
        private string IdentificadorServicioField;
        
        private string NroLinDetField;
        
        private string NroLinTransField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TransPuntoOrigenUbigeo
        {
            get
            {
                return this.TransPuntoOrigenUbigeoField;
            }
            set
            {
                this.TransPuntoOrigenUbigeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string TransPuntoOrigenDireccion
        {
            get
            {
                return this.TransPuntoOrigenDireccionField;
            }
            set
            {
                this.TransPuntoOrigenDireccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string TransPuntoDestinoUbigeo
        {
            get
            {
                return this.TransPuntoDestinoUbigeoField;
            }
            set
            {
                this.TransPuntoDestinoUbigeoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string TransPuntoDestinoDireccion
        {
            get
            {
                return this.TransPuntoDestinoDireccionField;
            }
            set
            {
                this.TransPuntoDestinoDireccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string TransDetalleViaje
        {
            get
            {
                return this.TransDetalleViajeField;
            }
            set
            {
                this.TransDetalleViajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string TransValorRefServicio
        {
            get
            {
                return this.TransValorRefServicioField;
            }
            set
            {
                this.TransValorRefServicioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string TransValorRefCargaEfectiva
        {
            get
            {
                return this.TransValorRefCargaEfectivaField;
            }
            set
            {
                this.TransValorRefCargaEfectivaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string TransValorRefCargaUtil
        {
            get
            {
                return this.TransValorRefCargaUtilField;
            }
            set
            {
                this.TransValorRefCargaUtilField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string IdentificadorServicio
        {
            get
            {
                return this.IdentificadorServicioField;
            }
            set
            {
                this.IdentificadorServicioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string NroLinDet
        {
            get
            {
                return this.NroLinDetField;
            }
            set
            {
                this.NroLinDetField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string NroLinTrans
        {
            get
            {
                return this.NroLinTransField;
            }
            set
            {
                this.NroLinTransField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TramoCarga", Namespace="http://www.dbnet.cl")]
    public partial class TramoCarga : object
    {
        
        private string TramoPuntoOrigenField;
        
        private string TramoPuntoDestinoField;
        
        private string TramoDescripcionField;
        
        private string TramoIdentificadorField;
        
        private string TramoValorRefCargaEfectivaField;
        
        private string TramoValorRefCargaUtilField;
        
        private string NroLinTransField;
        
        private string NroLinTramoField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TramoPuntoOrigen
        {
            get
            {
                return this.TramoPuntoOrigenField;
            }
            set
            {
                this.TramoPuntoOrigenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string TramoPuntoDestino
        {
            get
            {
                return this.TramoPuntoDestinoField;
            }
            set
            {
                this.TramoPuntoDestinoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string TramoDescripcion
        {
            get
            {
                return this.TramoDescripcionField;
            }
            set
            {
                this.TramoDescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string TramoIdentificador
        {
            get
            {
                return this.TramoIdentificadorField;
            }
            set
            {
                this.TramoIdentificadorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string TramoValorRefCargaEfectiva
        {
            get
            {
                return this.TramoValorRefCargaEfectivaField;
            }
            set
            {
                this.TramoValorRefCargaEfectivaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string TramoValorRefCargaUtil
        {
            get
            {
                return this.TramoValorRefCargaUtilField;
            }
            set
            {
                this.TramoValorRefCargaUtilField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string NroLinTrans
        {
            get
            {
                return this.NroLinTransField;
            }
            set
            {
                this.NroLinTransField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string NroLinTramo
        {
            get
            {
                return this.NroLinTramoField;
            }
            set
            {
                this.NroLinTramoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Vehiculo", Namespace="http://www.dbnet.cl")]
    public partial class Vehiculo : object
    {
        
        private string VehiculoConfiguracionField;
        
        private string VehiculoValorRefPorTMField;
        
        private string VehiculoIndFactorRetornoField;
        
        private string VehiculoCargaUtilField;
        
        private string VehiculoCargaEfectivaField;
        
        private string NroLinTramoField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string VehiculoConfiguracion
        {
            get
            {
                return this.VehiculoConfiguracionField;
            }
            set
            {
                this.VehiculoConfiguracionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string VehiculoValorRefPorTM
        {
            get
            {
                return this.VehiculoValorRefPorTMField;
            }
            set
            {
                this.VehiculoValorRefPorTMField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string VehiculoIndFactorRetorno
        {
            get
            {
                return this.VehiculoIndFactorRetornoField;
            }
            set
            {
                this.VehiculoIndFactorRetornoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string VehiculoCargaUtil
        {
            get
            {
                return this.VehiculoCargaUtilField;
            }
            set
            {
                this.VehiculoCargaUtilField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string VehiculoCargaEfectiva
        {
            get
            {
                return this.VehiculoCargaEfectivaField;
            }
            set
            {
                this.VehiculoCargaEfectivaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string NroLinTramo
        {
            get
            {
                return this.NroLinTramoField;
            }
            set
            {
                this.NroLinTramoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mensaje", Namespace="http://www.dbnet.cl")]
    public partial class Mensaje : object
    {
        
        private string CodigoField;
        
        private string MensajesField;
        
        private string TrackIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Codigo
        {
            get
            {
                return this.CodigoField;
            }
            set
            {
                this.CodigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Mensajes
        {
            get
            {
                return this.MensajesField;
            }
            set
            {
                this.MensajesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TrackId
        {
            get
            {
                return this.TrackIdField;
            }
            set
            {
                this.TrackIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.dbnet.cl", ConfigurationName="ServiceReference2.CustomerETDLoadASPSoap")]
    public interface CustomerETDLoadASPSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dbnet.cl/putCustomerETDLoad", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference2.putCustomerETDLoadResponse> putCustomerETDLoadAsync(ServiceReference2.putCustomerETDLoadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.dbnet.cl/putCustomerETDLoadXML", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference2.putCustomerETDLoadXMLResponse> putCustomerETDLoadXMLAsync(ServiceReference2.putCustomerETDLoadXMLRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class putCustomerETDLoadRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="putCustomerETDLoad", Namespace="http://www.dbnet.cl", Order=0)]
        public ServiceReference2.putCustomerETDLoadRequestBody Body;
        
        public putCustomerETDLoadRequest()
        {
        }
        
        public putCustomerETDLoadRequest(ServiceReference2.putCustomerETDLoadRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.dbnet.cl")]
    public partial class putCustomerETDLoadRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference2.Extras Extras;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public ServiceReference2.Encabezado Encabezado;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public ServiceReference2.Detalle[] Detalles;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public ServiceReference2.DescuentosRecargosyOtros DescuentosRecargosyOtros;
        
        public putCustomerETDLoadRequestBody()
        {
        }
        
        public putCustomerETDLoadRequestBody(ServiceReference2.Extras Extras, ServiceReference2.Encabezado Encabezado, ServiceReference2.Detalle[] Detalles, ServiceReference2.DescuentosRecargosyOtros DescuentosRecargosyOtros)
        {
            this.Extras = Extras;
            this.Encabezado = Encabezado;
            this.Detalles = Detalles;
            this.DescuentosRecargosyOtros = DescuentosRecargosyOtros;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class putCustomerETDLoadResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="putCustomerETDLoadResponse", Namespace="http://www.dbnet.cl", Order=0)]
        public ServiceReference2.putCustomerETDLoadResponseBody Body;
        
        public putCustomerETDLoadResponse()
        {
        }
        
        public putCustomerETDLoadResponse(ServiceReference2.putCustomerETDLoadResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.dbnet.cl")]
    public partial class putCustomerETDLoadResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ServiceReference2.Mensaje putCustomerETDLoadResult;
        
        public putCustomerETDLoadResponseBody()
        {
        }
        
        public putCustomerETDLoadResponseBody(ServiceReference2.Mensaje putCustomerETDLoadResult)
        {
            this.putCustomerETDLoadResult = putCustomerETDLoadResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class putCustomerETDLoadXMLRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="putCustomerETDLoadXML", Namespace="http://www.dbnet.cl", Order=0)]
        public ServiceReference2.putCustomerETDLoadXMLRequestBody Body;
        
        public putCustomerETDLoadXMLRequest()
        {
        }
        
        public putCustomerETDLoadXMLRequest(ServiceReference2.putCustomerETDLoadXMLRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.dbnet.cl")]
    public partial class putCustomerETDLoadXMLRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string lsXML;
        
        public putCustomerETDLoadXMLRequestBody()
        {
        }
        
        public putCustomerETDLoadXMLRequestBody(string lsXML)
        {
            this.lsXML = lsXML;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class putCustomerETDLoadXMLResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="putCustomerETDLoadXMLResponse", Namespace="http://www.dbnet.cl", Order=0)]
        public ServiceReference2.putCustomerETDLoadXMLResponseBody Body;
        
        public putCustomerETDLoadXMLResponse()
        {
        }
        
        public putCustomerETDLoadXMLResponse(ServiceReference2.putCustomerETDLoadXMLResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.dbnet.cl")]
    public partial class putCustomerETDLoadXMLResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string putCustomerETDLoadXMLResult;
        
        public putCustomerETDLoadXMLResponseBody()
        {
        }
        
        public putCustomerETDLoadXMLResponseBody(string putCustomerETDLoadXMLResult)
        {
            this.putCustomerETDLoadXMLResult = putCustomerETDLoadXMLResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface CustomerETDLoadASPSoapChannel : ServiceReference2.CustomerETDLoadASPSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class CustomerETDLoadASPSoapClient : System.ServiceModel.ClientBase<ServiceReference2.CustomerETDLoadASPSoap>, ServiceReference2.CustomerETDLoadASPSoap
    {
        
    /// <summary>
    /// Implemente este método parcial para configurar el punto de conexión de servicio.
    /// </summary>
    /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
    /// <param name="clientCredentials">Credenciales de cliente</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CustomerETDLoadASPSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(CustomerETDLoadASPSoapClient.GetBindingForEndpoint(endpointConfiguration), CustomerETDLoadASPSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerETDLoadASPSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CustomerETDLoadASPSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerETDLoadASPSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CustomerETDLoadASPSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CustomerETDLoadASPSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference2.putCustomerETDLoadResponse> ServiceReference2.CustomerETDLoadASPSoap.putCustomerETDLoadAsync(ServiceReference2.putCustomerETDLoadRequest request)
        {
            return base.Channel.putCustomerETDLoadAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.putCustomerETDLoadResponse> putCustomerETDLoadAsync(ServiceReference2.Extras Extras, ServiceReference2.Encabezado Encabezado, ServiceReference2.Detalle[] Detalles, ServiceReference2.DescuentosRecargosyOtros DescuentosRecargosyOtros)
        {
            ServiceReference2.putCustomerETDLoadRequest inValue = new ServiceReference2.putCustomerETDLoadRequest();
            inValue.Body = new ServiceReference2.putCustomerETDLoadRequestBody();
            inValue.Body.Extras = Extras;
            inValue.Body.Encabezado = Encabezado;
            inValue.Body.Detalles = Detalles;
            inValue.Body.DescuentosRecargosyOtros = DescuentosRecargosyOtros;
            return ((ServiceReference2.CustomerETDLoadASPSoap)(this)).putCustomerETDLoadAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference2.putCustomerETDLoadXMLResponse> ServiceReference2.CustomerETDLoadASPSoap.putCustomerETDLoadXMLAsync(ServiceReference2.putCustomerETDLoadXMLRequest request)
        {
            return base.Channel.putCustomerETDLoadXMLAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.putCustomerETDLoadXMLResponse> putCustomerETDLoadXMLAsync(string lsXML)
        {
            ServiceReference2.putCustomerETDLoadXMLRequest inValue = new ServiceReference2.putCustomerETDLoadXMLRequest();
            inValue.Body = new ServiceReference2.putCustomerETDLoadXMLRequestBody();
            inValue.Body.lsXML = lsXML;
            return ((ServiceReference2.CustomerETDLoadASPSoap)(this)).putCustomerETDLoadXMLAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CustomerETDLoadASPSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.CustomerETDLoadASPSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CustomerETDLoadASPSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://13.68.199.98/wssCustomerETDLoadASPUBL21/CustomerETDLoadASP.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.CustomerETDLoadASPSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://13.68.199.98/wssCustomerETDLoadASPUBL21/CustomerETDLoadASP.asmx");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            CustomerETDLoadASPSoap,
            
            CustomerETDLoadASPSoap12,
        }
    }
}
