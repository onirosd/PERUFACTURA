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
    public class DataRuc
    {
        private Repositorio<ent.DataRuc> _repositorio = new Repositorio<ent.DataRuc>(new ApplicationDbContext());

        public void Adicionar(ent.DataRuc entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.DataRuc entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.DataRuc entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.DataRuc> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.DataRuc BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.DataRuc BuscarPrimero(Expression<Func<ent.DataRuc, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.DataRuc> Buscar(Expression<Func<ent.DataRuc, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
