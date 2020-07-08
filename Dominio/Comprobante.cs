using Repositorio;
using System;
using System.Collections.Generic;
using datoDto = Datos.Entidades.DTO;
using ent = Datos.Entidades.Models;
using System.Linq.Expressions;
using Datos.Context;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace Dominio
{
    public class Comprobante
    {
        private Repositorio<ent.Comprobante> _repositorio = new Repositorio<ent.Comprobante>(new ApplicationDbContext());

        public List<datoDto.ReporteMesDetalladoResponse> ObtenerReporteMesDetallado(datoDto.ReporteMesDetalladoRequest request)
        {
            List<datoDto.ReporteMesDetalladoResponse> listaReporteMesDetallado = new List<datoDto.ReporteMesDetalladoResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteMesDetallado";
            cmd.Parameters.Add("@Mes", System.Data.SqlDbType.Int).Value = request.Mes;
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteMesDetalladoResponse
                    {
                        Documento = Convert.ToString(reader["Documento"]),
                        Serie = Convert.ToString(reader["Serie"]),
                        Correlativo = Convert.ToInt32(reader["Correlativo"]),
                        NroDocumento = Convert.ToString(reader["NroDocumento"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Importe = Convert.ToDecimal(reader["Importe"]),
                        Estado = Convert.ToString(reader["Estado"]),

                    };
                    listaReporteMesDetallado.Add(item);
                }
            }
            conn.Close();
            return listaReporteMesDetallado;
        }

        public List<datoDto.ReporteTopProductosResponse> ObtenerReporteTopProductos(datoDto.ReporteTopProductosRequest request)
        {
            List<datoDto.ReporteTopProductosResponse> listaReporteTopProductos = new List<datoDto.ReporteTopProductosResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteTopProductos";
            cmd.Parameters.Add("@Mes", System.Data.SqlDbType.Int).Value = request.Mes;
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteTopProductosResponse
                    {
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        Ganado = Convert.ToDecimal(reader["Ganado"]),
                        Vendido = Convert.ToDecimal(reader["Vendido"]),
                        UnidadMedidaId = Convert.ToString(reader["UnidadMedida_id"]),
                    };
                    listaReporteTopProductos.Add(item);
                }
            }
            conn.Close();
            return listaReporteTopProductos;
        }

        public List<datoDto.ReporteTopEmpleadosResponse> ObtenerReporteTopEmpleados(datoDto.ReporteTopEmpleadosRequest request)
        {
            List<datoDto.ReporteTopEmpleadosResponse> listaReporteTopEmpleados = new List<datoDto.ReporteTopEmpleadosResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteTopEmpleados";
            cmd.Parameters.Add("@Mes", System.Data.SqlDbType.Int).Value = request.Mes;
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteTopEmpleadosResponse
                    {
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        Ganado = Convert.ToDecimal(reader["Ganado"]),
                        Vendido = Convert.ToDecimal(reader["Vendido"])
                    };
                    listaReporteTopEmpleados.Add(item);
                }
            }
            conn.Close();
            return listaReporteTopEmpleados;
        }

        public List<datoDto.ReporteTopClientesResponse> ObtenerReporteTopClientes(datoDto.ReporteTopClientesRequest request)
        {
            List<datoDto.ReporteTopClientesResponse> listaReporteTopClientes = new List<datoDto.ReporteTopClientesResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteTopClientes";
            cmd.Parameters.Add("@Mes", System.Data.SqlDbType.Int).Value = request.Mes;
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteTopClientesResponse
                    {
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        Ganancia = Convert.ToDecimal(reader["Ganado"]),
                        Vendido = Convert.ToDecimal(reader["Vendido"]),
                    };
                    listaReporteTopClientes.Add(item);
                }
            }
            conn.Close();
            return listaReporteTopClientes;
        }

        public List<datoDto.ReporteAnualResponse> ObtenerReporteAnual(datoDto.ReporteAnualRequest request)
        {
            List<datoDto.ReporteAnualResponse> listaReporteAnual = new List<datoDto.ReporteAnualResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteAnual";
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteAnualResponse
                    {
                        AnioEmitido = Convert.ToInt32(reader["Anio"]),
                        Boleta = Convert.ToDecimal(reader["Boleta"]),
                        Factura = Convert.ToDecimal(reader["Factura"]),
                        Menudeo = Convert.ToDecimal(reader["Menudeo"]),
                        Debito = Convert.ToDecimal(reader["Debito"]),
                        Ganancia = Convert.ToDecimal(reader["Ganancia"]),
                        Vendido = Convert.ToDecimal(reader["Vendido"]),
                    };
                    listaReporteAnual.Add(item);
                }
            }
            conn.Close();
            return listaReporteAnual;
        }

        public List<datoDto.ReporteMensualResponse> ObtenerReporteMensual(datoDto.ReporteMensualRequest request)
        {
            List<datoDto.ReporteMensualResponse> listaReporteMensual = new List<datoDto.ReporteMensualResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteMensual";
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteMensualResponse
                    {
                        MesEmitido = Convert.ToInt32(reader["Mes"]),
                        Boleta = Convert.ToDecimal(reader["Boleta"]),
                        Factura = Convert.ToDecimal(reader["Factura"]),
                        Menudeo = Convert.ToDecimal(reader["Menudeo"]),
                        Debito = Convert.ToDecimal(reader["Debito"]),
                        Ganancia = Convert.ToDecimal(reader["Ganancia"]),
                        Vendido = Convert.ToDecimal(reader["Vendido"]),
                    };
                    listaReporteMensual.Add(item);
                }
            }
            conn.Close();
            return listaReporteMensual;
        }

        public List<datoDto.ReporteDiarioResponse> ObtenerReporteDiario(datoDto.ReporteDiarioRequest request)
        {
            List<datoDto.ReporteDiarioResponse> listaReporteDiario = new List<datoDto.ReporteDiarioResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteDiario";
            cmd.Parameters.Add("@Mes", System.Data.SqlDbType.Int).Value = request.Mes;
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ReporteDiarioResponse
                    {
                        FechaEmitido = Convert.ToDateTime(reader["FechaEmitido"]),
                        Boleta = Convert.ToDecimal(reader["Boleta"]),
                        Factura = Convert.ToDecimal(reader["Factura"]),
                        Menudeo = Convert.ToDecimal(reader["Menudeo"]),
                        Debito = Convert.ToDecimal(reader["Debito"]),
                        Ganancia = Convert.ToDecimal(reader["Ganancia"]),
                        Vendido = Convert.ToDecimal(reader["Vendido"]),
                    };
                    listaReporteDiario.Add(item);
                }
            }
            conn.Close();
            return listaReporteDiario;
        }

        public List<datoDto.ComprobanteGrilla> BuscarComprobantes(string Empresa_id, string Serie, string ClienteNombre, int? ComprobanteTipo_id, int? Estado, DateTime? FechaEmitidoInicio, DateTime? FechaEmitidoFin)
        {
            List<datoDto.ComprobanteGrilla> comprobantes = new List<datoDto.ComprobanteGrilla>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerComprobantes";
            cmd.Parameters.Add("@Empresa_id", System.Data.SqlDbType.VarChar, 11).Value = Empresa_id;
            cmd.Parameters.Add("@Serie", System.Data.SqlDbType.VarChar, 5).Value = Serie;
            cmd.Parameters.Add("@ClienteNombre", System.Data.SqlDbType.VarChar, 100).Value = ClienteNombre;
            cmd.Parameters.Add("@ComprobanteTipo_id", System.Data.SqlDbType.TinyInt).Value = ComprobanteTipo_id;
            cmd.Parameters.Add("@Estado", System.Data.SqlDbType.TinyInt).Value = Estado;
            cmd.Parameters.Add("@FechaEmitidoInicio", System.Data.SqlDbType.Date).Value = FechaEmitidoInicio;
            cmd.Parameters.Add("@FechaEmitidoFin", System.Data.SqlDbType.Date).Value = FechaEmitidoFin;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new datoDto.ComprobanteGrilla
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        EmpresaId = reader["Empresa_id"].ToString(),
                        ComprobanteTipoId = Convert.ToByte(reader["ComprobanteTipo_id"]),
                        Serie = reader["Serie"].ToString(),
                        Correlativo = reader["Correlativo"].ToString(),
                        Codigo = reader["Codigo"].ToString(),
                        ClienteNombre = reader["ClienteNombre"].ToString(),
                        Estado = Convert.ToByte(reader["Estado"]),
                        EstadoNombre = reader["EstadoNombre"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        FechaEmitido = Convert.ToDateTime(reader["FechaEmitido"]),
                        Iva = Convert.ToDecimal(reader["Iva"]),
                        SubTotal = Convert.ToDecimal(reader["SubTotal"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        Impresion = Convert.ToByte(reader["Impresion"]),
                        NombreUsuario = reader["Nombre"].ToString(),
                        UsuarioId = reader["Usuario"].ToString(),
                        ClienteIdentidad = reader["ClienteIdentidad"].ToString(),
                    };
                    comprobantes.Add(item);
                }
            }
            conn.Close();
            return comprobantes;
        }

        public void Adicionar(ent.Comprobante entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Comprobante entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Comprobante entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Comprobante> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Comprobante BuscarPorId(long id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Comprobante BuscarPrimero(Expression<Func<ent.Comprobante, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Comprobante> Buscar(Expression<Func<ent.Comprobante, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }

    public class ComprobanteDetalles
    {
        private Repositorio<ent.Comprobantedetalle> _repositorio = new Repositorio<ent.Comprobantedetalle>(new ApplicationDbContext());
        public void Adicionar(ent.Comprobantedetalle entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Comprobantedetalle entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Comprobantedetalle entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Comprobantedetalle> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Comprobantedetalle BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Comprobantedetalle BuscarPrimero(Expression<Func<ent.Comprobantedetalle, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Comprobantedetalle> Buscar(Expression<Func<ent.Comprobantedetalle, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }

    }
}
