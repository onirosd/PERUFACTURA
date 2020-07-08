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
    public class AspNetUserRoles
    {
        
        private Repositorio<ent.AspNetUserRoles> _repositorio = new Repositorio<ent.AspNetUserRoles>(new ApplicationDbContext());
        public void Adicionar(ent.AspNetUserRoles entidad)
        {

            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.AspNetUserRoles entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.AspNetUserRoles entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.AspNetUserRoles> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.AspNetUserRoles BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.AspNetUserRoles BuscarPrimero(Expression<Func<ent.AspNetUserRoles, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.AspNetUserRoles> Buscar(Expression<Func<ent.AspNetUserRoles, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
