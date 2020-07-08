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
    public class Producto
    {
        private Repositorio<ent.Producto> _repositorio = new Repositorio<ent.Producto>(new ApplicationDbContext());

        public List<dto.ProductoServicio> BuscarProductosYServicios(string Empresaid, string Nombre)
        {
            List<dto.ProductoServicio> listaProductoServicio = new List<dto.ProductoServicio>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ProductosYServicios";
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = Empresaid;
            cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 100).Value = Nombre;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.ProductoServicio
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        UnidadMedidaId = reader["UnidadMedida_id"].ToString(),
                        PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Marca = reader["Marca"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Stock = Convert.ToDecimal(reader["Stock"]),
                        Tipo = Convert.ToInt32(reader["Tipo"]),
                    };
                    listaProductoServicio.Add(item);
                }
            }
            conn.Close();
            return listaProductoServicio;
        }

        public void Adicionar(ent.Producto entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Producto entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Producto entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Producto> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Producto BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Producto BuscarPrimero(Expression<Func<ent.Producto, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Producto> Buscar(Expression<Func<ent.Producto, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
