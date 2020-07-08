using Repositorio;
using System;
using System.Collections.Generic;
using datos = Datos;
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
    public class Menu
    {
        private Repositorio<ent.Menu> _repositorio = new Repositorio<ent.Menu>(new ApplicationDbContext());
        public void Adicionar(ent.Menu entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Menu entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Menu entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Menu> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Menu BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Menu BuscarPrimero(Expression<Func<ent.Menu, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Menu> Buscar(Expression<Func<ent.Menu, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }

        public List<ent.Menu> BuscarByNombreRol(string RoleName)
        {
            List<ent.Menu> menu = new List<ent.Menu>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_GetRole";
            cmd.Parameters.Add("@RoleName", System.Data.SqlDbType.VarChar, 455).Value = RoleName;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new ent.Menu
                    {
                        Class = reader["Class"].ToString(),
                        Css = reader["Css"].ToString(),
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Orden = Convert.ToInt32(reader["Orden"]),
                        Padre = Convert.ToInt32(reader["Padre"]),
                        Separador = Convert.ToInt32(reader["Separador"]),
                        Url = reader["Url"].ToString()
                    };
                    menu.Add(item);
                }
            }
            conn.Close();
            return menu;
        }
    }

    public class Menusuario
    {
        private Repositorio<ent.Menusuario> _repositorio = new Repositorio<ent.Menusuario>(new ApplicationDbContext());
        public void Adicionar(ent.Menusuario entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Menusuario entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Menusuario entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Menusuario> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Menusuario BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Menusuario BuscarPrimero(Expression<Func<ent.Menusuario, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Menusuario> Buscar(Expression<Func<ent.Menusuario, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }

        
    }
}
