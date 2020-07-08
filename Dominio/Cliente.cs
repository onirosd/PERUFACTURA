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
    public class Cliente
    {
        private Repositorio<ent.Cliente> _repositorio = new Repositorio<ent.Cliente>(new ApplicationDbContext());

        public void Adicionar(ent.Cliente entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Cliente entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Cliente entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Cliente> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Cliente BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Cliente BuscarPrimero(Expression<Func<ent.Cliente, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Cliente> Buscar(Expression<Func<ent.Cliente, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}
