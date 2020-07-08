using System;
using System.Collections.Generic;
using System.Linq;
using Repositorio;
using datos = Datos;
using ent = Datos.Entidades.Models;
using System.Linq.Expressions;
using Datos.Context;

namespace Dominio
{
    public class AspNetUsers
    {
        private Repositorio<ent.AspNetUsers> _repositorio = new Repositorio<ent.AspNetUsers>(new ApplicationDbContext());
        public void Adicionar(ent.AspNetUsers entidad)
        {

            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.AspNetUsers entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.AspNetUsers entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.AspNetUsers> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.AspNetUsers BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.AspNetUsers BuscarPrimero(Expression<Func<ent.AspNetUsers, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.AspNetUsers> Buscar(Expression<Func<ent.AspNetUsers, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
