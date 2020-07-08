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
    public class Empresa
    {
        private Repositorio<ent.Empresa> _repositorio = new Repositorio<ent.Empresa>(new ApplicationDbContext());

        public void Adicionar(ent.Empresa entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Empresa entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Empresa entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Empresa> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Empresa BuscarPorId(string id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Empresa BuscarPrimero(Expression<Func<ent.Empresa, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Empresa> Buscar(Expression<Func<ent.Empresa, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
