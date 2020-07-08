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
    public class Servicio
    {
        private Repositorio<ent.Servicio> _repositorio = new Repositorio<ent.Servicio>(new ApplicationDbContext());

        public void Adicionar(ent.Servicio entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Servicio entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Servicio entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Servicio> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Servicio BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Servicio BuscarPrimero(Expression<Func<ent.Servicio, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Servicio> Buscar(Expression<Func<ent.Servicio, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
