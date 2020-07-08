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
    public class AspNetRoles
    {
        private Repositorio<ent.AspNetRoles> _repositorio = new Repositorio<ent.AspNetRoles>(new ApplicationDbContext());
        public List<ent.AspNetRoles> ObtenerAllRoles()
        {
            List<ent.AspNetRoles> roles = new List<ent.AspNetRoles>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_GetAllRoles";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new ent.AspNetRoles
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        NormalizedName = reader["Name"].ToString()
                    };
                    roles.Add(item);
                }
            }
            conn.Close();
            return roles;
        }

        public void Adicionar(ent.AspNetRoles entidad)
        {

            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.AspNetRoles entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.AspNetRoles entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.AspNetRoles> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.AspNetRoles BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.AspNetRoles BuscarPrimero(Expression<Func<ent.AspNetRoles, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.AspNetRoles> Buscar(Expression<Func<ent.AspNetRoles, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
