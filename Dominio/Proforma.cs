using Repositorio;
using System;
using System.Collections.Generic;
using datos = Datos;
using ent = Datos.Entidades.Models;
using dto = Datos.Entidades.DTO;
using System.Linq.Expressions;
using Datos.Context;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace Dominio
{
    public class Proforma
    {
        private Repositorio<ent.Proforma> _repositorio = new Repositorio<ent.Proforma>(new ApplicationDbContext());

        public List<dto.ReporteMesDetalladoResponse> ObtenerReporteMesDetalladoProforma(dto.ReporteMesDetalladoRequest request)
        {
            List<dto.ReporteMesDetalladoResponse> listaReporteMesDetallado = new List<dto.ReporteMesDetalladoResponse>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerReporteMesDetalladoProforma";
            cmd.Parameters.Add("@Mes", System.Data.SqlDbType.Int).Value = request.Mes;
            cmd.Parameters.Add("@Anio", System.Data.SqlDbType.Int).Value = request.Anio;
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = request.EmpresaId;
            cmd.Parameters.Add("@TipoMonedaId", System.Data.SqlDbType.VarChar, 10).Value = request.TipoMonedaId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.ReporteMesDetalladoResponse
                    {
                        Serie = Convert.ToString(reader["Serie"]),
                        Correlativo = Convert.ToInt32(reader["Correlativo"]),
                        NroDocumento = Convert.ToString(reader["NroDocumento"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Importe = Convert.ToDecimal(reader["Importe"]),
                    };
                    listaReporteMesDetallado.Add(item);
                }
            }
            conn.Close();
            return listaReporteMesDetallado;
        }

        public List<dto.ProformaGrilla> ObtenerProformasGrilla(dto.ProformaGrillaRequest r)
        {
            List<dto.ProformaGrilla> listaProformas = new List<dto.ProformaGrilla>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ListarProformas";
            cmd.Parameters.Add("@Empresaid", System.Data.SqlDbType.VarChar, 11).Value = r.EmpresaId;
            cmd.Parameters.Add("@Serie", System.Data.SqlDbType.VarChar, 5).Value = r.Serie;
            cmd.Parameters.Add("@ClienteNombre", System.Data.SqlDbType.VarChar, 100).Value = r.ClienteNombre;
            cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar, 256).Value = r.Usuario;
            cmd.Parameters.Add("@FechaInicio", System.Data.SqlDbType.VarChar, 10).Value = r.FechaInicio;
            cmd.Parameters.Add("@FechaFin", System.Data.SqlDbType.VarChar, 10).Value = r.FechaFin;
            cmd.Parameters.Add("@Estado", System.Data.SqlDbType.TinyInt).Value = r.Estado;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.ProformaGrilla
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        EmpresaId = Convert.ToString(reader["Empresa_id"]),
                        ComprobanteTipoId = Convert.ToInt32(reader["ComprobanteTipo_id"]),
                        Serie = Convert.ToString(reader["Serie"]),
                        Codigo = Convert.ToString(reader["Codigo"]),
                        ClienteNombre = Convert.ToString(reader["ClienteNombre"]),
                        Estado = Convert.ToInt32(reader["Estado"]),
                        EstadoNombre = Convert.ToString(reader["EstadoNombre"]),
                        Tipo = Convert.ToString(reader["Tipo"]),
                        FechaEmitido = Convert.ToString(reader["FechaEmitido"]),
                        Iva = Convert.ToDecimal(reader["Iva"]),
                        SubTotal = Convert.ToDecimal(reader["SubTotal"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        Impresion = Convert.ToInt32(reader["Impresion"]),
                        Nombre = Convert.ToString(reader["Nombre"]),
                        Usuario = Convert.ToString(reader["Usuario"]),
                    };
                    listaProformas.Add(item);
                }
            }
            conn.Close();
            return listaProformas;
        }

        //public bool GuardarProforma(ent.Proforma cabecera, List<ProformaDetalle> detalle) {
        //    using (var tran = _repositorio.ObtenerContexto().BeginTransaction())
        //    {
        //        try
        //        {
        //            _repositorio.Adicionar(cabecera);
        //            _repositorio.
        //            // your code
        //            tran.Commit();
        //        }
        //        catch
        //        {
        //            tran.Rollback();
        //            throw;
        //        }
        //    }
        //    return true;
        //}

        public void Adicionar(ent.Proforma entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Proforma entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Proforma entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Proforma> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Proforma BuscarPorId(long id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Proforma BuscarPrimero(Expression<Func<ent.Proforma, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Proforma> Buscar(Expression<Func<ent.Proforma, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
