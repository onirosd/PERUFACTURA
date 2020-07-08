using AutoMapper;
using ent = Aplicacion.Entidades.Models;
using datos = Datos.Entidades.Models;
using entDto = Aplicacion.Entidades.DTO;
using datosDto = Datos.Entidades.DTO;

namespace Mapeo
{
    public class Mapeos : Profile
    {
        public Mapeos()
        {
            CreateMap<ent.Almacen, datos.Almacen>();
            CreateMap<datos.Almacen, ent.Almacen>();

            CreateMap<ent.Cliente, datos.Cliente>();
            CreateMap<datos.Cliente, ent.Cliente>();

            CreateMap<ent.Comprobante, datos.Comprobante>();
            CreateMap<datos.Comprobante, ent.Comprobante>();

            CreateMap<ent.Comprobantedetalle, datos.Comprobantedetalle>();
            CreateMap<datos.Comprobantedetalle, ent.Comprobantedetalle>();

            CreateMap<ent.Configuracion, datos.Configuracion>();
            CreateMap<datos.Configuracion, ent.Configuracion>();

            CreateMap<ent.Empresa, datos.Empresa>();
            CreateMap<datos.Empresa, ent.Empresa>();

            CreateMap<ent.Menu, datos.Menu>();
            CreateMap<datos.Menu, ent.Menu>();

            CreateMap<ent.Menusuario, datos.Menusuario>();
            CreateMap<datos.Menusuario, ent.Menusuario>();

            CreateMap<ent.Producto, datos.Producto>();
            CreateMap<datos.Producto, ent.Producto>();

            CreateMap<ent.Proforma, datos.Proforma>();
            CreateMap<datos.Proforma, ent.Proforma>();

            CreateMap<ent.Proformadetalle, datos.Proformadetalle>();
            CreateMap<datos.Proformadetalle, ent.Proformadetalle>();

            CreateMap<ent.Serie, datos.Serie>();
            CreateMap<datos.Serie, ent.Serie>();

            CreateMap<ent.Servicio, datos.Servicio>();
            CreateMap<datos.Servicio, ent.Servicio>();

            CreateMap<ent.Tabladato, datos.Tabladato>();
            CreateMap<datos.Tabladato, ent.Tabladato>();

            CreateMap<ent.Usuario, datos.Usuario>();
            CreateMap<datos.Usuario, ent.Usuario>();

            CreateMap<ent.AspNetUserRoles, datos.AspNetUserRoles>();
            CreateMap<datos.AspNetUserRoles, ent.AspNetUserRoles>();

            CreateMap<ent.AspNetRoles, datos.AspNetRoles>();
            CreateMap<datos.AspNetRoles, ent.AspNetRoles>();

            CreateMap<ent.AspNetUsers, datos.AspNetUsers>();
            CreateMap<datos.AspNetUsers, ent.AspNetUsers>();

            CreateMap<ent.DataRuc, datos.DataRuc>();
            CreateMap<datos.DataRuc, ent.DataRuc>();

            CreateMap<entDto.UsuarioGrillaRequest, datosDto.UsuarioGrillaRequest>();
            CreateMap<datosDto.UsuarioGrillaRequest, entDto.UsuarioGrillaRequest>();

            CreateMap<entDto.UsuarioGrilla, datosDto.UsuarioGrilla>();
            CreateMap<datosDto.UsuarioGrilla, entDto.UsuarioGrilla>();

            CreateMap<entDto.KardexGrillaRequestByFecha, datosDto.KardexGrillaRequestByFecha>();
            CreateMap<datosDto.KardexGrillaRequestByFecha, entDto.KardexGrillaRequestByFecha>();

            CreateMap<entDto.KardexGrillaRequestByRango, datosDto.KardexGrillaRequestByRango>();
            CreateMap<datosDto.KardexGrillaRequestByRango, entDto.KardexGrillaRequestByRango>();

            CreateMap<entDto.KardexGrilla, datosDto.KardexGrilla>();
            CreateMap<datosDto.KardexGrilla, entDto.KardexGrilla>();

            CreateMap<entDto.ReporteResumenBasico, datosDto.ReporteResumenBasico>();
            CreateMap<datosDto.ReporteResumenBasico, entDto.ReporteResumenBasico>();

            CreateMap<entDto.ProformaGrilla, datosDto.ProformaGrilla>();
            CreateMap<datosDto.ProformaGrilla, entDto.ProformaGrilla>();

            CreateMap<entDto.ProformaGrillaRequest, datosDto.ProformaGrillaRequest>();
            CreateMap<datosDto.ProformaGrillaRequest, entDto.ProformaGrillaRequest>();

            CreateMap<entDto.ProductoServicio, datosDto.ProductoServicio>();
            CreateMap<datosDto.ProductoServicio, entDto.ProductoServicio>();

            CreateMap<entDto.ReporteDiarioResponse, datosDto.ReporteDiarioResponse>();
            CreateMap<datosDto.ReporteDiarioResponse, entDto.ReporteDiarioResponse>();

            CreateMap<entDto.ReporteDiarioRequest, datosDto.ReporteDiarioRequest>();
            CreateMap<datosDto.ReporteDiarioRequest, entDto.ReporteDiarioRequest>();

            CreateMap<entDto.ReporteMensualResponse, datosDto.ReporteMensualResponse>();
            CreateMap<datosDto.ReporteMensualResponse, entDto.ReporteMensualResponse>();

            CreateMap<entDto.ReporteMensualRequest, datosDto.ReporteMensualRequest>();
            CreateMap<datosDto.ReporteMensualRequest, entDto.ReporteMensualRequest>();

            CreateMap<entDto.ReporteAnualResponse, datosDto.ReporteAnualResponse>();
            CreateMap<datosDto.ReporteAnualResponse, entDto.ReporteAnualResponse>();

            CreateMap<entDto.ReporteAnualRequest, datosDto.ReporteAnualRequest>();
            CreateMap<datosDto.ReporteAnualRequest, entDto.ReporteAnualRequest>();

            CreateMap<entDto.ReporteTopClientesResponse, datosDto.ReporteTopClientesResponse>();
            CreateMap<datosDto.ReporteTopClientesResponse, entDto.ReporteTopClientesResponse>();

            CreateMap<entDto.ReporteTopClientesRequest, datosDto.ReporteTopClientesRequest>();
            CreateMap<datosDto.ReporteTopClientesRequest, entDto.ReporteTopClientesRequest>();

        }
    }
}
