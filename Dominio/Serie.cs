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
    public class Serie
    {
        private Repositorio<ent.Serie> _repositorio = new Repositorio<ent.Serie>(new ApplicationDbContext());

        public void Adicionar(ent.Serie entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Serie entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Serie entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Serie> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Serie BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Serie BuscarPrimero(Expression<Func<ent.Serie, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Serie> Buscar(Expression<Func<ent.Serie, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
