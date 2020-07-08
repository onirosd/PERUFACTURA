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
    public class Almacen
    {

        private Repositorio<ent.Almacen> _repositorio = new Repositorio<ent.Almacen>(new ApplicationDbContext());

        public List<dto.KardexGrilla> BuscarKardexByFecha(dto.KardexGrillaRequestByFecha r)
        {
            List<dto.KardexGrilla> listaAlmacen = new List<dto.KardexGrilla>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerKardexByFecha";
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = r.EmpresaId;
            cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.Date).Value = r.Fecha;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.KardexGrilla
                    {
                        Id = Convert.ToInt64(reader["id"]),
                        Tipo = Convert.ToByte(reader["Tipo"]),
                        ProductoId = Convert.ToInt32(reader["Producto_id"]),
                        ProductoNombre = reader["ProductoNombre"].ToString(),
                        UnidadMedidaId = reader["UnidadMedida_id"].ToString(),
                        Cantidad = Convert.ToDecimal(reader["Cantidad"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToDecimal(reader["Stock"])
                    };
                    listaAlmacen.Add(item);
                }
            }
            conn.Close();
            return listaAlmacen;
        }

        public List<dto.KardexGrilla> BuscarKardexByRangoFecha(dto.KardexGrillaRequestByRango r)
        {
            List<dto.KardexGrilla> listaAlmacen = new List<dto.KardexGrilla>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerKardexByRangoFechas";
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = r.EmpresaId;
            cmd.Parameters.Add("@FechaInicio", System.Data.SqlDbType.Date).Value = r.FechaInicio;
            cmd.Parameters.Add("@FechaFin", System.Data.SqlDbType.Date).Value = r.FechaFin;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.KardexGrilla
                    {
                        Id = Convert.ToInt64(reader["id"]),
                        Tipo = Convert.ToByte(reader["Tipo"]),
                        ProductoId = Convert.ToInt32(reader["Producto_id"]),
                        ProductoNombre = reader["ProductoNombre"].ToString(),
                        UnidadMedidaId = reader["UnidadMedida_id"].ToString(),
                        Cantidad = Convert.ToDecimal(reader["Cantidad"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToDecimal(reader["Stock"])
                    };
                    listaAlmacen.Add(item);
                }
            }
            conn.Close();
            return listaAlmacen;
        }

        public List<dto.AlmacenGrilla> BuscarAlmacen(string EmpresaId, byte Tipo)
        {
            List<dto.AlmacenGrilla> listaAlmacen = new List<dto.AlmacenGrilla>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerAlmacen";
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = EmpresaId;
            cmd.Parameters.Add("@Tipo", System.Data.SqlDbType.TinyInt).Value = Tipo;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.AlmacenGrilla
                    {
                        Id = Convert.ToInt64(reader["id"]),
                        Tipo = Convert.ToByte(reader["Tipo"]),
                        UsuarioId = reader["Usuario_id"].ToString(),
                        ProductoId = Convert.ToInt32(reader["Producto_id"]),
                        ProductoNombre = reader["ProductoNombre"].ToString(),
                        UnidadMedidaId = reader["UnidadMedida_id"].ToString(),
                        Cantidad = Convert.ToDecimal(reader["Cantidad"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        EmpresaId = reader["Empresa_id"].ToString(),
                        ComprobanteId = Convert.ToInt32(reader["Comprobante_id"]),
                        NombrePersona = reader["UsuarioNombre"].ToString(),
                        TipoNombre = reader["TipoNombre"].ToString(),
                    };
                    listaAlmacen.Add(item);
                }
            }
            conn.Close();
            return listaAlmacen;
        }

        public void Adicionar(ent.Almacen entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Almacen entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Almacen entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Almacen> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Almacen BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Almacen BuscarPrimero(Expression<Func<ent.Almacen, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Almacen> Buscar(Expression<Func<ent.Almacen, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
