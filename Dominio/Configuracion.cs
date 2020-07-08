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
    public class Configuracion
    {
        private Repositorio<ent.Configuracion> _repositorio = new Repositorio<ent.Configuracion>(new ApplicationDbContext());

        public void Adicionar(ent.Configuracion entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Configuracion entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Configuracion entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Configuracion> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Configuracion BuscarPorId(string id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Configuracion BuscarPrimero(Expression<Func<ent.Configuracion, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Configuracion> Buscar(Expression<Func<ent.Configuracion, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
